using RuleStreet.Models;
using System;
using System.Collections.Generic;

public class PoliciaPostDTO
{
    public int? IdPolicia { get; set; }
    public int? IdCiudadano { get; set; }
    public string? Rango { get; set; }
    public string? NumeroPlaca { get; set; }
}