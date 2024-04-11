
using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;
using RuleStreet.Business;

namespace RuleStreet.Data
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly RuleStreetAppContext _context;
        private readonly ILogger<VehiculoRepository> _logger;


        public VehiculoRepository(RuleStreetAppContext context, ILogger<VehiculoRepository> logger)
        {

            _context = context;
            _logger = logger;
        }

        public List<Vehiculo> GetAll()
        {

            return _context.Vehiculo.ToList();



        }

        public Vehiculo Get(int id)
        {
            try
            {
                return _context.Vehiculo.AsNoTracking().FirstOrDefault(Vehiculo => Vehiculo.IdVehiculo == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo el vehiculo por id.");
                throw;

            }
        }


        public void Add(VehiculoPostDTO vehiculo)
        {
            try
            {
                 var Vehiculo = new Vehiculo(){
                    IdVehiculo = vehiculo.IdVehiculo,
                    IdCiudadano = vehiculo.IdCiudadano,
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    Color = vehiculo.Color,
                };
                _context.Vehiculo.Add(Vehiculo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir el vehiculo.");
                throw;
            }
        }

        public void Update(Vehiculo vehiculo)
        {
            try
            {
                _context.Entry(vehiculo).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al añadir el vehiculo.");
                throw;
            }
        }



        public void Delete(int id)
        {
            try
            {
                var vehiculo = _context.Vehiculo.FirstOrDefault(Vehiculo => Vehiculo.IdVehiculo == id);
                _context.Vehiculo.Remove(vehiculo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el vehiculo.");
                throw;

            }
        }

    }
}
