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
        ///     <cabecera></cabecera>
        /// </summary>
        /// <returns></returns>
        private static ObservableCollection<clsPersonaConNombreDepartamento> obtenerListadoPersonasConNombreDepartamento()
        {
            ObservableCollection<clsPersonaConNombreDepartamento> listadoersonasNombreDepartamento = new ObservableCollection<clsPersonaConNombreDepartamento>();
            try
            {
                ObservableCollection<clsPersona> listadopersonas = clsListadoPersonasBL.obtenerListadoPersonasCompleto_BL();

                foreach (clsPersona persona in listadopersonas)
                {
                    listadoersonasNombreDepartamento.Add(new clsPersonaConNombreDepartamento(persona, (clsDepartamentosBL.obtenerDepartamentoBL(persona.IdDepartamento)).Nombre));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listadoersonasNombreDepartamento;
        }
    }
}
