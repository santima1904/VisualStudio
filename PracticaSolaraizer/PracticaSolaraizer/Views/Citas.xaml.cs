using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PracticaSolaraizer.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Citas : Page
    {
        public Citas()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///  <cabecera>private void Button_Click(object sender, RoutedEventArgs e)</cabecera>
        ///  <descripcion>Método para programar el evento del click del botón para ir a la página de inicio</descripcion>
        ///  <precondiciones>Ninguna</precondiciones>
        ///  <postcondiciones>Vuelves a la página de inicio</postcondiciones>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PracticaSolaraizer.MainPage));
        }

        /// <summary>
        ///  <cabecera>private void lstLista_ItemClick(object sender, ItemClickEventArgs e)</cabecera>
        ///  <descripcion>Método para programar el evento del click de un item seleccionado de la lista para ver los detalles</descripcion>
        ///  <precondiciones>Ninguna</precondiciones>
        ///  <postcondiciones>Vas a la página de los detalles de la cita seleccinada</postcondiciones>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstLista_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(PracticaSolaraizer.Views.Detalles));
        }
    }
}
