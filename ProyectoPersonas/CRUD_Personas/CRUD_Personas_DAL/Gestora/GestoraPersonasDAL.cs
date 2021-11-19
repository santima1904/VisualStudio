using CRUD_Personas_DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Gestora
{
    public class GestoraPersonasDAL
    {

        /// <summary>
        /// <cadecera>public int deletepersonaDAL(int id)</cadecera>
        /// <descripcion>Método para recoger una lista de personas de la base de datos</descripcion>
        /// <precondiciones>Ninguna</precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(clsPersona)</returns>
        public int deletepersonaDAL(int id)
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
        /// <cadecera>public int deletepersonaDAL(int id)</cadecera>
        /// <descripcion>Método para recoger una lista de personas de la base de datos</descripcion>
        /// <precondiciones>Ninguna</precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(clsPersona)</returns>
        public int insertpersonaDAL(string nombre, string apellidos, DateTime fechanacimiento, string telefono, string direccion, string foto, int iddepartamento)
        {
            int resultado = 0;
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.NVarChar).Value = apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.NVarChar).Value = fechanacimiento;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.NVarChar).Value = telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.NVarChar).Value = direccion;
            miComando.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = iddepartamento;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.NVarChar).Value = foto;

            miComando.CommandText = "INSERT INTO Personas VALUES(@nombre, @apellidos, @fechaNac, @telefono, @direccion, @iddepartamento, @foto)";
            miComando.Connection = connection;
            resultado = miComando.ExecuteNonQuery();

            miConexion.closeConnection(ref connection);
            return resultado;
        }
    }
}
