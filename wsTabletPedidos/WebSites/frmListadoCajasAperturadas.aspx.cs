using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bussinessLayer;
using CrearTicketVenta;

public partial class frmListadoCajasAperturadas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
        {
            WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
            return;
        }
        if (!IsPostBack) {
            
            cargarCajas();
            cargarDatosMovCaja();
            if (Session["Perfil"].ToString()== "Cajero")
            {
                ddlUsuario.Enabled = false;
                ddlUsuario2.Enabled = false;
            }
        }
    }

    void cargarCajas() {
        clsProducto lobjProducto = new clsProducto();

        gdCajasTurno.DataSource = lobjProducto.obtenerCajasTurno("", (int) Session["Idsucursal"]);
        gdCajasTurno.DataBind();
    }


    protected void gdCajasTurno_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.Cells[1].Text.Equals("ABIERTO"))
        //    {
        //        e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
        //        e.Row.Cells[1].Font.Bold = true;
        //    }
        //    if (e.Row.Cells[1].Text.Equals("CERRADO"))
        //    {
        //        e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
        //        e.Row.Cells[1].Font.Bold = true;
        //    }
        //}
    }
    protected void gdCajasTurno_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detalle")
        {
            string[] valores = e.CommandArgument.ToString().Split('|');
            Session["MovCajaID"] = valores[1];
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "verdetalle();",
                    true);
        }
        else if (e.CommandName == "Ingresos")
        {
            string[] valores = e.CommandArgument.ToString().Split('|');
            Response.Redirect("OtrosIngresos?vchCajaId=" + valores[1]);
        }
    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (txtMontoInicio.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Completar el monto inicial de la caja.','Monto Inicio');", true);
            return;
        }
        aperturarCaja(ddlCaja.SelectedValue,
                      ddlUsuario.SelectedValue,
                      Convert.ToInt32(ddlTurno.SelectedValue),
                      Convert.ToDouble(txtMontoInicio.Value.Trim()),
                      Session["Usuario"].ToString());
        cargarCajas();
    }
    void aperturarCaja(String pstrCajaID,
                       String pstrEmpleadoID,
                       Int32 pintTurno,
                       Double pdblMontoIni,
                       String pstrUsuario)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;

        dtResponse = lobjProducto.aperturarCaja(pstrCajaID,
                                                pstrEmpleadoID,
                                                pintTurno,
                                                pdblMontoIni,
                                                pstrUsuario,
                                                (int) Session["Idsucursal"]);
        if (dtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("100"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('" + dtResponse.Rows[0]["MensajeRespuesta"].ToString() + "','Error');", true);
            return ;
        }
        if (dtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("200"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                "$('#mymodal').modal('hide');" +
                "toastr.success('" + dtResponse.Rows[0]["MensajeRespuesta"].ToString() + "','Bien');", true);
        }
    }
    void cargarDatosMovCaja()
    {
        clsProducto lobjProducto = new clsProducto();
        DataSet dsResponse;

        dsResponse = lobjProducto.obtenerDatosMovCaja("", (int)Session["Idsucursal"]);

        ddlCaja.DataTextField = "cajaNombre";
        ddlCaja.DataValueField = "cajaID";
        ddlCaja.DataSource = dsResponse.Tables[0];
        ddlCaja.DataBind();


        ddlUsuario.DataTextField = "nombresApellidos";
        ddlUsuario.DataValueField = "empID";
        ddlUsuario.DataSource = dsResponse.Tables[1];
        ddlUsuario.DataBind();

        ddlUsuario.SelectedValue = Session["empID"].ToString();

        lblFechaAper.Value = DateTime.Now.ToString("yyyy-MM-dd");

        ddlCaja2.DataTextField = "cajaNombre";
        ddlCaja2.DataValueField = "cajaID";
        ddlCaja2.DataSource = dsResponse.Tables[0];
        ddlCaja2.DataBind();

        ddlUsuario2.DataTextField = "nombresApellidos";
        ddlUsuario2.DataValueField = "empID";
        ddlUsuario2.DataSource = dsResponse.Tables[1];
        ddlUsuario2.DataBind();
        ddlUsuario2.SelectedValue = Session["empID"].ToString();
    }

    protected void BtnGuardar2_Click(object sender, EventArgs e)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;
        DataTable dtResponse2;
        Double ldblMontoFinal = 0.0;

        dtResponse2 = lobjProducto.obtenerMesasPendientes((int)Session["Idsucursal"]);

        if (dtResponse2.Rows.Count > 0)
        {
            //Response.Write("<script>toastr.error('Todas las mesas deben estar pagadas.','Error');</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                "toastr.error('Todas las mesas deben estar pagadas.','Error');", true);
            return;
        }
        if (txtefectivoTotal.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Completar el monto total en efectivo.','Total Efectivo');", true);
            return;
        }
        if (txtDepositoTotal.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Completar el monto total en deposito.','Total Deposito');", true);
            return;
        }
        if (txtTarjetaTotal.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Completar el monto total en tarjeta.','Total Tarjeta');", true);
            return;
        }
        dtResponse = lobjProducto.obtenerValoresArqueoCierreCaja(Convert.ToInt32(Session["MovCajaID"].ToString()), Session["Usuario"].ToString(),
            double.Parse (txtefectivoTotal.Value),double.Parse(txtTarjetaTotal.Value),double.Parse(txtDepositoTotal.Value),double.Parse(txtefectivoTotal.Value));
        hdMesaId.Value = Session["MovCajaID"].ToString();
        //imprimirCierre();
        cargarCajas();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal2').modal('hide');"+
                    "crearIframe();" +
                    "toastr.success('Se realizo el cierre de caja correctamente','Bien');"+
                    "$('#pdfModal').modal('show');",
                    true);
    }

    protected void EventDetalle_Click(object sender, EventArgs e)
    {
        string MovCajaID = Session["MovCajaID"].ToString();
        cargarDatosDetalleCaja(Convert.ToInt32(MovCajaID));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
               "$('#mymodal2').modal('show');" , true);
    }
    void cargarDatosDetalleCaja(Int32 pintMovCajaID)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;

        dtResponse = lobjProducto.obtenerCajaID(pintMovCajaID);

        ddlCaja2.SelectedValue = dtResponse.Rows[0]["cajaID"].ToString();
        ddlUsuario2.SelectedValue = dtResponse.Rows[0]["empID"].ToString();
        lblFechaAper2.Value = Convert.ToDateTime( dtResponse.Rows[0]["fecApertura"]).ToString("yyyy-MM-dd");
        ddlTurno2.SelectedValue = dtResponse.Rows[0]["movTurnoId"].ToString();
        txtMontoInicio2.Value = dtResponse.Rows[0]["movCajaMontoIni"].ToString();
        lblEstado.Text = dtResponse.Rows[0]["cajaEstado"].ToString();
    }
    void imprimirCierre()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;
        DataTable dtResponse2;
        Double ldblMontoFinal = 0.0;

        dtResponse2 = lobjProducto.obtenerMesasPendientes(0);


        dtResponse = null;//lobjProducto.obtenerValoresArqueoCierreCaja(Convert.ToInt32(Session["MovCajaID"].ToString()), Session["Usuario"].ToString());

        for (int i = 0; i <= dtResponse.Rows.Count - 1; i++)
        {
            ldblMontoFinal = ldblMontoFinal + Convert.ToDouble(dtResponse.Rows[i]["Monto"].ToString());
        }
        //Creamos una instancia d ela clase CrearTicket
        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("*****CIERRE DE CAJA*****");
        ticket.TextoCentro("" + DateTime.Now.ToString());
        //ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
        //ticket.TextoIzquierda("DIREC: DIRECCION DE LA EMPRESA");
        //ticket.TextoIzquierda("TELEF: 4530000");
        //ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
        //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("Caja # 1", "Ticket # 002-0000006");
        ticket.lineasAsteriscos();

        //Sub cabecera.
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("Caja: " + ddlCaja2.SelectedItem.Text);
        ticket.TextoIzquierda("Fecha: " + lblFechaAper2.Value);
        ticket.TextoIzquierda("Turno: " + ddlTurno2.SelectedValue.ToString());
        ticket.TextoIzquierda("Cajero: " + ddlUsuario2.SelectedItem.Text);
        //ticket.TextoIzquierda("ATENDIÓ: " + Session["Usuario"]);
        //ticket.TextoIzquierda("CLIENTE: PUBLICO EN GENERAL");
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
        //ticket.lineasAsteriscos();

        //Articulos a vender.
        //ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        //ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        //for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //{
        //    decMontoTotal = decMontoTotal + Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString());
        //    ticket.AgregaArticulo(dt.Rows[i]["vchDeItem"].ToString(),
        //                          Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()),
        //                          Convert.ToDecimal(dt.Rows[i]["numPrecioUni"].ToString()),
        //                          Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString()));
        //}
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        ticket.lineasAsteriscos();

        //Resumen de la venta. Sólo son ejemplos
        for (int i = 0; i <= dtResponse.Rows.Count - 1; i++)
        {
            ticket.AgregarTotales("      " + dtResponse.Rows[i]["vchTipo"] + "....S/.", Convert.ToDecimal(dtResponse.Rows[i]["Monto"].ToString()));
        }
        //ticket.AgregarTotales("      SUBTOTAL....S/.", 100);
        //ticket.AgregarTotales("      IGV.........S/.", 10.04M);//La M indica que es un decimal en C#
        //ticket.AgregarTotales("      TOTAL.......S/.", decMontoTotal);
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.AgregarTotales("      TOTAL.......S/.", Convert.ToDecimal(ldblMontoFinal));
        //ticket.AgregarTotales("         EFECTIVO....S/.", 200);
        //ticket.AgregarTotales("         CAMBIO......S/.", 0.0M);
        ticket.lineasAsteriscos();

        //Texto final del Ticket.
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        //ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("CajaPri");//Nombre de la impresora ticketera

        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                "$('#mymodal2').modal('hide');" +
                "toastr.success('Se realizo el cierre de caja correctamente','Bien');", true);
    }
    void imprimirArqueo()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;
        Double ldblMontoFinal = 0.0;

        dtResponse = lobjProducto.obtenerValoresArqueoPrevioCaja(Convert.ToInt32(Session["MovCajaID"].ToString()));

        for (int i = 0; i <= dtResponse.Rows.Count - 1; i++)
        {
            ldblMontoFinal = ldblMontoFinal + Convert.ToDouble(dtResponse.Rows[i]["Monto"].ToString());
        }
        //Creamos una instancia d ela clase CrearTicket
        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("*****ARQUEO DE CAJA*****");
        ticket.TextoCentro("" + DateTime.Now.ToString());
        //ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
        //ticket.TextoIzquierda("DIREC: DIRECCION DE LA EMPRESA");
        //ticket.TextoIzquierda("TELEF: 4530000");
        //ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
        //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("Caja # 1", "Ticket # 002-0000006");
        ticket.lineasAsteriscos();

        //Sub cabecera.
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("Caja: " + ddlCaja.SelectedItem.Text);
        ticket.TextoIzquierda("Fecha: " + lblFechaAper.Value);
        ticket.TextoIzquierda("Turno: " + ddlTurno.SelectedValue.ToString());
        ticket.TextoIzquierda("Cajero: " + ddlUsuario.SelectedItem.Text);
        //ticket.TextoIzquierda("ATENDIÓ: " + Session["Usuario"]);
        //ticket.TextoIzquierda("CLIENTE: PUBLICO EN GENERAL");
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
        //ticket.lineasAsteriscos();

        //Articulos a vender.
        //ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        //ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        //for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //{
        //    decMontoTotal = decMontoTotal + Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString());
        //    ticket.AgregaArticulo(dt.Rows[i]["vchDeItem"].ToString(),
        //                          Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()),
        //                          Convert.ToDecimal(dt.Rows[i]["numPrecioUni"].ToString()),
        //                          Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString()));
        //}
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        ticket.lineasAsteriscos();

        //Resumen de la venta. Sólo son ejemplos
        for (int i = 0; i <= dtResponse.Rows.Count - 1; i++)
        {
            ticket.AgregarTotales("      " + dtResponse.Rows[i]["vchTipo"] + "....S/.", Convert.ToDecimal(dtResponse.Rows[i]["Monto"].ToString()));
        }
        //ticket.AgregarTotales("      SUBTOTAL....S/.", 100);
        //ticket.AgregarTotales("      IGV.........S/.", 10.04M);//La M indica que es un decimal en C#
        //ticket.AgregarTotales("      TOTAL.......S/.", decMontoTotal);
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.AgregarTotales("      TOTAL.......S/.", Convert.ToDecimal(ldblMontoFinal));
        //ticket.AgregarTotales("         EFECTIVO....S/.", 200);
        //ticket.AgregarTotales("         CAMBIO......S/.", 0.0M);
        ticket.lineasAsteriscos();

        //Texto final del Ticket.
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        //ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("CajaPri");//Nombre de la impresora ticketera
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                "$('#mymodal2').modal('hide');" +
                "toastr.success('Se realizo el arqueo de caja correctamente','Bien');", true);
    }
    protected void btnArqueo_Click(object sender, EventArgs e)
    {
        imprimirArqueo();
    }

    protected void BtnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmListadoCajasAperturadas");
    }
}