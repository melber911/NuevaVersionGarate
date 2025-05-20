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
    public partial class frmReporteConsolidado : System.Web.UI.Page
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
                
                Session["gvConsolidado"] = new DataTable();
                Buscar();
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

        public void Buscar()
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;

            ldtResponse = lobjProducto.obtenerReporteConsolidado((int)HttpContext.Current.Session["Idsucursal"]);
            Session["gvConsolidado"] = ldtResponse;
            if (ldtResponse.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('No Existe Stock de productos','info');", true);
                return;
            }

            GridView1.DataSource = ldtResponse;
            GridView1.DataBind();
        }


        protected void imgExcelDescarga1_Click(object sender, EventArgs e)
        {
            String lstrNameReporte = "";
            lstrNameReporte = "ReporteConsolidadoProductos.xls";
            GridView2.DataSource = (DataTable)Session["gvConsolidado"];
            GridView2.DataBind();
            buscarReportexFecha(lstrNameReporte);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = (DataTable)Session["gvConsolidado"];
            GridView1.DataBind();
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            //GridView gv = (GridView)sender;

            //if ((gv.ShowHeader == true && gv.Rows.Count > 0)
            //    || (gv.ShowHeaderWhenEmpty == true))
            //{
            //    gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}
            //if ((gv.AllowPaging == true && gv.Rows.Count > 0))
            //{
            //    gv.BottomPagerRow.TableSection = TableRowSection.TableFooter;
            //}
        }
    }
}