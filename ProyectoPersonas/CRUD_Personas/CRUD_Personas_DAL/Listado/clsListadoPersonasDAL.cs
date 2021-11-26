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
            miComando.CommandText = "SELECT * FROM Personas";
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    clsPersona oPersona = new clsPersona();
                    oPersona.Id = (int)miLector["IDPersona"];
                    if(miLector["nombrePersona"] != System.DBNull.Value)
                    {
                        oPersona.Nombre = (string)miLector["nombrePersona"];
                    }
                    else
                    {
                        oPersona.Nombre = null;
                    }
                    if (miLector["apellidosPersona"] != System.DBNull.Value)
                    {
                        oPersona.Apellidos = (string)miLector["apellidosPersona"];
                    }
                    else
                    {
                        oPersona.Apellidos = null;
                    }
                    if (miLector["fechaNacimiento"] != System.DBNull.Value)
                    {
                        oPersona.FechaNac = (DateTime)miLector["fechaNacimiento"];
                    }
                    else
                    {
                        oPersona.FechaNac = DateTime.Now;
                    }
                    if (miLector["telefono"] != System.DBNull.Value)
                    {
                        oPersona.Telefono = (string)miLector["telefono"];
                    }
                    else
                    {
                        oPersona.Telefono = null;
                    }
                    if (miLector["direccion"] != System.DBNull.Value)
                    {
                        oPersona.Direccion = (string)miLector["direccion"];
                    }
                    else
                    {
                        oPersona.Direccion = null;
                    }
                    if (miLector["Foto"] != System.DBNull.Value)
                    {
                        oPersona.Foto = (string)miLector["Foto"];
                    }
                    else
                    {
                        oPersona.Foto = null;
                    }
                    if (miLector["IDDepartamento"] != System.DBNull.Value)
                    {
                        oPersona.IdDepartamento = (int)miLector["IDDepartamento"];
                    }
                    else
                    {
                        oPersona.IdDepartamento = 0;
                    }
                    listado.Add(oPersona);
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref connection);

            return listado;
        }
        

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static clsPersona obtenerPersona(int id)
        {
            clsPersona oPersona = new clsPersona();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.CommandText = "SELECT * FROM Personas  WHERE IDPersona = "+id;
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                miLector.Read();
                oPersona.Id = (int)miLector["IDPersona"];
                if (miLector["nombrePersona"] != System.DBNull.Value)
                {
                    oPersona.Nombre = (string)miLector["nombrePersona"];
                }
                if (miLector["apellidosPersona"] != System.DBNull.Value)
                {
                    oPersona.Apellidos = (string)miLector["apellidosPersona"];
                }
                if (miLector["fechaNacimiento"] != System.DBNull.Value)
                {
                    oPersona.FechaNac = (DateTime)miLector["fechaNacimiento"];
                }
                if (miLector["telefono"] != System.DBNull.Value)
                {
                    oPersona.Telefono = (string)miLector["telefono"];
                }
                if (miLector["direccion"] != System.DBNull.Value)
                {
                    oPersona.Direccion = (string)miLector["direccion"];
                }
                if (miLector["Foto"] != System.DBNull.Value)
                {
                    oPersona.Foto = (string)miLector["Foto"];
                }
                if (miLector["IDDepartamento"] != System.DBNull.Value)
                {
                    oPersona.IdDepartamento = (int)miLector["IDDepartamento"];
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref connection);

            return oPersona;
        }
    }
}
