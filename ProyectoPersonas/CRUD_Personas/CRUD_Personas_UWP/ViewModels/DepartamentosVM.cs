using CRUD_Personas_Entidades;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using CRUD_Personas_BL.Listado;
using CRUD_Personas_UWP.ViewModels.Utilidades;
using CRUD_Personas_BL.Gestora;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;

namespace CRUD_Personas_UWP.ViewModels
{
    public class DepartamentosVM : clsVMBase
    {
        #region atributos privados
        ObservableCollection<Departamento> listadoDepartamentosCompleto;
        ObservableCollection<Departamento> listadoDepartamentosOfrecido;
        Departamento departamentoSeleccionado;
        private DelegateCommand buscarCommand;
        private string txbBarraBusqueda;
        DelegateCommand anhadirCommand;
        DelegateCommand borrarCommand;
        DelegateCommand editarCommand;
        DelegateCommand guardarCommand;
        string visibilityDetalles = "Visible";
        string visibilityAnhadir = "Collapsed";
        string visibilityEditar = "Collapsed";
        string visibilityCampoVacio = "Collapsed";
        #endregion

        #region constructor
        public DepartamentosVM()
        {
            try
            {
                this.listadoDepartamentosCompleto = clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
                this.listadoDepartamentosOfrecido = listadoDepartamentosCompleto;
            }
            catch (Exception) 
            {
                generarMensajeErrorAsync();
            }         
        }
        #endregion

        #region propiedades publicas
        public ObservableCollection<Departamento> ListadoDepartamentosCompleto { get => listadoDepartamentosCompleto; set => listadoDepartamentosCompleto = value; }
        public ObservableCollection<Departamento> ListadoDepartamentosOfrecido { get => listadoDepartamentosOfrecido; set => listadoDepartamentosOfrecido = value; }
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
        public string VisibilityAnhadir { get => visibilityAnhadir; set => visibilityAnhadir = value; }
        public string VisibilityDetalles { get => visibilityDetalles; set => visibilityDetalles = value; }
        public string VisibilityEditar { get => visibilityEditar; set => visibilityEditar = value; }
        public string VisibilityCampoVacio { get => visibilityCampoVacio; set => visibilityCampoVacio = value; }
        public Departamento DepartamentoSeleccionado
        {
            get => departamentoSeleccionado;
            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged("DepartamentoSeleccionado");
                anhadirCommand.RaiseCanExecuteChanged();
                editarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();
                borrarCommand.RaiseCanExecuteChanged();
            }
        }
        
        #endregion

        #region commands

        #region canExecuted
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
                listadoDepartamentosOfrecido = listadoDepartamentosCompleto;
                NotifyPropertyChanged("ListadoDepartamentosOfrecido");
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

            if (departamentoSeleccionado is null)//aprovecho que hago la comprobación de si es nulo el textbox para eso
            {
                valido = false;
            }
            return valido;
        }
        #endregion

        #region executed
        /// <summary>
        ///     <cabecera>private void BuscarCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command buscar al ser ejecutado.
        ///         El command busca en la lista de departamentos, aquellos nombres que contengan el contenido del textbox txbBarraBusqueda
        ///     </descripcion> 
        /// </summary>
        private void BuscarCommand_Executed()
        {
            listadoDepartamentosOfrecido = new ObservableCollection<Departamento>(from d in listadoDepartamentosCompleto
                                                                                  where d.Nombre.ToLower().Contains(txbBarraBusqueda.ToLower())
                                                                                  select d);
            NotifyPropertyChanged("ListadoDepartamentosOfrecido");
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
            departamentoSeleccionado = new Departamento();
            visibilityAnhadir = "Visible";
            visibilityDetalles = "Collapsed";
            visibilityEditar = "Collapsed";

            NotifyPropertyChanged("DepartamentoSeleccionado");
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
            if (String.IsNullOrEmpty(departamentoSeleccionado.Nombre))
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

        /// <summary>
        ///     <cabecera>private void BorrarCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command borrar al ser ejecutado.
        ///         El command borra al departamento seleccionado de la base de datos
        ///     </descripcion>
        /// </summary>
        private async void BorrarCommand_Executed()
        {
            ContentDialog confirmarBorrar = new ContentDialog()
            {
                Title = "Borrar departamento",
                Content = "¿Estás seguro de borrar este departamento?",
                SecondaryButtonText = "Sí",
                CloseButtonText = "No"
            };

            ContentDialogResult respuesta = await confirmarBorrar.ShowAsync();
            if (respuesta.HasFlag(ContentDialogResult.Secondary))
            {
                try
                {
                    GestoraDepartamentosBL.deletedepartamentoBL(departamentoSeleccionado);
                    listadoDepartamentosOfrecido.Remove(departamentoSeleccionado);
                    NotifyPropertyChanged("ListadoDepartamentosOfrecido");
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
                    GestoraDepartamentosBL.insertdepartamentoBL(departamentoSeleccionado);
                    listadoDepartamentosOfrecido.Add(departamentoSeleccionado);
                }
                else if (visibilityEditar == "Visible")
                {
                    GestoraDepartamentosBL.updatedepartamentoDAL(departamentoSeleccionado);
                }
                NotifyPropertyChanged("DepartamentoSeleccionado");
                listadoDepartamentosOfrecido = clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
                NotifyPropertyChanged("ListadoDepartamentosOfrecido");
            }
            catch (Exception)
            {
                generarMensajeErrorAsync();
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
                Content = "Ha ocurrido un error" +
                ", espere a que se solucione",
                CloseButtonText = "Ok"
            };
            ContentDialogResult respuesta = await mensajeError.ShowAsync();
        }
        #endregion
    }
}
