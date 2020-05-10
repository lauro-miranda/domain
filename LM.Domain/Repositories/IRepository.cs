using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LM.Domain.Entities;
using LM.Responses;

namespace LM.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();

        Task<Maybe<T>> FindAsync(Guid code);

        Task AddAsync(T entity);

        Task RemoveAsync(T entity);

        Task UpdateAsync(T entity);

        Task UpdateRangeAsync(ICollection<T> entityCollection);

        Task AddRangeAsync(IEnumerable<T> entityCollection);

        Task RemoveRangeAsync(ICollection<T> entityCollection);

        Task<List<T>> FindAsync(List<Guid> codes);
    }
}
