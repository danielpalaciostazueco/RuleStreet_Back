using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IVehiculoRepository
    {
        List<Vehiculo> GetAll();
        Vehiculo? Get(int id);
        void Add(Vehiculo vehiculo);
        void Update(Vehiculo vehiculo);
        void Delete(int id);
    }
}