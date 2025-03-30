using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class m002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 1,
                column: "USUARIO_NOME",
                value: "alef");

            migrationBuilder.UpdateData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 2,
                column: "USUARIO_NOME",
                value: "thiago");

            migrationBuilder.UpdateData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 3,
                column: "USUARIO_NOME",
                value: "thiago");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 1,
                column: "USUARIO_NOME",
                value: "Alef");

            migrationBuilder.UpdateData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 2,
                column: "USUARIO_NOME",
                value: "Thiago");

            migrationBuilder.UpdateData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 3,
                column: "USUARIO_NOME",
                value: "Thiago");
        }
    }
}
