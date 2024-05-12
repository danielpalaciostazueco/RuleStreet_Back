using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;
using System.Text.Json;

namespace RuleStreet.Business
{
    public class MultaService : IMultaService
    {
        private readonly IMultaRepository _multaRepository;
        private readonly IPoliciaRepository _policiaRepository;
        private readonly ICiudadanoRepository _ciudadanoRepository;
        private readonly ICodigoPenalRepository _codigoPenalRepository;
        private readonly ILogger<MultaService> _logger;


        public MultaService(IMultaRepository multaRepository, IPoliciaRepository policiaRepository, ICiudadanoRepository ciudadanoRepository, ICodigoPenalRepository codigoPenalRepository, ILogger<MultaService> logger)
        {
            _multaRepository = multaRepository;
            _policiaRepository = policiaRepository;
            _ciudadanoRepository = ciudadanoRepository;
            _codigoPenalRepository = codigoPenalRepository;
            _logger = logger;
        }

        public List<MultaDTO> GetAll()
        {
            _logger.LogInformation("Obteniendo todas las multas");
            try
            {
                var multas = _multaRepository.GetAll();

                var multasDto = multas.Select(m => new MultaDTO
                {
                    IdMulta = m.IdMulta,
                    IdPolicia = m.IdPolicia,
                    Fecha = m.Fecha,
                    Pagada = m.Pagada,
                    IdCiudadano = m.IdCiudadano,
                    CodigoPenal = m.CodigoPenal != null ? new CodigoPenalDTO
                    {
                        IdCodigoPenal = m.CodigoPenal.IdCodigoPenal,
                        Articulo = m.CodigoPenal.Articulo,
                        Descripcion = m.CodigoPenal.Descripcion,
                        Precio = m.CodigoPenal.Precio,
                        Sentencia = m.CodigoPenal.Sentencia
                    } : null
                }).ToList();

                _logger.LogInformation($"Retornadas {multasDto.Count} multas.");
                return multasDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las multas");
                throw;
            }
        }

        public MultaDTO? Get(int id)
        {
            _logger.LogInformation($"Buscando multa con ID: {id}");
            try
            {
                var multa = _multaRepository.Get(id);
                if (multa == null)
                {
                    _logger.LogWarning($"Multa con ID: {id} no encontrada.");
                    return null;
                }

                var multaDto = new MultaDTO
                {
                    IdMulta = multa.IdMulta,
                    IdPolicia = multa.IdPolicia,
                    Fecha = multa.Fecha,
                    CodigoPenal = multa.CodigoPenal != null ? new CodigoPenalDTO
                    {
                        IdCodigoPenal = multa.CodigoPenal.IdCodigoPenal,
                        Articulo = multa.CodigoPenal.Articulo,
                        Descripcion = multa.CodigoPenal.Descripcion,
                        Precio = multa.CodigoPenal.Precio,
                        Sentencia = multa.CodigoPenal.Sentencia
                    } : null,
                    Pagada = multa.Pagada,
                    IdCiudadano = multa.IdCiudadano
                };
                _logger.LogInformation($"Multa con ID: {id} encontrada.");
                return multaDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener la multa con ID: {id}.");
                throw;
            }
        }

        public void Update(MultaPostDTO multaDto, int id)
        {
            _logger.LogInformation($"Intentando actualizar la multa con ID: {id}");
            try
            {
                var multa = _multaRepository.Get(id);
                if (multa == null)
                {
                    _logger.LogWarning($"No se encontró la multa con ID: {id} para actualizar.");
                    return;
                }

                multa.IdPolicia = multaDto.IdPolicia ?? multa.IdPolicia;
                multa.Fecha = multaDto.Fecha ?? multa.Fecha;
                multa.Pagada = multaDto.Pagada ?? multa.Pagada;
                multa.IdCiudadano = multaDto.IdCiudadano ?? multa.IdCiudadano;
                multa.IdCodigoPenal = multaDto.IdCodigoPenal ?? multa.IdCodigoPenal;

                _logger.LogInformation($"Actualizando datos de la multa con ID: {id}.");

                if (multaDto.IdPolicia.HasValue && _policiaRepository.Get(multaDto.IdPolicia.Value) == null)
                {
                    throw new ArgumentException($"Policía con ID {multaDto.IdPolicia} no existe.");
                }
                if (multaDto.IdCiudadano.HasValue && _ciudadanoRepository.Get(multaDto.IdCiudadano.Value) == null)
                {
                    throw new ArgumentException($"Ciudadano con ID {multaDto.IdCiudadano} no existe.");
                }
                if (multaDto.IdCodigoPenal.HasValue && _codigoPenalRepository.Get(multaDto.IdCodigoPenal.Value) == null)
                {
                    throw new ArgumentException($"Código Penal con ID {multaDto.IdCodigoPenal} no existe.");
                }

                _multaRepository.Update(multa);
                _logger.LogInformation($"Multa con ID: {id} actualizada correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar la multa con ID: {id}");
                throw;
            }
        }

        public void Add(MultaPostDTO multaDto)
        {
            try
            {
                _logger.LogInformation($"Intentando agregar una nueva multa: {JsonSerializer.Serialize(multaDto)}");

                if (multaDto.IdPolicia.HasValue && _policiaRepository.Get(multaDto.IdPolicia.Value) == null)
                {
                    throw new ArgumentException($"Policía con ID {multaDto.IdPolicia} no existe.");
                }
                if (multaDto.IdCiudadano.HasValue && _ciudadanoRepository.Get(multaDto.IdCiudadano.Value) == null)
                {
                    throw new ArgumentException($"Ciudadano con ID {multaDto.IdCiudadano} no existe.");
                }
                if (multaDto.IdCodigoPenal.HasValue && _codigoPenalRepository.Get(multaDto.IdCodigoPenal.Value) == null)
                {
                    throw new ArgumentException($"Código Penal con ID {multaDto.IdCodigoPenal} no existe.");
                }

                var multa = new Multa
                {
                    IdPolicia = multaDto.IdPolicia ?? 0,
                    Fecha = multaDto.Fecha,
                    IdCodigoPenal = multaDto.IdCodigoPenal ?? 0,
                    Pagada = multaDto.Pagada,
                    IdCiudadano = multaDto.IdCiudadano,
                };

                _multaRepository.Add(multa);
                _logger.LogInformation($"Multa agregada con éxito con ID {multa.IdMulta}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo la multa");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _multaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando la multa");
                throw;
            }

        }


    }
}
