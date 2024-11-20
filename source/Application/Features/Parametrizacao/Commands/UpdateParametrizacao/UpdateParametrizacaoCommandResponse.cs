namespace Project.Application.Features.Commands.UpdateParametrizacao;

public record UpdateParametrizacaoCommandResponse
{
    public Guid Id { get; set; }
    public string NomeVendedor { get; set; } = string.Empty;
    public decimal Custo { get; set; }
    public decimal Lucro { get; set; }
    public string LocalVenda { get; set; } = string.Empty;
    public string HorarioInicio { get; set; } = string.Empty;
    public string HorarioFim { get; set; } = string.Empty;
}
