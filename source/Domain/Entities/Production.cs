using Project.Domain.Entities;

namespace Project.Domain.Entities
{
    public class Production : BaseEntity
    {
        public Guid ReceitaId { get; set; }
        public int QuantidadeProduzida { get; set; }
        public DateTime DataProducao { get; set; }

        public virtual Recipe? Receita { get; set; }
    }
}
