using CRUD_Personas_Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_Personas_ASP.Models;
using CRUD_Personas_BL.Listado;
using CRUD_Personas_ASP.Models.ViewModels;
using System.Collections.ObjectModel;
using CRUD_Personas_BL.Gestora;
using System;

namespace CRUD_Personas_ASP.Controllers
{
    public class Personas : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listado()
        {
            vmIndex ovmIndex = null;
            ActionResult actionResult;
            try
            {
             ovmIndex = new vmIndex();
             actionResult = View(ovmIndex.ListadoPersonasConNombreDepartamento);
            }
            catch (Exception)
            {
                actionResult = View("PersonasError");
            }

            return actionResult;
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            clsPersona oPersona = clsListadoPersonasBL.obtenerPersona(id);
            clsPersonaConNombreDepartamento oPersonaConNombreDepartamento = new clsPersonaConNombreDepartamento(oPersona, clsDepartamentosBL.obtenerDepartamentoBL(oPersona.IdDepartamento).Nombre);
            return View(oPersonaConNombreDepartamento);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            vmCreate ovmCreate = null;
            ActionResult actionResult;
            try
            {
                ovmCreate = new vmCreate();
                actionResult = View(ovmCreate);
            }
            catch (Exception)
            {
                actionResult = View("PersonasError");
            }

            return actionResult;
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vmCreate vmCreate)
        {
            ActionResult actionResult;
            try
            {
                GestoraPersonasBL.insertpersonaBL(vmCreate.PersonaVacia);
                actionResult = View(vmCreate);
            }
            catch
            {
                actionResult = View("PersonasError");
            }
            return actionResult;
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            vmCreate ovmCreate = null;
            ActionResult actionResult;
            try
            {
                ovmCreate = new vmCreate();
                ovmCreate.PersonaVacia = clsListadoPersonasBL.obtenerPersona(id);
                actionResult = View(ovmCreate);
            }
            catch (Exception)
            {
                actionResult = View("PersonasError");
            }

            return actionResult;
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,vmCreate vmCreate)
        {
            ActionResult actionResult;
            try
            {
                vmCreate.PersonaVacia.Id = id;
                GestoraPersonasBL.updatepersonaBL(vmCreate.PersonaVacia);
                actionResult = View(vmCreate);
            }
            catch
            {
                actionResult = View("PersonasError");
            }
            return actionResult;
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            clsPersona oPersona = clsListadoPersonasBL.obtenerPersona(id);
            clsPersonaConNombreDepartamento oPersonaConNombreDepartamento = new clsPersonaConNombreDepartamento(oPersona, clsDepartamentosBL.obtenerDepartamentoBL(oPersona.IdDepartamento).Nombre);
            return View(oPersonaConNombreDepartamento);
        }

        // POST: Personas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteBoton(int id)
        {
            ActionResult actionResult;
            try
            {
                GestoraPersonasBL.deletepersonaBL(id);
                actionResult = RedirectToAction("Listado"/*, new {viewBag = "a"}*/);
            }
            catch
            {
                actionResult = View("PersonasError");
            }
            return actionResult;
        }
    }
}
