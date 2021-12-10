using System;
using System.Linq;
using CRUD_Personas_Entidades;
using CRUD_Personas_BL.Gestora;
using CRUD_Personas_BL.Listado;
using System.Collections.ObjectModel;
using CRUD_Personas_UWP.ViewModels.Utilidades;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;

namespace CRUD_Personas_UWP.ViewModels
{
    public class PersonasVM : clsVMBase
    {
        #region atributos de la clase
        ObservableCollection<clsPersona> listadoPersonasCompleto;
        ObservableCollection<clsPersona> listadoPersonasOfrecido;
        ObservableCollection<Departamento> listadoDepartamentosCompleto;
        clsPersona personaSeleccionada;
        string nombreDepartamento;
        DelegateCommand buscarCommand;
        DelegateCommand anhadirCommand;
        DelegateCommand borrarCommand;
        DelegateCommand editarCommand;
        DelegateCommand guardarCommand;
        string txbBarraBusqueda;
        string visibilityDetalles = "Visible";
        string visibilityAnhadir = "Collapsed";
        string visibilityEditar = "Collapsed";
        string visibilityCampoVacio = "Collapsed";
        #endregion

        #region constructor
        public PersonasVM()
        {
            try
            {
                this.listadoPersonasCompleto = clsListadoPersonasBL.obtenerListadoPersonasCompleto_BL();
                this.listadoDepartamentosCompleto = clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
                this.listadoPersonasOfrecido = listadoPersonasCompleto;

            }
            catch (Exception)
            {
                generarMensajeErrorAsync();
            }
        }
        #endregion

        #region propiedades publicas
        public ObservableCollection<clsPersona> ListadoPersonasCompleto { get => listadoPersonasCompleto; set => listadoPersonasCompleto = value; }
        public ObservableCollection<Departamento> ListadoDepartamentosCompleto { get => listadoDepartamentosCompleto; set => listadoDepartamentosCompleto = value; }
        public ObservableCollection<clsPersona> ListadoPersonasOfrecido { get => listadoPersonasOfrecido; set => listadoPersonasOfrecido = value; }
        public string NombreDepartamento
        {
            get { return nombreDepartamento; }
            set { nombreDepartamento = value; }
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

        public DelegateCommand BuscarCommand
        {
            get
            {
                buscarCommand = new DelegateCommand(BuscarCommand_Executed, PuedeEjercutarBuscarCommand);
                return buscarCommand;
            }
            set => buscarCommand = value;
        }
        public DelegateCommand AnhadirCommand
        {
            get
            {
                anhadirCommand = new DelegateCommand(AnhadirCommand_Executed);
                return anhadirCommand;
            }
            set => anhadirCommand = value;
        }
        public DelegateCommand BorrarCommand
        {
            get
            {
                borrarCommand = new DelegateCommand(BorrarCommand_Executed, PuedeEjercutarCommandBar);
                return borrarCommand;
            }
            set => borrarCommand = value;
        }
        public DelegateCommand EditarCommand
        {
            get
            {
                editarCommand = new DelegateCommand(EditarCommand_Executed, PuedeEjercutarCommandBar);
                return editarCommand;
            }
            set => editarCommand = value;
        }
        public DelegateCommand GuardarCommand
        {
            get
            {
                guardarCommand = new DelegateCommand(GuardarCommand_Executed);
                return guardarCommand;
            }
            set => guardarCommand = value;
        }
        public clsPersona PersonaSeleccionada
        {
            get => personaSeleccionada;
            set
            {
                personaSeleccionada = value;
                if (!(personaSeleccionada is null))
                {
                    getNombreDepartamentoDePersona();
                    NotifyPropertyChanged("NombreDepartamento");
                }
                if (visibilityAnhadir == "Visible")//esta condicion la hago para que en el caso de añadir persona,
                                                   //si seleccionas una persona se cambie a editar, en vez de crear una nueva persona con los datos de la previa
                {
                    visibilityAnhadir = "Collapsed";
                    visibilityDetalles = "Collapsed";
                    visibilityEditar = "Visible";
                    NotifyPropertyChanged("VisibilityAnhadir");
                    NotifyPropertyChanged("VisibilityDetalles");
                    NotifyPropertyChanged("VisibilityEditar");
                }
                NotifyPropertyChanged("PersonaSeleccionada");
                anhadirCommand.RaiseCanExecuteChanged();
                editarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();
                borrarCommand.RaiseCanExecuteChanged();
            }
        }
        public string VisibilityAnhadir { get => visibilityAnhadir; set => visibilityAnhadir = value; }
        public string VisibilityDetalles { get => visibilityDetalles; set => visibilityDetalles = value; }
        public string VisibilityEditar { get => visibilityEditar; set => visibilityEditar = value; }
        public string VisibilityCampoVacio { get => visibilityCampoVacio; set => visibilityCampoVacio = value; }
        #endregion

        #region commands

        #region canExecute
        /// <summary>
        ///     <cabecera>private bool PuedeEjercutarBuscarCommand()</cabecera>
        ///     <descripcion>
        ///         Método para comprobar que el command buscar se puede ejecutar.
        ///         El boton se habilitará si la cadena txbBarraBusqueda es diferente de nula o no esta vacía
        ///     </descripcion>
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        ///     <cabecera>private bool PuedeEjercutarCommandBar()</cabecera>
        ///     <descripcion>
        ///         Método para comprobar que el command commandBar se puede ejecutar.
        ///         El command se habilitará si la persona seleccionada es diferente de null
        ///     </descripcion>
        /// </summary>
        /// <returns></returns>
        private bool PuedeEjercutarCommandBar()
        {
            bool valido = true;

            if (personaSeleccionada is null)//aprovecho que hago la comprobación de si es nulo el textbox para eso
            {
                valido = false;
            }
            return valido;
        }
        #endregion

        #region execute
        /// <summary>
        ///     <cabecera>private void BuscarCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command buscar al ser ejecutado.
        ///         El command busca en la lista de personas, aquellos nombres o apellidos que contengan el contenido del textbox txbBarraBusqueda
        ///     </descripcion> 
        /// </summary>
        private void BuscarCommand_Executed()
        {
            listadoPersonasOfrecido = new ObservableCollection<clsPersona>(from p in listadoPersonasCompleto
                                                                           where p.Nombre.ToLower().Contains(txbBarraBusqueda.ToLower()) || p.Apellidos.ToLower().Contains(txbBarraBusqueda.ToLower())
                                                                           select p);
            NotifyPropertyChanged("ListadoPersonasOfrecido");
        }

        /// <summary>
        ///     <cabecera>private void AnhadirCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command añadir al ser ejecutado.
        ///         El command habilita la vista de editar
        ///     </descripcion>
        /// </summary>
        private void AnhadirCommand_Executed()
        {
            personaSeleccionada = new clsPersona();//para que salgan los campos vacios
            visibilityAnhadir = "Visible";
            visibilityDetalles = "Collapsed";
            visibilityEditar = "Collapsed";
            NotifyPropertyChanged("PersonaSeleccionada");
            NotifyPropertyChanged("VisibilityAnhadir");
            NotifyPropertyChanged("VisibilityDetalles");
            NotifyPropertyChanged("VisibilityEditar");
        }

        /// <summary>
        ///     <cabecera>private void GuardarCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command guardar al ser ejecutado.
        ///         El command actualiza la base de datos y devuelve a la vista de detalles
        ///     </descripcion>
        /// </summary>
        private void GuardarCommand_Executed()
        {
            if (!(personaSeleccionada is null))
            {
                if (String.IsNullOrEmpty(personaSeleccionada.Nombre) || String.IsNullOrEmpty(personaSeleccionada.Apellidos))
                {
                    visibilityCampoVacio = "Visible";
                }
                else
                {
                    guardarBasedeDatos();
                    visibilityAnhadir = "Collapsed";
                    visibilityDetalles = "Visible";
                    visibilityEditar = "Collapsed";
                    visibilityCampoVacio = "Collapsed";

                    NotifyPropertyChanged("VisibilityAnhadir");
                    NotifyPropertyChanged("VisibilityDetalles");
                    NotifyPropertyChanged("VisibilityEditar");

                }
                NotifyPropertyChanged("VisibilityCampoVacio");
            }
        }

        /// <summary>
        ///     <cabecera>private void BorrarCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command borrar al ser ejecutado.
        ///         El command borra a la persona seleccionada de la base de datos
        ///     </descripcion>
        /// </summary>
        private async void BorrarCommand_Executed()
        {
            ContentDialog confirmarBorrar = new ContentDialog()
            {
                Title = "Borrar persona",
                Content = " ",
                SecondaryButtonText = "Sí",
                CloseButtonText = "No"
            };

            ContentDialogResult respuesta = await confirmarBorrar.ShowAsync();
            if (respuesta.HasFlag(ContentDialogResult.Secondary))
            {
                try
                {
                    GestoraPersonasBL.deletepersonaBL(personaSeleccionada.Id);
                    listadoPersonasOfrecido.Remove(personaSeleccionada);
                    NotifyPropertyChanged("ListadoPersonasOfrecido");
                }
                catch (Exception)
                {
                    generarMensajeErrorAsync();
                }
            }
        }

        /// <summary>
        ///     <cabecera>private void EditarCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command editar al ser ejecutado.
        ///         El command cambia a la vista editar
        ///     </descripcion>
        /// </summary>
        private void EditarCommand_Executed()
        {
            visibilityAnhadir = "Collapsed";
            visibilityDetalles = "Collapsed";
            visibilityEditar = "Visible";

            NotifyPropertyChanged("VisibilityAnhadir");
            NotifyPropertyChanged("VisibilityDetalles");
            NotifyPropertyChanged("VisibilityEditar");
        }
        #endregion

        #endregion

        #region metodos privados
        /// <summary>
        ///     <cabecera>private void guardarBasedeDatos()</cabecera>
        ///     <descripcion>
        ///         Método para guardar los cambios realizados en la base de datos.
        ///     </descripcion>
        /// </summary>
        private void guardarBasedeDatos()
        {
            try
            {
                if (visibilityAnhadir == "Visible")
                {
                    GestoraPersonasBL.insertpersonaBL(personaSeleccionada);
                    listadoPersonasOfrecido.Add(personaSeleccionada);
                }
                else if (visibilityEditar == "Visible")
                {
                    GestoraPersonasBL.updatepersonaBL(personaSeleccionada);
                }
                NotifyPropertyChanged("PersonaSeleccionada");
                listadoPersonasOfrecido = clsListadoPersonasBL.obtenerListadoPersonasCompleto_BL();
                NotifyPropertyChanged("ListadoPersonasOfrecido");
            }
            catch (Exception)
            {
                generarMensajeErrorAsync();
            }
        }

        /// <summary>
        ///     <cabecera>private void getNombreDepartamentoDePersona()</cabecera>
        ///     <descripcion>
        ///         Método para obtener el nombre del departamento de la persona seleccionada.
        ///     </descripcion>
        /// </summary>
        private void getNombreDepartamentoDePersona()
        {
            foreach (Departamento departamento in listadoDepartamentosCompleto)
            {
                if (departamento.Id == personaSeleccionada.IdDepartamento)
                {
                    NombreDepartamento = departamento.Nombre;
                }
            }
        }

        /// <summary>
        ///     <cabecera>private async void generarMensajeErrorAsync()</cabecera>
        ///     <descripcion>
        ///         Método para generar el mensaje del error en un content dialog
        ///     </descripcion> 
        /// </summary>
        private async void generarMensajeErrorAsync()
        {
            ContentDialog mensajeError = new ContentDialog()
            {
                Title = "Error",
                Content = "Ha ocurrido un error",
                CloseButtonText = "Ok"
            };

            ContentDialogResult respuesta = await mensajeError.ShowAsync();

        }

       
        #endregion
    }
}
