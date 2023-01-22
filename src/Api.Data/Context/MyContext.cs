using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Data.Mapping;
using System;
using Api.Data.Seeds;

namespace Api.Data.Context
{
  public class MyContext : DbContext
  {
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UfEntity> Ufs { get; set; }
    public DbSet<MunicipioEntity> Municipios { get; set; }
    public DbSet<CepEntity> Ceps { get; set; }

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<UserEntity>(new UserMap().Configure);
      modelBuilder.Entity<UfEntity>(new UfMap().Configure);
      modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
      modelBuilder.Entity<CepEntity>(new CepMap().Configure);

      // Seed para usuario inicial
      modelBuilder.Entity<UserEntity>().HasData(
        new UserEntity
        {
          Id = Guid.NewGuid(),
          Name = "Administrador",
          Email = "admin@gmail.com",
          CreatedAt = DateTime.Now,
          UpdatedAt = DateTime.Now,
        }
      );

      UfSeeds.Ufs(modelBuilder);
    }
  }
}
