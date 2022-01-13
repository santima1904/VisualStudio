using CRUD_Personas_Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CRUD_Personas_BL.Listado;
using CRUD_Personas_BL.Gestora;
using System;
using System.Web.Http;
using System.Net;
using System.Collections.ObjectModel;

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
            ObservableCollection<clsPersona> personas;
            try
            {
                personas = clsListadoPersonasBL.obtenerListadoPersonasCompleto_BL();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            if (personas == null || personas.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return personas;
        }

        // GET api/<Personas>/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            clsPersona persona;

            try
            {
                persona = clsListadoPersonasBL.obtenerPersona(id);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            if (persona == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return persona;
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
            try
            {
                GestoraPersonasBL.updatepersonaBL(persona);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            if (persona == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
        }

        // DELETE api/<Personas>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {  
            try
            {
                GestoraPersonasBL.deletepersonaBL(id);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
