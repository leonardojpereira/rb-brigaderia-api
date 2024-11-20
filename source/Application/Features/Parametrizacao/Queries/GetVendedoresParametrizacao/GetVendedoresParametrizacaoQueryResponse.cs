namespace Project.Application.Features.Queries.GetVendedoresParametrizacao;

public class GetVendedoresParametrizacaoQueryResponse
{
    public IEnumerable<GetVendedoresParametrizacaoDTO> Vendedores { get; set; } = new List<GetVendedoresParametrizacaoDTO>();
}

public class GetVendedoresParametrizacaoDTO
{
    public Guid Id { get; set; }
    public string NomeVendedor { get; set; } = string.Empty;
}
