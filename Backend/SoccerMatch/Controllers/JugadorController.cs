using Entity;
using Service;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {

        private IJugadorService JugadorService;

        public JugadorController(IJugadorService JugadorService)
        {
            this.JugadorService = JugadorService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                JugadorService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Jugador Jugador)
        {
            return Ok(
                JugadorService.Save(Jugador)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Jugador Jugador)
        {
            return Ok(
                JugadorService.Update(Jugador)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                JugadorService.Delete(id)
            );
        }

    }
}