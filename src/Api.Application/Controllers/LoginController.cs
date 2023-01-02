using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    [HttpPost]
    public async Task<object> Login([FromBody] UserEntity user, [FromServices] ILoginService service)
    {
      if (!ModelState.IsValid || user == null)
        return BadRequest(ModelState);

      try
      {
        var result = await service.FindByLogin(user);
        if (result != null)
          return Ok(result);
        else
          return NotFound();
      }
      catch (ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
      }

    }
  }
}
