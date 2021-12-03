using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;
using CRUD_Personas_BL.Gestora;
using CRUD_Personas_BL.Listado;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CRUD_Personas_UWP.Models;

namespace CRUD_Personas_UWP.ViewModels
{
    public class PersonasVM : INotifyPropertyChanged
    {
        ObservableCollection<clsPersona> listadoPersonasCompleto;
        ObservableCollection<Departamento> listadoDepartamentosCompleto;
        clsPersonaConNombreDepartamento personaSeleccionada;

        public ObservableCollection<clsPersona> ListadoPersonasCompleto { get => listadoPersonasCompleto; set => listadoPersonasCompleto = value; }
        public ObservableCollection<Departamento> ListadoDepartamentosCompleto { get => listadoDepartamentosCompleto; set => listadoDepartamentosCompleto = value; }
        public clsPersonaConNombreDepartamento PersonaSeleccionada { 
            get => personaSeleccionada;
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }
        public PersonasVM()
        {
                this.listadoPersonasCompleto = clsListadoPersonasBL.obtenerListadoPersonasCompleto_BL();
                this.listadoDepartamentosCompleto = clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
                //this.personaSeleccionada=new clsPersona();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String nombre)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nombre));
            }
        }
    }
}
