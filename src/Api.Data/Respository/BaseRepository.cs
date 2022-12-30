using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Data.Respository
{
  public class BaseRepository<E> : IRepository<E> where E : BaseEntity
  {
    protected readonly MyContext _context;
    private DbSet<E> _dataset;

    public BaseRepository(MyContext context)
    {
      _context = context;
      _dataset = context.Set<E>();
    }

    public async Task<E> InsertAsync(E entity)
    {
      try
      {
        if (entity.Id == Guid.Empty)
        {
          entity.Id = Guid.NewGuid();
        }

        entity.CreatedAt = DateTime.UtcNow;
        _dataset.Add(entity);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return entity;
    }
    public async Task<E> UpdateAsync(E entity)
    {
      try
      {
        var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(entity.Id));
        if (result == null)
          return null;

        entity.UpdateAt = DateTime.UtcNow;
        entity.CreatedAt = result.CreatedAt;

        _context.Entry(result).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
      try
      {
        var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        if (result == null)
          return false;

        _dataset.Remove(result);
        await _context.SaveChangesAsync();

        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
      return await _dataset.AnyAsync(p => p.Id.Equals(id));
    }

    public async Task<E> SelectAsync(Guid id)
    {
      try
      {
        return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<IEnumerable<E>> SelectAsync()
    {
      try
      {
        return await _dataset.ToListAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
