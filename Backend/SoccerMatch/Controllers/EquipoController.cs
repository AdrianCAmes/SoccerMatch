﻿using System;
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

        [HttpPost]
        public ActionResult Post([FromBody] Equipo Equipo)
        {
            return Ok(
                EquipoService.Save(Equipo)
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