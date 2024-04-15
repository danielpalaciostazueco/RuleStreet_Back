using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class RangoPermiso
{
    [Key]
    public int IdRangoPermiso{ get; set; }
    [ForeignKey("Rango")]
    public int? IdRango { get; set; }
    public Rango? rango {get; set;}
    public int IdPermiso {get; set;}
    public Permiso? permiso {get; set;}
}

