using RuleStreet.Models;
public class VehiculoDTO
{
    public int IdVehiculo { get; set; }
    public string? Matricula { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? Color { get; set; }
    public int? IdCiudadano { get; set; }
    public CiudadanoDTO? Ciudadano { get; set; }
}
