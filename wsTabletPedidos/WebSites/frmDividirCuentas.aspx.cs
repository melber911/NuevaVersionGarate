using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmDividirCuentas : System.Web.UI.Page
{
    static int IdOrden;
    static string Usuario;
    static int canPersonas;
    static int salon;
    static int mesas;
    static string cliente;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
        {
            WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
            return;
        }
        if (!IsPostBack)
        {
            
            Usuario = Session["Usuario"].ToString();
            armarTablaPedidos(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
            IdOrden = Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString());
        }
    }
    void armarTablaPedidos(Int32 IdPedido)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dt = lobjProducto.obtenerDetalleOrden(IdPedido);
        salon = int.Parse(dt.Rows[0]["ordenSalon"].ToString());
        mesas = int.Parse(dt.Rows[0]["ordenMesa"].ToString());
        canPersonas = int.Parse(dt.Rows[0]["ordenCantidadPersonas"].ToString());
        cliente = dt.Rows[0]["ordenCliente"].ToString();
        string rpta = "";
        int i = 0;
        foreach (DataRow row in dt.Rows)
        {
            rpta += "<tr id='TrBodyPedidoTb" + row[8].ToString() + "'>";
            rpta += "<td hidden='hidden'>" + row[8].ToString() + "</td>";
            rpta += "<td>" + row[1].ToString() + "</td>";
            rpta += "<td>" + row[3].ToString() + "</td>";
            rpta += "<td>" + row[5].ToString() + "</td>";
            rpta += "<td hidden='hidden'>" + row[4].ToString() + "</td>";
            rpta += "<td>" + "<span onclick='AgregarProducto(" + i + ")' class='fa fa-plus' style='font-size:30px; cursor: pointer;color:#28a745' title='Agregar Producto'></span>" + "</td>";
            rpta += "</tr>";
            i++;
        }
        bodyTbProductosPedido.InnerHtml = rpta;
    }
   

    [System.Web.Services.WebMethod]
    public static string GenerarDivision(string datos,string numMesas)
    {
        string  rpta = "";
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponseCab;
        DataSet dsResponseDet;
        DataTable ldtResponse;

        var Data = datos.Split('¬');
        for (int i = 0; i < Int16.Parse(numMesas); i++)
        {
            var DetPedido = Data[i].Split('|');
            dtResponseCab = lobjProducto.generarOrdenCab("C", salon, mesas, Usuario, cliente, "ACT", "S", (int)HttpContext.Current.Session["Idsucursal"], canPersonas );
            for (int x = 0; x < DetPedido.Length; x++)
            {
                dsResponseDet = lobjProducto.generarOrdenDet(Convert.ToInt32(dtResponseCab.Rows[0]["OrdenID"].ToString()),
                                                         Convert.ToInt32(DetPedido[x].Split(';')[0].ToString()),
                                                         Convert.ToInt32(DetPedido[x].Split(';')[1].ToString()),
                                                         Convert.ToDouble(DetPedido[x].Split(';')[2].ToString()),
                                                         "",
                                                         Usuario);
            }   
        }
        ldtResponse = lobjProducto.anularOrdenPedido(Convert.ToInt32(IdOrden),
                                                     "Por división de mesas",
                                                     Usuario);
        return rpta;
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmListadoMesasPagar");
    }

}