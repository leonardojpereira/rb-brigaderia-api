using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.Infrastructure.Data.Respositories
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Recipe?> GetAsync(Expression<Func<Recipe, bool>> predicate)
        {
            return await _dbContext.Recipe
                .Include(r => r.Ingredientes)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task AddAsync(Recipe recipe)
        {
            await _dbContext.Recipe.AddAsync(recipe);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await _dbContext.Recipe
                .Include(r => r.Ingredientes)
                .ThenInclude(ri => ri.Ingredient)
                .ToListAsync();
        }


        public async Task<Recipe?> GetWithIngredientsAsync(Guid recipeId)
        {
            return await _dbContext.Recipe
                .Include(r => r.Ingredientes)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == recipeId);
        }

        public override IEnumerable<Recipe> GetAll()
        {
            return _dbContext.Recipe
                .Include(r => r.Ingredientes)
                .ThenInclude(ri => ri.Ingredient)
                .ToList();
        }
    }
}
