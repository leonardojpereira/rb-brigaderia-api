namespace Project.Application.Features.Queries.GetParametrizacaoById;

public class GetParametrizacaoByIdQueryResponse
{
    public GetParametrizacaoByIdDTO? Parametrizacao { get; set; }
}

public class GetParametrizacaoByIdDTO
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
