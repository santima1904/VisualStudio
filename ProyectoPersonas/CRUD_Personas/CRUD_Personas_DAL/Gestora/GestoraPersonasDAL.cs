using CRUD_Personas_DAL.Conexion;
using System;
using System.Data.SqlClient;

namespace CRUD_Personas_DAL.Gestora
{
    public class GestoraPersonasDAL
    {

        /// <summary>
        /// <cadecera>public static int deletepersonaDAL(int id)</cadecera>
        /// <descripcion>Método para borrar una persona de la base de datos</descripcion>
        /// <precondiciones>id distinto de 0 y positivo</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int deletepersonaDAL(int id)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            miComando.CommandText = "DELETE FROM Personas WHERE IDPersona = @id";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }

        /// <summary>
        /// <cadecera>public static int insertpersonaDAL(string nombre, string apellidos, DateTime fechanacimiento, string telefono, string direccion, string foto, int iddepartamento)</cadecera>
        /// <descripcion>Método para insertar una persona en la base de datos</descripcion>
        /// <precondiciones>parámetros distintos de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int insertpersonaDAL(string nombre, string apellidos, DateTime fechanacimiento, string telefono, string direccion, string foto, int iddepartamento)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.VarChar).Value = fechanacimiento;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = direccion;
            miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = iddepartamento;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = foto;

            miComando.CommandText = "INSERT INTO Personas VALUES(@nombre, @apellidos, @fechaNac, @telefono, @direccion, @iddepartamento, @foto)";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }

        /// <summary>
        /// <cadecera>public static int updatepersonaDAL(int idPersona, string nombre, string apellidos, DateTime fechanacimiento, string telefono, string direccion, string foto, int iddepartamento)</cadecera>
        /// <descripcion>Método para actualizar una persona de la base de datos</descripcion>
        /// <precondiciones>parámetros distintos de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int updatepersonaDAL(int idPersona, string nombre, string apellidos, DateTime fechanacimiento, string telefono, string direccion, string foto, int iddepartamento)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.VarChar).Value = fechanacimiento;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = direccion;
            miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = iddepartamento;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = foto;

            miComando.CommandText = "Update Personas " +
                "SET nombrePersona = @nombre, apellidosPersona = @apellidos, fechaNacimiento = @fechaNac," +
                "telefono = @telefono, direccion = @direccion, IDDepartamento = @iddepartamento, Foto = @foto "+
                "WHERE IDPersona = @id";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }
    }
}
