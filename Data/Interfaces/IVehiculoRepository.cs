using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IVehiculoRepository
    {
        List<VehiculoDTO> GetAll();
        VehiculoDTO? Get(int id);
        void Add(VehiculoPostDTO vehiculo);
        void Update(Vehiculo vehiculo);
        void Delete(int id);
    }
}