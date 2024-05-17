using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IPoliciaService
    {
        List<PoliciaDTO> GetAll();
        PoliciaDTO? Get(int id);
        void Update(PoliciaPostDTO policia, int id);
        void Delete(int id);
        void Add(PoliciaPostDTO policia);
        bool policiaDuplicado(PoliciaPostDTO policia);
    }
}