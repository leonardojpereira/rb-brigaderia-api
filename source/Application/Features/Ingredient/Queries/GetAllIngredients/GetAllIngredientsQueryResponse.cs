namespace Project.Application.Features.Queries.GetAllIngredients;

public class GetAllIngredientsQueryResponse
{
    public IEnumerable<GetAllIngredientsIngredientDTO>? Ingredients { get; set; } 
}

public class GetAllIngredientsIngredientDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Measurement { get; set; } = string.Empty;
    public decimal Stock { get; set; }
    public decimal MinimumStock { get; set; }
    public decimal UnitPrice { get; set; }
}