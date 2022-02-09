using ExamenSGEMP_2T.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ExamenSGEMP_2T.Listado;
using ExamenSGEMP_2T.Gestora;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenSGEMP_2T.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantasController : ControllerBase
    {
        // GET: api/<PlantaController>/id
        [HttpGet]
        public ObjectResult GetListadoCategoria(int idCategoria)
        {
            List<clsPlanta> plantas = new List<clsPlanta>();
            ObjectResult result = new ObjectResult(new { value = plantas });
            try
            {
                result.Value = clsListadoPlantasDAL.obtenerListadoPlantasPorCategoriaDAL(idCategoria);
                result.StatusCode = (int)HttpStatusCode.OK;
                if (plantas == null || (plantas.Count == 0))
                {
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
            catch (Exception)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            
            return result;
        }

        // GET api/<PlantaController>/5
        [HttpGet("{id}")]
        public ObjectResult GetPlanta(int id)
        {
            clsPlanta planta = new clsPlanta();
            ObjectResult result = new ObjectResult(new { value = planta });
            try
            {
                result.Value = clsListadoPlantasDAL.obtenerPlantaDAL(id);
                result.StatusCode = (int)HttpStatusCode.OK;
                if (planta == null)
                {
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
            catch (Exception)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return result;
        }

        // POST api/<PlantaController>
        [HttpPost]
        public ObjectResult Post([FromBody] clsPlanta planta)
        {
            ObjectResult result = new ObjectResult(new { value = planta });
            try
            {
                result.Value = clsGestoraPlantasDAL.insertPlantaDAL(planta);
                result.StatusCode = (int)HttpStatusCode.OK;
                if (planta == null)
                {
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
            catch (Exception)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return result;
        }

        // PUT api/<PlantaController>/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] clsPlanta planta)
        {
            ObjectResult result = new ObjectResult(new { value = planta });
            try
            {
                result.Value = clsGestoraPlantasDAL.updatePlantaDAL(planta);
                result.StatusCode = (int)HttpStatusCode.OK;
                if (planta == null)
                {
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
            catch (Exception)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return result;
        }

        // DELETE api/<PlantaController>/5
        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            ObjectResult result = new ObjectResult(new { value = id });
            try
            {
                result.Value = clsGestoraPlantasDAL.deletePlantaDAL(id);
                result.StatusCode = (int)HttpStatusCode.OK;
                if (id < 0)
                {
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
            catch (Exception)
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return result;
        }
    }
}
