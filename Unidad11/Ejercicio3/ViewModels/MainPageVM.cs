using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad11.DAL;
using Unidad11.Entidades;
using Windows.UI.Xaml;
using System.Collections.ObjectModel;
using Ejercicio3_UI.Models.ViewModels;
using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;

namespace Ejercicio3.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        private ObservableCollection<clsPersona> listaPersonas;
        private clsPersona opersonaSeleccionada;
        private DelegateCommand borrarCommand;

        #region constructores
        public MainPageVM()
        {
            listaPersonas = new clsListado().rellenarLista();
            opersonaSeleccionada = new clsPersona();
        }

        public ObservableCollection<clsPersona> ListaPersonas { get => listaPersonas; set => listaPersonas = value; }
        public clsPersona OpersonaSeleccionada { get => opersonaSeleccionada; set => opersonaSeleccionada = value; }
        public DelegateCommand BorrarCommand 
        { 
            get {
                DelegateCommand delegateCommand = new DelegateCommand(BorrarCommand_Executed, PuedeEjercutar);
                return borrarCommand; 
            }
            set => borrarCommand = value; 
        }

        #endregion

        private void BorrarCommand_Executed()
        {
            listaPersonas.Remove(opersonaSeleccionada);
            NotifyPropertyChanged("ListaPersonas");
        }

        private bool PuedeEjercutar()
        {
            bool valido = false;
            if(opersonaSeleccionada != null)
            {
                valido = true;
            }

            return valido;
        }
    }
}
