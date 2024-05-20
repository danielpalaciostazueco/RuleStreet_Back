using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface ICiudadanoRepository
    {
        List<CiudadanoDTO> GetAll();
        CiudadanoDTO? Get(int id);
        void Add(Ciudadano ciudadano);
        void Delete(int id);
        void Update(Ciudadano ciudadano);

        CiudadanoDTO? GetByDni(string dni);

        CiudadanoDTO? GetIdioma(int id);
        List<CiudadanoDTO> GetAllIdioma();

    }
}