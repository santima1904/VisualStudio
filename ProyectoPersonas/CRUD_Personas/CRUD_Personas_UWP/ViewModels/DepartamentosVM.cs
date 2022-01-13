using CRUD_Personas_BL.Gestora;
using CRUD_Personas_BL.Listado;
using CRUD_Personas_Entidades;
using CRUD_Personas_UWP.ViewModels.Utilidades;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace CRUD_Personas_UWP.ViewModels
{
    public class DepartamentosVM : clsVMBase
    {
        #region atributos privados
        ObservableCollection<Departamento> listadoDepartamentosCompleto;
        ObservableCollection<Departamento> listadoDepartamentosOfrecido;
        Departamento departamentoSeleccionado;
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
                nomostrarDepartamentoPorDefecto();
                NotifyPropertyChanged("ListadoDepartamentosOfrecido");
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
                if (visibilityAnhadir == "Visible")//esta condicion la hago para que en el caso de añadir depaartamento,
                                                   //si seleccionas un departamento se cambie a editar, en vez de crear un nuevo departamento con los datos de el previo
                {
                    visibilityAnhadir = "Collapsed";
                    visibilityDetalles = "Collapsed";
                    visibilityEditar = "Visible";
                    NotifyPropertyChanged("VisibilityAnhadir");
                    NotifyPropertyChanged("VisibilityDetalles");
                    NotifyPropertyChanged("VisibilityEditar");
                }
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
                    GestoraDepartamentosBL.deletedepartamentoBL(departamentoSeleccionado.Id);
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
                listadoDepartamentosOfrecido = clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
                nomostrarDepartamentoPorDefecto();
                NotifyPropertyChanged("DepartamentoSeleccionado");
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
                Content = "Ha ocurrido un error",
                CloseButtonText = "Ok"
            };
            await mensajeError.ShowAsync();
        }

        /// <summary>
        ///     <cabecera>private void nomostrarDepartamentoSinnombre()</cabecera>
        ///     <descripcion>
        ///         Método para borrar el primer departamento de la lista a ofrecer ya que no queremos que se modifique 
        ///     </descripcion> 
        /// </summary>
        private void nomostrarDepartamentoPorDefecto()
        { 
         listadoDepartamentosOfrecido.RemoveAt(0);
        }
        #endregion
    }
}
