using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllParametrizacao;

public class GetAllParametrizacaoQuery : Command<GetAllParametrizacaoQueryResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? NomeVendedor { get; set; }

    public GetAllParametrizacaoQuery(int pageNumber = 1, int pageSize = 10, string? nomeVendedor = null)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        NomeVendedor = nomeVendedor;
    }
}
