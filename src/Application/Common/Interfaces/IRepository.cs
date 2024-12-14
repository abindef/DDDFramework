using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDFramework.Domain.Common;

namespace DDDFramework.Application.Common.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
