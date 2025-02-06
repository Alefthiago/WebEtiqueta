using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MATRIZ",
                columns: table => new
                {
                    MATRIZ_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MATRIZ_NOME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    MATRIZ_CNPJ_CPF = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATRIZ", x => x.MATRIZ_ID);
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
                    ETIQUETA_IMPRESSORA = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ETIQUETA_ELIMINADO = table.Column<bool>(type: "boolean", nullable: false),
                    ETIQUETA_ELIMINADO_DATA = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ETIQUETA_ELIMINADO_POR = table.Column<int>(type: "integer", nullable: true),
                    ETIQUETA_MATRIZ_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETIQUETA", x => x.ETIQUETA_ID);
                    table.ForeignKey(
                        name: "FK_ETIQUETA_MATRIZ_ETIQUETA_MATRIZ_ID",
                        column: x => x.ETIQUETA_MATRIZ_ID,
                        principalTable: "MATRIZ",
                        principalColumn: "MATRIZ_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FILIAL",
                columns: table => new
                {
                    FILIAL_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FILIAL_NOME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FILIAL_CPNJ_CPF = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    FILIAL_ELIMINADO = table.Column<bool>(type: "boolean", nullable: false),
                    FILIAL_ELIMINADO_DATA = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FILIAL_ELIMINADO_POR = table.Column<int>(type: "integer", nullable: true),
                    FILIAL_MATRIZ_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILIAL", x => x.FILIAL_ID);
                    table.ForeignKey(
                        name: "FK_FILIAL_MATRIZ_FILIAL_MATRIZ_ID",
                        column: x => x.FILIAL_MATRIZ_ID,
                        principalTable: "MATRIZ",
                        principalColumn: "MATRIZ_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FILIAL_ETIQUETA",
                columns: table => new
                {
                    FILIAL_ID = table.Column<int>(type: "integer", nullable: false),
                    ETIQUETA_ID = table.Column<int>(type: "integer", nullable: false),
                    DISPONIVEL = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FILIAL_ETIQUETA", x => new { x.FILIAL_ID, x.ETIQUETA_ID });
                    table.ForeignKey(
                        name: "FK_FILIAL_ETIQUETA_ETIQUETA_ETIQUETA_ID",
                        column: x => x.ETIQUETA_ID,
                        principalTable: "ETIQUETA",
                        principalColumn: "ETIQUETA_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FILIAL_ETIQUETA_FILIAL_FILIAL_ID",
                        column: x => x.FILIAL_ID,
                        principalTable: "FILIAL",
                        principalColumn: "FILIAL_ID",
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
                    NIVEL_ACESSO_ADICIONAR_FILIAR = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_EDITAR_FILIAR = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_EXCLUIR_FILIAR = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_ELIMINADO = table.Column<bool>(type: "boolean", nullable: false),
                    NIVEL_ACESSO_ELIMINADO_DATA = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NIVEL_ACESSO_ELIMINADO_POR = table.Column<int>(type: "integer", nullable: true),
                    EliminadorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIVEL_ACESSO", x => x.NIVEL_ACESSO_ID);
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
                    USUARIO_MATRIZ_ID = table.Column<int>(type: "integer", nullable: false),
                    USUARIO_NIVEL_ACESSO_ID = table.Column<int>(type: "integer", nullable: false),
                    USUARIO_ELIMINADO = table.Column<bool>(type: "boolean", nullable: false),
                    USUARIO_ELIMINADO_DATA = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USUARIO_ELIMINADO_POR = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.USUARIO_ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_MATRIZ_USUARIO_MATRIZ_ID",
                        column: x => x.USUARIO_MATRIZ_ID,
                        principalTable: "MATRIZ",
                        principalColumn: "MATRIZ_ID",
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

            migrationBuilder.CreateTable(
                name: "USUARIO_FILIAL",
                columns: table => new
                {
                    USUARIO_FILIAL_USUARIO_ID = table.Column<int>(type: "integer", nullable: false),
                    USUARIO_FILIAL_FILIAL_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_FILIAL", x => new { x.USUARIO_FILIAL_USUARIO_ID, x.USUARIO_FILIAL_FILIAL_ID });
                    table.ForeignKey(
                        name: "FK_USUARIO_FILIAL_FILIAL_USUARIO_FILIAL_FILIAL_ID",
                        column: x => x.USUARIO_FILIAL_FILIAL_ID,
                        principalTable: "FILIAL",
                        principalColumn: "FILIAL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_FILIAL_USUARIO_USUARIO_FILIAL_USUARIO_ID",
                        column: x => x.USUARIO_FILIAL_USUARIO_ID,
                        principalTable: "USUARIO",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MATRIZ",
                columns: new[] { "MATRIZ_ID", "MATRIZ_CNPJ_CPF", "MATRIZ_NOME" },
                values: new object[] { 1, "00000000000000", "Matriz" });

            migrationBuilder.InsertData(
                table: "NIVEL_ACESSO",
                columns: new[] { "NIVEL_ACESSO_ID", "NIVEL_ACESSO_ADICIONAR_ETIQUETA", "NIVEL_ACESSO_ADICIONAR_FILIAR", "NIVEL_ACESSO_ADICIONAR_USUARIO", "NIVEL_ACESSO_EDITAR_ETIQUETA", "NIVEL_ACESSO_EDITAR_FILIAR", "NIVEL_ACESSO_EDITAR_USUARIO", "NIVEL_ACESSO_ELIMINADO", "NIVEL_ACESSO_ELIMINADO_DATA", "NIVEL_ACESSO_ELIMINADO_POR", "EliminadorId", "NIVEL_ACESSO_EXCLUIR_ETIQUETA", "NIVEL_ACESSO_EXCLUIR_FILIAR", "NIVEL_ACESSO_EXCLUIR_USUARIO", "NIVEL_ACESSO_NOME" },
                values: new object[] { 1, true, true, true, true, true, true, false, null, null, null, true, true, true, "Administrador" });

            migrationBuilder.InsertData(
                table: "USUARIO",
                columns: new[] { "USUARIO_ID", "USUARIO_ELIMINADO", "USUARIO_ELIMINADO_DATA", "USUARIO_ELIMINADO_POR", "USUARIO_LOGIN", "USUARIO_MATRIZ_ID", "USUARIO_NIVEL_ACESSO_ID", "USUARIO_NOME", "USUARIO_SENHA" },
                values: new object[] { 1, false, null, null, "suporte", 1, 1, "suporte", "AQAAAAIAAYagAAAAEAH7K+qacDcQl3Iw8EB617kxQ39wbjr5PfBAJtfxHNS79SSubo1NIBwgOx2KqJh+eA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ETIQUETA_ETIQUETA_ELIMINADO_POR",
                table: "ETIQUETA",
                column: "ETIQUETA_ELIMINADO_POR");

            migrationBuilder.CreateIndex(
                name: "IX_ETIQUETA_ETIQUETA_MATRIZ_ID",
                table: "ETIQUETA",
                column: "ETIQUETA_MATRIZ_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FILIAL_FILIAL_ELIMINADO_POR",
                table: "FILIAL",
                column: "FILIAL_ELIMINADO_POR");

            migrationBuilder.CreateIndex(
                name: "IX_FILIAL_FILIAL_MATRIZ_ID",
                table: "FILIAL",
                column: "FILIAL_MATRIZ_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FILIAL_ETIQUETA_ETIQUETA_ID",
                table: "FILIAL_ETIQUETA",
                column: "ETIQUETA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NIVEL_ACESSO_EliminadorId",
                table: "NIVEL_ACESSO",
                column: "EliminadorId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_USUARIO_ELIMINADO_POR",
                table: "USUARIO",
                column: "USUARIO_ELIMINADO_POR");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_USUARIO_MATRIZ_ID",
                table: "USUARIO",
                column: "USUARIO_MATRIZ_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_USUARIO_NIVEL_ACESSO_ID",
                table: "USUARIO",
                column: "USUARIO_NIVEL_ACESSO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_FILIAL_USUARIO_FILIAL_FILIAL_ID",
                table: "USUARIO_FILIAL",
                column: "USUARIO_FILIAL_FILIAL_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ETIQUETA_USUARIO_ETIQUETA_ELIMINADO_POR",
                table: "ETIQUETA",
                column: "ETIQUETA_ELIMINADO_POR",
                principalTable: "USUARIO",
                principalColumn: "USUARIO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FILIAL_USUARIO_FILIAL_ELIMINADO_POR",
                table: "FILIAL",
                column: "FILIAL_ELIMINADO_POR",
                principalTable: "USUARIO",
                principalColumn: "USUARIO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NIVEL_ACESSO_USUARIO_EliminadorId",
                table: "NIVEL_ACESSO",
                column: "EliminadorId",
                principalTable: "USUARIO",
                principalColumn: "USUARIO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIO_MATRIZ_USUARIO_MATRIZ_ID",
                table: "USUARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_NIVEL_ACESSO_USUARIO_EliminadorId",
                table: "NIVEL_ACESSO");

            migrationBuilder.DropTable(
                name: "FILIAL_ETIQUETA");

            migrationBuilder.DropTable(
                name: "USUARIO_FILIAL");

            migrationBuilder.DropTable(
                name: "ETIQUETA");

            migrationBuilder.DropTable(
                name: "FILIAL");

            migrationBuilder.DropTable(
                name: "MATRIZ");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "NIVEL_ACESSO");
        }
    }
}
