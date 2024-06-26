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

                //  entity.HasOne(d => d.policia)
                //  .WithMany(p => p.Notas)
                //  .HasForeignKey(d => d.IdPolicia);

                    entity.HasOne(d => d.ciudadano)
                    .WithMany(c => c.Notas)
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
                    ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjW8BqiphgAP2RarwrIgqXMdH0Y4XWQgicOFG6g5lTSoqlharjkl=s75-c",
                    Trabajo = "Desarrollador",
                    Work = "Developer"

                },
                new Ciudadano
                {
                    IdCiudadano = 2,
                    Nombre = "Vanessa",
                    Apellidos = "Llorente Pinzon",
                    Dni = "12345678B",
                    Genero = "Mujer",
                    Gender = "Woman",
                    Nacionalidad = "Española",
                    Nationality = "Spanish",
                    FechaNacimiento = new DateTime(1995, 1, 1),
                    Direccion = "Calle Falsa 123",
                    Address = "Fake Street 123",
                    NumeroTelefono = 987654321,
                    NumeroCuentaBancaria = "ES987654321",
                    IsPoli = false,
                    IsBusquedaYCaptura = false,
                    IsPeligroso = false,
                    ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjXq4SaB_ODyUUzUulLF9MsBbfp2kyQ8dJQ6-k96AxVcHx8PtnV2=s75-c",
                    Trabajo = "Desarrollador",
                    Work = "Developer"

                },
                new Ciudadano
                {
                    IdCiudadano = 3,
                    Nombre = "Maria",
                    Apellidos = "Crespo",
                    Dni = "12345678C",
                    Genero = "Mujer",
                    Gender = "Woman",
                    Nacionalidad = "Española",
                    Nationality = "Spanish",
                    FechaNacimiento = new DateTime(1995, 1, 1),
                    Direccion = "Calle Falsa 123",
                    Address = "Fake Street 123",
                    NumeroTelefono = 987654321,
                    NumeroCuentaBancaria = "ES987654321",
                    IsPoli = false,
                    IsBusquedaYCaptura = false,
                    IsPeligroso = false,
                    ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjXNudiq8hrsLIIP4y9gHaPvdatUtONrCGpmKvYBTePbSFleNrs=s75-c",
                    Trabajo = "Profesora",
                    Work = "Teacher"
                },
                new Ciudadano
                {
                    IdCiudadano = 4,
                    Nombre = "Oliver",
                    Apellidos = "Hierro Amon",
                    Dni = "12345678D",
                    Genero = "Hombre",
                    Gender = "Man",
                    Nacionalidad = "Española",
                    Nationality = "Spanish",
                    FechaNacimiento = new DateTime(1995, 1, 1),
                    Direccion = "Calle Falsa 123",
                    Address = "Fake Street 123",
                    NumeroTelefono = 987654321,
                    NumeroCuentaBancaria = "ES987654321",
                    IsPoli = false,
                    IsBusquedaYCaptura = false,
                    IsPeligroso = false,
                    ImagenUrl = "https://lh3.googleusercontent.com/a/ACg8ocL5B2wDSyuywLri2wQOKXk9DuqWrYHjH0iShHT3uwZUSfnIqA=s32-c-mo",
                    Trabajo = "Desarrollador",
                    Work = "Developer"

                },
                   new Ciudadano
                   {
                       IdCiudadano = 5,
                       Nombre = "Santos",
                       Apellidos = "Pardos Gotor",
                       Dni = "12345678E",
                       Genero = "Hombre",
                       Gender = "Man",
                       Nacionalidad = "Española",
                       Nationality = "Spanish",
                       FechaNacimiento = new DateTime(1995, 1, 1),
                       Direccion = "Calle Falsa 123",
                       Address = "Fake Street 123",
                       NumeroTelefono = 987654321,
                       NumeroCuentaBancaria = "ES987654321",
                       IsPoli = false,
                       IsBusquedaYCaptura = false,
                       IsPeligroso = false,
                       ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjXzV-jm0U5kV0lccfpkdR_NeIDpJRa3av9cA6fBJySmh8B-nsfU=s75-c",
                       Trabajo = "Desarrollador",
                       Work = "Developer"
                   },
                   new Ciudadano
                   {
                       IdCiudadano = 6,
                       Nombre = "Eva Maria",
                       Apellidos = "Higelmo Martinez",
                       Dni = "12345678F",
                       Genero = "Mujer",
                       Gender = "Woman",
                       Nacionalidad = "Española",
                       Nationality = "Spanish",
                       FechaNacimiento = new DateTime(1995, 1, 1),
                       Direccion = "Calle Falsa 123",
                       Address = "Fake Street 123",
                       NumeroTelefono = 987654321,
                       NumeroCuentaBancaria = "ES987654321",
                       IsPoli = false,
                       IsBusquedaYCaptura = false,
                       IsPeligroso = false,
                       ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjWbaN_SMJT8GbltNzC69AJquU6hlO2JoVkXGBjpptldvZNclstX=s75-c",
                       Trabajo = "Profesora",
                       Work = "Teacher"
                   },
                  new Ciudadano
                  {
                      IdCiudadano = 7,
                      Nombre = "Silvia",
                      Apellidos = "Guardingo De La Riva",
                      Dni = "12345678G",
                      Genero = "Mujer",
                      Gender = "Woman",
                      Nacionalidad = "Española",
                      Nationality = "Spanish",
                      FechaNacimiento = new DateTime(1995, 1, 1),
                      Direccion = "Calle Falsa 123",
                      Address = "Fake Street 123",
                      NumeroTelefono = 987654321,
                      NumeroCuentaBancaria = "ES987654321",
                      IsPoli = false,
                      IsBusquedaYCaptura = false,
                      IsPeligroso = false,
                      ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjW6IGDJ5YeNx1nJ1XnWsYBo15QF_E8JrIA9mMZ2uq9xQTI0XoY=s75-c",
                      Trabajo = "Desarolladora",
                      Work = "Developer"
                  },
                   new Ciudadano
                   {
                       IdCiudadano = 8,
                       Nombre = "Joaquin",
                       Apellidos = "Ruiz Lite",
                       Dni = "12345678H",
                       Genero = "Hombre",
                       Gender = "Man",
                       Nacionalidad = "Española",
                       Nationality = "Spanish",
                       FechaNacimiento = new DateTime(1995, 1, 1),
                       Direccion = "Calle Falsa 123",
                       Address = "Fake Street 123",
                       NumeroTelefono = 987654321,
                       NumeroCuentaBancaria = "ES987654321",
                       IsPoli = false,
                       IsBusquedaYCaptura = false,
                       IsPeligroso = false,
                       ImagenUrl = "https://lh3.googleusercontent.com/a-/ALV-UjV2lVzVGBSS8cX-TisA7tu5Guwo9KVK9aAalgSJzmqRZw629sc=s32-c",
                       Trabajo = "Desarrollador",
                       Work = "Developer"
                   },
                    new Ciudadano
                    {
                        IdCiudadano = 9,
                        Nombre = "María",
                        Apellidos = "González Pérez",
                        Dni = "87654321Z",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1988, 2, 14),
                        Direccion = "Avenida Siempre Viva 742",
                        Address = "Evergreen Terrace 742",
                        NumeroTelefono = 912345678,
                        NumeroCuentaBancaria = "ES912345678",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://example.com/image1.jpg",
                        Trabajo = "Profesora",
                        Work = "Teacher"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 10,
                        Nombre = "Carlos",
                        Apellidos = "Martínez Gómez",
                        Dni = "23456789A",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1990, 3, 20),
                        Direccion = "Calle Real 456",
                        Address = "Royal Street 456",
                        NumeroTelefono = 923456789,
                        NumeroCuentaBancaria = "ES923456789",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "data:image/jpeg;base64,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",
                        Trabajo = "Fontanero",
                        Work = "Plumber"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 11,
                        Nombre = "Laura",
                        Apellidos = "López García",
                        Dni = "34567890B",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1985, 4, 10),
                        Direccion = "Calle del Sol 789",
                        Address = "Sun Street 789",
                        NumeroTelefono = 934567890,
                        NumeroCuentaBancaria = "ES934567890",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "data:image/jpeg;base64,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",
                        Trabajo = "Camarera",
                        Work = "Waitress"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 12,
                        Nombre = "Miguel",
                        Apellidos = "Fernández Ruiz",
                        Dni = "45678901C",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1992, 5, 5),
                        Direccion = "Calle Luna 321",
                        Address = "Moon Street 321",
                        NumeroTelefono = 945678901,
                        NumeroCuentaBancaria = "ES945678901",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "data:image/jpeg;base64,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",
                        Trabajo = "Camarero",
                        Work = "Waiter"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 13,
                        Nombre = "Ana",
                        Apellidos = "Sánchez Martín",
                        Dni = "56789012D",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1997, 6, 15),
                        Direccion = "Calle Estrella 654",
                        Address = "Star Street 654",
                        NumeroTelefono = 956789012,
                        NumeroCuentaBancaria = "ES956789012",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "data:image/jpeg;base64,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",
                        Trabajo = "Piloto",
                        Work = "Pilot"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 14,
                        Nombre = "David",
                        Apellidos = "Gómez López",
                        Dni = "67890123E",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1983, 7, 23),
                        Direccion = "Calle Flor 987",
                        Address = "Flower Street 987",
                        NumeroTelefono = 967890123,
                        NumeroCuentaBancaria = "ES967890123",
                        IsPoli = false,
                        IsBusquedaYCaptura = true,
                        IsPeligroso = false,
                        ImagenUrl = "data:image/jpeg;base64,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",
                        DiaBusquedaCaptura = new DateTime(2021, 1, 1),
                        Trabajo = "Limpiador",
                        Work = "Cleaner"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 15,
                        Nombre = "Lucía",
                        Apellidos = "Torres García",
                        Dni = "78901234F",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1993, 8, 30),
                        Direccion = "Calle Mar 159",
                        Address = "Sea Street 159",
                        NumeroTelefono = 978901234,
                        NumeroCuentaBancaria = "ES978901234",
                        IsPoli = false,
                        IsBusquedaYCaptura = true,
                        IsPeligroso = false,
                        ImagenUrl = "data:image/jpeg;base64,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",
                        DiaBusquedaCaptura = new DateTime(2021, 1, 1),
                        Trabajo = "Limpiadora",
                        Work = "Cleaner"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 16,
                        Nombre = "Alberto",
                        Apellidos = "Ramírez Morales",
                        Dni = "89012345G",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1996, 9, 25),
                        Direccion = "Calle Río 753",
                        Address = "River Street 753",
                        NumeroTelefono = 989012345,
                        NumeroCuentaBancaria = "ES989012345",
                        IsPoli = false,
                        IsBusquedaYCaptura = true,
                        IsPeligroso = false,
                        ImagenUrl = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxAQEhUSEBIQFRUVEBAPEBUQFRUQEBIQFRUWFxUSFRUYHSggGBolGxUVITEhJSkrLi4uFx8zODMsNygtLisBCgoKDg0OFRAQFy0dFx0rKy0rKy0rLS0rLS0rKystLS0tKystLS0tNystLSstKy0tLSstLTcrKysrNysrKysrK//AABEIAP8AxgMBIgACEQEDEQH/xAAcAAABBQEBAQAAAAAAAAAAAAABAAIDBAUGBwj/xAA8EAABAwIDBgQDBgYBBQEAAAABAAIRAwQSITEFBkFRYXETIoGRMqGxByNSwdHwFDNicoLhQhZTc5LxFf/EABgBAQEBAQEAAAAAAAAAAAAAAAABAgME/8QAJBEBAQACAgICAQUBAAAAAAAAAAECESExAxIiQVETFDJScQT/2gAMAwEAAhEDEQA/APVUkklUJJJJAkCkUCUCJTSUCU0lA4lNxJhcmuqAakDuglLk3Esjam8Nrb/zazAfwjzO9gsCp9pNkJyqnlA1HqUNO3xJYlx9r9oFm/4jUYJObhllxyOS3LbbtrVjBXpmRI8wmOabNNWUZUIfy7+nNOxIiWUZUUogoJJRlMlOBVU4IpqKgKSSSBJJJICkiggSSSBQAppKLlG4oA4rL23ty3s2Y678PIDNx7BZ29+9tHZ7Ri81Rx8rBGKOLs9B1Xi+8e3a19VL6h4+RuoYzkOfdFkd9tP7Tpn+Hp6ZDxAZIM+aRlly6rh9o74Xtd33lV4Eg+TyaaRhWUGE6me+aZgPz4cFnbWj3Xbj5nlxJMk5Z9+qgfXmMpkZqR1KdJSbTw5ubIRD6Di3VwA1h2a0LTaNWk4PpvgjQif2VQdTgS4Ry5/VRYsP5BDb0PYG/wDWYQKoa5nENBaR/UBz+S9M2btOlcNDqTgZEwMyPb19ivm9tWDIy5haWz9s1KLg6m4xyJIaeYMHoELJX0WnBee7rb/UXBrK8snKScTAeOeoGmq79jgYIIIOYIzBC1GbNJQU4JgTgqh4Tk0JyKKSSSgSSCKBySSSAIFFAoI3lUNr3raFJ9V58rGOceGg0V568s+1rbYwi1Y6SXB1WDpGjffNKRwG8u06lzXdWqHzOiIMhrYkNEdEzZOz3VHTBUFK3xEAcjK9E2DssUqYnUgE/oueWWnbx4brBtd3HO+LLtqr7d1GZRi6nRdOxgGQU4XH3r1zxYuQfupylU7rdCo1stdPqu+anJ71L4Y8iuLOo055nnkYHRQOtjGYPzBXqv8A+VTLpLR7AobR2TSe2MABjKFv9Ry/QeSVKKY9oaInORpwXTbW2a8A/duxNnQEhw5ghc2yzc8+Vj54iDn1B4HoukylccsLKktqhaQYkaxxnSWnUEL2r7NtpCtaNaXS6mS06ThJlvb/AEvE30alLIh0a5jMLr/s62+LevDv5dQEPjUToewP1KrFj2sFPCjaZ07qRq2weE5NCcEUUkkFAikkkgekkkgCaU5NKDm9+tsmztX1GTjMMpkcHnIHT5LwO/qVHPcaji5xMuJ1knOV9A74WArW7v6Jqjjm0HhxXz+6qCD3EnjkpWp02d2bPG8E/wCl34yXJbsHn00XXHOF58+3t8M4OaVZpwq9IK1R1WHc/CUcKnIyTIhERRmnOZKfCaCUVSrCFSIbwA+ivXiz4VSyVnbb2a2rTcdHASCPovP6bHMdIMGco4FepVHQw9ivN7wAPJ4S5p9wQV1wrx+bGSve92rvxrWjUiMVJhI1gxGq1wsbdWkWWlBszFFmfoFshdo81PCIQCKoSSSCgRSQKSCQIoBFACmlOcmFBR2uQKVSdPDdPHKCvmy4IblH/LEevJfQ29F06lRxASC5rX9GkiSei+eb1gxuAJgVCGzkcPCeqlanTpd2a5cRAXc0xkuS3Rs/Li4Lq2OhefLmvb4+ImpNjVW6TeKxX7XptMAyemalpbdojUu9GnJZ06+0bijkqpS21TdpPQkK9TqhwySw2AlRYSrXiCFTur9rOE9k0u0ddipVqcKG53gpmQG1J7FUxthvIx1yT1Z9omvfgd2K83q1sRjm4g95Ga9Jxte2RmCCvO6toadzgIy8UCe5XXB5vN+Xvm7DHNtKAdqKLAfbL5LXCr2rIY0cmgewVgLs8t7PCSCKoSEpEppUBJRTSkglCKARQAoFOTSg5rfm9NKgAJ878JjI4YJMLwna9NoqFjBlPBe279MJ8KQS3z9sWUfKV41tanhqv7gf6XO35PT6yeKO53ao4aDeoV64biEcFBsTKiwH8IWm6gTEdjyXK9vRjOIoUTRpRIHPqVFc7yWYMEZzBwic/RR32xy58ucTzGjT0I5Kle7vB1QOBLRIcQJiYiRHTmtSM5b+o07e8o1PhEcpiPeVp2FbOFQbSp+QfBgaGtjN5A4Hmrnla7y5CZWMuG8d8Le0X+EJHFYrrmRidpyEfnAV7atTE0d1Ta6n5ZkYRkCJp4ufdScrltV/6itqZgjnJAcW5EAycMZSPdT1NoUawgBvTQ//ABZt3sFlSoagLsyTAzbDjLoz0Rq7JxPBbLTkMtIHNddcOUmW+Vm1oYHEN+EmQORWFt2gBdsPMNd6iV1IoOaM4XKb1uPjU41wZRzByTFM5xHsG7Vd1S2pucZJbB9CR+S1Qub3E8T+FGPg9wHUZE/MuXSBdZ08mc+VOCSCSrJFApFBAikkQkgmCKARQJAhFJBlbxW3iUH5Zt+8Hpr8pXhO3bdzblzXaPfLTwOLQr6IqsxAjmCPcFeWbS2U14GP4qbwfYwQueXF29Hi+WNn4SWDS1jQeAAW3aBY1N2mi1bZ0Lhe3rx6WatoHZkKtU2eObvdafi5QmEEps0zf4NjBIH5n3VKpqta/Ia3M9gsimZco3imvqUsVSzbOS17qj5fSViUawpu83wzCsK1KVnTP/GD0MKcWTW5gD1U1NoIlqbUdl+qbZ0o3nRcnt+0L6tEtE5lro4RBn5LpLl2qpa+5K1jWM509C2AwC3pAf8AbB9TqVoKlsRsW9L/AMbfory9E6eDL+VJJJJVkCgESgEBKSRKCCYJyanAoEgjCSALgN4KRZVqg8TjbPEHPL5rv1n7Z2cyvTIcPMA4sPEGPosZY7jr4s/W/wCvO6Dlo03LLZI/PurttVlcM49mFbdpmc1aqENGSzLaojcXAGpWW1W+xOcTGQWO/aYL8LGOMRicIDQeXVbVS/BBa1UGs4xM5lamJ7fhYqbX8hl2eGFiW9c1sTS0tzIl31C0G2wdJwgdYzVMDA6YV0lyrc2NVc0YXcPor128EZLFt9oB3dXatXJZqs+5dmqQBJgAknIAcSVNc1PMtzci3Dqz3kDysgTwc4iCP/UreMcvJl68us2ZRNOjTY7VrGtPcDNWkkl6Hht3RCSQSRAKanFAoGpIoILCIQRQFAooFAEkpSlB5vty08Gu9nAnG3+12Y/NVKRhdbvvZSxtYDNhwu/sP6H6rjaToK4Zx7PFluNi1IVe9plzjkTyUlqZVsxK4u15c4atWmY8I65Zz6qVt7U0LSOzJC1rmkSoTXLR8MrUu28eFJ17+FpnjDT+azrmtWOjT/lC1zfHQMHfJV3Nc50mVrot2ds6wfhBqRMz5eA5FadzTwtHZK2qYQB9VFtCuIWJy59MW4dmu83KtcFDGdajif8AEZD6LgC9uLzENBIBcdGjKXHoJXqWzbqg5jW0KjHNa0NGEg5ARnC9GEefzXhcSTZQldHmPlKU2UpQElJCUEBKCUpIJ5RCZKIKB8oIShKAyg50Zn55Lnd497KNpLB56kfCNG/3FeXbx7z3Nxm57onysYSGjoANVLXXHxWzd4j2Ha11QfSqU3VaXmY5sF7dYy4815jTq8OI+fVc9szYdat5qlQM6fzHf5QYHaZ6LdrUSMpzGXKYXPK7dcMddNWhWgaq024JK5uncOGRnsrFvecPZc9OlrqWOBElMuGAiFn2d0Ms+6uvrg/64JI3Mlf+HAz/AHCk8qVW5bp9FQurkAZapZs9tHXFeM5yCpXN3I9Fn3l5wnuq3iE/vRXTlvlDtm5IZlnLoPQaqhY7RqUnB9N7mkaFphbzrMVKbmn05g81yTWluR1BgreNaj1rdPfcViKVyQHHJr9A48ndeq7eV870HkFd7ZfaFVZgbUYxwwtBOYcQB9V025+Tw/1elylKwbLeyzqgfehpPB8iD3Wy14IkEEHQjMKvPcbO0kpSmYkpRk+UVHiQQWJRBUMrN2nvBbW38yoJ/C3zO/0jUxtupGzK53fTeD+EpQwjxHyG/wBI4uK4/bm/1d8ih923Sci+O/BclfXj6hlzi48STJJUtenx/wDPd7yC4uS8lxJJJkk5knmo7cS9o4FwB7KJrkmuwkEcDKzXqyx4d/SpBoAAjlCqV2Z+qu2j8bGuHEAqK5ZmvP8AbGmXcW85jJUiOByK3cAORVa4sSdFqVm4M0XTmagkcCFLS22RlB/NQ1Leo3QFRGo/8B9lrbGrFyptgHQOVKtdudwI7pec6Mj0hSMsHnUQmzVqsxpPU8+SuUaICs0rHDqnubClrUwSW/H98FxNyfvH/wB7vqV27fIwuPAElcORJJ5kn3KuDej2BS1DkDykKImEgZaV1aPpViDPut/ZW89zb+VjpbyOYXOM6qQVOSJ6y9u+tN/6jT98xjhxw+VwW9R33s3DMvb0LZ+i8ka5SCorti+DCvbNmbat7ifDfmMyD5THP5pLxZldzTIcR2MJJtj9tHT3W/N65paMAyguDYcuXq3LnGXEknMzzUDqpPFRYlNvTjhJ1EtZ8ouKgeUWOyHZFThEpgcnKNadfupeBzfDJzHw9ltXFBef7PuzSeHDgvSdnXLa9MOEaZ91yzxcspqs1rFM2mprm3gyE+lnqudhDKdunGyadR9FZYwhPJKktXSkbJo0CjdarQJUT3q7qyMu4pQFSpW5eegWpUpF5TLqvToNkkDurEZG8dYU6eHidf0XHELS2vems7FwmR9FnVNF2xmosn2hmVZp0xEHkq9JuaslbJFdqdCjx+YwpgoQ0BPCBQlUOJSTJSRdEmkIJIoPGSipv4KeVXq0p0RKs03SpGrOp1CDBRrXjgYaPU/oie2u2mFp7G2w+2dIIwn4mn8lyuKq7Vx9Mgg22IOIEyOJSzZ7W/T2Kz2xSrjIgHiDqp20xwXldu9mDH45ZVEyx7SA4c2PBg9lpbJ3nrMjPEOLXHOOhXO4Myy9PSWNKLlm7H2/Rr5Thd+F2RWw4rnY0rgEpOpc04VAFg7xbwNptw083H9ykmxNtbbNK3EAgu4DiuH2nfvrkl5/tHAZ/oq1es5xLnEkk5yoqlQNzcQPquuOOmtSHcD2Md4yWbQu6h1wntkpXXhOTB6n9EbehhW3O/K8LFOp0TKhc7InLkMgnoORvQNACeowjKGkibKSQQEpJFJBGUgkgSjQlIBCUZQIsURpqYFAoliIAhPBCcUAgDmTqMvn7qPwefoVOEUNG0q1RuhBj0Puuj2Pvc6mcNbER11HrxXP4QU2q0RB45DopZtNO12nvE1zBggzxBEyuSr1ZJc895Rp2r/CfUaJbTaHOnKZIHvn8lnCkX5vPpwSY6SXXEPq3ZOVMdJP5KNluSZcZPVTtYAnqrrfZjWAKRBOCKQKBCKEoAUoShIBA5qCAKKApJSkiI4TU5AhGjSEinQkAgEpyEJQgQRhBOCBBOQhFqAgKOpm4DrKlCiB8/ZpRKcLh7muZid4ZcDhBhpjQkJQkwZJyEmgQKMoIohIBAIoDKRQhJEKUkCigCSUpFAUkEEQwohJIFGhSlFKEAIRBSQBQGEQgCigKSQKUoCSoqep7AfNSJBuZjogTUZUbgdckcDuY9kDiUgVHonNKB0pIIygSRTZSlEOQhIIFAiUkHJFASkgkiP/2Q==",
                        DiaBusquedaCaptura = new DateTime(2021, 1, 1),
                        Trabajo = "Camarero",
                        Work = "Waiter"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 17,
                        Nombre = "Carmen",
                        Apellidos = "Navarro Pérez",
                        Dni = "90123456H",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1989, 10, 12),
                        Direccion = "Calle Nube 951",
                        Address = "Cloud Street 951",
                        NumeroTelefono = 990123456,
                        NumeroCuentaBancaria = "ES990123456",
                        IsPoli = false,
                        IsBusquedaYCaptura = true,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRK9mAH2AZIYbObimNfeWk8nUhVfvmSNUR-1Q&s",
                        DiaBusquedaCaptura = new DateTime(2021, 1, 2),
                        Trabajo = "Politico",
                        Work = "Politician"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 18,
                        Nombre = "Fernando",
                        Apellidos = "Ortiz Sánchez",
                        Dni = "12345678I",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1994, 11, 18),
                        Direccion = "Calle Montaña 258",
                        Address = "Mountain Street 258",
                        NumeroTelefono = 991234567,
                        NumeroCuentaBancaria = "ES991234567",
                        IsPoli = false,
                        IsBusquedaYCaptura = true,
                        IsPeligroso = false,
                        ImagenUrl = "data:image/jpeg;base64,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",
                        DiaBusquedaCaptura = new DateTime(2021, 1, 2),
                        Trabajo = "Camarero",
                        Work = "Waiter"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 19,
                        Nombre = "Elena",
                        Apellidos = "Vega Martínez",
                        Dni = "23456789J",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1987, 12, 24),
                        Direccion = "Calle Bosque 357",
                        Address = "Forest Street 357",
                        NumeroTelefono = 992345678,
                        NumeroCuentaBancaria = "ES992345678",
                        IsPoli = false,
                        IsBusquedaYCaptura = true,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRc5E-KHBLO0f478Ak4EkpAKGF0ovrzNnCaMg&s",
                        DiaBusquedaCaptura = new DateTime(2021, 1, 3),
                        Trabajo = "Camarera",
                        Work = "Waitress"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 20,
                        Nombre = "Pablo",
                        Apellidos = "Gil Hernández",
                        Dni = "34567890K",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1991, 1, 5),
                        Direccion = "Calle Campo 654",
                        Address = "Field Street 654",
                        NumeroTelefono = 993456789,
                        NumeroCuentaBancaria = "ES993456789",
                        IsPoli = false,
                        IsBusquedaYCaptura = true,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6ojdFqgzvT_M7dTd5LaKMv56UmSnWMjjClg&s",
                        DiaBusquedaCaptura = new DateTime(2021, 1, 3),
                        Trabajo = "Camarero",
                        Work = "Waiter"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 21,
                        Nombre = "Isabel",
                        Apellidos = "Domínguez Pérez",
                        Dni = "45678901L",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1990, 2, 9),
                        Direccion = "Calle Prado 753",
                        Address = "Meadow Street 753",
                        NumeroTelefono = 994567890,
                        NumeroCuentaBancaria = "ES994567890",
                        IsPoli = false,
                        IsBusquedaYCaptura = true,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIgb32UROVofW-VUVfPJVdLLZJn6ZHl8QGxQ&s",
                        DiaBusquedaCaptura = new DateTime(2021, 1, 4),
                        Trabajo = "Científica",
                        Work = "Scientist"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 22,
                        Nombre = "Manuel",
                        Apellidos = "Hernández Ruiz",
                        Dni = "56789012M",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1995, 3, 17),
                        Direccion = "Calle Laguna 159",
                        Address = "Lagoon Street 159",
                        NumeroTelefono = 995678901,
                        NumeroCuentaBancaria = "ES995678901",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRK9jiobxMB4C1kFPubJv890GZwuv3bUlM0SA&s",
                        Trabajo = "Camarero",
                        Work = "Waiter"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 23,
                        Nombre = "Sofía",
                        Apellidos = "Romero Gómez",
                        Dni = "67890123N",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1998, 4, 28),
                        Direccion = "Calle Valle 753",
                        Address = "Valley Street 753",
                        NumeroTelefono = 996789012,
                        NumeroCuentaBancaria = "ES996789012",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRjjgc1d_Eai9k7TmlCafGNQq-O4ASFludeog&s",
                        Trabajo = "Electricista",
                        Work = "Electrician"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 24,
                        Nombre = "Adrián",
                        Apellidos = "Iglesias Torres",
                        Dni = "78901234O",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1992, 5, 19),
                        Direccion = "Calle Cielo 951",
                        Address = "Sky Street 951",
                        NumeroTelefono = 997890123,
                        NumeroCuentaBancaria = "ES997890123",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQvKeb-c3leaFUVrxSbzObbgevMyZjdODmFrA&s",
                        Trabajo = "Médico",
                        Work = "Doctor"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 25,
                        Nombre = "Raquel",
                        Apellidos = "Ortega López",
                        Dni = "89012345P",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1994, 6, 30),
                        Direccion = "Calle Viento 357",
                        Address = "Wind Street 357",
                        NumeroTelefono = 998901234,
                        NumeroCuentaBancaria = "ES998901234",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQv7xHFeF4ibtgeULLcqyFVIPNYVewbXokiiw&s",
                        Trabajo = "Camarera",
                        Work = "Waitress"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 26,
                        Nombre = "Javier",
                        Apellidos = "Méndez Pérez",
                        Dni = "90123456Q",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1985, 7, 11),
                        Direccion = "Calle Tranquila 258",
                        Address = "Quiet Street 258",
                        NumeroTelefono = 999012345,
                        NumeroCuentaBancaria = "ES999012345",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcREvIyDecVTjMMIBQYE-qiv6jeIqdXPUbcJfA&s",
                        Trabajo = "Camarero",
                        Work = "Waiter"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 27,
                        Nombre = "Verónica",
                        Apellidos = "Castro Ruiz",
                        Dni = "12345678R",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1991, 8, 21),
                        Direccion = "Calle Esperanza 159",
                        Address = "Hope Street 159",
                        NumeroTelefono = 910123456,
                        NumeroCuentaBancaria = "ES910123456",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSsI-bH9j_chxKJJFNMkPzptBqTY05fp2B7lg&s",
                        Trabajo = "Camarera",
                        Work = "Waitress"
                    },
                    new Ciudadano
                    {
                        IdCiudadano = 28,
                        Nombre = "Sergio",
                        Apellidos = "Núñez García",
                        Dni = "23456789S",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1989, 9, 12),
                        Direccion = "Calle Horizonte 753",
                        Address = "Horizon Street 753",
                        NumeroTelefono = 921234567,
                        NumeroCuentaBancaria = "ES921234567",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRR_p5mFZzr6DEMSbALEAowWDEOODD6rA-NKQ&s",
                        Trabajo = "Camarero",
                        Work = "Waiter"

                    },
                    new Ciudadano
                    {
                        IdCiudadano = 29,
                        Nombre = "Patricia",
                        Apellidos = "Moreno Pérez",
                        Dni = "34567890T",
                        Genero = "Mujer",
                        Gender = "Woman",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1986, 10, 4),
                        Direccion = "Calle Aurora 951",
                        Address = "Dawn Street 951",
                        NumeroTelefono = 932345678,
                        NumeroCuentaBancaria = "ES932345678",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBCNa5wfAAPb0-Pg9A41k79JjqS2ebSfCP9A&s",
                        Trabajo = "Camarera",
                        Work = "Waitress"

                    },
                    new Ciudadano
                    {
                        IdCiudadano = 30,
                        Nombre = "Antonio",
                        Apellidos = "Molina García",
                        Dni = "45678901U",
                        Genero = "Hombre",
                        Gender = "Man",
                        Nacionalidad = "Española",
                        Nationality = "Spanish",
                        FechaNacimiento = new DateTime(1997, 11, 13),
                        Direccion = "Calle Refugio 258",
                        Address = "Refuge Street 258",
                        NumeroTelefono = 943456789,
                        NumeroCuentaBancaria = "ES943456789",
                        IsPoli = false,
                        IsBusquedaYCaptura = false,
                        IsPeligroso = false,
                        ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrnuwpY_UyuJED1mMMRwdb-ypqckTsKF4T_w&s",
                        Trabajo = "Enfermero",
                        Work = "Nurse"
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
                    new CodigoPenal { IdCodigoPenal = 45, Articulo = "Art. 4.7", Description = "Terrorist attack", Descripcion = "Atentado terrorista", Precio = 100000, Sentencia = "25" },
                    new CodigoPenal { IdCodigoPenal = 46, Articulo = "Art. 4.8", Description = "Attempting against the life or physical integrity of several people and/or public officials through the armed organization of several individuals", Descripcion = "Atentar contra la vida o integridad fisica de varios personas y/o funcionarios publicos mediante la organizacion armada de varios individuos", Precio = 100000, Sentencia = "35 " },
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
                new Rango { IdRango = 4, Name = "Inspector", Nombre = "Inspector", Salario = 1765, isLocal = true },
                new Rango { IdRango = 5, Name = "Mayor", Nombre = "Intendente", Salario = 2028, isLocal = true },
                new Rango { IdRango = 6, Name = "Super mayor", Nombre = "Superintendente", Salario = 2142, isLocal = true }
            );

            modelBuilder.Entity<Permiso>().HasData(
                new Permiso { IdPermiso = 1, Name = "Add police", Nombre = "Añadir policia" },
                new Permiso { IdPermiso = 2, Name = "Remove police", Nombre = "Quitar policia" },
                new Permiso { IdPermiso = 3, Name = "Modify police", Nombre = "Modificar policia" },
                new Permiso { IdPermiso = 4, Name = "Create fine", Nombre = "Crear multa" },
                new Permiso { IdPermiso = 5, Name = "Manage Range", Nombre = "Gestionar rangos" },
                new Permiso { IdPermiso = 6, Name = "Change police fields", Nombre = "Cambiar campos policia" }
            );

            modelBuilder.Entity<RangoPermiso>().HasData(
                new RangoPermiso { IdPermiso = 4, IdRango = 2 },
                new RangoPermiso { IdPermiso = 1, IdRango = 3 },
                new RangoPermiso { IdPermiso = 4, IdRango = 3 },
                new RangoPermiso { IdPermiso = 1, IdRango = 4 },
                new RangoPermiso { IdPermiso = 2, IdRango = 4 },
                new RangoPermiso { IdPermiso = 4, IdRango = 4 },
                new RangoPermiso { IdPermiso = 1, IdRango = 5 },
                new RangoPermiso { IdPermiso = 2, IdRango = 5 },
                new RangoPermiso { IdPermiso = 3, IdRango = 5 },
                new RangoPermiso { IdPermiso = 4, IdRango = 5 },
                new RangoPermiso { IdPermiso = 6, IdRango = 5 },
                new RangoPermiso { IdPermiso = 1, IdRango = 6 },
                new RangoPermiso { IdPermiso = 2, IdRango = 6 },
                new RangoPermiso { IdPermiso = 3, IdRango = 6 },
                new RangoPermiso { IdPermiso = 4, IdRango = 6 },
                new RangoPermiso { IdPermiso = 6, IdRango = 6 },
                new RangoPermiso { IdPermiso = 5, IdRango = 6 }
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