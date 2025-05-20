using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bussinessLayer;
using System.Data;

public partial class frmListadoPagadosSUNAT : System.Web.UI.Page
{
    void cargarListadoxUsuario()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse = new DataTable();
        dtResponse = lobjProducto.obtenerListadoStatusSUNAT(Session["Usuario"].ToString(), (int)Session["Idsucursal"]);
        Session["gdListadoSUNAT"] = dtResponse;
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

        }
    }

    protected void gdListadoPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton libtBuscar = (LinkButton)e.Row.FindControl("ibtBuscar");

            if (e.Row.Cells[4].Text.Equals("ACEPTADO"))
            {
                e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                e.Row.Cells[4].Font.Bold = true;
                libtBuscar.Visible = false;
            }
            else {
                e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[4].Font.Bold = true;
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

            if (!valores[4].Equals("ACEPTADO"))
            {
                ldtResponse = lobjProducto.validarCajaAperturada(Session["Usuario"].ToString(), (int)Session["Idsucursal"]);

                if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("100"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('Por favor abrir una caja para poder generar comprobantes.','Error');", true);
                    return;
                }
            }

            Response.Redirect("frmGenComprobPago_v2?vchOrdenID=" + valores[1] + "&vchEstado=" + valores[4] + "&vchNumDocu=" + valores[5]);
        }
    }

    protected void gdListadoPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdListadoPedidos.PageIndex = e.NewPageIndex;
        gdListadoPedidos.DataSource = (DataTable)Session["gdListadoSUNAT"];
        gdListadoPedidos.DataBind();
    }
}