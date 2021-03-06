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
        /// <cadecera>public static int insertpersonaDAL(clsPersona opersona)</cadecera>
        /// <descripcion>Método para insertar una persona en la base de datos</descripcion>
        /// <precondiciones>objeto persona distintos de null</precondiciones>
        /// <postcondiciones>devuelve un entero con el número de filas afectadas</postcondiciones>
        /// </summary>
        /// <returns>int</returns>
        public static int insertpersonaDAL(clsPersona opersona)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            if(opersona.Nombre != null)
            {
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = opersona.Nombre;
            }
            else
            {
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (opersona.Apellidos != null)
            {
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = opersona.Apellidos;
            }
            else
            {
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (opersona.FechaNac != null)
            {
                miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = opersona.FechaNac;
            }
            else
            {
                miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (opersona.Telefono != null)
            {
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = opersona.Telefono;
            }
            else
            {
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (opersona.Direccion != null)
            {
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = opersona.Direccion;
            }
            else
            {
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (opersona.IdDepartamento != 0)
            {
                miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = opersona.IdDepartamento;
            }
            else
            {
                miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (opersona.Foto != null)
            {
                miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = opersona.Foto;
            }
            else
            {
                miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            
            miComando.CommandText = "INSERT INTO Personas VALUES(@nombre, @apellidos, @fechaNac, @telefono, @direccion, @iddepartamento, @foto)";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }

        /// <summary>
        /// <cadecera>public static int updatepersonaDAL(clsPersona oPersona)</cadecera>
        /// <descripcion>Método para actualizar una persona de la base de datos</descripcion>
        /// <precondiciones>objeto persona distintos de null</precondiciones>
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
            if (oPersona.Nombre != null)
            {
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPersona.Nombre;
            }
            else
            {
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPersona.Apellidos != null)
            {
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = oPersona.Apellidos;
            }
            else
            {
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPersona.FechaNac != null)
            {
                miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = oPersona.FechaNac;
            }
            else
            {
                miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPersona.Telefono != null)
            {
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = oPersona.Telefono;
            }
            else
            {
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPersona.Direccion != null)
            {
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.Direccion;
            }
            else
            {
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPersona.IdDepartamento != 0)
            {
                miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = oPersona.IdDepartamento;
            }
            else
            {
                miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }
            if (oPersona.Foto != null)
            {
                miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = oPersona.Foto;
            }
            else
            {
                miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = System.DBNull.Value;
            }

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
