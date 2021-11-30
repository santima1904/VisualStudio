using CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace CRUD_Personas_DAL.Listado
{
    public class clsListadoDepartamentosDAL
    {
        /// <summary>
        /// <cadecera>public static ObservableCollection(Departamento) obtenerListadoDepartamentosCompleto_DAL()</cadecera>
        /// <descripcion>Método para recoger una lista de departamentos de la base de datos</descripcion>
        /// <precondiciones>Ninguna</precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(Departamento)</returns>
        public static ObservableCollection<Departamento> obtenerListadoDepartamentosCompleto_DAL()
        {
            ObservableCollection<Departamento> listado = new ObservableCollection<Departamento>();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.CommandText = "SELECT * FROM Departamentos";
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                while (miLector.Read())
                {
                    Departamento odepartamento = new Departamento();
                    odepartamento.Id = (int)miLector["IDDepartamento"];
                    if(miLector["nombreDepartamento"] != System.DBNull.Value)
                    {
                        odepartamento.Nombre = (string)miLector["nombreDepartamento"];
                    }
                    listado.Add(odepartamento);
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref connection);

            return listado;
        }

        /// <summary>
        /// <cadecera>public static Departamento obtenerDepartamento(int id)</cadecera>
        /// <descripcion>Método para obtener un departamento de la base de datos a partir de un id dado</descripcion>
        /// <precondiciones>id positivo</precondiciones>
        /// <postcondiciones>objeto departamento obtenido</postcondiciones>
        /// </summary>
        /// <returns>Departamento</returns>
        public static Departamento obtenerDepartamento(int id)
        {
            Departamento odepartamento = new Departamento();
            clsMyConnection miConexion = new clsMyConnection();
            SqlConnection connection = miConexion.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            miComando.CommandText = "SELECT * FROM Departamentos  WHERE IDDepartamento = @id";
            miComando.Connection = connection;
            miLector = miComando.ExecuteReader();

            if (miLector.HasRows)
            {
                miLector.Read();
                odepartamento.Id = (int)miLector["IDDepartamento"];
                if (miLector["nombreDepartamento"] != System.DBNull.Value)
                {
                    odepartamento.Nombre = (string)miLector["nombreDepartamento"];
                }
            }
            miLector.Close();
            miConexion.closeConnection(ref connection);

            return odepartamento;
        }
    }
}
