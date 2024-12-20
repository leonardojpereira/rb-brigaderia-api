namespace Project.Application.Features.Commands.CreateIngredient;

public record CreateIngredientCommandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Measurement { get; set; } = string.Empty;
    public decimal Stock { get; set; }
    public decimal MinimumStock { get; set; }
    public decimal UnitPrice { get; set; }
}