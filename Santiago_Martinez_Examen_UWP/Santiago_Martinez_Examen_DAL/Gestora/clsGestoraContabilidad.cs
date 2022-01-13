using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using CRUD_Personas_DAL.Conexion;
using Santiago_Martinez_ExamenUWP_Entidades;

namespace Santiago_Martinez_Examen_DAL.Gestora
{
    public class clsGestoraContabilidad
    {

        /// <summary>
        /// <cadecera>public int guardarRecaudacionDAL(clsContabilidad oContabilidad)</cadecera>
        /// <descripcion>Método para insertar un objeto contabilidad en la base de datos</descripcion>
        /// <precondiciones>objeto contabilidad distinto de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <param name="oContabilidad">clsContabilidad</param>
        /// <returns>int</returns>
        public static int guardarRecaudacionDAL(clsContabilidad oContabilidad)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();

            try
            {
                SqlConnection connection = miConexion.getConnection();
                SqlCommand miComando = new SqlCommand();
                
                    miComando.Parameters.Add("@fecha", System.Data.SqlDbType.VarChar).Value = oContabilidad.Fecha;
                    if(oContabilidad.RecaudacionDada != null)
                    {
                        miComando.Parameters.Add("@recaudacionDada", System.Data.SqlDbType.VarChar).Value = oContabilidad.RecaudacionDada;
                    }
                    else
                    {
                        miComando.Parameters.Add("@recaudacionDada", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
                    }
                    if (oContabilidad.RecaudacionDada != null)
                    {
                        miComando.Parameters.Add("@recaudacionReal", System.Data.SqlDbType.VarChar).Value = oContabilidad.RecaudacionReal;
                    }
                    else
                    {
                        miComando.Parameters.Add("@recaudacionReal", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
                    }
                
               
                miComando.CommandText = "INSERT INTO contabilidad VALUES(@fecha,@recaudacionDada,@recaudacionReal)";
                miComando.Connection = connection;
                resultado = miComando.ExecuteNonQuery();

                miConexion.closeConnection(ref connection);
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
        }

        /// <summary>
        /// <cadecera>public int updateRecaudacionDAL(clsContabilidad oContabilidad)</cadecera>
        /// <descripcion>Método para actualizar un objeto contabilidad en la base de datos</descripcion>
        /// <precondiciones>objeto contabilidad distinto de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <param name="oContabilidad">clsContabilidad</param>
        /// <returns>int</returns>
        public static int updateRecaudacionDAL(clsContabilidad oContabilidad)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();

            try
            {
                SqlConnection connection = miConexion.getConnection();
                SqlCommand miComando = new SqlCommand();
                miComando.Parameters.Add("@fecha", System.Data.SqlDbType.VarChar).Value = oContabilidad.Fecha;
                if (oContabilidad.RecaudacionDada != null)
                {
                    miComando.Parameters.Add("@recaudacionDada", System.Data.SqlDbType.VarChar).Value = oContabilidad.RecaudacionDada;
                }
                else
                {
                    miComando.Parameters.Add("@recaudacionDada", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
                }
                if (oContabilidad.RecaudacionDada != null)
                {
                    miComando.Parameters.Add("@recaudacionReal", System.Data.SqlDbType.VarChar).Value = oContabilidad.RecaudacionReal;
                }
                else
                {
                    miComando.Parameters.Add("@recaudacionReal", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
                }

                miComando.CommandText = "Update contabilidad " +
                    "SET recaudacionDada = @recaudacionDada, recaudacionReal = @recaudacionReal" +
                    "WHERE fecha = @fecha";

                miComando.Connection = connection;
                resultado = miComando.ExecuteNonQuery();
                miConexion.closeConnection(ref connection);
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
        }
    }
}
