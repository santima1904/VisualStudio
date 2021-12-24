using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parejas_UWP_UI.Models
{
    public class clsCarta
    {
        #region atributos
        string nombre;
        string foto;
        #endregion

        #region constructor
        public clsCarta(string nombre)
        {
            this.nombre = nombre;
            this.foto = "//Assets/Images/logoSDLT.jpg";
        }

        public clsCarta()
        {
            this.nombre = "porDefecto";
            this.foto = "//Assets/Images/logoSDLT.jpg";
        }
        #endregion

        #region propiedades públicas
        public string Nombre { get => nombre;}
        public string Foto { get => foto; set => foto = value; }
        #endregion
    }
}
