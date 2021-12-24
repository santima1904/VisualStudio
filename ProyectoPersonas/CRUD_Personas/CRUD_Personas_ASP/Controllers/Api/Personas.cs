using CRUD_Personas_Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CRUD_Personas_BL.Listado;
using CRUD_Personas_BL.Gestora;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Personas_ASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class Personas : ControllerBase
    {
        // GET: api/<Personas>
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            return clsListadoPersonasBL.obtenerListadoPersonasCompleto_BL();
        }

        // GET api/<Personas>/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            return clsListadoPersonasBL.obtenerPersona(id);
        }

        // POST api/<Personas>
        [HttpPost]
        public void Post([FromBody] clsPersona persona)
        {
            GestoraPersonasBL.insertpersonaBL(persona);
        }

        // PUT api/<Personas>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsPersona persona)
        {
            GestoraPersonasBL.updatepersonaBL(persona);
        }

        // DELETE api/<Personas>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            GestoraPersonasBL.deletepersonaBL(id);
        }
    }
}
