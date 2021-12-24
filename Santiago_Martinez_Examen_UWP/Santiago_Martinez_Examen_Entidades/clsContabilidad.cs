using System;
using System.Collections.Generic;
using System.Text;

namespace Santiago_Martinez_ExamenUWP_Entidades
{
    public class clsContabilidad
    {
        DateTime fecha;
        double recaudacionDada;
        double recaudacionReal;

        public clsContabilidad()
        {
            this.fecha = DateTime.Now;
            this.recaudacionDada = 0;
            this.recaudacionReal = 0;
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double RecaudacionDada { get => recaudacionDada; set => recaudacionDada = value; }
        public double RecaudacionReal { get => recaudacionReal; set => recaudacionReal = value; }
    }
}
