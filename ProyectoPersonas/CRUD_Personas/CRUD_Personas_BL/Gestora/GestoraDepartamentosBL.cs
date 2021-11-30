using System;
using System.Collections.Generic;
using System.Text;
using CRUD_Personas_DAL.Gestora;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_BL.Gestora
{
    public class GestoraDepartamentosBL
    {
        /// <summary>
        /// <cadecera>public int deletepersonaBL(Departamento departamento)</cadecera>
        /// <descripcion>Método para borrar un departamento de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int deletedepartamentoBL(Departamento departamento)
        {
            return GestoraDepartamentosDAL.deletedepartamentoDAL(departamento);
        }

        /// <summary>
        /// <cadecera>public int insertpersonaBL(Departamento departamento)</cadecera>
        /// <descripcion>Método para insertar un departamento de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int insertdepartamentoBL(Departamento departamento)
        {
            return GestoraDepartamentosDAL.insertdepartamentoDAL(departamento);
        }

        /// <summary>
        /// <cadecera>public int updatedepartamentoDAL(Departamento departamento)</cadecera>
        /// <descripcion>Método para actualizar un departamento de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int updatedepartamentoDAL(Departamento departamento)
        {
            return GestoraDepartamentosDAL.updatedepartamentoDAL(departamento);
        }
    }
}
