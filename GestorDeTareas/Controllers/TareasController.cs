using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestorDeTareas.Models;
using GestorDeTareas.ViewModels;

namespace GestorDeTareas.Controllers
{
    [CustomAuthorization]
    public class TareasController : BaseController
    {
        // GET: Tareas
        public ActionResult Index()
        {
            return View(Tarea.ObtenerTareas());
        }

        //// GET: Tareas/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tarea tarea = db.TareaSet.Find(id);
        //    if (tarea == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tarea);
        //}

        // GET: Tareas/Create
        public ActionResult Alta()
        {
            return View(Cargarmodelo());
        }

        private static TareaViewModel Cargarmodelo()
        {
            TareaViewModel modelo = new TareaViewModel();
            using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
            {
                modelo.EstadosDDL = Estado.ObtenerEstados(db).Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.EstadoDesc }).ToList();
                modelo.PrioridadesDDL = Prioridad.ObtenerPrioridades(db).Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.PrioridadDesc }).ToList();
            }
            return modelo;
        }

        // POST: Tareas/Alta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(TareaViewModel modelo)
        {
            using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
            {
                if (ModelState.IsValid)
                {
                    db.TareaSet.Add(new Tarea
                    {
                        Titulo = modelo.Titulo,
                        Descripcion = modelo.Descripcion,
                        UsuarioAsignado = Usuario.ObtenerUsuarioPorId(db, modelo.UsuarioAsignado),
                        FechaVencimiento = modelo.Vencimiento,
                        UsuarioAlta = GetUsuarioLogueado(),
                        FechaAlta = DateTime.Now,
                        Prioridad = Prioridad.ObtenerPrioridad(db, modelo.Prioridad),  //TODO: Si viene null Baja, si no está Baja crearlo
                        Estado = Estado.ObtenerEstado(db, "Pendiente")  //TODO: Pendiente, si no está crearlo
                    });
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            //TODO: Informar Error
            return View(Cargarmodelo());
        }

        //// GET: Tareas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tarea tarea = db.TareaSet.Find(id);
        //    if (tarea == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UsuarioAltaId = new SelectList(db.UsuarioSet, "Id", "Nombre", tarea.UsuarioAltaId);
        //    ViewBag.UsuarioAsignadoId = new SelectList(db.UsuarioSet, "Id", "Nombre", tarea.UsuarioAsignadoId);
        //    ViewBag.UsuarioBajaId = new SelectList(db.UsuarioSet, "Id", "Nombre", tarea.UsuarioBajaId);
        //    ViewBag.PrioridadId = new SelectList(db.PrioridadSet, "Id", "PrioridadDesc", tarea.PrioridadId);
        //    ViewBag.EstadoId = new SelectList(db.EstadoSet, "Id", "EstadoDesc", tarea.EstadoId);
        //    return View(tarea);
        //}

        //// POST: Tareas/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Titulo,Descripcion,UsuarioAsignadoId,FechaVencimiento,UsuarioAltaId,FechaAlta,UsuarioBajaId,FechaBaja,PrioridadId,EstadoId")] Tarea tarea)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tarea).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UsuarioAltaId = new SelectList(db.UsuarioSet, "Id", "Nombre", tarea.UsuarioAltaId);
        //    ViewBag.UsuarioAsignadoId = new SelectList(db.UsuarioSet, "Id", "Nombre", tarea.UsuarioAsignadoId);
        //    ViewBag.UsuarioBajaId = new SelectList(db.UsuarioSet, "Id", "Nombre", tarea.UsuarioBajaId);
        //    ViewBag.PrioridadId = new SelectList(db.PrioridadSet, "Id", "PrioridadDesc", tarea.PrioridadId);
        //    ViewBag.EstadoId = new SelectList(db.EstadoSet, "Id", "EstadoDesc", tarea.EstadoId);
        //    return View(tarea);
        //}

        //// GET: Tareas/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tarea tarea = db.TareaSet.Find(id);
        //    if (tarea == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tarea);
        //}

        //// POST: Tareas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Tarea tarea = db.TareaSet.Find(id);
        //    db.TareaSet.Remove(tarea);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
