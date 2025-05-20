using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class TicketPreCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                clsSucursal lobjProducto = new clsSucursal();
                var obj = lobjProducto.obtenerEmpresa();
                byte[] imageData = (byte[])obj.Rows[0]["logo"];

                if (imageData != null)
                {
                    string base64String = Convert.ToBase64String(imageData);
                    imgLogo.ImageUrl = "data:image/png;base64," + base64String;
                    imgLogo.ImageUrl = "data:image/png;base64," + base64String;
                    imgLogo.Visible = true;
                }
                CargarDatosTicket();
            }
        }
        private void CargarDatosTicket()
        {
            // Obtener datos de la sesión o parámetros
            DataTable dt = Session["dtPedido"] as DataTable;
            decimal total = 0;

            // Asignar valores a los controles
            lblOrden.Text = Request.QueryString["vchOrdenID"];
            lblSalon.Text = Request.QueryString["vchSalon"];
            lblMesa.Text = Request.QueryString["vchNumMesa"];
            lblAtendio.Text = Session["Usuario"]?.ToString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();

            // Calcular total y bindear items
            if (dt != null)
            {
                // Crear DataTable filtrado solo para items a imprimir
                DataTable dtFiltrado = dt.Clone();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["vchImpresion"].ToString() == "S")
                    {
                        dtFiltrado.ImportRow(row);
                        total += Convert.ToDecimal(row["numPrecioTot"]);
                    }
                }

                rptItems.DataSource = dtFiltrado;
                rptItems.DataBind();
                lblTotal.Text = total.ToString("N2");
            }
        }
    }
}