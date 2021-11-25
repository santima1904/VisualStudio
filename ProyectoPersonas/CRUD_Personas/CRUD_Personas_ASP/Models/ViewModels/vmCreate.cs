using CRUD_Personas_Entidades;
using System.Collections.ObjectModel;

namespace CRUD_Personas_ASP.Models.ViewModels
{
    public class vmCreate
    {
        clsPersona personaVacia;
        ObservableCollection<Departamento> departamentos;

        public clsPersona PersonaVacia { get => personaVacia; set => personaVacia = value; }
        public ObservableCollection<Departamento> Departamentos { get => departamentos; set => departamentos = value; }

        public vmCreate()
        {
            this.personaVacia = new clsPersona();
            this.departamentos = CRUD_Personas_BL.Listado.clsDepartamentosBL.obtenerListadoDepartamentosCompleto_BL();
        }
    }
}
