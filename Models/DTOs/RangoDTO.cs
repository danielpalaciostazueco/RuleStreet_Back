using RuleStreet.Models;
using System;
using System.Collections.Generic;

public class RangoDTO
{
    public int IdRango { get; set; }
    public string? Nombre { get; set; }
    public string? Name { get; set; }
    public int Salario { get; set; }
    public bool isLocal { get; set; }
    public List<PermisoDTO>? Permisos { get; set; }
}
