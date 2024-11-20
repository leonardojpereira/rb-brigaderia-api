    namespace Project.Domain.Entities;

    public class VendasCaixinhas : BaseEntity
    {
        public DateTime DataVenda { get; set; }
        public string NomeVendedor { get; set; } = string.Empty;
        public int QuantidadeCaixinhas { get; set; }
        public decimal PrecoTotalVenda { get; set; }
        public decimal Salario { get; set; }
        public decimal CustoTotal { get; set; }
        public decimal Lucro { get; set; }
        public string LocalVenda { get; set; } = string.Empty;
        public string HorarioInicio { get; set; } = string.Empty; 
        public string HorarioFim { get; set; } = string.Empty;
    }
