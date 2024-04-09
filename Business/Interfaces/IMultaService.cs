using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IMultaService
    {
        List<Multa> GetAll();
        Multa? Get(int id);
        void Update(Multa multa);
        void Delete(int id);
    }
}