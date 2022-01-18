using Ejercicio1Entidades;
using Ejercicio1DAL.Conexiones;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Ejercicio1DAL
{
    public class GestoraPersonasDAL
    {
        /// <summary>
        /// <b>Cabecera:</b>  public async static Task<ObservableCollection<clsPersona>> obtenerListadoPersonasDAL()
        /// <b>Descripción: </b> Método para obtener el listado de todas las personas del servidor. Contiene una llamada a la api.
        /// <b>Precondiciones: </b> Ninguna
        /// <b>Postcondiciones: </b> Lista de personas devuelta
        /// </summary>
        /// <b>Salidas: </b> Task<ObservableCollection<clsPersona>>
        /// <returns></returns>
        public async static Task<ObservableCollection<clsPersona>> obtenerListadoPersonasDAL()
        {
            ObservableCollection<clsPersona> listadoPersona = new ObservableCollection<clsPersona>();
            Conexion conexion = new Conexion();
            string urlConexion = conexion.Url;
            Uri uri = new Uri($"{urlConexion}Personas");
            HttpClient httpClient;

            HttpResponseMessage codigoRespuesta;
            string textoJsonRespuesta;

            httpClient = new HttpClient();
            try
            {
                codigoRespuesta = await httpClient.GetAsync(uri);

                if (codigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await httpClient.GetStringAsync(uri);
                    httpClient.Dispose();
                    listadoPersona = JsonConvert.DeserializeObject<ObservableCollection<clsPersona>>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoPersona;
        }

        /// <summary>
        /// <b>Cabecera:</b>  public async static void borrarPersonasDAL(int id)
        /// <b>Descripción: </b> Método para borrar la persona del servidor con el id dado. Contiene una llamada a la api.
        /// <b>Precondiciones: </b> id positivo
        /// <b>Postcondiciones: </b> Persona borrada del servidor
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        public async static Task<HttpResponseMessage> borrarPersonasDAL(int id)
        {
            Conexion conexion = new Conexion();
            string urlConexion = conexion.Url;
            Uri uri = new Uri($"{urlConexion}Personas/{id}");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage codigoRespuesta;

            try
            {
               codigoRespuesta = await httpClient.DeleteAsync(uri);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return codigoRespuesta;
        }

    }
}
