using CRUD_Personas_Entidades;
using System.Collections.ObjectModel;
using CRUD_Personas_BL.Listado;
using System;

namespace CRUD_Personas_ASP.Models.ViewModels
{
    public class vmListado
    {
        private ObservableCollection<clsPersonaConNombreDepartamento> listadoPersonasConNombreDepartamento;
        public vmListado()
        {
          listadoPersonasConNombreDepartamento = obtenerListadoPersonasConNombreDepartamento();
        }


        public ObservableCollection<clsPersonaConNombreDepartamento> ListadoPersonasConNombreDepartamento { get => listadoPersonasConNombreDepartamento; set => listadoPersonasConNombreDepartamento = value; }

        /// <summary>
        ///     <cabecera>private static ObservableCollection(clsPersonaConNombreDepartamento) obtenerListadoPersonasConNombreDepartamento()</cabecera>
        ///     <descripcion>Método para obtener un listado con personas con nombre departamento</descripcion>
        ///     <precondiciones>Capa DAL hecha</precondiciones>
        ///     <postcondiciones>Listado lleno con las personas de la base de datos y el nombre de su departamento</postcondiciones>
        /// </summary>
        /// <entradas>Ninguna</entradas>
        /// <salidas>ObservableCollection(clsPersonaConNombreDepartamento)</salidas>
        /// <returns>listadoPersonasNombreDepartamento</returns>
        private static ObservableCollection<clsPersonaConNombreDepartamento> obtenerListadoPersonasConNombreDepartamento()
        {
            ObservableCollection<clsPersonaConNombreDepartamento> listadoPersonasNombreDepartamento = new ObservableCollection<clsPersonaConNombreDepartamento>();
            ObservableCollection<clsPersona> listadopersonas;
            ObservableCollection<Departamento> listadoDepartamentos;

            try
            {
                listadopersonas = clsListadoPersonasBL.obtenerListadoPersonasCompleto_BL();
                listadoDepartamentos = clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
            }
            catch (Exception)
            {
                throw;
            }

            foreach (clsPersona persona in listadopersonas)
            {
                listadoPersonasNombreDepartamento.Add(new clsPersonaConNombreDepartamento(persona, obtenerNombreDepartamento(persona.IdDepartamento, listadoDepartamentos)));
            }

            return listadoPersonasNombreDepartamento;
        }

        /// <summary>
        ///     <cabecera>private static string obtenerNombreDepartamento(int id, ObservableCollection(Departamento) listadoDepartamentos)</cabecera>
        ///     <descripcion>Método para obtener el nombre del departamento con id dado buscando en la lista dada de departamentos</descripcion>
        ///     <precondiciones>id positivo y lista llena</precondiciones>
        ///     <postcondiciones>Cadena devuelta con el nombre del departamento</postcondiciones>
        /// </summary>
        /// <entradas>int id, ObservableCollection(Departamento) listadoDepartamentos</entradas>
        /// <salidas>string nombre</salidas>
        /// <returns>string</returns>
        private static string obtenerNombreDepartamento(int id, ObservableCollection<Departamento> listadoDepartamentos)
        {
            String nombre = " ";
            foreach(Departamento departamento in listadoDepartamentos)
            {
                if(departamento.Id == id)
                {
                    nombre = departamento.Nombre;
                }
            }
            return nombre;
        }
    }
}
