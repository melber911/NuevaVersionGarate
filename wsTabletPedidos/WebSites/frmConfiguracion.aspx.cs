using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSites
{
    public partial class frmConfiguracion : System.Web.UI.Page
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
                CargarLogoActual();
            }
        }
        private void CargarLogoActual()
        {
            try
            {
                clsSucursal lobjProducto = new clsSucursal();
                var obj = lobjProducto.obtenerEmpresa();
                byte[] imageData = (byte[]) obj.Rows[0]["logo"];

                    if (imageData != null)
                    {
                        string base64String = Convert.ToBase64String(imageData);
                        imgLogoPreview.ImageUrl = "data:image/png;base64," + base64String;
                        imgLogoModal.ImageUrl = "data:image/png;base64," + base64String;
                        imgLogoPreview.Visible = true;
                        btnVerLogo.Visible = true;
                    }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar el logo: " + ex.Message, false);
            }
        }
        protected void btnSubirLogo_Click(object sender, EventArgs e)
        {
            if (fuLogo.HasFile)
            {
                try
                {
                    // Validar que sea una imagen
                    if (!fuLogo.PostedFile.ContentType.StartsWith("image/"))
                    {
                        MostrarMensaje("Por favor, seleccione un archivo de imagen válido (JPG/PNG)", false);
                        return;
                    }

                    // Validar tamaño (ejemplo: máximo 2MB)
                    if (fuLogo.PostedFile.ContentLength > 2097152)
                    {
                        MostrarMensaje("El tamaño de la imagen no debe exceder los 2MB", false);
                        return;
                    }

                    // Convertir a bytes
                    byte[] imageData;
                    using (BinaryReader br = new BinaryReader(fuLogo.PostedFile.InputStream))
                    {
                        imageData = br.ReadBytes(fuLogo.PostedFile.ContentLength);
                    }
                    clsSucursal lobjProducto = new clsSucursal();
                    var objList = lobjProducto.obtenerEmpresa();
                    if (objList.Rows.Count>0)
                    {
                        var obj = lobjProducto.actualizarLogo(imageData);
                    }
                    else
                    {
                        lobjProducto.registrarConfigSunat("", "", "", "",
                "", "", "", "", "",
                "");
                        var obj = lobjProducto.actualizarLogo(imageData);
                    }
                    


                    // Actualizar vista previa
                    string base64String = Convert.ToBase64String(imageData);
                    imgLogoPreview.ImageUrl = "data:image/png;base64," + base64String;
                    imgLogoModal.ImageUrl = "data:image/png;base64," + base64String;
                    imgLogoPreview.Visible = true;
                    btnVerLogo.Visible = true;

                    MostrarMensaje("Logo actualizado correctamente", true);
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al actualizar el logo: " + ex.Message, false);
                }
            }
            else
            {
                MostrarMensaje("Por favor, seleccione un archivo de imagen", false);
            }
        }
        private void MostrarMensaje(string mensaje, bool esExito)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true;
            lblMensaje.CssClass = esExito ? "alert alert-success" : "alert alert-danger";
        }
    }
}