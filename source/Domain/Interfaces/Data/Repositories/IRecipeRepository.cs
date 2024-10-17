using System.Linq.Expressions;
using Project.Domain.Entities;


namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IRecipeRepository : IRepositoryBase<Recipe>
    {
        Task<Recipe?> GetAsync(Expression<Func<Recipe, bool>> predicate);
        Task AddAsync(Recipe Recipe);

        Task<IEnumerable<Recipe>> GetAllAsync();
    }
}
