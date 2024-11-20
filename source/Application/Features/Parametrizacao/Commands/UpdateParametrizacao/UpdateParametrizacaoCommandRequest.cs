namespace Project.Application.Features.Commands.UpdateParametrizacao;

public record UpdateParametrizacaoCommandRequest
{
    public string? NomeVendedor { get; set; }
    public decimal? Custo { get; set; }
    public decimal? Lucro { get; set; }
    public string? LocalVenda { get; set; }
    public string? HorarioInicio { get; set; }
    public string? HorarioFim { get; set; }
}