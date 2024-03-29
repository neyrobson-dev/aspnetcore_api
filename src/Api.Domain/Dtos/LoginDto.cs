using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
  public class LoginDto
  {
    [Required(ErrorMessage = "E-mail é campo obrigatório para login")]
    [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
    [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres.")]
    public string Email { get; set; }
  }
}
