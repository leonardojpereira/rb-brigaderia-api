
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetIngredientById
{
    public class GetIngredientByIdQueryHandler : IRequestHandler<GetIngredientByIdQuery, GetIngredientByIdQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IIngredientRepository _ingredientRepository;

        public GetIngredientByIdQueryHandler(IMediator mediator, IIngredientRepository ingredientRepository)
        {
            _mediator = mediator;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<GetIngredientByIdQueryResponse?> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            var dbIngredient = _ingredientRepository.Get(ingredient => ingredient.Id == request.Id);
            if (dbIngredient is null)
            {
                await _mediator.Publish(new DomainNotification("GetIngredientById", "Ingredient not found"), cancellationToken);
                return default;
            }
            await _mediator.Publish(new DomainSuccessNotification("GetIngredientById", "Ingredient found successfully"), cancellationToken);

            var ingredientDTO = new GetIngredientByIdIngredientDTO {
                Id = dbIngredient.Id,
                Name = dbIngredient.Name,
                Measurement = dbIngredient.Measurement,
                Stock = dbIngredient.Stock,
                MinimumStock = dbIngredient.MinimumStock,
                UnitPrice = dbIngredient.UnitPrice,
                CreatedAt = dbIngredient.CreatedAt,
                UpdatedAt = dbIngredient.UpdatedAt,
            };

            return new GetIngredientByIdQueryResponse { Ingredient = ingredientDTO };
        }
    }
}