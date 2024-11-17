using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations;
internal class VendasCaixinhasConfiguration : IEntityTypeConfiguration<VendasCaixinhas>
{
    public void Configure(EntityTypeBuilder<VendasCaixinhas> builder)
    {
        builder.ToTable("T_VENDAS_CAIXINHAS");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
               .HasColumnName("PK_ID_VENDAS_CAIXINHAS")
               .IsRequired();

        builder.Property(v => v.DataVenda)
               .HasColumnName("DT_VENDA")
               .IsRequired();

        builder.Property(v => v.QuantidadeCaixinhas)
               .HasColumnName("NR_QUANTIDADE_CAIXINHAS")
               .IsRequired();

        builder.Property(v => v.PrecoTotalVenda)
               .HasColumnName("NR_PRECO_TOTAL_VENDA")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(v => v.Salario)
               .HasColumnName("NR_SALARIO")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(v => v.CustoTotal)
               .HasColumnName("NR_CUSTO_TOTAL")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(v => v.Lucro)
               .HasColumnName("NR_LUCRO")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(v => v.LocalVenda)
               .HasColumnName("TX_LOCAL_VENDA")
               .IsRequired();

         builder.Property(v => v.HorarioInicio)
               .HasColumnName("TM_HORARIO_INICIO")
               .HasMaxLength(8)
               .IsRequired();

        builder.Property(v => v.HorarioFim)
               .HasColumnName("TM_HORARIO_FIM")
               .HasMaxLength(8) 
               .IsRequired();
    }
}
