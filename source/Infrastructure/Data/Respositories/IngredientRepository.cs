using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Data.Respositories
{
    public class IngredientRepository(ApplicationDbContext dbContext) : RepositoryBase<Ingredient>(dbContext), IIngredientRepository
    {
    }
}
