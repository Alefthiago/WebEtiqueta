using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class M001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    EMPRESA_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EMPRESA_NOME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    EMPRESA_CNPJ_CPF = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.EMPRESA_ID);
                });

            migrationBuilder.CreateTable(
                name: "ETIQUETA",
                columns: table => new
                {
                    ETIQUETA_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ETIQUETA_NOME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ETIQUETA_COLUNAS = table.Column<int>(type: "integer", nullable: false),
                    ETIQUETA_LINHAS = table.Column<int>(type: "integer", nullable: false),
                    ETIQUETA_MODELO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ETIQUETA_LARGURA = table.Column<int>(type: "integer", nullable: false),
                    ETIQUETA_ALTURA = table.Column<int>(type: "integer", nullable: false),
                    ETIQUETA_ESPACOX = table.Column<int>(type: "integer", nullable: false),
                    ETIQUETA_ESPACOY = table.Column<int>(type: "integer", nullable: false),
                    ETIQUETA_TIPO = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ETIQUETA_ELIMINADO = table.Column<bool>(type: "boolean", nullable: false),
                    ETIQUETA_ELIMINADO_DATA = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ETIQUETA_ELIMINADO_POR = table.Column<int>(type: "integer", nullable: true),
                    ETIQUETA_EMPRESA_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETIQUETA", x => x.ETIQUETA_ID);
                    table.ForeignKey(
                        name: "FK_ETIQUETA_EMPRESA_ETIQUETA_EMPRESA_ID",
                        column: x => x.ETIQUETA_EMPRESA_ID,
                        principalTable: "EMPRESA",
                        principalColumn: "EMPRESA_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NIVEL_ACESSO",
                columns: table => new
                {
                    NIVEL_ACESSO_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NIVEL_ACESSO_NOME = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NIVEL_ACESSO_ADICIONAR_USUARIO = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_EDITAR_USUARIO = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_EXCLUIR_USUARIO = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_ADICIONAR_ETIQUETA = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_EDITAR_ETIQUETA = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_EXCLUIR_ETIQUETA = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_EMPRESA_ID = table.Column<int>(type: "integer", nullable: false),
                    NIVEL_ACESSO_ELIMINADO = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_ELIMINADO_DATA = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NIVEL_ACESSO_ELIMINADO_POR = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIVEL_ACESSO", x => x.NIVEL_ACESSO_ID);
                    table.ForeignKey(
                        name: "FK_NIVEL_ACESSO_EMPRESA_NIVEL_ACESSO_EMPRESA_ID",
                        column: x => x.NIVEL_ACESSO_EMPRESA_ID,
                        principalTable: "EMPRESA",
                        principalColumn: "EMPRESA_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    USUARIO_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USUARIO_NOME = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    USUARIO_LOGIN = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    USUARIO_SENHA = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    USUARIO_ELIMINADO = table.Column<bool>(type: "boolean", nullable: false),
                    USUARIO_EMPRESA_ID = table.Column<int>(type: "integer", nullable: false),
                    USUARIO_NIVEL_ACESSO_ID = table.Column<int>(type: "integer", nullable: false),
                    USUARIO_ELIMINADO_DATA = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USUARIO_ELIMINADO_POR = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.USUARIO_ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_EMPRESA_USUARIO_EMPRESA_ID",
                        column: x => x.USUARIO_EMPRESA_ID,
                        principalTable: "EMPRESA",
                        principalColumn: "EMPRESA_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_NIVEL_ACESSO_USUARIO_NIVEL_ACESSO_ID",
                        column: x => x.USUARIO_NIVEL_ACESSO_ID,
                        principalTable: "NIVEL_ACESSO",
                        principalColumn: "NIVEL_ACESSO_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_USUARIO_USUARIO_ELIMINADO_POR",
                        column: x => x.USUARIO_ELIMINADO_POR,
                        principalTable: "USUARIO",
                        principalColumn: "USUARIO_ID");
                });

            migrationBuilder.InsertData(
                table: "EMPRESA",
                columns: new[] { "EMPRESA_ID", "EMPRESA_CNPJ_CPF", "EMPRESA_NOME" },
                values: new object[,]
                {
                    { 1, "00000000000000", "Empresa" },
                    { 2, "00748572000153", "ARMAZÉM FAVEIRO" }
                });

            migrationBuilder.InsertData(
                table: "NIVEL_ACESSO",
                columns: new[] { "NIVEL_ACESSO_ID", "NIVEL_ACESSO_ADICIONAR_ETIQUETA", "NIVEL_ACESSO_ADICIONAR_USUARIO", "NIVEL_ACESSO_EDITAR_ETIQUETA", "NIVEL_ACESSO_EDITAR_USUARIO", "NIVEL_ACESSO_ELIMINADO", "NIVEL_ACESSO_ELIMINADO_DATA", "NIVEL_ACESSO_ELIMINADO_POR", "NIVEL_ACESSO_EMPRESA_ID", "NIVEL_ACESSO_EXCLUIR_ETIQUETA", "NIVEL_ACESSO_EXCLUIR_USUARIO", "NIVEL_ACESSO_NOME" },
                values: new object[] { 1, true, true, true, true, false, null, null, 1, true, true, "Administrador" });

            migrationBuilder.InsertData(
                table: "USUARIO",
                columns: new[] { "USUARIO_ID", "USUARIO_ELIMINADO", "USUARIO_ELIMINADO_DATA", "USUARIO_ELIMINADO_POR", "USUARIO_EMPRESA_ID", "USUARIO_LOGIN", "USUARIO_NIVEL_ACESSO_ID", "USUARIO_NOME", "USUARIO_SENHA" },
                values: new object[,]
                {
                    { 1, false, null, null, 1, "alef", 1, "Alef", "AQAAAAIAAYagAAAAEAH7K+qacDcQl3Iw8EB617kxQ39wbjr5PfBAJtfxHNS79SSubo1NIBwgOx2KqJh+eA==" },
                    { 2, false, null, null, 1, "thiago", 1, "Thiago", "AQAAAAIAAYagAAAAEAH7K+qacDcQl3Iw8EB617kxQ39wbjr5PfBAJtfxHNS79SSubo1NIBwgOx2KqJh+eA==" },
                    { 3, false, null, null, 2, "thiago", 1, "Thiago", "AQAAAAIAAYagAAAAEAH7K+qacDcQl3Iw8EB617kxQ39wbjr5PfBAJtfxHNS79SSubo1NIBwgOx2KqJh+eA==" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ETIQUETA_ETIQUETA_ELIMINADO_POR",
                table: "ETIQUETA",
                column: "ETIQUETA_ELIMINADO_POR");

            migrationBuilder.CreateIndex(
                name: "IX_ETIQUETA_ETIQUETA_EMPRESA_ID",
                table: "ETIQUETA",
                column: "ETIQUETA_EMPRESA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NIVEL_ACESSO_NIVEL_ACESSO_ELIMINADO_POR",
                table: "NIVEL_ACESSO",
                column: "NIVEL_ACESSO_ELIMINADO_POR");

            migrationBuilder.CreateIndex(
                name: "IX_NIVEL_ACESSO_NIVEL_ACESSO_EMPRESA_ID",
                table: "NIVEL_ACESSO",
                column: "NIVEL_ACESSO_EMPRESA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_USUARIO_ELIMINADO_POR",
                table: "USUARIO",
                column: "USUARIO_ELIMINADO_POR");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_USUARIO_EMPRESA_ID",
                table: "USUARIO",
                column: "USUARIO_EMPRESA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_USUARIO_NIVEL_ACESSO_ID",
                table: "USUARIO",
                column: "USUARIO_NIVEL_ACESSO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ETIQUETA_USUARIO_ETIQUETA_ELIMINADO_POR",
                table: "ETIQUETA",
                column: "ETIQUETA_ELIMINADO_POR",
                principalTable: "USUARIO",
                principalColumn: "USUARIO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NIVEL_ACESSO_USUARIO_NIVEL_ACESSO_ELIMINADO_POR",
                table: "NIVEL_ACESSO",
                column: "NIVEL_ACESSO_ELIMINADO_POR",
                principalTable: "USUARIO",
                principalColumn: "USUARIO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NIVEL_ACESSO_EMPRESA_NIVEL_ACESSO_EMPRESA_ID",
                table: "NIVEL_ACESSO");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIO_EMPRESA_USUARIO_EMPRESA_ID",
                table: "USUARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_NIVEL_ACESSO_USUARIO_NIVEL_ACESSO_ELIMINADO_POR",
                table: "NIVEL_ACESSO");

            migrationBuilder.DropTable(
                name: "ETIQUETA");

            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "NIVEL_ACESSO");
        }
    }
}
