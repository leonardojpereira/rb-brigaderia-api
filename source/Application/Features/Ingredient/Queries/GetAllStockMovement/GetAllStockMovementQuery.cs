using MediatR;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllStockMovement
{
    public class GetAllStockMovementQuery : Command<GetAllStockMovementQueryResponse>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10; 

        public GetAllStockMovementQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
