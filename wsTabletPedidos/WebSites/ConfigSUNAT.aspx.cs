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
    public partial class ConfigSUNAT : System.Web.UI.Page
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
                clsSucursal lobjProducto = new clsSucursal();
                DesactivarCampos();
                var obj = lobjProducto.obtenerEmpresa();
                if (obj.Rows.Count > 0)
                {
                    foreach (DataRow row in obj.Rows)
                    {
                        txtRazonSocial.Value = row["RazonSocial"].ToString();
                        txtNumeroDocumento.Value = row["RUC"].ToString();
                        txtDireccion.Value = row["Direccion"].ToString();
                        txtDepartamento.Value = row["Departamento"].ToString();
                        txtProvincia.Value = row["Provincia"].ToString();
                        txtDistrito.Value = row["Distrito"].ToString();
                        txtUsuario.Value = row["CuentaRUC"].ToString();
                        txtContrasena.Value = row["CuentaPass"].ToString();
                        txtCertificadoContraseña.Value = row["CertPass"].ToString();
                        txtRutaCertificado.Value = row["CertRuta"].ToString();
                    }
                }
                
            }
        }
        private void DesactivarCampos()
        {
            txtRazonSocial.Disabled = true;
            txtNumeroDocumento.Disabled = true;
            txtDireccion.Disabled = true;
            txtDepartamento.Disabled = true;
            txtProvincia.Disabled = true;
            txtDistrito.Disabled = true;
            txtUsuario.Disabled = true;
            txtContrasena.Disabled = true;
            txtCertificadoContraseña.Disabled = true;
            txtRutaCertificado.Disabled = true;
            btncancelar.Style.Value = "display:none;border-radius: 15px;";
            btnguardar.Style.Value = "display:none;border-radius: 15px;";
            btnActualizar.Style.Value = "border-radius: 15px;";
        }
        private void ActivarCampos()
        {
            txtRazonSocial.Disabled = false;
            txtNumeroDocumento.Disabled = false;
            txtDireccion.Disabled = false;
            txtDepartamento.Disabled = false;
            txtProvincia.Disabled = false;
            txtDistrito.Disabled = false;
            txtUsuario.Disabled = false;
            txtContrasena.Disabled = false;
            txtCertificadoContraseña.Disabled = false;
            txtRutaCertificado.Disabled = false;
            btncancelar.Style.Value = "border-radius: 15px;";
            btnguardar.Style.Value = "border-radius: 15px;";
            btnActualizar.Style.Value = "display:none;border-radius: 15px;";
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActivarCampos();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            clsSucursal lobjProducto = new clsSucursal();
            if (lobjProducto.obtenerEmpresa().Rows.Count>0)
            {
                lobjProducto.actualizarConfigSunat(txtNumeroDocumento.Value, txtRazonSocial.Value, txtDireccion.Value, txtDepartamento.Value,
                txtProvincia.Value, txtDistrito.Value, txtUsuario.Value, txtContrasena.Value, txtCertificadoContraseña.Value,
                txtRutaCertificado.Value);
            }
            else
            {
                lobjProducto.registrarConfigSunat(txtNumeroDocumento.Value, txtRazonSocial.Value, txtDireccion.Value, txtDepartamento.Value,
                txtProvincia.Value, txtDistrito.Value, txtUsuario.Value, txtContrasena.Value, txtCertificadoContraseña.Value,
                txtRutaCertificado.Value);
            }
            
            DesactivarCampos();
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            DesactivarCampos();
        }
    }
}