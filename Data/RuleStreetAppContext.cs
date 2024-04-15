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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Ciudadano)
                .WithMany(c => c.Vehiculos)
                .HasForeignKey(v => v.IdCiudadano);

            modelBuilder.Entity<Multa>()
                .HasOne(v => v.ciudadano)
                .WithMany(c => c.Multas)
                .HasForeignKey(v => v.IdCiudadano);



            modelBuilder.Entity<Ciudadano>().HasData(
                new Ciudadano
                {
                    IdCiudadano = 1,
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    Dni = "12345678",
                    Genero = "Hombre",
                    Nacionalidad = "Español",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    Direccion = "Calle Falsa 123",
                    NumeroTelefono = 123456789,
                    NumeroCuentaBancaria = "ES123456789",
                    IsPoli = false,
                    IsBusquedaYCaptura = false,
                    IsPeligroso = false
                },
                new Ciudadano
                {
                    IdCiudadano = 2,
                    Nombre = "Maria",
                    Apellidos = "Gonzalez",
                    Dni = "87654321",
                    Genero = "Mujer",
                    Nacionalidad = "Española",
                    FechaNacimiento = new DateTime(1995, 1, 1),
                    Direccion = "Calle Falsa 123",
                    NumeroTelefono = 987654321,
                    NumeroCuentaBancaria = "ES987654321",
                    IsPoli = false,
                    IsBusquedaYCaptura = false,
                    IsPeligroso = false
                }
           );

            modelBuilder.Entity<CodigoPenal>().HasData(
                new CodigoPenal { IdCodigoPenal = 1, Articulo = "Art. 1.1", Descripcion = "Uso excesivo del claxón", Precio = 500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 2, Articulo = "Art. 1.2", Descripcion = "Giro indebido", Precio = 300, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 3, Articulo = "Art. 1.3", Descripcion = "Circular en sentido contrario", Precio = 700, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 4, Articulo = "Art. 1.4", Descripcion = "Estacionar en zonas no habitadas y obstruir la circulación", Precio = 500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 5, Articulo = "Art. 1.5", Descripcion = "Ignorar señales de tránsito", Precio = 500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 6, Articulo = "Art. 1.6", Descripcion = "Saltarse un semáforo", Precio = 450, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 7, Articulo = "Art. 1.7", Descripcion = "No ceder el paso a vehículos de emergencia", Precio = 550, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 8, Articulo = "Art. 1.8", Descripcion = "Realizar adelantamiento indebido", Precio = 350, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 9, Articulo = "Art. 1.9", Descripcion = "Circular marcha atrás", Precio = 800, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 10, Articulo = "Art. 1.10", Descripcion = "Ignorar señales de los agentes que regulan la circulacion", Precio = 500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 11, Articulo = "Art. 1.11", Descripcion = "Saltarse / omitir un control de trafico", Precio = 500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 12, Articulo = "Art. 1.12", Descripcion = "Conducir un vehiculo en malas condiciones", Precio = 1000, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 13, Articulo = "Art. 1.13", Descripcion = "Exceso de velocidad en vias urbanas", Precio = 800, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 14, Articulo = "Art. 1.14", Descripcion = "Condución temeraria", Precio = 1500, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 15, Articulo = "Art. 1.15", Descripcion = "Exceso de velocidad en vias secundarias", Precio = 1000, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 16, Articulo = "Art. 1.16", Descripcion = "Conducir bajo los efectos de drogas/alcohol", Precio = 1500, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 17, Articulo = "Art. 1.17", Descripcion = "Circular por zonas no habilitadas para ello", Precio = 1000, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 18, Articulo = "Art. 1.18", Descripcion = "Circular sin casco para motocicleta", Precio = 500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 19, Articulo = "Art. 1.18.1", Descripcion = "Circular sin licencia de conducir", Precio = 550, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 20, Articulo = "Art. 2.1", Descripcion = "Alteración del orden público", Precio = 3500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 21, Articulo = "Art. 2.2", Descripcion = "Racismo", Precio = 5000, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 22, Articulo = "Art. 2.3", Descripcion = "Faltas de respeto a otro civil", Precio = 2500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 23, Articulo = "Art. 2.4", Descripcion = "Dañar mobiliario urbano", Precio = 1700, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 24, Articulo = "Art. 2.5", Descripcion = "Acoso psicológico", Precio = 6000, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 25, Articulo = "Art. 2.6", Descripcion = "Amenaza de muerte a un civil", Precio = 2000, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 26, Articulo = "Art. 2.7", Descripcion = "Suplantación de identidad", Precio = 6000, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 27, Articulo = "Art. 2.8", Descripcion = "Circular por la via pública con el rostro oculto", Precio = 1000, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 28, Articulo = "Art. 2.9", Descripcion = "Circular en la via pública desnudo o semi-desnudo", Precio = 1200, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 29, Articulo = "Art. 2.10", Descripcion = "Circular en la via pública sin camiseta", Precio = 120, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 30, Articulo = "Art. 2.11", Descripcion = "Acoso sexual", Precio = 30000, Sentencia = "100 meses" },
                new CodigoPenal { IdCodigoPenal = 31, Articulo = "Art. 2.12", Descripcion = "Violar una orden de alejamiento con sentencia firme", Precio = 25000, Sentencia = "80 meses" },
                new CodigoPenal { IdCodigoPenal = 32, Articulo = "Art. 2.13", Descripcion = "Negativa a identificarse", Precio = 1000, Sentencia = "7 meses" },
                new CodigoPenal { IdCodigoPenal = 33, Articulo = "Art. 2.14", Descripcion = "Obstrucción a la justicia", Precio = 2500, Sentencia = "10 meses" }
             );

        }
    }
}
