using Project.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken);
    }
}
