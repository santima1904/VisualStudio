using CRUD_Personas_Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_Personas_ASP.Models;
using CRUD_Personas_BL.Listado;
using CRUD_Personas_ASP.Models.ViewModels;
using System.Collections.ObjectModel;
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
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
