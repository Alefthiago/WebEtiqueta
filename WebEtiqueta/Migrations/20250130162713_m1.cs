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
                name: "Etiqueta",
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
                    ETIQUETA_ELIMINADO_POR = table.Column<int>(type: "integer", nullable: false),
                    ETIQUETA_ELIMINADO_DATA = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiqueta", x => x.ETIQUETA_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etiqueta");
        }
    }
}
