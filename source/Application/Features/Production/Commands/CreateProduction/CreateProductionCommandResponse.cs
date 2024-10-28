public record CreateProductionCommandResponse
{
    public Guid Id { get; set; }
    public Guid ReceitaId { get; set; }
    public int QuantidadeProduzida { get; set; }
    public DateTime DataProducao { get; set; }
}
