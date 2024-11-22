using Project.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IVendasCaixinhasRepository : IRepositoryBase<VendasCaixinhas>
    {
        Task<VendasCaixinhas?> GetByDateAsync(DateTime dataVenda, CancellationToken cancellationToken);

        Task<VendasCaixinhas?> GetByNomeVendedorAsync(string nomeVendedor, CancellationToken cancellationToken);
        Task<decimal> GetMonthlyProfitAsync(int month, int year, CancellationToken cancellationToken);

        Task<IEnumerable<VendasCaixinhas>> GetAllAsync(CancellationToken cancellationToken);

        Task<VendasCaixinhas?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<VendasCaixinhas?> GetAsync(Expression<Func<VendasCaixinhas, bool>> predicate);

        void DeleteSoft(VendasCaixinhas vendasCaixinhas);

         Task<IEnumerable<(int Day, decimal TotalSales)>> GetSalesGroupedByDayAsync(int year, int month, CancellationToken cancellationToken);
        Task<IEnumerable<(int Month, decimal TotalSales)>> GetSalesGroupedByMonthAsync(int year, CancellationToken cancellationToken);
        Task<IEnumerable<(int Day, decimal TotalProfit)>> GetProfitGroupedByDayAsync(int year, int month, CancellationToken cancellationToken);

        Task<(decimal TotalCusto, decimal TotalLucro, int QuantidadeVendas)> GetMonthlySalesSummaryAsync(int year, int month, CancellationToken cancellationToken);

    }
}
