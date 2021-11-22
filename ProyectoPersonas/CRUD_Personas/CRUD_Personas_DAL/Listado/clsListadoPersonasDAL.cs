using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;

namespace CRUD_Personas_DAL.Listado
{
    //TODO trato de excepciones
    public class clsListadoPersonasDAL
    {

        /// <summary>
        /// <cadecera>public static ObservableCollection(clsPersona) obtenerListadoPersonasCompleto_DAL()</cadecera>
        /// <descripcion>Método para recoger una lista de personas de la base de datos</descripcion>
        /// <precondiciones>Ninguna</precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(clsPersona)</returns>
        public static ObservableCollection<clsPersona> obtenerListadoPersonasCompleto_DAL()
        {
            ObservableCollection<clsPersona> listado = new ObservableCollection<clsPersona>();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.CommandText = "SELECT * FROM Cliente";
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    clsPersona oPersona = new clsPersona();
                    oPersona.Id = (int)miLector["IDPersona"];
                    oPersona.Nombre = (string)miLector["nombrePersona"];
                    oPersona.Apellidos = (string)miLector["apellidosPersona"];
                    oPersona.FechaNac = (DateTime)miLector["fechaNacimiento"];
                    oPersona.Telefono = (string)miLector["telefono"];
                    oPersona.Direccion = (string)miLector["direccion"];
                    oPersona.Foto = (string)miLector["Foto"];
                    oPersona.IdDepartamento = (int)miLector["IDDepartamento"];
                    listado.Add(oPersona);
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref connection);

            return listado;
        }
    }
}
