using CRUD_Personas_Entidades;
using Microsoft.AspNetCore.Mvc;
using CRUD_Personas_ASP.Models;
using CRUD_Personas_BL.Listado;
using CRUD_Personas_ASP.Models.ViewModels;
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

        public ActionResult Listado(String viewbag)
        {
            vmIndex ovmIndex = null;
            ActionResult actionResult;
            try
            {
             ovmIndex = new vmIndex();
             actionResult = View(ovmIndex.ListadoPersonasConNombreDepartamento);
                ViewBag.Mensaje = viewbag;
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
            string mensaje = "";
            int resultadoCRUD = 0;
            ActionResult actionResult;
            try
            {
                resultadoCRUD = GestoraPersonasBL.insertpersonaBL(vmCreate.PersonaVacia);
                if (resultadoCRUD == 0)
                {
                    mensaje = "No se ha creado correctamente";
                }
                else
                {
                    mensaje = "Se ha creado correctamente";
                }
                actionResult = RedirectToAction("Listado", new { viewbag = mensaje });
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
            string mensaje = "";
            int resultadoCRUD = 0;
            ActionResult actionResult;
            try
            {
                vmCreate.PersonaVacia.Id = id;
                resultadoCRUD = GestoraPersonasBL.updatepersonaBL(vmCreate.PersonaVacia);
                if (resultadoCRUD == 0)
                {
                    mensaje = "No se ha actualizado correctamente";
                }
                else
                {
                    mensaje = "Se ha actualizado correctamente";
                }
                ViewBag.mensaje = mensaje;
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
            clsPersona oPersona;
            clsPersonaConNombreDepartamento oPersonaConNombreDepartamento = null;
            ActionResult actionResult;

            try
            {
               oPersona = clsListadoPersonasBL.obtenerPersona(id);
               oPersonaConNombreDepartamento = new clsPersonaConNombreDepartamento(oPersona, clsDepartamentosBL.obtenerDepartamentoBL(oPersona.IdDepartamento).Nombre);
                actionResult = View(oPersonaConNombreDepartamento);
            }
            catch (Exception)
            {
                actionResult = View("PersonasError");
            }
            
            return actionResult;
        }

        // POST: Personas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteBoton(int id)
        {
            string mensaje = "";
            int resultadoCRUD = 0;
            ActionResult actionResult;
            try
            {
                resultadoCRUD = GestoraPersonasBL.deletepersonaBL(id);
                if (resultadoCRUD == 0)
                {
                    mensaje = "No se ha borrado correctamente";
                }
                else
                {
                    mensaje = "Se ha borrado correctamente";
                }
                actionResult = RedirectToAction("Listado", new {viewBag = mensaje});
            }
            catch
            {
                actionResult = View("PersonasError");
            }
            return actionResult;
        }
    }
}
