
using Examen_ASP_2T.Conexion;
using Examen_ASP_2T.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace Examen_ASP_2T.Listado
{
    public class clsListadoPlantasDAL
    {
        /// <summary>
        /// <cadecera>public static ObservableCollection(clsPlanta) obtenerListadoPlantasPorCategoriaDAL(int idCategoria)</cadecera>
        /// <descripcion>Método para recoger una lista de plantas de la base de datos con la categoría dada</descripcion>
        /// <precondiciones>idCategoria positivo o 0</precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <param name="idCategoria">int</param>
        /// <returns>ObservableCollection(clsPersona)</returns>
        public static ObservableCollection<clsPlanta> obtenerListadoPlantasPorCategoriaDAL(int idCategoria)
        {
            ObservableCollection<clsPlanta> listadoPlantas = new ObservableCollection<clsPlanta>();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idCategoria;
            miComando.CommandText = "SELECT * FROM plantas WHERE idCategoria = @id";
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    clsPlanta oPlanta = new clsPlanta();
                    oPlanta.IdPlanta = (int)miLector["idPlanta"];

                    oPlanta.Nombre = (string)miLector["nombrePlanta"];

                    if (miLector["descripcion"] != System.DBNull.Value)
                    {
                        oPlanta.Descripcion = (string)miLector["descripcion"];
                    }
                    else
                    {
                        oPlanta.Descripcion = null;
                    }
                    oPlanta.IdCategoria = (int)miLector["idCategoria"];
                    if (miLector["precio"] != System.DBNull.Value)
                    {
                        oPlanta.Precio = Convert.ToDouble(miLector["precio"]);
                    }
                    else
                    {
                        oPlanta.Precio = 0;
                    }
                    listadoPlantas.Add(oPlanta);
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref connection);


            return listadoPlantas;
        }   
    }
}
