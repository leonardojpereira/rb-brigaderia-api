using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetProductionById
{
    public class GetProductionByIdQueryHandler : IRequestHandler<GetProductionByIdQuery, GetProductionByIdQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IProductionRepository _productionRepository;
        private readonly IRecipeRepository _recipeRepository;

        public GetProductionByIdQueryHandler(IMediator mediator, IProductionRepository productionRepository, IRecipeRepository recipeRepository)
        {
            _mediator = mediator;
            _productionRepository = productionRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<GetProductionByIdQueryResponse?> Handle(GetProductionByIdQuery request, CancellationToken cancellationToken)
        {
            var dbProduction = await _productionRepository.GetAsync(p => p.Id == request.Id);
            if (dbProduction == null)
            {
                await _mediator.Publish(new DomainNotification("GetProductionById", "Production not found"), cancellationToken);
                return null;
            }

            var recipe = await _recipeRepository.GetWithIngredientsAsync(dbProduction.ReceitaId);
            if (recipe == null)
            {
                await _mediator.Publish(new DomainNotification("GetProductionById", "Recipe not found"), cancellationToken);
                return null;
            }

            var productionDTO = new GetProductionByIdDTO
            {
                Id = dbProduction.Id,
                ReceitaId = recipe.Id,
                NomeReceita = recipe.Nome,
                QuantidadeProduzida = dbProduction.QuantidadeProduzida,
                DataProducao = dbProduction.DataProducao
            };

            await _mediator.Publish(new DomainSuccessNotification("GetProductionById", "Production retrieved successfully"), cancellationToken);

            return new GetProductionByIdQueryResponse
            {
                Productions = new List<GetProductionByIdDTO> { productionDTO }
            };
        }
    }
}
