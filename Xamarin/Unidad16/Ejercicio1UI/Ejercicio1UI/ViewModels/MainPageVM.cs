using Ejercicio1Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Ejercicio1UI.ViewModels.Utilidades;
using Ejercicio1BL;

namespace Ejercicio1UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        ObservableCollection<clsPersona> listadoPersonas;
        clsPersona personasSeleccionada;
        DelegateCommand mostrarListaCommand;
        DelegateCommand borrarCommand;

        public MainPageVM()
        {

        }

        public ObservableCollection<clsPersona> ListadoPersonas { get => listadoPersonas; set => listadoPersonas = value; }
        public clsPersona PersonasSeleccionada { get => personasSeleccionada; set => personasSeleccionada = value; }
        public  DelegateCommand MostrarListaCommand 
        {
            get 
            {
                mostrarListaCommand = new DelegateCommand(mostrarListaCommandExecuted);
                return mostrarListaCommand; 
            }
            set => mostrarListaCommand = value;
        }
        public DelegateCommand BorrarCommand 
        {
            get
            {
                borrarCommand = new DelegateCommand(borrarCommandExecuted, borrarCommandCanExecuted);
                return borrarCommand;
            }
            set => borrarCommand = value; 
        }

        private async void mostrarListaCommandExecuted()
        {
            listadoPersonas = await GestoraPersonasBL.obtenerListadoPersonasBL();
            NotifyPropertyChanged("ListadoPersonas");
        }

        private async void borrarCommandExecuted()
        {
           await GestoraPersonasBL.borrarPersonasDAL(personasSeleccionada.Id);
        }

        private bool borrarCommandCanExecuted()
        {
            bool puedeBorrar = false;

            if(personasSeleccionada != null)
            {
                puedeBorrar = true;
            }
            return puedeBorrar;
        }
    }
}
