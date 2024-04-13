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
                name: "Vehiculo",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCiudadano = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Ciudadano_IdCiudadano",
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
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ArticuloPenal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pagada = table.Column<bool>(type: "bit", nullable: true),
                    IdCiudadano = table.Column<int>(type: "int", nullable: true),
                    ciudadanoIdCiudadano = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multa", x => x.IdMulta);
                    table.ForeignKey(
                        name: "FK_Multa_Ciudadano_ciudadanoIdCiudadano",
                        column: x => x.ciudadanoIdCiudadano,
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
                    { 3, "Art. 1.3", "Circular en sentido contrario", 700m, "0 meses" },
                    { 4, "Art. 1.4", "Estacionar en zonas no habitadas y obstruir la circulación", 500m, "0 meses" },
                    { 5, "Art. 1.5", "Ignorar señales de tránsito", 500m, "0 meses" },
                    { 6, "Art. 1.6", "Saltarse un semáforo", 450m, "0 meses" },
                    { 7, "Art. 1.7", "No ceder el paso a vehículos de emergencia", 550m, "0 meses" },
                    { 8, "Art. 1.8", "Realizar adelantamiento indebido", 350m, "0 meses" },
                    { 9, "Art. 1.9", "Circular marcha atrás", 800m, "0 meses" },
                    { 10, "Art. 1.10", "Ignorar señales de los agentes que regulan la circulacion", 500m, "0 meses" },
                    { 11, "Art. 1.11", "Saltarse / omitir un control de trafico", 500m, "0 meses" },
                    { 12, "Art. 1.12", "Conducir un vehiculo en malas condiciones", 1000m, "0 meses" },
                    { 13, "Art. 1.13", "Exceso de velocidad en vias urbanas", 800m, "5 meses" },
                    { 14, "Art. 1.14", "Condución temeraria", 1500m, "10 meses" },
                    { 15, "Art. 1.15", "Exceso de velocidad en vias secundarias", 1000m, "10 meses" },
                    { 16, "Art. 1.16", "Conducir bajo los efectos de drogas/alcohol", 1500m, "10 meses" },
                    { 17, "Art. 1.17", "Circular por zonas no habilitadas para ello", 1000m, "0 meses" },
                    { 18, "Art. 1.18", "Circular sin casco para motocicleta", 500m, "0 meses" },
                    { 19, "Art. 1.18.1", "Circular sin licencia de conducir", 550m, "0 meses" },
                    { 20, "Art. 2.1", "Alteración del orden público", 3500m, "0 meses" },
                    { 21, "Art. 2.2", "Racismo", 5000m, "0 meses" },
                    { 22, "Art. 2.3", "Faltas de respeto a otro civil", 2500m, "0 meses" },
                    { 23, "Art. 2.4", "Dañar mobiliario urbano", 1700m, "0 meses" },
                    { 24, "Art. 2.5", "Acoso psicológico", 6000m, "5 meses" },
                    { 25, "Art. 2.6", "Amenaza de muerte a un civil", 2000m, "5 meses" },
                    { 26, "Art. 2.7", "Suplantación de identidad", 6000m, "0 meses" },
                    { 27, "Art. 2.8", "Circular por la via pública con el rostro oculto", 1000m, "5 meses" },
                    { 28, "Art. 2.9", "Circular en la via pública desnudo o semi-desnudo", 1200m, "0 meses" },
                    { 29, "Art. 2.10", "Circular en la via pública sin camiseta", 120m, "0 meses" },
                    { 30, "Art. 2.11", "Acoso sexual", 30000m, "100 meses" },
                    { 31, "Art. 2.12", "Violar una orden de alejamiento con sentencia firme", 25000m, "80 meses" },
                    { 32, "Art. 2.13", "Negativa a identificarse", 1000m, "7 meses" },
                    { 33, "Art. 2.14", "Obstrucción a la justicia", 2500m, "10 meses" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Multa_ciudadanoIdCiudadano",
                table: "Multa",
                column: "ciudadanoIdCiudadano");

            migrationBuilder.CreateIndex(
                name: "IX_Multa_IdPolicia",
                table: "Multa",
                column: "IdPolicia");

            migrationBuilder.CreateIndex(
                name: "IX_Policia_IdCiudadano",
                table: "Policia",
                column: "IdCiudadano");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_IdCiudadano",
                table: "Vehiculo",
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
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Policia");

            migrationBuilder.DropTable(
                name: "Ciudadano");
        }
    }
}
