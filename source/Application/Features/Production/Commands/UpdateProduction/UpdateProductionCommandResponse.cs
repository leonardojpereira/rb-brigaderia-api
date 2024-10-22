namespace Project.Application.Features.Commands.UpdateProduction
{
    public record UpdateProductionCommandResponse
    {
        public Guid ReceitaId { get; set; } 
        public int QuantidadeProduzida { get; set; } 
        public DateTime DataAtualizada { get; set; }
    }
}
