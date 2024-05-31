using RuleStreet.Models;
using System;
using System.Collections.Generic;

public class AuditoriaDTO
{
    public int IdAuditoria { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime? Fecha { get; set; }
    public int? IdPolicia {get; set;}
    public Policia? policia {get; set;}
}