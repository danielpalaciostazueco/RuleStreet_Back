using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IDenunciaService
    {
        List<Denuncia> GetAll();
        Denuncia? Get(int id);
        void Add(DenunciaPostDTO denuncia);
        void Delete(int id);
    }
}