using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
  public partial class MigrationCompleto : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Uf",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Sigla = table.Column<string>(maxLength: 2, nullable: false),
            Nome = table.Column<string>(maxLength: 45, nullable: false),
            CreatedAt = table.Column<DateTime>(nullable: true),
            UpdatedAt = table.Column<DateTime>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Uf", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "User",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Name = table.Column<string>(maxLength: 60, nullable: false),
            Email = table.Column<string>(maxLength: 100, nullable: false),
            CreatedAt = table.Column<DateTime>(nullable: true),
            UpdatedAt = table.Column<DateTime>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_User", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Municipio",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Nome = table.Column<string>(maxLength: 60, nullable: false),
            CodIBGE = table.Column<int>(nullable: false),
            UfId = table.Column<Guid>(nullable: false),
            CreatedAt = table.Column<DateTime>(nullable: true),
            UpdatedAt = table.Column<DateTime>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Municipio", x => x.Id);
            table.ForeignKey(
                      name: "FK_Municipio_Uf_UfId",
                      column: x => x.UfId,
                      principalTable: "Uf",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Cep",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Cep = table.Column<string>(maxLength: 10, nullable: false),
            Logradouro = table.Column<string>(maxLength: 60, nullable: false),
            Numero = table.Column<string>(maxLength: 10, nullable: true),
            MunicipioId = table.Column<Guid>(nullable: false),
            CreatedAt = table.Column<DateTime>(nullable: true),
            UpdatedAt = table.Column<DateTime>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Cep", x => x.Id);
            table.ForeignKey(
                      name: "FK_Cep_Municipio_MunicipioId",
                      column: x => x.MunicipioId,
                      principalTable: "Municipio",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.InsertData(
          table: "Uf",
          columns: new[] { "Id", "CreatedAt", "Nome", "Sigla", "UpdatedAt" },
          values: new object[,]
          {
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9482), "Acre", "AC", null },
                    { new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9573), "São Paulo", "SP", null },
                    { new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9571), "Sergipe", "SE", null },
                    { new Guid("b81f95e0-f226-4afd-9763-290001637ed4"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9569), "Santa Catarina", "SC", null },
                    { new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9567), "Rio Grande do Sul", "RS", null },
                    { new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9564), "Roraima", "RR", null },
                    { new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9563), "Rondônia", "RO", null },
                    { new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9561), "Rio Grande do Norte", "RN", null },
                    { new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9559), "Rio de Janeiro", "RJ", null },
                    { new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9557), "Paraná", "PR", null },
                    { new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9555), "Piauí", "PI", null },
                    { new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9553), "Pernambuco", "PE", null },
                    { new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9551), "Paraíba", "PB", null },
                    { new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9549), "Pará", "PA", null },
                    { new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9547), "Mato Grosso", "MT", null },
                    { new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9545), "Mato Grosso do Sul", "MS", null },
                    { new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9543), "Minas Gerais", "MG", null },
                    { new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9541), "Maranhão", "MA", null },
                    { new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9539), "Goiás", "GO", null },
                    { new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9537), "Espírito Santo", "ES", null },
                    { new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9535), "Distrito Federal", "DF", null },
                    { new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9533), "Ceará", "CE", null },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9531), "Bahia", "BA", null },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9529), "Amapá", "AP", null },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9526), "Amazonas", "AM", null },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9522), "Alagoas", "AL", null },
                    { new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"), new DateTime(2023, 1, 22, 22, 14, 22, 658, DateTimeKind.Utc).AddTicks(9575), "Tocantins", "TO", null }
          });

      migrationBuilder.InsertData(
          table: "User",
          columns: new[] { "Id", "CreatedAt", "Email", "Name", "UpdatedAt" },
          values: new object[] { new Guid("c8a1e074-ee15-484e-aed3-b209c4830d94"), new DateTime(2023, 1, 22, 19, 14, 22, 656, DateTimeKind.Local).AddTicks(2449), "admin@gmail.com", "Administrador", new DateTime(2023, 1, 22, 19, 14, 22, 657, DateTimeKind.Local).AddTicks(135) });

      migrationBuilder.CreateIndex(
          name: "IX_Cep_Cep",
          table: "Cep",
          column: "Cep");

      migrationBuilder.CreateIndex(
          name: "IX_Cep_MunicipioId",
          table: "Cep",
          column: "MunicipioId");

      migrationBuilder.CreateIndex(
          name: "IX_Municipio_CodIBGE",
          table: "Municipio",
          column: "CodIBGE");

      migrationBuilder.CreateIndex(
          name: "IX_Municipio_UfId",
          table: "Municipio",
          column: "UfId");

      migrationBuilder.CreateIndex(
          name: "IX_Uf_Sigla",
          table: "Uf",
          column: "Sigla",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_User_Email",
          table: "User",
          column: "Email",
          unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Cep");

      migrationBuilder.DropTable(
          name: "User");

      migrationBuilder.DropTable(
          name: "Municipio");

      migrationBuilder.DropTable(
          name: "Uf");
    }
  }
}
