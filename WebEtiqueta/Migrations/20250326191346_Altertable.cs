using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class Altertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MATRIZ_ID",
                table: "FILIAL_ETIQUETA",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FILIAL_ETIQUETA_MATRIZ_ID",
                table: "FILIAL_ETIQUETA",
                column: "MATRIZ_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FILIAL_ETIQUETA_MATRIZ_MATRIZ_ID",
                table: "FILIAL_ETIQUETA",
                column: "MATRIZ_ID",
                principalTable: "MATRIZ",
                principalColumn: "MATRIZ_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FILIAL_ETIQUETA_MATRIZ_MATRIZ_ID",
                table: "FILIAL_ETIQUETA");

            migrationBuilder.DropIndex(
                name: "IX_FILIAL_ETIQUETA_MATRIZ_ID",
                table: "FILIAL_ETIQUETA");

            migrationBuilder.DropColumn(
                name: "MATRIZ_ID",
                table: "FILIAL_ETIQUETA");
        }
    }
}
