using RuleStreet.Models;

public class PoliciaDTO
{
    public int IdPolicia { get; set; }
    public int IdCiudadano { get; set; }
    public string Rango { get; set; }
    public string NumeroPlaca { get; set; }
    public Ciudadano ciudadano { get; set; }
}
