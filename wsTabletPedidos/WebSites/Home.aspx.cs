using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
                return;
            }
            ClientScript.GetPostBackEventReference(this, "");
        }
        [WebMethod]
        public static async Task<string> MiMetodoServidor()
        {
            await Task.Delay(200); // Simula una operación lenta de 2 segundos
            return "¡Respuesta asincrónica desde el servidor!";
        }
    }
}