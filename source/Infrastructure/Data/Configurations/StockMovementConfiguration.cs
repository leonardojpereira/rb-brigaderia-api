using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations;
internal class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        builder.ToTable("T_STOCK_MOVEMENT");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("PK_ID_STOCK_MOVEMENT")
                .ValueGeneratedOnAdd();

        builder.Property(m => m.Quantity)
                .HasColumnName("NR_QUANTITY")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

        builder.Property(m => m.Description)
                .HasColumnName("TX_DESCRIPTION")
                .IsRequired();

        builder.Property(m => m.MovementType)
                .HasColumnName("TX_MOVEMENT_TYPE")
                .IsRequired();

        builder.Property(m => m.CreatedAt)
                .HasColumnName("DT_CREATED_AT")
                .IsRequired();

        builder.HasOne(m => m.Ingredient)
               .WithMany(i => i.StockMovements)
               .HasForeignKey(m => m.IngredientId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
