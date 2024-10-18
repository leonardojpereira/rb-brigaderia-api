using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllRecipe
{
    public class GetAllRecipeQueryHandler : IRequestHandler<GetAllRecipeQuery, GetAllRecipeQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public GetAllRecipeQueryHandler(IMediator mediator, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            _mediator = mediator;
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<GetAllRecipeQueryResponse?> Handle(GetAllRecipeQuery request, CancellationToken cancellationToken)
        {
            // Busca todas as receitas
            var dbRecipes = _recipeRepository.GetAll();

            var recipeDTOs = dbRecipes.Select(dbRecipe => new GetAllRecipeDTO
            {
                Id = dbRecipe.Id,
                Nome = dbRecipe.Nome,
                Descricao = dbRecipe.Descricao,
                Ingredientes = dbRecipe.Ingredientes.Select(i =>
                {
                    var ingrediente = _ingredientRepository.Get(ing => ing.Id == i.IngredienteId);
                    return new GetAllRecipeIngredientDTO
                    {
                        IngredienteId = i.IngredienteId,
                        QuantidadeNecessaria = i.QuantidadeNecessaria,
                        Nome = ingrediente?.Name ?? "Desconhecido"
                    };
                }).ToList()
            }).ToList();

            await _mediator.Publish(new DomainSuccessNotification("GetAllRecipe", "Recipes retrieved successfully"), cancellationToken);

            return new GetAllRecipeQueryResponse
            {
                Recipes = recipeDTOs
            };
        }
    }
}
