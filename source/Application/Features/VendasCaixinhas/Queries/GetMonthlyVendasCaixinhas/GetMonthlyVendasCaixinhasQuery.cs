using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetMonthlyVendasCaixinhas
{
    public class GetMonthlyVendasCaixinhasQuery : Command<GetMonthlyVendasCaixinhasQueryResponse>
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public GetMonthlyVendasCaixinhasQuery(int year, int month)
        {
            Year = year;
            Month = month;
        }
    }
}
