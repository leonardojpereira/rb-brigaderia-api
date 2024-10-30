using System.Linq.Expressions;
using Project.Domain.Entities;


namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IRecipeRepository : IRepositoryBase<Recipe>
    {
        Task<Recipe?> GetAsync(Expression<Func<Recipe, bool>> predicate);
        Task AddAsync(Recipe Recipe);

        void DeleteSoft(Recipe recipe);


        Task<IEnumerable<Recipe>> GetAllAsync();

        Task<Recipe?> GetWithIngredientsAsync(Guid recipeId);

        Task<(IEnumerable<Recipe> recipes, int totalItems)> GetPagedRecipesAsync(int pageNumber, int pageSize, string? filter);

    }
}
