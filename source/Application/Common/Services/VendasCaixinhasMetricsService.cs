using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Application.Services
{
    public class VendasCaixinhasMetricsService : IVendasCaixinhasMetricsService
    {
        private readonly IVendasCaixinhasRepository _vendasCaixinhasRepository;

        public VendasCaixinhasMetricsService(IVendasCaixinhasRepository vendasCaixinhasRepository)
        {
            _vendasCaixinhasRepository = vendasCaixinhasRepository;
        }

        public async Task<int> GetDayWithMostSalesAsync(int year, int month, CancellationToken cancellationToken)
        {
            var salesGroupedByDay = await _vendasCaixinhasRepository
                .GetSalesGroupedByDayAsync(year, month, cancellationToken);

            return salesGroupedByDay.OrderByDescending(s => s.TotalSales)
                .FirstOrDefault().Day;
        }

       public async Task<IEnumerable<(int Month, decimal TotalSales)>> GetMonthlySalesAsync(int year, CancellationToken cancellationToken)
{
    var salesGroupedByMonth = await _vendasCaixinhasRepository.GetSalesGroupedByMonthAsync(year, cancellationToken);
    return salesGroupedByMonth.OrderBy(s => s.Month);
}



        public async Task<decimal> GetMaxProfitInADayAsync(int year, int month, CancellationToken cancellationToken)
        {
            var profitByDay = await _vendasCaixinhasRepository
                .GetProfitGroupedByDayAsync(year, month, cancellationToken);

            return profitByDay.Max(p => p.TotalProfit);
        }

        public async Task<(int Day, decimal TotalSales)> GetBestSellingDayAsync(int year, int month, CancellationToken cancellationToken)
        {
            var salesGroupedByDay = await _vendasCaixinhasRepository
                .GetSalesGroupedByDayAsync(year, month, cancellationToken);

            var bestDay = salesGroupedByDay.OrderByDescending(s => s.TotalSales)
                .FirstOrDefault();

            return (bestDay.Day, bestDay.TotalSales);
        }
    }
}
