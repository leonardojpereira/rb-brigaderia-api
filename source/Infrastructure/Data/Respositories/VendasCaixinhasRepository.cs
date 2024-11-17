using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Project.Infrastructure.Data.Respositories;
using System.Linq.Expressions;

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
             .Where(i => !i.IsDeleted)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<VendasCaixinhas?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.VendasCaixinhas
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }

        public async Task<VendasCaixinhas?> GetAsync(Expression<Func<VendasCaixinhas, bool>> predicate)
        {
            return await _dbContext.VendasCaixinhas
                .Where(i => !i.IsDeleted)
                .FirstOrDefaultAsync(predicate);
        }

        public void DeleteSoft(VendasCaixinhas vendasCaixinhas)
        {
            vendasCaixinhas.IsDeleted = true;
            _dbContext.Update(vendasCaixinhas);
        }

         public async Task<IEnumerable<(int Day, decimal TotalSales)>> GetSalesGroupedByDayAsync(int year, int month, CancellationToken cancellationToken)
        {
            return await _dbContext.VendasCaixinhas
                .Where(v => v.DataVenda.Year == year && v.DataVenda.Month == month)
                .GroupBy(v => v.DataVenda.Day)
                .Select(g => new ValueTuple<int, decimal>(g.Key, g.Sum(v => v.PrecoTotalVenda)))
                .ToListAsync(cancellationToken);
        }

       public async Task<IEnumerable<(int Month, decimal TotalSales)>> GetSalesGroupedByMonthAsync(int year, CancellationToken cancellationToken)
{
    return await _dbContext.VendasCaixinhas
        .Where(v => v.DataVenda.Year == year && !v.IsDeleted) 
        .GroupBy(v => v.DataVenda.Month)
        .Select(g => new ValueTuple<int, decimal>(g.Key, g.Sum(v => v.PrecoTotalVenda)))
        .ToListAsync(cancellationToken);
}


        public async Task<IEnumerable<(int Day, decimal TotalProfit)>> GetProfitGroupedByDayAsync(int year, int month, CancellationToken cancellationToken)
        {
            return await _dbContext.VendasCaixinhas
                .Where(v => v.DataVenda.Year == year && v.DataVenda.Month == month)
                .GroupBy(v => v.DataVenda.Day)
                .Select(g => new ValueTuple<int, decimal>(g.Key, g.Sum(v => v.Lucro)))
                .ToListAsync(cancellationToken);
        }

           public async Task<(decimal TotalCusto, decimal TotalLucro, int QuantidadeVendas)> GetMonthlySalesSummaryAsync(int year, int month, CancellationToken cancellationToken)
        {
            var summary = await _dbContext.VendasCaixinhas
                .Where(v => v.DataVenda.Year == year && v.DataVenda.Month == month && !v.IsDeleted)
                .GroupBy(v => 1) // Group by a constant to get aggregate values for the month
                .Select(g => new
                {
                    TotalCusto = g.Sum(v => v.CustoTotal),
                    TotalLucro = g.Sum(v => v.Lucro),
                    QuantidadeVendas = g.Count()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return summary != null
                ? (summary.TotalCusto, summary.TotalLucro, summary.QuantidadeVendas)
                : (0, 0, 0);
        }
    }
    }




