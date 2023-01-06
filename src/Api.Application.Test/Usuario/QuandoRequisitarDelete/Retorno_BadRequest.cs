using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarDelete
{
  public class Retorno_BadRequest
  {
    private UsersController _controller;

    [Fact(DisplayName = "É possível Realizar o Deleted.")]
    public async Task E_POSSIVEL_INVOCAR_A_CONTROLLER_DELETE()
    {
      var serviceMock = new Mock<IUserService>();
      serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

      _controller = new UsersController(serviceMock.Object);
      _controller.ModelState.AddModelError("Id", "Formato inválido");

      var result = await _controller.Delete(default(Guid));
      Assert.True(result is BadRequestObjectResult);
      Assert.False(_controller.ModelState.IsValid);
    }
  }
}
