using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
  public interface IUserService
  {
    Task<UserEntity> Get(Guid id);
    Task<IEnumerable<UserEntity>> GetAll();
    Task<UserEntity> Post(UserEntity entity);
    Task<UserEntity> Put(UserEntity entity);
    Task<bool> Delete(Guid id);
  }
}
