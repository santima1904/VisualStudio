using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio1Entidades
{
    public class clsPersona
    {
        #region atributos privados
        private int id;
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string foto;
        private DateTime fechaNac;
        private int idDepartamento;
        #endregion

        #region constructores
        public clsPersona(int id, string nombre, string apellidos, string telefono, string direccion, DateTime fechaNac, int idDepartamento, string foto)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.fechaNac = fechaNac;
            this.idDepartamento = idDepartamento;
            this.foto = foto;
        }

        public clsPersona()
        {
            this.id = 0;
            this.nombre = "";
            this.apellidos = "";
            this.telefono = "";
            this.direccion = "";
            this.fechaNac = DateTime.Now;
            this.idDepartamento = 1;
            this.foto = "";
        }
        #endregion

        #region propiedades públicas
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        public string Foto { get => foto; set => foto = value; }
        #endregion
    }
}
