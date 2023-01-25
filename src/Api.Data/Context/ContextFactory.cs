using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      // Usado pra criar as migrations
      var connectionString = "server=localhost;port=3306;database=curso;uid=root;password=cafefaca@102030";
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version("8.0.31")),
        mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
      );
      return new MyContext(optionsBuilder.Options);
    }
  }
}
