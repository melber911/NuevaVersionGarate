using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace WebSites
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }
        void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
            // Ruta dinámica para todas las páginas .aspx
            routes.MapPageRoute(
                "DefaultRoute",        // Nombre de la ruta
                "{page}",              // URL sin .aspx (parámetro dinámico)
                "~/{page}.aspx"        // Mapea dinámicamente a la página con .aspx
            );

            
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            HttpContext.Current.Session["Usuario"] = null;
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            string currentUrl = HttpContext.Current.Request.Url.AbsolutePath;
            if (currentUrl.EndsWith("/index", StringComparison.OrdinalIgnoreCase) || currentUrl.EndsWith("/EndSession", StringComparison.OrdinalIgnoreCase))
            {
                return; // No hacer nada si es la página de login
            }
            // Verificar si la sesión de usuario está inicializada
            //if (HttpContext.Current != null && HttpContext.Current.Session != null)
            //{
            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session["Usuario"] == null && HttpContext.Current.Request.Form["__ASYNCPOST"] == "true")
                {
                    Response.Redirect("/EndSession");
                }
            }
            //}
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}