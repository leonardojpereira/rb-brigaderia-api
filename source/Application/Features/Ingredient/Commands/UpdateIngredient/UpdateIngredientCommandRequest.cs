namespace Project.Application.Features.Commands.UpdateIngredient;

public record UpdateIngredientCommandRequest
{
    public string? Name { get; set; }
    public string? Measurement { get; set; }
    public decimal? Stock { get; set; }
    public decimal? MinimumStock { get; set; }
    public decimal? UnitPrice { get; set; }
}