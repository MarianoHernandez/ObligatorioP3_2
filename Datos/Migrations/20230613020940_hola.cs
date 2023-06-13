using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class hola : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cabania_Nombre",
                table: "Cabania");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "TipoCabania");

            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "Mantenimiento");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Cabania");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Cabania");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion_Value",
                table: "TipoCabania",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "descripcion_Value",
                table: "Mantenimiento",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion_Value",
                table: "Cabania",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre_Value",
                table: "Cabania",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoCabania_Descripcion_Value",
                table: "TipoCabania",
                column: "Descripcion_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_descripcion_Value",
                table: "Mantenimiento",
                column: "descripcion_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cabania_Descripcion_Value",
                table: "Cabania",
                column: "Descripcion_Value",
                unique: true,
                filter: "[Descripcion_Value] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cabania_Nombre_Value",
                table: "Cabania",
                column: "Nombre_Value",
                unique: true,
                filter: "[Nombre_Value] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TipoCabania_Descripcion_Value",
                table: "TipoCabania");

            migrationBuilder.DropIndex(
                name: "IX_Mantenimiento_descripcion_Value",
                table: "Mantenimiento");

            migrationBuilder.DropIndex(
                name: "IX_Cabania_Descripcion_Value",
                table: "Cabania");

            migrationBuilder.DropIndex(
                name: "IX_Cabania_Nombre_Value",
                table: "Cabania");

            migrationBuilder.DropColumn(
                name: "Descripcion_Value",
                table: "TipoCabania");

            migrationBuilder.DropColumn(
                name: "descripcion_Value",
                table: "Mantenimiento");

            migrationBuilder.DropColumn(
                name: "Descripcion_Value",
                table: "Cabania");

            migrationBuilder.DropColumn(
                name: "Nombre_Value",
                table: "Cabania");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "TipoCabania",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "Mantenimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Cabania",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Cabania",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cabania_Nombre",
                table: "Cabania",
                column: "Nombre",
                unique: true);
        }
    }
}
