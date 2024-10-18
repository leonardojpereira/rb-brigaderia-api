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

        // Implementação do método GetAsync
        public async Task<Recipe?> GetAsync(Expression<Func<Recipe, bool>> predicate)
        {
            return await _dbContext.Recipe
                .Include(r => r.Ingredientes) // Incluir os ingredientes
                .ThenInclude(ri => ri.Ingredient) // Incluir detalhes do ingrediente
                .FirstOrDefaultAsync(predicate);
        }

        // Implementação do método AddAsync
        public async Task AddAsync(Recipe recipe)
        {
            await _dbContext.Recipe.AddAsync(recipe);
            await _dbContext.SaveChangesAsync();
        }

        // Implementação do método GetAllAsync
        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await _dbContext.Recipe
                .Include(r => r.Ingredientes)
                .ThenInclude(ri => ri.Ingredient) // Incluir os detalhes do ingrediente
                .ToListAsync();
        }

        // Implementação do método GetWithIngredientsAsync
        public async Task<Recipe?> GetWithIngredientsAsync(Guid recipeId)
        {
            return await _dbContext.Recipe
                .Include(r => r.Ingredientes) 
                .ThenInclude(ri => ri.Ingredient) 
                .FirstOrDefaultAsync(r => r.Id == recipeId);
        }

        // Sobrescrevendo o método GetAll para incluir os ingredientes
        public override IEnumerable<Recipe> GetAll()
        {
            return _dbContext.Recipe
                .Include(r => r.Ingredientes)
                .ThenInclude(ri => ri.Ingredient)
                .ToList();
        }
    }
}
