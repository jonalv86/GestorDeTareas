using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorDeTareas.Models
{
    public partial class Estado
    {
        internal static List<Estado> ObtenerEstados(GestorDeTareasModelContainer db)
        {
            return db.EstadoSet.ToList();
        }

        internal static Estado ObtenerEstado(GestorDeTareasModelContainer db, string nombreEstado)
        {
            return db.EstadoSet.FirstOrDefault(p => p.EstadoDesc == nombreEstado) ?? CrearEstado(db, nombreEstado);
        }

        /// <summary>
        /// A modo de inicialización
        /// </summary>
        /// <param name="db"></param>
        /// <param name="nombreEstado"></param>
        /// <returns></returns>
        private static Estado CrearEstado(GestorDeTareasModelContainer db, string nombreEstado)
        {
            Estado estado = new Estado { EstadoDesc = nombreEstado };
            db.EstadoSet.Add(estado);
            return estado;
        }
    }
}