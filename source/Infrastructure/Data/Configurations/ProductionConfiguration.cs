using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations
{
    internal class ProductionConfiguration : IEntityTypeConfiguration<Production>
    {
        public void Configure(EntityTypeBuilder<Production> builder)
        {
            builder.ToTable("T_PRODUCTION");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("PK_ID_PRODUCTION")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ReceitaId)
                .HasColumnName("FK_ID_RECEITA")
                .IsRequired();

            builder.Property(p => p.QuantidadeProduzida)
                .HasColumnName("NR_QUANTIDADE_PRODUZIDA")
                .IsRequired();

            builder.Property(p => p.DataProducao)
                .HasColumnName("DT_PRODUCAO")
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(p => p.Receita)
                .WithMany()
                .HasForeignKey(p => p.ReceitaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
