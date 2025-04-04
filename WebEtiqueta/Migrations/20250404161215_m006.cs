using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class m006 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EMPRESA",
                columns: new[] { "EMPRESA_ID", "EMPRESA_CNPJ_CPF", "EMPRESA_NOME" },
                values: new object[] { 2, "00748572000153", "empresa 2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EMPRESA",
                keyColumn: "EMPRESA_ID",
                keyValue: 2);
        }
    }
}
