using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllVendasCaixinhas
{
    public class GetAllVendasCaixinhasQuery : Command<GetAllVendasCaixinhasQueryResponse>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public DateTime? Date { get; set; }

        public string NomeVendedor { get; set; }

        public GetAllVendasCaixinhasQuery(int pageNumber = 1, int pageSize = 10, DateTime? date = null, string nomeVendedor = "")
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Date = date;
            NomeVendedor = nomeVendedor;
        }
    }
}
