using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;

public class Vehiculo
{
    [Key]
    public int IdVehiculo { get; set; }

    public string Matricula { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Color { get; set; }

    [ForeignKey("Ciudadano")]
    public int IdCiudadano { get; set; }
    public virtual Ciudadano Ciudadano { get; set; }
}
