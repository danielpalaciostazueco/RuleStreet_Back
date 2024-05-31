using System.ComponentModel.DataAnnotations.Schema;
using RuleStreet.Models;


public class MultaDTO
{
    public int IdMulta { get; set; }
    public int? IdPolicia { get; set; }
    public DateTime? Fecha { get; set; }
    public CodigoPenalDTO CodigoPenal { get; set; }
    public bool? Pagada { get; set; }

    public int? IdCiudadano { get; set; }


}

