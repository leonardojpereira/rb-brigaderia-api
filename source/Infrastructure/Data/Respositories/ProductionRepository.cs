using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Respositories
{
    public class ProductionRepository : RepositoryBase<Production>, IProductionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Production?> GetAsync(Expression<Func<Production, bool>> predicate)
        {
            return await _dbContext.Production
                .Include(p => p.Receita)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Production>> GetAllAsync()
        {
            return await _dbContext.Production
                .Include(p => p.Receita)
                .ToListAsync();
        }

        public async Task AddAsync(Production production)
        {
            await _dbContext.Production.AddAsync(production);
        }
    }
}
