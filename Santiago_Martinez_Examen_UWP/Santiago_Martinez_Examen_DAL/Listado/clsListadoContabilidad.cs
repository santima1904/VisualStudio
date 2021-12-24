using CRUD_Personas_DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Santiago_Martinez_Examen_DAL.Listado
{
    public class clsListadoContabilidad
    {
        //Este método no me funciona , lo dejo por si encuentra el error
        /// <summary>
        /// <cadecera>public static bool existeContabilidadDAL(DateTime fecha)</cadecera>
        /// <descripcion>Método para saber si existe un registro de esa fecha</descripcion>
        /// <precondiciones>fecah distinta de null</precondiciones>
        /// <postcondiciones>booleano con la existencia del registro</postcondiciones>
        /// </summary>
        /// <returns>bool</returns>
        public static bool existeContabilidadDAL(DateTime fecha)
        {
            bool existe = false;

            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.CommandText = "SELECT * FROM contabilidad";
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    if (miLector["fecha"].Equals(fecha))
                    {
                        existe = true;
                    }
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref connection);

            return existe;
        }
    }
}
