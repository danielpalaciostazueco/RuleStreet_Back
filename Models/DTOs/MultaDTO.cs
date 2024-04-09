using RuleStreet.Models;


public class MultaDTO
{
    public int IdMulta { get; set; }
    public int IdPolicia { get; set; } // Solo el ID de Policia
    public DateTime Fecha { get; set; }
    public DateTime Hora { get; set; }
    public decimal Precio { get; set; }
    public string ArticuloPenal { get; set; }
    public string Descripcion { get; set; }
    public bool Pagada { get; set; }
    public int IdCiudadano { get; set; }
}

