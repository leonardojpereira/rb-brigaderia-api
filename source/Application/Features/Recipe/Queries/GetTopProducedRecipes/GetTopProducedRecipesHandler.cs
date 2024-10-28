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
        // Consulta os IDs das receitas mais produzidas
        var topProductions = await _productionRepository.GetTopProducedRecipesAsync(3);

        // Consulta os detalhes das receitas correspondentes
        var topProducedRecipes = topProductions.Select(top => {
            var recipe = _recipeRepository.Get(r => r.Id == top.ReceitaId);
            return new GetTopProducedRecipeDTO
            {
                Id = recipe?.Id ?? Guid.Empty,
                Nome = recipe?.Nome ?? "Desconhecido",
                Descricao = recipe?.Descricao ?? "Descrição indisponível",
                TotalProduzido = top.TotalProduzido
            };
        }).ToList();

        return new GetTopProducedRecipesQueryResponse
        {
            TopProducedRecipes = topProducedRecipes
        };
    }
}
