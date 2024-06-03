using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.IO.Compression;
using System.Text.Json;

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
            _logger.LogInformation("Iniciando método GetAll() en el servicio.");
            var serviceStartTime = DateTime.UtcNow;

            try
            {
                var ciudadanos = _ciudadanoRepository.GetAll();
                var serviceEndTime = DateTime.UtcNow;
                _logger.LogInformation("Datos obtenidos del repositorio en {Duration}ms. Preparando para el retorno. Total de registros recuperados: {Count}.", (serviceEndTime - serviceStartTime).TotalMilliseconds, ciudadanos.Count);

                return ciudadanos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error durante la obtención de datos del repositorio.");
                throw new Exception("Error en la capa de servicio al recuperar ciudadanos.", ex);
            }
            finally
            {
                _logger.LogInformation("Saliendo del método GetAll() en el servicio. Duración total del método: {TotalDuration}ms.", (DateTime.UtcNow - serviceStartTime).TotalMilliseconds);
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

                    foreach (var multa in multasPendientes)
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
            _logger.LogInformation("Iniciando método Get() en el servicio para ID: {Id}", id);
            var serviceStartTime = DateTime.UtcNow;

            try
            {
                var ciudadano = _ciudadanoRepository.Get(id);
                var serviceEndTime = DateTime.UtcNow;

                if (ciudadano == null)
                {
                    _logger.LogWarning("Ciudadano con ID: {Id} no encontrado en el servicio", id);
                }

                _logger.LogInformation("Método Get() en el servicio completado en {Duration}ms para ID: {Id}", (serviceEndTime - serviceStartTime).TotalMilliseconds, id);
                return ciudadano;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener el ciudadano con ID: {Id}", id);
                throw;
            }
            finally
            {
                _logger.LogInformation("Salida del método Get() en el servicio para ID: {Id}. Duración total del servicio: {TotalDuration}ms", id, (DateTime.UtcNow - serviceStartTime).TotalMilliseconds);
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
            var startTime = DateTime.UtcNow;
            _logger.LogInformation("Iniciando la actualización del ciudadano con ID: {Id}", ciudadanoPostDTO.IdCiudadano);
            try
            {
                var originalData = _ciudadanoRepository.Get(ciudadanoPostDTO.IdCiudadano);
                _logger.LogInformation("Datos originales del ciudadano: {OriginalData}", JsonSerializer.Serialize(originalData));

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
                    ImagenUrl = ciudadanoPostDTO.ImagenUrl
                };

                _ciudadanoRepository.Update(ciudadano);
                _logger.LogInformation("Datos del ciudadano actualizados en el repositorio.");
                var updatedData = _ciudadanoRepository.Get(ciudadanoPostDTO.IdCiudadano);
                _logger.LogInformation("Datos actualizados del ciudadano: {UpdatedData}", JsonSerializer.Serialize(updatedData));

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error actualizando el ciudadano con ID: {Id}", ciudadanoPostDTO.IdCiudadano);
                throw;
            }
            finally
            {
                var endTime = DateTime.UtcNow;
                _logger.LogInformation("Actualización del ciudadano completada para ID: {Id}. Duración total del servicio: {TotalDuration}ms", ciudadanoPostDTO.IdCiudadano, (endTime - startTime).TotalMilliseconds);
            }
        }

        public void Add(CiudadanoPostDTO ciudadanoPostDTO)
        {
            _logger.LogInformation("Iniciando el proceso de añadir un nuevo ciudadano en el servicio con los datos: {ciudadanoPostDTO}", ciudadanoPostDTO);
            var serviceStartTime = DateTime.UtcNow;

            try
            {
                _logger.LogInformation($"Creando objeto Ciudadano a partir de CiudadanoPostDTO con los siguientes datos: {JsonSerializer.Serialize(ciudadanoPostDTO)}");
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
                    ImagenUrl = ciudadanoPostDTO.ImagenUrl
                };
                _ciudadanoRepository.Add(ciudadano);
                var serviceEndTime = DateTime.UtcNow;
                _logger.LogInformation("Ciudadano añadido exitosamente en el repositorio con ID asignado: {Id}. Tiempo de ejecución: {Duration}ms", ciudadano.IdCiudadano, (serviceEndTime - serviceStartTime).TotalMilliseconds);
            }
            catch (Exception ex)
            {
                var serviceErrorTime = DateTime.UtcNow;
                _logger.LogError(ex, "Error al añadir el ciudadano con datos: {ciudadanoPostDTO}. Tiempo hasta error: {Duration}ms", JsonSerializer.Serialize(ciudadanoPostDTO), (serviceErrorTime - serviceStartTime).TotalMilliseconds);
                throw;
            }
            finally
            {
                var serviceEndTime = DateTime.UtcNow;
                _logger.LogInformation("Salida del método Add() en el servicio para el ciudadano con datos: {ciudadanoPostDTO}. Duración total del servicio: {TotalDuration}ms", JsonSerializer.Serialize(ciudadanoPostDTO), (serviceEndTime - serviceStartTime).TotalMilliseconds);
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
