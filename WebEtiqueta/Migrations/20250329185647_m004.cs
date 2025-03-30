using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class m004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ETIQUETA",
                columns: new[] { "ETIQUETA_ID", "ETIQUETA_ALTURA", "ETIQUETA_COLUNAS", "ETIQUETA_ELIMINADO", "ETIQUETA_ELIMINADO_DATA", "ETIQUETA_ELIMINADO_POR", "ETIQUETA_EMPRESA_ID", "ETIQUETA_ESPACOX", "ETIQUETA_ESPACOY", "ETIQUETA_LARGURA", "ETIQUETA_LINHAS", "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[,]
                {
                    { 11, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 11", "Tipo" },
                    { 12, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 12", "Tipo" },
                    { 13, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 13", "Tipo" },
                    { 14, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 14", "Tipo" },
                    { 15, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 15", "Tipo" },
                    { 16, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 16", "Tipo" },
                    { 17, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 17", "Tipo" },
                    { 18, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 18", "Tipo" },
                    { 19, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 19", "Tipo" },
                    { 20, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 20", "Tipo" },
                    { 21, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 21", "Tipo" },
                    { 22, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 22", "Tipo" },
                    { 23, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 23", "Tipo" },
                    { 24, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 24", "Tipo" },
                    { 25, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 25", "Tipo" },
                    { 26, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 26", "Tipo" },
                    { 27, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 27", "Tipo" },
                    { 28, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 28", "Tipo" },
                    { 29, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 29", "Tipo" },
                    { 30, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 30", "Tipo" },
                    { 31, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 31", "Tipo" },
                    { 32, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 32", "Tipo" },
                    { 33, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 33", "Tipo" },
                    { 34, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 34", "Tipo" },
                    { 35, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 35", "Tipo" },
                    { 36, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 36", "Tipo" },
                    { 37, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 37", "Tipo" },
                    { 38, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 38", "Tipo" },
                    { 39, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 39", "Tipo" },
                    { 40, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 40", "Tipo" },
                    { 41, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 41", "Tipo" },
                    { 42, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 42", "Tipo" },
                    { 43, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 43", "Tipo" },
                    { 44, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 44", "Tipo" },
                    { 45, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 45", "Tipo" },
                    { 46, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 46", "Tipo" },
                    { 47, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 47", "Tipo" },
                    { 48, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 48", "Tipo" },
                    { 49, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 49", "Tipo" },
                    { 50, 100, 2, false, null, null, 1, 10, 10, 100, 2, "Modelo", "Etiqueta 50", "Tipo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 50);
        }
    }
}
