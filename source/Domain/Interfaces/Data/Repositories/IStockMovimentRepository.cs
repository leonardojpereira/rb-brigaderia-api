using Project.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IStockMovementRepository : IRepositoryBase<StockMovement>
    {
        Task<StockMovement?> GetAsync(Expression<Func<StockMovement, bool>> predicate);
        Task AddAsync(StockMovement stockMovement);

        Task<IEnumerable<StockMovement>> GetAllAsync();
    }
}
