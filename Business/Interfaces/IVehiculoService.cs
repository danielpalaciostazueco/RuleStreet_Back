using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IVehiculoService
    {
        List<Vehiculo> GetAll();
        Vehiculo? Get(int id);
        void Update(Vehiculo vehiculo);
        void Delete(int id);
        void Add(VehiculoPostDTO vehiculoPostDTO);
    }
}