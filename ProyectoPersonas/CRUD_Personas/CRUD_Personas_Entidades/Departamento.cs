using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_Entidades
{
    public class Departamento
    {
        #region atributos privados
        private int id;
        private string nombre;
        #endregion

        #region propiedades públicas
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        #endregion

        #region constructores
        public Departamento(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Departamento()
        {
            this.id = 0;
            this.nombre = "";
        }
        #endregion
    }
}
