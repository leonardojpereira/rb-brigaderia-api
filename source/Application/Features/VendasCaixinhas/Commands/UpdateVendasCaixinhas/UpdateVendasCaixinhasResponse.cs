namespace Project.Application.Features.Commands.UpdateVendasCaixinhas
{
    public record UpdateVendasCaixinhasCommandResponse
    {
        public Guid Id { get; set; }
        public DateTime DataVenda { get; set; }
        public int QuantidadeCaixinhas { get; set; }
        public decimal PrecoTotalVenda { get; set; }
        public decimal Salario { get; set; }
        public decimal CustoTotal { get; set; }
        public decimal Lucro { get; set; }
        public string LocalVenda { get; set; } = string.Empty;
        public string HorarioInicio { get; set; } = string.Empty;
        public string HorarioFim { get; set; } = string.Empty;

        public string NomeVendedor { get; set; } = string.Empty;
    }
}
