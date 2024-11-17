using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetMaxProfitInADay
{
    public class GetMaxProfitInADayQuery : Command<GetMaxProfitInADayQueryResponse>
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public GetMaxProfitInADayQuery(int year, int month)
        {
            Year = year;
            Month = month;
        }
    }
}
