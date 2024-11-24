namespace Project.Application.Features.Queries.GetResumoVendasCaixinhas;

public class ResumoVendedoraDTO
{
    public string NomeVendedor { get; set; } = string.Empty;
    public decimal TotalLucro { get; set; }
    public decimal TotalCusto { get; set; }
    public decimal TotalSalario { get; set; }
    public decimal TotalFaturamento { get; set; }
    public string Date { get; set; } = string.Empty; 
}

public class GetResumoVendasCaixinhasQueryResponse
{
    public List<ResumoVendedoraDTO> ResumoPorVendedora { get; set; } = new();
    public int TotalItems { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
}
