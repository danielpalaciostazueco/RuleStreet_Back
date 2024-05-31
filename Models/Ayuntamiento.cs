using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class Ayuntamiento
{
    [Key]
    public int IdUsuarioAyuntamiento{ get; set; }
    public string? Dni {get; set;}
    public string? Contrasena {get; set;}
}

