using Project.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Data.Repositories;

public interface IParametrizacaoRepository : IRepositoryBase<Parametrizacao>
{
    Task<Parametrizacao?> GetByNameAsync(string nomeVendedor, CancellationToken cancellationToken);
    Task<IEnumerable<Parametrizacao>> GetAllAsync(CancellationToken cancellationToken);

    Task<Parametrizacao?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    void DeleteSoft(Parametrizacao parametrizacao);

}
