using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface ICiudadanoRepository
    {
        List<CiudadanoDTO> GetAll();
        Ciudadano? Get(int id);
        void Add(Ciudadano ciudadano);
        void Delete(int id);
        void Update(Ciudadano ciudadano);
    }
}