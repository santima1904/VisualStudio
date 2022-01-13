using Microsoft.AspNetCore.Mvc;
using CRUD_Personas_BL.Listado;
using CRUD_Personas_BL.Gestora;
using CRUD_Personas_Entidades;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Net;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Personas_ASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class Departamentos : ControllerBase
    {
        // GET: api/<Departamentos>
        [HttpGet]
        public IEnumerable<Departamento> Get()
        {
            ObservableCollection<Departamento> departamentos;
            try
            {
                departamentos = clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            if (departamentos == null || departamentos.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return departamentos;
        }

        // GET api/<Departamentos>/5
        [HttpGet("{id}")]
        public Departamento Get(int id)
        {
            return clsDepartamentosBL.obtenerDepartamentoBL(id);
        }

        // POST api/<Departamentos>
        [HttpPost]
        public void Post([FromBody] Departamento departamento)
        {
            GestoraDepartamentosBL.insertdepartamentoBL(departamento);  
        }

        // PUT api/<Departamentos>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Departamento departamento)
        {
            GestoraDepartamentosBL.updatedepartamentoDAL(departamento);
        }

        // DELETE api/<Departamentos>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            GestoraDepartamentosBL.deletedepartamentoBL(id);
        }
    }
}
