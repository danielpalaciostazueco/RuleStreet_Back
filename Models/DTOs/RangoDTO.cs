using RuleStreet.Models;
using System;
using System.Collections.Generic;

public class RangoDto
{
    public int IdRango { get; set; }
    public string? Nombre { get; set; }
    public int Salario { get; set; }
    public bool isLocal { get; set; }
    public List<PermisoDto>? Permisos { get; set; }
}
