using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Listado
{
    public class clsListadoDepartamentosDAL
    {
        /// <summary>
        /// <cadecera>public ObservableCollection(Departamento) obtenerListadoPersonasCompleto_DAL()</cadecera>
        /// <descripcion>Método para recoger una lista de departamentos de la base de datos</descripcion>
        /// <precondiciones>Ninguna</precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(Departamento)</returns>
        public ObservableCollection<Departamento> obtenerListadoPersonasCompleto_DAL()
        {
            ObservableCollection<Departamento> listado = new ObservableCollection<Departamento>();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.CommandText = "SELECT * FROM Departamento";
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    Departamento odepartamento = new Departamento();
                    odepartamento.Id = (int)miLector["IDDepartamentos"];
                    odepartamento.Nombre = (string)miLector["nombreDepartamento"];
                    listado.Add(odepartamento);
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref connection);

            return listado;
        }
    }
}
