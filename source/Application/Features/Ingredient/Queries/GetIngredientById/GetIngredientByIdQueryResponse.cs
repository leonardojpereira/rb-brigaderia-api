namespace Project.Application.Features.Queries.GetIngredientById;

public class GetIngredientByIdQueryResponse
{
    public GetIngredientByIdIngredientDTO? Ingredient { get; set; } 
}

public class GetIngredientByIdIngredientDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Measurement { get; set; } = string.Empty;
    public decimal Stock { get; set; }
    public decimal MinimumStock { get; set; }
    public decimal UnitPrice { get; set; }
}