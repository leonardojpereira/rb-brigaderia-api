using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Project.Infrastructure.Data.Respositories;

namespace Project.Infrastructure.Data.Repositories
{
    public class VendasCaixinhasRepository : RepositoryBase<VendasCaixinhas>, IVendasCaixinhasRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VendasCaixinhasRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VendasCaixinhas?> GetByDateAsync(DateTime dataVenda, CancellationToken cancellationToken)
        {
            return await _dbContext.VendasCaixinhas
                .FirstOrDefaultAsync(v => v.DataVenda.Date == dataVenda.Date, cancellationToken);
        }

        public async Task<decimal> GetMonthlyProfitAsync(int month, int year, CancellationToken cancellationToken)
        {
            return await _dbContext.VendasCaixinhas
                .Where(v => v.DataVenda.Month == month && v.DataVenda.Year == year)
                .SumAsync(v => v.Lucro, cancellationToken);
        }

        public async Task<IEnumerable<VendasCaixinhas>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.VendasCaixinhas
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
        
        public async Task<VendasCaixinhas?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.VendasCaixinhas
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }

    }
}
