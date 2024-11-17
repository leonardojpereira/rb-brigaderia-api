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
    // Obter receitas paginadas e total de itens
    var (pagedRecipes, totalItems) = await _recipeRepository.GetPagedRecipesAsync(request.PageNumber, request.PageSize, request.Filter);

    var recipeDTOs = pagedRecipes.Select(dbRecipe =>
    {
        decimal totalCost = dbRecipe.Ingredientes.Sum(i =>
            (i.Ingredient?.UnitPrice ?? 0) * i.QuantidadeNecessaria);

        return new GetAllRecipeDTO
        {
            Id = dbRecipe.Id,
            Nome = dbRecipe.Nome,
            Descricao = dbRecipe.Descricao,
            CustoTotal = totalCost,
            Ingredientes = dbRecipe.Ingredientes.Select(i => new GetAllRecipeIngredientDTO
            {
                IngredienteId = i.IngredienteId,
                QuantidadeNecessaria = i.QuantidadeNecessaria,
                Nome = i.Ingredient?.Name ?? "Desconhecido"
            }).ToList()
        };
    }).ToList();

    await _mediator.Publish(new DomainSuccessNotification("GetAllRecipe", "Recipes retrieved successfully"), cancellationToken);

    return new GetAllRecipeQueryResponse
    {
        Recipes = recipeDTOs,
        TotalItems = totalItems
    };
}


    }
}
