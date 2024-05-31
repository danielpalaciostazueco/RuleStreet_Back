using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class RangoPermiso
{
    [Key]
    public int IdRango { get; set; }
    public Rango? Rango { get; set; }
    public int IdPermiso { get; set; }
    public Permiso? Permiso { get; set; }
}

