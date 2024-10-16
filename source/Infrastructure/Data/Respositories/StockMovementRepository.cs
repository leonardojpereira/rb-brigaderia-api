using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Respositories
{
public class StockMovementRepository : RepositoryBase<StockMovement>, IStockMovementRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockMovementRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StockMovement?> GetAsync(Expression<Func<StockMovement, bool>> predicate)
        {
            return await _dbContext.StockMovement.FirstOrDefaultAsync(predicate);
        }
        public async Task AddAsync(StockMovement stockMovement)
        {
            await _dbContext.StockMovement.AddAsync(stockMovement);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<StockMovement>> GetAllAsync()
        {
            return await _dbContext.StockMovement.ToListAsync();
        }
    }
}
