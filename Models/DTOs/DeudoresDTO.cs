using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using RuleStreet.Models;


public class DeudoresDTO
{
    public int? IdCiudadano { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Dni { get; set; }
    public string? Genero { get; set; }
    public string? Nacionalidad { get; set; }
    public decimal? Cantidad { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public bool? Pagada { get; set; }
    public string? ImagenUrl { get; set; }
}

