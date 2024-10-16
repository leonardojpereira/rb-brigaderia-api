using Project.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Data.Repositories
{
    public interface IIngredientRepository : IRepositoryBase<Ingredient>
    {
        Task<Ingredient?> GetAsync(Expression<Func<Ingredient, bool>> predicate);
    }
}
