using GestorDeTareas.Models;
using System.Web.Mvc;

namespace GestorDeTareas
{
    public class CustomAuthorization : FilterAttribute, IAuthorizationFilter
    {
        private const string LogueadoKey = "user";

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Usuario usuarioEnSession = (Usuario)filterContext.Controller.ControllerContext.HttpContext.Session?[LogueadoKey];
            if (usuarioEnSession == null) filterContext.Result = new RedirectResult(new UrlHelper(filterContext.RequestContext).Action("Index", "Login"));
        }
    }
}