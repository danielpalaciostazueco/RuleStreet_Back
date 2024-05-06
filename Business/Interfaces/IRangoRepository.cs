using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IRangoService
    {
        List<RangoDto> GetAll();
        RangoDto? Get(int id);
        void Update(Rango rango);
    }
}