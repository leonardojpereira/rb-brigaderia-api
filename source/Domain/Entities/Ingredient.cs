namespace Project.Domain.Entities;

public class Ingredient : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Measurement { get; set; } = string.Empty;
    public decimal Stock { get; set; }
    public decimal MinimumStock { get; set; }
    public decimal UnitPrice { get; set; }
}