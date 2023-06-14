using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datos.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ValorMaximo = table.Column<int>(type: "int", nullable: false),
                    ValorMinimo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCabania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion_Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCabania", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cabania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCabaniaId = table.Column<int>(type: "int", nullable: false),
                    Nombre_Value = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descripcion_Value = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Jacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    Habilitada = table.Column<bool>(type: "bit", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cabania_TipoCabania_TipoCabaniaId",
                        column: x => x.TipoCabaniaId,
                        principalTable: "TipoCabania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion_Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    trabajador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabaniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_Cabania_CabaniaId",
                        column: x => x.CabaniaId,
                        principalTable: "Cabania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cabania_TipoCabaniaId",
                table: "Cabania",
                column: "TipoCabaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_CabaniaId",
                table: "Mantenimiento",
                column: "CabaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_descripcion_Value",
                table: "Mantenimiento",
                column: "descripcion_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parametro_Nombre",
                table: "Parametro",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoCabania_Descripcion_Value",
                table: "TipoCabania",
                column: "Descripcion_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoCabania_Nombre",
                table: "TipoCabania",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_email",
                table: "Usuario",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mantenimiento");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cabania");

            migrationBuilder.DropTable(
                name: "TipoCabania");
        }
    }
}
