using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITeenyURLRepository<TEntity, TEntityMapping>
    {
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> exp);
    }
}
