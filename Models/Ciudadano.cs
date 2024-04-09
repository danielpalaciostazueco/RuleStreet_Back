using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;
using System.Collections.Generic;
public class Ciudadano
{
    [Key]
    public int IdCiudadano { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Dni { get; set; }
    public string? Genero { get; set; }
    public string? Nacionalidad { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Direccion { get; set; }
    public int? NumeroTelefono { get; set; }
    public string? NumeroCuentaBancaria { get; set; }
    public bool? IsPoli { get; set; }
    public bool? IsBusquedaYCaptura { get; set; }
    public bool? IsPeligroso { get; set; }
    public virtual List<Multa>? Multas { get; set; }
    public virtual List<Vehiculo>? Vehiculos { get; set; }
}
