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
using Common;
using System.Text;

public partial class frmPedidoDetalle : System.Web.UI.Page
{
    HelperLog hpLog = new HelperLog();
    static DataTable DTcategoria;
    static DataTable DTSubCategoria;
    static string Strcategoria;
    static string StrSubcategoria;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
        {
            WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
            return;
        }
        if (!IsPostBack)
        {
            Session["gdCartaProductos"] = new DataTable();
            Session["dtPedido"] = null;
            Session["dtPedidoNuevo"] = null;
            Session["dtPedidoCocina"] = null;
            Session["dtPedidoPizza"] = null;

            fn_obtenerCartaMenu();
            armarTablaPedidos();
            armarTablaPedidos(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
            armarTablaPedidosCocina();
            armarTablaPedidosPizza();
            armarTablaPedidosPizzaPOS();
            gdCartaProductos.DataSource = (DataTable)Session["gdCartaProductos"];
            gdCartaProductos.DataBind();
            cargarCarta();
        }
        else
        {
            //if (Request.Form["ope"].ToString().Equals("EnviarCocina"))
            //{
            //    enviarCocina();
            //}
            if (Request.Form["ope"].ToString().Equals("PreCuenta"))
            {
                ImprimirPreCuentaHTML();
                //imprimirPreCuenta();
               // Response.Redirect("frmMesas");
            }
        }
    }
    void calcularMontoTotal()
    {
        DataTable dt;
        double montoAcum = 0.0;
        dt = Session["dtPedido"] as DataTable;

        if (dt.Rows.Count == 0)
        {
            lblValor.InnerText = "S/. 0.00";
            //imgCocina.Visible = false;
            //btnEnviarCocina.Visible = false;
            return;
        }

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            montoAcum = montoAcum + Convert.ToDouble(dt.Rows[i]["numPrecioTot"].ToString());
        }

        if (montoAcum != 0)
        {
            lblValor.InnerText = "S/. " + montoAcum.ToString("n2");
            //imgCocina.Visible = true;
            //btnEnviarCocina.Visible = true;
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

    void armarTablaPedidosPizzaPOS()
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

        Session["dtPedidoPizzaPOS"] = dt;
    }

    void armarTablaPedidos(Int32 pintordenID)
    {
        clsProducto lobjProducto = new clsProducto();
        //DataTable dt = new DataTable();

        DataTable dt = lobjProducto.obtenerDetalleOrden(pintordenID);

        //dt.Columns.Add("vchNumSecu");
        //dt.Columns.Add("intCantidad");
        //dt.Columns.Add("vchCodigo");
        //dt.Columns.Add("vchDeItem");
        //dt.Columns.Add("numPrecioUni");
        //dt.Columns.Add("numPrecioTot");
        //dt.Columns.Add("vchComentario");

        Session["dtPedido"] = dt;

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
            if (dt.Rows[i]["vchCodigo"].Equals(pstrCodigo) && dt.Rows[i]["vchImpresion"].Equals("N"))
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
            if (dtNuevo.Rows[i]["vchCodigo"].Equals(pstrCodigo) && dtNuevo.Rows[i]["vchImpresion"].Equals("N"))
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

        dtNuevo = Session["dtPedidoNuevo"] as DataTable;

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            if (dt.Rows[i]["vchCodigo"].Equals(pstrCodigo) && dt.Rows[i]["vchImpresion"].Equals("N"))
            {
                intCantidadItems = Convert.ToInt32(dt.Rows[i]["intCantidad"]);

                if (intCantidadItems == 1)
                {
                    dt.Rows[i].Delete();
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

        for (int i = 0; i <= dtNuevo.Rows.Count - 1; i++)
        {
            if (dtNuevo.Rows[i]["vchCodigo"].Equals(pstrCodigo) && dtNuevo.Rows[i]["vchImpresion"].Equals("N"))
            {
                intCantidadItemsNuevo = Convert.ToInt32(dtNuevo.Rows[i]["intCantidad"]);

                if (intCantidadItemsNuevo == 1)
                {
                    dtNuevo.Rows[i].Delete();
                    Session["dtPedidoNuevo"] = dtNuevo;
                    break;
                }

                intCantidadItemsNuevo = intCantidadItemsNuevo - 1;
                dblMontoNuevo = intCantidadItemsNuevo * Convert.ToDouble(dtNuevo.Rows[i]["numPrecioUni"]);
                dtNuevo.Rows[i]["intCantidad"] = intCantidadItemsNuevo.ToString();
                dtNuevo.Rows[i]["numPrecioTot"] = dblMontoNuevo.ToString("n2");

                Session["dtPedidoNuevo"] = dtNuevo;
                break;
            }
        }
    }

    void cargarComentario(String pstrCodigo)
    {
        DataTable dtNuevo;
        DataTable dt;
        dtNuevo = Session["dtPedidoNuevo"] as DataTable;
        dt = Session["dtPedido"] as DataTable;
        for (int i = 0; i <= dtNuevo.Rows.Count - 1; i++)
        {
            if (dtNuevo.Rows[i]["vchCodigo"].Equals(pstrCodigo) && dtNuevo.Rows[i]["vchImpresion"].Equals("N"))
            {
                dtNuevo.Rows[i]["vchComentario"] = txtObservacion.Value;
            }
        }
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            if (dt.Rows[i]["vchCodigo"].Equals(pstrCodigo) && dt.Rows[i]["vchImpresion"].Equals("N"))
            {
                dt.Rows[i]["vchComentario"] = txtObservacion.Value;
                
            }
        }
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            if (dt.Rows[i]["vchCodigo"].Equals(pstrCodigo) && dt.Rows[i]["vchImpresion"].Equals("S"))
            {
                dt.Rows[i]["vchComentario"] = txtObservacion.Value;

            }
        }
        txtObservacion.Value = "";
        Session["vchCodigo"] = null;
    }

    void obtenerComentario(Int32 pintindice,
                           String pstrCodigo)
    {
        DataTable dt;
        dt = Session["dtPedido"] as DataTable;
        for (int j = 0; j < dt.Rows.Count - 1; j++)
        {
            if (dt.Rows[j]["vchCodigo"].Equals(dt.Rows[pintindice]["vchCodigo"]) && dt.Rows[j]["vchImpresion"].Equals("S"))
            {
                txtObservacion.Value = dt.Rows[j]["vchComentario"].ToString();
                return;
            }
        }
        txtObservacion.Value = dt.Rows[pintindice]["vchComentario"].ToString();
    }

    void cargarCarta()
    {
        clsProducto lobjProducto = new clsProducto();
        Session["gdCartaProductos"] = lobjProducto.obtenerProductos((int)Session["Idsucursal"]);
    }
    
    void enviarCocina()
    {
        hpLog.generarLog("INICIO DE MODIFICACION DE PEDIDO GENERADO");
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponseDet;
        DataTable dtActualizarStock;
        DataSet dsResponseTemp;
        DataTable dtEliminaTmp;
        DataTable dt;
        DataTable dtNuevo;
        DataTable dtCocina = null;
        DataTable dtPizzas = null;
        DataTable dtPizzasPOS = null;
        DataTable dtStockProd;
        DataTable dtActualizar;
        string DataVenta = "";
        //Int32 intContador=0;

        dt = Session["dtPedido"] as DataTable;
        dtNuevo = Session["dtPedidoNuevo"] as DataTable;

        if (dtNuevo.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.info('No hay pendientes por enviar.', 'Pedidos Nuevos');",
                    true);
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
            dtPizzasPOS = dsResponseTemp.Tables[2];

            dtActualizarStock = lobjProducto.actualizarStock(Convert.ToInt32(dtNuevo.Rows[i]["intCantidad"].ToString()), Convert.ToInt32(dtNuevo.Rows[i]["vchCodigo"].ToString()));
            DataVenta = DataVenta + dtActualizarStock.Rows[0].ItemArray[0].ToString();
        }
        DataVenta = DataVenta.TrimEnd('|');
        //consolidar stock
        dtStockProd = lobjProducto.obtenerInformacionStock(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
        string DataStock = dtStockProd.Rows[0]["informacionStock"].ToString().TrimEnd('|');
        var ListDataStock = DataStock.Equals("") ? new string[] { } : DataStock.Split('|');
        var ListDataVenta = DataVenta.Equals("") ? new string[] { } : DataVenta.Split('|');
        foreach (var itemS in ListDataStock)
        {
            var ListDataStock2 = itemS.Split(',');
            foreach (var itemV in ListDataVenta)
            {
                var ListDataVenta2 = itemV.Split(',');
                if (ListDataStock2[0].Equals(ListDataVenta2[0]))
                {
                    int suma = Convert.ToInt32(ListDataStock2[1]) + Convert.ToInt32(ListDataVenta2[1]);
                    DataStock = DataStock.Replace(itemS, ListDataStock2[0] + "," + suma);
                    DataVenta = DataVenta.Replace(itemV, "");
                }
            }
        }
        var LisNew = DataVenta.Equals("") ? new string[] { } : DataVenta.Split('|');
        foreach (var item in LisNew)
        {
            if (!item.Equals(""))
            {
                DataStock = DataStock.Equals("") ? item : DataStock.TrimEnd('|') + "|" + item;
            }
        }
        dtActualizar = lobjProducto.actualizarVenta(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()), DataStock);
        dtEliminaTmp = lobjProducto.eliminaTmpPedidosAdic(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()),
                                                          Session["Usuario"].ToString());
        hpLog.generarLog("OrdenID: " + Request.QueryString["vchOrdenID"].ToString());
        if (dtCocina.Rows.Count > 0)
        {
            hpLog.generarLog("IMPRESION: dtPedidoCocina");
            Session["dtPedidoCocina"] = dtCocina;
            printReceipt();
        }

        if (dtPizzas.Rows.Count > 0)
        {
            hpLog.generarLog("IMPRESION: dtPedidoPizza");
            Session["dtPedidoPizza"] = dtPizzas;
            printReceipt_2();
            printReceipt_6();
        }

        if (dtPizzasPOS.Rows.Count > 0)
        {
            hpLog.generarLog("IMPRESION: dtPedidoPizzaPOS");
            Session["dtPedidoPizzaPOS"] = dtPizzasPOS;
            printReceipt_7();
        }
        hpLog.generarLog("Redireccionamiento ");
        //string urlRed = "frmPedidoDetalle?vchOrdenID=" + Request.QueryString["vchOrdenID"].ToString() +
        //                                         "&vchSalon=" + Request.QueryString["vchSalon"] +
        //                                         "&vchNumMesa=" + Request.QueryString["vchNumMesa"] +
        //                                         "&vchEstado=" + Request.QueryString["vchEstado"];
        //hpLog.generarLog("URL de Redireccionamiento: " + urlRed);
        //Response.Redirect(urlRed);
        Response.Redirect("frmMesas");
        
    }
    void buscarProductos()
    {
        if (!txtBusqueda.Value.Trim().Equals(string.Empty))
        {
            string find = txtBusqueda.Value.Trim().ToUpper();
            gdCartaProductos.Columns[4].Visible = true;
            gdCartaProductos.Columns[5].Visible = true;
            gdCartaProductos.Columns[6].Visible = true;

            DataTable myDT = (DataTable)Session["gdCartaProductos"];
            var result = myDT
                .AsEnumerable()
                .Where(myRow => myRow.Field<string>("vchDeItem").Contains(find))
                .AsDataView();
            gdCartaProductos.DataSource = result;
            gdCartaProductos.DataBind();
        }
    }

    void seleccionarProductos()
    {
        StrSubcategoria = Request.Form["HSubcategoria"].ToString();
        txtBusqueda.Value = string.Empty;
        gdCartaProductos.Columns[4].Visible = true;
        gdCartaProductos.Columns[5].Visible = true;
        gdCartaProductos.Columns[6].Visible = true;
        DataTable myDT = (DataTable)Session["gdCartaProductos"];
        var result = myDT
            .AsEnumerable()
            .Where(myRow => myRow.Field<string>("Categoria") == Strcategoria
            && myRow.Field<string>("SubCategoria") == StrSubcategoria).AsDataView();
        gdCartaProductos.DataSource = result;
        gdCartaProductos.DataBind();
    }


    protected void gdPedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Mas")
        {
            string[] valores = e.CommandArgument.ToString().Split('-');
            Int32 index = Convert.ToInt32(valores[0]);
            
            if(ActualizarStockTiempoReal(valores[1], "Mas"))
                cargarPedidos(valores[1],
                          gdPedido.Rows[index].Cells[2].Text,
                          gdPedido.Rows[index].Cells[3].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "AgregarEvento2();", true);
        }

        if (e.CommandName == "Menos")
        {
            string[] valores = e.CommandArgument.ToString().Split('-');
            Int32 index = Convert.ToInt32(valores[0]);
            
            if(ActualizarStockTiempoReal(valores[1], "Menos"))
                restarItem(valores[1],
                       gdPedido.Rows[index].Cells[2].Text,
                       gdPedido.Rows[index].Cells[3].Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "AgregarEvento2();", true);
        }
        if (e.CommandName == "Comentario")
        {
            string[] valores = e.CommandArgument.ToString().Split('-');
            //Int32 index = Convert.ToInt32(valores[0]);
            Session["valorIndice"] = valores[0];
            Session["vchCodigo"] = valores[1];
            //txtObservacion.Text = "";
            //txtObservacion.Text = dt.Rows[index]["vchComentario"].ToString();
            //obtenerComentario(Convert.ToInt32(valores[0]), valores[1]);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "ComentarioEvento();",
                    true);
            
        }
    }


    private bool ActualizarStockTiempoReal(string codProd, string tipoActualizacion)
    {
        //Si es Mas, se resta 
        if (tipoActualizacion == "Mas")
        {
            //Validamos que el producto se encuentre en la grilla
            int items = gdCartaProductos.Rows.Count;
            if (items > 0)
            {
                for (int i = 0; i < gdCartaProductos.Rows.Count; i++)
                {
                    if (gdCartaProductos.Rows[i].Cells[4].Text == codProd)
                    {
                        if (gdCartaProductos.Rows[i].Cells[2].Text != "0")
                            gdCartaProductos.Rows[i].Cells[2].Text = (int.Parse(gdCartaProductos.Rows[i].Cells[2].Text) - 1).ToString();
                        break;
                    }
                }
            }
            #region [Descontar stock Carta Productos]
            DataTable result = Session["gdCartaProductos"] as DataTable;
            foreach (DataRow item in result.Rows)
            {
                if (item["vchCodigo"].ToString().Equals(codProd))
                {
                    if (item["Stock"].ToString() != "0")
                        item["Stock"] = int.Parse(item["Stock"].ToString()) - 1;
                    else{
                        string javaScript = "NoHayStock();";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
                        return false;
                    }
                    break;
                }
            }
            Session["gdCartaProductos"] = result;
            #endregion
        }
        else
        {
            //Validamos que el producto se encuentre en la grilla
            int items = gdCartaProductos.Rows.Count;
            if (items > 0)
            {
                for (int i = 0; i < gdCartaProductos.Rows.Count; i++)
                {
                    if (gdCartaProductos.Rows[i].Cells[4].Text == codProd)
                    {
                        gdCartaProductos.Rows[i].Cells[2].Text = (int.Parse(gdCartaProductos.Rows[i].Cells[2].Text) + 1).ToString();
                        break;
                    }
                }
            }
            #region [Aumentar stock Carta Productos]
            DataTable result = Session["gdCartaProductos"] as DataTable;
            foreach (DataRow item in result.Rows)
            {
                if (item["vchCodigo"].ToString().Equals(codProd))
                {
                    item["Stock"] = int.Parse(item["Stock"].ToString()) + 1;
                    break;
                }
            }
            Session["gdCartaProductos"] = result;
            #endregion
        }
        return true;
    }

    protected void gdCartaProductos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Agregar")
        {
            string[] valores = e.CommandArgument.ToString().Split('-');
            Int32 index = Convert.ToInt32(valores[0]);
            int stock = int.Parse(gdCartaProductos.Rows[index].Cells[2].Text);
            if (stock != 0)
            {
                #region [Descontar stock Carta Productos]
                gdCartaProductos.Rows[index].Cells[2].Text = (int.Parse(gdCartaProductos.Rows[index].Cells[2].Text) - 1).ToString();
                DataTable result = Session["gdCartaProductos"] as DataTable;
                foreach (DataRow item in result.Rows)
                {
                    if (item["vchCodigo"].ToString().Equals(gdCartaProductos.Rows[index].Cells[4].Text))
                        item["Stock"] = gdCartaProductos.Rows[index].Cells[2].Text;
                }
                Session["gdCartaProductos"] = result;
                #endregion

                #region [Cargar Pedidos]
                cargarPedidos(valores[1],
                              gdCartaProductos.Rows[index].Cells[1].Text,
                              gdCartaProductos.Rows[index].Cells[3].Text);
                #endregion
            }
            else
            {
                string javaScript = "NoHayStock();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "AgregarEvento();", true);
        }
    }


   

    void printReceipt()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        pd.PrinterSettings.PrinterName = "COMPIZZ";//pd.PrinterSettings.PrinterName = "COMACOC";
        pd.Print();
    }
    void printDoc_PrintPage(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoCocina"] as DataTable;

        int i, j;
        //let make j the total count of items on listview
        j = dt.Rows.Count;


        Graphics grafic = e.Graphics;
        Font font = new Font("Courer New", 12);
        float fontHeight = font.GetHeight();
        int StartX = 10;
        int StartY = 10;
        int offSet = 40;

        grafic.DrawString("Gaucho Parrillero", new Font("Courer New", 13), new SolidBrush(Color.Black), StartX, StartY);
        grafic.DrawString(" ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

        grafic.DrawString("====================================================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

        grafic.DrawString("#Pedido: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);
        grafic.DrawString("\t" + Session["OrdenIDTemp"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);

        grafic.DrawString("\t\tDia: " + DateTime.Now, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);


        grafic.DrawString("Salon#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        grafic.DrawString("\t" + Request.QueryString["vchSalon"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        //    grafic.DrawString("\t\t\t\t"+ ordInfo.Times.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

        grafic.DrawString("Mesa#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
        grafic.DrawString("\t" + Request.QueryString["vchNumMesa"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

        grafic.DrawString("Mesero: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
        grafic.DrawString("\t" + Session["Usuario"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));

        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Para Llevar", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }
        else
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Comer Aqui", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }

        string Liners = "====================================================";
        grafic.DrawString(Liners, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


        for (int k = 0; k <= dt.Rows.Count - 1; k++)
        {

            string productLine = dt.Rows[k]["intCantidad"].ToString() + " - " + dt.Rows[k]["vchDeItem"].ToString() + "\t"; //+ proPrice;
            grafic.DrawString(productLine, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));
            //offSet += (int)fontHeight + 5;

            if (!dt.Rows[k]["vchComentario"].ToString().Equals(""))
            {
                grafic.DrawString("\tObs.: " + dt.Rows[k]["vchComentario"].ToString(), new Font("Courer New", 7), new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 10;
            }
            else
            {
                offSet += (int)fontHeight + 5;
            }
        }
    }

    void printReceipt_2()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_2);
        pd.PrinterSettings.PrinterName = "COMAPAR";
        pd.Print();
    }
    void printDoc_PrintPage_2(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoPizza"] as DataTable;

        int i, j;
        //let make j the total count of items on listview
        j = dt.Rows.Count;


        Graphics grafic = e.Graphics;
        Font font = new Font("Courer New", 12);
        float fontHeight = font.GetHeight();
        int StartX = 10;
        int StartY = 10;
        int offSet = 40;

        grafic.DrawString("Gaucho Parrillero", new Font("Courer New", 13), new SolidBrush(Color.Black), StartX, StartY);
        grafic.DrawString(" ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

        grafic.DrawString("====================================================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

        grafic.DrawString("#Pedido: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);
        grafic.DrawString("\t" + Session["OrdenIDTemp"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);

        grafic.DrawString("\t\tDia: " + DateTime.Now, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);


        grafic.DrawString("Salon#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        grafic.DrawString("\t" + Request.QueryString["vchSalon"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        //    grafic.DrawString("\t\t\t\t"+ ordInfo.Times.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

        grafic.DrawString("Mesa#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
        grafic.DrawString("\t" + Request.QueryString["vchNumMesa"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

        grafic.DrawString("Mesero: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
        grafic.DrawString("\t" + Session["Usuario"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));

        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Para Llevar", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }
        else
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Comer Aqui", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }

        string Liners = "====================================================";
        grafic.DrawString(Liners, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


        for (int k = 0; k <= dt.Rows.Count - 1; k++)
        {

            string productLine = dt.Rows[k]["intCantidad"].ToString() + " - " + dt.Rows[k]["vchDeItem"].ToString() + "\t"; //+ proPrice;
            grafic.DrawString(productLine, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));
            //offSet += (int)fontHeight + 5;

            if (!dt.Rows[k]["vchComentario"].ToString().Equals(""))
            {
                grafic.DrawString("\tObs.: " + dt.Rows[k]["vchComentario"].ToString(), new Font("Courer New", 7), new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 10;
            }
            else
            {
                offSet += (int)fontHeight + 5;
            }
        }
    }

    void printReceipt_6()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_6);
        pd.PrinterSettings.PrinterName = "COMPIZZ";//pd.PrinterSettings.PrinterName = "COMACOC";
        pd.Print();
    }

    void printDoc_PrintPage_6(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoPizza"] as DataTable;

        int i, j;
        //let make j the total count of items on listview
        j = dt.Rows.Count;


        Graphics grafic = e.Graphics;
        Font font = new Font("Courer New", 12);
        float fontHeight = font.GetHeight();
        int StartX = 10;
        int StartY = 10;
        int offSet = 40;

        grafic.DrawString("Gaucho Parrillero", new Font("Courer New", 13), new SolidBrush(Color.Black), StartX, StartY);
        grafic.DrawString(" ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

        grafic.DrawString("====================================================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

        grafic.DrawString("#Pedido: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);
        grafic.DrawString("\t" + Session["OrdenIDTemp"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);

        grafic.DrawString("\t\tDia: " + DateTime.Now, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);


        grafic.DrawString("Salon#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        grafic.DrawString("\t" + Request.QueryString["vchSalon"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        //    grafic.DrawString("\t\t\t\t"+ ordInfo.Times.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

        grafic.DrawString("Mesa#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
        grafic.DrawString("\t" + Request.QueryString["vchNumMesa"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

        grafic.DrawString("Mesero: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
        grafic.DrawString("\t" + Session["Usuario"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));

        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Para Llevar", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }
        else
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Comer Aqui", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }

        string Liners = "====================================================";
        grafic.DrawString(Liners, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


        for (int k = 0; k <= dt.Rows.Count - 1; k++)
        {

            string productLine = dt.Rows[k]["intCantidad"].ToString() + " - " + dt.Rows[k]["vchDeItem"].ToString() + "\t"; //+ proPrice;
            grafic.DrawString(productLine, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));
            //offSet += (int)fontHeight + 5;

            if (!dt.Rows[k]["vchComentario"].ToString().Equals(""))
            {
                grafic.DrawString("\tObs.: " + dt.Rows[k]["vchComentario"].ToString(), new Font("Courer New", 7), new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 10;
            }
            else
            {
                offSet += (int)fontHeight + 5;
            }
        }
    }

    void printReceipt_7()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_7);
        pd.PrinterSettings.PrinterName = "COMPIZZ";
        pd.Print();
    }

    void printDoc_PrintPage_7(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoPizzaPOS"] as DataTable;

        int i, j;
        //let make j the total count of items on listview
        j = dt.Rows.Count;


        Graphics grafic = e.Graphics;
        Font font = new Font("Courer New", 12);
        float fontHeight = font.GetHeight();
        int StartX = 10;
        int StartY = 10;
        int offSet = 40;

        grafic.DrawString("Gaucho Parrillero", new Font("Courer New", 13), new SolidBrush(Color.Black), StartX, StartY);
        grafic.DrawString(" ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

        grafic.DrawString("====================================================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

        grafic.DrawString("#Pedido: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);
        grafic.DrawString("\t" + Session["OrdenIDTemp"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);

        grafic.DrawString("\t\tDia: " + DateTime.Now, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);


        grafic.DrawString("Salon#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        grafic.DrawString("\t" + Request.QueryString["vchSalon"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        //    grafic.DrawString("\t\t\t\t"+ ordInfo.Times.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

        grafic.DrawString("Mesa#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
        grafic.DrawString("\t" + Request.QueryString["vchNumMesa"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

        grafic.DrawString("Mesero: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
        grafic.DrawString("\t" + Session["Usuario"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));

        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Para Llevar", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }
        else
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Comer Aqui", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }

        string Liners = "====================================================";
        grafic.DrawString(Liners, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


        for (int k = 0; k <= dt.Rows.Count - 1; k++)
        {

            string productLine = dt.Rows[k]["intCantidad"].ToString() + " - " + dt.Rows[k]["vchDeItem"].ToString() + "\t"; //+ proPrice;
            grafic.DrawString(productLine, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));
            //offSet += (int)fontHeight + 5;

            if (!dt.Rows[k]["vchComentario"].ToString().Equals(""))
            {
                grafic.DrawString("\tObs.: " + dt.Rows[k]["vchComentario"].ToString(), new Font("Courer New", 7), new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 10;
            }
            else
            {
                offSet += (int)fontHeight + 5;
            }
        }
    }
    protected void gdPedido_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton libtMas = (LinkButton)e.Row.FindControl("ibtMas");
            LinkButton libtMenos = (LinkButton)e.Row.FindControl("ibtMenos");
            LinkButton libtComentario = (LinkButton)e.Row.FindControl("ibtComentario");
            CheckBox lchkEnviado = (CheckBox)e.Row.FindControl("chkEnviado");

            DataRow drv = ((DataRowView)e.Row.DataItem).Row;

            if (drv["vchImpresion"].ToString().Equals("S"))
            {
                //libtMas.Visible = false;
                libtMas.Enabled = false;
                //libtMenos.Visible = false;
                libtMenos.Enabled = false;
                //libtComentario.Visible = false;
                //libtComentario.Enabled = false;
                lchkEnviado.Checked = true;
            }

            lchkEnviado.Enabled = false;

        }
    }
    
    protected void btnPreCuenta_Click(object sender, EventArgs e)
    {
        //generaraPreCuenta(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
        imprimirPreCuenta();
        Response.Redirect("frmMesas");
    }

    void generaraPreCuenta(Int32 pintOrdenID) {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;

        dtResponse = lobjProducto.generarPreCuenta(pintOrdenID,
                                                   Session["Usuario"].ToString());

    }
    void ImprimirPreCuentaHTML()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    $"crearIframe('{Request.QueryString["vchOrdenID"].ToString()}','{Request.QueryString["vchSalon"].ToString()}','{Request.QueryString["vchNumMesa"].ToString()}');" +
                    "$('#pdfModal').modal('show');",
                    true);
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
            if (dt.Rows[i]["vchImpresion"].ToString().Equals("S")) {
                decMontoTotal = decMontoTotal + Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString());
                ticket.AgregaArticulo(dt.Rows[i]["vchDeItem"].ToString(),
                                      Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()),
                                      Convert.ToDecimal(dt.Rows[i]["numPrecioUni"].ToString()),
                                      Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString()));
            }
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
        DataTable dtPizzaPOS = new DataTable();
        dsResponse = lobjProducto.obtenerReImpresionComanda(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
        dtCocina = dsResponse.Tables[0];
        dtPizza = dsResponse.Tables[1];
        dtPizzaPOS = dsResponse.Tables[2];

        if (dtCocina.Rows.Count > 0) {
            Session["dtPedidoCocina"] = dtCocina;
            printReceipt_3();
        }

        if (dtPizza.Rows.Count > 0)
        {
            Session["dtPedidoPizza"] = dtPizza;
            printReceipt_4();
            printReceipt_5();
        }

        if (dtPizzaPOS.Rows.Count > 0)
        {
            Session["dtPedidoPizzaPOS"] = dtPizzaPOS;
            printReceipt_8();
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
        pd.PrinterSettings.PrinterName = "COMPIZZ";//pd.PrinterSettings.PrinterName = "COMACOC";
        pd.Print();
    }

    void printDoc_PrintPage_3(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoCocina"] as DataTable;

        int i, j;
        //let make j the total count of items on listview
        j = dt.Rows.Count;


        Graphics grafic = e.Graphics;
        Font font = new Font("Courer New", 12);
        float fontHeight = font.GetHeight();
        int StartX = 10;
        int StartY = 10;
        int offSet = 40;

        grafic.DrawString("Gaucho Parrillero", new Font("Courer New", 13), new SolidBrush(Color.Black), StartX, StartY);
        grafic.DrawString(" ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

        grafic.DrawString("====================================================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

        grafic.DrawString("#Pedido: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);
        grafic.DrawString("\t" + Session["OrdenIDTemp"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);

        grafic.DrawString("\t\tDia: " + DateTime.Now, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);


        grafic.DrawString("Salon#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        grafic.DrawString("\t" + Request.QueryString["vchSalon"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        //    grafic.DrawString("\t\t\t\t"+ ordInfo.Times.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

        grafic.DrawString("Mesa#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
        grafic.DrawString("\t" + Request.QueryString["vchNumMesa"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

        grafic.DrawString("Mesero: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
        grafic.DrawString("\t" + Session["Usuario"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));

        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Para Llevar", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }
        else
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Comer Aqui", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }

        string Liners = "====================================================";
        grafic.DrawString(Liners, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


        for (int k = 0; k <= dt.Rows.Count - 1; k++)
        {

            string productLine = dt.Rows[k]["intCantidad"].ToString() + " - " + dt.Rows[k]["vchDeItem"].ToString() + "\t"; //+ proPrice;
            grafic.DrawString(productLine, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));
            //offSet += (int)fontHeight + 5;

            if (!dt.Rows[k]["vchComentario"].ToString().Equals(""))
            {
                grafic.DrawString("\tObs.: " + dt.Rows[k]["vchComentario"].ToString(), new Font("Courer New", 7), new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 10;
            }
            else
            {
                offSet += (int)fontHeight + 5;
            }
        }
    }

    void printReceipt_4()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_4);
        pd.PrinterSettings.PrinterName = "COMAPAR";
        pd.Print();
    }

    void printDoc_PrintPage_4(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoPizza"] as DataTable;

        int i, j;
        //let make j the total count of items on listview
        j = dt.Rows.Count;


        Graphics grafic = e.Graphics;
        Font font = new Font("Courer New", 12);
        float fontHeight = font.GetHeight();
        int StartX = 10;
        int StartY = 10;
        int offSet = 40;

        grafic.DrawString("Gaucho Parrillero", new Font("Courer New", 13), new SolidBrush(Color.Black), StartX, StartY);
        grafic.DrawString(" ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

        grafic.DrawString("====================================================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

        grafic.DrawString("#Pedido: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);
        grafic.DrawString("\t" + Session["OrdenIDTemp"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);

        grafic.DrawString("\t\tDia: " + DateTime.Now, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);


        grafic.DrawString("Salon#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        grafic.DrawString("\t" + Request.QueryString["vchSalon"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        //    grafic.DrawString("\t\t\t\t"+ ordInfo.Times.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

        grafic.DrawString("Mesa#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
        grafic.DrawString("\t" + Request.QueryString["vchNumMesa"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

        grafic.DrawString("Mesero: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
        grafic.DrawString("\t" + Session["Usuario"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));

        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Para Llevar", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }
        else
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Comer Aqui", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }

        string Liners = "====================================================";
        grafic.DrawString(Liners, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


        for (int k = 0; k <= dt.Rows.Count - 1; k++)
        {

            string productLine = dt.Rows[k]["intCantidad"].ToString() + " - " + dt.Rows[k]["vchDeItem"].ToString() + "\t"; //+ proPrice;
            grafic.DrawString(productLine, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));
            //offSet += (int)fontHeight + 5;

            if (!dt.Rows[k]["vchComentario"].ToString().Equals(""))
            {
                grafic.DrawString("\tObs.: " + dt.Rows[k]["vchComentario"].ToString(), new Font("Courer New", 7), new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 10;
            }
            else
            {
                offSet += (int)fontHeight + 5;
            }
        }
    }

    void printReceipt_5()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_5);
        pd.PrinterSettings.PrinterName = "COMPIZZ";//pd.PrinterSettings.PrinterName = "COMACOC";
        pd.Print();
    }

    void printDoc_PrintPage_5(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoPizza"] as DataTable;

        int i, j;
        //let make j the total count of items on listview
        j = dt.Rows.Count;


        Graphics grafic = e.Graphics;
        Font font = new Font("Courer New", 12);
        float fontHeight = font.GetHeight();
        int StartX = 10;
        int StartY = 10;
        int offSet = 40;

        grafic.DrawString("Gaucho Parrillero", new Font("Courer New", 13), new SolidBrush(Color.Black), StartX, StartY);
        grafic.DrawString(" ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

        grafic.DrawString("====================================================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

        grafic.DrawString("#Pedido: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);
        grafic.DrawString("\t" + Session["OrdenIDTemp"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);

        grafic.DrawString("\t\tDia: " + DateTime.Now, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);


        grafic.DrawString("Salon#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        grafic.DrawString("\t" + Request.QueryString["vchSalon"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        //    grafic.DrawString("\t\t\t\t"+ ordInfo.Times.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

        grafic.DrawString("Mesa#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
        grafic.DrawString("\t" + Request.QueryString["vchNumMesa"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

        grafic.DrawString("Mesero: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
        grafic.DrawString("\t" + Session["Usuario"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));

        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Para Llevar", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }
        else
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Comer Aqui", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }

        string Liners = "====================================================";
        grafic.DrawString(Liners, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


        for (int k = 0; k <= dt.Rows.Count - 1; k++)
        {

            string productLine = dt.Rows[k]["intCantidad"].ToString() + " - " + dt.Rows[k]["vchDeItem"].ToString() + "\t"; //+ proPrice;
            grafic.DrawString(productLine, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));
            //offSet += (int)fontHeight + 5;

            if (!dt.Rows[k]["vchComentario"].ToString().Equals(""))
            {
                grafic.DrawString("\tObs.: " + dt.Rows[k]["vchComentario"].ToString(), new Font("Courer New", 7), new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 10;
            }
            else
            {
                offSet += (int)fontHeight + 5;
            }
        }
    }

    void printReceipt_8()
    {

        PrintDocument pd = new PrintDocument();
        pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_8);
        pd.PrinterSettings.PrinterName = "COMPIZZ";
        pd.Print();
    }

    void printDoc_PrintPage_8(object sender, PrintPageEventArgs e)
    {

        DataTable dt;
        dt = Session["dtPedidoPizzaPOS"] as DataTable;

        int i, j;
        //let make j the total count of items on listview
        j = dt.Rows.Count;


        Graphics grafic = e.Graphics;
        Font font = new Font("Courer New", 12);
        float fontHeight = font.GetHeight();
        int StartX = 10;
        int StartY = 10;
        int offSet = 40;

        grafic.DrawString("Gaucho Parrillero", new Font("Courer New", 13), new SolidBrush(Color.Black), StartX, StartY);
        grafic.DrawString(" ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 5);

        grafic.DrawString("====================================================", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 20);

        grafic.DrawString("#Pedido: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);
        grafic.DrawString("\t" + Session["OrdenIDTemp"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);

        grafic.DrawString("\t\tDia: " + DateTime.Now, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + 40);


        grafic.DrawString("Salon#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        grafic.DrawString("\t" + Request.QueryString["vchSalon"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));
        //    grafic.DrawString("\t\t\t\t"+ ordInfo.Times.ToString().PadRight(30), new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 20));

        grafic.DrawString("Mesa#: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));
        grafic.DrawString("\t" + Request.QueryString["vchNumMesa"].ToString(), new Font("Courer New", 11), new SolidBrush(Color.Black), StartX, StartY + (offSet + 40));

        grafic.DrawString("Mesero: ", new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));
        grafic.DrawString("\t" + Session["Usuario"].ToString(), new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 60));

        if (Request.QueryString["vchNumMesa"].ToString().Equals("0"))
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Para Llevar", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }
        else
        {
            grafic.DrawString("Obs.: ", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
            grafic.DrawString("\t" + "Comer Aqui", new Font("Courer New", 10), new SolidBrush(Color.Black), StartX, StartY + (offSet + 80));
        }

        string Liners = "====================================================";
        grafic.DrawString(Liners, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 100));


        for (int k = 0; k <= dt.Rows.Count - 1; k++)
        {

            string productLine = dt.Rows[k]["intCantidad"].ToString() + " - " + dt.Rows[k]["vchDeItem"].ToString() + "\t"; //+ proPrice;
            grafic.DrawString(productLine, new Font("Courer New", 8), new SolidBrush(Color.Black), StartX, StartY + (offSet + 120));
            //offSet += (int)fontHeight + 5;

            if (!dt.Rows[k]["vchComentario"].ToString().Equals(""))
            {
                grafic.DrawString("\tObs.: " + dt.Rows[k]["vchComentario"].ToString(), new Font("Courer New", 7), new SolidBrush(Color.Black), StartX, StartY + (offSet + 140));
                offSet += (int)fontHeight + 10;
            }
            else
            {
                offSet += (int)fontHeight + 5;
            }
        }
    }

    void fn_obtenerCartaMenu()
    {
        clsProducto lobjProducto = new clsProducto();
        DataSet ldsRpta;

        ldsRpta = lobjProducto.fn_obtenerMenuCarta();

        DTcategoria = ldsRpta.Tables[0].AsEnumerable().Where(x => x.Field<int>("id_sucursal") == (int)Session["Idsucursal"]).CopyToDataTable();
        DTSubCategoria = ldsRpta.Tables[1].AsEnumerable().Where(x => x.Field<int>("id_sucursal") == (int)Session["Idsucursal"]).CopyToDataTable();
        string StrHtml = "";
        foreach (DataRow level1DataRow in DTcategoria.Rows)
        {
            string categoria = level1DataRow["vchCategoria"].ToString();
            StrHtml += "<button title='"+ categoria + "' id='" + categoria + "' style='border-radius:0px;' onClick='seleccionarCategoria(this.id)' type='button' class='btn btn-secondary w-25 font-weight-bold'>" + categoria + "</button>";
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                "document.getElementById('categoria').innerHTML = \"" + StrHtml + "\";",
                true);
    }


    protected void gdCartaProductos_DataBound(object sender, EventArgs e)
    {
        gdCartaProductos.Columns[4].Visible = false;
        gdCartaProductos.Columns[5].Visible = false;
        gdCartaProductos.Columns[6].Visible = false;
    }

    protected void EventCategoria_Click(object sender, EventArgs e)
    {
        string StrHtml = "";
        string categoria = Request.Form["Hcategoria"].ToString();
        foreach (DataRow level1DataRow in DTSubCategoria.Rows)
        {
            if (level1DataRow["vchCategoria"].ToString().Equals(categoria))
            {
                string subcategoria = level1DataRow["vchSubCategoria"].ToString();
                StrHtml += "<button title='" + subcategoria + "' id='" + subcategoria + "' style='border-radius:0px;' onClick='seleccionarSubCategoria(this.id)' type='button'  class='btn btn-tertiary w-25 font-weight-bold'>" + subcategoria + "</button>";
            }
        }
        NombCat.InnerText = categoria;
        Strcategoria = categoria;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "cargarHTMLsubCateg(\"" + StrHtml + "\");", true);
    }

    protected void EventSubCategoria_Click(object sender, EventArgs e)
    {
        seleccionarProductos();
    }

    protected void EventComentario_Click(object sender, EventArgs e)
    {
        obtenerComentario(Convert.ToInt32(Session["valorIndice"]), Session["vchCodigo"].ToString());
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('show');",
                    true);
    }

    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        buscarProductos();
    }

    protected void btnguardar_Click1(object sender, EventArgs e)
    {
        //string indice = Session["valorIndice"].ToString();
        string codigo = Session["vchCodigo"].ToString();
        cargarComentario(codigo);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('hide');",
                    true);
    }

    protected void Enviar_Click(object sender, EventArgs e)
    {
        enviarCocina();
    }

    protected void cerrar_Click(object sender, EventArgs e)
    {

    }

    protected void Precuenta_Click(object sender, EventArgs e)
    {
        ImprimirPreCuentaHTML();
    }
}