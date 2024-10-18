using Project.Domain.Entities;

namespace Project.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Ingredient> Ingredient { get; set; }

    public DbSet<StockMovement> StockMovement { get; set; }

    public DbSet<Recipe> Recipe { get; set; }

     public DbSet<RecipeIngredient> RecipeIngredient { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
