namespace Project.Application.Features.Commands.DeleteProduction;

public record DeleteProductionCommandRequest
{
    public string Property { get; set; } = string.Empty;
    public long Property2 { get; set; } = 0;
}