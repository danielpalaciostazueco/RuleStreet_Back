using System.ComponentModel.DataAnnotations.Schema;
using RuleStreet.Models;


public class DenunciaPostDTO
{

    public int IdDenuncia { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime? Fecha { get; set; }
    public int? IdPolicia { get; set; }
    public int? IdCiudadano { get; set; }

}

