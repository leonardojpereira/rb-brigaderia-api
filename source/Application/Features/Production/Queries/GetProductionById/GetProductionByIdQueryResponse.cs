namespace Project.Application.Features.Queries.GetProductionById
{
    public class GetProductionByIdQueryResponse
    {
        public IEnumerable<GetProductionByIdDTO>? Productions { get; set; }
    }

    public class GetProductionByIdDTO
    {
        public Guid Id { get; set; }
        public Guid ReceitaId { get; set; }
        public string NomeReceita { get; set; } = string.Empty;
        public decimal QuantidadeProduzida { get; set; }
        public DateTime DataProducao { get; set; }
    }
}
