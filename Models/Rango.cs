using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace RuleStreet.Models;

public class Rango
{
    [Key]
    public int IdRango { get; set; }
    public string? Nombre { get; set; }
    public int? Salario { get; set; }
    public bool? isLocal { get; set; }
    public ICollection<Policia> Policias { get; set; } = new List<Policia>();
    public ICollection<RangoPermiso> RangosPermisos { get; set; } = new List<RangoPermiso>();
}
