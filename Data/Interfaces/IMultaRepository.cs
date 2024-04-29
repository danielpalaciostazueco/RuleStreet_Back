using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IMultaRepository
    {
        List<Multa> GetAll();
        Multa? Get(int id);
        void Add(Multa multa);
        void Update(Multa multa);
        void Delete(int id);
    }
}