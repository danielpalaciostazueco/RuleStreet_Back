using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuleStreet.Models;

public class Multa
{
    [Key]
    public int IdMulta { get; set; }


    [ForeignKey("Policia")]
    public int IdPolicia { get; set; }
    public Policia? Policia { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Precio { get; set; }
    public string? ArticuloPenal { get; set; }
    public string? Descripcion { get; set; }
    public bool? Pagada { get; set; }

    [ForeignKey("Ciudadano")]
    public int? IdCiudadano { get; set; }
    public Ciudadano? Ciudadano { get; set; }

}
