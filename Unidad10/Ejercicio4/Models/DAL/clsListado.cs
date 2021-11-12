using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio4.Models;

namespace Ejercicio4.Models.DAL
{
    public class clsListado
    {
        /// <summary>
        /// Método para rellenar una lista con objetos de clsPersona
        /// </summary>
        /// <returns>List<clsPersona></returns>
        public static List<clsPersona> rellenarLista()
        {
            List<clsPersona> lista = new List<clsPersona>();
            lista.Add(new clsPersona("Mariano", "Rajoy", DateTime.Now, "si", "343747347"));
            lista.Add(new clsPersona("Evaristo", "Hernández", DateTime.Now, "sisi", "343747347"));
            lista.Add(new clsPersona("Jose", "Pingu", DateTime.Now, "sisisi", "343747347"));
            lista.Add(new clsPersona("Tibi", "Dominguez", DateTime.Now, "sisisisi", "343747347"));
            lista.Add(new clsPersona("Patozo", "Juan", DateTime.Now, "sisisisisi", "343747347"));

            return lista;
        }
    }
}
