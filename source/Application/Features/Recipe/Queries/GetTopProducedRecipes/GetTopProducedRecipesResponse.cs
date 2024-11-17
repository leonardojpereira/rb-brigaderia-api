public class GetTopProducedRecipesQuery : IRequest<GetTopProducedRecipesQueryResponse> { }

public class GetTopProducedRecipesQueryResponse
{
    public List<GetTopProducedRecipeDTO> TopProducedRecipes { get; set; } = new List<GetTopProducedRecipeDTO>();
}

public class GetTopProducedRecipeDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int TotalProduzido { get; set; }
    public decimal CustoTotal { get; set; }
}

