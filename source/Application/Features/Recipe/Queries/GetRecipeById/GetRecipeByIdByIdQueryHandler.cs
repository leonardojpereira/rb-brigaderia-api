using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetRecipeById
{
    public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, GetRecipeByIdQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IRecipeRepository _recipeRepository;

        public GetRecipeByIdQueryHandler(IMediator mediator, IRecipeRepository recipeRepository)
        {
            _mediator = mediator;
            _recipeRepository = recipeRepository;
        }

        public async Task<GetRecipeByIdQueryResponse?> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            var dbRecipe = await _recipeRepository.GetWithIngredientsAsync(request.Id);
            if (dbRecipe is null)
            {
                await _mediator.Publish(new DomainNotification("GetRecipeById", "Recipe not found"), cancellationToken);
                return default;
            }

            await _mediator.Publish(new DomainSuccessNotification("GetRecipeById", "Recipe found successfully"), cancellationToken);

            var ingredients = dbRecipe.Ingredientes.Select(i => new GetRecipeByIdIngredientDTO
            {
                IngredienteId = i.IngredienteId,
                Nome = i.Ingredient?.Name ?? "Desconhecido",
                QuantidadeNecessaria = i.QuantidadeNecessaria
            }).ToList();

            decimal totalCost = dbRecipe.Ingredientes.Sum(i =>
                (i.Ingredient?.UnitPrice ?? 0) * i.QuantidadeNecessaria);

            var recipeDTO = new GetRecipeByIdRecipeDTO
            {
                Id = dbRecipe.Id,
                Nome = dbRecipe.Nome,
                Descricao = dbRecipe.Descricao,
                CustoTotal = totalCost,
                Ingredients = ingredients
            };

            return new GetRecipeByIdQueryResponse { Recipe = recipeDTO };
        }

    }
}
