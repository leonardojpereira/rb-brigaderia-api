namespace Project.Application.Features.Commands.CreateParametrizacao;

public record CreateParametrizacaoCommandResponse
{
    public Guid Id { get; set; }
    public string NomeVendedor { get; set; } = string.Empty;
}
