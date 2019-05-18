using System.Collections.Generic;
using System.Linq;

namespace GestorDeTareas.Models
{
    public partial class Prioridad
    {
        internal static List<Prioridad> ObtenerPrioridades(GestorDeTareasModelContainer db)
        {
            return db.PrioridadSet.ToList();
        }

        internal static Prioridad ObtenerPrioridad(GestorDeTareasModelContainer db, int prioridadId)
        {
            return db.PrioridadSet.FirstOrDefault(p => p.Id == prioridadId) ?? ObtenerPrioridad(db, "Baja");
        }

        private static Prioridad ObtenerPrioridad(GestorDeTareasModelContainer db, string desc)
        {
            return db.PrioridadSet.FirstOrDefault(p => p.PrioridadDesc == desc) ?? CrearPrioridad(db, "Baja");
        }

        /// <summary>
        /// A modeo de Inicialización
        /// </summary>
        /// <param name="db"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private static Prioridad CrearPrioridad(GestorDeTareasModelContainer db, string desc)
        {
            Prioridad prioridad = new Prioridad { PrioridadDesc = desc };
            db.PrioridadSet.Add(prioridad);
            return prioridad;
        }
    }
}