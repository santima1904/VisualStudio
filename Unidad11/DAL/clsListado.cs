using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad11.Entidades;

namespace Unidad11.DAL
{
    public class clsListado
    {
        /// <summary>
        /// Método para rellenar una lista con objetos de clsPersona
        /// </summary>
        /// <returns>List<clsPersona></returns>
        public ObservableCollection<clsPersona> rellenarLista()
        {
            ObservableCollection<clsPersona> lista = new ObservableCollection<clsPersona>();
            lista.Add(new clsPersona("Mariano", "Rajoy"));
            lista.Add(new clsPersona("Evaristo", "Hernández"));
            lista.Add(new clsPersona("Jose", "Pingu"));
            lista.Add(new clsPersona("Tibi", "Dominguez"));
            lista.Add(new clsPersona("Patozo", "Juan"));
            lista.Add(new clsPersona("Patata", "Patata"));
            lista.Add(new clsPersona("Gato", "Con Botas"));
            lista.Add(new clsPersona("Viejo", "Sabroso"));
            lista.Add(new clsPersona("Galletita", "Traviesa"));
            lista.Add(new clsPersona("Zafarrancho", "En el Rancho"));

            return lista;
        }
    }
}
