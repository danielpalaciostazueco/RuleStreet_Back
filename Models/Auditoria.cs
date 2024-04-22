using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class Auditoria
{
    [Key]
    public int IdAuditoria{ get; set; }
    public string? Titulo {get; set;}
    public string? Descripcion {get; set;}
    public DateTime? Fecha {get; set;} 
    
    [ForeignKey("Policia")]
    public int? IdPolicia { get; set; }
    public  Policia? Policia { get; set; }
}

