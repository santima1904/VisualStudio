using Examen_ASP_2T.Entidades;
using Examen_ASP_2T.Listado;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.ObjectModel;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examen_ASP_2T.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantasController : ControllerBase
    {
        // GET: api/<PlantasController>/id
        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            ObservableCollection<clsPlanta> plantas = new ObservableCollection<clsPlanta>();
            ObjectResult result = new ObjectResult(new { Value = plantas });
            try
            {
                result.Value = clsListadoPlantasDAL.obtenerListadoPlantasPorCategoriaDAL(id);
                result.StatusCode = (int)HttpStatusCode.OK;
                if ((result.Value as ObservableCollection<clsPlanta>) == null || (result.Value as ObservableCollection<clsPlanta>).Count == 0)
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
