using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad11.DAL;
using Unidad11.Entidades;
using Windows.UI.Xaml;
using System.Collections.ObjectModel;

namespace Ejercicio1.ViewModels
{
    public class MainPageVM
    {
        private ObservableCollection<clsPersona> listaPersonas;
        private clsPersona opersonaSeleccionada;

        #region constructores
        public MainPageVM()
        {
            listaPersonas = new clsListado().rellenarLista();
            opersonaSeleccionada = new clsPersona();
        }

        public ObservableCollection<clsPersona> ListaPersonas { get => listaPersonas; set => listaPersonas = value; }
        public clsPersona OpersonaSeleccionada { get => opersonaSeleccionada; set => opersonaSeleccionada = value; }

        #endregion

        /// <summary>
        ///     <h1>Cabecera: </h1> public void Delete_Click(object sender, RoutedEventArgs e)
        ///     <h1>Descripción: </h1>Método asociado con el evento del botón dado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            listaPersonas.Remove(opersonaSeleccionada);
        }
    }
}
