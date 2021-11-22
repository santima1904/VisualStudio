using System;
using CRUD_Personas_DAL.Conexion;
using System.Data.SqlClient;

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
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            miComando.CommandText = "DELETE FROM Departamentos WHERE IDDepartamento = @id";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }

        /// <summary>
        /// <cadecera>public int insertdepartamentoDAL(string nombre)</cadecera>
        /// <descripcion>Método para insertar un departamento en la base de datos</descripcion>
        /// <precondiciones>parámetros distintos de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int insertdepartamentoDAL(string nombre)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre;

            miComando.CommandText = "INSERT INTO Departamentos VALUES(@nombre)";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }

        /// <summary>
        /// <cadecera>public int updatedepartamentoDAL(string nombre, int iddepartamento)</cadecera>
        /// <descripcion>Método para actualizar un departamento de la base de datos</descripcion>
        /// <precondiciones>parámetros distintos de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int updatedepartamentoDAL(string nombre, int iddepartamento)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre;
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = iddepartamento;

            miComando.CommandText = "Update Departamentos " +
                "SET nombreDepartamento = @nombre " +
                "WHERE IDDepartamento = @id";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }
    }
}
