using System.Reflection;
using Project.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext, IUnitOfWork
{
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Ingredient> Ingredient { get; set; }
    public DbSet<StockMovement> StockMovement { get; set; }

    public DbSet<Recipe> Recipe { get; set; }

    public DbSet<RecipeIngredient> RecipeIngredient { get; set; }

    public DbSet<Production> Production { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public int Commit()
    {
        return base.SaveChanges();
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

}
