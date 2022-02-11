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
    public class CategoriasController : ControllerBase
    {
        // GET: api/<CategoriasController>
        [HttpGet]
        public ObjectResult Get()
        {
            ObservableCollection<clsCategoria> categorias = new ObservableCollection<clsCategoria>();
            ObjectResult result = new ObjectResult(new { Value = categorias });
            try
            {
                result.Value = clsListadoCategoriasDAL.obtenerListadoCategoriasCompletoDAL();
                result.StatusCode = (int)HttpStatusCode.OK;
                if ((result.Value as ObservableCollection<clsCategoria>) == null || (result.Value as ObservableCollection<clsCategoria>).Count == 0)
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
