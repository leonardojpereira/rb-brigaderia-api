using Project.Domain.Interfaces.Data.Repositories;

public class GetTopProducedRecipesQueryHandler : IRequestHandler<GetTopProducedRecipesQuery, GetTopProducedRecipesQueryResponse?>
{
    private readonly IProductionRepository _productionRepository;
    private readonly IRecipeRepository _recipeRepository;

    public GetTopProducedRecipesQueryHandler(IProductionRepository productionRepository, IRecipeRepository recipeRepository)
    {
        _productionRepository = productionRepository;
        _recipeRepository = recipeRepository;
    }

    public async Task<GetTopProducedRecipesQueryResponse?> Handle(GetTopProducedRecipesQuery request, CancellationToken cancellationToken)
    {
        var topProductions = await _productionRepository.GetTopProducedRecipesAsync(3);

        var topProducedRecipes = new List<GetTopProducedRecipeDTO>();

        foreach (var top in topProductions)
        {
            var recipe = await _recipeRepository.GetWithIngredientsAsync(top.ReceitaId);

            decimal totalCost = recipe?.Ingredientes.Sum(ri =>
                (ri.Ingredient?.UnitPrice ?? 0) * ri.QuantidadeNecessaria) ?? 0;

            topProducedRecipes.Add(new GetTopProducedRecipeDTO
            {
                Id = recipe?.Id ?? Guid.Empty,
                Nome = recipe?.Nome ?? "Desconhecido",
                Descricao = recipe?.Descricao ?? "Descrição indisponível",
                TotalProduzido = top.TotalProduzido,
                CustoTotal = totalCost
            });
        }

        return new GetTopProducedRecipesQueryResponse
        {
            TopProducedRecipes = topProducedRecipes
        };
    }

}

