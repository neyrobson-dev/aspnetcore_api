using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      // Usado pra criar as migrations
      var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION"); // "server=localhost;port=3306;database=curso;uid=root;password=cafefaca@102030";
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      optionsBuilder.UseMySql(connectionString);
      return new MyContext(optionsBuilder.Options);
    }
  }
}
