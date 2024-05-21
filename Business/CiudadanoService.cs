using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.IO.Compression;

namespace RuleStreet.Business
{
    public class CiudadanoService : ICiudadanoService
    {
        private readonly ICiudadanoRepository _ciudadanoRepository;
        private readonly IMultaRepository _multaRepository;
        private readonly ICodigoPenalRepository _codigoPenalRepository;
        private readonly ILogger<CiudadanoService> _logger;


        public CiudadanoService(ICiudadanoRepository ciudadanoRepository, ILogger<CiudadanoService> logger, IMultaRepository multaRepository, ICodigoPenalRepository codigoPenalRepository)
        {
            _ciudadanoRepository = ciudadanoRepository;
            _logger = logger;
            _multaRepository = multaRepository;
            _codigoPenalRepository = codigoPenalRepository;
        }

        public List<CiudadanoDTO> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las ciudadanos");
                return _ciudadanoRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las ciudadanos");
                throw;
            }
        }


        public List<CiudadanoDTO> GetAllBusquedaCaptura()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las ciudadanos que están en busqueda y captura");
                return _ciudadanoRepository.GetAll().Where(x => x.IsBusquedaYCaptura == true).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas los ciudadanos que están en busqueda y captura");
                throw;
            }
        }

        public List<DeudoresDTO> GetAllDeudores()
        {
            try
            {
                var multas = _multaRepository.GetAll(0);
                var ciudadanos = _ciudadanoRepository.GetAll().Where(x => x.Multas?.Any(m => (bool)!m.Pagada) == true).ToList();
                var deudores = new List<DeudoresDTO>();
                var codigoPenal = _codigoPenalRepository.GetAll();
                List<Multa> multasPendientes = new List<Multa>();


                foreach (var ciudadano in ciudadanos)
                {
                    multasPendientes = multas.Where(x => x.IdCiudadano == ciudadano.IdCiudadano && x.Pagada == false).ToList();
                    decimal cantidad = 0;

                    foreach(var multa in multasPendientes)
                    {
                        cantidad += (decimal)multa.CodigoPenal.Precio;
                    }
                    var deudor = new DeudoresDTO
                    {

                        IdCiudadano = ciudadano.IdCiudadano,
                        Nombre = ciudadano.Nombre,
                        Apellidos = ciudadano.Apellidos,
                        FechaNacimiento = (DateTime)ciudadano.FechaNacimiento,
                        Dni = ciudadano.Dni,
                        Genero = ciudadano.Genero,
                        Nacionalidad = ciudadano.Nacionalidad,
                        Pagada = multas.Any(x => x.IdCiudadano == ciudadano.IdCiudadano && x.Pagada == false),
                        Cantidad = cantidad,
                        ImagenUrl = ciudadano.ImagenUrl
                    };
                    deudores.Add(deudor);
                    multasPendientes.Clear();
                }

                return deudores;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las personas con multas pendientes");
                throw;
            }
        }

        
     
        public CiudadanoDTO? Get(int id)
        {
            try
            {
                return _ciudadanoRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la ciudadano por id");
                throw;
            }

        }


        public CiudadanoDTO? GetByDni(string dni)
        {
            try
            {
                return _ciudadanoRepository.GetByDni(dni);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la ciudadano por dni");
                throw;
            }

        }

        public void Update(CiudadanoPostDTO ciudadanoPostDTO)
        {
            try
            {
                var ciudadano = new Ciudadano
                {
                    IdCiudadano = ciudadanoPostDTO.IdCiudadano,
                    Nombre = ciudadanoPostDTO.Nombre,
                    Apellidos = ciudadanoPostDTO.Apellidos,
                    Dni = ciudadanoPostDTO.Dni,
                    Genero = ciudadanoPostDTO.Genero,
                    Nacionalidad = ciudadanoPostDTO.Nacionalidad,
                    FechaNacimiento = ciudadanoPostDTO.FechaNacimiento,
                    Direccion = ciudadanoPostDTO.Direccion,
                    NumeroTelefono = ciudadanoPostDTO.NumeroTelefono,
                    NumeroCuentaBancaria = ciudadanoPostDTO.NumeroCuentaBancaria,
                    IsPoli = ciudadanoPostDTO.IsPoli,
                    IsBusquedaYCaptura = ciudadanoPostDTO.IsBusquedaYCaptura,
                    IsPeligroso = ciudadanoPostDTO.IsPeligroso,
                    
                };

                _ciudadanoRepository.Update(ciudadano);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando al ciudadano por id");
                throw;
            }
        }

        public void Add(CiudadanoPostDTO ciudadanoPostDTO)
        {
            try
            {
                var ciudadano = new Ciudadano
                {
                    Nombre = ciudadanoPostDTO.Nombre,
                    Apellidos = ciudadanoPostDTO.Apellidos,
                    Dni = ciudadanoPostDTO.Dni,
                    Genero = ciudadanoPostDTO.Genero,
                    Nacionalidad = ciudadanoPostDTO.Nacionalidad,
                    FechaNacimiento = ciudadanoPostDTO.FechaNacimiento,
                    Direccion = ciudadanoPostDTO.Direccion,
                    NumeroTelefono = ciudadanoPostDTO.NumeroTelefono,
                    NumeroCuentaBancaria = ciudadanoPostDTO.NumeroCuentaBancaria,
                    IsPoli = ciudadanoPostDTO.IsPoli,
                    IsBusquedaYCaptura = ciudadanoPostDTO.IsBusquedaYCaptura,
                    IsPeligroso = ciudadanoPostDTO.IsPeligroso,
                };
                _ciudadanoRepository.Add(ciudadano);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la ciudadano");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _ciudadanoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando al ciudadano");
                throw;
            }

        }
    }
}
