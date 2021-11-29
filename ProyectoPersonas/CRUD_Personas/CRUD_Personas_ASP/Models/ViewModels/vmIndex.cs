using CRUD_Personas_Entidades;
using System.Collections.ObjectModel;
using CRUD_Personas_BL.Listado;
using System;

namespace CRUD_Personas_ASP.Models.ViewModels
{
    public class vmIndex
    {
        private ObservableCollection<clsPersonaConNombreDepartamento> listadoPersonasConNombreDepartamento;
        public vmIndex()
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
            try
            {
                ObservableCollection<clsPersona> listadopersonas = clsListadoPersonasBL.obtenerListadoPersonasCompleto_BL();

                foreach (clsPersona persona in listadopersonas)
                {
                    listadoPersonasNombreDepartamento.Add(new clsPersonaConNombreDepartamento(persona, (clsDepartamentosBL.obtenerDepartamentoBL(persona.IdDepartamento)).Nombre));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listadoPersonasNombreDepartamento;
        }
    }
}
