namespace Project.Application.Features.Commands.UpdateVendasCaixinhas
{
    public record UpdateVendasCaixinhasCommandRequest
    {
        public DateTime? DataVenda { get; set; }
        public int? QuantidadeCaixinhas { get; set; }
        public decimal? PrecoTotalVenda { get; set; }
        public decimal? Salario { get; set; }
        public decimal? CustoTotal { get; set; }
        public decimal? Lucro { get; set; }
        public string? LocalVenda { get; set; }
        public string? HorarioInicio { get; set; }
        public string? HorarioFim { get; set; }
    }
}
