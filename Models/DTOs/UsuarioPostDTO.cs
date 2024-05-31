using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class UsuarioPostDTO
{
    public int IdUsuario { get; set; }


    public string? Dni { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Contrasena { get; set; }
}
