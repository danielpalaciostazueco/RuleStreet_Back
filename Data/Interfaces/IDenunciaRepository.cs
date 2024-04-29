using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IDenunciaRepository
    {
        List<Denuncia> GetAll();
        Denuncia? Get(int id);
        void Add(Denuncia denuncia);
        void Delete(int id);
        void Update(Denuncia denuncia);
    }
}