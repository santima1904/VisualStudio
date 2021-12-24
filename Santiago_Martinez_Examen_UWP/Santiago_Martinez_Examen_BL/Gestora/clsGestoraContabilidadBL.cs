using Santiago_Martinez_ExamenUWP_Entidades;
using Santiago_Martinez_Examen_DAL.Gestora;
using System;
using System.Collections.Generic;
using System.Text;


namespace Santiago_Martinez_Examen_BL.Gestora
{
    public class clsGestoraContabilidadBL
    {
        /// <summary>
        /// <cadecera>public int guardarRecaudacionBL(clsContabilidad oContabilidad)</cadecera>
        /// <descripcion>Método para insertar un objeto contabilidad en la base de datos</descripcion>
        /// <precondiciones>objeto contabilidad distinto de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <param name="oContabilidad">clsContabilidad</param>
        /// <returns>int</returns>
        public static int guardarRecaudacionBL(clsContabilidad oContabilidad)
        {
            return clsGestoraContabilidad.guardarRecaudacionDAL(oContabilidad);

        }

        /// <summary>
        /// <cadecera>public int updateRecaudacionBL(clsContabilidad oContabilidad)</cadecera>
        /// <descripcion>Método para actualizar un objeto contabilidad en la base de datos</descripcion>
        /// <precondiciones>objeto contabilidad distinto de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <param name="oContabilidad">clsContabilidad</param>
        /// <returns>int</returns>
        public static int updateRecaudacionBL(clsContabilidad oContabilidad)
        {
            return clsGestoraContabilidad.updateRecaudacionDAL(oContabilidad);
        }
    }
}
