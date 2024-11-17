using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetMonthWithMostSales
{
    public class GetMonthWithMostSalesQuery : Command<GetMonthWithMostSalesQueryResponse>
    {
        public int Year { get; set; }

        public GetMonthWithMostSalesQuery(int year)
        {
            Year = year;
        }
    }
}
