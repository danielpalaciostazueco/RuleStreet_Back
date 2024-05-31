using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class Nota
{
    [Key]
    public int IdNota{ get; set; }
    public string? Titulo {get; set;}
    public string? Title {get; set;}
    public string? Descripcion {get; set;}
    public string? Description {get; set;}
    public DateTime? Fecha {get; set;} 
    
    [ForeignKey("Policia")]
    public int? IdPolicia { get; set; }
    public virtual Policia? policia { get; set; }

    [ForeignKey("Ciudadano")]
    public int? IdCiudadano { get; set; }
    public Ciudadano? ciudadano { get; set; }

}

