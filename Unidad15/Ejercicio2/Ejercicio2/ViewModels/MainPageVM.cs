using Ejercicio2.Models;
using Ejercicio2.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;

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
        ///     <cabecera>private void AnhadirCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command añadir al ser ejecutado.
        ///         El command habilita la vista de editar
        ///     </descripcion>
        /// </summary>
         async void SaludarCommand_Executed()
        {
            //await DisplayAlert();
        }
    }
}
