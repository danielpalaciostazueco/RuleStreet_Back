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

    public string? Rango { get; set; }
    public string? NumeroPlaca { get; set; }
    public virtual Ciudadano? Ciudadano { get; set; }
}

