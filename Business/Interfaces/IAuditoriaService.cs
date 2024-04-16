using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IAuditoriaService
    {
        List<AuditoriaDTO> GetAll();
        AuditoriaDTO? Get(int id);
        void Add(AuditoriaPostDTO auditoria);
        void Update(Auditoria auditoria);
        void Delete(int id);
    }
}