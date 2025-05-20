using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bussinessLayer;
using System.Data;

public partial class frmListadoPedidosxPagar : System.Web.UI.Page
{
    void cargarListadoxUsuario()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse =new DataTable();
        dtResponse = lobjProducto.obtenerListadoxCobrar(Session["Usuario"].ToString(), (int)Session["Idsucursal"]);
        Session["gdListadoPedidosPagados"] = dtResponse;
        gdListadoPedidos.DataSource = dtResponse;
        gdListadoPedidos.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
        {
            WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
            return;
        }
        if (!IsPostBack)
        {
            

            cargarListadoxUsuario();

            //if (Request.QueryString["vchUsuario"] == null)
            //{
            //    Response.End();
            //}
            //else {
            //    Session["Usuario"] = Request.QueryString["vchUsuario"];
            //    Response.Redirect("frmListadoPedidosxPagar");
            //}
        }
    }
    protected void gdListadoPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //ImageButton libtBuscar = (ImageButton)e.Row.FindControl("ibtBuscar");

            if (e.Row.Cells[6].Text.Equals("ACTIVO"))
            {
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                e.Row.Cells[6].Font.Bold = true;
            }
            if (e.Row.Cells[6].Text.Equals("PRE-CUENTA"))
            {
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[6].Font.Bold = true;
            }
            if (e.Row.Cells[6].Text.Equals("PAGADO"))
            {
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                e.Row.Cells[6].Font.Bold = true;
            }
            if (e.Row.Cells[6].Text.Equals("ANULADO"))
            {
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[6].Font.Bold = true;
            }
        }
    }
    protected void gdListadoPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detalle")
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;

            string[] valores = e.CommandArgument.ToString().Split('|');

            if (valores[4].Equals("ACTIVO")) {
                ldtResponse = lobjProducto.validarCajaAperturada(Session["Usuario"].ToString(),(int) Session["Idsucursal"]);

                if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("100"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('Por favor abrir una caja para poder generar comprobantes.','Error');", true);
                    return;
                }
            }

            if (valores[4].Equals("ANULADO")) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('El pedido se encuentra anulado.','Info');", true);
                return;
            }

            Response.Redirect("frmGenComprobPago?vchOrdenID=" + valores[1] + "&vchEstado=" + valores[4] + "&vchNumDocu=" + valores[5]);
        }
        if (e.CommandName == "imprimir")
        {
            ifrpdf.Src = $"pdfWeb?ruta={e.CommandArgument.ToString()}";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#pdfModal').modal('show');",
                    true);
        }
    }

    protected void gdListadoPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdListadoPedidos.PageIndex = e.NewPageIndex;
        gdListadoPedidos.DataSource = (DataTable)Session["gdListadoPedidosPagados"];
        gdListadoPedidos.DataBind();
    }

}