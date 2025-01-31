using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matriz",
                columns: table => new
                {
                    MATRIZ_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MATRIZ_NOME = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    MATRIZ_CNPJ_CPF = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriz", x => x.MATRIZ_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_USUARIO_MATRIZ_ID",
                table: "Usuario",
                column: "USUARIO_MATRIZ_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Matriz_USUARIO_MATRIZ_ID",
                table: "Usuario",
                column: "USUARIO_MATRIZ_ID",
                principalTable: "Matriz",
                principalColumn: "MATRIZ_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Matriz_USUARIO_MATRIZ_ID",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Matriz");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_USUARIO_MATRIZ_ID",
                table: "Usuario");
        }
    }
}
