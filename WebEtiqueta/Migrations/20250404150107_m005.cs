using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class m005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EMPRESA",
                keyColumn: "EMPRESA_ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "EMPRESA",
                keyColumn: "EMPRESA_ID",
                keyValue: 1,
                column: "EMPRESA_NOME",
                value: "suporte");

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 1,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 1", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 2,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 2", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 3,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 3", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 4,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 4", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 5,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 5", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 6,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 6", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 7,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 7", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 8,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 8", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 9,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 9", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 10,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 10", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 11,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 11", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 12,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 12", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 13,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 13", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 14,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 14", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 15,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 15", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 16,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 16", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 17,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 17", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 18,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 18", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 19,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 19", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 20,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 20", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 21,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 21", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 22,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 22", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 23,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 23", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 24,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 24", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 25,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 25", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 26,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 26", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 27,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 27", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 28,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 28", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 29,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 29", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 30,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 30", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 31,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 31", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 32,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 32", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 33,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 33", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 34,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 34", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 35,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 35", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 36,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 36", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 37,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 37", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 38,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 38", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 39,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 39", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 40,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 40", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 41,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 41", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 42,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 42", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 43,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 43", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 44,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 44", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 45,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 45", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 46,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 46", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 47,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 47", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 48,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 48", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 49,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 49", "tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 50,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "modelo", "etiqueta 50", "tipo" });

            migrationBuilder.UpdateData(
                table: "NIVEL_ACESSO",
                keyColumn: "NIVEL_ACESSO_ID",
                keyValue: 1,
                column: "NIVEL_ACESSO_NOME",
                value: "suporte");

            migrationBuilder.UpdateData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 1,
                columns: new[] { "USUARIO_LOGIN", "USUARIO_NOME" },
                values: new object[] { "suporte", "suporte" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EMPRESA",
                keyColumn: "EMPRESA_ID",
                keyValue: 1,
                column: "EMPRESA_NOME",
                value: "Empresa");

            migrationBuilder.InsertData(
                table: "EMPRESA",
                columns: new[] { "EMPRESA_ID", "EMPRESA_CNPJ_CPF", "EMPRESA_NOME" },
                values: new object[] { 2, "00748572000153", "ARMAZÉM FAVEIRO" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 1,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 1", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 2,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 2", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 3,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 3", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 4,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 4", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 5,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 5", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 6,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 6", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 7,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 7", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 8,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 8", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 9,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 9", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 10,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 10", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 11,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 11", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 12,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 12", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 13,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 13", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 14,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 14", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 15,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 15", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 16,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 16", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 17,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 17", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 18,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 18", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 19,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 19", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 20,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 20", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 21,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 21", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 22,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 22", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 23,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 23", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 24,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 24", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 25,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 25", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 26,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 26", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 27,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 27", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 28,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 28", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 29,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 29", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 30,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 30", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 31,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 31", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 32,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 32", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 33,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 33", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 34,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 34", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 35,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 35", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 36,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 36", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 37,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 37", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 38,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 38", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 39,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 39", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 40,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 40", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 41,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 41", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 42,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 42", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 43,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 43", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 44,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 44", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 45,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 45", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 46,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 46", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 47,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 47", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 48,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 48", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 49,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 49", "Tipo" });

            migrationBuilder.UpdateData(
                table: "ETIQUETA",
                keyColumn: "ETIQUETA_ID",
                keyValue: 50,
                columns: new[] { "ETIQUETA_MODELO", "ETIQUETA_NOME", "ETIQUETA_TIPO" },
                values: new object[] { "Modelo", "Etiqueta 50", "Tipo" });

            migrationBuilder.UpdateData(
                table: "NIVEL_ACESSO",
                keyColumn: "NIVEL_ACESSO_ID",
                keyValue: 1,
                column: "NIVEL_ACESSO_NOME",
                value: "Administrador");

            migrationBuilder.UpdateData(
                table: "USUARIO",
                keyColumn: "USUARIO_ID",
                keyValue: 1,
                columns: new[] { "USUARIO_LOGIN", "USUARIO_NOME" },
                values: new object[] { "alef", "alef" });

            migrationBuilder.InsertData(
                table: "USUARIO",
                columns: new[] { "USUARIO_ID", "USUARIO_ELIMINADO", "USUARIO_ELIMINADO_DATA", "USUARIO_ELIMINADO_POR", "USUARIO_EMPRESA_ID", "USUARIO_LOGIN", "USUARIO_NIVEL_ACESSO_ID", "USUARIO_NOME", "USUARIO_SENHA" },
                values: new object[,]
                {
                    { 2, false, null, null, 1, "thiago", 1, "thiago", "AQAAAAIAAYagAAAAEAH7K+qacDcQl3Iw8EB617kxQ39wbjr5PfBAJtfxHNS79SSubo1NIBwgOx2KqJh+eA==" },
                    { 3, false, null, null, 2, "thiago", 1, "thiago", "AQAAAAIAAYagAAAAEAH7K+qacDcQl3Iw8EB617kxQ39wbjr5PfBAJtfxHNS79SSubo1NIBwgOx2KqJh+eA==" }
                });
        }
    }
}
