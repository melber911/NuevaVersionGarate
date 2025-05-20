using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class pdfWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ruta = Request.QueryString["ruta"].ToString();

            // Transmitir el archivo PDF al navegador
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "inline; filename=20601486718-03-B007-00000003.pdf"); // inline hace que se muestre en el navegador
            Response.TransmitFile(ruta);
            Response.End();
        }
    }
}