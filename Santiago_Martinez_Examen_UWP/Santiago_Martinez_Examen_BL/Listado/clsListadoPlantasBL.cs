using System;
using System.Collections.Generic;
using System.Text;
using Santaigo_Martinez_ExamenUWP_Entidades;
using Santaigo_Martinez_ExamenUWP_DAL.Listado;
using System.Collections.ObjectModel;

namespace Santaigo_Martinez_ExamenUWP_BL.Listado
{
    public class clsListadoPlantasBL
    {
        /// <summary>
        /// <cadecera>public static ObservableCollection(clsPlanta) obtenerListadoPlantasBL()</cadecera>
        /// <descripcion>Método para llamar al método de recoger una lista de plantas en la capa DAL</descripcion>
        /// <precondiciones></precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(clsPersona)</returns>
        public static ObservableCollection<clsPlanta> obtenerListadoPlantasBL()
        {
            return clsListadoPlantasDAL.obtenerListadoPlantasDAL();
        }


        /// <summary>
        /// <cadecera>public static clsPlanta obtenerPlantaBL(int id)</cadecera>
        /// <descripcion>Método para obtener una planta de la BL a partir de un id dado</descripcion>
        /// <precondiciones>id positivo</precondiciones>
        /// <postcondiciones>objeto planta obtenido</postcondiciones>
        /// </summary>
        /// <returns>clsPlanta</returns>
        public static clsPlanta obtenerPlanta(int id)
        {
            return clsListadoPlantasDAL.obtenerPlantaDAL(id);
        }
    }
}
