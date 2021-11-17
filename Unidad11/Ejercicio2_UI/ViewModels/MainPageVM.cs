using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad11.Entidades;
using Unidad11.DAL;
using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using Ejercicio2_UI.Models.ViewModels;

namespace Ejercicio2_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        private ObservableCollection<clsPersona> listaPersonasCompleto;
        private ObservableCollection<clsPersona> listaPersonasOfrecido;
        private DelegateCommand buscarCommand;
        private String txbContent;

        public ObservableCollection<clsPersona> ListaPersonasOfrecido { get => listaPersonasOfrecido; }
        public DelegateCommand BuscarCommand1 {
            get { 
                buscarCommand = new DelegateCommand(BuscarCommand_Executed, PuedeEjercutar);
                return buscarCommand;
            }
            set => buscarCommand = value; }

        public string TxbContent
        {
            get { return txbContent; }

            set
            {
                txbContent = value;
                NotifyPropertyChanged("TxbContent");
                buscarCommand.RaiseCanExecuteChanged();
            }
        }

        public MainPageVM()
        {
            this.listaPersonasCompleto = new clsListado().rellenarLista();
            this.listaPersonasOfrecido = listaPersonasCompleto; 
        }

        private void BuscarCommand_Executed()
        {
            listaPersonasOfrecido = new ObservableCollection<clsPersona>(from p in listaPersonasCompleto
                                                                         where p.Nombre.ToLower().Contains(txbContent.ToLower()) || p.Apellidos.ToLower().Contains(txbContent.ToLower()) 
                                                                         select p);
            NotifyPropertyChanged("ListaPersonasOfrecido");
        }

        private bool PuedeEjercutar()
        {
            bool valido = true;

            if (String.IsNullOrEmpty(txbContent))//aprovecho que hago la comprobación de si es nulo el textbox para eso
            {
                valido = false;
                listaPersonasOfrecido = listaPersonasCompleto;
                NotifyPropertyChanged("ListaPersonasOfrecido");
            }
            return valido;
        }
    }
}
