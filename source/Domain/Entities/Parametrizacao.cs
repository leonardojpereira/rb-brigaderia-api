namespace Project.Domain.Entities;

public class Parametrizacao : BaseEntity
{
    public string NomeVendedor { get; set; } = string.Empty;

public decimal PrecoCaixinha { get; set; }
    public decimal Custo { get; set; }
    public decimal Lucro { get; set; }
    public string LocalVenda { get; set; } = string.Empty;
    public string HorarioInicio { get; set; } = string.Empty; 
    public string HorarioFim { get; set; } = string.Empty;

    public decimal? PrecoPassagem { get; set; }

    public bool PrecisaPassagem { get; set; }
}
