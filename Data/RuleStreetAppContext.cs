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
        public DbSet<Denuncia> Denuncia { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Ayuntamiento> Ayuntamiento { get; set; }   

        public DbSet<Evento> Evento { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Ciudadano)
                .WithMany(c => c.Vehiculos)
                .HasForeignKey(v => v.IdCiudadano);

            modelBuilder.Entity<Multa>()
                .HasOne(v => v.Ciudadano)
                .WithMany(c => c.Multas);



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
                    IsBusquedaYCaptura = true,
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
                new CodigoPenal { IdCodigoPenal = 33, Articulo = "Art. 2.14", Descripcion = "Obstrucción a la justicia", Precio = 2500, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 34, Articulo = "Art. 3.1", Descripcion = "Posesion de estupefacientes (marihuana) 210/unidad (a partir de 2 unidades)", Precio = 210, Sentencia = "7 meses" },
                new CodigoPenal { IdCodigoPenal = 35, Articulo = "Art. 3.2", Descripcion = "Consumo de marihuana en vía pública", Precio = 350, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 36, Articulo = "Art. 3.3", Descripcion = "Posesion de estupefacientes (Cocaína/Mentafetamina) 650/unidad (a partir de 2 unidades)", Precio = 650, Sentencia = "7 meses" },
                new CodigoPenal { IdCodigoPenal = 37, Articulo = "Art. 3.4", Descripcion = "Se considera trafico de drogas a cualquier individuo o grupo de personas que se vean vendiendo estupefacientes en flagante delito. Multa de 450 por cada delito flagante de venta de cocaina. Se requisara todo el dinero que lleve el sujeto.", Precio = 450, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 38, Articulo = "Art. 3.5", Descripcion = "Se considera trafico de drogas a cualquier individuo o grupo de personas que se vean vendiendo estupefacientes en flagante delito. Multa de 650 por cada delito flagante de venta de meta. Se requisara todo el dinero que lleve el sujeto.", Precio = 650, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 39, Articulo = "Art. 4.1", Descripcion = "Queda totalmente prohibida por parte de los civiles portar una pistolera como atuendo de modo decorativo", Precio = 1500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 40, Articulo = "Art. 4.2", Descripcion = "Posesion de arma blanca: son considerados como tal, aquellas armas de filo cortante. Armas blancas susceptibles de ser usadas como arma ilegal: Cuchillo, Bate de beisbol, Palo de golf, Botella rota, Navaja, Machete", Precio = 2500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 41, Articulo = "Art. 4.3", Descripcion = "Portar pistola de baja calibre (arma de fuego)", Precio = 10000, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 42, Articulo = "Art. 4.4", Descripcion = "Portar armas automaticas de baja calibre/medio", Precio = 24000, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 43, Articulo = "Art. 4.5", Descripcion = "Portar armas automaticas de alto calibre", Precio = 40000, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 44, Articulo = "Art. 4.6", Descripcion = "Trafico de armas", Precio = 30000, Sentencia = "25 meses" },
                new CodigoPenal { IdCodigoPenal = 45, Articulo = "Art. 4.7", Descripcion = "Atentado terrorista", Precio = 100000, Sentencia = "250 meses" },
                new CodigoPenal { IdCodigoPenal = 46, Articulo = "Art. 4.8", Descripcion = "Atentar contra la vida o integridad fisica de varios personas y/o funcionarios publicos mediante la organizacion armada de varios individuos", Precio = 100000, Sentencia = "350 meses" },
                new CodigoPenal { IdCodigoPenal = 47, Articulo = "Art. 5.1", Descripcion = "Agresion a otro individuo", Precio = 3000, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 48, Articulo = "Art. 5.2", Descripcion = "Intento de agresion a civil", Precio = 1500, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 49, Articulo = "Art. 5.3", Descripcion = "Intento de secuestro", Precio = 2400, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 50, Articulo = "Art. 5.4", Descripcion = "Secuestro a un individuo", Precio = 3500, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 51, Articulo = "Art. 5.5", Descripcion = "Intento de homicidio a un civil sin el uso de armas", Precio = 4000, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 52, Articulo = "Art. 5.6", Descripcion = "Intento de homicidio a un civil con uso de armas de cualquier indole", Precio = 6000, Sentencia = "20 meses" },
                new CodigoPenal { IdCodigoPenal = 53, Articulo = "Art. 5.7", Descripcion = "Intento de homicidio a multiples sin el uso de armas", Precio = 5000, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 54, Articulo = "Art. 5.8", Descripcion = "Intento de homicidio a multiples civiles con uso de armas de cualquier indole", Precio = 7500, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 55, Articulo = "Art. 6.1", Descripcion = "Amenazas, desobedencia e insultos: Tras la primera amision de la orden de un funcionario de policia, se le podra acumular al reo el monta econonico despues del primer aviso por cada falta de respeto o desacato.", Precio = 300, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 56, Articulo = "Art. 6.2", Descripcion = "Insultar a un funcionario publico.", Precio = 1700, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 57, Articulo = "Art. 6.3", Descripcion = "Agresión o amenaza de muerte a un funcionario.", Precio = 3400, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 58, Articulo = "Art. 6.4", Descripcion = "Desacato", Precio = 2000, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 59, Articulo = "Art. 6.5", Descripcion = "Huir de la justicia", Precio = 1500, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 60, Articulo = "Art. 6.6", Descripcion = "Usurpacion de funciones publicas", Precio = 10000, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 61, Articulo = "Art. 6.7", Descripcion = "Falso testimonio", Precio = 2000, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 62, Articulo = "Art. 6.8", Descripcion = "Usurpacion de funcionarios publicos", Precio = 10000, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 63, Articulo = "Art. 6.9", Descripcion = "Secuestro a un funcionario", Precio = 8000, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 64, Articulo = "Art. 6.10", Descripcion = "Amenazar a un funcionario publico a mano armada", Precio = 3500, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 65, Articulo = "Art. 6.11", Descripcion = "Intento de homicidio a un funcionario publico", Precio = 5500, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 66, Articulo = "Art. 6.12", Descripcion = "Homicidio a un funcionario", Precio = 9000, Sentencia = "20 meses" },
                new CodigoPenal { IdCodigoPenal = 67, Articulo = "Art. 6.13", Descripcion = "Homicidio a diferentes funcionarios", Precio = 12500, Sentencia = "50 meses" },
                new CodigoPenal { IdCodigoPenal = 68, Articulo = "Art. 6.14", Descripcion = "Robo de secretos del estado", Precio = 0, Sentencia = "5000 meses" },
                new CodigoPenal { IdCodigoPenal = 69, Articulo = "Art. 6.15", Descripcion = "Sera acusado de denuncia falsa aquel que registre una denucia ante el cuerpo policial a sabiendas de su falsedad", Precio = 2500, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 70, Articulo = "Art. 6.16", Descripcion = "Actos de corrupcion por parte de un agente", Precio = 0, Sentencia = "5000 meses" },
                new CodigoPenal { IdCodigoPenal = 71, Articulo = "Art. 7.1", Descripcion = "Robo de vehiculo", Precio = 2000, Sentencia = "6 meses" },
                new CodigoPenal { IdCodigoPenal = 72, Articulo = "Art. 7.2", Descripcion = "Robo con intimidacion a un civil", Precio = 3400, Sentencia = "8 meses" },
                new CodigoPenal { IdCodigoPenal = 73, Articulo = "Art. 7.3", Descripcion = "Robo con violencia a un civil", Precio = 2600, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 74, Articulo = "Art. 7.4", Descripcion = "Hurto menor", Precio = 1500, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 75, Articulo = "Art. 7.5", Descripcion = "Robar pertenencias que se hallen en el interior de un vehiculo de via urbana o propiedad privada", Precio = 2150, Sentencia = "7 meses" },
                new CodigoPenal { IdCodigoPenal = 76, Articulo = "Art. 8.1", Descripcion = "Celebracion de manifestaciones en lugares de transito publico sin haber sido autorizados", Precio = 1000, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 77, Articulo = "Art. 8.2", Descripcion = "Cometer actos de vandalismo", Precio = 1500, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 78, Articulo = "Art. 8.3", Descripcion = "Hurto de un civil sin importar las posesiones robadas", Precio = 3500, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 79, Articulo = "Art. 8.4", Descripcion = "Obstaculizar el desempeño y desarrollo de las funciones publicas y servicios de emergencia", Precio = 2300, Sentencia = "0 meses" },
                new CodigoPenal { IdCodigoPenal = 80, Articulo = "Art. 8.5", Descripcion = "Negarse a disolver una reunion o manifestacion tras haber sido previamente advertido por un funcionario publico", Precio = 1600, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 81, Articulo = "Art. 8.6", Descripcion = "Negarse a identificarse o aportar datos falsos que dificulten la accion policial", Precio = 1500, Sentencia = "5 meses" },
                new CodigoPenal { IdCodigoPenal = 82, Articulo = "Art. 8.7", Descripcion = "Amenazar a un funcionario publico a mano armada", Precio = 3500, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 83, Articulo = "Art. 8.8", Descripcion = "Exhibicionismo: El que realice actos de exhibicionismo delante de personas causandoles un perjuicio", Precio = 5500, Sentencia = "10 meses" },
                new CodigoPenal { IdCodigoPenal = 84, Articulo = "Art. 8.9", Descripcion = "Sera acusado de extorsion aquel que, con intencion de beneficiarse, obligue a otro con violencia o intimidacion a realizar un acto que le perjudique economicamente", Precio = 3000, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 85, Articulo = "Art. 8.10", Descripcion = "Sera acusado de injuria aquel que diga de manera publica hechos falsos que humillen a otra persona", Precio = 1200, Sentencia = "7 meses" },
                new CodigoPenal { IdCodigoPenal = 86, Articulo = "Art. 8.11", Descripcion = "Violacion de la intimidad aquel que acceda a cualquier tipo de propiedad o dispositivo de otro, sea digital o analogico. El articulo excluye a los funcionarios publicos por desempeño de sus labores de investigacion", Precio = 2400, Sentencia = "7 meses" },
                new CodigoPenal { IdCodigoPenal = 87, Articulo = "Art. 8.12", Descripcion = "Sera acusado de tortura aquel que realice actos degradantes, ofensivos, dañinos o de similar a una persona", Precio = 5600, Sentencia = "15 meses" },
                new CodigoPenal { IdCodigoPenal = 88, Articulo = "Art. 8.13", Descripcion = "Negarse a la identificacion ante un funcionario publico", Precio = 1500, Sentencia = "0 meses" }
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