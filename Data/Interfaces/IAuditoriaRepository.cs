using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IAuditoriaRepository
    {
        List<AuditoriaDTO> GetAll();
        AuditoriaDTO? Get(int id);
        void Add(Auditoria auditoria);
        void Delete(int id);
        void Update(Auditoria auditoria);
    }
}