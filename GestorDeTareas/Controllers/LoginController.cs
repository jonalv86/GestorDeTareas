using GestorDeTareas.Models;
using System.Web.Mvc;

namespace GestorDeTareas.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            if (GetUsuarioLogueado() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario)
        {
            GestorDeTareasModelContainer db = new GestorDeTareasModelContainer();
            Usuario user = Usuario.ObtenerCrearUsuario(usuario);
            SetUsuarioLogueado(user);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
