using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Configurations
{
  internal class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.ToTable("T_RECIPE_INGREDIENTES");

        builder.HasKey(ri => new { ri.RecipeId, ri.IngredienteId });

        builder.Property(ri => ri.QuantidadeNecessaria)
            .HasColumnName("NR_QUANTIDADE_NECESSARIA")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne(ri => ri.Recipe)
            .WithMany(r => r.Ingredientes)
            .HasForeignKey(ri => ri.RecipeId)
            .HasConstraintName("FK_RECIPE_INGREDIENTES_RECIPE")
            .OnDelete(DeleteBehavior.Cascade);  

        builder.HasOne(ri => ri.Ingredient)
            .WithMany()
            .HasForeignKey(ri => ri.IngredienteId)
            .HasConstraintName("FK_RECIPE_INGREDIENTES_INGREDIENT")
            .OnDelete(DeleteBehavior.Restrict); 
    }
}

}
