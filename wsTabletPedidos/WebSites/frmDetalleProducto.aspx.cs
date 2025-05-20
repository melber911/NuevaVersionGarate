using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmDetalleProducto : System.Web.UI.Page
{
    public static string Usuario = "";
    void cargarDatosProducto(Int32 pintProdID) {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        ldtResponse = lobjProducto.obtenerDatosProductoID(pintProdID);

        cargarCategorias();

        ddlCategoria.SelectedValue = ldtResponse.Rows[0]["vchCategoria"].ToString();

        cargarSCategorias(ddlCategoria.SelectedValue);

        ddlSCategoria.SelectedValue = ldtResponse.Rows[0]["vchSubCategoria"].ToString();

        txtDescripcion.Value = ldtResponse.Rows[0]["vchDescripcion"].ToString();

        txtPrecio.Value = ldtResponse.Rows[0]["vchPrecio"].ToString();

        txtStockProd.Value = ldtResponse.Rows[0]["vchStock"].ToString();

        if (ldtResponse.Rows[0]["vchEstado"].ToString().Equals("ACTIVO"))
        {
            ddlEstado.SelectedValue = "ACT";
        }
        else {
            ddlEstado.SelectedValue = "ANU";
        }

        if (ldtResponse.Rows[0]["vchTipo"].ToString().Equals("PARA LLEVAR"))
        {
            rdbListTipo2.Checked = true;
        }
        else {
            rdbListTipo1.Checked = true;
        }
        //Generar Tabla IngresoStock - INI
        string rows = "";
        DataTable IngresoStock;
        IngresoStock = lobjProducto.getIngresoStockByProducto(pintProdID, (int)Session["Idsucursal"]);
        foreach (DataRow row in IngresoStock.Rows)
        {
            DateTime fecha = DateTime.Parse(row[8].ToString());
            string dia = fecha.Day.ToString();
            string mes = fecha.Month.ToString();
            string anio = fecha.Year.ToString();

            if (int.Parse(dia) < 10)
            {
                dia = "0" + dia;
            }

            if (int.Parse(mes) < 10)
            {
                mes = "0" + mes;
            }

            rows += "<tr>";
            rows += "<th scope='row' hidden='hidden'>" + row[0].ToString() + "</th>";
            rows += "<th scope='row' hidden='hidden'>" + row[1].ToString() + "</th>";
            rows += "<th scope='row' hidden='hidden'>" + row[2].ToString() + "</th>";
            rows += "<th scope='row' hidden='hidden'>" + row[3].ToString() + "</th>";
            rows += "<th scope='row'>" + row[4].ToString() + "</th>";
            rows += "<td>" + row[5].ToString() + "</td>";
            rows += "<td  hidden='hidden'>" + row[6].ToString() + "</td>";
            rows += "<td>" + "<input id='txtCosto" + row[2].ToString() + "' disabled='true' type='text' value='" + row[7].ToString() + "'" + "</td>";
            rows += "<td>" + "<input id='fVencimientoProd" + row[2].ToString() + "' disabled='true' type='date' value='" + anio + '-' + mes + '-' + dia +"'" + "</td>";
            rows += "<td>" + "<input id='" + txtDescripcion.ClientID + row[2].ToString() + "' disabled='true' type='text'placeholder='Ingrese una descripción' </td>";
            rows += "<td>" + "<span id='editIngStock" + row[2].ToString() + "' onclick='EditarIngresoStock(" + row[2].ToString() + ")' class='fa fa-edit' style='font-size:30px; cursor: pointer;color:#28a745' title='Editar Producto'></span>";
            rows += "<div style='width: 100%;'>";
            rows += "<span id='saveEditIngStock" + row[2].ToString() + "' onclick='GuardarEdicion(" + row[2].ToString() + ")' class='fa fa-save' style='font-size:30px; width: 50%; float: left; cursor: pointer;color:blue;display:none' title='Guardar'></span>";
            rows += "<span id='cancelEditIngStock" + row[2].ToString() + "' onclick='CancelEdicion(" + row[2].ToString() + ")' class='fa fa-times-circle' style='font-size:30px; width: 50%; float: right;  cursor: pointer;color:red;display:none' title='Cancelar'></span>";
            rows += "</div>";
            rows += "</td>";
            rows += "</tr>";

        }
        bodyIngesoStock.InnerHtml = rows==""? "<tr><td colspan='11'>No existen Entradas para este producto</td></tr>": rows;
        //Generar Tabla IngresoStock - FIN

    }
    void cargarCategorias()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        ldtResponse = lobjProducto.obtenerCategorias("");

        ddlCategoria.DataTextField = "vchValor";
        ddlCategoria.DataValueField = "vchCodigo";
        ddlCategoria.DataSource = ldtResponse;
        ddlCategoria.DataBind();
    }

    void cargarSCategorias(String pstrCategoria)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        ldtResponse = lobjProducto.obtenerSCategorias(pstrCategoria);

        ddlSCategoria.DataTextField = "vchValor";
        ddlSCategoria.DataValueField = "vchCodigo";
        ddlSCategoria.DataSource = ldtResponse;
        ddlSCategoria.DataBind();
    }

    void guardarProducto() {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        if (ddlCategoria.SelectedValue.Equals("")) {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione una categoría.');", true);
            return;
        }

        if (ddlSCategoria.SelectedValue.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione una Sub-categoría.');", true);
            return;
        }

        if (txtDescripcion.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese el nombre del producto.');", true);
            return;
        }

        if (txtPrecio.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese el precio del producto.');", true);
            return;
        }

        try
        {
            Convert.ToDouble(txtPrecio.Value.Trim());
        }
        catch (Exception ex) {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese un valor válido para el precio.');", true);
            return;   
        }
        string flagtip = string.Empty;
        if (rdbListTipo1.Checked)
        {
            flagtip = rdbListTipo1.Value;
        }
        else if (rdbListTipo2.Checked)
        {
            flagtip = rdbListTipo2.Value;
        }

        ldtResponse = lobjProducto.actualizarDatosProductoMant(Convert.ToInt32(Request.QueryString["vchProdID"].ToString()),
                                                               ddlCategoria.SelectedValue.ToString(),
                                                               ddlSCategoria.SelectedValue.ToString(),
                                                               txtDescripcion.Value.Trim(),
                                                               Convert.ToDouble(txtPrecio.Value.Trim()),
                                                               ddlEstado.SelectedValue.ToString(),
                                                               flagtip);

        Response.Redirect("frmMantProductos?vchProdID=" + Request.QueryString["vchProdID"].ToString());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            cargarDatosProducto(Convert.ToInt32(Request.QueryString["vchProdID"].ToString()));
            Usuario = Session["Usuario"].ToString();
        }
    }
    [System.Web.Services.WebMethod]
    public static string EditarIngresoStock(string datos)
    {
        string rpta = "";
        var arrayDatos = datos.Split(';');
        clsProducto lobjProducto = new clsProducto();
        DataTable dtProductos;
        dtProductos = lobjProducto.editarRegistroIngresoStock(arrayDatos[0],Usuario,arrayDatos[2],arrayDatos[3],arrayDatos[1]);
        
        return rpta;
    }

    protected void btnGuardar_Click1(object sender, EventArgs e)
    {
        guardarProducto();
    }

    protected void ddlCategoria_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (!ddlCategoria.SelectedValue.Equals(""))
        {
            cargarSCategorias(ddlCategoria.SelectedValue.ToString());
        }
        else
        {
            ddlSCategoria.Items.Clear();
        }
    }

    protected void imgVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmMantProductos?vchProdID=" + Request.QueryString["vchProdID"].ToString());
    }
}