using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_DAL.Gestora;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_BL.Gestora
{
    public class GestoraPersonasBL
    {
        /// <summary>
        /// <cadecera>public int deletepersonaBL(int id)</cadecera>
        /// <descripcion>Método para borrar una persona de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int deletepersonaBL(int id)
        {
            return GestoraPersonasDAL.deletepersonaDAL(id);
        }

        /// <summary>
        /// <cadecera>public int insertpersonaBL(clsPersona oPersona)</cadecera>
        /// <descripcion>Método para borrar una persona de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int insertpersonaBL(clsPersona oPersona)
        {
            return GestoraPersonasDAL.insertpersonaDAL(oPersona);
        }

        /// <summary>
        /// <cadecera>public int updatepersonaBL(clsPersona oPersona)</cadecera>
        /// <descripcion>Método para borrar una persona de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int updatepersonaBL(clsPersona oPersona)
        {
            return GestoraPersonasDAL.updatepersonaDAL(oPersona);
        }
    }
}
