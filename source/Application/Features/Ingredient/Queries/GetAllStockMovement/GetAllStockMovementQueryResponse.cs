namespace Project.Application.Features.Queries.GetAllStockMovement
{
    public class GetAllStockMovementQueryResponse
    {
        public IEnumerable<GetAllStockMovementDTO>? StockMovements { get; set; }
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllStockMovementDTO
    {
        public Guid Id { get; set; }
        public Guid IngredientId { get; set; } 
        public decimal Quantity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string MovementType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
