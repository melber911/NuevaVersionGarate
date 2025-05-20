using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Common;

namespace WebSites
{

    public partial class frmAgregarUsuarios : System.Web.UI.Page
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
                inicio();
            }


        }
        public void inicio()
        {
            llenarListaUsuarios();
            llenarListaRoles();
            limpiarCamposAddUser();
        }
        public void limpiarCamposAddUser()
        {
            txtapellidos.Value = "";
            txtnombres.Value = "";
            txtpass.Value = "";
            txtuser.Value = "";
            ChkEstado.Checked = true;
            DdlRol.SelectedValue = "-1";
        }
        public void llenarListaUsuarios()
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;
            var usuarios = lobjProducto.obtenerUsuarios()?.AsEnumerable()?.Where(row => row.Field<int>("id_sucursal") == (int)Session["Idsucursal"]);

            if (usuarios != null && usuarios.Any())
            {
                ldtResponse = usuarios.CopyToDataTable();
            }
            else
            {
                // Manejar el caso donde no hay filas
                ldtResponse = new DataTable(); // O maneja el caso según tu lógica
            }
            Session["gvUsuarios"] = ldtResponse;
            gvUsuarios.DataSource = (DataTable)Session["gvUsuarios"];
            gvUsuarios.DataBind();
        }
        public bool ValidarUsuarioExistente(string user)
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;
            var result = lobjProducto.obtenerUsuarios().
                AsEnumerable().
                Where(x => x.Field<string>("username").Equals(user)).
                Where(x => x.Field<int>("id_sucursal") == (int)Session["Idsucursal"]).
                AsDataView();
            if (result.Count > 0) return false;
            else return true;

        }
        public bool ValidarPassExistente(string pass)
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;
            var result = lobjProducto.obtenerUsuarios().
                AsEnumerable().
                Where(x => x.Field<string>("Pass").Equals(pass)).
                AsDataView();
            if (result.Count > 0) return false;
            else return true;

        }
        public void llenarListaRoles()
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;
            DataRow Row1;
            ldtResponse = lobjProducto.obtenerRoles();

            Row1 = ldtResponse.NewRow();
            Row1["id"] = -1;
            Row1["nombre"] = "seleccione..";
            ldtResponse.Rows.Add(Row1);

            DdlRol.DataSource = ldtResponse.AsEnumerable().OrderBy(u => u["id"]).AsDataView();
            DdlRol.DataValueField = "id";
            DdlRol.DataTextField = "nombre";
            DdlRol.DataBind();

            DdlRolE.DataSource = ldtResponse.AsEnumerable().OrderBy(u => u["id"]).AsDataView();
            DdlRolE.DataValueField = "id";
            DdlRolE.DataTextField = "nombre";
            DdlRolE.DataBind();
        }
        

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            gvUsuarios.DataSource = (DataTable)Session["gvUsuarios"];
            gvUsuarios.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string find = NombreProductoFiltroID.Text;
            DataTable myDT = (DataTable)Session["gvUsuarios"];
            var result = myDT
                .AsEnumerable()
                .Where(myrow => (myrow.Field<string>("username") + " " +
                myrow.Field<string>("nombres") + " " +
                myrow.Field<string>("apellidos")).ToUpper()
                .Contains(find.ToUpper()))
                .AsDataView();

            gvUsuarios.DataSource = result;
            gvUsuarios.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtnombres.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.info('Complete el campo', 'Nombres');",
                    true);
                return;
            }
            if (txtapellidos.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                     "toastr.info('Complete el campo', 'Apellidos');",
                     true);
                return;
            }
            if (DdlRol.SelectedValue.Equals("-1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                     "toastr.info('Complete el campo', 'Rol');",
                     true);
                return;
            }
            if (txtuser.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                         "toastr.info('Complete el campo', 'Nombre de usuario');",
                         true);
                return;
            }
            if (txtpass.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                             "toastr.info('Complete el campo', 'Contraseña');",
                             true);
                return;
            }

            try
            {
                hplog.generarLog("INICIO - REGISTRAR USUARIO ");
                clsProducto lobjProducto = new clsProducto();
                DataTable ldtResponse;
                int idrol = int.Parse(DdlRol.SelectedValue);
                string estado = ChkEstado.Checked ? "1" : "0";
                //Comentado Melber
                //if (!ValidarUsuarioExistente(txtuser.Value))
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                //    "toastr.error('El usuario ya existe', 'Error');",
                //    true);
                //    return;
                //}
                if (!ValidarPassExistente(txtpass.Value))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.error('La clave ya existe', 'Error');",
                    true);
                    return;
                }

                ldtResponse = lobjProducto.registrarUsuario(txtnombres.Value, txtapellidos.Value, idrol, estado, txtuser.Value, txtpass.Value, (int)Session["Idsucursal"]);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal2').modal('hide');" +
                    "toastr.success('Se realizó el registro de usuario con éxito', 'Bien');",
                    true);
                hplog.generarLog("FIN - REGISTRAR USUARIO ");
                inicio();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.error('Error del sistema', 'Error');",
                    true);
                hplog.generarLog("ERROR: " + ex.Message);
            }
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (txtnombresE.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.info('Complete el campo', 'Nombres');",
                    true);
                return;
            }
            if (txtapellidosE.Value.Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                        "toastr.info('Complete el campo', 'Apellidos');",
                        true);
                return;
            }
            if (DdlRolE.SelectedValue.Equals("-1"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                        "toastr.info('Complete el campo', 'Rol');",
                        true);
                return;
            }

            try
            {
                hplog.generarLog("INICIO - ACTUALIZAR USUARIO ");
                clsProducto lobjProducto = new clsProducto();
                DataTable ldtResponse;
                int idrol = int.Parse(DdlRolE.SelectedValue);
                string estado = ChkEstadoE.Checked ? "1" : "0";
                ldtResponse = lobjProducto.actualizarUsuarioPass("1", hfempidE.Value, txtnombresE.Value, txtapellidosE.Value, idrol, estado, txtpassE.Value);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('hide');" +
                    "toastr.success('Se realizó la modificacion del usuario con éxito', 'Bien');",
                    true);
                hplog.generarLog("FIN - ACTUALIZAR USUARIO ");
                inicio();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.error('Error del sistema', 'Error');",
                    true);
                hplog.generarLog("ERROR: " + ex.Message);
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {
                string id = e.CommandArgument.ToString();
                clsProducto lobjProducto = new clsProducto();
                DataTable ldtResponse = (DataTable)Session["gvUsuarios"];
                var result = ldtResponse.AsEnumerable().
                    Where(myrow => myrow.Field<string>("empid").Equals(id)).
                    AsDataView();
                hfempidE.Value = id;
                txtnombresE.Value = result[0].Row["nombres"].ToString();
                txtapellidosE.Value = result[0].Row["apellidos"].ToString();
                DdlRolE.SelectedValue = result[0].Row["idRol"].ToString().Equals("") ? "-1" : result[0].Row["idRol"].ToString();
                txtuserE.Value = result[0].Row["username"].ToString();
                ChkEstadoE.Checked = result[0].Row["estado"].ToString() == "1" ? true : false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('show');",
                    true);
            }
        }

        protected void btnCambPass_Click(object sender, EventArgs e)
        {
            try
            {
                hplog.generarLog("INICIO - CAMBIAR PASSWORD ");
                clsProducto lobjProducto = new clsProducto();
                DataTable ldtResponse;
                ldtResponse = lobjProducto.actualizarUsuarioPass("2", hfempidE.Value, "", "", 0, "", txtpassE.Value);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('hide');" +
                    "toastr.success('Se actualizo la nueva contraseña con éxito', 'Bien');",
                    true);
                hplog.generarLog("FIN - CAMBIAR PASSWORD ");
                inicio();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "toastr.error('Error del sistema', 'Error');",
                    true);
                hplog.generarLog("ERROR: " + ex.Message);
            }
        }
        protected void DdlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlRol.SelectedValue == "2" || DdlRol.SelectedValue == "3")
            {
                // Cambiar a 4 dígitos y solo números
                txtpass.MaxLength = 4;
                txtpass.Attributes["onkeypress"] = "return event.charCode >= 48 && event.charCode <= 57;"; // Solo números
            }
            else
            {
                // Permitir todo
                txtpass.MaxLength = 50; // Sin límite
                txtpass.Attributes["onkeypress"] = "return true;";
            }
        }
    }
}