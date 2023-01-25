using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Xunit;

namespace Api.Data.Test
{
  public abstract class BaseTest
  {
    public BaseTest()
    {

    }
  }

  public class DbTeste : IDisposable
  {
    private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    public ServiceProvider ServiceProvider { get; private set; }

    public DbTeste()
    {
      var serviceCollection = new ServiceCollection();
      var connectionString = $"Persist Security Info=True;Server=localhost;Database={dataBaseName};port=3306;uid=root;password=cafefaca@102030";

      serviceCollection.AddDbContext<MyContext>(o =>
        o.UseMySql(connectionString, new MySqlServerVersion(new Version("8.0.31")),
          mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
        ), ServiceLifetime.Transient
      );

      ServiceProvider = serviceCollection.BuildServiceProvider();
      using (var context = ServiceProvider.GetService<MyContext>())
      {
        context.Database.EnsureCreated();
      }
    }

    public void Dispose()
    {
      using (var context = ServiceProvider.GetService<MyContext>())
      {
        context.Database.EnsureDeleted();
      }
    }
  }

}
