using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace CRUD_Personas_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(CRUD_Personas_UWP.Views.FotoSaludo));
        }

        /// <summary>
        ///     <cabecera>private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)</cabecera>
        ///     <descripcion>
        ///         Método controlar los eventos del navigationview
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">TappedRoutedEventArgs</param>
        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            NavigationViewItem navigationView = sender as NavigationViewItem;
            try
            {
                if (navigationView.Name == "nvwPersonas")
                {
                    contentFrame.Navigate(typeof(CRUD_Personas_UWP.Views.Personas));
                }
                else
                {
                    contentFrame.Navigate(typeof(CRUD_Personas_UWP.Views.Departamentos));
                }
               
            }
            catch (Exception)
            {
                contentFrame.Navigate(typeof(CRUD_Personas_UWP.Views.Error));
            }
        }
    }
}
