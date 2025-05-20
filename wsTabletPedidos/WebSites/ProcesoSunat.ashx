<%@ WebHandler Language="C#" Class="WebSites.ProcesoSunat" %>
using System;
using System.Threading.Tasks;
using System.Web;
using WebSites.Utils;
using System.Web.Hosting;

namespace WebSites
{
    public class ProcesoSunat : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        

        public void ProcessRequest(HttpContext context)
        {
           int id = 0;
            if (context.Session != null && context.Session["Idsucursal"] != null)
            {
                id = (int)context.Session["Idsucursal"];
            }

           HostingEnvironment.QueueBackgroundWorkItem(ct =>
            {
                var envio = new EnvioSunat();
                envio.enviarPendientes(id);
            });

            context.Response.ContentType = "application/json";
            context.Response.Write("{\"status\": \"Proceso en segundo plano iniciado\"}");
        }

        public bool IsReusable { get { return false; } }

        
    }
}