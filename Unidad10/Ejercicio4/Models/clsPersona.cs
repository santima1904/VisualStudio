using System;

namespace Ejercicio4.Models
{
    public class clsPersona
    {
        #region atributos privados
        private string nombre;
        private string apellidos;
        private DateTime fechaNacimiento;
        private string direccion;
        private string telefono;

        #endregion

        #region propiedades publicas
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }



        #endregion

        // Forma de autoimplementacion (para más adelante)
        // public String Nombre { get; set; }

        #region constructores
        //Constructor por defecto
        public clsPersona()
        {
            this.nombre = "Santi";
            this.apellidos = "Martinez";
            this.fechaNacimiento = DateTime.Now;
            this.direccion = "mi casa";
            this.telefono = "987654321";
        }

        //Constructor por parametros
        public clsPersona(string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        #endregion

        #region toString
        public String toString()
        {
            return nombre;
        }
        #endregion

    }

} 