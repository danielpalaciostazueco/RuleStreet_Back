using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface ICiudadanoService
    {
        List<CiudadanoDTO> GetAll();
        Ciudadano? Get(int id);
        void Update(Ciudadano ciudadano);
        void Delete(int id);
    }
}