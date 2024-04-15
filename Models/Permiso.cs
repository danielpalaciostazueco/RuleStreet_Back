using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class Permiso
{
    [Key]
    public int IdPermiso{ get; set; }
    public string? Nombre {get; set;}
}

