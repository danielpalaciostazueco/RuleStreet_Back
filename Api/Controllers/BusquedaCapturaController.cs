using Microsoft.AspNetCore.Mvc;
using RuleStreet.Models;
using RuleStreet.Business;
using System.Collections.Generic;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RuleStreet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BusquedaCapturaController : ControllerBase
    {
        private readonly CiudadanoService _CiudadanoService;


        public BusquedaCapturaController(CiudadanoService CiudadanoService)
        {
            _CiudadanoService = CiudadanoService;
        }

        [AllowAnonymous]
        [HttpGet("")]
        public ActionResult<List<CiudadanoDTO>> GetAllBusquedaCaptura()
        {
            return _CiudadanoService.GetAllBusquedaCaptura();
        }
    }
}
