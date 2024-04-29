using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IRangoService
    {
        List<Rango> GetAll();
        Rango? Get(int id);
        void Update(Rango rango);
    }
}