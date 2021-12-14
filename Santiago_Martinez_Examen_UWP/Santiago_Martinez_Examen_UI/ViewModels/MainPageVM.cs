using CRUD_Personas_UWP.ViewModels.Utilidades;
using Santaigo_Martinez_ExamenUWP_Entidades;
using Santiago_Martinez_Examen_UI.Models;
using Santiago_Martinez_ExamenUWP_Entidades;
using Santaigo_Martinez_ExamenUWP_BL.Listado;
using Santiago_Martinez_Examen_BL.Gestora;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Santiago_Martinez_Examen_BL.Listado;

namespace Santiago_Martinez_Examen_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        ObservableCollection<clsPlantaConCantidad> listadoPlantasConCantidad;
        clsContabilidad contabilidadDia;
        DelegateCommand guardarRecaudacion;
        DelegateCommand calcularRecaudacion;
        string visibilidadResultado = "Collapsed";

        public MainPageVM()
        {
            this.listadoPlantasConCantidad = rellenarListadoPlantasConCantidad();
            this.contabilidadDia = new clsContabilidad();
        }

        public ObservableCollection<clsPlantaConCantidad> ListadoPlantasConCantidad { get => listadoPlantasConCantidad; set => listadoPlantasConCantidad = value; }
        public clsContabilidad ContabilidadDia
        {
            get => contabilidadDia;
            set
            {
                contabilidadDia = value;
                calcularRecaudacion.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand CalcularRecaudacion
        {
            get
            { 
                calcularRecaudacion = new DelegateCommand(CalcularCommand_Executed);
                return calcularRecaudacion;
            }

            set => calcularRecaudacion = value;
        }
        public string VisibilidadResultado { get => visibilidadResultado; set => visibilidadResultado = value; }
        public DelegateCommand GuardarRecaudacion
        {
            get
            {
                guardarRecaudacion = new DelegateCommand(GuardarCommand_Executed, PuedeEjercutarGuardar);
                return guardarRecaudacion;
            }
            set => guardarRecaudacion = value;
        }


        /// <summary>
        ///     <cabecera>private bool PuedeEjercutarGu()</cabecera>
        ///     <descripcion>
        ///         Método para comprobar que el command guardar se puede ejecutar.
        ///         Se ejecutará en el caso de que la recaudación real sea distinta de 0
        ///     </descripcion>
        /// </summary>
        /// <returns></returns>
        private bool PuedeEjercutarGuardar()
        {
            bool valido = true;

            if (contabilidadDia.RecaudacionReal == 0)//aprovecho que hago la comprobación de si es nulo el textbox para eso
            {
                valido = false;
            }
            return valido;
        }

        

        //En este método haría un if para comprobar si actualizar o insertar, pero no me funciona el método de comprobación(está en listadoContabilidad)
        /// <summary>
        ///     <cabecera>private void GuardarCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command guardar al ser ejecutado.
        ///         El command actualiza la base de datos
        ///     </descripcion>
        /// </summary>
        private void GuardarCommand_Executed()
        {
            try
            {
                //contabilidadDia.Fecha = new DateTime(2002,4,19);
                clsGestoraContabilidadBL.guardarRecaudacionBL(contabilidadDia);
                contabilidadDia.RecaudacionReal = 0;
                NotifyPropertyChanged("ContabilidadDia");
                guardarRecaudacion.RaiseCanExecuteChanged();
            }
            catch (Exception)
            {
                generarMensajeErrorAsync();
            }
        }

        /// <summary>
        ///     <cabecera>private void CalcularCommand_Executed()</cabecera>
        ///     <descripcion>
        ///         Método para realizar la función del command calcular al ser ejecutado.
        ///         El command calcula el valor de la recaudacion del dia
        ///     </descripcion>
        /// </summary>
        private void CalcularCommand_Executed()
        {
            contabilidadDia.RecaudacionReal = 0;
            NotifyPropertyChanged("ContabilidadDia");
            foreach (clsPlantaConCantidad plantaConCantidad in listadoPlantasConCantidad)
            {
                contabilidadDia.RecaudacionReal += plantaConCantidad.Precio * plantaConCantidad.Cantidad;
            }
            guardarRecaudacion.RaiseCanExecuteChanged();
            NotifyPropertyChanged("ContabilidadDia");
            visibilidadResultado = "Visible";
            NotifyPropertyChanged("VisibilidadResultado");
        }

        /// <summary>
        /// <cadecera>private ObservableCollection<clsPlantaConCantidad> rellenarListadoPlantasConCantidad()</cadecera>
        /// <descripcion>Método para rellenar una lista con plantas con cantidad</descripcion>
        /// <precondiciones></precondiciones>
        /// <postcondiciones>lista devuelta</postcondiciones>
        /// </summary>
        /// <returns>ObservableCollection(clsPlantaConCantidad)</returns>
        private ObservableCollection<clsPlantaConCantidad> rellenarListadoPlantasConCantidad()
        {
            ObservableCollection<clsPlantaConCantidad> listadoPlantasConCantidades = new ObservableCollection<clsPlantaConCantidad>();
            try
            {
                listadoPlantasConCantidades = new ObservableCollection<clsPlantaConCantidad>();
                ObservableCollection<clsPlanta> listadoPlantas = clsListadoPlantasBL.obtenerListadoPlantasBL();

                foreach (clsPlanta planta in listadoPlantas)
                {
                    listadoPlantasConCantidades.Add(new clsPlantaConCantidad(planta, 0));
                }
            }
            catch (Exception)
            {
                generarMensajeErrorAsync();
            }


            return listadoPlantasConCantidades;

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
    }
}
