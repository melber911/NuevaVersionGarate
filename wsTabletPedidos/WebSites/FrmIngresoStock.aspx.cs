using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmIngresoStock : System.Web.UI.Page
{
    public static string Usuario = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.GetPostBackEventReference(this, "");
        if (Session["Usuario"] == null)
        {
            WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
            return;
        }
        if (!IsPostBack)
        {
            
            
                Usuario = Session["Usuario"].ToString();
                clsProducto lobjProducto = new clsProducto();
                DataTable dtProductos = lobjProducto.obtenerNumeroLoteIngresoStock();
                foreach (DataRow row in dtProductos.Rows)
                {
                    txtNumeroLote.Value = row[0].ToString();
                }
        }
    }

    [System.Web.Services.WebMethod]
    public static string BuscarProductos(string nombreProd)
    {
        if (HttpContext.Current.Session["Usuario"] == null) return "SesionExpirada";
        string rpta = "";
        clsProducto lobjProducto = new clsProducto();
        DataTable dtProductos;
        dtProductos = lobjProducto.obtenerProductosByIngresoStock(nombreProd,(int) HttpContext.Current.Session["Idsucursal"]);
        int i = 0;

        foreach (DataRow row in dtProductos.Rows)
        {  
            rpta += "<tr>";
            rpta += "<th scope='row' hidden='hidden'>" + row[0].ToString() + "</th>";
            rpta += "<th scope='row'>" + row[1].ToString() + "</th>";
            rpta += "<td>" + row[2].ToString() + "</td>";
            rpta += "<td>" + "<span onclick='AgregarProducto(" + i + ")' class='fa fa-plus' style='font-size:30px; cursor: pointer;color:#28a745' title='Agregar Producto'></span>" + "</td>";
            rpta += "</tr>";
            i++;
        }
        return rpta;
    }

    [System.Web.Services.WebMethod]
    public static string GenerarIngresoStock(string datos,string total,string CodLote)
    {
        if (HttpContext.Current.Session["Usuario"] == null) return "SesionExpirada";
        string rpta = "";
        var arrayDatos = datos.Split(';');
        clsProducto lobjProducto = new clsProducto();
        DataTable dtProductos;
        DataTable dtIngCat;
        int idRegistro = 0;
        dtProductos = lobjProducto.generarIngresoStockInventario(CodLote, (int)HttpContext.Current.Session["Idsucursal"], total, Usuario);
        foreach (DataRow row in dtProductos.Rows)
        {
            idRegistro = int.Parse(row[0].ToString());
        }
        for (int i = 0; i < arrayDatos.Length; i++)
        {
            var arrayData = arrayDatos[i].Split('|');
            dtProductos = lobjProducto.generarIngresoDetStockInventario(idRegistro, arrayData[0], arrayData[4], arrayData[5], 1, arrayData[3], Usuario);
            dtIngCat = lobjProducto.ingresoStockAgrupacion(arrayData[0], (int)HttpContext.Current.Session["Idsucursal"], arrayData[4]);
        }
        return rpta;
    }

}