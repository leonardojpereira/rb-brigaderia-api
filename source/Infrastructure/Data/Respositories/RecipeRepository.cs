using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            return await _dbContext.Recipe.FirstOrDefaultAsync(predicate);
        }
        public async Task AddAsync(Recipe Recipe)
        {
            await _dbContext.Recipe.AddAsync(Recipe);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await _dbContext.Recipe.ToListAsync();
        }

        public override IEnumerable<Recipe> GetAll()
        {
            return _dbContext.Recipe
                .Include(r => r.Ingredientes)
                .ToList();
        }
    }
}
