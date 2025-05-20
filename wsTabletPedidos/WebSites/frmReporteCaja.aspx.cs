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
    public partial class frmReporteCaja : System.Web.UI.Page
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
                
                Session["gvCaja"] = new DataTable();
                Bgen.Visible = true;
                Breg.Visible = false;
                Bdes.Visible = false;
                GridView1.DataSource = (DataTable)Session["gvCaja"];
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
            Int32 lintTurno = 1;

            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;
            if (datepicker11.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Se requiere ingresar fecha','Fecha');", true);
                return;
            }
            lstrFechaIni = Convert.ToDateTime(datepicker11.Value).ToString("yyyyMMdd");
            lintTurno = Convert.ToInt32(ddlTurno.Value);

            ldtResponse = lobjProducto.obtenerReporteCaja(lstrFechaIni, lintTurno, (int)HttpContext.Current.Session["Idsucursal"]);
            Session["gvCaja"] = ldtResponse;
            if (ldtResponse.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('No hay datos con los parámetros seleccionados','info');", true);
                return;
            }

            GridView1.DataSource = ldtResponse;
            GridView1.DataBind();

            Bgen.Visible = false;
            datepicker11.Disabled = true;
            ddlTurno.Disabled = true;
            Breg.Visible = true;
            Bdes.Visible = true;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Bgen.Visible = true;
            Breg.Visible = false;
            Bdes.Visible = false;
            datepicker11.Disabled = false;
            datepicker11.Value = "";
            ddlTurno.Disabled = false;
            GridView1.DataSource = new DataTable();
            GridView1.DataBind();
        }

        protected void imgExcelDescarga1_Click(object sender, EventArgs e)
        {
            String lstrNameReporte = "";
            String lstrFechaIni = "";
            Int32 lintTurno = 1;
            lstrFechaIni = Convert.ToDateTime(datepicker11.Value).ToString("yyyyMMdd");
            lintTurno = Convert.ToInt32(ddlTurno.Value);
            lstrNameReporte = "ReporteCaja_" + lstrFechaIni + "_" + lintTurno.ToString() + ".xls";
            GridView2.DataSource = (DataTable)Session["gvCaja"];
            GridView2.DataBind();
            buscarReportexFecha(lstrNameReporte);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = (DataTable)Session["gvCaja"];
            GridView1.DataBind();
        }

        
    }
}