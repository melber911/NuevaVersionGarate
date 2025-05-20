using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Session["Usuario"] == null)
                {
                    return;
                }
                if (!IsPostBack)
                {

                    navbarDropdownMenuLink.InnerHtml = "<i class='fa fa-user-circle' aria-hidden='true'></i> " + Session["nombresApellidos"];
                    local.InnerHtml = "<i class='fa fa-map-marker mr-2' aria-hidden='true'></i> " + Session["sucursal"];
                    if (Session["Perfil"].ToString().Equals("Mesero"))
                    {
                        lnkGestion.Visible = false;
                        lnkCaja.Visible = false;
                        lnkReportes.Visible = false;
                        lnkMantenimiento.Visible = false;
                        lnkAdministracion.Visible = false;
                        lnkSeg.Visible = false;
                    }

                    if (Session["Perfil"].ToString().Equals("Cajero"))
                    {
                        lnkAdministracion.Visible = false;
                        lnkReportes.Visible = false;
                        lnkSeg.Visible = false;
                        lnkSubMantSucursal.Visible= false;
                        lnkSubMantMesas.Visible = false;
                        lnkistadoMesasAnular.Visible = false;
                    }
                    if (Session["Perfil"].ToString().Equals("Administrators"))
                    {
                        lnkSubMantSucursal.Visible = false;
                    }
                    if (Session["Perfil"].ToString().Equals("Master"))
                    {
                        configSUNAT.Visible = true;
                        config.Visible = true;
                    }
                }
                else
                {
                    string parameter = Request["__EVENTTARGET"] == null ? "" : Request["__EVENTTARGET"];
                    if (parameter.Equals("cerrarSesion"))
                    {
                        Session["Usuario"] = null;
                        Session["ModuloDesktop"] = null;
                        if (Session["Perfil"].ToString() == "Cajero" || Session["Perfil"].ToString() == "Mesero")
                        {
                            Session["Perfil"] = null;
                            Response.Redirect("frmMeseroIndex");
                        }
                        else
                        {
                            Session["Perfil"] = null;
                            Response.Redirect("index");
                        }
                    }
                }
            }
    }
}