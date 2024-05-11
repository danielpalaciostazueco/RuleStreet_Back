using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IPermisoService
    {
        List<PermisoDTO> GetAll();
        PermisoDTO? Get(int id);
        void Update(Permiso permiso);

        void Add(Permiso permiso);

        void Delete(int id);


    }
}