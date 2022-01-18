using Ejercicio1Entidades;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Ejercicio1DAL;
using System.Net.Http;

namespace Ejercicio1BL
{
    public class GestoraPersonasBL
    {
        /// <summary>
        /// <b>Cabecera:</b>  public async static Task<ObservableCollection<clsPersona>> obtenerListadoPersonasBL()
        /// <b>Descripción: </b> Método para llamar al método de la capa DAL obtenerListadoPersonasDAL
        /// <b>Precondiciones: </b> Ninguna
        /// <b>Postcondiciones: </b> Lista de personas devuelta
        /// </summary>
        /// <b>Salidas: </b> Task<ObservableCollection<clsPersona>>
        /// <returns></returns>
        public async static Task<ObservableCollection<clsPersona>> obtenerListadoPersonasBL()
        {
            return await GestoraPersonasDAL.obtenerListadoPersonasDAL();
        }

        /// <summary>
        /// <b>Cabecera:</b>  public async static void borrarPersonasBL(int id)
        /// <b>Descripción: </b> Método para llamar al método de la capa DAL borrarPersonasDAL
        /// <b>Precondiciones: </b> id positivo
        /// <b>Postcondiciones: </b> Persona borrada del servidor
        /// </summary>
        /// <param name="id">int</param>
        /// <returns></returns>
        public async static Task<HttpResponseMessage> borrarPersonasDAL(int id)
        {
            return await GestoraPersonasDAL.borrarPersonasDAL(id);
        }
    }
}
