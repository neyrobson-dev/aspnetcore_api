using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Respository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Api.CrossCutting.DependencyInjection
{
  public class ConfigureRepository
  {
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

      serviceCollection.AddScoped<IUserRepository, UserImplementation>();
      serviceCollection.AddScoped<IUfRepository, UfImplementation>();
      serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();
      serviceCollection.AddScoped<ICepRepository, CepImplementation>();

      // if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MySQL".ToLower())
      // {
      serviceCollection.AddDbContext<MyContext>(
        options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"), new MySqlServerVersion(new Version("8.0.31")),
          mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
        )
      );
      // }
    }
  }
}
