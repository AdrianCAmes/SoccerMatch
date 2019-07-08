using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entity;
using Service;
using Repository.ViewModel;
namespace SoccerMatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private IEquipoService EquipoService;

        public EquipoController(IEquipoService EquipoService)
        {
            this.EquipoService = EquipoService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                EquipoService.GetAll()
            );
        }

        [HttpGet("recomendados/{idUsuario}")]
        public ActionResult EquiposRecomendados(int idUsuario)
        {
            
            return Ok(
                EquipoService.EquiposRecomendados(idUsuario)
            );
        }
        
        [HttpGet("misequipos/{idUsuario}")]
        public ActionResult MisEquipos(int idUsuario)
        {        
            return Ok(
                EquipoService.MisEquipos(idUsuario)
            );
        }
        [HttpPost]
        public ActionResult Post([FromBody] EquiposRecomendadosViewModel Equipo)
        {
            return Ok(
                EquipoService.Guardar(Equipo)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Equipo Equipo)
        {
            return Ok(
                EquipoService.Update(Equipo)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                EquipoService.Delete(id)
            );
        }


    }
}