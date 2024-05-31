using System.ComponentModel.DataAnnotations.Schema;
using RuleStreet.Models;


public class MultaPostDTO
{
    public int IdMulta { get; set; }
    public int? IdPolicia { get; set; }
    public DateTime? Fecha { get; set; }
    public int? IdCodigoPenal  { get; set; }
    public bool? Pagada { get; set; }
    public int? IdCiudadano { get; set; }
}

