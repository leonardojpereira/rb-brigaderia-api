using Project.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetByFilterAsync(string filter, CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        void DeleteSoft(User user);

    }
}
