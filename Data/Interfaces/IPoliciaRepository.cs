using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IPoliciaRepository
    {
        List<PoliciaDTO> GetAll();
        PoliciaDTO? Get(int id);
        void Add(Policia policia);
        void Delete(int id);
        void Update(Policia policia, int id);
    }
}