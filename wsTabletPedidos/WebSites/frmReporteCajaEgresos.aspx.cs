using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class frmReporteCajaEgresos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime lstrFechaIni;
            DateTime lstrFechaFin;
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;
            if (datepicker11.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Se requiere ingresar fecha Inicio','Fecha Inicio');", true);
                return;
            }
            if (datepicker12.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Se requiere ingresar fecha Fin','Fecha Fin');", true);
                return;
            }
            lstrFechaIni = Convert.ToDateTime(datepicker11.Value);
            lstrFechaFin = Convert.ToDateTime(datepicker12.Value);

            ldtResponse = lobjProducto.obtenerReporteCajaEgresos(lstrFechaIni, lstrFechaFin, (int)HttpContext.Current.Session["Idsucursal"]);
            Session["gvCajaEgresos"] = ldtResponse;
            if (ldtResponse.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('No hay datos con los parámetros seleccionados','info');", true);
                return;
            }

            GridView1.DataSource = ldtResponse;
            GridView1.DataBind();

            Bgen.Visible = false;
            datepicker11.Disabled = true;
            datepicker12.Disabled = true;
            Breg.Visible = true;
            Bdes.Visible = true;
        }
        protected string GetTipoDescripcion(object tipoId)
        {
            if (tipoId == null)
                return "Desconocido";

            switch (tipoId.ToString())
            {
                case "1":
                    return "Efectivo";
                case "2":
                    return "Tarjeta";
                case "3":
                    return "Deposito/Yape";
                default:
                    return "Otro";
            }
        }
        protected string GetMotivoDescripcion(object motivoId)
        {
            if (motivoId == null)
                return "Desconocido";

            switch (motivoId.ToString())
            {
                case "1":
                    return "Invitación";
                case "2":
                    return "Gasto Motorizado";
                case "3":
                    return "Comisión Tarjeta";
                case "4":
                    return "Otros Gastos";
                default:
                    return "No especificado";
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Bgen.Visible = true;
            Breg.Visible = false;
            Bdes.Visible = false;
            datepicker11.Disabled = false;
            datepicker11.Value = "";
            datepicker12.Disabled = false;
            datepicker12.Value = "";
            GridView1.DataSource = new DataTable();
            GridView1.DataBind();
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
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("Content-Disposition", "attachment;filename=" + pstrNameReporte);
            response.Write("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }
        protected void imgExcelDescarga1_Click(object sender, EventArgs e)
        {
            String lstrNameReporte = "";
            String lstrFechaIni = "";
            String lstrFechaFin = "";
            Int32 lintTurno = 1;
            lstrFechaIni = Convert.ToDateTime(datepicker11.Value).ToString("yyyyMMdd");
            lstrFechaFin = Convert.ToDateTime(datepicker12.Value).ToString("yyyyMMdd");
            lstrNameReporte = "ReporteCajaEgresos_" + lstrFechaIni + "_" + lstrFechaFin + ".xls";
            GridView2.DataSource = (DataTable)Session["gvCajaEgresos"];
            GridView2.DataBind();
            buscarReportexFecha(lstrNameReporte);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = (DataTable)Session["gvCajaEgresos"];
            GridView1.DataBind();
        }
    }
}