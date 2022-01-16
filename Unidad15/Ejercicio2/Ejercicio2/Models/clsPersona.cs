using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2.Models
{
    public class clsPersona
    {
        string nombre;
        string apellidos;

        public clsPersona(string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

        public clsPersona()
        {
            this.nombre = "Santi";
            this.apellidos = "Martinez";
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
    }
}
