using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T>? GetAsync(int id, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetAllAsync(int pageSize = 0, int pageNumber = 0, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);
    }
}
