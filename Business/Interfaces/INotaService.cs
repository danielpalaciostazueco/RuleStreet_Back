using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface INotaService
    {
        List<Nota> GetAll();
        Nota? Get(int id);
        void Update(NotaPostDTO nota);
        void Delete(int id);
        void Add(NotaPostDTO nota);
   
    }
}