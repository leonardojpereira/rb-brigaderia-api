using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Infrastructure.Data.Respositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.User
                .Include(u => u.Role) 
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<User>> GetByFilterAsync(string filter, CancellationToken cancellationToken)
        {
            return await _dbContext.User
                .Include(u => u.Role)
                .Where(u => u.Nome.Contains(filter) || u.Email.Contains(filter))
                .ToListAsync(cancellationToken);
        }

         public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.User
                .Include(u => u.Role) 
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }
    }
}
