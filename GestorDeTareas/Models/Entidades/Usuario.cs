using System.Linq;

namespace GestorDeTareas.Models
{
    public partial class Usuario
    {
        internal static Usuario ObtenerCrearUsuario(string nombre)
        {
            using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
            {
                Usuario user = db.UsuarioSet.FirstOrDefault(u => u.Nombre == nombre);
                if(user == null)
                {
                    user = new Usuario { Nombre = nombre };
                    db.UsuarioSet.Add(user);
                    db.SaveChanges();
                }
                return user;
            }
        }
    }
}