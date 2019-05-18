using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorDeTareas.Models
{
    public partial class Usuario
    {
        internal static Usuario ObtenerCrearUsuario(GestorDeTareasModelContainer db, string nombre)
        {
            return db.UsuarioSet.FirstOrDefault(u => u.Nombre == nombre) ?? CrearUsuario(db, nombre);
        }

        private static Usuario CrearUsuario(GestorDeTareasModelContainer db, string nombre)
        {
            Usuario user = new Usuario { Nombre = nombre };
            db.UsuarioSet.Add(user);
            db.SaveChanges();
            return user;
        }

        internal static List<Usuario> ObtenerUsuarios(GestorDeTareasModelContainer db)
        {
            return db.UsuarioSet.ToList();
        }

        internal static Usuario ObtenerUsuarioPorId(GestorDeTareasModelContainer db, int? id)
        {
            return db.UsuarioSet.FirstOrDefault(u => u.Id == id);
        }
    }
}