using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;
using System.Linq;

namespace Project.Application.Features.Queries.GetAllProduction
{
    public class GetAllProductionQueryHandler : IRequestHandler<GetAllProductionQuery, GetAllProductionQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IProductionRepository _productionRepository;

        public GetAllProductionQueryHandler(IMediator mediator, IProductionRepository productionRepository, IRecipeRepository recipeRepository)
        {
            _mediator = mediator;
            _productionRepository = productionRepository;
        }

        public async Task<GetAllProductionQueryResponse?> Handle(GetAllProductionQuery request, CancellationToken cancellationToken)
        {
            var filteredProductions = _productionRepository.GetAllAsync().Result.AsQueryable();
            if (!string.IsNullOrEmpty(request.Filter))
            {
                filteredProductions = filteredProductions.Where(p => p.Receita != null && p.Receita.Nome.Contains(request.Filter));
            }

            var totalProductions = filteredProductions.Count();

            var paginatedProductions = filteredProductions
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var productionDTOs = paginatedProductions.Select(dbProduction => new GetAllProductionDTO
            {
                Id = dbProduction.Id,
                ReceitaId = dbProduction.ReceitaId,
                QuantidadeProduzida = dbProduction.QuantidadeProduzida,
                DataProducao = dbProduction.DataProducao,
                NomeReceita = dbProduction.Receita?.Nome ?? "Receita desconhecida"
            }).ToList();

            await _mediator.Publish(new DomainSuccessNotification("GetAllProduction", "Productions retrieved successfully"), cancellationToken);

            return new GetAllProductionQueryResponse
            {
                Productions = productionDTOs,
                TotalRecords = totalProductions,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling(totalProductions / (double)request.PageSize)
            };
        }
    }
}
