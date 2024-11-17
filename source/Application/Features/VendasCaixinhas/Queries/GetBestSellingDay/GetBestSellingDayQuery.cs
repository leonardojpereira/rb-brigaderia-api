using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetBestSellingDay
{
    public class GetBestSellingDayQuery : Command<GetBestSellingDayQueryResponse>
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public GetBestSellingDayQuery(int year, int month)
        {
            Year = year;
            Month = month;
        }
    }
}
