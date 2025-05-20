using Aspose.Pdf;
using bussinessLayer;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class frmMantSucursal : System.Web.UI.Page
    {
        HelperLog hplog = new HelperLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
                return;
            }
            if (!IsPostBack)
            {
                cargarTipoDocumentoDT();
                cargarSucursal();
            }
        }
        void cargarSucursal()
        {
            clsSucursal lobjSucursal = new clsSucursal();
            DataTable ldtResponse = lobjSucursal.obtenerSucursal();
            
            Session["gvSucursales"] = ldtResponse;
            gvSucursales.DataSource = (DataTable) Session["gvSucursales"];
            gvSucursales.DataBind();
        }
        void cargarTipoDocumentoDT()
        {
            // Crear el DataTable con columnas necesarias
            DataTable dt = new DataTable();
            dt.Columns.Add("TipoDocumento");
            dt.Columns.Add("serie");
            dt.Columns.Add("declara");
            // Agregar filas con datos predefinidos
            dt.Rows.Add("FAC", "F","Si"); 
            dt.Rows.Add("BOL", "B", "Si"); 
            dt.Rows.Add("BON", "N", "No"); 

            // Enlazar el DataTable al GridView
            GVDoc.DataSource = dt;
            GVDoc.DataBind();
        }
        protected void gvSucursales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSucursales.PageIndex = e.NewPageIndex;
            gvSucursales.DataSource = (DataTable)Session["gvSucursales"];
            gvSucursales.DataBind();
        }


        protected void gvSucursales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar") {
                string id = e.CommandArgument.ToString();
                DataTable ldtResponse = (DataTable)Session["gvSucursales"];
                var result = ldtResponse.AsEnumerable().
                    Where(myrow => myrow.Field<int>("id").Equals(int.Parse(id))).
                    AsDataView();
                hfidE.Value = id;
                txtEdireccion.Value = result[0].Row["direccion"].ToString();
                txtEnombre.Value = result[0].Row["nombreLocal"].ToString();
                ChkEestado.Checked = result[0].Row["estado"].ToString() == "1" ? true : false; ;
                clsSucursal lobjSucursal = new clsSucursal();
                var result2 = lobjSucursal.obtenerComprobanteSucursal(int.Parse(id));
                GVEDIT.DataSource = result2;
                GVEDIT.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal2').modal('show');",
                    true);
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            clsSucursal lobjSucursal = new clsSucursal();
            string estado = ChkEstado.Checked ? "1" : "0";
            if (txtnombre.Value.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.info('Complete el campo', 'Nombre Local');",
                    true);
                return;
            }
            if (txtdireccion.Value.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                     "toastr.info('Complete el campo', 'Direccion');",
                     true);
                return;
            }
            foreach (GridViewRow row in GVDoc.Rows)
            {
                string seriev = (row.FindControl("lblserie") as HtmlGenericControl).InnerText.Trim() + (row.FindControl("txtSerie") as HtmlInputText).Value;
                if (lobjSucursal.obtenerComprobanteVal(seriev).Rows[0]["vchcodigoRespuesta"].ToString().Equals("100")) {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                     "toastr.error('El comprobante: "+ seriev + ", ya existe.', 'Comprobante');",
                     true);
                    return;
                }
            }
                try
            {
                
                hplog.generarLog("INICIO - REGISTRAR SUCURSAL");
                
                DataTable ldtResponse = lobjSucursal.registrarSucursal(txtnombre.Value,txtdireccion.Value, estado);
                if (ldtResponse.Rows.Count > 0)
                {
                    // Obtiene el valor de la columna vchcodigoRespuesta que contiene el NuevoID
                    int nuevoID = Convert.ToInt32(ldtResponse.Rows[0]["vchcodigoRespuesta"]);
                    foreach (GridViewRow row in GVDoc.Rows)
                    {
                        // Obtener valores de los controles en cada fila del GridView
                        string tipoDoc = row.Cells[1].Text;
                        string serie = (row.FindControl("lblserie") as HtmlGenericControl).InnerText.Trim() + (row.FindControl("txtSerie") as HtmlInputText).Value;
                        int correlativo = int.Parse((row.FindControl("txtCorrelativo") as HtmlInputText).Value);

                        // Aquí llamas a la función para guardar los datos de cada fila, por ejemplo:
                        lobjSucursal.registrarTipoDoc(tipoDoc, serie, correlativo, nuevoID);
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                        "$('#mymodal').modal('hide');" +
                        "toastr.success('Se realizó el registro con éxito', 'Bien');",
                        true);
                    cargarSucursal();
                }
                    
                hplog.generarLog("FIN - REGISTRAR SUCURSAL");
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.error('Error del sistema', 'Error');",
                    true);
                hplog.generarLog("ERROR: " + ex.Message);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string estado = ChkEestado.Checked ? "1" : "0";
            if (txtEnombre.Value.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.info('Complete el campo', 'Nombre Local');",
                    true);
                return;
            }
            if (txtEdireccion.Value.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                     "toastr.info('Complete el campo', 'Direccion');",
                     true);
                return;
            }
            try
            {
                hplog.generarLog("INICIO - ACTUALIZAR SUCURSAL");
                clsSucursal lobjSucursal = new clsSucursal();
                DataTable ldtResponse = lobjSucursal.actualizarSucursal(int.Parse(hfidE.Value), txtEnombre.Value, txtEdireccion.Value, estado);
                foreach (GridViewRow row in GVEDIT.Rows)
                {
                    // Obtener valores de los controles en cada fila del GridView
                    string tipoDoc = row.Cells[1].Text;
                    string serie =  (row.FindControl("txtSerie1") as HtmlInputText).Value;
                    int correlativo = int.Parse((row.FindControl("txtCorrelativo1") as HtmlInputText).Value);

                    // Aquí llamas a la función para guardar los datos de cada fila, por ejemplo:
                    lobjSucursal.actualizarTipoDoc(tipoDoc, serie, correlativo, int.Parse(hfidE.Value));
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal2').modal('hide');" +
                    "toastr.success('Se realizó el cambio con éxito', 'Bien');",
                    true);
                cargarSucursal();
                hplog.generarLog("FIN - ACTUALIZAR SUCURSAL");
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.error('Error del sistema', 'Error');",
                    true);
                hplog.generarLog("ERROR: " + ex.Message);
            }
        }
    }
}