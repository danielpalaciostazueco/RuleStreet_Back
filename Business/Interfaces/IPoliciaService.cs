using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IPoliciaService
    {
        List<PoliciaDTO> GetAll();
        Policia? Get(int id);
        void Update(Policia policia);
        void Delete(int id);
    }
}