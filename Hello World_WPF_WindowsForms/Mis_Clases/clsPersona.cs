using System;

namespace Mis_Clases
{
    public class clsPersona
    {
        #region atributos privados
        private String nombre;
        #endregion

        #region propiedades publicas
        public string Nombre { get => nombre; set => nombre = value; }


        #endregion

        // Forma de autoimplementacion (para más adelante)
        // public String Nombre { get; set; }

        #region constructores
        //Constructor por defecto
        public clsPersona()
        {

        }

        //Constructor por parametros
        public clsPersona(string nombre)
        {
            this.Nombre = nombre;
        }

        #endregion
    }
} 