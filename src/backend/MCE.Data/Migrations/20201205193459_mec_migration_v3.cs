using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCE.Data.Migrations
{
    public partial class mec_migration_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UsuarioEntity",
                columns: new[] { "Id", "CreateAt", "Email", "Nome", "Senha", "UpdateAt" },
                values: new object[] { new Guid("f9503f79-3c21-49b6-8c43-407b3c8be6d4"), new DateTime(2020, 12, 5, 16, 34, 58, 202, DateTimeKind.Local).AddTicks(176), "maxwbs@gmail.com", "Administrador", "1234", new DateTime(2020, 12, 5, 16, 34, 58, 203, DateTimeKind.Local).AddTicks(5289) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioEntity");
        }
    }
}
