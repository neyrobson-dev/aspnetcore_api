using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
  public class QuandoForExecutadoFindByLogin
  {
    private ILoginService _service;
    private Mock<ILoginService> _serviceMock;

    [Fact(DisplayName = "É Possivel executar metodo FindByLogin")]
    public async Task E_POSSIVEL_EXECUTAR_METODO_FINDBYLOGIN()
    {
      var email = Faker.Internet.Email();
      var objetoRetorno = new
      {
        authenticated = true,
        create = DateTime.UtcNow,
        expiration = DateTime.UtcNow.AddHours(8),
        accessToken = Guid.NewGuid(),
        userName = email,
        name = Faker.Name.FullName(),
        message = "Usuário Logado com sucesso"
      };

      var loginDto = new LoginDto
      {
        Email = email
      };

      _serviceMock = new Mock<ILoginService>();
      _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoRetorno);
      _service = _serviceMock.Object;

      var result = await _service.FindByLogin(loginDto);
      Assert.NotNull(result);
    }
  }
}
