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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
