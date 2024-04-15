using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class VehiculoPostDTO
{
    
    public int IdVehiculo { get; set; }
    public int IdCiudadano {get; set;}
    public string? Matricula { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? Color { get; set; }

 
}
