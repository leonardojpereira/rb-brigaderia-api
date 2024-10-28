using Project.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IProductionRepository : IRepositoryBase<Production>
    {
        Task<Production?> GetAsync(Expression<Func<Production, bool>> predicate);
        Task<IEnumerable<Production>> GetAllAsync();

        Task AddAsync(Production production);
    }
}
