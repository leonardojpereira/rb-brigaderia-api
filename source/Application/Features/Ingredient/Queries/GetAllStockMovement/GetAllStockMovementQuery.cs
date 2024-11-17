using MediatR;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllStockMovement
{
    public class GetAllStockMovementQuery : Command<GetAllStockMovementQueryResponse>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public DateTime? DataInicial { get; set; } 
        public DateTime? DataFinal { get; set; } 
        public GetAllStockMovementQuery(int pageNumber, int pageSize, DateTime? dataInicial = null, DateTime? dataFinal = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }
    }

}
