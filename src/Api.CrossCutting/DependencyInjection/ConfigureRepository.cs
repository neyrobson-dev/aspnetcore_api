using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Respository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
  public class ConfigureRepository
  {
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
      serviceCollection.AddScoped<IUserRepository, UserImplementation>();

      serviceCollection.AddDbContext<MyContext>(
        options => options.UseMySql("server=localhost;port=3306;database=curso;uid=root;password=cafefaca@102030")
      );
    }
  }
}
