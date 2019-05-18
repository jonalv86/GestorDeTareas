using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GestorDeTareas.Models
{
    public partial class Tarea
    {
        internal static List<Tarea> ObtenerTareas()
        {
            List<Tarea> tareas = new List<Tarea>();
            try
            {
                using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
                {
                    tareas = db.TareaSet.Include(t => t.UsuarioAlta).Include(t => t.UsuarioAsignado).Include(t => t.UsuarioBaja).Include(t => t.Prioridad).Include(t => t.Estado).ToList();
                }
            }
            catch (Exception ex)
            {
                //TODO:
            }
            return tareas;
        }
    }
}