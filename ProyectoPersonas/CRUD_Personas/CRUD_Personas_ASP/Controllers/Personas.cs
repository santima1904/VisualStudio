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
            try
            {
             ovmIndex = new vmIndex();
            }
            catch (Exception)
            {
                //Enviar vista error
            }

            return View(ovmIndex.ListadoPersonasConNombreDepartamento);
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            vmCreate ovmCreate = null;
            try
            {
                ovmCreate = new vmCreate();
            }
            catch (Exception)
            {
                //Enviar vista error
            }

            return View(ovmCreate);
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(vmCreate vmCreate)
        {
            try
            {
                GestoraPersonasBL.insertpersonaBL(vmCreate.PersonaVacia);
            }
            catch
            {
                //Enviar vista error
            }
            return View(vmCreate);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            vmCreate ovmCreate = null;
            try
            {
                ovmCreate = new vmCreate();
                ovmCreate.PersonaVacia = clsListadoPersonasBL.obtenerPersona(id);
            }
            catch (Exception)
            {
                //Enviar vista error
            }

            return View(ovmCreate);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, vmCreate vmCreate)
        {
            try
            {
                GestoraPersonasBL.updatepersonaBL(vmCreate.PersonaVacia);
            }
            catch
            {
                //Enviar vista error
            }
            return View(vmCreate);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
