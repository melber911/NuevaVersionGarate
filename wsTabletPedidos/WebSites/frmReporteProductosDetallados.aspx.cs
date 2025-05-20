using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class frmReporteProductosDetallados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
                return;
            }
            if (!IsPostBack)
            {
                
                Session["gvProductosDetalles"] = new DataTable();
                Bgen.Visible = true;
                Breg.Visible = false;
                Bdes.Visible = false;
                GridView1.DataSource = (DataTable)Session["gvProductosDetalles"];
                GridView1.DataBind();
            }
        }
        void buscarReportexFecha(String pstrNameReporte)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            form.Controls.Add(GridView2);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + pstrNameReporte);
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String lstrFechaIni = "";
            String lstrFechaFin = "";
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;
            if (datepicker3.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Se requiere ingresar fecha de inicio','Fecha de inicio');", true);
                return;
            }
            if (datepicker4.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Se requiere ingresar fecha fin','Fecha fin');", true);
                return;
            }
            lstrFechaIni = Convert.ToDateTime(datepicker3.Value).ToString("yyyyMMdd");
            lstrFechaFin = Convert.ToDateTime(datepicker4.Value).ToString("yyyyMMdd");

            ldtResponse = lobjProducto.obtenerReportedeVentasProducto(lstrFechaIni, lstrFechaFin, (int)HttpContext.Current.Session["Idsucursal"]);
            Session["gvProductosDetalles"] = ldtResponse;
            if (ldtResponse.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('No hay datos con los parámetros seleccionados','info');", true);
                return;
            }

            GridView1.DataSource = ldtResponse;
            GridView1.DataBind();

            Bgen.Visible = false;
            datepicker3.Disabled = true;
            datepicker4.Disabled = true;
            Breg.Visible = true;
            Bdes.Visible = true;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Bgen.Visible = true;
            Breg.Visible = false;
            Bdes.Visible = false;
            datepicker3.Disabled = false;
            datepicker3.Value = "";
            datepicker4.Disabled = false;
            datepicker4.Value = "";
            GridView1.DataSource = new DataTable();
            GridView1.DataBind();
        }

        protected void imgExcelDescarga1_Click(object sender, EventArgs e)
        {
            String lstrNameReporte = "";
            String lstrFechaIni = "";
            String lstrFechaFin = "";
            lstrFechaIni = Convert.ToDateTime(datepicker3.Value).ToString("yyyyMMdd");
            lstrFechaFin = Convert.ToDateTime(datepicker4.Value).ToString("yyyyMMdd");
            lstrNameReporte = "RepProductosVendidos_" + lstrFechaIni + "_" + lstrFechaFin + ".xls";
            GridView2.DataSource = (DataTable)Session["gvProductosDetalles"];
            GridView2.DataBind();
            buscarReportexFecha(lstrNameReporte);
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if ((gv.AllowPaging == true && gv.Rows.Count > 0))
            {
                gv.BottomPagerRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = (DataTable)Session["gvProductosDetalles"];
            GridView1.DataBind();
        }
    }
}