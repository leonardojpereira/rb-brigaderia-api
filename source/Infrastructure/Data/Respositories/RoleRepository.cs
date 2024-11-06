using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Respositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Role.ToListAsync(cancellationToken);
        }
    }
}
