using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Services
{
    public interface IVendasCaixinhasMetricsService
    {
        Task<int> GetDayWithMostSalesAsync(int year, int month, CancellationToken cancellationToken);
        Task<IEnumerable<(int Month, decimal TotalSales)>> GetMonthlySalesAsync(int year, CancellationToken cancellationToken);
        Task<decimal> GetMaxProfitInADayAsync(int year, int month, CancellationToken cancellationToken);
        Task<(int Day, decimal TotalSales)> GetBestSellingDayAsync(int year, int month, CancellationToken cancellationToken);
    }
}
