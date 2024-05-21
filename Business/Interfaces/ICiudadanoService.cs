using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface ICiudadanoService
    {
        List<CiudadanoDTO> GetAll();
        List<CiudadanoDTO> GetAllBusquedaCaptura();
        List<DeudoresDTO> GetAllDeudores();
        CiudadanoDTO? Get(int id);
        void Add(CiudadanoPostDTO ciudadanoDTO);
        void Update(CiudadanoPostDTO ciudadanoPostDTO);
        void Delete(int id);
        CiudadanoDTO? GetByDni(string dni);
      

    }
}