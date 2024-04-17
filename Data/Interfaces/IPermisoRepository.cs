using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IPermisoRepository
    {
        List<Permiso> GetAll();
        Permiso? Get(int id);
        void Update(Permiso permiso);

        void Add(Permiso permiso);
        void Delete(int id);
    }
}