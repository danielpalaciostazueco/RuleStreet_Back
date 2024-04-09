using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodigoPenalController : ControllerBase
    {
        private readonly CodigoPenalService _codigoPenalService;
        private readonly ILogger<CodigoPenalController> _logger;

        public CodigoPenalController(CodigoPenalService codigoPenalService, ILogger<CodigoPenalController> logger)
        {
            _codigoPenalService = codigoPenalService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<CodigoPenalDTO>> GetAll()
        {
            try
            {
                _logger.LogInformation("Solicitando la lista de todo el codigo penal.");
                return _codigoPenalService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo todo el codigo penal.");
                return StatusCode(500, "Un error ocurrió al obtener la lista del codigo penal.");
            }
        }


    }
}