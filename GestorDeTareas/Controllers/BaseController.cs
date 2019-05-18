using GestorDeTareas.Models;
using System.Web.Mvc;

namespace GestorDeTareas.Controllers
{
    public class BaseController : Controller
    {
        private const string LogueadoKey = "user";

        public Usuario GetUsuarioLogueado()
        {
            return (Usuario)Session[LogueadoKey];
        }

        public void SetUsuarioLogueado(Usuario usuario)
        {
            Session[LogueadoKey] = usuario;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled) return;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, filterContext.Controller.ControllerContext.RouteData.Values["controller"].ToString(), filterContext.Controller.ControllerContext.RouteData.Values["action"].ToString());
            View("Error", model).ExecuteResult(ControllerContext);
        }
    }
}