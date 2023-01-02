using System;
using System.Collections.Generic;
using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Security;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          services.AddControllers();

          // Injeção de dependencias (services)
          ConfigureService.ConfigureDependenciesService(services);
          // Injeção de dependencias (repositories)
          ConfigureRepository.ConfigureDependenciesRepository(services);

          // Automapper
          var configMapper = new AutoMapper.MapperConfiguration(cfg => {
            cfg.AddProfile(new DtoToModelProfile());
            cfg.AddProfile(new EntityToDtoProfile());
            cfg.AddProfile(new ModelToEntityProfile());
          });
          IMapper mapper = configMapper.CreateMapper();
          services.AddSingleton(mapper);

          // JWT
          var signingConfiguration = new SigningConfiguration();
          services.AddSingleton(signingConfiguration);

          var tokenConfiguration = new TokenConfiguration();
          new ConfigureFromConfigurationOptions<TokenConfiguration>(
            Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);
          services.AddSingleton(tokenConfiguration);

          services.AddAuthentication(authOptions => {
            authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          }).AddJwtBearer(bearerOptions => {
            var paramsValidation = bearerOptions.TokenValidationParameters;
            paramsValidation.IssuerSigningKey = signingConfiguration.Key;
            paramsValidation.ValidAudience = tokenConfiguration.Audiance;
            paramsValidation.ValidIssuer = tokenConfiguration.Issuer;
            paramsValidation.ValidateIssuerSigningKey = true;
            paramsValidation.ValidateLifetime = true;
            paramsValidation.ClockSkew = TimeSpan.Zero;
          });

          services.AddAuthorization(auth => {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build()
              );
          });

          // Playground Swagger
          services.AddSwaggerGen(c =>
          {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
              Version = "v1",
              Title = "Curso de API com AspNetCore 3.1 - Na Prática",
              Description = "Arquitetura DDD",
              // TermsOfService = new Uri("http://www.mfrinfo.com.br"),
              // Contact = new OpenApiContact
              // {
              //     Name = "Ney Robson Araujo Ganma",
              //     Email = "neyrobson.dev@gmail.com",
              //     // Url = new Uri("http://www.mfrinfo.com.br")
              // },
              // License = new OpenApiLicense
              // {
                // Name = "Termo de Licença de Uso",
              //     Url = new Uri("http://www.mfrinfo.com.br")
              // }
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
              Description = "Entre com o Token JWT",
              Name = "Authorization",
              In = ParameterLocation.Header,
              Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
              {
                new OpenApiSecurityScheme
                {
                  Reference = new OpenApiReference
                  {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                  }
                }, new List<string>()
              }
            });
          });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de API com AspNetCore 3.1");
              c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Aplicar as atualizações de BD - verificar primeiro....
            if (Environment.GetEnvironmentVariable("MIGRATION").ToLower() == "APLICAR".ToLower())
            {
              using (var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
              {
                using (var context = service.ServiceProvider.GetService<MyContext>())
                {
                  context.Database.Migrate();
                }
              }
            }
        }
    }
}
