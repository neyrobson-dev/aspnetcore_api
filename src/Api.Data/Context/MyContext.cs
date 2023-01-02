using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Data.Mapping;
using System;

namespace Api.Data.Context
{
  public class MyContext : DbContext
  {
    public DbSet<UserEntity> Users { get; set; }

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<UserEntity>(new UserMap().Configure);

      // Seed para usuario inicial
      modelBuilder.Entity<UserEntity>().HasData(
        new UserEntity
        {
          Id = Guid.NewGuid(),
          Name = "Administrador",
          Email = "admin@gmail.com",
          CreatedAt = DateTime.Now,
          UpdateAt = DateTime.Now,
        }
      );
    }
  }
}
