using System;

namespace Api.Domain.Dtos.Municipio
{
  public class MunicipioDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int CodIBGE { get; set; }
    public Guid UfId { get; set; }
  }
}
