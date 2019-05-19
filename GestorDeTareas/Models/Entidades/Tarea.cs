using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GestorDeTareas.Models
{
    public partial class Tarea
    {
        internal static List<Tarea> ObtenerTareas(GestorDeTareasModelContainer db)
        {
            return db.TareaSet.Include(t => t.UsuarioAlta).Include(t => t.UsuarioAsignado).Include(t => t.Prioridad).Include(t => t.Estado).ToList();
        }

        internal static Tarea ObtenerTarea(GestorDeTareasModelContainer db, int? id)
        {
            return db.TareaSet.Include(t => t.UsuarioAlta).Include(t => t.UsuarioAsignado).Include(t => t.Prioridad).Include(t => t.Estado).FirstOrDefault(t => t.Id == id && t.FechaBaja == null);
        }

        internal static object ObtenerTareasVigentes(GestorDeTareasModelContainer db)
        {
            return db.TareaSet.Include(t => t.UsuarioAlta).Include(t => t.UsuarioAsignado).Include(t => t.Prioridad).Include(t => t.Estado).Where(t => t.FechaBaja == null).ToList();
        }

        internal static Tarea ObtenerTareaVigente(GestorDeTareasModelContainer db, int idTarea)
        {
            return db.TareaSet.FirstOrDefault(t => t.Id == idTarea && t.FechaBaja == null);
        }

        internal void ActualizarTareaEnDB(GestorDeTareasModelContainer db)
        {
            Tarea original = db.TareaSet.Find(Id);
            if (original != null) db.Entry(original).CurrentValues.SetValues(this);
        }
    }
}