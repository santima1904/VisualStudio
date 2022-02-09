using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CRUD_Personas_DAL.Conexion;
using ExamenSGEMP_2T.Entidades;

namespace ExamenSGEMP_2T.Gestora
{
    public class clsGestoraPlantasDAL
    {
        /// <summary>
        /// <cadecera>public int actualizarPrecioPlantaDAL(clsPlanta planta)</cadecera>
        /// <descripcion>Método para actualizar el precio de una planta de la base de datos</descripcion>
        /// <precondiciones>planta distinta de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas , el precio queda actualizado</postcondiciones>
        /// </summary>
        /// <param name="planta">clsPlanta</param>
        /// <returns>int</returns>
        public static int actualizarPrecioPlantaDAL(clsPlanta planta)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            try
            {
                SqlConnection connection = miConexion.getConnection();
                SqlCommand miComando = new SqlCommand();
                miComando.Parameters.Add("@precio", System.Data.SqlDbType.Float).Value = planta.Precio;
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = planta.IdPlanta;
                miComando.CommandText = "Update plantas " +
                    "SET precio = @precio " +
                    "WHERE idPlanta = @id";
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
        /// <cadecera>public static int deletePlantaDAL(int id)</cadecera>
        /// <descripcion>Método para borrar una planta de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>int</returns>
        public static int deletePlantaDAL(int id)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            miComando.CommandText = "DELETE FROM plantas WHERE idPlanta = @id";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }

        /// <summary>
        /// <cadecera>public static int insertPlantaDAL(clsPlanta oPlanta)</cadecera>
        /// <descripcion>Método para insertar una planta en la base de datos</descripcion>
        /// <precondiciones>objeto planta distintos de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <param name="oPlanta">clsPlanta</param>
        /// <returns>int</returns>
        public static int insertPlantaDAL(clsPlanta oPlanta)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            if (oPlanta.Nombre != null)
            {
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPlanta.Nombre;
            }
            else
            {
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPlanta.Descripcion != null)
            {
                miComando.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar).Value = oPlanta.Descripcion;
            }
            else
            {
                miComando.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPlanta.IdCategoria != 0)
            {
                miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = oPlanta.IdCategoria;
            }
            else
            {
                miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = System.DBNull.Value;
            }
            if (oPlanta.Precio != 0)
            {
                miComando.Parameters.Add("@precio", System.Data.SqlDbType.Float).Value = oPlanta.Precio;
            }
            else
            {
                miComando.Parameters.Add("@precio", System.Data.SqlDbType.Float).Value = System.DBNull.Value;
            }

            miComando.CommandText = "INSERT INTO plantas VALUES(@nombre, @descripcion, @idCategoria, @precio)";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }

        /// <summary>
        /// <cadecera>public static int updatePlantaDAL(clsPersona oPersona)</cadecera>
        /// <descripcion>Método para actualizar una planta de la base de datos</descripcion>
        /// <precondiciones>objeto planta distintos de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <param name="oPlanta">clsPlanta</param>
        /// <returns>int</returns>
        public static int updatePlantaDAL(clsPlanta oPlanta)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = oPlanta.IdPlanta;
            if (oPlanta.Nombre != null)
            {
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPlanta.Nombre;
            }
            else
            {
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPlanta.Descripcion != null)
            {
                miComando.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar).Value = oPlanta.Descripcion;
            }
            else
            {
                miComando.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPlanta.IdCategoria != 0)
            {
                miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = oPlanta.IdCategoria;
            }
            else
            {
                miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = System.DBNull.Value;
            }
            if (oPlanta.Precio != 0)
            {
                miComando.Parameters.Add("@precio", System.Data.SqlDbType.Float).Value = oPlanta.Precio;
            }
            else
            {
                miComando.Parameters.Add("@precio", System.Data.SqlDbType.Float).Value = System.DBNull.Value;
            }

            miComando.CommandText = "Update plantas " +
                "SET nombrePlanta = @nombre, descripcion = @descripcion, idCategoria = @idCategoria, precio = @precio" +
                "WHERE idPlanta = @id";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }
    }
}
