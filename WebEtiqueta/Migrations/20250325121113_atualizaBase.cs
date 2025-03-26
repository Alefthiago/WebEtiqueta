using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEtiqueta.Migrations
{
    /// <inheritdoc />
    public partial class atualizaBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ETIQUETA_IMPRESSORA",
                table: "ETIQUETA",
                newName: "ETIQUETA_TIPO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ETIQUETA_TIPO",
                table: "ETIQUETA",
                newName: "ETIQUETA_IMPRESSORA");
        }
    }
}
