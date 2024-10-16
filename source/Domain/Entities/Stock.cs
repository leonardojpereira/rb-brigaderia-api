namespace Project.Domain.Entities;

public class StockMovement : BaseEntity
{
    public Guid IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = null!;
    
    public decimal Quantity { get; set; }
    public string Description { get; set; } = string.Empty;
    public string MovementType { get; set; } = string.Empty; // "entrada" ou "saida"
}
