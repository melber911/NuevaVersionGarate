using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class MantSalonMesas : System.Web.UI.Page
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
                cargarMesas();
            }
         }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                clsSucursal lobjSucursal = new clsSucursal();
                int nroOrden = int.Parse(txtorden.Value);
                int nroMesas = int.Parse(txtnromesas.Value);
                string descripcion = txtDescripcion.Value;
                var result = lobjSucursal.registrarMesas(nroOrden, descripcion, nroMesas, (int)Session["Idsucursal"]);
                if (result.Rows[0]["CodigoRespuesta"].ToString().Equals("200"))
                {
                    cargarMesas();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                       "$('#mymodal').modal('hide');" +
                       "toastr.success('Se realizó el registro con éxito', 'Bien');",
                       true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                      "toastr.error('"+ex.Message+"', 'Error');",
                      true);
            }
            

        }
        void cargarMesas()
        {
            clsSucursal lobjSucursal = new clsSucursal();
            DataTable ldtResponse = lobjSucursal.obtenerMesas();

            var filteredRows = ldtResponse.AsEnumerable()
                .Where(myrow => myrow.Field<int>("id_sucursal") == (int)Session["Idsucursal"]);

            if (filteredRows.Any()) // Verifica si hay filas
            {
                Session["gvMesas"] = filteredRows.CopyToDataTable();
                gvMesas.DataSource = (DataTable)Session["gvMesas"];
            }
            else
            {
                Session["gvMesas"] = null;
                gvMesas.DataSource = null; // O maneja el caso de DataSource vacío
            }

            gvMesas.DataBind();
        }

        protected void gvMesas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvMesas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {
                string id = e.CommandArgument.ToString();
                DataTable ldtResponse = (DataTable)Session["gvMesas"];
                var result = ldtResponse.AsEnumerable().
                    Where(myrow => myrow.Field<int>("id").Equals(int.Parse(id))).
                    AsDataView();
                txtDescripcionE.Value = result[0].Row["nombre"].ToString();
                txtnromesasE.Value = result[0].Row["nroMesas"].ToString();
                txtordenE.Value = result[0].Row["nroOrden"].ToString();
                BtnActualizar.CommandArgument=id;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal2').modal('show');",
                    true);
            }
            if (e.CommandName == "eliminar")
            {
                string id = e.CommandArgument.ToString();
                clsSucursal lobjSucursal = new clsSucursal();
                var result = lobjSucursal.eliminarMesas(int.Parse(id));
                
                if (result.Rows[0]["CodigoRespuesta"].ToString().Equals("200"))
                {
                    cargarMesas();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                       "toastr.success('Se elimino el registro', 'Bien');",
                       true);
                }
           }
        }

        protected void gvMesas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            
            try
            {
                LinkButton button = sender as LinkButton;
                string id = string.Empty;
                if (button != null)
                {

                    id = button.CommandArgument;

                }
                int nroOrden = int.Parse(txtordenE.Value);
                int nroMesas = int.Parse(txtnromesasE.Value);
                string descripcion = txtDescripcionE.Value;
                clsSucursal lobjSucursal = new clsSucursal();
                var result = lobjSucursal.actualizarMesas(nroOrden, descripcion, nroMesas, int.Parse(id));
                if (result.Rows[0]["CodigoRespuesta"].ToString().Equals("200"))
                {
                    cargarMesas();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                       "$('#mymodal2').modal('hide');" +
                       "toastr.success('Se realizó la actualizacion con éxito', 'Bien');",
                       true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                      "toastr.error('" + ex.Message + "', 'Error');",
                      true);
            }
        }
    }
}