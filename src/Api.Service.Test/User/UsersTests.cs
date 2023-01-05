using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;

namespace Api.Service.Test.User
{
  public class UsersTests
  {
    public static string NameUser { get; set; }
    public static string EmailUser { get; set; }
    public static string NameUserChanged { get; set; }
    public static string EmailUserChanged { get; set; }
    public static Guid IdUser { get; set; }

    public List<UserDto> listaUserDto = new List<UserDto>();
    public UserDto userDto;
    public UserDtoCreate userDtoCreate;
    public UserDtoCreateResult userDtoCreateResult;
    public UserDtoUpdate userDtoUpdate;
    public UserDtoUpdateResult userDtoUpdateResult;

    public UsersTests()
    {
      IdUser = Guid.NewGuid();
      NameUser = Faker.Name.FullName();
      EmailUser = Faker.Internet.Email();
      NameUserChanged = Faker.Name.FullName();
      EmailUserChanged = Faker.Internet.Email();

      for (int i = 0; i < 10; i++)
      {
        var dto = new UserDto()
        {
          Id = Guid.NewGuid(),
          Name = Faker.Name.FullName(),
          Email = Faker.Internet.Email()
        };
        listaUserDto.Add(dto);
      }

      userDto = new UserDto
      {
        Id = IdUser,
        Name = NameUser,
        Email = EmailUser
      };

      userDtoCreate = new UserDtoCreate
      {
        Name = NameUser,
        Email = EmailUser
      };

      userDtoCreateResult = new UserDtoCreateResult
      {
        Id = IdUser,
        Name = NameUser,
        Email = EmailUser,
        CreatedAt = DateTime.UtcNow
      };

      userDtoUpdate = new UserDtoUpdate
      {
        Id = IdUser,
        Name = NameUserChanged,
        Email = EmailUserChanged
      };

      userDtoUpdateResult = new UserDtoUpdateResult
      {
        Id = IdUser,
        Name = NameUserChanged,
        Email = EmailUserChanged,
        UpdateAt = DateTime.UtcNow
      };
    }
  }
}
