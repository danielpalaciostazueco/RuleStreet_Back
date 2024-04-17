using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface ICiudadanoRepository
    {
        List<CiudadanoDTO> GetAll();
        CiudadanoDTO? Get(int id);
        void Add(CiudadanoPostDTO ciudadanoPostDTO);
        void Delete(int id);
        void Update(CiudadanoPostDTO ciudadanoPostDTO);
    }
}