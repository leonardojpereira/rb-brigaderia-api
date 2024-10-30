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
                .FirstOrDefaultAsync(Expression.Lambda<Func<Recipe, bool>>(
                    Expression.AndAlso(
                        predicate.Body,
                        Expression.Not(Expression.Property(predicate.Parameters[0], nameof(Recipe.IsDeleted)))
                    ),
                    predicate.Parameters
                ));

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
                .Where(r => !r.IsDeleted)
                .ToListAsync();

        }


        public async Task<Recipe?> GetWithIngredientsAsync(Guid recipeId)
        {
            return await _dbContext.Recipe
                 .Include(r => r.Ingredientes)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == recipeId && !r.IsDeleted);
        }

        public override IEnumerable<Recipe> GetAll()
        {
            return _dbContext.Recipe
                 .Include(r => r.Ingredientes)
                .ThenInclude(ri => ri.Ingredient)
                .Where(r => !r.IsDeleted)
                .ToList();
        }

        public async Task<(IEnumerable<Recipe> recipes, int totalItems)> GetPagedRecipesAsync(int pageNumber, int pageSize, string? filter)
        {
            var query = _dbContext.Recipe
                .Include(r => r.Ingredientes)
                .ThenInclude(ri => ri.Ingredient)
                .Where(r => !r.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(r => r.Nome.Contains(filter) || r.Descricao.Contains(filter));
            }

            var totalItems = await query.CountAsync();

            var recipes = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (recipes, totalItems);
        }

        public void DeleteSoft(Recipe recipe)
        {
            recipe.IsDeleted = true;
            _dbContext.Update(recipe);
        }

    }
}
