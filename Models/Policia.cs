using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class Policia
{
    [Key]
    public int IdPolicia { get; set; }

    [ForeignKey("Ciudadano")]
    public int? IdCiudadano { get; set; }

    [ForeignKey("Rango")]
    public int? IdRango { get; set; }
    public virtual Rango? Rango { get; set; }
    public int? NumeroPlaca { get; set; }
    public virtual Ciudadano? Ciudadano { get; set; }

    public string Contrasena { get; set; }
}

