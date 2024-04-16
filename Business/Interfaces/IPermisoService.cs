using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IPermisoService
    {
        List<Permiso> GetAll();
        Permiso? Get(int id);
        void Update(Permiso permiso);

    
    }
}