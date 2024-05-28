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
                name: "Ayuntamiento",
                columns: table => new
                {
                    IdUsuarioAyuntamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayuntamiento", x => x.IdUsuarioAyuntamiento);
                });

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
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: true),
                    NumeroCuentaBancaria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPoli = table.Column<bool>(type: "bit", nullable: true),
                    IsBusquedaYCaptura = table.Column<bool>(type: "bit", nullable: true),
                    IsPeligroso = table.Column<bool>(type: "bit", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sentencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigoPenal", x => x.IdCodigoPenal);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    IdEventos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.IdEventos);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.IdPermiso);
                });

            migrationBuilder.CreateTable(
                name: "Rango",
                columns: table => new
                {
                    IdRango = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<int>(type: "int", nullable: true),
                    isLocal = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rango", x => x.IdRango);
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
                    EnColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Policia",
                columns: table => new
                {
                    IdPolicia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCiudadano = table.Column<int>(type: "int", nullable: true),
                    IdRango = table.Column<int>(type: "int", nullable: true),
                    NumeroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policia", x => x.IdPolicia);
                    table.ForeignKey(
                        name: "FK_Policia_Ciudadano_IdCiudadano",
                        column: x => x.IdCiudadano,
                        principalTable: "Ciudadano",
                        principalColumn: "IdCiudadano");
                    table.ForeignKey(
                        name: "FK_Policia_Rango_IdRango",
                        column: x => x.IdRango,
                        principalTable: "Rango",
                        principalColumn: "IdRango");
                });

            migrationBuilder.CreateTable(
                name: "RangoPermiso",
                columns: table => new
                {
                    IdRango = table.Column<int>(type: "int", nullable: false),
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangoPermiso", x => new { x.IdRango, x.IdPermiso });
                    table.ForeignKey(
                        name: "FK_RangoPermiso_Permiso_IdPermiso",
                        column: x => x.IdPermiso,
                        principalTable: "Permiso",
                        principalColumn: "IdPermiso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RangoPermiso_Rango_IdRango",
                        column: x => x.IdRango,
                        principalTable: "Rango",
                        principalColumn: "IdRango",
                        onDelete: ReferentialAction.Cascade);
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
                    IdCodigoPenal = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Multa_CodigoPenal_IdCodigoPenal",
                        column: x => x.IdCodigoPenal,
                        principalTable: "CodigoPenal",
                        principalColumn: "IdCodigoPenal",
                        onDelete: ReferentialAction.Cascade);
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                table: "Ayuntamiento",
                columns: new[] { "IdUsuarioAyuntamiento", "Contrasena", "Dni" },
                values: new object[,]
                {
                    { 1, "1234", "12345678" },
                    { 2, "1234", "87654321" }
                });

            migrationBuilder.InsertData(
                table: "Ciudadano",
                columns: new[] { "IdCiudadano", "Address", "Apellidos", "Direccion", "Dni", "FechaNacimiento", "Gender", "Genero", "IdUsuario", "ImagenUrl", "IsBusquedaYCaptura", "IsPeligroso", "IsPoli", "Nacionalidad", "Nationality", "Nombre", "NumeroCuentaBancaria", "NumeroTelefono" },
                values: new object[,]
                {
                    { 1, "Fake Street 123", "Gimenez Garulo", "Calle Falsa 123", "12345678A", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Hombre", null, "https://lh3.googleusercontent.com/a-/ALV-UjW8BqiphgAP2RarwrIgqXMdH0Y4XWQgicOFG6g5lTSoqlharjkl=s75-c", false, false, false, "Española", "Spanish", "Alejadro", "ES123456789", 123456789 },
                    { 2, null, "Llorente Pinzon", "Calle Falsa 123", "12345678B", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mujer", null, "https://lh3.googleusercontent.com/a-/ALV-UjXq4SaB_ODyUUzUulLF9MsBbfp2kyQ8dJQ6-k96AxVcHx8PtnV2=s75-c", false, false, false, "Española", null, "Vanessa", "ES987654321", 987654321 },
                    { 3, null, "Crespo", "Calle Falsa 123", "12345678C", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mujer", null, "https://lh3.googleusercontent.com/a-/ALV-UjXNudiq8hrsLIIP4y9gHaPvdatUtONrCGpmKvYBTePbSFleNrs=s75-c", false, false, false, "Española", null, "Maria", "ES987654321", 987654321 },
                    { 4, null, "Hierro Amon", "Calle Falsa 123", "12345678D", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hombre", null, "https://lh3.googleusercontent.com/a/ACg8ocL5B2wDSyuywLri2wQOKXk9DuqWrYHjH0iShHT3uwZUSfnIqA=s32-c-mo", false, false, false, "Española", null, "Oliver", "ES987654321", 987654321 },
                    { 5, null, "Pardos Gotor", "Calle Falsa 123", "12345678E", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hombre", null, "https://lh3.googleusercontent.com/a-/ALV-UjXzV-jm0U5kV0lccfpkdR_NeIDpJRa3av9cA6fBJySmh8B-nsfU=s75-c", false, false, false, "Española", null, "Santos", "ES987654321", 987654321 },
                    { 6, null, "Higelmo Martinez", "Calle Falsa 123", "12345678F", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mujer", null, "https://lh3.googleusercontent.com/a-/ALV-UjWbaN_SMJT8GbltNzC69AJquU6hlO2JoVkXGBjpptldvZNclstX=s75-c", false, false, false, "Española", null, "Eva Maria", "ES987654321", 987654321 },
                    { 7, null, "Guardingo De La Riva", "Calle Falsa 123", "12345678G", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mujer", null, "https://lh3.googleusercontent.com/a-/ALV-UjW6IGDJ5YeNx1nJ1XnWsYBo15QF_E8JrIA9mMZ2uq9xQTI0XoY=s75-c", false, false, false, "Española", null, "Silvia", "ES987654321", 987654321 },
                    { 8, null, "Ruiz Lite", "Calle Falsa 123", "12345678H", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hombre", null, "https://lh3.googleusercontent.com/a-/ALV-UjV2lVzVGBSS8cX-TisA7tu5Guwo9KVK9aAalgSJzmqRZw629sc=s32-c", false, false, false, "Española", null, "Joaquin", "ES987654321", 987654321 }
                });

            migrationBuilder.InsertData(
                table: "CodigoPenal",
                columns: new[] { "IdCodigoPenal", "Article", "Articulo", "Descripcion", "Description", "Precio", "Sentencia" },
                values: new object[,]
                {
                    { 1, null, "Art. 1.1", "Uso excesivo del claxón", "Excessive use of the horn", 500m, "0 meses" },
                    { 2, null, "Art. 1.2", "Giro indebido", "Improper turn", 300m, "0 meses" },
                    { 3, null, "Art. 1.3", "Circular en sentido contrario", "Driving against traffic", 700m, "0 meses" },
                    { 4, null, "Art. 1.4", "Estacionar en zonas no habitadas y obstruir la circulación", "Parking in non-habitable areas and obstructing traffic", 500m, "0 meses" },
                    { 5, null, "Art. 1.5", "Ignorar señales de tránsito", "Ignoring traffic signs", 500m, "0 meses" },
                    { 6, null, "Art. 1.6", "Saltarse un semáforo", "Running a red light", 450m, "0 meses" },
                    { 7, null, "Art. 1.7", "No ceder el paso a vehículos de emergencia", "Not yielding to emergency vehicles", 550m, "0 meses" },
                    { 8, null, "Art. 1.8", "Realizar adelantamiento indebido", "Improper overtaking", 350m, "0 meses" },
                    { 9, null, "Art. 1.9", "Circular marcha atrás", "Driving in reverse", 800m, "0 meses" },
                    { 10, null, "Art. 1.10", "Ignorar señales de los agentes que regulan la circulacion", "Ignoring signals from traffic regulators", 500m, "0 meses" },
                    { 11, null, "Art. 1.11", "Saltarse / omitir un control de trafico", "Skipping/omitting a traffic control", 500m, "0 meses" },
                    { 12, null, "Art. 1.12", "Conducir un vehiculo en malas condiciones", "Driving a vehicle in poor condition", 1000m, "0 meses" },
                    { 13, null, "Art. 1.13", "Exceso de velocidad en vias urbanas", "Speeding in urban areas", 800m, "5 meses" },
                    { 14, null, "Art. 1.14", "Condución temeraria", "Reckless driving", 1500m, "10 meses" },
                    { 15, null, "Art. 1.15", "Exceso de velocidad en vias secundarias", "Speeding in secondary roads", 1000m, "10 meses" },
                    { 16, null, "Art. 1.16", "Conducir bajo los efectos de drogas/alcohol", "Driving under the influence of drugs/alcohol", 1500m, "10 meses" },
                    { 17, null, "Art. 1.17", "Circular por zonas no habilitadas para ello", "Driving in non-authorized areas", 1000m, "0 meses" },
                    { 18, null, "Art. 1.18", "Circular sin casco para motocicleta", "Riding without a helmet for motorcycles", 500m, "0 meses" },
                    { 19, null, "Art. 1.18.1", "Circular sin licencia de conducir", "Driving without a license", 550m, "0 meses" },
                    { 20, null, "Art. 2.1", "Alteración del orden público", "Disturbing public order", 3500m, "0 meses" },
                    { 21, null, "Art. 2.2", "Racismo", "Racism", 5000m, "0 meses" },
                    { 22, null, "Art. 2.3", "Faltas de respeto a otro civil", "Disrespecting another civilian", 2500m, "0 meses" },
                    { 23, null, "Art. 2.4", "Dañar mobiliario urbano", "Damaging urban furniture", 1700m, "0 meses" },
                    { 24, null, "Art. 2.5", "Acoso psicológico", "Psychological harassment", 6000m, "5 meses" },
                    { 25, null, "Art. 2.6", "Amenaza de muerte a un civil", "Threatening to kill a civilian", 2000m, "5 meses" },
                    { 26, null, "Art. 2.7", "Suplantación de identidad", "Identity theft", 6000m, "0 meses" },
                    { 27, null, "Art. 2.8", "Circular por la via pública con el rostro oculto", "Concealing face in public", 1000m, "5 meses" },
                    { 28, null, "Art. 2.9", "Circular en la via pública desnudo o semi-desnudo", "Being naked or semi-naked in public", 1200m, "0 meses" },
                    { 29, null, "Art. 2.10", "Circular en la via pública sin camiseta", "Being shirtless in public", 120m, "0 meses" },
                    { 30, null, "Art. 2.11", "Acoso sexual", "Sexual harassment", 30000m, "100 meses" },
                    { 31, null, "Art. 2.12", "Violar una orden de alejamiento con sentencia firme", "Violating a restraining order with a firm sentence", 25000m, "80 meses" },
                    { 32, null, "Art. 2.13", "Negativa a identificarse", "Refusing to identify oneself", 1000m, "7 meses" },
                    { 33, null, "Art. 2.14", "Obstrucción a la justicia", "Obstruction of justice", 2500m, "10 meses" },
                    { 34, null, "Art. 3.1", "Posesion de estupefacientes (marihuana) 210/unidad (a partir de 2 unidades)", "Possession of narcotics (marijuana) 210/unit (from 2 units)", 210m, "7 meses" },
                    { 35, null, "Art. 3.2", "Consumo de marihuana en vía pública", "Consumption of marijuana in public", 350m, "10 meses" },
                    { 36, null, "Art. 3.3", "Posesion de estupefacientes (Cocaína/Mentafetamina) 650/unidad (a partir de 2 unidades)", "Possession of narcotics (cocaine/methamphetamine) 650/unit (from 2 units)", 650m, "7 meses" },
                    { 37, null, "Art. 3.4", "Se considera trafico de drogas a cualquier individuo o grupo de personas que se vean vendiendo estupefacientes en flagante delito. Multa de 450 por cada delito flagante de venta de cocaina. Se requisara todo el dinero que lleve el sujeto.", "Drug trafficking: Any individual or group caught selling narcotics flagrantly. Fine of 450 for each flagrant sale of cocaine. All money on the subject will be confiscated.", 450m, "10 meses" },
                    { 38, null, "Art. 3.5", "Se considera trafico de drogas a cualquier individuo o grupo de personas que se vean vendiendo estupefacientes en flagante delito. Multa de 650 por cada delito flagante de venta de meta. Se requisara todo el dinero que lleve el sujeto.", "Drug trafficking: Any individual or group caught selling narcotics flagrantly. Fine of 650 for each flagrant sale of meth. All money on the subject will be confiscated.", 650m, "10 meses" },
                    { 39, null, "Art. 4.1", "Queda totalmente prohibida por parte de los civiles portar una pistolera como atuendo de modo decorativo", "It is completely prohibited for civilians to wear a gun holster as a decorative outfit.", 1500m, "0 meses" },
                    { 40, null, "Art. 4.2", "Posesion de arma blanca: son considerados como tal, aquellas armas de filo cortante. Armas blancas susceptibles de ser usadas como arma ilegal: Cuchillo, Bate de beisbol, Palo de golf, Botella rota, Navaja, Machete", "Possession of a blade weapon: considered as such, those cutting edge weapons. Bladed weapons susceptible to be used as an illegal weapon: Knife, Baseball bat, Golf club, Broken bottle, Razor, Machete", 2500m, "0 meses" },
                    { 41, null, "Art. 4.3", "Portar pistola de baja calibre (arma de fuego)", "Carrying a small caliber pistol (firearm)", 10000m, "10 meses" },
                    { 42, null, "Art. 4.4", "Portar armas automaticas de baja calibre/medio", "Carrying low/medium caliber automatic weapons", 24000m, "10 meses" },
                    { 43, null, "Art. 4.5", "Portar armas automaticas de alto calibre", "Carrying high caliber automatic weapons", 40000m, "15 meses" },
                    { 44, null, "Art. 4.6", "Trafico de armas", "Arms trafficking", 30000m, "25 meses" },
                    { 45, null, "Art. 4.7", "Atentado terrorista", "Terrorist attack", 100000m, "250 meses" },
                    { 46, null, "Art. 4.8", "Atentar contra la vida o integridad fisica de varios personas y/o funcionarios publicos mediante la organizacion armada de varios individuos", "Attempting against the life or physical integrity of several people and/or public officials through the armed organization of several individuals", 100000m, "350 meses" },
                    { 47, null, "Art. 5.1", "Agresion a otro individuo", "Assaulting another individual", 3000m, "10 meses" },
                    { 48, null, "Art. 5.2", "Intento de agresion a civil", "Attempted assault on a civilian", 1500m, "5 meses" },
                    { 49, null, "Art. 5.3", "Intento de secuestro", "Attempted kidnapping", 2400m, "15 meses" },
                    { 50, null, "Art. 5.4", "Secuestro a un individuo", "Kidnapping an individual", 3500m, "15 meses" },
                    { 51, null, "Art. 5.5", "Intento de homicidio a un civil sin el uso de armas", "Attempted homicide on a civilian without the use of weapons", 4000m, "10 meses" },
                    { 52, null, "Art. 5.6", "Intento de homicidio a un civil con uso de armas de cualquier indole", "Attempted homicide on a civilian with the use of any kind of weapon", 6000m, "20 meses" },
                    { 53, null, "Art. 5.7", "Intento de homicidio a multiples sin el uso de armas", "Attempted homicide on multiple civilians without the use of weapons", 5000m, "15 meses" },
                    { 54, null, "Art. 5.8", "Intento de homicidio a multiples civiles con uso de armas de cualquier indole", "Attempted homicide on multiple civilians with the use of any kind of weapon", 7500m, "15 meses" },
                    { 55, null, "Art. 6.1", "Amenazas, desobedencia e insultos: Tras la primera amision de la orden de un funcionario de policia, se le podra acumular al reo el monta econonico despues del primer aviso por cada falta de respeto o desacato.", "Threats, disobedience, and insults: After the first omission of a police officer's order, the economic amount may be accumulated for each disrespect or disobedience after the first warning.", 300m, "0 meses" },
                    { 56, null, "Art. 6.2", "Insultar a un funcionario publico.", "Insulting a public official.", 1700m, "5 meses" },
                    { 57, null, "Art. 6.3", "Agresión o amenaza de muerte a un funcionario.", "Assault or death threat to an official.", 3400m, "5 meses" },
                    { 58, null, "Art. 6.4", "Desacato", "Contempt", 2000m, "10 meses" },
                    { 59, null, "Art. 6.5", "Huir de la justicia", "Fleeing from justice", 1500m, "10 meses" },
                    { 60, null, "Art. 6.6", "Usurpacion de funciones publicas", "Usurpation of public functions", 10000m, "15 meses" },
                    { 61, null, "Art. 6.7", "Falso testimonio", "False testimony", 2000m, "5 meses" },
                    { 62, null, "Art. 6.8", "Usurpación de funcionarios públicos", "Usurpation of public officials", 10000m, "15 meses" },
                    { 63, null, "Art. 6.9", "Secuestro a un funcionario", "Kidnapping of an official", 8000m, "10 meses" },
                    { 64, null, "Art. 6.10", "Amenazar a un funcionario público a mano armada", "Threatening a public official at gunpoint", 3500m, "10 meses" },
                    { 65, null, "Art. 6.11", "Intento de homicidio a un funcionario público", "Attempted homicide of a public official", 5500m, "15 meses" },
                    { 66, null, "Art. 6.12", "Homicidio a un funcionario", "Homicide of an official", 9000m, "20 meses" },
                    { 67, null, "Art. 6.13", "Homicidio a diferentes funcionarios", "Homicide of different officials", 12500m, "50 meses" },
                    { 68, null, "Art. 6.14", "Robo de secretos del estado", "Theft of state secrets", 0m, "5000 meses" },
                    { 69, null, "Art. 6.15", "Sera acusado de denuncia falsa aquel que registre una denucia ante el cuerpo policial a sabiendas de su falsedad", "Those who file a false complaint with the police knowing its falsehood will be accused", 2500m, "10 meses" },
                    { 70, null, "Art. 6.16", "Actos de corrupción por parte de un agente", "Acts of corruption by an agent", 0m, "5000 meses" },
                    { 71, null, "Art. 7.1", "Robo de vehículo", "Vehicle theft", 2000m, "6 meses" },
                    { 72, null, "Art. 7.2", "Robo con intimidación a un civil", "Robbery with intimidation to a civilian", 3400m, "8 meses" },
                    { 73, null, "Art. 7.3", "Robo con violencia a un civil", "Robbery with violence to a civilian", 2600m, "10 meses" },
                    { 74, null, "Art. 7.4", "Hurto menor", "Petty theft", 1500m, "5 meses" },
                    { 75, null, "Art. 7.5", "Robar pertenencias que se hallen en el interior de un vehículo de vía urbana o propiedad privada", "Stealing belongings inside a vehicle in an urban area or private property", 2150m, "7 meses" },
                    { 76, null, "Art. 8.1", "Celebración de manifestaciones en lugares de tránsito público sin haber sido autorizados", "Holding demonstrations in public transit places without authorization", 1000m, "0 meses" },
                    { 77, null, "Art. 8.2", "Cometer actos de vandalismo", "Commit acts of vandalism", 1500m, "0 meses" },
                    { 78, null, "Art. 8.3", "Hurto de un civil sin importar las posesiones robadas", "Theft from a civilian regardless of stolen possessions", 3500m, "10 meses" },
                    { 79, null, "Art. 8.4", "Obstaculizar el desempeño y desarrollo de las funciones públicas y servicios de emergencia", "Obstructing the performance and development of public functions and emergency services", 2300m, "0 meses" },
                    { 80, null, "Art. 8.5", "Negarse a disolver una reunión o manifestación tras haber sido previamente advertido por un funcionario público", "Refusing to disband a meeting or demonstration after being previously warned by a public official", 1600m, "5 meses" },
                    { 81, null, "Art. 8.6", "Negarse a identificarse o aportar datos falsos que dificulten la acción policial", "Refusing to identify oneself or provide false information that hinders police action", 1500m, "5 meses" },
                    { 82, null, "Art. 8.7", "Amenazar a un funcionario público a mano armada", "Threatening an official with a firearm", 3500m, "10 meses" },
                    { 83, null, "Art. 8.8", "Exhibicionismo: El que realice actos de exhibicionismo delante de personas causándoles un perjuicio", "Exhibitionism: Anyone who engages in exhibitionism in front of people causing them harm", 5500m, "10 meses" },
                    { 84, null, "Art. 8.9", "Será acusado de extorsión aquel que, con intención de beneficiarse, obligue a otro con violencia o intimidación a realizar un acto que le perjudique económicamente", "Anyone who, with the intention of benefiting, forces another person with violence or intimidation to perform an act that harms them economically, will be accused of extortion", 3000m, "15 meses" },
                    { 85, null, "Art. 8.10", "Será acusado de injuria aquel que diga de manera pública hechos falsos que humillen a otra persona", "Anyone who publicly states false facts that humiliate another person will be accused of defamation", 1200m, "7 meses" },
                    { 86, null, "Art. 8.11", "Violación de la intimidad aquel que acceda a cualquier tipo de propiedad o dispositivo de otro, sea digital o analógico. El artículo excluye a los funcionarios públicos por desempeño de sus labores de investigación", "Violation of privacy: Anyone who accesses any type of property or device of another, whether digital or analog. The article excludes public officials in the performance of their investigative duties", 2400m, "7 meses" },
                    { 87, null, "Art. 8.12", "Será acusado de tortura aquel que realice actos degradantes, ofensivos, dañinos o de similar a una persona", "Anyone who performs degrading, offensive, harmful, or similar acts to a person will be accused of torture", 5600m, "15 meses" },
                    { 88, null, "Art. 8.13", "Negarse a la identificación ante un funcionario público", "Refusing to identify oneself to a public official", 1500m, "0 meses" }
                });

            migrationBuilder.InsertData(
                table: "Permiso",
                columns: new[] { "IdPermiso", "Name", "Nombre" },
                values: new object[,]
                {
                    { 1, "Add police", "Añadir policia" },
                    { 2, "Remove police", "Quitar policia" },
                    { 3, "Modify police", "Modificar policia" },
                    { 4, "Delete fine", "Borrar multa" },
                    { 5, "Create fine", "Crear multa" },
                    { 6, "Delete complaint", "Borrar denuncia" },
                    { 7, "Create complaint", "Crear denuncia" },
                    { 8, "Modify complaint", "Modificar denuncia" },
                    { 9, "Delete note", "Eliminar nota" },
                    { 10, "Create note", "Crear nota" },
                    { 11, "Modify note", "Modificar nota" },
                    { 12, "Create event", "Crear evento" },
                    { 13, "Delete event", "Eliminar evento" }
                });

            migrationBuilder.InsertData(
                table: "Rango",
                columns: new[] { "IdRango", "Name", "Nombre", "Salario", "isLocal" },
                values: new object[,]
                {
                    { 1, "Practices ", "Practicas", 1071, true },
                    { 2, "Agent", "Agente", 1330, true },
                    { 3, "Official I", "Oficial I", 1412, true },
                    { 4, "Official II", "Oficial II", 1483, true },
                    { 5, "Official III", "Oficial III", 1555, true },
                    { 6, "Sub-inspector", "Subinspector", 1674, true },
                    { 7, "Inspector", "Inspector", 1765, true },
                    { 8, "Chief inspector", "Inspector Jefe", 1881, true },
                    { 9, "Mayor", "Intendente", 2028, true },
                    { 10, "Super mayor", "Superintendente", 2142, true }
                });

            migrationBuilder.InsertData(
                table: "RangoPermiso",
                columns: new[] { "IdPermiso", "IdRango" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 7, 1 },
                    { 5, 2 },
                    { 7, 2 },
                    { 10, 2 },
                    { 5, 3 },
                    { 7, 3 },
                    { 10, 3 },
                    { 11, 3 },
                    { 5, 4 },
                    { 7, 4 },
                    { 10, 4 },
                    { 11, 4 },
                    { 5, 5 },
                    { 7, 5 },
                    { 10, 5 },
                    { 11, 5 },
                    { 5, 6 },
                    { 7, 6 },
                    { 8, 6 },
                    { 10, 6 },
                    { 11, 6 },
                    { 5, 7 },
                    { 7, 7 },
                    { 8, 7 },
                    { 9, 7 },
                    { 10, 7 },
                    { 11, 7 },
                    { 3, 8 },
                    { 5, 8 },
                    { 7, 8 },
                    { 8, 8 },
                    { 9, 8 },
                    { 10, 8 },
                    { 11, 8 },
                    { 1, 9 },
                    { 3, 9 },
                    { 4, 9 },
                    { 5, 9 },
                    { 6, 9 },
                    { 7, 9 },
                    { 8, 9 },
                    { 9, 9 },
                    { 10, 9 },
                    { 11, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 10 },
                    { 4, 10 },
                    { 5, 10 },
                    { 6, 10 },
                    { 7, 10 },
                    { 8, 10 },
                    { 9, 10 },
                    { 10, 10 },
                    { 11, 10 },
                    { 12, 10 },
                    { 13, 10 }
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
                name: "IX_Multa_IdCodigoPenal",
                table: "Multa",
                column: "IdCodigoPenal");

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
                name: "IX_Policia_IdRango",
                table: "Policia",
                column: "IdRango");

            migrationBuilder.CreateIndex(
                name: "IX_RangoPermiso_IdPermiso",
                table: "RangoPermiso",
                column: "IdPermiso");

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
                name: "Ayuntamiento");

            migrationBuilder.DropTable(
                name: "Denuncia");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Multa");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "RangoPermiso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "CodigoPenal");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Policia");

            migrationBuilder.DropTable(
                name: "Ciudadano");

            migrationBuilder.DropTable(
                name: "Rango");
        }
    }
}
