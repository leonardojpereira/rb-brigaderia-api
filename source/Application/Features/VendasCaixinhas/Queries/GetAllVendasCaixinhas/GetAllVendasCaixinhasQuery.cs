using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllVendasCaixinhas
{
    public class GetAllVendasCaixinhasQuery : Command<GetAllVendasCaixinhasQueryResponse>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public GetAllVendasCaixinhasQuery(int pageNumber = 1, int pageSize = 10)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
