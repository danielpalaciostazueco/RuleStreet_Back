﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RuleStreet.Data;

#nullable disable

namespace RuleStreet.Data.Migrations
{
    [DbContext(typeof(RuleStreetAppContext))]
    partial class RuleStreetAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RuleStreet.Models.Ciudadano", b =>
                {
                    b.Property<int>("IdCiudadano")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCiudadano"));

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsBusquedaYCaptura")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPeligroso")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPoli")
                        .HasColumnType("bit");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCuentaBancaria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumeroTelefono")
                        .HasColumnType("int");

                    b.HasKey("IdCiudadano");

                    b.ToTable("Ciudadano");

                    b.HasData(
                        new
                        {
                            IdCiudadano = 1,
                            Apellidos = "Perez",
                            Direccion = "Calle Falsa 123",
                            Dni = "12345678",
                            FechaNacimiento = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Hombre",
                            IsBusquedaYCaptura = false,
                            IsPeligroso = false,
                            IsPoli = false,
                            Nacionalidad = "Español",
                            Nombre = "Juan",
                            NumeroCuentaBancaria = "ES123456789",
                            NumeroTelefono = 123456789
                        },
                        new
                        {
                            IdCiudadano = 2,
                            Apellidos = "Gonzalez",
                            Direccion = "Calle Falsa 123",
                            Dni = "87654321",
                            FechaNacimiento = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Mujer",
                            IsBusquedaYCaptura = false,
                            IsPeligroso = false,
                            IsPoli = false,
                            Nacionalidad = "Española",
                            Nombre = "Maria",
                            NumeroCuentaBancaria = "ES987654321",
                            NumeroTelefono = 987654321
                        });
                });

            modelBuilder.Entity("RuleStreet.Models.CodigoPenal", b =>
                {
                    b.Property<int>("IdCodigoPenal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCodigoPenal"));

                    b.Property<string>("Articulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sentencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCodigoPenal");

                    b.ToTable("CodigoPenal");

                    b.HasData(
                        new
                        {
                            IdCodigoPenal = 1,
                            Articulo = "Art. 1.1",
                            Descripcion = "Uso excesivo del claxón",
                            Precio = 500m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 2,
                            Articulo = "Art. 1.2",
                            Descripcion = "Giro indebido",
                            Precio = 300m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 3,
                            Articulo = "Art. 1.3",
                            Descripcion = "Circular en sentido contrario",
                            Precio = 700m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 4,
                            Articulo = "Art. 1.4",
                            Descripcion = "Estacionar en zonas no habitadas y obstruir la circulación",
                            Precio = 500m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 5,
                            Articulo = "Art. 1.5",
                            Descripcion = "Ignorar señales de tránsito",
                            Precio = 500m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 6,
                            Articulo = "Art. 1.6",
                            Descripcion = "Saltarse un semáforo",
                            Precio = 450m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 7,
                            Articulo = "Art. 1.7",
                            Descripcion = "No ceder el paso a vehículos de emergencia",
                            Precio = 550m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 8,
                            Articulo = "Art. 1.8",
                            Descripcion = "Realizar adelantamiento indebido",
                            Precio = 350m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 9,
                            Articulo = "Art. 1.9",
                            Descripcion = "Circular marcha atrás",
                            Precio = 800m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 10,
                            Articulo = "Art. 1.10",
                            Descripcion = "Ignorar señales de los agentes que regulan la circulacion",
                            Precio = 500m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 11,
                            Articulo = "Art. 1.11",
                            Descripcion = "Saltarse / omitir un control de trafico",
                            Precio = 500m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 12,
                            Articulo = "Art. 1.12",
                            Descripcion = "Conducir un vehiculo en malas condiciones",
                            Precio = 1000m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 13,
                            Articulo = "Art. 1.13",
                            Descripcion = "Exceso de velocidad en vias urbanas",
                            Precio = 800m,
                            Sentencia = "5 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 14,
                            Articulo = "Art. 1.14",
                            Descripcion = "Condución temeraria",
                            Precio = 1500m,
                            Sentencia = "10 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 15,
                            Articulo = "Art. 1.15",
                            Descripcion = "Exceso de velocidad en vias secundarias",
                            Precio = 1000m,
                            Sentencia = "10 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 16,
                            Articulo = "Art. 1.16",
                            Descripcion = "Conducir bajo los efectos de drogas/alcohol",
                            Precio = 1500m,
                            Sentencia = "10 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 17,
                            Articulo = "Art. 1.17",
                            Descripcion = "Circular por zonas no habilitadas para ello",
                            Precio = 1000m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 18,
                            Articulo = "Art. 1.18",
                            Descripcion = "Circular sin casco para motocicleta",
                            Precio = 500m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 19,
                            Articulo = "Art. 1.18.1",
                            Descripcion = "Circular sin licencia de conducir",
                            Precio = 550m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 20,
                            Articulo = "Art. 2.1",
                            Descripcion = "Alteración del orden público",
                            Precio = 3500m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 21,
                            Articulo = "Art. 2.2",
                            Descripcion = "Racismo",
                            Precio = 5000m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 22,
                            Articulo = "Art. 2.3",
                            Descripcion = "Faltas de respeto a otro civil",
                            Precio = 2500m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 23,
                            Articulo = "Art. 2.4",
                            Descripcion = "Dañar mobiliario urbano",
                            Precio = 1700m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 24,
                            Articulo = "Art. 2.5",
                            Descripcion = "Acoso psicológico",
                            Precio = 6000m,
                            Sentencia = "5 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 25,
                            Articulo = "Art. 2.6",
                            Descripcion = "Amenaza de muerte a un civil",
                            Precio = 2000m,
                            Sentencia = "5 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 26,
                            Articulo = "Art. 2.7",
                            Descripcion = "Suplantación de identidad",
                            Precio = 6000m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 27,
                            Articulo = "Art. 2.8",
                            Descripcion = "Circular por la via pública con el rostro oculto",
                            Precio = 1000m,
                            Sentencia = "5 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 28,
                            Articulo = "Art. 2.9",
                            Descripcion = "Circular en la via pública desnudo o semi-desnudo",
                            Precio = 1200m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 29,
                            Articulo = "Art. 2.10",
                            Descripcion = "Circular en la via pública sin camiseta",
                            Precio = 120m,
                            Sentencia = "0 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 30,
                            Articulo = "Art. 2.11",
                            Descripcion = "Acoso sexual",
                            Precio = 30000m,
                            Sentencia = "100 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 31,
                            Articulo = "Art. 2.12",
                            Descripcion = "Violar una orden de alejamiento con sentencia firme",
                            Precio = 25000m,
                            Sentencia = "80 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 32,
                            Articulo = "Art. 2.13",
                            Descripcion = "Negativa a identificarse",
                            Precio = 1000m,
                            Sentencia = "7 meses"
                        },
                        new
                        {
                            IdCodigoPenal = 33,
                            Articulo = "Art. 2.14",
                            Descripcion = "Obstrucción a la justicia",
                            Precio = 2500m,
                            Sentencia = "10 meses"
                        });
                });

            modelBuilder.Entity("RuleStreet.Models.Multa", b =>
                {
                    b.Property<int>("IdMulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMulta"));

                    b.Property<string>("ArticuloPenal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CiudadanoIdCiudadano")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Hora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCiudadano")
                        .HasColumnType("int");

                    b.Property<int>("IdPolicia")
                        .HasColumnType("int");

                    b.Property<bool?>("Pagada")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdMulta");

                    b.HasIndex("CiudadanoIdCiudadano");

                    b.HasIndex("IdPolicia");

                    b.ToTable("Multa");
                });

            modelBuilder.Entity("RuleStreet.Models.Policia", b =>
                {
                    b.Property<int>("IdPolicia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPolicia"));

                    b.Property<int?>("IdCiudadano")
                        .HasColumnType("int");

                    b.Property<string>("NumeroPlaca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rango")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPolicia");

                    b.HasIndex("IdCiudadano");

                    b.ToTable("Policia");
                });

            modelBuilder.Entity("RuleStreet.Models.Multa", b =>
                {
                    b.HasOne("RuleStreet.Models.Ciudadano", null)
                        .WithMany("Multas")
                        .HasForeignKey("CiudadanoIdCiudadano");

                    b.HasOne("RuleStreet.Models.Policia", "Policia")
                        .WithMany()
                        .HasForeignKey("IdPolicia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policia");
                });

            modelBuilder.Entity("RuleStreet.Models.Policia", b =>
                {
                    b.HasOne("RuleStreet.Models.Ciudadano", "Ciudadano")
                        .WithMany()
                        .HasForeignKey("IdCiudadano");

                    b.Navigation("Ciudadano");
                });

            modelBuilder.Entity("RuleStreet.Models.Ciudadano", b =>
                {
                    b.Navigation("Multas");
                });
#pragma warning restore 612, 618
        }
    }
}
