using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenSGEMP_2T.Entidades
{
    public class clsPlanta
    {
        #region atributos
        int idPlanta;
        string nombre;
        string descripcion;
        int idCategoria;
        float precio;
        #endregion

        #region constructores
        public clsPlanta(int idPlanta, string nombre, string descripcion, int idCategoria, float precio)
        {
            this.idPlanta = idPlanta;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.idCategoria = idCategoria;
            this.precio = precio;
        }

        public clsPlanta()
        {
            this.idPlanta = 0;
            this.nombre = " ";
            this.descripcion = " ";
            this.idCategoria = 0;
            this.precio = 0;
        }
        #endregion

        #region propiedades publicas
        public int IdPlanta { get => idPlanta; set => idPlanta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public float Precio { get => precio; set => precio = value; }
        #endregion
    }
}
