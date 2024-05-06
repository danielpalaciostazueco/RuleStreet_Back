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
                    IsPeligroso = table.Column<bool>(type: "bit", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
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
                name: "Permiso",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRango = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.IdPermiso);
                });

            migrationBuilder.CreateTable(
                name: "Policia",
                columns: table => new
                {
                    IdPolicia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCiudadano = table.Column<int>(type: "int", nullable: true),
                    Rango = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Auditoria",
                columns: table => new
                {
                    IdAuditoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdPolicia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.IdAuditoria);
                    table.ForeignKey(
                        name: "FK_Auditoria_Policia_IdPolicia",
                        column: x => x.IdPolicia,
                        principalTable: "Policia",
                        principalColumn: "IdPolicia");
                });

            migrationBuilder.CreateTable(
                name: "Denuncia",
                columns: table => new
                {
                    IdDenuncia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdPolicia = table.Column<int>(type: "int", nullable: true),
                    IdCiudadano = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncia", x => x.IdDenuncia);
                    table.ForeignKey(
                        name: "FK_Denuncia_Ciudadano_IdCiudadano",
                        column: x => x.IdCiudadano,
                        principalTable: "Ciudadano",
                        principalColumn: "IdCiudadano");
                    table.ForeignKey(
                        name: "FK_Denuncia_Policia_IdPolicia",
                        column: x => x.IdPolicia,
                        principalTable: "Policia",
                        principalColumn: "IdPolicia");
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
                    IdCiudadano = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multa", x => x.IdMulta);
                    table.ForeignKey(
                        name: "FK_Multa_Ciudadano_IdCiudadano",
                        column: x => x.IdCiudadano,
                        principalTable: "Ciudadano",
                        principalColumn: "IdCiudadano");
                    table.ForeignKey(
                        name: "FK_Multa_Policia_IdPolicia",
                        column: x => x.IdPolicia,
                        principalTable: "Policia",
                        principalColumn: "IdPolicia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    IdNota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdPolicia = table.Column<int>(type: "int", nullable: true),
                    IdCiudadano = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.IdNota);
                    table.ForeignKey(
                        name: "FK_Nota_Ciudadano_IdCiudadano",
                        column: x => x.IdCiudadano,
                        principalTable: "Ciudadano",
                        principalColumn: "IdCiudadano");
                    table.ForeignKey(
                        name: "FK_Nota_Policia_IdPolicia",
                        column: x => x.IdPolicia,
                        principalTable: "Policia",
                        principalColumn: "IdPolicia");
                });

            migrationBuilder.CreateTable(
                name: "Rango",
                columns: table => new
                {
                    IdRango = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPolicia = table.Column<int>(type: "int", nullable: true),
                    policiaIdPolicia = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<int>(type: "int", nullable: true),
                    isLocal = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rango", x => x.IdRango);
                    table.ForeignKey(
                        name: "FK_Rango_Policia_policiaIdPolicia",
                        column: x => x.policiaIdPolicia,
                        principalTable: "Policia",
                        principalColumn: "IdPolicia");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPolicia = table.Column<int>(type: "int", nullable: true),
                    policiaIdPolicia = table.Column<int>(type: "int", nullable: true),
                    IdCiudadano = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPolicia = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Ciudadano_IdCiudadano",
                        column: x => x.IdCiudadano,
                        principalTable: "Ciudadano",
                        principalColumn: "IdCiudadano");
                    table.ForeignKey(
                        name: "FK_Usuario_Policia_policiaIdPolicia",
                        column: x => x.policiaIdPolicia,
                        principalTable: "Policia",
                        principalColumn: "IdPolicia");
                });

            migrationBuilder.InsertData(
                table: "Ciudadano",
                columns: new[] { "IdCiudadano", "Apellidos", "Direccion", "Dni", "FechaNacimiento", "Genero", "IdUsuario", "IsBusquedaYCaptura", "IsPeligroso", "IsPoli", "Nacionalidad", "Nombre", "NumeroCuentaBancaria", "NumeroTelefono" },
                values: new object[,]
                {
                    { 1, "Perez", "Calle Falsa 123", "12345678", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hombre", null, false, false, false, "Español", "Juan", "ES123456789", 123456789 },
                    { 2, "Gonzalez", "Calle Falsa 123", "87654321", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mujer", null, false, false, false, "Española", "Maria", "ES987654321", 987654321 }
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
                    { 33, "Art. 2.14", "Obstrucción a la justicia", 2500m, "10 meses" },
                    { 34, "Art. 3.1", "Posesion de estupefacientes (marihuana) 210/unidad (a partir de 2 unidades)", 210m, "7 meses" },
                    { 35, "Art. 3.2", "Consumo de marihuana en vía pública", 350m, "10 meses" },
                    { 36, "Art. 3.3", "Posesion de estupefacientes (Cocaína/Mentafetamina) 650/unidad (a partir de 2 unidades)", 650m, "7 meses" },
                    { 37, "Art. 3.4", "Se considera trafico de drogas a cualquier individuo o grupo de personas que se vean vendiendo estupefacientes en flagante delito. Multa de 450 por cada delito flagante de venta de cocaina. Se requisara todo el dinero que lleve el sujeto.", 450m, "10 meses" },
                    { 38, "Art. 3.5", "Se considera trafico de drogas a cualquier individuo o grupo de personas que se vean vendiendo estupefacientes en flagante delito. Multa de 650 por cada delito flagante de venta de meta. Se requisara todo el dinero que lleve el sujeto.", 650m, "10 meses" },
                    { 39, "Art. 4.1", "Queda totalmente prohibida por parte de los civiles portar una pistolera como atuendo de modo decorativo", 1500m, "0 meses" },
                    { 40, "Art. 4.2", "Posesion de arma blanca: son considerados como tal, aquellas armas de filo cortante. Armas blancas susceptibles de ser usadas como arma ilegal: Cuchillo, Bate de beisbol, Palo de golf, Botella rota, Navaja, Machete", 2500m, "0 meses" },
                    { 41, "Art. 4.3", "Portar pistola de baja calibre (arma de fuego)", 10000m, "10 meses" },
                    { 42, "Art. 4.4", "Portar armas automaticas de baja calibre/medio", 24000m, "10 meses" },
                    { 43, "Art. 4.5", "Portar armas automaticas de alto calibre", 40000m, "15 meses" },
                    { 44, "Art. 4.6", "Trafico de armas", 30000m, "25 meses" },
                    { 45, "Art. 4.7", "Atentado terrorista", 100000m, "250 meses" },
                    { 46, "Art. 4.8", "Atentar contra la vida o integridad fisica de varios personas y/o funcionarios publicos mediante la organizacion armada de varios individuos", 100000m, "350 meses" },
                    { 47, "Art. 5.1", "Agresion a otro individuo", 3000m, "10 meses" },
                    { 48, "Art. 5.2", "Intento de agresion a civil", 1500m, "5 meses" },
                    { 49, "Art. 5.3", "Intento de secuestro", 2400m, "15 meses" },
                    { 50, "Art. 5.4", "Secuestro a un individuo", 3500m, "15 meses" },
                    { 51, "Art. 5.5", "Intento de homicidio a un civil sin el uso de armas", 4000m, "10 meses" },
                    { 52, "Art. 5.6", "Intento de homicidio a un civil con uso de armas de cualquier indole", 6000m, "20 meses" },
                    { 53, "Art. 5.7", "Intento de homicidio a multiples sin el uso de armas", 5000m, "15 meses" },
                    { 54, "Art. 5.8", "Intento de homicidio a multiples civiles con uso de armas de cualquier indole", 7500m, "15 meses" },
                    { 55, "Art. 6.1", "Amenazas, desobedencia e insultos: Tras la primera amision de la orden de un funcionario de policia, se le podra acumular al reo el monta econonico despues del primer aviso por cada falta de respeto o desacato.", 300m, "0 meses" },
                    { 56, "Art. 6.2", "Insultar a un funcionario publico.", 1700m, "5 meses" },
                    { 57, "Art. 6.3", "Agresión o amenaza de muerte a un funcionario.", 3400m, "5 meses" },
                    { 58, "Art. 6.4", "Desacato", 2000m, "10 meses" },
                    { 59, "Art. 6.5", "Huir de la justicia", 1500m, "10 meses" },
                    { 60, "Art. 6.6", "Usurpacion de funciones publicas", 10000m, "15 meses" },
                    { 61, "Art. 6.7", "Falso testimonio", 2000m, "5 meses" },
                    { 62, "Art. 6.8", "Usurpacion de funcionarios publicos", 10000m, "15 meses" },
                    { 63, "Art. 6.9", "Secuestro a un funcionario", 8000m, "10 meses" },
                    { 64, "Art. 6.10", "Amenazar a un funcionario publico a mano armada", 3500m, "10 meses" },
                    { 65, "Art. 6.11", "Intento de homicidio a un funcionario publico", 5500m, "15 meses" },
                    { 66, "Art. 6.12", "Homicidio a un funcionario", 9000m, "20 meses" },
                    { 67, "Art. 6.13", "Homicidio a diferentes funcionarios", 12500m, "50 meses" },
                    { 68, "Art. 6.14", "Robo de secretos del estado", 0m, "5000 meses" },
                    { 69, "Art. 6.15", "Sera acusado de denuncia falsa aquel que registre una denucia ante el cuerpo policial a sabiendas de su falsedad", 2500m, "10 meses" },
                    { 70, "Art. 6.16", "Actos de corrupcion por parte de un agente", 0m, "5000 meses" },
                    { 71, "Art. 7.1", "Robo de vehiculo", 2000m, "6 meses" },
                    { 72, "Art. 7.2", "Robo con intimidacion a un civil", 3400m, "8 meses" },
                    { 73, "Art. 7.3", "Robo con violencia a un civil", 2600m, "10 meses" },
                    { 74, "Art. 7.4", "Hurto menor", 1500m, "5 meses" },
                    { 75, "Art. 7.5", "Robar pertenencias que se hallen en el interior de un vehiculo de via urbana o propiedad privada", 2150m, "7 meses" },
                    { 76, "Art. 8.1", "Celebracion de manifestaciones en lugares de transito publico sin haber sido autorizados", 1000m, "0 meses" },
                    { 77, "Art. 8.2", "Cometer actos de vandalismo", 1500m, "0 meses" },
                    { 78, "Art. 8.3", "Hurto de un civil sin importar las posesiones robadas", 3500m, "10 meses" },
                    { 79, "Art. 8.4", "Obstaculizar el desempeño y desarrollo de las funciones publicas y servicios de emergencia", 2300m, "0 meses" },
                    { 80, "Art. 8.5", "Negarse a disolver una reunion o manifestacion tras haber sido previamente advertido por un funcionario publico", 1600m, "5 meses" },
                    { 81, "Art. 8.6", "Negarse a identificarse o aportar datos falsos que dificulten la accion policial", 1500m, "5 meses" },
                    { 82, "Art. 8.7", "Amenazar a un funcionario publico a mano armada", 3500m, "10 meses" },
                    { 83, "Art. 8.8", "Exhibicionismo: El que realice actos de exhibicionismo delante de personas causandoles un perjuicio", 5500m, "10 meses" },
                    { 84, "Art. 8.9", "Sera acusado de extorsion aquel que, con intencion de beneficiarse, obligue a otro con violencia o intimidacion a realizar un acto que le perjudique economicamente", 3000m, "15 meses" },
                    { 85, "Art. 8.10", "Sera acusado de injuria aquel que diga de manera publica hechos falsos que humillen a otra persona", 1200m, "7 meses" },
                    { 86, "Art. 8.11", "Violacion de la intimidad aquel que acceda a cualquier tipo de propiedad o dispositivo de otro, sea digital o analogico. El articulo excluye a los funcionarios publicos por desempeño de sus labores de investigacion", 2400m, "7 meses" },
                    { 87, "Art. 8.12", "Sera acusado de tortura aquel que realice actos degradantes, ofensivos, dañinos o de similar a una persona", 5600m, "15 meses" },
                    { 88, "Art. 8.13", "Negarse a la identificacion ante un funcionario publico", 1500m, "0 meses" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_IdPolicia",
                table: "Auditoria",
                column: "IdPolicia");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncia_IdCiudadano",
                table: "Denuncia",
                column: "IdCiudadano");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncia_IdPolicia",
                table: "Denuncia",
                column: "IdPolicia");

            migrationBuilder.CreateIndex(
                name: "IX_Multa_IdCiudadano",
                table: "Multa",
                column: "IdCiudadano");

            migrationBuilder.CreateIndex(
                name: "IX_Multa_IdPolicia",
                table: "Multa",
                column: "IdPolicia");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_IdCiudadano",
                table: "Nota",
                column: "IdCiudadano");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_IdPolicia",
                table: "Nota",
                column: "IdPolicia");

            migrationBuilder.CreateIndex(
                name: "IX_Policia_IdCiudadano",
                table: "Policia",
                column: "IdCiudadano");

            migrationBuilder.CreateIndex(
                name: "IX_Rango_policiaIdPolicia",
                table: "Rango",
                column: "policiaIdPolicia");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdCiudadano",
                table: "Usuario",
                column: "IdCiudadano",
                unique: true,
                filter: "[IdCiudadano] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_policiaIdPolicia",
                table: "Usuario",
                column: "policiaIdPolicia");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_IdCiudadano",
                table: "Vehiculo",
                column: "IdCiudadano");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "CodigoPenal");

            migrationBuilder.DropTable(
                name: "Denuncia");

            migrationBuilder.DropTable(
                name: "Multa");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Rango");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Policia");

            migrationBuilder.DropTable(
                name: "Ciudadano");
        }
    }
}
