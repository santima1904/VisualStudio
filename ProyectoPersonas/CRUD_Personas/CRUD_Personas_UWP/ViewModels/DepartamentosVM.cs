using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_BL.Listado;
using CRUD_Personas_UWP.ViewModels.Utilidades;

namespace CRUD_Personas_UWP.ViewModels
{
    public class DepartamentosVM : clsVMBase
    {
        ObservableCollection<Departamento> listadoDepartamentosCompleto;
        ObservableCollection<Departamento> listadoDepartamentosOfrecido;
        Departamento departamentoSeleccionado;
        private DelegateCommand buscarCommand;
        private string txbBarraBusqueda;

        public ObservableCollection<Departamento> ListadoDepartamentosCompleto { get => listadoDepartamentosCompleto; set => listadoDepartamentosCompleto = value; }
        public Departamento DepartamentoSeleccionado 
        { 
            get => departamentoSeleccionado;
            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged("DepartamentoSeleccionado");
            }
        }

        public DelegateCommand BuscarCommand
        {
            get
            {
                buscarCommand = new DelegateCommand(BuscarCommand_Executed, PuedeEjercutarBuscarCommand);
                return buscarCommand;
            }
            set => buscarCommand = value;
        }

        public string TxbBarraBusqueda
        {
            get => txbBarraBusqueda;
            set
            {
                txbBarraBusqueda = value;
                NotifyPropertyChanged("TxbBarraBusqueda");
                buscarCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Departamento> ListadoDepartamentosOfrecido { get => listadoDepartamentosOfrecido; set => listadoDepartamentosOfrecido = value; }

        public DepartamentosVM()
        {
            this.listadoDepartamentosCompleto = clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
            this.listadoDepartamentosOfrecido = listadoDepartamentosCompleto;
        }

        private void BuscarCommand_Executed()
        {
            listadoDepartamentosOfrecido = new ObservableCollection<Departamento>(from d in listadoDepartamentosCompleto
                                                                                  where d.Nombre.ToLower().Contains(txbBarraBusqueda.ToLower()) 
                                                                                  select d);
            NotifyPropertyChanged("ListadoDepartamentosOfrecido");
        }

        private bool PuedeEjercutarBuscarCommand()
        {
            bool valido = true;

            if (String.IsNullOrEmpty(txbBarraBusqueda))//aprovecho que hago la comprobación de si es nulo el textbox para eso
            {
                valido = false;
                listadoDepartamentosOfrecido = listadoDepartamentosCompleto;
                NotifyPropertyChanged("ListadoDepartamentosOfrecido");
            }
            return valido;
        }

    }
}
