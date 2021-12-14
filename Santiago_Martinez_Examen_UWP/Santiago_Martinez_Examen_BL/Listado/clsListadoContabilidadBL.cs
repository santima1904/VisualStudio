using System;
using System.Collections.Generic;
using System.Text;
using Santiago_Martinez_Examen_DAL.Listado;

namespace Santiago_Martinez_Examen_BL.Listado
{
    public class clsListadoContabilidadBL
    {
        /// <summary>
        /// <cadecera>public static bool existeContabilidadBL(DateTime fecha)</cadecera>
        /// <descripcion>Método para saber si existe un registro de esa fecha</descripcion>
        /// <precondiciones>fecah distinta de null</precondiciones>
        /// <postcondiciones>booleano con la existencia del registro</postcondiciones>
        /// </summary>
        /// <returns>bool</returns>
        public static bool existeContabilidadBL(DateTime fecha)
        {
            return clsListadoContabilidad.existeContabilidadDAL(fecha);
        }
    }
}
