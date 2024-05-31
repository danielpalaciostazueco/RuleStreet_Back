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
    public class DeudoresController : ControllerBase
    {
        private readonly CiudadanoService _CiudadanoService;


        public DeudoresController(CiudadanoService CiudadanoService)
        {
            _CiudadanoService = CiudadanoService;
        }

        [HttpGet]
        public ActionResult<List<DeudoresDTO>> GetAllDeudores()
        {
            return _CiudadanoService.GetAllDeudores();
        }
      
    }
}
