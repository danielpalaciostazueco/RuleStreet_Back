
using Microsoft.EntityFrameworkCore;
using RuleStreet.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RuleStreet.Data;


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

        public List<VehiculoDTO> GetAll()
        {
            var vehiculos = _context.Vehiculo
                .Include(v => v.Ciudadano)
                .Select(v => new VehiculoDTO
                {
                    IdVehiculo = v.IdVehiculo,
                    Matricula = v.Matricula,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    Color = v.Color,
                    EnColor = v.EnColor,
                    IdCiudadano = v.IdCiudadano,
                    Ciudadano = new CiudadanoDTO
                    {
                        IdCiudadano = v.Ciudadano.IdCiudadano,
                        Nombre = v.Ciudadano.Nombre,
                        Apellidos = v.Ciudadano.Apellidos,
                        Dni = v.Ciudadano.Dni,
                        Genero = v.Ciudadano.Genero,
                        Gender = v.Ciudadano.Gender,
                        Nacionalidad = v.Ciudadano.Nacionalidad,
                        Nationality = v.Ciudadano.Nationality,
                        FechaNacimiento = v.Ciudadano.FechaNacimiento,
                        Direccion = v.Ciudadano.Direccion,
                        Address = v.Ciudadano.Address,
                        NumeroTelefono = v.Ciudadano.NumeroTelefono,
                        NumeroCuentaBancaria = v.Ciudadano.NumeroCuentaBancaria,
                        IsPoli = v.Ciudadano.IsPoli,
                        IsBusquedaYCaptura = v.Ciudadano.IsBusquedaYCaptura,
                        IsPeligroso = v.Ciudadano.IsPeligroso
                    }
                })
                .ToList();

            return vehiculos;
        }


        

        public VehiculoDTO Get(int id)
        {
            try
            {
                var vehiculo = _context.Vehiculo
                    .AsNoTracking()
                    .Where(v => v.IdVehiculo == id)
                    .Include(v => v.Ciudadano)
                    .Select(v => new VehiculoDTO
                    {
                        IdVehiculo = v.IdVehiculo,
                        Matricula = v.Matricula,
                        Marca = v.Marca,
                        Modelo = v.Modelo,
                        Color = v.Color,
                        EnColor = v.EnColor,
                        IdCiudadano = v.IdCiudadano,
                        Ciudadano = new CiudadanoDTO
                        {
                            IdCiudadano = v.Ciudadano.IdCiudadano,
                            Nombre = v.Ciudadano.Nombre,
                            Apellidos = v.Ciudadano.Apellidos,
                            Dni = v.Ciudadano.Dni,
                            Genero = v.Ciudadano.Genero,
                            Gender = v.Ciudadano.Gender,
                            Nacionalidad = v.Ciudadano.Nacionalidad,
                            Nationality = v.Ciudadano.Nationality,
                            FechaNacimiento = v.Ciudadano.FechaNacimiento,
                            Direccion = v.Ciudadano.Direccion,
                            Address = v.Ciudadano.Address,
                            NumeroTelefono = v.Ciudadano.NumeroTelefono,
                            NumeroCuentaBancaria = v.Ciudadano.NumeroCuentaBancaria,
                            IsPoli = v.Ciudadano.IsPoli,
                            IsBusquedaYCaptura = v.Ciudadano.IsBusquedaYCaptura,
                            IsPeligroso = v.Ciudadano.IsPeligroso
                        }
                    })
                    .FirstOrDefault();

                return vehiculo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el vehiculo.");
                throw;
            }
        }
        public void Add(Vehiculo vehiculo)
        {
            try
            {
                _context.Vehiculo.Add(vehiculo);
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
