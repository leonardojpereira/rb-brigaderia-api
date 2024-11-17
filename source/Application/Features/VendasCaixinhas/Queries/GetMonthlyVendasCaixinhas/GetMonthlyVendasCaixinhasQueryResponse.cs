namespace Project.Application.Features.Queries.GetMonthlyVendasCaixinhas
{
    public class GetMonthlyVendasCaixinhasQueryResponse
    {
        public decimal TotalCusto { get; set; }
        public decimal TotalLucro { get; set; }
        public int QuantidadeVendas { get; set; }
    }
}
