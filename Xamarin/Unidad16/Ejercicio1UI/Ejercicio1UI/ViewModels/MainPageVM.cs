using Ejercicio1Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Ejercicio1UI.ViewModels.Utilidades;
using Ejercicio1BL;
using Windows.UI.Xaml.Controls;

namespace Ejercicio1UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        ObservableCollection<clsPersona> listadoPersonas;
        clsPersona personasSeleccionada;
        DelegateCommand mostrarListaCommand;
        DelegateCommand borrarCommand;
        bool visibilidadCargando;

        public MainPageVM()
        {

        }

        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get => listadoPersonas;
            set 
            {
                listadoPersonas = value; 
                NotifyPropertyChanged("ListadoPersonas");
            }

        }
        public clsPersona PersonasSeleccionada 
        { 
            get => personasSeleccionada;
            set 
            {
                personasSeleccionada = value;
                borrarCommand.RaiseCanExecuteChanged();
            }
        }
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

        public bool VisibilidadCargando { get => visibilidadCargando; set => visibilidadCargando = value; }

        /// <summary>
        /// <b>Cabecera: </b> private async void mostrarListaCommandExecuted()
        /// <b>Descripción: </b> Método para ejecutar la función del command borrar
        /// </summary>
        private async void mostrarListaCommandExecuted()
        {
            visibilidadCargando = true;
            NotifyPropertyChanged("VisibilidadCargando");
            try
            {
                listadoPersonas = await GestoraPersonasBL.obtenerListadoPersonasBL();
                NotifyPropertyChanged("ListadoPersonas");
            }
            catch (Exception)
            {
                 generarMensajeErrorAsync();
            }
            visibilidadCargando = false;
            NotifyPropertyChanged("VisibilidadCargando");
        }

        /// <summary>
        /// <b>Cabecera: </b> private async void borrarCommandExecuted()
        /// <b>Descripción: </b> Método para ejecutar la función del command mostrar lista
        /// </summary>
        private async void borrarCommandExecuted()
        {
            try
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Confirmación", "Estás seguro de borrar esta persona?", "Sí", "No");
                if (answer)
                {
                    await GestoraPersonasBL.borrarPersonasDAL(personasSeleccionada.Id);
                }  
            }
            catch (Exception)
            {
               generarMensajeErrorAsync();
            }
            listadoPersonas.Remove(personasSeleccionada);
            NotifyPropertyChanged("ListadoPersonas");
        }

        /// <summary>
        /// <b>Cabecera: </b> private bool borrarCommandCanExecuted()
        /// <b>Descripción: </b> Método para comprobara cuando se puede ejecutar el command borrar
        /// </summary>
        private bool borrarCommandCanExecuted()
        {
            bool puedeBorrar = false;

            if(personasSeleccionada != null)
            {
                puedeBorrar = true;
            }
            return puedeBorrar;
        }

        /// <summary>
        ///     <cabecera>private async void generarMensajeErrorAsync()</cabecera>
        ///     <descripcion>
        ///         Método para generar el mensaje del error en un content dialog
        ///     </descripcion> 
        /// </summary>
        private async void generarMensajeErrorAsync()
        {
            await App.Current.MainPage.DisplayAlert("Mensaje error", "Ha ocurrido un error, vuelva más tarde", "Ok");
        }
    }
}
