
using bussinessLayer;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace WebSites
{
    public partial class frmPedidoMesas : System.Web.UI.Page
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
                Session["OrdenIDTemp"] = null;
                int vchSalon = Convert.ToInt32(Request.QueryString["vchSalon"].ToString());
                int vchNumMesa = Convert.ToInt32(Request.QueryString["vchNumMesa"].ToString());
                if (vchSalon == 0 && vchNumMesa == 0)
                {
                    lblcantper.Style.Add("display", "none");
                    txtcantper.Style.Add("display", "none");

                }
                else
                {
                    lblCliente.Style.Add("display", "none");
                    txtcliente.Style.Add("display", "none");
                }
                Session["gdCartaProductos"] = new DataTable();
                armarTablaPedidos();
                armarTablaPedidosCocina();
                armarTablaPedidosPizza();
                armarTablaPedidosPizza_POS();
                fn_obtenerCartaMenu();
                gdPedido.DataSource = (DataTable)Session["dtPedido"];
                gdPedido.DataBind();
                gdCartaProductos.DataSource = (DataTable)Session["gdCartaProductos"];
                gdCartaProductos.DataBind();
                cargarCarta();
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

            Session["dtPedido"] = dt;
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

            Session["dtPedidoPizza"] = dt;
        }

        void armarTablaPedidosPizza_POS()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("vchNumSecu");
            dt.Columns.Add("intCantidad");
            dt.Columns.Add("vchCodigo");
            dt.Columns.Add("vchDeItem");
            dt.Columns.Add("numPrecioUni");
            dt.Columns.Add("numPrecioTot");
            dt.Columns.Add("vchComentario");

            Session["dtPedidoPizzaPOS"] = dt;
        }

        protected void gdPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Mas")
            {
                string[] valores = e.CommandArgument.ToString().Split('-');
                Int32 index = Convert.ToInt32(valores[0]);

                if (ActualizarStockTiempoReal(valores[1], "Mas"))
                    cargarPedidos(valores[1],
                              gdPedido.Rows[index].Cells[2].Text,
                              gdPedido.Rows[index].Cells[3].Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "AgregarEvento2();", true);
            }

            if (e.CommandName == "Menos")
            {
                string[] valores = e.CommandArgument.ToString().Split('-');
                Int32 index = Convert.ToInt32(valores[0]);

                if (ActualizarStockTiempoReal(valores[1], "Menos"))
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
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "ComentarioEvento();",
                    true);
            }
        }

        

        protected void gdCartaProductos_DataBound(object sender, EventArgs e)
        {
            gdCartaProductos.Columns[4].Visible = false;
            gdCartaProductos.Columns[5].Visible = false;
            gdCartaProductos.Columns[6].Visible = false;
        }
        void fn_obtenerCartaMenu()
        {
            clsProducto lobjProducto = new clsProducto();
            DataSet ldsRpta;

            ldsRpta = lobjProducto.fn_obtenerMenuCarta();
            var categorias = ldsRpta.Tables[0].AsEnumerable().Where(x => x.Field<int>("id_sucursal") == (int)Session["Idsucursal"]);
            if (categorias.Any()) 
                DTcategoria = categorias.CopyToDataTable();
            else 
                DTcategoria = new DataTable();
            var subcategorias = ldsRpta.Tables[1].AsEnumerable().Where(x => x.Field<int>("id_sucursal") == (int)Session["Idsucursal"]);
            
            if (subcategorias.Any())
                DTSubCategoria = subcategorias.CopyToDataTable();
            else
                DTSubCategoria = new DataTable();
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
        void cargarCarta()
        {
            clsProducto lobjProducto = new clsProducto();
            Session["gdCartaProductos"] = lobjProducto.obtenerProductos((int)Session["Idsucursal"]);
        }
        void seleccionarProductos()
        {
            StrSubcategoria = Request.Form["HSubcategoria"].ToString();
            txtBusqueda.Value =string.Empty;
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
        void cargarPedidos(String pstrCodigo,
                       String pstrDeItem,
                       String pnumPrecioUni)

        {
            DataTable dt;
            DataRow row;
            Int32 intCantidadItems = 0;
            Double dblMonto = 0.0;
            Boolean bolInsertado = false;


            dt = Session["dtPedido"] as DataTable;

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
                    return;
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
                dt.Rows.Add(row);

                Session["dtPedido"] = dt;

                calcularMontoTotal();

                gdPedido.DataSource = dt;
                gdPedido.DataBind();
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
                        else
                        {
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
        void restarItem(String pstrCodigo,
                    String pstrDeItem,
                    String pnumPrecioUni)
        {
            DataTable dt;
            Int32 intCantidadItems = 0;
            Double dblMonto = 0.0;


            dt = Session["dtPedido"] as DataTable;

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (dt.Rows[i]["vchCodigo"].Equals(pstrCodigo))
                {
                    intCantidadItems = Convert.ToInt32(dt.Rows[i]["intCantidad"]);

                    if (intCantidadItems == 1)
                    {
                        dt.Rows[i].Delete();
                        Session["dtPedido"] = dt;

                        calcularMontoTotal();

                        gdPedido.DataSource = dt;
                        gdPedido.DataBind();
                        return;

                    }

                    intCantidadItems = intCantidadItems - 1;
                    dblMonto = intCantidadItems * Convert.ToDouble(dt.Rows[i]["numPrecioUni"]);
                    dt.Rows[i]["intCantidad"] = intCantidadItems.ToString();
                    dt.Rows[i]["numPrecioTot"] = dblMonto.ToString("n2");

                    Session["dtPedido"] = dt;

                    calcularMontoTotal();

                    gdPedido.DataSource = dt;
                    gdPedido.DataBind();
                    return;
                }
            }
        }
        void obtenerComentario(Int32 pintindice,
                           String pstrCodigo)
        {
            DataTable dt;
            dt = Session["dtPedido"] as DataTable;

            txtObservacion.Value = dt.Rows[pintindice]["vchComentario"].ToString();
        }

        void enviarCocina()
        {
            hpLog.generarLog("INICIO DE GENERACION DE PEDIDO");
            clsProducto lobjProducto = new clsProducto();
            DataTable dtResponseCab;
            DataSet dsResponseDet;
            DataTable dt;
            DataTable dtCocina = new DataTable();
            DataTable dtPizzas = new DataTable();
            DataTable dtPizzasPOS = new DataTable();
            //DataTable dtStockProd;
            DataTable dtActualizarStock;
            DataTable dtActualizar;
            string DataVenta = "";
            int vchSalon = Convert.ToInt32(Request.QueryString["vchSalon"].ToString());
            int vchNumMesa = Convert.ToInt32(Request.QueryString["vchNumMesa"].ToString());
            if (vchSalon != 0 && vchNumMesa != 0)
            {
                if (txtcantper.Value == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                        "toastr.info('Ingrese Cantidad de Personas', 'Cantidad Personas');",
                        true);
                    return;
                }
            }
            else if(vchSalon == 0 && vchNumMesa == 0)
            {
                txtcantper.Value = "0";
                if (txtcliente.Value == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                        "toastr.info('Ingrese nombre de cliente', 'Cliente');",
                        true);
                    return;
                }
            }
            
            if (gdPedido.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.info('Seleccione los platos.', 'Pedido');",
                    true);
                return;
            }

            dt = Session["dtPedido"] as DataTable;

            dtResponseCab = lobjProducto.generarOrdenCab("C",
                                                      Convert.ToInt32(Request.QueryString["vchSalon"].ToString()),
                                                      Convert.ToInt32(Request.QueryString["vchNumMesa"].ToString()),
                                                      Session["Usuario"].ToString(),
                                                      txtcliente.Value,
                                                      "ACT",
                                                      "N",
                                                      (int)Session["Idsucursal"],
                                                       int.Parse(txtcantper.Value)) ;

            Session["OrdenIDTemp"] = dtResponseCab.Rows[0]["OrdenID"].ToString();

            //for (int i = 0; i <= dt.Rows.Count - 1; i++)
            //{
            //    string CodProd = dt.Rows[i]["vchCodigo"].ToString();
            //    int cantidad = int.Parse(dt.Rows[i]["intCantidad"].ToString());
            //    dtStockProd = lobjProducto.getStockByProducto(CodProd);
            //    if (int.Parse(dtStockProd.Rows[0].ItemArray[0].ToString()) < cantidad)
            //    {
            //        string javaScript = "NoHayStock();";
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            //        return;
            //    }
            //}

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                dsResponseDet = lobjProducto.generarOrdenDet(Convert.ToInt32(dtResponseCab.Rows[0]["OrdenID"].ToString()),
                                                             Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()),
                                                             Convert.ToInt32(dt.Rows[i]["vchCodigo"].ToString()),
                                                             Convert.ToDouble(dt.Rows[i]["numPrecioUni"].ToString()),
                                                             dt.Rows[i]["vchComentario"].ToString(),
                                                             Session["Usuario"].ToString());
                dtCocina = dsResponseDet.Tables[0];
                dtPizzas = dsResponseDet.Tables[1];
                dtPizzasPOS = dsResponseDet.Tables[2];

                dtActualizarStock = lobjProducto.actualizarStock(Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()), Convert.ToInt32(dt.Rows[i]["vchCodigo"].ToString()));
                DataVenta = DataVenta + dtActualizarStock.Rows[0].ItemArray[0].ToString();
            }
            dtActualizar = lobjProducto.actualizarVenta(Convert.ToInt32(dtResponseCab.Rows[0]["OrdenID"].ToString()), DataVenta);
            hpLog.generarLog("OrdenID: " + dtResponseCab.Rows[0]["OrdenID"].ToString());
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
                printReceipt_3();
            }

            if (dtPizzasPOS.Rows.Count > 0)
            {
                hpLog.generarLog("IMPRESION: dtPedidoPizzaPOS");
                Session["dtPedidoPizzaPOS"] = dtPizzasPOS;
                printReceipt_4();
            }

            Response.Redirect("frmMesas");
        }
        void printReceipt()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            pd.PrinterSettings.PrinterName = "COMPIZZ";//pd.PrinterSettings.PrinterName = "COMPIZZ";//pd.PrinterSettings.PrinterName = "COMACOC";
            pd.Print();
        }

        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            DataTable dt;
            dt = Session["dtPedidoCocina"] as DataTable;

            //int i, j;
            int j;
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

            //int i, j;
            int j;
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

        void printReceipt_3()
        {

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_3);
            pd.PrinterSettings.PrinterName = "COMPIZZ";//pd.PrinterSettings.PrinterName = "COMPIZZ";//pd.PrinterSettings.PrinterName = "COMACOC";
            pd.Print();
        }

        void printReceipt_4()
        {

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage_4);
            pd.PrinterSettings.PrinterName = "COMPIZZ";
            pd.Print();
        }

        void printDoc_PrintPage_3(object sender, PrintPageEventArgs e)
        {
            DataTable dt;
            dt = Session["dtPedidoPizza"] as DataTable;

            //int i, j;
            int j;
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

        void printDoc_PrintPage_4(object sender, PrintPageEventArgs e)
        {
            DataTable dt;
            dt = Session["dtPedidoPizzaPOS"] as DataTable;

            // int i, j;
            int j;
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

        
        void cargarComentario(Int32 pintindice,
                          String pstrCodigo)
        {
            DataTable dt;
            dt = Session["dtPedido"] as DataTable;

            dt.Rows[pintindice]["vchComentario"] = txtObservacion.Value;
            txtObservacion.Value = "";
            Session["valorIndice"] = null;
            Session["vchCodigo"] = null;
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "cargarHTMLsubCateg(\""+ StrHtml + "\");", true);
        }

        protected void EventSubCategoria_Click(object sender, EventArgs e)
        {
            seleccionarProductos();
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            buscarProductos();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string indice = Session["valorIndice"].ToString();
            string codigo = Session["vchCodigo"].ToString();
            cargarComentario(Convert.ToInt32(Session["valorIndice"].ToString()), Session["vchCodigo"].ToString());
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('hide');",
                    true);
        }

        protected void EventComentario_Click(object sender, EventArgs e)
        {
            obtenerComentario(Convert.ToInt32(Session["valorIndice"]), Session["vchCodigo"].ToString());
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('show');",
                    true);
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            int vchSalon = Convert.ToInt32(Request.QueryString["vchSalon"].ToString());
            int vchNumMesa = Convert.ToInt32(Request.QueryString["vchNumMesa"].ToString());
            clsProducto lobjProducto = new clsProducto();
            DataTable dt = lobjProducto.ConsultarDisponibilidadMesas(vchNumMesa,vchSalon, (int)Session["Idsucursal"]);
            if (dt.Rows.Count>0 && vchSalon != 0 && vchNumMesa != 0) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                "NoHayMesa("+ vchNumMesa + ");",
                true);
                return;
            }
            enviarCocina();
        }
    }
}