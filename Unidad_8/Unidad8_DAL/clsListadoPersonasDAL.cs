using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad8_Entidades;

namespace Unidad8_DAL
{
    public class clsListadoPersonasDAL
    {
        /// <summary>
    	/// Función que nos devuelve un listado de todas las personas
    	/// </summary>
    	/// <returns>Listado de personas</returns>
    	public List<clsPersona> getListadoCompletoPersonas()
        {
            clsPersona persona = new clsPersona("Santiago Martínez");
            clsPersona persona2 = new clsPersona("Juan Martínez");
            clsPersona persona3 = new clsPersona("Vicente del Bosque");
            clsPersona persona4 = new clsPersona("Mariano Rajoy");

            List<clsPersona> lista = new List<clsPersona>();

            lista.Add(persona);
            lista.Add(persona2);
            lista.Add(persona3);
            lista.Add(persona4);

            return lista;
        }
        

    }
}
