using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IVehiculoService
    {
        List<VehiculoDTO> GetAll();
        VehiculoDTO? Get(int id);
        void Update(VehiculoPostDTO vehiculo);
        void Delete(int id);
        void Add(VehiculoPostDTO vehiculoPostDTO);
    
    }
}