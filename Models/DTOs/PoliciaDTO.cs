using RuleStreet.Models;

public class PoliciaDTO
{
  public int IdPolicia { get; set; }
  public int IdCiudadano { get; set; }
  public RangoDTO Rango { get; set; }
  public int NumeroPlaca { get; set; }
  public CiudadanoDTO Ciudadano { get; set; }

  public string Contrasena { get; set; }
  public bool IsPolicia { get; set; }


}
