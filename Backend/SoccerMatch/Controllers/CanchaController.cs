using Entity;
using Service;
using Microsoft.AspNetCore.Mvc;

namespace SoccerMatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchaController : ControllerBase
    {

        private ICanchaService CanchaService;

        public CanchaController(ICanchaService CanchaService)
        {
            this.CanchaService = CanchaService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(
                CanchaService.ListarTodos()
            );
        }
        [HttpPost]
        public ActionResult Post([FromBody] Cancha Cancha)
        {
            return Ok(
                CanchaService.Save(Cancha)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Cancha Cancha)
        {
            return Ok(
                CanchaService.Update(Cancha)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                CanchaService.Delete(id)
            );
        }

    }
}