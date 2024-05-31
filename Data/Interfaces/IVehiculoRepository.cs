using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface IVehiculoRepository
    {
        List<VehiculoDTO> GetAll();
        VehiculoDTO? Get(int id);
        void Add(Vehiculo vehiculo);
        void Update(Vehiculo vehiculo);
        void Delete(int id);
    }
}