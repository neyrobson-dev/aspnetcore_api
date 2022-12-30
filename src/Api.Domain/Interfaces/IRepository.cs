using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
  public interface IRepository<E> where E : BaseEntity
  {
    Task<E> InsertAsync(E entity);
    Task<E> UpdateAsync(E entity);
    Task<bool> DeleteAsync(Guid id);
    Task<E> SelectAsync(Guid id);
    Task<IEnumerable<E>> SelectAsync();
    Task<bool> ExistsAsync(Guid id);
  }
}
