using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllProduction
{
    public class GetAllProductionQueryHandler : IRequestHandler<GetAllProductionQuery, GetAllProductionQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IProductionRepository _productionRepository;
        private readonly IRecipeRepository _recipeRepository;

        public GetAllProductionQueryHandler(IMediator mediator, IProductionRepository productionRepository, IRecipeRepository recipeRepository)
        {
            _mediator = mediator;
            _productionRepository = productionRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<GetAllProductionQueryResponse?> Handle(GetAllProductionQuery request, CancellationToken cancellationToken)
        {
            var dbProductions = await _productionRepository.GetAllAsync();

            var productionDTOs = dbProductions.Select(dbProduction => new GetAllProductionDTO
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
                Productions = productionDTOs
            };
        }
    }
}
