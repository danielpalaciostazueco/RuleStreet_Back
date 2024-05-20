using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuleStreet.Models;

public class Evento
{
    [Key]
    public int IdEventos { get; set; }
    public string? Imagen { get; set; }
    public string? Descripcion { get; set; }
    public string? Description { get; set; }
    public DateTime? Fecha { get; set; }

    public object ToList()
    {
        throw new NotImplementedException();
    }
}
