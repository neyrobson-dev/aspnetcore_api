using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
  public class Retorno_BadRequest
  {
    private UsersController _controller;

    [Fact(DisplayName = "É possível Realizar o Update.")]
    public async Task E_POSSIVEL_INVOCAR_A_CONTROLLER_UPDATE()
    {
      var serviceMock = new Mock<IUserService>();
      var nome = Faker.Name.FullName();
      var email = Faker.Internet.Email();

      serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
        new UserDtoUpdateResult
        {
          Id = Guid.NewGuid(),
          Name = nome,
          Email = email,
          UpdatedAt = DateTime.UtcNow
        }
      );

      _controller = new UsersController(serviceMock.Object);
      _controller.ModelState.AddModelError("Name", "É um campo obrigatório");

      Mock<IUrlHelper> url = new Mock<IUrlHelper>();
      url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
      _controller.Url = url.Object;

      var UserDtoUpdate = new UserDtoUpdate
      {
        Name = nome,
        Email = email,
      };

      var result = await _controller.Put(UserDtoUpdate);
      Assert.True(result is BadRequestObjectResult);
    }
  }
}
