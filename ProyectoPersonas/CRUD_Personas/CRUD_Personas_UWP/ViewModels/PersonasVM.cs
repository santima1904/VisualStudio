using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_Entidades;
using CRUD_Personas_BL.Gestora;
using CRUD_Personas_BL.Listado;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CRUD_Personas_UWP.ViewModels.Utilidades;

namespace CRUD_Personas_UWP.ViewModels
{
    public class PersonasVM : clsVMBase
    {
        ObservableCollection<clsPersona> listadoPersonasCompleto;
        ObservableCollection<clsPersona> listadoPersonasOfrecido;
        ObservableCollection<Departamento> listadoDepartamentosCompleto;
        clsPersona personaSeleccionada;
        string nombreDepartamento;
        private DelegateCommand buscarCommand;
        private DelegateCommand anhadirCommand;
        private DelegateCommand borrarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand guardarCommand;
        private string txbBarraBusqueda;

        public ObservableCollection<clsPersona> ListadoPersonasCompleto { get => listadoPersonasCompleto; set => listadoPersonasCompleto = value; }
        public ObservableCollection<Departamento> ListadoDepartamentosCompleto { get => listadoDepartamentosCompleto; set => listadoDepartamentosCompleto = value; }
        public clsPersona PersonaSeleccionada { 
            get => personaSeleccionada;
            set
            {
                personaSeleccionada = value;
                if(personaSeleccionada != null)
                {
                    getNombreDepartamentoDePersona();
                    NotifyPropertyChanged("NombreDepartamento");
                }
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

        public string NombreDepartamento 
        {
            get { return nombreDepartamento; }
            set { nombreDepartamento = value; }
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
        public ObservableCollection<clsPersona> ListadoPersonasOfrecido { get => listadoPersonasOfrecido; }
        public DelegateCommand AnhadirCommand {
            get
            {
                buscarCommand = new DelegateCommand(AnhadirCommand_Executed, PuedeEjercutarCommandBar);
                return buscarCommand;
            }
            set => anhadirCommand = value; }
        public DelegateCommand BorrarCommand {
            get
            {
                buscarCommand = new DelegateCommand(BorrarCommand_Executed, PuedeEjercutarCommandBar);
                return buscarCommand;
            }
            set => borrarCommand = value; 
        }
        public DelegateCommand EditarCommand {
            get
            {
                buscarCommand = new DelegateCommand(EditarCommand_Executed, PuedeEjercutarCommandBar);
                return buscarCommand;
            }
            set => editarCommand = value; 
        }
        public DelegateCommand GuardarCommand {
            get
            {
                buscarCommand = new DelegateCommand(GuardarCommand_Executed, PuedeEjercutarCommandBar);
                return buscarCommand;
            }
            set => guardarCommand = value; 
        }

        public PersonasVM()
        {
            this.listadoPersonasCompleto = clsListadoPersonasBL.obtenerListadoPersonasCompleto_BL();
            this.listadoDepartamentosCompleto = clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
            this.listadoPersonasOfrecido = listadoPersonasCompleto;
        }

        private void getNombreDepartamentoDePersona()
        {
            foreach(Departamento departamento in listadoDepartamentosCompleto)
            {
                if(departamento.Id == personaSeleccionada.IdDepartamento)
                {
                    NombreDepartamento = departamento.Nombre;
                }
            }
        }

        private void BuscarCommand_Executed()
        {
            listadoPersonasOfrecido = new ObservableCollection<clsPersona>(from p in listadoPersonasCompleto
                                                                         where p.Nombre.ToLower().Contains(txbBarraBusqueda.ToLower()) || p.Apellidos.ToLower().Contains(txbBarraBusqueda.ToLower())
                                                                         select p);
            NotifyPropertyChanged("ListadoPersonasOfrecido");
        }

        private bool PuedeEjercutarBuscarCommand()
        {
            bool valido = true;

            if (String.IsNullOrEmpty(txbBarraBusqueda))//aprovecho que hago la comprobación de si es nulo el textbox para eso
            {
                valido = false;
                listadoPersonasOfrecido = listadoPersonasCompleto;
                NotifyPropertyChanged("ListadoPersonasOfrecido");
            }
            return valido;
        }

        private bool PuedeEjercutarCommandBar()
        {
            bool valido = true;

            if (personaSeleccionada == null)//aprovecho que hago la comprobación de si es nulo el textbox para eso
            {
                valido = false;
            }
            return valido;
        }

        private void AnhadirCommand_Executed()
        {
            
        }
        private void GuardarCommand_Executed()
        {
            
        }

        private void BorrarCommand_Executed()
        {
            
        }

        private void EditarCommand_Executed()
        {
            
        }

    }
}
