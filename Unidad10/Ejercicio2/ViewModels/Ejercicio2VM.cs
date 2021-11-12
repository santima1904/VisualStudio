using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio2.Models;

namespace Ejercicio2.ViewModels
{
    public class Ejercicio2VM
    {
        private clsPersona oPersona = new clsPersona();
        public clsPersona OPersona
        { 
            get { return oPersona; }
            set { oPersona = value; }
        }


    }
}
