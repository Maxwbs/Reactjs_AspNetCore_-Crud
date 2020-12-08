using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCE.Data.Migrations
{
    public partial class mce_migration_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MCE_MEMBRO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 160, nullable: true),
                    CargoMinisterial = table.Column<int>(nullable: false),
                    MembroEhAtivo = table.Column<bool>(nullable: false),
                    GerarCredencial = table.Column<bool>(nullable: false),
                    DataBatismoEspiritoSanto = table.Column<DateTime>(nullable: true),
                    DataBatismoAguas = table.Column<DateTime>(nullable: true),
                    CredencialMinistro = table.Column<byte[]>(nullable: true),
                    Congregacao = table.Column<int>(maxLength: 160, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCE_MEMBRO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MCE_PARAMETRIZACAOCREDENCIAL",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false),
                    Extensao = table.Column<string>(maxLength: 4, nullable: false),
                    Tamanho = table.Column<long>(nullable: false),
                    Imagem = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCE_PARAMETRIZACAOCREDENCIAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MCE_ENDERECO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Cep = table.Column<string>(maxLength: 50, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 200, nullable: true),
                    Complemento = table.Column<string>(maxLength: 200, nullable: true),
                    Bairro = table.Column<string>(maxLength: 200, nullable: true),
                    Localidade = table.Column<string>(maxLength: 200, nullable: true),
                    Uf = table.Column<string>(maxLength: 10, nullable: true),
                    Ddd = table.Column<string>(maxLength: 10, nullable: true),
                    IdPessoaEndereco = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCE_ENDERECO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MCE_ENDERECO_MCE_MEMBRO_IdPessoaEndereco",
                        column: x => x.IdPessoaEndereco,
                        principalTable: "MCE_MEMBRO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MCE_PESSOA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 260, nullable: false),
                    NomePai = table.Column<string>(maxLength: 260, nullable: false),
                    NomeMae = table.Column<string>(maxLength: 260, nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Rg = table.Column<string>(maxLength: 100, nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Naturalidade = table.Column<string>(nullable: true),
                    EstadoCivil = table.Column<int>(nullable: false),
                    OrgaoEmissorRg = table.Column<string>(maxLength: 160, nullable: true),
                    Nacionalidade = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    IdPessoaMembro = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCE_PESSOA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MCE_PESSOA_MCE_MEMBRO_IdPessoaMembro",
                        column: x => x.IdPessoaMembro,
                        principalTable: "MCE_MEMBRO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MCE_ENDERECO_IdPessoaEndereco",
                table: "MCE_ENDERECO",
                column: "IdPessoaEndereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MCE_PESSOA_IdPessoaMembro",
                table: "MCE_PESSOA",
                column: "IdPessoaMembro",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MCE_ENDERECO");

            migrationBuilder.DropTable(
                name: "MCE_PARAMETRIZACAOCREDENCIAL");

            migrationBuilder.DropTable(
                name: "MCE_PESSOA");

            migrationBuilder.DropTable(
                name: "MCE_MEMBRO");
        }
    }
}
