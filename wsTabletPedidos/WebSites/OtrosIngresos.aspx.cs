using bussinessLayer;
using Spire.Pdf.Annotations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class OtrosIngresos : System.Web.UI.Page
    {
        public  string titulo = ""; 
        private readonly List<KeyValuePair<string, string>> tiposDeIngreso = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("1", "Efectivo"),
            new KeyValuePair<string, string>("2", "Tarjeta"),
            new KeyValuePair<string, string>("3", "Depósito/Yape")
        };
        private readonly List<KeyValuePair<string, string>> motivo = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("1", "Invitacion"),
            new KeyValuePair<string, string>("2", "Gasto Motorizado"),
            new KeyValuePair<string, string>("3", "Comision Tarjeta"),
            new KeyValuePair<string, string>("4", "Otros Gastos")
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
                return;
            }
            if (!IsPostBack)
            {
                CargarTiposDeIngreso();
                obtenerIngresos();
                obtenerEgresos();
            }
            
        }
        private void CargarTiposDeIngreso()
        {
            // Asignar los datos de la colección al DropDownList
            ddlTipoIngreso.DataSource = tiposDeIngreso;
            ddlTipoIngreso.DataTextField = "Value";
            ddlTipoIngreso.DataValueField = "Key";
            ddlTipoIngreso.DataBind();
            ddlTipoIngreso2.DataSource = tiposDeIngreso;
            ddlTipoIngreso2.DataTextField = "Value";
            ddlTipoIngreso2.DataValueField = "Key";
            ddlTipoIngreso2.DataBind();

            ddlmotivo.DataSource = motivo;
            ddlmotivo.DataTextField = "Value";
            ddlmotivo.DataValueField = "Key";
            ddlmotivo.DataBind();
            ddlmotivo2.DataSource = motivo;
            ddlmotivo2.DataTextField = "Value";
            ddlmotivo2.DataValueField = "Key";
            ddlmotivo2.DataBind();
        }
        public void obtenerIngresos()
        {
            clsSucursal cls = new clsSucursal();
            DataTable ldtResponse;
            int caja = Convert.ToInt32(Request.QueryString["vchCajaId"].ToString());
            ldtResponse = cls.obtenerOtrosIngresos(caja);

            Session["gvOtrosIngresos"] = ldtResponse;
            gvOtrosIngresos.DataSource = (DataTable)Session["gvOtrosIngresos"];
            gvOtrosIngresos.DataBind();
            ActualizarTotalIngresos();
        }
        public void obtenerEgresos()
        {
            clsSucursal cls = new clsSucursal();
            DataTable ldtResponse;
            int caja = Convert.ToInt32(Request.QueryString["vchCajaId"].ToString());
            ldtResponse = cls.obtenerOtrosEgresos(caja);

            Session["gvOtrosEgresos"] = ldtResponse;
            gvOtrosEgresos.DataSource = (DataTable)Session["gvOtrosEgresos"];
            gvOtrosEgresos.DataBind();
            ActualizarTotalEgresos();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }


        protected void gvOtrosIngresos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOtrosIngresos.PageIndex = e.NewPageIndex;
            gvOtrosIngresos.DataSource = (DataTable)Session["gvOtrosIngresos"];
            gvOtrosIngresos.DataBind();
        }
        protected void ActualizarTotalIngresos()
        {
            decimal total = 0;

            // Recorre todas las filas del GridView
            foreach (GridViewRow row in gvOtrosIngresos.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    // Encuentra la celda correspondiente al Monto
                    string montoText = row.Cells[1].Text;

                    // Intenta convertir el texto a decimal
                    if (decimal.TryParse(montoText, out decimal monto))
                    {
                        total += monto;
                    }
                }
            }

            // Actualiza el Label con el total
            lblTotalIngresos.Text = total.ToString("N2");
        }
        protected void ActualizarTotalEgresos()
        {
            decimal total = 0;

            // Recorre todas las filas del GridView
            foreach (GridViewRow row in gvOtrosEgresos.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    // Encuentra la celda correspondiente al Monto
                    string montoText = row.Cells[1].Text;

                    // Intenta convertir el texto a decimal
                    if (decimal.TryParse(montoText, out decimal monto))
                    {
                        total += monto;
                    }
                }
            }

            // Actualiza el Label con el total
            lblegresos.Text = total.ToString("N2");
        }
        protected void gvOtrosIngresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "editar")
            {
                
                DataTable ldtResponse = (DataTable)Session["gvOtrosIngresos"];
                var result = ldtResponse.AsEnumerable().
                    Where(myrow => myrow.Field<int>("otrosIngresosID").Equals(int.Parse( id))).
                    AsDataView();
                hfempidE.Value = id;
                ddlTipoIngreso2.SelectedValue = result[0].Row["tipo"].ToString();
                txtprecioEdit.Value = result[0].Row["Precio"].ToString();
                txtObservacionEdit.Value = result[0].Row["Observacion"].ToString();
            }
            else if (e.CommandName == "eliminar") {
                clsSucursal cls = new clsSucursal();
                DataTable ldtResponse;
                ldtResponse = cls.eliminarOtrosIngresos(int.Parse(id));
                obtenerIngresos();
            }
        }

        protected void gvOtrosIngresos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Encuentra el valor de TipoIngreso en la fila
                var tipoCell = e.Row.Cells[0]; // Asegúrate de que la columna 0 sea "Tipo de Ingreso"
                string tipoValor = tipoCell.Text;

                // Busca el texto correspondiente en la lista tiposDeIngreso
                var tipoTexto = tiposDeIngreso.Find(t => t.Key == tipoValor).Value;

                if (!string.IsNullOrEmpty(tipoTexto))
                {
                    tipoCell.Text = tipoTexto;
                }
                else
                {
                    tipoCell.Text = "Desconocido"; // Si no se encuentra el valor
                }
            }
        }

        protected void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            clsSucursal cls = new clsSucursal();
            DataTable ldtResponse;
            int caja = Convert.ToInt32(Request.QueryString["vchCajaId"].ToString());
            if (hfValor.Value.Equals("1"))
            {
                ldtResponse = cls.agregarOtrosIngresos(caja, ddlTipoIngreso.SelectedValue, double.Parse(txtprecioAdd.Value), txtObservacionAdd.Value);
                obtenerIngresos();
            }
            else if (hfValor.Value.Equals("2"))
            {
                ldtResponse = cls.agregarOtrosEgresos(caja, ddlTipoIngreso.SelectedValue, double.Parse(txtprecioAdd.Value), ddlmotivo.SelectedValue,txtObservacionAdd.Value);
                obtenerEgresos();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
               "toastr.error('Error en el registro', 'Error');",
               true);
                return;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                   "$('#modalNuevoIngreso').modal('hide');" +
                   "toastr.success('Se realizó el registro correctamente', 'Bien');",
                   true);
        }

        protected void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            clsSucursal cls = new clsSucursal();
            DataTable ldtResponse;
            int caja = Convert.ToInt32(Request.QueryString["vchCajaId"].ToString());
            if (hfValor.Value.Equals("1"))
            {
                ldtResponse = cls.modificarOtrosIngresos(int.Parse(hfempidE.Value), caja, ddlTipoIngreso2.SelectedValue, double.Parse(txtprecioEdit.Value), txtObservacionEdit.Value);
                obtenerIngresos();
            }
            else if (hfValor.Value.Equals("2"))
            {
                ldtResponse = cls.modificarOtrosEgresos(int.Parse(hfempidE.Value), caja, ddlTipoIngreso2.SelectedValue, double.Parse(txtprecioEdit.Value),ddlmotivo2.SelectedValue, txtObservacionEdit.Value);
                obtenerEgresos();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
               "toastr.error('Error en la edicion', 'Error');",
               true);
                return;
            }
                
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
               "$('#modalEditarIngreso').modal('hide');" +
               "toastr.success('Se realizó la edicion correctamente', 'Bien');",
               true);
        }

        protected void gvOtrosEgresos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOtrosEgresos.PageIndex = e.NewPageIndex;
            gvOtrosEgresos.DataSource = (DataTable)Session["gvOtrosEgresos"];
            gvOtrosEgresos.DataBind();
        }

        protected void gvOtrosEgresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "editar")
            {
                DataTable ldtResponse = (DataTable)Session["gvOtrosEgresos"];
                var result = ldtResponse.AsEnumerable().
                    Where(myrow => myrow.Field<int>("otrosEgresosID").Equals(int.Parse(id))).
                    AsDataView();
                hfempidE.Value = id;
                ddlTipoIngreso2.SelectedValue = result[0].Row["tipo"].ToString();
                txtprecioEdit.Value = result[0].Row["Precio"].ToString();
                txtObservacionEdit.Value = result[0].Row["Observacion"].ToString();
                ddlmotivo2.SelectedValue = result[0].Row["motivo"].ToString();
            }
            else if (e.CommandName == "eliminar")
            {
                clsSucursal cls = new clsSucursal();
                DataTable ldtResponse;
                ldtResponse = cls.eliminarOtrosEgresos(int.Parse(id));
                obtenerEgresos();
            }
        }

        protected void gvOtrosEgresos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Encuentra el valor de TipoIngreso en la fila
                var tipoCell = e.Row.Cells[0];
                string tipoValor = tipoCell.Text;

                // Busca el texto correspondiente en la lista tiposDeIngreso
                var tipoTexto = tiposDeIngreso.Find(t => t.Key == tipoValor).Value;

                if (!string.IsNullOrEmpty(tipoTexto))
                {
                    tipoCell.Text = tipoTexto;
                }
                else
                {
                    tipoCell.Text = "Desconocido"; // Si no se encuentra el valor
                }

                //Encuentra el valor de MOTIVO en la fila
                var motivoCell = e.Row.Cells[2];
                string motivoValor = motivoCell.Text;

                var motivoTexto = motivo.Find(t => t.Key == motivoValor).Value;

                if (!string.IsNullOrEmpty(motivoTexto))
                {
                    motivoCell.Text = motivoTexto;
                }
                else
                {
                    motivoCell.Text = "Desconocido"; // Si no se encuentra el valor
                }
            }
        }

        protected void btnEditarEgreso_Click(object sender, EventArgs e)
        {
            colMotivo2.Attributes.Add("style", "");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            colMotivo2.Attributes.Add("style", "display: none;");
        }

        protected void imgVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmListadoCajasAperturadas");
        }
    }
}