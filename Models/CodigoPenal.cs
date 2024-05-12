using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RuleStreet.Models;
public class CodigoPenal
{
    [Key]
    public int IdCodigoPenal { get; set; }
    public string? Articulo { get; set; }
    public string? Descripcion { get; set; }
    public decimal? Precio { get; set; }
    public string? Sentencia { get; set; }
    public List<Multa> Multas { get; set; } = new List<Multa>();
}
