using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Eliminar variables de sesión MVO
            Session.Clear();
            Session.Abandon();

            // Borrar cookie "privileges" si existe
            if (Request.Cookies["privileges"] != null)
            {
                HttpCookie privilegesCookie = new HttpCookie("privileges");
                privilegesCookie.Expires = DateTime.Now.AddDays(-1); // Fecha expirada
                privilegesCookie.Path = "/";
                Response.Cookies.Add(privilegesCookie);
            }

            // Redirigir al login
            Response.Redirect("Login.aspx");
        }
    }
}