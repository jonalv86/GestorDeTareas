using GestorDeTareas.Models;
using GestorDeTareas.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace GestorDeTareas.Controllers
{
    [CustomAuthorization]
    public class TareasController : BaseController
    {
        // GET: Tareas
        public ActionResult Index()
        {
            using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer()) return View(Tarea.ObtenerTareasVigentes(db));
        }

        // GET: Tareas/Create
        public ActionResult Alta()
        {
            return View(Cargarmodelo());
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

        // GET: Tareas/Details/5
        public ActionResult Ver(int? id)
        {
            using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
            {
                Tarea tarea = Tarea.ObtenerTarea(db, id);
                if (tarea == null)
                {
                    //InformarError
                    return RedirectToAction("Index");
                }
                return View(tarea);
            }
        }

        // GET: Tareas/Edit/5
        public ActionResult Editar(int? id)
        {
            int idUsuarioLogueado = GetUsuarioLogueado().Id;
            using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
            {
                Tarea tarea = Tarea.ObtenerTarea(db, id);
                if (tarea == null || (tarea.UsuarioAltaId != idUsuarioLogueado && tarea.UsuarioAsignadoId != idUsuarioLogueado))
                {
                    //TODO: InformarError
                    return RedirectToAction("Index");
                }
                return View(CargarModelo(tarea));
            }
        }

        // POST: Tareas/Edit/5
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

        [HttpPost]
        public JsonResult ActualizarVencimiento(int IdTarea, DateTime Fecha)
        {
            bool error = false;
            using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
            {
                Tarea tarea = Tarea.ObtenerTareaVigente(db, IdTarea);
                if (tarea != null && tarea.UsuarioAltaId == GetUsuarioLogueado().Id)
                {
                    tarea.FechaVencimiento = Fecha;
                    tarea.ActualizarTareaEnDB(db);
                    db.SaveChanges();
                }
                else
                {
                    error = true;
                }
            }
            return new JsonResult
            {
                Data = new
                {
                    success = true,
                    error
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public JsonResult ActualizarPrioridad(int IdTarea, int IdPrioridad)
        {
            bool error = false;
            try
            {
                using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
                {
                    Tarea tarea = Tarea.ObtenerTareaVigente(db, IdTarea);
                    if (tarea != null && tarea.UsuarioAltaId == GetUsuarioLogueado().Id)
                    {
                        tarea.PrioridadId = IdPrioridad;
                        tarea.ActualizarTareaEnDB(db);
                        db.SaveChanges();
                    }
                    else
                    {
                        error = true;
                    }
                }
            }
            catch (Exception ex)
            {
                error = true;
            }
            return new JsonResult
            {
                Data = new
                {
                    success = true,
                    error
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
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

        private TareaViewModel CargarModelo(Tarea tarea)
        {
            TareaViewModel modelo = new TareaViewModel
            {
                Id = tarea.Id,
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                UsuarioAsignado = tarea.UsuarioAsignadoId,
                UsuarioAltaId = tarea.UsuarioAltaId,
                Vencimiento = tarea.FechaVencimiento,
                NombreUsuAlta = tarea.UsuarioAlta.Nombre,
                NombreUsuAsignado = tarea.UsuarioAsignado?.Nombre,
                NombreEstado = tarea.Estado.EstadoDesc,
                NombrePrioridad = tarea.Prioridad.PrioridadDesc,
                FechaAlta = tarea.FechaAlta,
                Prioridad = tarea.PrioridadId,
                Estado = tarea.EstadoId
            };
            using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
            {
                modelo.EstadosDDL = Estado.ObtenerEstados(db).Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.EstadoDesc }).ToList();
                modelo.PrioridadesDDL = Prioridad.ObtenerPrioridades(db).Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.PrioridadDesc }).ToList();
                modelo.UsuariosDDL = Usuario.ObtenerUsuarios(db).Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.Nombre }).ToList();
            }
            return modelo;
        }
    }
}
