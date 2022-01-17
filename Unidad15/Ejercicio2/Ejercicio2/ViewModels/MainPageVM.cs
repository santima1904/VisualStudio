using Ejercicio2.Models;
using Ejercicio2.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2.ViewModels
{
    public class MainPageVM
    {
        clsPersona persona;
        DelegateCommand commandSaludar;


        public MainPageVM()
        {
            this.persona = new clsPersona();
        }

        public clsPersona Persona { get => persona; set => persona = value; }
        public DelegateCommand CommandSaludar 
        {
            get
            {
                commandSaludar = new DelegateCommand(SaludarCommand_Executed);
                return commandSaludar;
            }
            set => commandSaludar = value; 
        }

        /// <summary>
        ///     <cabecera>private void SaludarCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command saludar al ser ejecutado.
        ///         El command lanza una ventana emergente con los datos introducidos por el usuario
        ///     </descripcion>
        /// </summary>
        private void SaludarCommand_Executed()
        {
            App.Current.MainPage.DisplayAlert("Hola",persona.Nombre+" "+persona.Apellidos,"Ok");
        }
    }
}
