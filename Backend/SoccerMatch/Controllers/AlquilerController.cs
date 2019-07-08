using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Entity;

namespace SoccerMatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private IAlquilerService AlquilerService;

        public AlquilerController(IAlquilerService AlquilerService)
        {
            this.AlquilerService = AlquilerService;
        }
        [HttpGet("alquilerdetalle/{idEquipo}")]
        public ActionResult Get(int idEquipo)
        {
            return Ok(
                AlquilerService.AlquilerDetalle(idEquipo)
            ); 
        }

        [HttpPost]
        public ActionResult Post([FromBody] AlquilerInsertarViewModel alquiler)
        {
            return Ok(
                AlquilerService.Guardar(alquiler)
            );
        }
    }
}