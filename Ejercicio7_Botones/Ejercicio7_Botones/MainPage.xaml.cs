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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Ejercicio7_Botones
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
        /// Event when boton1 is clicked, create boton 3 on stackpanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button boton3 = new Button
            {
                Name = "Boton3",
                Content = "Boton 3",
                FontFamily = new FontFamily("Verdana"),
                FontSize = 16,
                Background = (new SolidColorBrush(Windows.UI.Colors.Blue)),
                Margin = new Thickness(30),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 70,
                Width = 200,
                FontWeight = Windows.UI.Text.FontWeights.Bold,
                BorderBrush = (new SolidColorBrush(Windows.UI.Colors.Yellow))
            };
            boton3.Click += Button_Click3;

            Stackpanel.Children.Add(boton3);
            
        }

        /// <summary>
        /// Event when boton3 is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Stackpanel.Children.Remove(Buton1);
        }
    }
}
