using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
  public class UsuarioMapper : BaseTestService
  {
    [Fact(DisplayName = "É possivel mapear os modelos")]
    public void E_POSSIVEL_MAPEAR_OS_MODELOS()
    {
      var model = new UserModel
      {
        Id = Guid.NewGuid(),
        Name = Faker.Name.FullName(),
        Email = Faker.Internet.Email(),
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
      };

      var listaEntity = new List<UserEntity>();
      for (int i = 0; i < 5; i++)
      {
        var item = new UserEntity
        {
          Id = Guid.NewGuid(),
          Name = Faker.Name.FullName(),
          Email = Faker.Internet.Email(),
          CreatedAt = DateTime.UtcNow,
          UpdatedAt = DateTime.UtcNow
        };
        listaEntity.Add(item);
      }

      //Model => Entity
      var entity = Mapper.Map<UserEntity>(model);
      Assert.Equal(entity.Id, model.Id);
      Assert.Equal(entity.Name, model.Name);
      Assert.Equal(entity.Email, model.Email);
      Assert.Equal(entity.CreatedAt, model.CreatedAt);
      Assert.Equal(entity.UpdatedAt, model.UpdatedAt);

      //Entity para Dto
      var userDto = Mapper.Map<UserDto>(entity);
      Assert.Equal(userDto.Id, entity.Id);
      Assert.Equal(userDto.Name, entity.Name);
      Assert.Equal(userDto.Email, entity.Email);
      Assert.Equal(userDto.CreatedAt, entity.CreatedAt);

      var listaDto = Mapper.Map<List<UserDto>>(listaEntity);
      Assert.True(listaDto.Count() == listaEntity.Count());
      for (int i = 0; i < listaDto.Count(); i++)
      {
        Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
        Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
        Assert.Equal(listaDto[i].Email, listaEntity[i].Email);
        Assert.Equal(listaDto[i].CreatedAt, listaEntity[i].CreatedAt);
      }

      var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
      Assert.Equal(userDtoCreateResult.Id, entity.Id);
      Assert.Equal(userDtoCreateResult.Name, entity.Name);
      Assert.Equal(userDtoCreateResult.Email, entity.Email);
      Assert.Equal(userDtoCreateResult.CreatedAt, entity.CreatedAt);

      var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
      Assert.Equal(userDtoUpdateResult.Id, entity.Id);
      Assert.Equal(userDtoUpdateResult.Name, entity.Name);
      Assert.Equal(userDtoUpdateResult.Email, entity.Email);
      Assert.Equal(userDtoUpdateResult.UpdatedAt, entity.UpdatedAt);

      //Dto para Model
      var userModel = Mapper.Map<UserModel>(userDto);
      Assert.Equal(userModel.Id, userDto.Id);
      Assert.Equal(userModel.Name, userDto.Name);
      Assert.Equal(userModel.Email, userDto.Email);
      Assert.Equal(userModel.CreatedAt, userDto.CreatedAt);

      var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
      Assert.Equal(userDtoCreate.Name, userModel.Name);
      Assert.Equal(userDtoCreate.Email, userModel.Email);

      var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
      Assert.Equal(userDtoUpdate.Id, userModel.Id);
      Assert.Equal(userDtoUpdate.Name, userModel.Name);
      Assert.Equal(userDtoUpdate.Email, userModel.Email);

    }
  }
}
