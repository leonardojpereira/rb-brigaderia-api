using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations
{
    internal class ReceitaIngredienteConfiguration : IEntityTypeConfiguration<ReceitaIngrediente>
    {
        public void Configure(EntityTypeBuilder<ReceitaIngrediente> builder)
        {
            builder.ToTable("T_RECIPE");

            builder.HasKey(r => r.Id); 

            builder.Property(r => r.Id)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("PK_ID_RECIPE")
                .ValueGeneratedOnAdd(); 

            builder.Property(r => r.Nome)
                .HasColumnName("TX_NOME")
                .IsRequired(); 

            builder.Property(r => r.Descricao)
                .HasColumnName("TX_DESCRICAO");

            
            builder.HasMany(r => r.Ingredientes)
                .WithOne() 
                .HasForeignKey(i => i.IngredienteId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
