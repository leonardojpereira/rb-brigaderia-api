using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Respositories
{
    public class RecipeIngredientRepository : RepositoryBase<RecipeIngredient>, IRecipeIngredientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RecipeIngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RecipeIngredient?> GetAsync(Expression<Func<RecipeIngredient, bool>> predicate)
        {
            return await _dbContext.RecipeIngredient.FirstOrDefaultAsync(predicate);
        }
        public async Task AddAsync(RecipeIngredient RecipeIngredient)
        {
            await _dbContext.RecipeIngredient.AddAsync(RecipeIngredient);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<RecipeIngredient>> GetAllAsync()
        {
            return await _dbContext.RecipeIngredient.ToListAsync();
        }
        public async Task<IEnumerable<RecipeIngredient>> GetAllByRecipeId(Guid recipeId)
        {
            return await _dbContext.RecipeIngredient
                .Where(ri => ri.RecipeId == recipeId)
                .ToListAsync();
        }


        public void Remove(RecipeIngredient ingredient)
        {
            _dbContext.RecipeIngredient.Remove(ingredient);
        }
    }
}
