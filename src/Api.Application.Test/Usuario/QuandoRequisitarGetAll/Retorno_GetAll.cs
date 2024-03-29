using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGetAll
{
  public class Retorno_GetAll
  {
    private UsersController _controller;

    [Fact(DisplayName = "É possível Realizar o Get All.")]
    public async Task E_POSSIVEL_INVOCAR_A_CONTROLLER_GETALL()
    {
      var serviceMock = new Mock<IUserService>();
      serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
        new List<UserDto>
        {
          new UserDto
          {
            Id = Guid.NewGuid(),
            Name = Faker.Name.FullName(),
            Email = Faker.Internet.Email(),
            CreatedAt = DateTime.UtcNow
          },
          new UserDto
          {
            Id = Guid.NewGuid(),
            Name = Faker.Name.FullName(),
            Email = Faker.Internet.Email(),
            CreatedAt = DateTime.UtcNow
          }
        }
      );

      _controller = new UsersController(serviceMock.Object);
      var result = await _controller.GetAll();
      Assert.True(result is OkObjectResult);

      var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
      Assert.True(resultValue.Count() == 2);
    }
  }
}
