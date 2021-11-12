using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio4.Models;
using Ejercicio4.Models.DAL;
using System.ComponentModel;

namespace Ejercicio4.ViewModels
{
    public class vmListado : INotifyPropertyChanged
    {
        #region atributos
        private List<clsPersona> list;
        private clsPersona personaSeleccionada;

        #endregion

        #region propiedades publicas
        public List<clsPersona> List { get => list;}
        public clsPersona PersonaSeleccionada { get => personaSeleccionada;
            set { personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

        #endregion

        #region constructores
        public vmListado()
        {
            this.list = clsListado.rellenarLista();
            //this.personaSeleccionada = new clsPersona();
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String nombre)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nombre));
            }
        }
    }
}
