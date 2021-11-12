using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Ejercicio8._6
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
   
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Función asociada al evento de click del botón de "+", limpia los campos de los textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            txbNombre.Text = " ";
            txbApellidos.Text = " ";
            txbFecha.Text = " ";
        }

        /// <summary>
        /// Función asociada al evento de click del botón de guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            txtErrorNombre.Visibility = Visibility.Collapsed;
            txtErrorApellidos.Visibility = Visibility.Collapsed;
            txtErrorFecha.Text = " ";

            Boolean valido = true;

            if (string.IsNullOrEmpty(txbNombre.Text))
            {
                txtErrorNombre.Visibility = Visibility.Visible;
                valido = false;
            }
            if (string.IsNullOrEmpty(txbApellidos.Text))
            {
                txtErrorApellidos.Visibility = Visibility.Visible;
                valido = false;
            }
            if (string.IsNullOrEmpty(txbFecha.Text))
            {
                txtErrorFecha.Text = "Campo vacío";
                valido = false;
            }
            if (!validarFecha(txbFecha.Text)) 
            {
                txtErrorFecha.Text = "Fecha incorrecta";
            }


            if (valido) { 
            txtNombre.Text = " ";
            txtApellidos.Text = " ";
            txtFecha.Text = " ";
            txtConfirmar.Visibility = Visibility.Visible;
            }
           
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog();
        }


        /// <summary>
        /// Función para validar las fechas
        /// Devuelve true si es válida o false si no lo es
        /// </summary>
        /// <param name="cadenaFecha"></param>
        /// <returns>boolean</returns>
        private Boolean validarFecha(String cadenaFecha)
        {
            Boolean valido = true;
            DateTime fecha;

            try
            {
                fecha = DateTime.Parse(cadenaFecha);
            }
            catch
            {
                valido = false;
            }

            return valido;
        }
    }
}
