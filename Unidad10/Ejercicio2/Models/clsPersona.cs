using System;
using System.ComponentModel;

namespace Ejercicio2.Models
{
    public class clsPersona : INotifyPropertyChanged
    {
        #region atributos privados
        private String nombre;
        private String apellidos;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String nombre)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nombre));
            }
        }
        #endregion

        #region propiedades publicas
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                if (value.Contains("n")|| value.Contains("N"))
                {
                    apellidos = " ";
                    NotifyPropertyChanged("Apellidos");
                }
            }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value;
                if (value.Contains("n") || value.Contains("N"))
                {
                    nombre = " ";
                    NotifyPropertyChanged("Nombre");
                }
            }

        }


        #endregion

        // Forma de autoimplementacion (para más adelante)
        // public String Nombre { get; set; }

        #region constructores
        //Constructor por defecto
        public clsPersona()
        {
            this.nombre = "Santi";
            this.apellidos = "Martinez";
        }

        //Constructor por parametros
        public clsPersona(string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

        #endregion
    }

} 