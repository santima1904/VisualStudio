using Santaigo_Martinez_ExamenUWP_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santiago_Martinez_Examen_UI.Models
{
    public class clsPlantaConCantidad : clsPlanta
    {
        double cantidad;

        public clsPlantaConCantidad(clsPlanta planta ,double cantidad) : base(planta.IdPlanta, planta.Nombre, planta.Descripcion, planta.IdCategoria, planta.Precio)
        {
            this.cantidad = cantidad;
        }

        public double Cantidad { get => cantidad; set => cantidad = value; }
    }
}
