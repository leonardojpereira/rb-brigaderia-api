namespace Project.Application.Features.Commands.CreateParametrizacao;

public record CreateParametrizacaoCommandRequest
{
    public string NomeVendedor { get; set; } = string.Empty;
    public decimal PrecoCaixinha { get; set; }
    public decimal Custo { get; set; }
    public decimal Lucro { get; set; }
    public string LocalVenda { get; set; } = string.Empty;
    public string HorarioInicio { get; set; } = string.Empty;
    public string HorarioFim { get; set; } = string.Empty;
}
