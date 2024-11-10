using Project.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IVendasCaixinhasRepository : IRepositoryBase<VendasCaixinhas>
    {
        Task<VendasCaixinhas?> GetByDateAsync(DateTime dataVenda, CancellationToken cancellationToken);
        Task<decimal> GetMonthlyProfitAsync(int month, int year, CancellationToken cancellationToken);
    }
}
