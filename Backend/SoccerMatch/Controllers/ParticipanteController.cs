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
    public class ParticipanteController : ControllerBase
    {

        private IParticipanteService participanteService;

        public ParticipanteController(IParticipanteService participanteService)
        {
            this.participanteService = participanteService;
        }
        
        
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(
                participanteService.GetAll()
            );
        }

        
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
                participanteService.Get(id)
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Participante participante)
        {
            return Ok(
                participanteService.Save(participante)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Participante participante)
        {
            return Ok(
                participanteService.Update(participante)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                participanteService.Delete(id)
            );
        }
    }
}