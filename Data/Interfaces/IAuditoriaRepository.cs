using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IAuditoriaRepository
    {
        List<Auditoria> GetAll();
        Auditoria? Get(int id);
        void Add(Auditoria auditoria);
        void Delete(int id);
        void Update(Auditoria auditoria);
    }
}