namespace Project.Application.Features.Queries.GetAllParametrizacao;

public class GetAllParametrizacaoQueryResponse
{
    public IEnumerable<GetAllParametrizacaoDTO>? Parametrizacoes { get; set; }
    public int TotalItems { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
}

public class GetAllParametrizacaoDTO
{
    public Guid Id { get; set; }
    public string NomeVendedor { get; set; } = string.Empty;
    public decimal PrecoCaixinha { get; set; }
    public decimal Custo { get; set; }
    public decimal Lucro { get; set; }
    public string LocalVenda { get; set; } = string.Empty;
    public string HorarioInicio { get; set; } = string.Empty;
    public string HorarioFim { get; set; } = string.Empty;
}
