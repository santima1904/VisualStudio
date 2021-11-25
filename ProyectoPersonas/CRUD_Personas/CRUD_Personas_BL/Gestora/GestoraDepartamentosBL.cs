using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_DAL.Gestora;

namespace CRUD_Personas_BL.Gestora
{
    public class GestoraDepartamentosBL
    {
        /// <summary>
        /// <cadecera>public int deletepersonaBL(int id)</cadecera>
        /// <descripcion>Método para borrar un departamento de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int deletedepartamentoBL(int id)
        {
            return GestoraDepartamentosDAL.deletedepartamentoDAL(id);
        }

        /// <summary>
        /// <cadecera>public int insertpersonaBL(string nombre)</cadecera>
        /// <descripcion>Método para insertar un departamento de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int insertdepartamentoBL(string nombre)
        {
            return GestoraDepartamentosDAL.insertdepartamentoDAL(nombre);
        }

        /// <summary>
        /// <cadecera>public int updatedepartamentoDAL(string nombre, int iddepartamento)</cadecera>
        /// <descripcion>Método para actualizar un departamento de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int updatedepartamentoDAL(string nombre, int iddepartamento)
        {
            return GestoraDepartamentosDAL.updatedepartamentoDAL(nombre, iddepartamento);
        }
    }
}
