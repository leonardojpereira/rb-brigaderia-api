using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations;
internal class ParametrizacaoConfiguration : IEntityTypeConfiguration<Parametrizacao>
{
    public void Configure(EntityTypeBuilder<Parametrizacao> builder)
    {
        builder.ToTable("T_PARAMETRIZACAO");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
               .HasColumnName("PK_ID_PARAMETRIZACAO")
               .IsRequired();

        builder.Property(p => p.NomeVendedor)
               .HasColumnName("TX_NOME_VENDEDOR")
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(p => p.Custo)
               .HasColumnName("NR_CUSTO")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(p => p.Lucro)
               .HasColumnName("NR_LUCRO")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(p => p.LocalVenda)
               .HasColumnName("TX_LOCAL_VENDA")
               .IsRequired();

        builder.Property(p => p.HorarioInicio)
               .HasColumnName("TM_HORARIO_INICIO")
               .HasMaxLength(8)
               .IsRequired();

        builder.Property(p => p.HorarioFim)
               .HasColumnName("TM_HORARIO_FIM")
               .HasMaxLength(8)
               .IsRequired();
    }
}
