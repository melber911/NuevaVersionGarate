using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmCategorizarProductos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.GetPostBackEventReference(this, "");
    }

    [System.Web.Services.WebMethod]
    public static string BuscarGrupos(string nombFiltro)
    {
        string rpta = "";
        clsProducto lobjProducto = new clsProducto();
        DataTable dtProductosPrincipales;
        dtProductosPrincipales = lobjProducto.getProductoPrincipalGrupo(nombFiltro);

        foreach (DataRow row in dtProductosPrincipales.Rows)
        {
            rpta += "<tr id='TrBodyProductosPrincipales" + row[0].ToString() + "'>";
            rpta += "<td>" + row[0].ToString() + "</td>";
            rpta += "<td>" + row[2].ToString() + "</td>";
            rpta += "<td>" + row[3].ToString() + "</td>";
            if ((bool)row[4])
            {
                rpta += "<td><span onclick='cambiarEstado(" + row[1].ToString() + ")' title='Cambiar estado' class='label label-sm label-success' style='cursor: pointer;'> Activado</span></td>";
            }
            else
            {
                rpta += "<td><span onclick='cambiarEstado(" + row[1].ToString() + ")' title='Cambiar estado' class='label label-sm label-danger' style='cursor: pointer;'> Desactivado</span></td>";    
            }
            rpta += "<td align='center'>";
            rpta += "<span onclick='getDetalleGrupo(" + row[1].ToString() + ")' class='fa fa-edit' style='font-size:25px; cursor: pointer;' title='Editar'></span>";
            rpta += "<span onclick='eliminarLinea(" + row[1].ToString() + ")' class='fa fa-trash-o' style='font-size:25px; padding-left: 20px; cursor: pointer;' title='Eliminar'></span></td>";
            rpta += "</tr>";
        }
       
        return rpta;
    }

    [System.Web.Services.WebMethod]
    public static string BuscarProductos(string nombFiltro)
    {
        string rpta = "";
        clsProducto lobjProducto = new clsProducto();
        DataTable dtProductosPrincipales;
        dtProductosPrincipales = lobjProducto.getProductosSinGrupo(nombFiltro);
        int i = 0;
        foreach (DataRow row in dtProductosPrincipales.Rows)
        {
            rpta += "<tr id='TrBodyProductosPrincipales" + row[0].ToString() + "'>";
            rpta += "<td hidden='hidden'>" + row[0].ToString() + "</td>";
            rpta += "<td>" + row[1].ToString() + "</td>";
            rpta += "<td>" + row[2].ToString() + "</td>";
            rpta += "<td align='center'>";
            rpta += "<span onclick='agregarProducto(" + i + ")' class='fa fa-plus' style='font-size:25px; cursor: pointer;' title='Agregar'></span>";
            rpta += "</tr>";
            i++;
        }

        return rpta;
    }

    [System.Web.Services.WebMethod]
    public static string BuscarProductos1(string nombFiltro)
    {
        string rpta = "";
        clsProducto lobjProducto = new clsProducto();
        DataTable dtProductosPrincipales;
        dtProductosPrincipales = lobjProducto.getProductosSinGrupo(nombFiltro);
        int i = 0;
        foreach (DataRow row in dtProductosPrincipales.Rows)
        {
            rpta += "<tr id='TrBodyProductosPrincipalesJ" + row[0].ToString() + "'>";
            rpta += "<td hidden='hidden'>" + row[0].ToString() + "</td>";
            rpta += "<td>" + row[1].ToString() + "</td>";
            rpta += "<td>" + row[2].ToString() + "</td>";
            rpta += "<td align='center'>";
            rpta += "<span onclick='agregarProducto1(" + i + ")' class='fa fa-plus' style='font-size:25px; cursor: pointer;' title='Agregar'></span>";
            rpta += "</tr>";
            i++;
        }

        return rpta;
    }

    [System.Web.Services.WebMethod]
    public static string GuardarGrupo(string datos, string idProductoPrincipal)
    {
        string rpta = "";
        try
        {
            DataTable dtProductosPrincipales;
            clsProducto lobjProducto = new clsProducto();
            var data = datos.Split(';');
            for (int i = 0; i < data.Length; i++)
            {
                dtProductosPrincipales = lobjProducto.registrarGrupo(int.Parse(data[i]), int.Parse(idProductoPrincipal));
            }
            rpta = "0";
        }
        catch (Exception)
        {
            rpta = "-1";
        }

        return rpta;
    }

    [System.Web.Services.WebMethod]
    public static string GesProductosAgrupadosById(string idproducto){
        string rpta = "";
        clsProducto lobjProducto = new clsProducto();
        DataTable dtProductosPrincipales;
        dtProductosPrincipales = lobjProducto.getProductosAgrupadosByIdProdPrincipal(idproducto);

        foreach (DataRow row in dtProductosPrincipales.Rows)
        {
            rpta += "<tr id='trProductosParaGrupoTbJ" + row[0].ToString() + "'>";
            rpta += "<th scope='row' hidden='hidden'>" + row[0].ToString() + "</td>";
            rpta += "<td>" + row[1].ToString() + "</td>";
            if (bool.Parse(row[2].ToString()))
            {
                rpta += "<td><input type='checkbox' id='chck" + row[0].ToString() + "' checked disabled></td>";
            }
            else
            {
                rpta += "<td><input type='checkbox' id='chck" + row[0].ToString() + "' disabled></td>";
            }
            rpta += "<td>" + "<span onclick='EliminarProducto1(" + row[0].ToString() + ")' class='fa fa-minus' style='font-size:30px; cursor: pointer;color:Red' title='Eliminar Producto'></span>" + "</td>";
            rpta += "<th scope='row' hidden='hidden'>" + row[3].ToString() + "</td>";
            rpta += "</tr>";
        }

        return rpta;
    }

    [System.Web.Services.WebMethod]
    public static string EliminarProductoDeGrupo(string idProdAgrup)
    {
        string rpta = "";
        try 
	    {	
            clsProducto lobjProducto = new clsProducto();
            DataTable dtProductosPrincipales;
            dtProductosPrincipales = lobjProducto.eliminarProductoGrupo(idProdAgrup);
            rpta = "0";
	    }
	    catch (Exception ex)
	    {
		    rpta = "-1";
	    }
        

        return rpta;
    }

    

}