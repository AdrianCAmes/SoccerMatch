using Entity;
using Service;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioService UsuarioService;

        public UsuarioController(IUsuarioService UsuarioService)
        {
            this.UsuarioService = UsuarioService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                UsuarioService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario Usuario)
        {
            return Ok(
                UsuarioService.Save(Usuario)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Usuario Usuario)
        {
            return Ok(
                UsuarioService.Update(Usuario)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                UsuarioService.Delete(id)
            );
        }

    }
}