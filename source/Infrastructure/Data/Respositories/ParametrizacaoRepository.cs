using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Infrastructure.Data.Respositories;

namespace Project.Infrastructure.Data.Repositories;

public class ParametrizacaoRepository : RepositoryBase<Parametrizacao>, IParametrizacaoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ParametrizacaoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Parametrizacao?> GetByNameAsync(string nomeVendedor, CancellationToken cancellationToken)
    {
        return await _dbContext.Parametrizacao
            .FirstOrDefaultAsync(p => p.NomeVendedor == nomeVendedor && !p.IsDeleted, cancellationToken);
    }

    public async Task<IEnumerable<Parametrizacao>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Parametrizacao
            .Where(p => !p.IsDeleted)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Parametrizacao?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Parametrizacao
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, cancellationToken);
    }
}
