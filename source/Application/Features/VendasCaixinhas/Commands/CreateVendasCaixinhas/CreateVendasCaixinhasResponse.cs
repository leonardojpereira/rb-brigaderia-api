namespace Project.Application.Features.Commands.CreateVendasCaixinhas;

public record CreateVendasCaixinhasCommandResponse
{
    public Guid Id { get; set; }
    public DateTime DataVenda { get; set; }
}
