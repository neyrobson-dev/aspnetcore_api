using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class QuandoForExecutadoUpdate : UsersTests
  {
    private IUserService _service;
    private Mock<IUserService> _serviceMock;

    [Fact(DisplayName = "É possível executar o médoto Update")]
    public async Task E_POSSIVEL_EXECUTAR_METODO_UPDATE()
    {
      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
      _service = _serviceMock.Object;

      var result = await _service.Post(userDtoCreate);

      Assert.NotNull(result);
      Assert.Equal(NameUser, result.Name);
      Assert.Equal(EmailUser, result.Email);

      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
      _service = _serviceMock.Object;

      var resultUpdate = await _service.Put(userDtoUpdate);

      Assert.NotNull(resultUpdate);
      Assert.Equal(NameUserChanged, resultUpdate.Name);
      Assert.Equal(EmailUserChanged, resultUpdate.Email);
    }
  }
}
