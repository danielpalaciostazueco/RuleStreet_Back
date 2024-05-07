using RuleStreet.Models;

public class PoliciaDTO
{
    public int IdPolicia { get; set; }
    public int IdCiudadano { get; set; }
    public string Rango { get; set; }
    public string Contrasena { get; set; }
    public string NumeroPlaca { get; set; }
    public bool IsPolicia { get; set; }
    public CiudadanoDTO Ciudadano { get; set; }
}
