using Microsoft.Extensions.Logging;
using RuleStreet.Models;
using RuleStreet.Data;
using System.Collections.Generic;

namespace RuleStreet.Business
{
    public class PoliciaService : IPoliciaService
    {
        private readonly IPoliciaRepository _policiaRepository;
        private readonly ICiudadanoRepository _ciudadanoRepository;
        private readonly ILogger<PoliciaService> _logger;
        private readonly IRangoRepository _rangoRepository;


        public PoliciaService(IPoliciaRepository policiaRepository, ILogger<PoliciaService> logger, ICiudadanoRepository ciudadanoRepository, IRangoRepository rangoRepository)
        {
            _policiaRepository = policiaRepository;
            _logger = logger;
            _ciudadanoRepository = ciudadanoRepository;
            _rangoRepository = rangoRepository;
        }

        public List<PoliciaDTO> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las ciudadanos");
                return _policiaRepository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todas las ciudadanos");
                throw;
            }
        }
        public PoliciaDTO? Get(int id)
        {
            try
            {
                return _policiaRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la ciudadano por id");
                throw;
            }

        }

        public void Update(PoliciaPostDTO policia)
        {
            try
            {
                var Policia = _policiaRepository.Get((int)policia.IdPolicia);
                if (Policia != null)
                {
                    Policia.IdCiudadano = (int)policia.IdCiudadano;
                    Policia.RangoId = policia.Rango?.IdRango;
                    Policia.NumeroPlaca = policia.NumeroPlaca;

                    _policiaRepository.Update(Policia);
                }
                else
                {
                    _logger.LogError("No se encontró el Policía con ID: {0}", policia.IdPolicia);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error actualizando al ciudadano por id");
                throw;
            }
        }

        public void Add(PoliciaPostDTO policia)
        {
            var ciudadano = _ciudadanoRepository.Get((int)policia.IdCiudadano);
            ciudadano.IsPoli = true;

            var ciudadanoUpdate = new Ciudadano
            {
                IdCiudadano = ciudadano.IdCiudadano,
                Nombre = ciudadano.Nombre,
                Apellidos = ciudadano.Apellidos,
                Dni = ciudadano.Dni,
                Genero = ciudadano.Genero,
                Nacionalidad = ciudadano.Nacionalidad,
                FechaNacimiento = ciudadano.FechaNacimiento,
                Direccion = ciudadano.Direccion,
                NumeroTelefono = ciudadano.NumeroTelefono,
                NumeroCuentaBancaria = ciudadano.NumeroCuentaBancaria,
                IsPoli = ciudadano.IsPoli,
                IsBusquedaYCaptura = ciudadano.IsBusquedaYCaptura,
                IsPeligroso = ciudadano.IsPeligroso,
            };
            _ciudadanoRepository.Update(ciudadanoUpdate);

            var Policia = new Policia()
            {
                IdPolicia = (int)policia.IdPolicia,
                IdCiudadano = (int)policia.IdCiudadano,
                IdRango = policia.Rango?.IdRango,
                NumeroPlaca = policia.NumeroPlaca
            };

            try
            {
                _policiaRepository.Add(Policia);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo el policía");
                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {
                _policiaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error eliminando al ciudadano");
                throw;
            }

        }


    }
}
