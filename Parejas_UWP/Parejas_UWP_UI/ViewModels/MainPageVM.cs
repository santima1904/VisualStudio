using Parejas_UWP_UI.Models;
using Parejas_UWP_UI.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parejas_UWP_UI.ViewModels
{
    public class MainPageVM
    {
        #region atributos
        ObservableCollection<clsCarta> listadoCartas;
        DelegateCommand nuevaPartida;
        int intentos;
        #endregion

        #region constructor
        public MainPageVM()
        {
            this.listadoCartas = new ObservableCollection<clsCarta>();
            rellenarListado();
            this.intentos = 6;
        }

        public ObservableCollection<clsCarta> ListadoCartas { get => listadoCartas;}
        public DelegateCommand NuevaPartida { get => nuevaPartida; set => nuevaPartida = value; }
        public int Intentos { get => intentos; set => intentos = value; }
        #endregion

        #region metodos

        private clsCarta crearCarta(string nombre)
        {
            return new clsCarta(nombre);
        }

        private void rellenarListado()
        {
            listadoCartas.Add(crearCarta("//Assets/Images/caña.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/caña.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/morcilla.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/morcilla.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/pate.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/pate.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/queso.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/queso.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/vino.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/vino.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/chorizo.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/chorizo.jpg"));
            listadoCartas.Add(crearCarta("//Assets/Images/aceite.png"));
            listadoCartas.Add(crearCarta("//Assets/Images/aceite.png"));
            listadoCartas.Add(crearCarta("//Assets/Images/jamon.png"));
            listadoCartas.Add(crearCarta("//Assets/Images/jamon.png"));
            listadoCartas.Add(crearCarta("//Assets/Images/sardinas.png"));
            listadoCartas.Add(crearCarta("//Assets/Images/sardinas.png"));
        }
        #endregion
    }
}
