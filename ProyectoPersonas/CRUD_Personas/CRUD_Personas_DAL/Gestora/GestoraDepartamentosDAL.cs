using System;
using CRUD_Personas_DAL.Conexion;
using System.Data.SqlClient;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_DAL.Gestora
{
    public class GestoraDepartamentosDAL
    {

        /// <summary>
        /// <cadecera>public static int deletedepartamentoDAL(int id)</cadecera>
        /// <descripcion>Método para borrar un departamento de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int deletedepartamentoDAL(int id)
        {
            int resultado = 0; 
            clsMyConnection miConexion = new clsMyConnection();

            try
            {
                SqlConnection connection = miConexion.getConnection();
                SqlCommand miComando = new SqlCommand();
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                miComando.CommandText = "EXECUTE EliminarDepartamento @id";
                miComando.Connection = connection;
                resultado = miComando.ExecuteNonQuery();

                miConexion.closeConnection(ref connection);
            }catch (Exception)
            {
                throw;
            }
            
            return resultado;
        }

        /// <summary>
        /// <cadecera>public int insertdepartamentoDAL(string nombre)</cadecera>
        /// <descripcion>Método para insertar un departamento en la base de datos</descripcion>
        /// <precondiciones>parámetros distintos de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int insertdepartamentoDAL(Departamento departamento)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();

            try
            {
                SqlConnection connection = miConexion.getConnection();
                SqlCommand miComando = new SqlCommand();
                if(departamento != null)
                {
                   miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;
                }
                else
                {
                    miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
                }
                
                miComando.CommandText = "INSERT INTO Departamentos VALUES(@nombre)";
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
        /// <cadecera>public int updatedepartamentoDAL(string nombre, int iddepartamento)</cadecera>
        /// <descripcion>Método para actualizar un departamento de la base de datos</descripcion>
        /// <precondiciones>parámetros distintos de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int updatedepartamentoDAL(Departamento departamento)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();

            try
            {
                SqlConnection connection = miConexion.getConnection();
                SqlCommand miComando = new SqlCommand();
                    if (departamento != null)
                    {
                        miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;
                    }
                    else
                    {
                        miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
                    }
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = departamento.Id;
                miComando.CommandText = "Update Departamentos " +
                    "SET nombreDepartamento = @nombre " +
                    "WHERE IDDepartamento = @id";
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
