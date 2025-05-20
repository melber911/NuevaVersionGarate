using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bussinessLayer;
using System.Drawing.Printing;
using System.Drawing;
using CrearTicketVenta;

public partial class frmPedidoDetalleAnular : System.Web.UI.Page
{
    void calcularMontoTotal()
    {
        DataTable dt;
        double montoAcum = 0.0;
        dt = Session["dtPedido"] as DataTable;

        if (dt.Rows.Count == 0)
        {
            lblValor.InnerText = "0.00";
            //imgCocina.Visible = false;
            //btnEnviarCocina.Visible = false;
            return;
        }

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            if (!dt.Rows[i]["intCantidad"].ToString().Equals("0"))
            {
                montoAcum = montoAcum + Convert.ToDouble(dt.Rows[i]["numPrecioTot"].ToString());   
            }
        }

        if (montoAcum != 0)
        {
            lblValor.InnerText = montoAcum.ToString("n2");
            //imgCocina.Visible = true;
            //btnEnviarCocina.Visible = true;
        }
        else {
            btnAnular.Visible = true;
            btnGuardarO.Visible = false;
            lblValor.InnerText = "0.00";
        }
    }
    void armarTablaPedidos()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("vchNumSecu");
        dt.Columns.Add("intCantidad");
        dt.Columns.Add("vchCodigo");
        dt.Columns.Add("vchDeItem");
        dt.Columns.Add("numPrecioUni");
        dt.Columns.Add("numPrecioTot");
        dt.Columns.Add("vchComentario");
        dt.Columns.Add("vchImpresion");

        Session["dtPedidoNuevo"] = dt;
    }

    void armarTablaPedidosCocina()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("vchNumSecu");
        dt.Columns.Add("intCantidad");
        dt.Columns.Add("vchCodigo");
        dt.Columns.Add("vchDeItem");
        dt.Columns.Add("numPrecioUni");
        dt.Columns.Add("numPrecioTot");
        dt.Columns.Add("vchComentario");
        dt.Columns.Add("vchImpresion");

        Session["dtPedidoCocina"] = dt;
    }

    void armarTablaPedidosPizza()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("vchNumSecu");
        dt.Columns.Add("intCantidad");
        dt.Columns.Add("vchCodigo");
        dt.Columns.Add("vchDeItem");
        dt.Columns.Add("numPrecioUni");
        dt.Columns.Add("numPrecioTot");
        dt.Columns.Add("vchComentario");
        dt.Columns.Add("vchImpresion");

        Session["dtPedidoPizza"] = dt;
    }

    void armarTablaPedidos(Int32 pintordenID)
    {
        clsProducto lobjProducto = new clsProducto();
        //DataTable dt = new DataTable();
        
        DataTable dt = lobjProducto.obtenerDetalleOrden(pintordenID);
        DataTable dtold = dt.Copy();
        //dt.Columns.Add("vchNumSecu");
        //dt.Columns.Add("intCantidad");
        //dt.Columns.Add("vchCodigo");
        //dt.Columns.Add("vchDeItem");
        //dt.Columns.Add("numPrecioUni");
        //dt.Columns.Add("numPrecioTot");
        //dt.Columns.Add("vchComentario");

        Session["dtPedido"] = dt;
        Session["dtPedidoOld"] = dtold;
        gdPedido.DataSource = dt;
        gdPedido.DataBind();
        calcularMontoTotal();
    }


    void cargarPedidos(String pstrCodigo,
                       String pstrDeItem,
                       String pnumPrecioUni)
    {
        DataTable dt;
        DataTable dtNuevo;
        DataRow row;
        Int32 intCantidadItems = 0;
        Int32 intCantidadItemsNuevo = 0;
        Double dblMonto = 0.0;
        Double dblMontoNuevo = 0.0;
        Boolean bolInsertado = false;
        Boolean bolInsertadoNuevo = false;


        dt = Session["dtPedido"] as DataTable;
        dtNuevo = Session["dtPedidoNuevo"] as DataTable;

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            if (dt.Rows[i]["vchCodigo"].Equals(pstrCodigo))
            {
                intCantidadItems = Convert.ToInt32(dt.Rows[i]["intCantidad"]);
                intCantidadItems = intCantidadItems + 1;
                dblMonto = intCantidadItems * Convert.ToDouble(dt.Rows[i]["numPrecioUni"]);
                dt.Rows[i]["intCantidad"] = intCantidadItems.ToString();
                dt.Rows[i]["numPrecioTot"] = dblMonto.ToString("n2");

                Session["dtPedido"] = dt;

                calcularMontoTotal();

                gdPedido.DataSource = dt;
                gdPedido.DataBind();

                bolInsertado = true;
            }
        }

        if (bolInsertado == false)
        {
            row = dt.NewRow();
            row["vchNumSecu"] = "";
            row["intCantidad"] = 1;
            row["vchCodigo"] = pstrCodigo;
            row["vchDeItem"] = pstrDeItem;
            row["numPrecioUni"] = pnumPrecioUni;
            row["numPrecioTot"] = pnumPrecioUni;
            row["vchComentario"] = "";
            row["vchImpresion"] = "N";
            dt.Rows.Add(row);

            Session["dtPedido"] = dt;

            calcularMontoTotal();

            gdPedido.DataSource = dt;
            gdPedido.DataBind();
        }

        for (int i = 0; i <= dtNuevo.Rows.Count - 1; i++)
        {
            if (dtNuevo.Rows[i]["vchCodigo"].Equals(pstrCodigo))
            {
                intCantidadItemsNuevo = Convert.ToInt32(dtNuevo.Rows[i]["intCantidad"]);
                intCantidadItemsNuevo = intCantidadItemsNuevo + 1;
                dblMontoNuevo = intCantidadItemsNuevo * Convert.ToDouble(dtNuevo.Rows[i]["numPrecioUni"]);
                dtNuevo.Rows[i]["intCantidad"] = intCantidadItemsNuevo.ToString();
                dtNuevo.Rows[i]["numPrecioTot"] = dblMontoNuevo.ToString("n2");

                Session["dtPedidoNuevo"] = dtNuevo;

                bolInsertadoNuevo = true;
                return;
            }
        }

        if (bolInsertadoNuevo == false)
        {
            row = dtNuevo.NewRow();
            row["vchNumSecu"] = "";
            row["intCantidad"] = 1;
            row["vchCodigo"] = pstrCodigo;
            row["vchDeItem"] = pstrDeItem;
            row["numPrecioUni"] = pnumPrecioUni;
            row["numPrecioTot"] = pnumPrecioUni;
            row["vchComentario"] = "";
            row["vchImpresion"] = "N";
            dtNuevo.Rows.Add(row);

            Session["dtPedidoNuevo"] = dtNuevo;
        }
    }

    void restarItem(String pstrCodigo,
                    String pstrDeItem,
                    String pnumPrecioUni)
    {
        DataTable dt;
        DataTable dtNuevo;
        Int32 intCantidadItems = 0;
        Double dblMonto = 0.0;
        Int32 intCantidadItemsNuevo = 0;
        Double dblMontoNuevo = 0.0;


        dt = Session["dtPedido"] as DataTable;

        //dtNuevo = Session["dtPedidoNuevo"] as DataTable;

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            if (dt.Rows[i]["vchCodigo"].Equals(pstrCodigo))
            {
                intCantidadItems = Convert.ToInt32(dt.Rows[i]["intCantidad"]);

                if (intCantidadItems == 1 || intCantidadItems == 0)
                {
                    dt.Rows[i]["intCantidad"] = "0";
                    Session["dtPedido"] = dt;

                    calcularMontoTotal();

                    gdPedido.DataSource = dt;
                    gdPedido.DataBind();
                    break;

                }

                intCantidadItems = intCantidadItems - 1;
                dblMonto = intCantidadItems * Convert.ToDouble(dt.Rows[i]["numPrecioUni"]);
                dt.Rows[i]["intCantidad"] = intCantidadItems.ToString();
                dt.Rows[i]["numPrecioTot"] = dblMonto.ToString("n2");

                Session["dtPedido"] = dt;

                calcularMontoTotal();

                gdPedido.DataSource = dt;
                gdPedido.DataBind();
                break;
            }
        }

        //for (int i = 0; i <= dtNuevo.Rows.Count - 1; i++)
        //{
        //    if (dtNuevo.Rows[i]["vchCodigo"].Equals(pstrCodigo))
        //    {
        //        intCantidadItemsNuevo = Convert.ToInt32(dtNuevo.Rows[i]["intCantidad"]);

        //        if (intCantidadItemsNuevo == 1)
        //        {
        //            dtNuevo.Rows[i].Delete();
        //            Session["dtPedidoNuevo"] = dtNuevo;
        //            break;
        //        }

        //        intCantidadItemsNuevo = intCantidadItemsNuevo - 1;
        //        dblMontoNuevo = intCantidadItemsNuevo * Convert.ToDouble(dtNuevo.Rows[i]["numPrecioUni"]);
        //        dtNuevo.Rows[i]["intCantidad"] = intCantidadItemsNuevo.ToString();
        //        dtNuevo.Rows[i]["numPrecioTot"] = dblMontoNuevo.ToString("n2");

        //        Session["dtPedidoNuevo"] = dtNuevo;
        //        break;
        //    }
        //}
    }


    //void cargarCarta(String pstrValor)
    //{
    //    clsProducto lobjProducto = new clsProducto();
    //    string[] valores = pstrValor.Split('-');

    //    gdCartaProductos.DataSource = lobjProducto.obtenerProductos(valores[0], valores[1]);
    //    gdCartaProductos.DataBind();
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
        {
            WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
            return;
        }
        if (!IsPostBack)
        {
            Session["dtPedidoOld"] = null;
            Session["dtPedido"] = null;
            Session["dtPedidoNuevo"] = null;
            Session["dtPedidoCocina"] = null;
            Session["dtPedidoPizza"] = null;
            
            //armarTablaPedidos();
            armarTablaPedidos();
            armarTablaPedidos(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
            armarTablaPedidosCocina();
            armarTablaPedidosPizza();
            //if (Request.QueryString["vchEstado"].ToString().Equals("PRE-CUENTA")) {
            //    imgCocina.Visible = false;
            //    btnEnviarCocina.Visible = false;
            //}
            //if (Request.QueryString["vchEstado"].ToString().Equals("PAGADO"))
            //{
            //    imgCocina.Visible = false;
            //    btnEnviarCocina.Visible = false;
            //    imgPreCuenta.Visible = false;
            //    btnPreCuenta.Visible = false;
            //}
            //if (Request.QueryString["vchEstado"].ToString().Equals("ANULADO"))
            //{
            //    imgCocina.Visible = false;
            //    btnEnviarCocina.Visible = false;
            //    imgPreCuenta.Visible = false;
            //    btnPreCuenta.Visible = false;
            //}
        }
    }


    protected void gdPedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Mas")
        {
            string[] valores = e.CommandArgument.ToString().Split('-');
            Int32 index = Convert.ToInt32(valores[0]);
            cargarPedidos(valores[1],
                          gdPedido.Rows[index].Cells[2].Text,
                          gdPedido.Rows[index].Cells[3].Text);
        }

        if (e.CommandName == "Menos")
        {
            string[] valores = e.CommandArgument.ToString().Split('-');
            Int32 index = Convert.ToInt32(valores[0]);
            restarItem(valores[1],
                       gdPedido.Rows[index].Cells[2].Text,
                       gdPedido.Rows[index].Cells[3].Text);
        }
        if (e.CommandName == "Comentario")
        {
            string[] valores = e.CommandArgument.ToString().Split('-');
            //Int32 index = Convert.ToInt32(valores[0]);
            //Session["valorIndice"] = valores[0];
            Session["vchCodigo"] = valores[1];
            //txtObservacion.Text = "";
            //txtObservacion.Text = dt.Rows[index]["vchComentario"].ToString();
            //obtenerComentario(Convert.ToInt32(valores[0]), valores[1]);
        }
    }
    //protected void gdCartaProductos_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Agregar")
    //    {
    //        string[] valores = e.CommandArgument.ToString().Split('-');
    //        Int32 index = Convert.ToInt32(valores[0]);
    //        cargarPedidos(valores[1],
    //                      gdCartaProductos.Rows[index].Cells[1].Text,
    //                      gdCartaProductos.Rows[index].Cells[2].Text);
    //    }
    //}
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        //string indice = Session["valorIndice"].ToString();
        string codigo = Session["vchCodigo"].ToString();
        //cargarComentario(codigo);
    }

    protected void btnEnviarCocina_Click(object sender, EventArgs e)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponseDet;
        DataSet dsResponseTemp;
        DataTable dtEliminaTmp;
        DataTable dt;
        DataTable dtNuevo;
        DataTable dtCocina = null;
        DataTable dtPizzas = null;
        //Int32 intContador=0;

        dt = Session["dtPedido"] as DataTable;
        dtNuevo = Session["dtPedidoNuevo"] as DataTable;

        if (dtNuevo.Rows.Count == 0)
        {
            Response.Write("<script>alert('No hay pendientes por enviar.');</script>");
            return;
        }

        for (int i = 0; i <= dtNuevo.Rows.Count - 1; i++)
        {
            dtResponseDet = lobjProducto.actualizarItemsOrden(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()),
                                                              Convert.ToInt32(dtNuevo.Rows[i]["vchCodigo"].ToString()),
                                                              Convert.ToInt32(dtNuevo.Rows[i]["intCantidad"].ToString()),
                                                              dtNuevo.Rows[i]["vchComentario"].ToString(),
                                                              Session["Usuario"].ToString());
            dsResponseTemp = lobjProducto.cargarTmpPedidosAdic(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()),
                                                               Convert.ToInt32(dtNuevo.Rows[i]["intCantidad"].ToString()),
                                                               Convert.ToInt32(dtNuevo.Rows[i]["vchCodigo"].ToString()),
                                                               dtNuevo.Rows[i]["vchDeItem"].ToString(),
                                                               Convert.ToDouble(dtNuevo.Rows[i]["numPrecioUni"].ToString()),
                                                               dtNuevo.Rows[i]["vchComentario"].ToString(),
                                                              Session["Usuario"].ToString(), (int)Session["Idsucursal"]);
            dtCocina = dsResponseTemp.Tables[0];
            dtPizzas = dsResponseTemp.Tables[1];
        }

        dtEliminaTmp = lobjProducto.eliminaTmpPedidosAdic(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()),
                                                          Session["Usuario"].ToString());

        if (dtCocina.Rows.Count > 0)
        {
            Session["dtPedidoCocina"] = dtCocina;
            printReceipt();
        }

        if (dtPizzas.Rows.Count > 0)
        {
            Session["dtPedidoPizza"] = dtPizzas;
            printReceipt_2();
        }

        Response.Redirect("frmPedidoDetalle?vchOrdenID=" + Request.QueryString["vchOrdenID"].ToString() +
                                                 "&vchSalon=" + Request.QueryString["vchSalon"] +
                                                 "&vchNumMesa=" + Request.QueryString["vchNumMesa"] +
                                                 "&vchEstado=" + Request.QueryString["vchEstado"]);
    }

    void printReceipt()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        pd.Print();
    }

    void printDoc_PrintPage(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoCocina"] as DataTable;

        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("Gaucho Parrillero");
        //ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
        //ticket.TextoIzquierda("DIREC: DIRECCION DE LA EMPRESA");
        //ticket.TextoIzquierda("TELEF: 4530000");
        //ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
        //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("Caja # 1", "Ticket # 002-0000006");
        ticket.lineasIgual();

        //Sub cabecera.
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("#Pedido: " + Request.QueryString["vchOrdenID"].ToString());
        ticket.TextoIzquierda("Fecha: " + DateTime.Now);
        ticket.TextoIzquierda("Salon: " + Request.QueryString["vchSalon"].ToString());
        ticket.TextoIzquierda("Mesa: " + Request.QueryString["vchNumMesa"].ToString());
        ticket.TextoIzquierda("Mesero: " + Session["Usuario"].ToString());
        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            ticket.TextoIzquierda("Obs.: Para Llevar");
        }
        else
        {
            ticket.TextoIzquierda("Obs.: Comer Aqui");
        }
        ticket.lineasIgual();

        //Articulos a vender.
        //ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        //ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            ticket.TextoIzquierda(dt.Rows[i]["intCantidad"].ToString() + "   " + dt.Rows[i]["vchDeItem"].ToString());
            if (!dt.Rows[i]["vchComentario"].ToString().Equals(""))
            {
                ticket.TextoIzquierda(" ");
                ticket.TextoIzquierda("Obs.: " + dt.Rows[i]["vchComentario"].ToString());
                ticket.TextoIzquierda(" ");
            }
        }
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        //ticket.lineasIgual();

        //Resumen de la venta. Sólo son ejemplos
        //ticket.AgregarTotales("         SUBTOTAL....S/.", 100);
        //ticket.AgregarTotales("         IGV.........S/.", 10.04M);//La M indica que es un decimal en C#
        //ticket.AgregarTotales("        TOTAL.......S/.", decMontoTotal);
        //ticket.TextoIzquierda("");
        //ticket.AgregarTotales("         EFECTIVO....S/.", 200);
        //ticket.AgregarTotales("         CAMBIO......S/.", 0.0M);

        //Texto final del Ticket.
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        //ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("COMACOC");//Nombre de la impresora ticketera
        //Session["OrdenIDTemp"] = null;
    }

    void printReceipt_2()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_2);
        pd.Print();
    }

    void printDoc_PrintPage_2(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoPizza"] as DataTable;

        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("Gaucho Parrillero");
        //ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
        //ticket.TextoIzquierda("DIREC: DIRECCION DE LA EMPRESA");
        //ticket.TextoIzquierda("TELEF: 4530000");
        //ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
        //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("Caja # 1", "Ticket # 002-0000006");
        ticket.lineasIgual();

        //Sub cabecera.
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("#Pedido: " + Request.QueryString["vchOrdenID"].ToString());
        ticket.TextoIzquierda("Fecha: " + DateTime.Now);
        ticket.TextoIzquierda("Salon: " + Request.QueryString["vchSalon"].ToString());
        ticket.TextoIzquierda("Mesa: " + Request.QueryString["vchNumMesa"].ToString());
        ticket.TextoIzquierda("Mesero: " + Session["Usuario"].ToString());
        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            ticket.TextoIzquierda("Obs.: Para Llevar");
        }
        else
        {
            ticket.TextoIzquierda("Obs.: Comer Aqui");
        }
        ticket.lineasIgual();

        //Articulos a vender.
        //ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        //ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            ticket.TextoIzquierda(dt.Rows[i]["intCantidad"].ToString() + "   " + dt.Rows[i]["vchDeItem"].ToString());
            if (!dt.Rows[i]["vchComentario"].ToString().Equals(""))
            {
                ticket.TextoIzquierda(" ");
                ticket.TextoIzquierda("Obs.: " + dt.Rows[i]["vchComentario"].ToString());
                ticket.TextoIzquierda(" ");
            }
        }
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        //ticket.lineasIgual();

        //Resumen de la venta. Sólo son ejemplos
        //ticket.AgregarTotales("         SUBTOTAL....S/.", 100);
        //ticket.AgregarTotales("         IGV.........S/.", 10.04M);//La M indica que es un decimal en C#
        //ticket.AgregarTotales("        TOTAL.......S/.", decMontoTotal);
        //ticket.TextoIzquierda("");
        //ticket.AgregarTotales("         EFECTIVO....S/.", 200);
        //ticket.AgregarTotales("         CAMBIO......S/.", 0.0M);

        //Texto final del Ticket.
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        //ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("COMAPAR");//Nombre de la impresora ticketera
        //Session["OrdenIDTemp"] = null;
    }
    //protected void gdPedido_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        ImageButton libtMas = (ImageButton)e.Row.FindControl("ibtMas");
    //        ImageButton libtMenos = (ImageButton)e.Row.FindControl("ibtMenos");
    //        ImageButton libtComentario = (ImageButton)e.Row.FindControl("ibtComentario");
    //        CheckBox lchkEnviado = (CheckBox)e.Row.FindControl("chkEnviado");

    //        DataRow drv = ((DataRowView)e.Row.DataItem).Row;

    //        if (drv["vchImpresion"].ToString().Equals("S"))
    //        {
    //            //libtMas.Visible = false;
    //            libtMas.Enabled = false;
    //            //libtMenos.Visible = false;
    //            libtMenos.Enabled = false;
    //            //libtComentario.Visible = false;
    //            libtComentario.Enabled = false;
    //            lchkEnviado.Checked = true;
    //        }

    //        lchkEnviado.Enabled = false;

    //    }
    //}
    
    protected void btnPreCuenta_Click(object sender, EventArgs e)
    {
        //generaraPreCuenta(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
        imprimirPreCuenta();
        Response.Redirect("frmListadoPedidos");
    }

    void generaraPreCuenta(Int32 pintOrdenID) {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;

        dtResponse = lobjProducto.generarPreCuenta(pintOrdenID,
                                                   Session["Usuario"].ToString());

    }
    void imprimirPreCuenta() {
        DataTable dt;
        dt = Session["dtPedido"] as DataTable;
        decimal decMontoTotal = 0;
        //Creamos una instancia d ela clase CrearTicket
        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("*****PRE-CUENTA*****");
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
        ticket.TextoIzquierda("# ORDEN: " + Request.QueryString["vchOrdenID"].ToString());
        ticket.TextoIzquierda("# SALON: " + Request.QueryString["vchSalon"].ToString());
        ticket.TextoIzquierda("# MESA: " + Request.QueryString["vchNumMesa"].ToString());
        ticket.TextoIzquierda("ATENDIO: " + Session["Usuario"]);
        ticket.TextoIzquierda("CLIENTE: PUBLICO EN GENERAL");
        ticket.TextoIzquierda("");
        ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
        ticket.lineasAsteriscos();

        //Articulos a vender.
        ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            decMontoTotal = decMontoTotal + Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString());
            ticket.AgregaArticulo(dt.Rows[i]["vchDeItem"].ToString(), 
                                  Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()),
                                  Convert.ToDecimal(dt.Rows[i]["numPrecioUni"].ToString()),
                                  Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString()));
        }
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        ticket.lineasIgual();

        //Resumen de la venta. Sólo son ejemplos
        //ticket.AgregarTotales("         SUBTOTAL....S/.", 100);
        //ticket.AgregarTotales("         IGV.........S/.", 10.04M);//La M indica que es un decimal en C#
        ticket.AgregarTotales("        TOTAL.......S/.", decMontoTotal);
        //ticket.TextoIzquierda("");
        //ticket.AgregarTotales("         EFECTIVO....S/.", 200);
        //ticket.AgregarTotales("         CAMBIO......S/.", 0.0M);

        //Texto final del Ticket.
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        //ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("CajaPri");//Nombre de la impresora ticketera
    }
    protected void gdCartaProductos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton libtAgregar = (ImageButton)e.Row.FindControl("ibtAgregar");
            if (Request.QueryString["vchEstado"].ToString().Equals("PRE-CUENTA") ) { 
                libtAgregar.Visible = false;
            }
            if (Request.QueryString["vchEstado"].ToString().Equals("PAGADO") ) { 
                libtAgregar.Visible = false;
            }
            if (Request.QueryString["vchEstado"].ToString().Equals("ANULADO") ) { 
                libtAgregar.Visible = false;
            }
        }
    }
    protected void imgReImprimirComanda_Click(object sender, ImageClickEventArgs e)
    {
        clsProducto lobjProducto = new clsProducto();
        DataSet dsResponse;
        DataTable dtCocina = new DataTable();
        DataTable dtPizza = new DataTable();
        dsResponse = lobjProducto.obtenerReImpresionComanda(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
        dtCocina = dsResponse.Tables[0];
        dtPizza = dsResponse.Tables[1];

        if (dtCocina.Rows.Count > 0) {
            Session["dtPedidoCocina"] = dtCocina;
            printReceipt_3();
        }

        if (dtPizza.Rows.Count > 0)
        {
            Session["dtPedidoPizza"] = dtPizza;
            printReceipt_4();
        }

        Response.Redirect("frmPedidoDetalle?vchOrdenID=" + Request.QueryString["vchOrdenID"].ToString() +
                                                 "&vchSalon=" + Request.QueryString["vchSalon"] +
                                                 "&vchNumMesa=" + Request.QueryString["vchNumMesa"] +
                                                 "&vchEstado=" + Request.QueryString["vchEstado"]);
    }

    void printReceipt_3()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_3);
        pd.Print();
    }

    void printDoc_PrintPage_3(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoCocina"] as DataTable;

        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("********REIMPRESION********");
        //ticket.TextoCentro("Gaucho Parrillero");
        //ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
        //ticket.TextoIzquierda("DIREC: DIRECCION DE LA EMPRESA");
        //ticket.TextoIzquierda("TELEF: 4530000");
        //ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
        //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("Caja # 1", "Ticket # 002-0000006");
        ticket.lineasIgual();

        //Sub cabecera.
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("#Pedido: " + Request.QueryString["vchOrdenID"].ToString());
        ticket.TextoIzquierda("Fecha: " + DateTime.Now);
        ticket.TextoIzquierda("Salon: " + Request.QueryString["vchSalon"].ToString());
        ticket.TextoIzquierda("Mesa: " + Request.QueryString["vchNumMesa"].ToString());
        ticket.TextoIzquierda("Mesero: " + Session["Usuario"].ToString());
        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            ticket.TextoIzquierda("Obs.: Para Llevar");
        }
        else
        {
            ticket.TextoIzquierda("Obs.: Comer Aqui");
        }
        ticket.lineasIgual();

        //Articulos a vender.
        //ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        //ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            ticket.TextoIzquierda(dt.Rows[i]["intCantidad"].ToString() + "   " + dt.Rows[i]["vchDeItem"].ToString());
            if (!dt.Rows[i]["vchComentario"].ToString().Equals(""))
            {
                ticket.TextoIzquierda(" ");
                ticket.TextoIzquierda("Obs.: " + dt.Rows[i]["vchComentario"].ToString());
                ticket.TextoIzquierda(" ");
            }
        }
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        //ticket.lineasIgual();

        //Resumen de la venta. Sólo son ejemplos
        //ticket.AgregarTotales("         SUBTOTAL....S/.", 100);
        //ticket.AgregarTotales("         IGV.........S/.", 10.04M);//La M indica que es un decimal en C#
        //ticket.AgregarTotales("        TOTAL.......S/.", decMontoTotal);
        //ticket.TextoIzquierda("");
        //ticket.AgregarTotales("         EFECTIVO....S/.", 200);
        //ticket.AgregarTotales("         CAMBIO......S/.", 0.0M);

        //Texto final del Ticket.
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        //ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("COMACOC");//Nombre de la impresora ticketera
        //Session["OrdenIDTemp"] = null;
    }

    void printReceipt_4()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_4);
        pd.Print();
    }

    void printDoc_PrintPage_4(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoPizza"] as DataTable;

        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("********REIMPRESION********");
        //ticket.TextoCentro("Gaucho Parrillero");
        //ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
        //ticket.TextoIzquierda("DIREC: DIRECCION DE LA EMPRESA");
        //ticket.TextoIzquierda("TELEF: 4530000");
        //ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
        //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("Caja # 1", "Ticket # 002-0000006");
        ticket.lineasIgual();

        //Sub cabecera.
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("#Pedido: " + Request.QueryString["vchOrdenID"].ToString());
        ticket.TextoIzquierda("Fecha: " + DateTime.Now);
        ticket.TextoIzquierda("Salon: " + Request.QueryString["vchSalon"].ToString());
        ticket.TextoIzquierda("Mesa: " + Request.QueryString["vchNumMesa"].ToString());
        ticket.TextoIzquierda("Mesero: " + Session["Usuario"].ToString());
        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            ticket.TextoIzquierda("Obs.: Para Llevar");
        }
        else
        {
            ticket.TextoIzquierda("Obs.: Comer Aqui");
        }
        ticket.lineasIgual();

        //Articulos a vender.
        //ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        //ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            ticket.TextoIzquierda(dt.Rows[i]["intCantidad"].ToString() + "   " + dt.Rows[i]["vchDeItem"].ToString());
            if (!dt.Rows[i]["vchComentario"].ToString().Equals(""))
            {
                ticket.TextoIzquierda(" ");
                ticket.TextoIzquierda("Obs.: " + dt.Rows[i]["vchComentario"].ToString());
                ticket.TextoIzquierda(" ");
            }
        }
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        //ticket.lineasIgual();

        //Resumen de la venta. Sólo son ejemplos
        //ticket.AgregarTotales("         SUBTOTAL....S/.", 100);
        //ticket.AgregarTotales("         IGV.........S/.", 10.04M);//La M indica que es un decimal en C#
        //ticket.AgregarTotales("        TOTAL.......S/.", decMontoTotal);
        //ticket.TextoIzquierda("");
        //ticket.AgregarTotales("         EFECTIVO....S/.", 200);
        //ticket.AgregarTotales("         CAMBIO......S/.", 0.0M);

        //Texto final del Ticket.
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        ticket.TextoIzquierda(" ");
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        //ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("COMAPAR");//Nombre de la impresora ticketera
        //Session["OrdenIDTemp"] = null;
    }

    //void obtenerProductosxBusqueda()
    //{
    //    clsProducto lobjProducto = new clsProducto();

    //    gdCartaProductos.DataSource = lobjProducto.obtenerProductosBusqueda(txtBusqueda.Text.Trim().ToUpper());
    //    gdCartaProductos.DataBind();
    //}

    //protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
    //{
    //    obtenerProductosxBusqueda();
    //}
    protected void imgVolver_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frmListadoMesasAnular");
    }

    protected void btnAnular_Click(object sender, EventArgs e)
    {
        anularOden();
    }

    void anularOden(){
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;
        DataTable ldtResponseInfStock;
        DataTable ldtResponseRegresarStock;

        if (txtMotivo.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Completar campo motivo.','Motivo');", true);
            return;
        }

        if (txtMotivo.Value.Trim().Length > 200)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('No debe superar los 200 caracteres.','Motivo');", true);
            return;
        }

        ldtResponse = lobjProducto.anularOrdenPedido(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()),
                                                     txtMotivo.Value.Trim().ToUpper(),
                                                     Session["Usuario"].ToString());

        ldtResponseInfStock = lobjProducto.obtenerInformacionStock(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
        string DataStock = ldtResponseInfStock.Rows[0]["informacionStock"].ToString().TrimEnd('|');

        if (!string.IsNullOrEmpty(DataStock))
        {
            var Data = DataStock.Split('|');
            if (Data.Count() > 0)
            {
                for (int i = 0; i < Data.Count(); i++)
                {
                    var Dt = Data[i].Split(',');
                    var IdStockProducto = Dt[0].ToString();
                    var Cantidad = Dt[1].ToString();
                    ldtResponseRegresarStock = lobjProducto.RegresoStockXAnularPedido(Convert.ToInt32(IdStockProducto), Convert.ToInt32(Cantidad));

                }
            }
        }

        Response.Redirect("frmListadoMesasAnular");

    }

    void anularItemxOrden() {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;
        DataTable dt;
        DataTable ldtResponseInfStock;
        DataTable dtOld = Session["dtPedidoOld"] as DataTable;
        dt = Session["dtPedido"] as DataTable;

        if (txtMotivo.Value.Trim().Equals("")) {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Completar campo motivo.','Motivo');", true);
            return;
        }

        if (txtMotivo.Value.Trim().Length > 200)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('No debe superar los 200 caracteres.','Motivo');", true);
            return;
        }

        ldtResponseInfStock = lobjProducto.obtenerInformacionStock(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
        string DataStock = ldtResponseInfStock.Rows[0]["informacionStock"].ToString().TrimEnd('|');
        string RestStock = "";
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            if (!dtOld.Rows[i]["intCantidad"].Equals(dt.Rows[i]["intCantidad"]))
            {
                ldtResponse = lobjProducto.actualizarItemOrden(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()),
                                                               Convert.ToInt32(dt.Rows[i]["vchCodigo"].ToString()),
                                                               Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()),
                                                               txtMotivo.Value.Trim().ToUpper(),
                                                               Session["Usuario"].ToString());
                int cantidad = int.Parse(dtOld.Rows[i]["intCantidad"].ToString()) - int.Parse(dt.Rows[i]["intCantidad"].ToString());
                anularItemxOrdenStockProducto(DataStock, Convert.ToInt32(dt.Rows[i]["vchCodigo"].ToString()), cantidad,ref RestStock);
            }
        }
        #region [Consolidar inf. stock en tabla Pedido Cabecera]
        string DataVenta = RestStock.TrimEnd('|');
        var ListDataStock = DataStock.Split('|');
        var ListDataVenta = DataVenta.Split('|');
        foreach (var itemS in ListDataStock)
        {
            var ListDataStock2 = itemS.Split(',');
            foreach (var itemV in ListDataVenta)
            {
                var ListDataVenta2 = itemV.Split(',');
                if (ListDataStock2[0].Equals(ListDataVenta2[0]))
                {
                    int resta = Convert.ToInt32(ListDataStock2[1]) - Convert.ToInt32(ListDataVenta2[1]);
                    DataStock = DataStock.Replace(itemS, ListDataStock2[0] + "," + resta);
                }
            }
        }
        //filtrar
        var LisNew = DataStock.Split('|');
        string InfoStock = "";
        foreach (var item in LisNew)
        {
            var split = item.Split(',');
            if (!split[1].Equals("0"))
            {
                InfoStock = InfoStock + item + "|";
            }
        }
        lobjProducto.actualizarVenta(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()), InfoStock);
        #endregion

        Response.Redirect("frmPedidoDetalleAnular?vchOrdenID=" + Request.QueryString["vchOrdenID"].ToString());
        
    }
    protected void btnGuardarO_Click(object sender, EventArgs e)
    {
        anularItemxOrden();
    }

    void anularItemxOrdenStockProducto(string DataStock,int IdProducto,int Cantidad, ref string RestStock)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldIdProducto;
        DataTable ldActualizado;
        string DataDiscriminada = "";
        var Data = DataStock.Split('|');
        if (Data.Count() > 0)
        {
            if (Data[0] != "")
            {
                for (int i = 0; i < Data.Count(); i++)
                {
                    var Dt = Data[i].Split(',');
                    var IdStockProducto = Dt[0];
                    var CantidadStock = Dt[1];
                    ldIdProducto = lobjProducto.ObtenerIdProducto(Convert.ToInt32(IdStockProducto));
                    string IdProductoObtenido = ldIdProducto.Rows[0]["IdProducto"].ToString();
                    if (Convert.ToInt32(IdProducto) == Convert.ToInt32(IdProductoObtenido))
                    {
                        DataDiscriminada += IdStockProducto + "," + CantidadStock + "|";
                    }
                }


                if (DataDiscriminada != "")
                {
                    DataDiscriminada = DataDiscriminada.TrimEnd('|');
                    var DtDis = DataDiscriminada.Split('|');
                    int cantidadNew = Cantidad;
                    if (DtDis.Count() > 0)
                    {
                        
                        for (int i = DtDis.Count(); i > 0; i--)
                        {
                            var Dt = DtDis[i - 1].Split(',');
                            string IdStock = Dt[0];
                            string Cant = Dt[1];
                            if (Convert.ToInt32(Cant) >= Convert.ToInt32(cantidadNew))
                            {
                                ldActualizado = lobjProducto.RegresoStockXAnularPedido(Convert.ToInt32(IdStock), Convert.ToInt32(cantidadNew));
                                RestStock = RestStock + IdStock + "," + cantidadNew + "|";
                                break;
                            }
                            else
                            {
                                cantidadNew = cantidadNew - int.Parse(Cant);
                                ldActualizado = lobjProducto.RegresoStockXAnularPedido(Convert.ToInt32(IdStock), Convert.ToInt32(Cant));
                                RestStock = RestStock + IdStock + "," + Cant + "|";
                            }
                        }
                    }
                    //else
                    //{
                    //    ldActualizado = lobjProducto.RegresoStockXAnularPedido(Convert.ToInt32(DtDis[0].Split(',')[0]), Convert.ToInt32(cantidadNew));
                    //}
                }

            }


        }
    }
}