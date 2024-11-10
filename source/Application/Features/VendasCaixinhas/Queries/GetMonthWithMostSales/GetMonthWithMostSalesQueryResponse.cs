namespace Project.Application.Features.Queries.GetMonthWithMostSales
{
    public class GetMonthWithMostSalesQueryResponse
    {
        public List<MonthSalesDTO> MonthlySales { get; set; } = new List<MonthSalesDTO>();
    }

    public class MonthSalesDTO
    {
        public int Month { get; set; }
        public decimal TotalSales { get; set; }
    }
}
