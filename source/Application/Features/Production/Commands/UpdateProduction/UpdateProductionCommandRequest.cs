namespace Project.Application.Features.Commands.UpdateProduction
{
    public record UpdateProductionCommandRequest
    {
        public Guid ReceitaId { get; set; }
        public int QuantidadeProduzida { get; set; }
    }
}
