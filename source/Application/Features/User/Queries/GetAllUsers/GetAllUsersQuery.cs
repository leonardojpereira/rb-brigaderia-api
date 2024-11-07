using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllUsers
{
    public class GetAllUsersQuery : Command<GetAllUsersQueryResponse>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Filter { get; set; }

        public GetAllUsersQuery(int pageNumber = 1, int pageSize = 10, string? filter = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Filter = filter;
        }
    }
}
