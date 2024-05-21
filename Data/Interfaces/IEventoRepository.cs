using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IEventoRepository
    {
        List<Evento> GetAll();
        Evento? Get(int id);
        void Add(Evento evento);
        void Update(Evento evento);
        void Delete(int id);
    }
}