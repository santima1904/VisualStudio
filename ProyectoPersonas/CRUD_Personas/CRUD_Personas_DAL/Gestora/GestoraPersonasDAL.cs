using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Data.SqlClient;

namespace CRUD_Personas_DAL.Gestora
{
    //TODO trato de excepciones
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
        public static int insertpersonaDAL(clsPersona opersona)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = opersona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = opersona.Apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = opersona.FechaNac;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = opersona.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = opersona.Direccion;
            miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = opersona.IdDepartamento;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = opersona.Foto;

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
        public static int updatepersonaDAL(clsPersona oPersona)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = oPersona.Id;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPersona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = oPersona.Apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.VarChar).Value = oPersona.FechaNac;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = oPersona.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.Direccion;
            miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = oPersona.IdDepartamento;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = oPersona.Foto;

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
