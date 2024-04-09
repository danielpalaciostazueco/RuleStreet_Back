using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RuleStreet.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudadano",
                columns: table => new
                {
                    IdCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: true),
                    NumeroCuentaBancaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPoli = table.Column<bool>(type: "bit", nullable: true),
                    IsBusquedaYCaptura = table.Column<bool>(type: "bit", nullable: true),
                    IsPeligroso = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudadano", x => x.IdCiudadano);
                });

            migrationBuilder.CreateTable(
                name: "CodigoPenal",
                columns: table => new
                {
                    IdCodigoPenal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Articulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sentencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoPenal", x => x.IdCodigoPenal);
                });

            migrationBuilder.CreateTable(
                name: "Policia",
                columns: table => new
                {
                    IdPolicia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCiudadano = table.Column<int>(type: "int", nullable: true),
                    Rango = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policia", x => x.IdPolicia);
                    table.ForeignKey(
                        name: "FK_Policia_Ciudadano_IdCiudadano",
                        column: x => x.IdCiudadano,
                        principalTable: "Ciudadano",
                        principalColumn: "IdCiudadano");
                });

            migrationBuilder.CreateTable(
                name: "Multa",
                columns: table => new
                {
                    IdMulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPolicia = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ArticuloPenal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pagada = table.Column<bool>(type: "bit", nullable: true),
                    IdCiudadano = table.Column<int>(type: "int", nullable: true),
                    CiudadanoIdCiudadano = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multa", x => x.IdMulta);
                    table.ForeignKey(
                        name: "FK_Multa_Ciudadano_CiudadanoIdCiudadano",
                        column: x => x.CiudadanoIdCiudadano,
                        principalTable: "Ciudadano",
                        principalColumn: "IdCiudadano");
                    table.ForeignKey(
                        name: "FK_Multa_Policia_IdPolicia",
                        column: x => x.IdPolicia,
                        principalTable: "Policia",
                        principalColumn: "IdPolicia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ciudadano",
                columns: new[] { "IdCiudadano", "Apellidos", "Direccion", "Dni", "FechaNacimiento", "Genero", "IsBusquedaYCaptura", "IsPeligroso", "IsPoli", "Nacionalidad", "Nombre", "NumeroCuentaBancaria", "NumeroTelefono" },
                values: new object[,]
                {
                    { 1, "Perez", "Calle Falsa 123", "12345678", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hombre", false, false, false, "Español", "Juan", "ES123456789", 123456789 },
                    { 2, "Gonzalez", "Calle Falsa 123", "87654321", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mujer", false, false, false, "Española", "Maria", "ES987654321", 987654321 }
                });

            migrationBuilder.InsertData(
                table: "CodigoPenal",
                columns: new[] { "IdCodigoPenal", "Articulo", "Descripcion", "Precio", "Sentencia" },
                values: new object[,]
                {
                    { 1, "Art. 1.1", "Uso excesivo del claxón", 500m, "0 meses" },
                    { 2, "Art. 1.2", "Giro indebido", 300m, "0 meses" },
                    { 3, "Art. 1.3", "Circular en sentido contrario", 700m, "0 meses" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Multa_CiudadanoIdCiudadano",
                table: "Multa",
                column: "CiudadanoIdCiudadano");

            migrationBuilder.CreateIndex(
                name: "IX_Multa_IdPolicia",
                table: "Multa",
                column: "IdPolicia");

            migrationBuilder.CreateIndex(
                name: "IX_Policia_IdCiudadano",
                table: "Policia",
                column: "IdCiudadano");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodigoPenal");

            migrationBuilder.DropTable(
                name: "Multa");

            migrationBuilder.DropTable(
                name: "Policia");

            migrationBuilder.DropTable(
                name: "Ciudadano");
        }
    }
}
