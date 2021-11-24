using CRUD_Personas_Entidades;
using System;

namespace CRUD_Personas_ASP.Models
{
    public class clsPersonaConNombreDepartamento : clsPersona
    {
        string nombreDepartamento;

        public clsPersonaConNombreDepartamento(clsPersona clsPersona,  string nombreDepartamento) : base(clsPersona.Id, clsPersona.Nombre, clsPersona.Apellidos,clsPersona.Telefono, clsPersona.Direccion, clsPersona.FechaNac, clsPersona.IdDepartamento, clsPersona.Foto)
        {
            this.NombreDepartamento = nombreDepartamento;
        }
        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
    }
}
