using bussinessLayer;
using System;
using System.Data;
using System.Web;

namespace WebSites
{
    public partial class frmMeseroIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Evitar que el navegador cachee la página
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetValidUntilExpires(false);

            if (!IsPostBack)
            {
                try
                {
                    // Redirigir si ya hay sesión activa
                    if (Session["Usuario"] != null)
                    {
                        Response.Redirect("frmMainMenu_2");
                        return;
                    }

                    // Autologin por QueryString
                    if (!string.IsNullOrEmpty(Request.QueryString["vchUsuario"]))
                    {
                        Session["Usuario"] = Request.QueryString["vchUsuario"].ToString();
                        Session["ModuloDesktop"] = Request.QueryString["vchModulo"].ToString();
                        Response.Redirect("frmMainMenu_2");
                    }
                    else
                    {
                        txtCodigo.Text = "";
                        txtCodigoReal.Text = "";
                    }
                }
                catch (Exception)
                {
                    txtCodigo.Text = "";
                    txtCodigoReal.Text = "";
                }
            }
        }


        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string codigoIngresado = txtCodigoReal.Text.Trim();
            
            // Validar que tenga 4 caracteres
            if (codigoIngresado.Length == 4)
            {
                // Lógica para validar el código (simulada aquí)
                ValidarCodigo(codigoIngresado);
            }
            else
            {
                lblResultado.Text = "";
            }
        }

        void ValidarCodigo(string Pass)
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable dtResponse;
            dtResponse = lobjProducto.verificarLoginMesero(Pass);

            if (dtResponse.Rows.Count == 0)
            {
                txtCodigo.Text = "";
                txtCodigoReal.Text = "";
                lblResultado.CssClass = "alert alert-danger";
                lblResultado.Text = "😕 ¡Oops! Usuario no Existe...!";
            }
            else
            {
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
                txtCodigoReal.Text = "";
            }
        }
    }
}