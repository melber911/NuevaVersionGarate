using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;
using Aspose.Pdf.Facades;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            try {
                if (!string.IsNullOrEmpty(Request.QueryString["vchUsuario"]))
                {
                    Session["Usuario"] = Request.QueryString["vchUsuario"].ToString();
                    Session["ModuloDesktop"] = Request.QueryString["vchModulo"].ToString();
                    Response.Redirect("frmMainMenu_2");
                }
                else {
                    txtUsuario.Value = "";
                    txtPass.Value = "";
                    cargarSucursal();
                }
            }
            catch (Exception ex) {
                txtUsuario.Value = "";
                txtPass.Value = "";
                cargarSucursal();
            }
        }
    }
    void cargarSucursal()
    {
        clsSucursal lobjSucursal = new clsSucursal();
        DataTable ldtResponse;
        var sucursal = lobjSucursal.obtenerSucursal().AsEnumerable();
        var sucursalFiltrada = sucursal.Where(row => row.Field<string>("estado") == "1");

        if (sucursalFiltrada.Any())
            ldtResponse = sucursalFiltrada.CopyToDataTable();
        else
            ldtResponse = new DataTable();

        if (!ldtResponse.Columns.Contains("nombreLocal"))
            ldtResponse.Columns.Add("nombreLocal", typeof(string));

        if (!ldtResponse.Columns.Contains("id"))
            ldtResponse.Columns.Add("id", typeof(string));

        Ddlsede.DataTextField = "nombreLocal";
        Ddlsede.DataValueField = "id";
        DataRow workRow = ldtResponse.NewRow();
        workRow["id"] = -1;
        workRow["nombreLocal"] = "--seleccione--";
        ldtResponse.Rows.Add(workRow);
        DataView dvOptions = new DataView(ldtResponse);
        dvOptions.Sort = "id ASC";
        Ddlsede.DataSource = dvOptions;
        Ddlsede.DataBind();
    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        validarLogin(txtUsuario.Value, txtPass.Value, int.Parse( Ddlsede.SelectedValue));
    }

    void validarLogin(String Usuario,
                      String Pass, int sucursal)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;

        dtResponse = lobjProducto.verificarLogin(Usuario, Pass, sucursal);

        if (dtResponse.Rows.Count == 0)
        {
            txtUsuario.Value = "";
            txtPass.Value = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "swal('Usuario y/o Password Invalido ')",
                    true);
        }
        else {
            Session["Usuario"] = dtResponse.Rows[0]["Uname"];
            Session["empID"] = dtResponse.Rows[0]["empID"];
            Session["Perfil"] = dtResponse.Rows[0]["privileges"];
            Session["sucursal"] = dtResponse.Rows[0]["sucursal"];
            Session["nombresApellidos"] = dtResponse.Rows[0]["nombresApellidos"];
            Session["Idsucursal"] = dtResponse.Rows[0]["Idsucursal"];
            HttpCookie privilegesCookie = new HttpCookie("privileges");
            privilegesCookie.Value = dtResponse.Rows[0]["privileges"]?.ToString() ?? "";
            privilegesCookie.Expires = DateTime.Now.AddHours(2);
            privilegesCookie.Path = "/";
            Response.Cookies.Add(privilegesCookie);
            Response.Redirect("Home");
        }
    }

    protected void Ddlsede_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtUsuario.Value = "";
        txtPass.Value = "";
        if (!Ddlsede.SelectedValue.Equals("-1"))
        {
            divBtnLogin.Style.Value = "";
            divPass.Style.Value = "";
            divUser.Style.Value = "";
        }
        else
        {
            divBtnLogin.Style.Value = "display:none;";
            divPass.Style.Value = "display:none;";
            divUser.Style.Value = "display:none;";
        }
        
    }
}