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
  public class Retorno_BadRequest
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
      _controller.ModelState.AddModelError("Id", "Formato Invalido");

      var result = await _controller.GetAll();
      Assert.True(result is BadRequestObjectResult);
    }
  }
}
