using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmListadoMesasPagar : System.Web.UI.Page
{
    public List<Salon> Salones { get; set; } = new List<Salon>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
        {
            WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
            return;
        }
        Salones = cargarMesasConfig();
        GenerarHTMLSalones(Salones);
        if (!IsPostBack)
        {
            
        }
    }
    private void GenerarHTMLSalones(List<Salon> Salones)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse = lobjProducto.obtenerEstadoMesas("1", (int)Session["Idsucursal"]);

        StringBuilder htmlContent = new StringBuilder();

        int salonIndex = 1;
        foreach (var salon in Salones)
        {
            // Clase activa para la primera pestaña
            string activeClass = salonIndex == 1 ? "show active" : "";

            // Contenedor del salón
            htmlContent.Append($@"
        <div class='tab-pane fade {activeClass}' 
             id='pills-salon{salon.Id}' 
             role='tabpanel' 
             aria-labelledby='pills-salon{salon.Id}-tab'>
            <div class='btn-toolbar d-flex justify-content-center' role='toolbar' aria-label='Toolbar with button groups'>");

            // Generar los botones de las mesas
            for (int i = 1; i <= salon.NroMesas; i++)
            {
                // Verificar el estado de la mesa en el DataTable
                DataRow[] estadoMesa = dtResponse.Select($"ordenSalon = '{salonIndex}' AND ordenMesa = '{i}'");
                string backgroundColor = estadoMesa.Length > 0 ? "red" : "#008f39"; // Rojo si está ocupada, verde si está libre
                string disabled = estadoMesa.Length > 0 ? "" : "disabled";
                htmlContent.Append($@"
            <div class='btn-group m-1' role='group'>
                <button class='btn btn-primary mesa-btn' type='button' 
                        onclick='clickPedido({salonIndex}, {i})' 
                        {disabled}
                        style='background-color: {backgroundColor}; height: 60px; width: 85px'>
                    {i}
                </button>
            </div>");
            }

            // Cerrar contenedor del salón
            htmlContent.Append("</div></div>");

            salonIndex++;
        }

        // Asignar el HTML generado al control en el frontend
        TabContentPlaceholder.Controls.Add(new Literal { Text = htmlContent.ToString() });
    }
    void cargarListadoxUsuario()
    {
        clsProducto lobjProducto = new clsProducto();
        //DataTable dtResponse;
        Session["gdListadoPedidos"] = lobjProducto.obtenerListadoDivididoxCobrar(Session["Usuario"].ToString(), (int)Session["Idsucursal"]);
        gdListadoPedidos.DataSource = (DataTable)Session["gdListadoPedidos"];
        gdListadoPedidos.DataBind();
    }
    void cargarListadoxUsuarioFiltro()
    {
        clsProducto lobjProducto = new clsProducto();
        //DataTable dtResponse;
        Session["gdListadoPedidos"] = lobjProducto.obtenerListadoDivididoxCobrar(Session["Usuario"].ToString(), (int)Session["Idsucursal"]).AsEnumerable()
            .Where(x => x.Field<int>("ordenSalon") == int.Parse(salon.Value) && x.Field<int>("ordenMesa") == int.Parse( mesa.Value)).CopyToDataTable();
        gdListadoPedidos.DataSource = (DataTable)Session["gdListadoPedidos"];
        gdListadoPedidos.DataBind();
    }
    private List<Salon> cargarMesasConfig()
    {
        List<Salon> salones = new List<Salon>();
        clsSucursal lobjSucursal = new clsSucursal();
        DataTable ldtResponse = lobjSucursal.obtenerMesas();

        var filteredRows = ldtResponse.AsEnumerable()
            .Where(myrow => myrow.Field<int>("id_sucursal") == (int)Session["Idsucursal"])
            .OrderBy(myrow => myrow.Field<int>("nroOrden"));

        foreach (var item in filteredRows)
        {
            salones.Add(new Salon
            {
                Id = item.Field<int>("id"),
                Descripcion = item.Field<string>("nombre"),
                NroMesas = item.Field<int>("nroMesas")
            });
        }
        return salones;
    }
   
    protected void btnParaLLevar_Click(object sender, EventArgs e)
    {
        cargarListadoxUsuario2();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal2').modal('show');",
                    true);
    }
    void cargarListadoxUsuario2()
    {
        clsProducto lobjProducto = new clsProducto();
        //DataTable dtResponse;
        Session["gdListadoPedidos2"] = lobjProducto.obtenerListadoLlevarxCobrar(Session["Usuario"].ToString(), (int)Session["Idsucursal"]);
        gdListadoPedidos2.DataSource = (DataTable)Session["gdListadoPedidos2"];
        gdListadoPedidos2.DataBind();
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

            if (valores[4].Equals("ACTIVO"))
            {
                ldtResponse = lobjProducto.validarCajaAperturada(Session["Usuario"].ToString(), (int)Session["Idsucursal"]);

                if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("100"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "swal('El usuario no tiene permisos para esta caja.');", true);
                    return;
                }
                else if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("300"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "swal('Primero debe realizar el cierre de caja del día anterior.');", true);
                    return;
                }
                else if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("400"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "swal('Primero debe abrir una caja');", true);
                    return;
                }
            }

            if (valores[4].Equals("ANULADO"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('El pedido se encuentra anulado.','info');", true);
                return;
            }

            Response.Redirect("frmGenComprobPago?vchOrdenID=" + valores[1] + "&vchEstado=" + valores[4] + "&vchNumDocu=" + valores[5]);
        }
    }

    protected void btnDivision_Click(object sender, EventArgs e)
    {
        cargarListadoxUsuario();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('show');",
                    true);
    }

    protected void gdListadoPedidos2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detalle")
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;

            string[] valores = e.CommandArgument.ToString().Split('|');

            if (valores[4].Equals("ACTIVO"))
            {
                ldtResponse = lobjProducto.validarCajaAperturada(Session["Usuario"].ToString(), (int)Session["Idsucursal"]);

                if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("100"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "swal('El usuario no tiene permisos para esta caja.');", true);
                    return;
                }
                else if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("300"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "swal('Primero debe realizar el cierre de caja del día anterior.');", true);
                    return;
                }
                else if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("400"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "swal('Primero debe abrir una caja');", true);
                    return;
                }
            }

            if (valores[4].Equals("ANULADO"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('El pedido se encuentra anulado.','info');", true);
                return;
            }

            Response.Redirect("frmGenComprobPago?vchOrdenID=" + valores[1] + "&vchEstado=" + valores[4] + "&vchNumDocu=" + valores[5]);
        }
    }

    protected void gdListadoPedidos2_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gdListadoPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdListadoPedidos.PageIndex = e.NewPageIndex;
        gdListadoPedidos.DataSource = (DataTable)Session["gdListadoPedidos"];
        gdListadoPedidos.DataBind();
    }

    protected void gdListadoPedidos2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdListadoPedidos2.PageIndex = e.NewPageIndex;
        gdListadoPedidos2.DataSource = (DataTable)Session["gdListadoPedidos2"];
        gdListadoPedidos2.DataBind();
    }

    protected void btnMesa_Click(object sender, EventArgs e)
    {
        DataTable ldtresponse;
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtresponse_2;

        ldtresponse_2 = lobjProducto.validarCajaAperturada(Session["Usuario"].ToString(), (int)Session["Idsucursal"]);

        if (ldtresponse_2.Rows[0]["CodigoRespuesta"].ToString().Equals("100"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "swal('El usuario no tiene permisos para esta caja.');", true);
            return;
        }
        else if (ldtresponse_2.Rows[0]["CodigoRespuesta"].ToString().Equals("300"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "swal('Primero debe realizar el cierre de caja del día anterior.');", true);
            return;
        }
        else if (ldtresponse_2.Rows[0]["CodigoRespuesta"].ToString().Equals("400"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "swal('Primero debe abrir una caja');", true);
            return;
        }

        ldtresponse = lobjProducto.obtenerDatosMesasDetalle(salon.Value,mesa.Value, (int)Session["Idsucursal"]);
        if (ldtresponse.Rows.Count>1)
        {
            cargarListadoxUsuarioFiltro();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('show');",
                    true);
        }
        else
            Response.Redirect("frmGenComprobPago?vchOrdenID=" + ldtresponse.Rows[0]["ordenID"] + "&vchEstado=" + ldtresponse.Rows[0]["ordenEstado"] + "&vchNumDocu=-");
    }
}