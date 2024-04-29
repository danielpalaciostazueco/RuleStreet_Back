using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IRangoRepository
    {
        List<Rango> GetAll();
        Rango? Get(int id);
        void Update(Rango rango);
    }
}