using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface INotaRepository
    {
        List<Nota> GetAll();
        Nota? Get(int id);
        void Update(Nota nota);
        void Add(Nota nota);
        void Delete(int id);
    }
}