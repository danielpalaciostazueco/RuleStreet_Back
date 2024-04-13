using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IPoliciaService
    {
        List<PoliciaDTO> GetAll();
        PoliciaDTO? Get(int id);
        void Update(Policia policia);
        void Delete(int id);
        void Add(PoliciaPostDTO policia);
    }
}