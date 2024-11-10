namespace Project.Domain.Entities;

public class VendasCaixinhas : BaseEntity
{
    public DateTime DataVenda { get; set; }
    public int QuantidadeCaixinhas { get; set; }
    public decimal PrecoTotalVenda { get; set; }
    public decimal Salario { get; set; }
    public decimal CustoTotal { get; set; }
    public decimal Lucro { get; set; }
    public string LocalVenda { get; set; } = string.Empty;
    public TimeSpan HorarioInicio { get; set; }
    public TimeSpan HorarioFim { get; set; }
}
