using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [ForeignKey("Policia")]
    public int? IdPolicia { get; set; }
    public virtual Policia? policia { get; set; }

    [ForeignKey("Ciudadano")]
    public int? IdCiudadano { get; set; }
    public Ciudadano? Ciudadano { get; set; }

    public string? Nombre { get; set; }
    public string? Dni { get; set; }

    public string? NombreUsuario { get; set; }
    public string? Contrasena { get; set; }
    public bool? IsPolicia { get; set; }
}
