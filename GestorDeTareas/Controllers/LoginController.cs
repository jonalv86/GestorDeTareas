using GestorDeTareas.Models;
using GestorDeTareas.ViewModels;
using System.Web.Mvc;

namespace GestorDeTareas.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            if (GetUsuarioLogueado() != null) return RedirectToAction("Index", "Home");
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel modelo)
        {
            if(ModelState.IsValid)
            {
                using (GestorDeTareasModelContainer db = new GestorDeTareasModelContainer())
                {
                    Usuario user = Usuario.ObtenerCrearUsuario(db, modelo.Nombre);
                    SetUsuarioLogueado(user);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
