using RuleStreet.Models;

public class NotaPostDTO
{

    public int IdNota { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime? Fecha { get; set; }

    public int? IdPolicia { get; set; }
    public int? IdCiudadano { get; set; }
}
