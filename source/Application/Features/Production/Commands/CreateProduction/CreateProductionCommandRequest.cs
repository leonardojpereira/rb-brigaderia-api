namespace Project.Application.Features.Commands.CreateProduction
{
    public record CreateProductionCommandRequest
    {
        public Guid ReceitaId { get; set; }
        public int QuantidadeProduzida { get; set; }
        public DateTime DataProducao { get; set; } = DateTime.UtcNow;
    }
}
