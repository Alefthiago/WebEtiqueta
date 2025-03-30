using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class m003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ETIQUETA",
                columns: new[] { "ETIQUETA_ID", "ETIQUETA_ALTURA", "ETIQUETA_COLUNAS", "ETIQUETA_ELIMINADO", "ETIQUETA_ELIMINADO_DATA", "ETIQUETA_ELIMINADO_POR", "ETIQUETA_EMPRESA_ID", "ETIQUETA_ESPACOX", "ETIQUETA_ESPACOY", "ETIQUETA_LARGURA", "ETIQUETA_LINHAS", "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[,]
                {
                    { 1, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 1", "Tipo" },
                    { 2, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 2", "Tipo" },
                    { 3, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 3", "Tipo" },
                    { 4, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 4", "Tipo" },
                    { 5, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 5", "Tipo" },
                    { 6, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 6", "Tipo" },
                    { 7, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 7", "Tipo" },
                    { 8, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 8", "Tipo" },
                    { 9, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 9", "Tipo" },
                    { 10, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 10", "Tipo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 10);
        }
    }
}
