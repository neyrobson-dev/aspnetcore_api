using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
  public class QuandoForExecutadoGet : UsersTests
  {
    private IUserService _service;
    private Mock<IUserService> _serviceMock;

    [Fact(DisplayName = "É possível executar o médoto GET")]
    public async Task E_POSSIVEL_EXECUTAR_METODO_GET()
    {
      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Get(IdUser)).ReturnsAsync(userDto);
      _service = _serviceMock.Object;

      var result = await _service.Get(IdUser);

      Assert.NotNull(result);
      Assert.True(result.Id == IdUser);
      Assert.Equal(NameUser, result.Name);

      _serviceMock = new Mock<IUserService>();
      _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
      _service = _serviceMock.Object;

      var _record = await _service.Get(IdUser);
      Assert.Null(_record);
    }
  }
}
