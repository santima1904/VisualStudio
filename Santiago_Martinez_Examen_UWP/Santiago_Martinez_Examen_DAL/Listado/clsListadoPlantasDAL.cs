using CRUD_Personas_DAL.Conexion;
using Santaigo_Martinez_ExamenUWP_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace Santaigo_Martinez_ExamenUWP_DAL.Listado
{
    public class clsListadoPlantasDAL
    {
        /// <summary>
        /// <cadecera>public static ObservableCollection(clsPlanta) obtenerListadoPlantasDAL()</cadecera>
        /// <descripcion>Método para recoger una lista de plantas de la base de datos</descripcion>
        /// <precondiciones></precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(clsPlanta)</returns>
        public static ObservableCollection<clsPlanta> obtenerListadoPlantasDAL()
        {
            ObservableCollection<clsPlanta> listadoPlantas = new ObservableCollection<clsPlanta>();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.CommandText = "SELECT * FROM plantas";
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
                        oPlanta.Precio = (double)miLector["precio"];
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

        /// <summary>
        /// <cadecera>public static clsPlanta obtenerPlantaDAL(int id)</cadecera>
        /// <descripcion>Método para obtener una planta de la base de datos a partir de un id dado</descripcion>
        /// <precondiciones>id positivo</precondiciones>
        /// <postcondiciones>objeto planta obtenido</postcondiciones>
        /// </summary>
        /// <returns>clsPlanta</returns>
        public static clsPlanta obtenerPlantaDAL(int id)
        {
            clsPlanta oPlanta = new clsPlanta();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            miComando.CommandText = "SELECT * FROM plantas  WHERE idPlanta = @id";
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                miLector.Read();
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
                    oPlanta.Precio = (float)miLector["precio"];
                }
                else
                {
                    oPlanta.Precio = 0;
                }

            }
            miLector.Close();
            miConexion.closeConnection(ref connection);

            return oPlanta;
        }
    }
}
