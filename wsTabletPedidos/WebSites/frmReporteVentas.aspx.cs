using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class frmReporteVentas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
        {
            WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
            return;
        }
        if (!IsPostBack) {
            
            Session["gvVentasTotales"] = new DataTable();
            Bgen.Visible = true;
            Breg.Visible = false;
            Bdes.Visible = false;
            GridView1.DataSource = (DataTable)Session["gvVentasTotales"];
            GridView1.DataBind();
        }
    }

    void buscarReportexFecha(String pstrNameReporte) {
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
        if (datepicker.Value.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Se requiere ingresar fecha de inicio','Fecha de inicio');", true);
            return;
        }
        if (datepicker2.Value.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Se requiere ingresar fecha fin','Fecha fin');", true);
            return;
        }
        lstrFechaIni = Convert.ToDateTime(datepicker.Value).ToString("yyyyMMdd");
        lstrFechaFin = Convert.ToDateTime(datepicker2.Value).ToString("yyyyMMdd");

        ldtResponse = lobjProducto.obtenerReportedeVentas(lstrFechaIni, lstrFechaFin, (int)HttpContext.Current.Session["Idsucursal"]);
        Session["gvVentasTotales"] = ldtResponse;
        if (ldtResponse.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('No hay datos con los parámetros seleccionados','info');", true);
            return;
        }

        GridView1.DataSource = ldtResponse;
        GridView1.DataBind();

        
        Bgen.Visible = false;
        datepicker.Disabled = true;
        datepicker2.Disabled = true;
        Breg.Visible = true;
        Bdes.Visible = true;
        //buscarReportexFecha(lstrNameReporte);
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Bgen.Visible = true;
        Breg.Visible = false;
        Bdes.Visible = false;
        datepicker.Disabled = false;
        datepicker.Value = "";
        datepicker2.Disabled = false;
        datepicker2.Value = "";
        GridView1.DataSource = new DataTable();
        GridView1.DataBind();
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
        GridView1.DataSource = (DataTable)Session["gvVentasTotales"];
        GridView1.DataBind();
    }

    protected void imgExcelDescarga1_Click1(object sender, EventArgs e)
    {
        String lstrNameReporte = "";
        String lstrFechaIni = "";
        String lstrFechaFin = "";
        lstrFechaIni = Convert.ToDateTime(datepicker.Value).ToString("yyyyMMdd");
        lstrFechaFin = Convert.ToDateTime(datepicker2.Value).ToString("yyyyMMdd");
        lstrNameReporte = "ReporteVentasTotales_" + lstrFechaIni + "_" + lstrFechaFin + ".xls";
        GridView2.DataSource = (DataTable)Session["gvVentasTotales"];
        GridView2.DataBind();
        buscarReportexFecha(lstrNameReporte);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Encuentra el índice de la columna "Medio Pago Detalle"
            int columnIndex = GetColumnIndexByHeaderText("Medio Pago Detalle", GridView1);

            if (columnIndex >= 0)
            {
                string cellText = e.Row.Cells[columnIndex].Text;

                // Verifica si la celda contiene datos
                if (!string.IsNullOrEmpty(cellText) && cellText != "&nbsp;")
                {
                    // Divide los datos en base al separador "|"
                    string[] paymentDetails = cellText.Split('|');

                    // Crea un HTML para mostrar como párrafos
                    string transformedData = string.Join("\n", paymentDetails.Select(detail =>  detail));

                    // Asigna el contenido transformado a la celda
                    e.Row.Cells[columnIndex].Text = transformedData;
                }
            }
        }
    }
    private int GetColumnIndexByHeaderText(string headerText, GridView gridView)
    {
        for (int i = 0; i < gridView.Columns.Count; i++)
        {
            if (gridView.Columns[i].HeaderText == headerText)
            {
                return i;
            }
        }
        return -1; // No encontrado
    }
}