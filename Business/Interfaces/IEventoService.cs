using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IEventoService
    {
        List<Evento> GetAll();
        Evento? Get(int id);
        void Update(Evento evento);
        void Delete(int id);
        void Add(Evento evento);
    }
}