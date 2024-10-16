using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Respositories
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public IngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Ingredient.ToListAsync(cancellationToken);
        }

        public async Task<Ingredient?> GetAsync(Expression<Func<Ingredient, bool>> predicate)
        {
            return await _dbContext.Ingredient.FirstOrDefaultAsync(predicate);
        }
    }
}
