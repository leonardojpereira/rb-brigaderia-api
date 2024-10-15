using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations;
internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("T_INGREDIENT");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("PK_ID_INGREDIENT")
                .ValueGeneratedOnAdd();

        builder.Property(i => i.Name)
                .HasColumnName("TX_NAME")
                .IsRequired();

        builder.Property(t => t.CreatedAt)
                .HasColumnName("DT_CREATEDAT")
                .IsRequired();

        builder.Property(t => t.UpdatedAt)
                .HasColumnName("DT_UPDATEDAT");
                        
        builder.Property(t => t.IsDeleted)
                .HasColumnName("FL_DELETED")
                .IsRequired();

        builder.Property(i => i.Measurement)
                .HasColumnName("TX_MEASUREMENT")
                .IsRequired();

        builder.Property(i => i.Stock)
                .HasColumnName("NR_CURRENT_STOCK")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

        builder.Property(i => i.MinimumStock)
                .HasColumnName("NR_MINIMUM_STOCK")
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            
        builder.Property(i => i.UnitPrice)
                .HasColumnName("NR_UNIT_PRICE")
                .HasColumnType("decimal(18,2)")
                .IsRequired();
    }
}
