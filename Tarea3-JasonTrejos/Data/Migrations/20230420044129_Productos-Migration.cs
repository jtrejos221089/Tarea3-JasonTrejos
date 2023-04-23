using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea3_JasonTrejos.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductosMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lote_Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaFabricacion_Producto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombre_Producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_Proveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaCaducidad_Producto = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id_Producto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productos");
        }
    }
}
