using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class Rango
{
    [Key]
    public int IdRango{ get; set; }

    [ForeignKey("Policia")]
    public int? IdPolicia { get; set; }
    public Policia? policia {get; set;}
    public string? Nombre { get; set; }
    public int? Salario { get; set; }
    public bool? isLocal {get; set;}
}

