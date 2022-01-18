using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio1DAL.Conexiones
{
    public class Conexion
    {
        string url;

        public Conexion()
        {
            this.url = "https://crudpersonasaspsantimartinez.azurewebsites.net/api/";
        }

        public string Url { get => url; set => url = value; }
    }
}
