using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
namespace RuleStreet.Data
{
    public class RuleStreetAppContext : DbContext
    {
        public RuleStreetAppContext(DbContextOptions<RuleStreetAppContext> options)
            : base(options)
        {
        }

        public DbSet<Ciudadano> Ciudadano { get; set; }
        public DbSet<Policia> Policia { get; set; }
        public DbSet<Multa> Multa { get; set; }
        public DbSet<CodigoPenal> CodigoPenal { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<Rango> Rango { get; set; }
        public DbSet<RangoPermiso> RangoPermiso { get; set; }
        public DbSet<Denuncia> Denuncia { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Ayuntamiento> Ayuntamiento { get; set; }
        public DbSet<Evento> Evento { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RangoPermiso>()
                   .HasKey(rp => new { rp.IdRango, rp.IdPermiso });

            modelBuilder.Entity<RangoPermiso>()
                .HasOne(rp => rp.Rango)
                .WithMany(r => r.RangosPermisos)
                .HasForeignKey(rp => rp.IdRango);

            modelBuilder.Entity<RangoPermiso>()
                .HasOne(rp => rp.Permiso)
                .WithMany(p => p.RangosPermisos)
                .HasForeignKey(rp => rp.IdPermiso);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Ciudadano)
                .WithMany(c => c.Vehiculos)
                .HasForeignKey(v => v.IdCiudadano);

            modelBuilder.Entity<Multa>()
                .HasOne(m => m.CodigoPenal)
                .WithMany(c => c.Multas)
                .HasForeignKey(m => m.IdCodigoPenal);

            modelBuilder.Entity<CodigoPenal>()
                .HasMany(c => c.Multas)
                .WithOne(m => m.CodigoPenal)
                .HasForeignKey(m => m.IdCodigoPenal);

            modelBuilder.Entity<Auditoria>()
                    .HasOne(a => a.Policia)
                    .WithMany()
                    .HasForeignKey(a => a.IdPolicia);

            modelBuilder.Entity<Denuncia>(entity =>
                {
                    entity.HasKey(d => d.IdDenuncia);
                    entity.HasOne(d => d.Policia)
                    .WithMany()
                    .HasForeignKey(d => d.IdPolicia);
                    entity.HasOne(d => d.Ciudadano)
                    .WithMany()
                    .HasForeignKey(d => d.IdCiudadano);

                });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasKey(d => d.IdNota);
                entity.HasOne(d => d.policia)
                .WithMany()
                .HasForeignKey(d => d.IdPolicia);
                entity.HasOne(d => d.ciudadano)
                .WithMany()
                .HasForeignKey(d => d.IdCiudadano);
            });

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Ciudadano)
                .WithOne(c => c.Usuario)
                .HasForeignKey<Usuario>(u => u.IdCiudadano);

            modelBuilder.Entity<Ciudadano>().HasData(
                new Ciudadano
                {
                    IdCiudadano = 1,
                    Nombre = "Alejadro",
                    Apellidos = "Gimenez Garulo",
                    Dni = "12345678A",
                    Genero = "Hombre",
                    Gender = "Male",
                    Nacionalidad = "Española",
                    Nationality = "Spanish",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    Direccion = "Calle Falsa 123",
                    Address = "Fake Street 123",
                    NumeroTelefono = 123456789,
                    NumeroCuentaBancaria = "ES123456789",
                    IsPoli = false,
                    IsBusquedaYCaptura = false,
                    IsPeligroso = false,
                    ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjW8BqiphgAP2RarwrIgqXMdH0Y4XWQgicOFG6g5lTSoqlharjkl=s75-c"
                },
                new Ciudadano
                {
                    IdCiudadano = 2,
                    Nombre = "Vanessa",
                    Apellidos = "Llorente Pinzon",
                    Dni = "12345678B",
                    Genero = "Mujer",
                    Nacionalidad = "Española",
                    FechaNacimiento = new DateTime(1995, 1, 1),
                    Direccion = "Calle Falsa 123",
                    NumeroTelefono = 987654321,
                    NumeroCuentaBancaria = "ES987654321",
                    IsPoli = false,
                    IsBusquedaYCaptura = false,
                    IsPeligroso = false,
                    ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjXq4SaB_ODyUUzUulLF9MsBbfp2kyQ8dJQ6-k96AxVcHx8PtnV2=s75-c"

                },
                new Ciudadano
                {
                    IdCiudadano = 3,
                    Nombre = "Maria",
                    Apellidos = "Crespo",
                    Dni = "12345678C",
                    Genero = "Mujer",
                    Nacionalidad = "Española",
                    FechaNacimiento = new DateTime(1995, 1, 1),
                    Direccion = "Calle Falsa 123",
                    NumeroTelefono = 987654321,
                    NumeroCuentaBancaria = "ES987654321",
                    IsPoli = false,
                    IsBusquedaYCaptura = false,
                    IsPeligroso = false,
                    ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjXNudiq8hrsLIIP4y9gHaPvdatUtONrCGpmKvYBTePbSFleNrs=s75-c"
                },
                new Ciudadano
                {
                    IdCiudadano = 4,
                    Nombre = "Oliver",
                    Apellidos = "Hierro Amon",
                    Dni = "12345678D",
                    Genero = "Hombre",
                    Nacionalidad = "Española",
                    FechaNacimiento = new DateTime(1995, 1, 1),
                    Direccion = "Calle Falsa 123",
                    NumeroTelefono = 987654321,
                    NumeroCuentaBancaria = "ES987654321",
                    IsPoli = false,
                    IsBusquedaYCaptura = false,
                    IsPeligroso = false,
                    ImagenUrl = "https://lh3.googleusercontent.com/a/ACg8ocL5B2wDSyuywLri2wQOKXk9DuqWrYHjH0iShHT3uwZUSfnIqA=s32-c-mo"
                },
                   new Ciudadano
                   {
                       IdCiudadano = 5,
                       Nombre = "Santos",
                       Apellidos = "Pardos Gotor",
                       Dni = "12345678E",
                       Genero = "Hombre",
                       Nacionalidad = "Española",
                       FechaNacimiento = new DateTime(1995, 1, 1),
                       Direccion = "Calle Falsa 123",
                       NumeroTelefono = 987654321,
                       NumeroCuentaBancaria = "ES987654321",
                       IsPoli = false,
                       IsBusquedaYCaptura = false,
                       IsPeligroso = false,
                       ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjXzV-jm0U5kV0lccfpkdR_NeIDpJRa3av9cA6fBJySmh8B-nsfU=s75-c"
                   },
                   new Ciudadano
                   {
                       IdCiudadano = 6,
                       Nombre = "Eva Maria",
                       Apellidos = "Higelmo Martinez",
                       Dni = "12345678F",
                       Genero = "Mujer",
                       Nacionalidad = "Española",
                       FechaNacimiento = new DateTime(1995, 1, 1),
                       Direccion = "Calle Falsa 123",
                       NumeroTelefono = 987654321,
                       NumeroCuentaBancaria = "ES987654321",
                       IsPoli = false,
                       IsBusquedaYCaptura = false,
                       IsPeligroso = false,
                       ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjWbaN_SMJT8GbltNzC69AJquU6hlO2JoVkXGBjpptldvZNclstX=s75-c"
                   },
                  new Ciudadano
                  {
                      IdCiudadano = 7,
                      Nombre = "Silvia",
                      Apellidos = "Guardingo De La Riva",
                      Dni = "12345678G",
                      Genero = "Mujer",
                      Nacionalidad = "Española",
                      FechaNacimiento = new DateTime(1995, 1, 1),
                      Direccion = "Calle Falsa 123",
                      NumeroTelefono = 987654321,
                      NumeroCuentaBancaria = "ES987654321",
                      IsPoli = false,
                      IsBusquedaYCaptura = false,
                      IsPeligroso = false,
                      ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjW6IGDJ5YeNx1nJ1XnWsYBo15QF_E8JrIA9mMZ2uq9xQTI0XoY=s75-c"
                  },
                   new Ciudadano
                   {
                       IdCiudadano = 8,
                       Nombre = "Joaquin",
                       Apellidos = "Ruiz Lite",
                       Dni = "12345678H",
                       Genero = "Hombre",
                       Nacionalidad = "Española",
                       FechaNacimiento = new DateTime(1995, 1, 1),
                       Direccion = "Calle Falsa 123",
                       NumeroTelefono = 987654321,
                       NumeroCuentaBancaria = "ES987654321",
                       IsPoli = false,
                       IsBusquedaYCaptura = false,
                       IsPeligroso = false,
                       ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjV2lVzVGBSS8cX-TisA7tu5Guwo9KVK9aAalgSJzmqRZw629sc=s32-c"
                   }
            );

            modelBuilder.Entity<CodigoPenal>().HasData(
                    new CodigoPenal { IdCodigoPenal = 1, Articulo = "Art. 1.1", Description = "Excessive use of the horn", Descripcion = "Uso excesivo del claxón", Precio = 500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 2, Articulo = "Art. 1.2", Description = "Improper turn", Descripcion = "Giro indebido", Precio = 300, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 3, Articulo = "Art. 1.3", Description = "Driving against traffic", Descripcion = "Circular en sentido contrario", Precio = 700, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 4, Articulo = "Art. 1.4", Description = "Parking in non-habitable areas and obstructing traffic", Descripcion = "Estacionar en zonas no habitadas y obstruir la circulación", Precio = 500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 5, Articulo = "Art. 1.5", Description = "Ignoring traffic signs", Descripcion = "Ignorar señales de tránsito", Precio = 500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 6, Articulo = "Art. 1.6", Description = "Running a red light", Descripcion = "Saltarse un semáforo", Precio = 450, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 7, Articulo = "Art. 1.7", Description = "Not yielding to emergency vehicles", Descripcion = "No ceder el paso a vehículos de emergencia", Precio = 550, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 8, Articulo = "Art. 1.8", Description = "Improper overtaking", Descripcion = "Realizar adelantamiento indebido", Precio = 350, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 9, Articulo = "Art. 1.9", Description = "Driving in reverse", Descripcion = "Circular marcha atrás", Precio = 800, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 10, Articulo = "Art. 1.10", Description = "Ignoring signals from traffic regulators", Descripcion = "Ignorar señales de los agentes que regulan la circulacion", Precio = 500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 11, Articulo = "Art. 1.11", Description = "Skipping/omitting a traffic control", Descripcion = "Saltarse / omitir un control de trafico", Precio = 500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 12, Articulo = "Art. 1.12", Description = "Driving a vehicle in poor condition", Descripcion = "Conducir un vehiculo en malas condiciones", Precio = 1000, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 13, Articulo = "Art. 1.13", Description = "Speeding in urban areas", Descripcion = "Exceso de velocidad en vias urbanas", Precio = 800, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 14, Articulo = "Art. 1.14", Description = "Reckless driving", Descripcion = "Condución temeraria", Precio = 1500, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 15, Articulo = "Art. 1.15", Description = "Speeding in secondary roads", Descripcion = "Exceso de velocidad en vias secundarias", Precio = 1000, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 16, Articulo = "Art. 1.16", Description = "Driving under the influence of drugs/alcohol", Descripcion = "Conducir bajo los efectos de drogas/alcohol", Precio = 1500, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 17, Articulo = "Art. 1.17", Description = "Driving in non-authorized areas", Descripcion = "Circular por zonas no habilitadas para ello", Precio = 1000, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 18, Articulo = "Art. 1.18", Description = "Riding without a helmet for motorcycles", Descripcion = "Circular sin casco para motocicleta", Precio = 500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 19, Articulo = "Art. 1.18.1", Description = "Driving without a license", Descripcion = "Circular sin licencia de conducir", Precio = 550, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 20, Articulo = "Art. 2.1", Description = "Disturbing public order", Descripcion = "Alteración del orden público", Precio = 3500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 21, Articulo = "Art. 2.2", Description = "Racism", Descripcion = "Racismo", Precio = 5000, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 22, Articulo = "Art. 2.3", Description = "Disrespecting another civilian", Descripcion = "Faltas de respeto a otro civil", Precio = 2500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 23, Articulo = "Art. 2.4", Description = "Damaging urban furniture", Descripcion = "Dañar mobiliario urbano", Precio = 1700, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 24, Articulo = "Art. 2.5", Description = "Psychological harassment", Descripcion = "Acoso psicológico", Precio = 6000, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 25, Articulo = "Art. 2.6", Description = "Threatening to kill a civilian", Descripcion = "Amenaza de muerte a un civil", Precio = 2000, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 26, Articulo = "Art. 2.7", Description = "Identity theft", Descripcion = "Suplantación de identidad", Precio = 6000, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 27, Articulo = "Art. 2.8", Description = "Concealing face in public", Descripcion = "Circular por la via pública con el rostro oculto", Precio = 1000, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 28, Articulo = "Art. 2.9", Description = "Being naked or semi-naked in public", Descripcion = "Circular en la via pública desnudo o semi-desnudo", Precio = 1200, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 29, Articulo = "Art. 2.10", Description = "Being shirtless in public", Descripcion = "Circular en la via pública sin camiseta", Precio = 120, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 30, Articulo = "Art. 2.11", Description = "Sexual harassment", Descripcion = "Acoso sexual", Precio = 30000, Sentencia = "100 " },
                    new CodigoPenal { IdCodigoPenal = 31, Articulo = "Art. 2.12", Description = "Violating a restraining order with a firm sentence", Descripcion = "Violar una orden de alejamiento con sentencia firme", Precio = 25000, Sentencia = "80 " },
                    new CodigoPenal { IdCodigoPenal = 32, Articulo = "Art. 2.13", Description = "Refusing to identify oneself", Descripcion = "Negativa a identificarse", Precio = 1000, Sentencia = "7 " },
                    new CodigoPenal { IdCodigoPenal = 33, Articulo = "Art. 2.14", Description = "Obstruction of justice", Descripcion = "Obstrucción a la justicia", Precio = 2500, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 34, Articulo = "Art. 3.1", Description = "Possession of narcotics (marijuana) 210/unit (from 2 units)", Descripcion = "Posesion de estupefacientes (marihuana) 210/unidad (a partir de 2 unidades)", Precio = 210, Sentencia = "7 " },
                    new CodigoPenal { IdCodigoPenal = 35, Articulo = "Art. 3.2", Description = "Consumption of marijuana in public", Descripcion = "Consumo de marihuana en vía pública", Precio = 350, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 36, Articulo = "Art. 3.3", Description = "Possession of narcotics (cocaine/methamphetamine) 650/unit (from 2 units)", Descripcion = "Posesion de estupefacientes (Cocaína/Mentafetamina) 650/unidad (a partir de 2 unidades)", Precio = 650, Sentencia = "7 " },
                    new CodigoPenal { IdCodigoPenal = 37, Articulo = "Art. 3.4", Description = "Drug trafficking: Any individual or group caught selling narcotics flagrantly. Fine of 450 for each flagrant sale of cocaine. All money on the subject will be confiscated.", Descripcion = "Se considera trafico de drogas a cualquier individuo o grupo de personas que se vean vendiendo estupefacientes en flagante delito. Multa de 450 por cada delito flagante de venta de cocaina. Se requisara todo el dinero que lleve el sujeto.", Precio = 450, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 38, Articulo = "Art. 3.5", Description = "Drug trafficking: Any individual or group caught selling narcotics flagrantly. Fine of 650 for each flagrant sale of meth. All money on the subject will be confiscated.", Descripcion = "Se considera trafico de drogas a cualquier individuo o grupo de personas que se vean vendiendo estupefacientes en flagante delito. Multa de 650 por cada delito flagante de venta de meta. Se requisara todo el dinero que lleve el sujeto.", Precio = 650, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 39, Articulo = "Art. 4.1", Description = "It is completely prohibited for civilians to wear a gun holster as a decorative outfit.", Descripcion = "Queda totalmente prohibida por parte de los civiles portar una pistolera como atuendo de modo decorativo", Precio = 1500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 40, Articulo = "Art. 4.2", Description = "Possession of a blade weapon: considered as such, those cutting edge weapons. Bladed weapons susceptible to be used as an illegal weapon: Knife, Baseball bat, Golf club, Broken bottle, Razor, Machete", Descripcion = "Posesion de arma blanca: son considerados como tal, aquellas armas de filo cortante. Armas blancas susceptibles de ser usadas como arma ilegal: Cuchillo, Bate de beisbol, Palo de golf, Botella rota, Navaja, Machete", Precio = 2500, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 41, Articulo = "Art. 4.3", Description = "Carrying a small caliber pistol (firearm)", Descripcion = "Portar pistola de baja calibre (arma de fuego)", Precio = 10000, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 42, Articulo = "Art. 4.4", Description = "Carrying low/medium caliber automatic weapons", Descripcion = "Portar armas automaticas de baja calibre/medio", Precio = 24000, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 43, Articulo = "Art. 4.5", Description = "Carrying high caliber automatic weapons", Descripcion = "Portar armas automaticas de alto calibre", Precio = 40000, Sentencia = "15 " },
                    new CodigoPenal { IdCodigoPenal = 44, Articulo = "Art. 4.6", Description = "Arms trafficking", Descripcion = "Trafico de armas", Precio = 30000, Sentencia = "25 " },
                    new CodigoPenal { IdCodigoPenal = 45, Articulo = "Art. 4.7", Description = "Terrorist attack", Descripcion = "Atentado terrorista", Precio = 100000, Sentencia = "250 " },
                    new CodigoPenal { IdCodigoPenal = 46, Articulo = "Art. 4.8", Description = "Attempting against the life or physical integrity of several people and/or public officials through the armed organization of several individuals", Descripcion = "Atentar contra la vida o integridad fisica de varios personas y/o funcionarios publicos mediante la organizacion armada de varios individuos", Precio = 100000, Sentencia = "350 " },
                    new CodigoPenal { IdCodigoPenal = 47, Articulo = "Art. 5.1", Description = "Assaulting another individual", Descripcion = "Agresion a otro individuo", Precio = 3000, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 48, Articulo = "Art. 5.2", Description = "Attempted assault on a civilian", Descripcion = "Intento de agresion a civil", Precio = 1500, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 49, Articulo = "Art. 5.3", Description = "Attempted kidnapping", Descripcion = "Intento de secuestro", Precio = 2400, Sentencia = "15 " },
                    new CodigoPenal { IdCodigoPenal = 50, Articulo = "Art. 5.4", Description = "Kidnapping an individual", Descripcion = "Secuestro a un individuo", Precio = 3500, Sentencia = "15 " },
                    new CodigoPenal { IdCodigoPenal = 51, Articulo = "Art. 5.5", Description = "Attempted homicide on a civilian without the use of weapons", Descripcion = "Intento de homicidio a un civil sin el uso de armas", Precio = 4000, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 52, Articulo = "Art. 5.6", Description = "Attempted homicide on a civilian with the use of any kind of weapon", Descripcion = "Intento de homicidio a un civil con uso de armas de cualquier indole", Precio = 6000, Sentencia = "20 " },
                    new CodigoPenal { IdCodigoPenal = 53, Articulo = "Art. 5.7", Description = "Attempted homicide on multiple civilians without the use of weapons", Descripcion = "Intento de homicidio a multiples sin el uso de armas", Precio = 5000, Sentencia = "15 " },
                    new CodigoPenal { IdCodigoPenal = 54, Articulo = "Art. 5.8", Description = "Attempted homicide on multiple civilians with the use of any kind of weapon", Descripcion = "Intento de homicidio a multiples civiles con uso de armas de cualquier indole", Precio = 7500, Sentencia = "15 " },
                    new CodigoPenal { IdCodigoPenal = 55, Articulo = "Art. 6.1", Description = "Threats, disobedience, and insults: After the first omission of a police officer's order, the economic amount may be accumulated for each disrespect or disobedience after the first warning.", Descripcion = "Amenazas, desobedencia e insultos: Tras la primera amision de la orden de un funcionario de policia, se le podra acumular al reo el monta econonico despues del primer aviso por cada falta de respeto o desacato.", Precio = 300, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 56, Articulo = "Art. 6.2", Description = "Insulting a public official.", Descripcion = "Insultar a un funcionario publico.", Precio = 1700, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 57, Articulo = "Art. 6.3", Description = "Assault or death threat to an official.", Descripcion = "Agresión o amenaza de muerte a un funcionario.", Precio = 3400, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 58, Articulo = "Art. 6.4", Description = "Contempt", Descripcion = "Desacato", Precio = 2000, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 59, Articulo = "Art. 6.5", Description = "Fleeing from justice", Descripcion = "Huir de la justicia", Precio = 1500, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 60, Articulo = "Art. 6.6", Description = "Usurpation of public functions", Descripcion = "Usurpacion de funciones publicas", Precio = 10000, Sentencia = "15 " },
                    new CodigoPenal { IdCodigoPenal = 61, Articulo = "Art. 6.7", Descripcion = "Falso testimonio", Description = "False testimony", Precio = 2000, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 62, Articulo = "Art. 6.8", Descripcion = "Usurpación de funcionarios públicos", Description = "Usurpation of public officials", Precio = 10000, Sentencia = "15 " },
                    new CodigoPenal { IdCodigoPenal = 63, Articulo = "Art. 6.9", Descripcion = "Secuestro a un funcionario", Description = "Kidnapping of an official", Precio = 8000, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 64, Articulo = "Art. 6.10", Descripcion = "Amenazar a un funcionario público a mano armada", Description = "Threatening a public official at gunpoint", Precio = 3500, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 65, Articulo = "Art. 6.11", Descripcion = "Intento de homicidio a un funcionario público", Description = "Attempted homicide of a public official", Precio = 5500, Sentencia = "15 " },
                    new CodigoPenal { IdCodigoPenal = 66, Articulo = "Art. 6.12", Descripcion = "Homicidio a un funcionario", Description = "Homicide of an official", Precio = 9000, Sentencia = "20 " },
                    new CodigoPenal { IdCodigoPenal = 67, Articulo = "Art. 6.13", Descripcion = "Homicidio a diferentes funcionarios", Description = "Homicide of different officials", Precio = 12500, Sentencia = "50 " },
                    new CodigoPenal { IdCodigoPenal = 68, Articulo = "Art. 6.14", Descripcion = "Robo de secretos del estado", Description = "Theft of state secrets", Precio = 0, Sentencia = "5000 " },
                    new CodigoPenal { IdCodigoPenal = 69, Articulo = "Art. 6.15", Descripcion = "Sera acusado de denuncia falsa aquel que registre una denucia ante el cuerpo policial a sabiendas de su falsedad", Description = "Those who file a false complaint with the police knowing its falsehood will be accused", Precio = 2500, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 70, Articulo = "Art. 6.16", Descripcion = "Actos de corrupción por parte de un agente", Description = "Acts of corruption by an agent", Precio = 0, Sentencia = "5000  " },
                    new CodigoPenal { IdCodigoPenal = 71, Articulo = "Art. 7.1", Descripcion = "Robo de vehículo", Description = "Vehicle theft", Precio = 2000, Sentencia = "6 " },
                    new CodigoPenal { IdCodigoPenal = 72, Articulo = "Art. 7.2", Descripcion = "Robo con intimidación a un civil", Description = "Robbery with intimidation to a civilian", Precio = 3400, Sentencia = "8 " },
                    new CodigoPenal { IdCodigoPenal = 73, Articulo = "Art. 7.3", Descripcion = "Robo con violencia a un civil", Description = "Robbery with violence to a civilian", Precio = 2600, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 74, Articulo = "Art. 7.4", Descripcion = "Hurto menor", Description = "Petty theft", Precio = 1500, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 75, Articulo = "Art. 7.5", Descripcion = "Robar pertenencias que se hallen en el interior de un vehículo de vía urbana o propiedad privada", Description = "Stealing belongings inside a vehicle in an urban area or private property", Precio = 2150, Sentencia = "7 " },
                    new CodigoPenal { IdCodigoPenal = 76, Articulo = "Art. 8.1", Descripcion = "Celebración de manifestaciones en lugares de tránsito público sin haber sido autorizados", Description = "Holding demonstrations in public transit places without authorization", Precio = 1000, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 77, Articulo = "Art. 8.2", Descripcion = "Cometer actos de vandalismo", Description = "Commit acts of vandalism", Precio = 1500, Sentencia = "0  " },
                    new CodigoPenal { IdCodigoPenal = 78, Articulo = "Art. 8.3", Descripcion = "Hurto de un civil sin importar las posesiones robadas", Description = "Theft from a civilian regardless of stolen possessions", Precio = 3500, Sentencia = "10  " },
                    new CodigoPenal { IdCodigoPenal = 79, Articulo = "Art. 8.4", Descripcion = "Obstaculizar el desempeño y desarrollo de las funciones públicas y servicios de emergencia", Description = "Obstructing the performance and development of public functions and emergency services", Precio = 2300, Sentencia = "0 " },
                    new CodigoPenal { IdCodigoPenal = 80, Articulo = "Art. 8.5", Descripcion = "Negarse a disolver una reunión o manifestación tras haber sido previamente advertido por un funcionario público", Description = "Refusing to disband a meeting or demonstration after being previously warned by a public official", Precio = 1600, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 81, Articulo = "Art. 8.6", Descripcion = "Negarse a identificarse o aportar datos falsos que dificulten la acción policial", Description = "Refusing to identify oneself or provide false information that hinders police action", Precio = 1500, Sentencia = "5 " },
                    new CodigoPenal { IdCodigoPenal = 82, Articulo = "Art. 8.7", Descripcion = "Amenazar a un funcionario público a mano armada", Description = "Threatening an official with a firearm", Precio = 3500, Sentencia = "10  " },
                    new CodigoPenal { IdCodigoPenal = 83, Articulo = "Art. 8.8", Descripcion = "Exhibicionismo: El que realice actos de exhibicionismo delante de personas causándoles un perjuicio", Description = "Exhibitionism: Anyone who engages in exhibitionism in front of people causing them harm", Precio = 5500, Sentencia = "10 " },
                    new CodigoPenal { IdCodigoPenal = 84, Articulo = "Art. 8.9", Descripcion = "Será acusado de extorsión aquel que, con intención de beneficiarse, obligue a otro con violencia o intimidación a realizar un acto que le perjudique económicamente", Description = "Anyone who, with the intention of benefiting, forces another person with violence or intimidation to perform an act that harms them economically, will be accused of extortion", Precio = 3000, Sentencia = "15 " },
                    new CodigoPenal { IdCodigoPenal = 85, Articulo = "Art. 8.10", Descripcion = "Será acusado de injuria aquel que diga de manera pública hechos falsos que humillen a otra persona", Description = "Anyone who publicly states false facts that humiliate another person will be accused of defamation", Precio = 1200, Sentencia = "7  " },
                    new CodigoPenal { IdCodigoPenal = 86, Articulo = "Art. 8.11", Descripcion = "Violación de la intimidad aquel que acceda a cualquier tipo de propiedad o dispositivo de otro, sea digital o analógico. El artículo excluye a los funcionarios públicos por desempeño de sus labores de investigación", Description = "Violation of privacy: Anyone who accesses any type of property or device of another, whether digital or analog. The article excludes public officials in the performance of their investigative duties", Precio = 2400, Sentencia = "7 " },
                    new CodigoPenal { IdCodigoPenal = 87, Articulo = "Art. 8.12", Descripcion = "Será acusado de tortura aquel que realice actos degradantes, ofensivos, dañinos o de similar a una persona", Description = "Anyone who performs degrading, offensive, harmful, or similar acts to a person will be accused of torture", Precio = 5600, Sentencia = "15" },
                    new CodigoPenal { IdCodigoPenal = 88, Articulo = "Art. 8.13", Descripcion = "Negarse a la identificación ante un funcionario público", Description = "Refusing to identify oneself to a public official", Precio = 1500, Sentencia = "0 " }
            );

            modelBuilder.Entity<Rango>().HasData(
               new Rango { IdRango = 1, Name = "Practices ", Nombre = "Practicas", Salario = 1071, isLocal = true },
               new Rango { IdRango = 2, Name = "Agent", Nombre = "Agente", Salario = 1330, isLocal = true },
               new Rango { IdRango = 3, Name = "Official I", Nombre = "Oficial I", Salario = 1412, isLocal = true },
               new Rango { IdRango = 4, Name = "Official II", Nombre = "Oficial II", Salario = 1483, isLocal = true },
               new Rango { IdRango = 5, Name = "Official III", Nombre = "Oficial III", Salario = 1555, isLocal = true },
               new Rango { IdRango = 6, Name = "Sub-inspector", Nombre = "Subinspector", Salario = 1674, isLocal = true },
               new Rango { IdRango = 7, Name = "Inspector", Nombre = "Inspector", Salario = 1765, isLocal = true },
               new Rango { IdRango = 8, Name = "Chief inspector", Nombre = "Inspector Jefe", Salario = 1881, isLocal = true },
               new Rango { IdRango = 9, Name = "Mayor", Nombre = "Intendente", Salario = 2028, isLocal = true },
               new Rango { IdRango = 10, Name = "Super mayor", Nombre = "Superintendente", Salario = 2142, isLocal = true }
            );

            modelBuilder.Entity<Permiso>().HasData(
                new Permiso { IdPermiso = 1, Name = "Add police", Nombre = "Añadir policia" },
                new Permiso { IdPermiso = 2, Name = "Remove police", Nombre = "Quitar policia" },
                new Permiso { IdPermiso = 3, Name = "Modify police", Nombre = "Modificar policia" },
                new Permiso { IdPermiso = 4, Name = "Delete fine", Nombre = "Borrar multa" },
                new Permiso { IdPermiso = 5, Name = "Create fine", Nombre = "Crear multa" },
                new Permiso { IdPermiso = 6, Name = "Delete complaint", Nombre = "Borrar denuncia" },
                new Permiso { IdPermiso = 7, Name = "Create complaint", Nombre = "Crear denuncia" },
                new Permiso { IdPermiso = 8, Name = "Modify complaint", Nombre = "Modificar denuncia" },
                new Permiso { IdPermiso = 9, Name = "Delete note", Nombre = "Eliminar nota" },
                new Permiso { IdPermiso = 10, Name = "Create note", Nombre = "Crear nota" },
                new Permiso { IdPermiso = 11, Name = "Modify note", Nombre = "Modificar nota" },
                new Permiso { IdPermiso = 12, Name = "Create event", Nombre = "Crear evento" },
                new Permiso { IdPermiso = 13, Name = "Delete event", Nombre = "Eliminar evento" }
            );

            modelBuilder.Entity<RangoPermiso>().HasData(
                new RangoPermiso { IdPermiso = 5, IdRango = 1 },
                new RangoPermiso { IdPermiso = 7, IdRango = 1 },
                new RangoPermiso { IdPermiso = 5, IdRango = 2 },
                new RangoPermiso { IdPermiso = 7, IdRango = 2 },
                new RangoPermiso { IdPermiso = 10, IdRango = 2 },
                new RangoPermiso { IdPermiso = 5, IdRango = 3 },
                new RangoPermiso { IdPermiso = 7, IdRango = 3 },
                new RangoPermiso { IdPermiso = 10, IdRango = 3 },
                new RangoPermiso { IdPermiso = 11, IdRango = 3 },
                new RangoPermiso { IdPermiso = 5, IdRango = 4 },
                new RangoPermiso { IdPermiso = 7, IdRango = 4 },
                new RangoPermiso { IdPermiso = 10, IdRango = 4 },
                new RangoPermiso { IdPermiso = 11, IdRango = 4 },
                new RangoPermiso { IdPermiso = 5, IdRango = 5 },
                new RangoPermiso { IdPermiso = 7, IdRango = 5 },
                new RangoPermiso { IdPermiso = 10, IdRango = 5 },
                new RangoPermiso { IdPermiso = 11, IdRango = 5 },
                new RangoPermiso { IdPermiso = 5, IdRango = 6 },
                new RangoPermiso { IdPermiso = 7, IdRango = 6 },
                new RangoPermiso { IdPermiso = 8, IdRango = 6 },
                new RangoPermiso { IdPermiso = 10, IdRango = 6 },
                new RangoPermiso { IdPermiso = 11, IdRango = 6 },
                new RangoPermiso { IdPermiso = 5, IdRango = 7 },
                new RangoPermiso { IdPermiso = 7, IdRango = 7 },
                new RangoPermiso { IdPermiso = 8, IdRango = 7 },
                new RangoPermiso { IdPermiso = 9, IdRango = 7 },
                new RangoPermiso { IdPermiso = 10, IdRango = 7 },
                new RangoPermiso { IdPermiso = 11, IdRango = 7 },
                new RangoPermiso { IdPermiso = 3, IdRango = 8 },
                new RangoPermiso { IdPermiso = 5, IdRango = 8 },
                new RangoPermiso { IdPermiso = 7, IdRango = 8 },
                new RangoPermiso { IdPermiso = 8, IdRango = 8 },
                new RangoPermiso { IdPermiso = 9, IdRango = 8 },
                new RangoPermiso { IdPermiso = 10, IdRango = 8 },
                new RangoPermiso { IdPermiso = 11, IdRango = 8 },
                new RangoPermiso { IdPermiso = 1, IdRango = 9 },
                new RangoPermiso { IdPermiso = 3, IdRango = 9 },
                new RangoPermiso { IdPermiso = 4, IdRango = 9 },
                new RangoPermiso { IdPermiso = 5, IdRango = 9 },
                new RangoPermiso { IdPermiso = 6, IdRango = 9 },
                new RangoPermiso { IdPermiso = 7, IdRango = 9 },
                new RangoPermiso { IdPermiso = 8, IdRango = 9 },
                new RangoPermiso { IdPermiso = 9, IdRango = 9 },
                new RangoPermiso { IdPermiso = 10, IdRango = 9 },
                new RangoPermiso { IdPermiso = 11, IdRango = 9 },
                new RangoPermiso { IdPermiso = 1, IdRango = 10 },
                new RangoPermiso { IdPermiso = 2, IdRango = 10 },
                new RangoPermiso { IdPermiso = 3, IdRango = 10 },
                new RangoPermiso { IdPermiso = 4, IdRango = 10 },
                new RangoPermiso { IdPermiso = 5, IdRango = 10 },
                new RangoPermiso { IdPermiso = 6, IdRango = 10 },
                new RangoPermiso { IdPermiso = 7, IdRango = 10 },
                new RangoPermiso { IdPermiso = 8, IdRango = 10 },
                new RangoPermiso { IdPermiso = 9, IdRango = 10 },
                new RangoPermiso { IdPermiso = 10, IdRango = 10 },
                new RangoPermiso { IdPermiso = 11, IdRango = 10 },
                new RangoPermiso { IdPermiso = 12, IdRango = 10 },
                new RangoPermiso { IdPermiso = 13, IdRango = 10 }
                );

            modelBuilder.Entity<Ayuntamiento>().HasData(
            new Ayuntamiento
            {
                IdUsuarioAyuntamiento = 1,
                Dni = "12345678",
                Contrasena = "1234"
            },
            new Ayuntamiento
            {
                IdUsuarioAyuntamiento = 2,
                Dni = "87654321",
                Contrasena = "1234"
            }
            );
        }
    }
}