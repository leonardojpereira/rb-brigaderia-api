using System.Linq.Expressions;
using Project.Domain.Entities;


namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IRecipeIngredientRepository : IRepositoryBase<RecipeIngredient>
    {
        Task<RecipeIngredient?> GetAsync(Expression<Func<RecipeIngredient, bool>> predicate);
        Task AddAsync(RecipeIngredient RecipeIngredient);

        Task<IEnumerable<RecipeIngredient>> GetAllAsync();
        Task<IEnumerable<RecipeIngredient>> GetAllByRecipeId(Guid recipeId);
        void Remove(RecipeIngredient ingredient);
    }
}
