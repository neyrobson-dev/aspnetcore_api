using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Dtos.User;

namespace Api.Domain.Interfaces.Services.User
{
  public interface IUserService
  {
    Task<UserDto> Get(Guid id);
    Task<IEnumerable<UserDto>> GetAll();
    Task<UserDtoCreateResult> Post(UserDtoCreate entity);
    Task<UserDtoUpdateResult> Put(UserDtoUpdate entity);
    Task<bool> Delete(Guid id);
  }
}
