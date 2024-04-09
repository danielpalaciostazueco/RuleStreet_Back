using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;
public class Denuncia
{
    [Key]
    public int IdDenuncia { get; set; }

    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; }

    [ForeignKey("Policia")]
    public int IdPolicia { get; set; }

    [ForeignKey("Ciudadano")]
    public int IdCiudadano { get; set; }

    public virtual Policia Policia { get; set; }
    public virtual Ciudadano Ciudadano { get; set; }
}