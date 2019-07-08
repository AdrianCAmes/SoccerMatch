using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entity;
using Service;

namespace SoccerMatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoController : ControllerBase
    {
        private IDistritoService distritoService;

        public DistritoController(IDistritoService distritoService)
        {
            this.distritoService = distritoService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(
                distritoService.GetAll()
            );
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                distritoService.Get(id)
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Distrito distrito)
        {
            return Ok(
                distritoService.Save(distrito)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Distrito distrito)
        {
            return Ok(
                distritoService.Update(distrito)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                distritoService.Delete(id)
            );
        }
    }
}