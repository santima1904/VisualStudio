using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_DAL.Gestora;

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
        public int deletepersonaBL(int id)
        {
            return GestoraPersonasDAL.deletepersonaDAL(id);
        }

        /// <summary>
        /// <cadecera>public int insertpersonaBL(string nombre, string apellidos, DateTime fechanacimiento, string telefono, string direccion, string foto, int iddepartamento)</cadecera>
        /// <descripcion>Método para borrar una persona de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public int insertpersonaBL(string nombre, string apellidos, DateTime fechanacimiento, string telefono, string direccion, string foto, int iddepartamento)
        {
            return GestoraPersonasDAL.insertpersonaDAL(nombre, apellidos, fechanacimiento, telefono, direccion, foto, iddepartamento);
        }

        /// <summary>
        /// <cadecera>public int updatepersonaBL(int idPersona, string nombre, string apellidos, DateTime fechanacimiento, string telefono, string direccion, string foto, int iddepartamento)</cadecera>
        /// <descripcion>Método para borrar una persona de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public int updatepersonaBL(int idPersona, string nombre, string apellidos, DateTime fechanacimiento, string telefono, string direccion, string foto, int iddepartamento)
        {
            return GestoraPersonasDAL.updatepersonaDAL(idPersona, nombre, apellidos, fechanacimiento, telefono, direccion, foto, iddepartamento);
        }
    }
}
