using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CRUD_Personas_DAL.Listado;

namespace CRUD_Personas_BL.Listado
{
    public class clsListadoPersonasBL
    {

        /// <summary>
        /// <cadecera>public static ObservableCollection(clsPersona) obtenerListadoPersonasCompleto_BL()</cadecera>
        /// <descripcion>Método para recoger una lista de personas de la capa DAL</descripcion>
        /// <precondiciones>Ninguna</precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(clsPersona)</returns>
        public static ObservableCollection<clsPersona> obtenerListadoPersonasCompleto_BL()
        {
            return clsListadoPersonasDAL.obtenerListadoPersonasCompleto_DAL();
        }

        /// <summary>
        /// <cadecera> public static clsPersona obtenerPersona(int id)</cadecera>
        /// <descripcion>Método para obtener una persona de la capa DAL</descripcion>
        /// <precondiciones>id positivo</precondiciones>
        /// <postcondiciones>objeto persona obtenido</postcondiciones>
        /// </summary>
        /// <returns>clsPersona</returns>
        public static clsPersona obtenerPersona(int id)
        {
            return clsListadoPersonasDAL.obtenerPersona(id);
        }
    }
}
