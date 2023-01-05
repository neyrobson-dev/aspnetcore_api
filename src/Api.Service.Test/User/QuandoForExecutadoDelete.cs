using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class QuandoForExecutadoDelete : UsersTests
  {
    private IUserService _service;
    private Mock<IUserService> _serviceMock;

    [Fact(DisplayName = "É possível executar o médoto Delete")]
    public async Task E_POSSIVEL_EXECUTAR_METODO_DELETE()
    {
      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Delete(IdUser)).ReturnsAsync(true);
      _service = _serviceMock.Object;

      var result = await _service.Delete(IdUser);

      Assert.True(result);

      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
      _service = _serviceMock.Object;

      var resultFalse = await _service.Delete(Guid.NewGuid());

      Assert.False(resultFalse);
    }
  }
}
