using CRUD_Personas_Entidades;
using System.Collections.ObjectModel;
using CRUD_Personas_DAL.Listado;

namespace CRUD_Personas_BL.Listado
{
    public class clsDepartamentosBL
    {
        /// <summary>
        /// <cadecera>public static ObservableCollection<Departamento> obtenerListadoDepartamentosCompleto_BL()</cadecera>
        /// <descripcion>Método para recoger una lista de departamentos de la capa DAL</descripcion>
        /// <precondiciones>Ninguna</precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(Departamento)</returns>
        public static ObservableCollection<Departamento> obtenerListadoDepartamentosCompleto_BL()
        {
            return clsListadoDepartamentosDAL.obtenerListadoDepartamentosCompleto_DAL();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Departamento obtenerDepartamentoBL(int id)
        {
            return clsListadoDepartamentosDAL.obtenerDepartamento(id);
        }


    }
}
