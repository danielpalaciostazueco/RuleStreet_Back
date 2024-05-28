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

        public void Update(PoliciaPostDTO policiaPostDto, int id)
        {
            try
            {
                var policia = new Policia
                {
                    IdPolicia = id,
                    IdCiudadano = policiaPostDto.IdCiudadano,
                    IdRango = policiaPostDto.RangoId,
                    NumeroPlaca = policiaPostDto.NumeroPlaca,
                    Contrasena = policiaPostDto.Contrasena,
                };

                _policiaRepository.Update(policia, id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el Policía.");
                throw;
            }
        }

        public void Add(PoliciaPostDTO policia)
        {
            var ciudadano = _ciudadanoRepository.Get((int)policia.IdCiudadano);
            if (ciudadano == null)
            {
                _logger.LogError("No se encontró el ciudadano con el ID proporcionado.");
                throw new InvalidOperationException("No se puede añadir un policía para un ciudadano no existente.");
            }
            ciudadano.IsPoli = true;

            var ciudadanoUpdate = new Ciudadano
            {
                IdCiudadano = ciudadano.IdCiudadano,
                Nombre = ciudadano.Nombre,
                Apellidos = ciudadano.Apellidos,
                Dni = ciudadano.Dni,
                Genero = ciudadano.Genero,
                Gender = ciudadano.Gender,
                Nacionalidad = ciudadano.Nacionalidad,
                Nationality = ciudadano.Nationality,
                FechaNacimiento = ciudadano.FechaNacimiento,
                Direccion = ciudadano.Direccion,
                Address = ciudadano.Address,
                NumeroTelefono = ciudadano.NumeroTelefono,
                NumeroCuentaBancaria = ciudadano.NumeroCuentaBancaria,
                IsPoli = ciudadano.IsPoli,
                IsBusquedaYCaptura = ciudadano.IsBusquedaYCaptura,
                IsPeligroso = ciudadano.IsPeligroso,
                ImagenUrl = ciudadano.ImagenUrl,
            };
            _ciudadanoRepository.Update(ciudadanoUpdate);

            var policiaEntity = new Policia()
            {
                IdCiudadano = (int)policia.IdCiudadano,
                IdRango = policia.RangoId,
                NumeroPlaca = policia.NumeroPlaca,
                Contrasena = policia.Contrasena,
            };

            try
            {
                _policiaRepository.Add(policiaEntity);
                _logger.LogInformation("Policía añadido correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error añadiendo el policía");
                throw;
            }
        }

        public bool policiaDuplicado(PoliciaPostDTO policia)
        {
            var policias = _policiaRepository.GetAll();
            bool repetido = false;
            foreach (var p in policias)
            {
                if (p.IdCiudadano == policia.IdCiudadano)
                {
                    repetido = true;
                }
                if(p.NumeroPlaca == policia.NumeroPlaca){
                    repetido = true;
                }
            }
            return repetido;
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
