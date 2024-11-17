namespace Project.Application.Features.Queries.GetAllProduction
{
    public class GetAllProductionQueryResponse
    {
        public IEnumerable<GetAllProductionDTO>? Productions { get; set; }
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }

    public class GetAllProductionDTO
    {
        public Guid Id { get; set; }
        public Guid ReceitaId { get; set; }
        public string NomeReceita { get; set; } = string.Empty;
        public decimal QuantidadeProduzida { get; set; }
        public DateTime DataProducao { get; set; }
    }
}
