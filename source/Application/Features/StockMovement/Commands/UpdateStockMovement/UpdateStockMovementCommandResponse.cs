namespace Project.Application.Features.Commands.UpdateStockMovement;

public record UpdateStockMovementCommandResponse
{
    public Guid Id { get; set; }
    public Guid IngredientId { get; set; }
    public decimal Quantity { get; set; }
    public string Description { get; set; } = string.Empty;
    public string MovementType { get; set; } = string.Empty;
}
