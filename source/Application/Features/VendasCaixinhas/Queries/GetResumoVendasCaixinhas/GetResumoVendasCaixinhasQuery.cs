using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetResumoVendasCaixinhas;

public class GetResumoVendasCaixinhasQuery : Command<GetResumoVendasCaixinhasQueryResponse>
{
    public string NomeVendedor { get; set; } = string.Empty;
    public int? Mes { get; set; }
    public int? Ano { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public GetResumoVendasCaixinhasQuery(string nomeVendedor = "", int? mes = null, int? ano = null, int pageNumber = 1, int pageSize = 10)
    {
        NomeVendedor = nomeVendedor;
        Mes = mes;
        Ano = ano;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
