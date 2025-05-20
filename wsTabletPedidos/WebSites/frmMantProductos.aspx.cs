using bussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmMantProductos : System.Web.UI.Page
{
    void recuperarUltimaVista(Int32 pintProdID)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        ldtResponse = lobjProducto.recuperarUltimaVistaProducto(pintProdID);

        if (ldtResponse.Rows.Count > 0)
        {
            ldtResponse = ldtResponse.AsEnumerable()
                .Where(row => row.Field<int>("id_sucursal") == (int)Session["Idsucursal"])
                .CopyToDataTable();
            ddlCategoria.SelectedValue = ldtResponse.Rows[0]["vchCategoria"].ToString();

            cargarSCategorias(ddlCategoria.SelectedValue);

            ddlSCategoria.SelectedValue = ldtResponse.Rows[0]["vchSubCategoria"].ToString();

            cargarProductoBusqueda(ddlCategoria.SelectedValue, ddlSCategoria.SelectedValue, "");
        }
    }
    public DataView loadCategoria()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse = new DataTable();

        var categorias = lobjProducto.obtenerCategorias("").AsEnumerable();
        var categoriasFiltradas = categorias
            .Where(row => row.Field<int>("id_sucursal") == (int)Session["Idsucursal"]);

        if (Session["Perfil"].ToString().Equals("Cajero"))
            categoriasFiltradas = categoriasFiltradas
                .Where(row => row.Field<string>("vchCodigo").Equals("MENU EJECUTIVO")
                           || row["vchCodigo"].Equals(""));

        if (categoriasFiltradas.Any())
            ldtResponse = categoriasFiltradas.CopyToDataTable();
        else
            ldtResponse = new DataTable();

        if (!ldtResponse.Columns.Contains("vchCodigo"))
            ldtResponse.Columns.Add("vchCodigo", typeof(string));

        if (!ldtResponse.Columns.Contains("vchValor"))
            ldtResponse.Columns.Add("vchValor", typeof(string));

        DataRow workRow = ldtResponse.NewRow();
        workRow["vchCodigo"] = "";
        workRow["vchValor"] = "--seleccione--";
        ldtResponse.Rows.Add(workRow);

        if (!ldtResponse.Columns.Contains("intOrden"))
            ldtResponse.Columns.Add("intOrden", typeof(int));

        foreach (DataRow row in ldtResponse.Rows)
            if (row.IsNull("intOrden"))
                row["intOrden"] = 0;

        DataView dvOptions = new DataView(ldtResponse);
        dvOptions.Sort = "intOrden ASC";
        return dvOptions;
    }
    void cargarCategorias()
    {
        ddlCategoria.DataSource = loadCategoria();
        ddlCategoria.DataTextField = "vchValor";
        ddlCategoria.DataValueField = "vchCodigo";
        ddlCategoria.DataBind();
    }

    void cargarCategorias2()
    {
        ddlCategoria2.DataSource = loadCategoria();
        ddlCategoria2.DataTextField = "vchValor";
        ddlCategoria2.DataValueField = "vchCodigo";
        ddlCategoria2.DataBind();
    }
    void cargarCategorias3()
    {
        ddlCategoria3.DataSource = loadCategoria();
        ddlCategoria3.DataTextField = "vchValor";
        ddlCategoria3.DataValueField = "vchCodigo";
        ddlCategoria3.DataBind();
    }

    void cargarSCategorias(String pstrCategoria)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        ldtResponse = lobjProducto.obtenerSCategorias(pstrCategoria);

        if(ldtResponse.Rows.Count >0) ldtResponse = ldtResponse.AsEnumerable().Where(row => row.Field<int>("id_sucursal") == (int)Session["Idsucursal"]).CopyToDataTable();

        ddlSCategoria.DataTextField = "vchValor";
        ddlSCategoria.DataValueField = "vchCodigo";
        DataRow workRow = ldtResponse.NewRow();
        workRow["vchCodigo"] = "";
        workRow["vchValor"] = "--seleccione--";
        ldtResponse.Rows.Add(workRow);
        DataView dvOptions = new DataView(ldtResponse);
        dvOptions.Sort = "intOrden ASC";
        ddlSCategoria.DataSource = dvOptions;
        ddlSCategoria.DataBind();
    }
    void cargarSCategorias2(String pstrCategoria)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        ldtResponse = lobjProducto.obtenerSCategorias(pstrCategoria);
        if (ldtResponse.Rows.Count > 0) ldtResponse = ldtResponse.AsEnumerable().Where(row => row.Field<int>("id_sucursal") == (int)Session["Idsucursal"]).CopyToDataTable();
        ddlSCategoria2.DataTextField = "vchValor";
        ddlSCategoria2.DataValueField = "vchCodigo";
        DataRow workRow = ldtResponse.NewRow();
        workRow["vchCodigo"] = "";
        workRow["vchValor"] = "--seleccione--";
        ldtResponse.Rows.Add(workRow);
        DataView dvOptions = new DataView(ldtResponse);
        dvOptions.Sort = "intOrden ASC";
        ddlSCategoria2.DataSource = dvOptions;
        ddlSCategoria2.DataBind();
    }

    void cargarProductoBusqueda(String pstrCategoria,
                                String pstrSCategoria,
                                String pstrBusqueda)
    {
        clsProducto lobjProducto = new clsProducto();
        DataView ldtResponse;

        ldtResponse = lobjProducto.obtenerProductoBusqueda(pstrCategoria, pstrSCategoria, pstrBusqueda).AsEnumerable()
            .Where(row => row.Field<int>("id_sucursal") == (int)Session["Idsucursal"]).AsDataView();
        Session["gvprod"] = ldtResponse;
        gvProductos.DataSource = ldtResponse;
        gvProductos.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
        {
            WebSites.Utils.Redireccionamiento.Login(this, this.GetType());
            return;
        }
        if (!IsPostBack)
        {
            ddlSCategoria.Items.Add(new ListItem("--seleccione--", ""));
            ddlSCategoria2.Items.Add(new ListItem("--seleccione--", ""));
            cargarCategorias();
            cargarCategorias2();
            cargarCategorias3();
            try
            {
                // Validar si el parámetro vchProdID existe en el QueryString
                if (!string.IsNullOrEmpty(Request.QueryString["vchProdID"]))
                {
                    int prodId = Convert.ToInt32(Request.QueryString["vchProdID"]);
                    recuperarUltimaVista(prodId);
                }
                else
                {
                    Console.WriteLine("El parámetro 'vchProdID' no está presente en la URL.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("El parámetro 'vchProdID' no tiene un formato válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al recuperar la última vista: " + ex.Message);
            }    
        }
    }
    protected void ddlSCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlSCategoria.SelectedValue.Equals(""))
        {
            cargarProductoBusqueda(ddlCategoria.SelectedValue, ddlSCategoria.SelectedValue, "");
        }
    }
    protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detalle")
        {
            Response.Redirect("frmDetalleProducto?vchProdID=" + e.CommandArgument);
        }
    }
    protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.Cells[5].Text.Equals("ACTIVO"))
        //    {
        //        e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
        //        e.Row.Cells[5].Font.Bold = true;
        //    }
        //    else
        //    {
        //        e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
        //        e.Row.Cells[5].Font.Bold = true;
        //    }
        //}
    }
    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlCategoria.SelectedValue.Equals(""))
        {
            cargarSCategorias(ddlCategoria.SelectedValue.ToString());
        }
        else
        {
            ddlSCategoria.Items.Clear();
            ddlSCategoria.Items.Add(new ListItem("--seleccione--", ""));
        }
    }

    protected void ibtDetalleB_Click(object sender, EventArgs e)
    {
        cargarProductoBusqueda(ddlCategoria.SelectedValue=="-1"?"": ddlCategoria.SelectedValue, 
            ddlSCategoria.SelectedValue == "-1" ? "" : ddlSCategoria.SelectedValue, 
            txtBusquedaProducto.Value.Trim());
    }

    protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProductos.PageIndex = e.NewPageIndex;
        gvProductos.DataSource = (DataView)Session["gvprod"];
        gvProductos.DataBind();
    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        if (txtCategoria.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Agregue el nombre de la categoría.','Categoria');", true);
            return;
        }

        ldtResponse = lobjProducto.registrarCategoria(txtCategoria.Value.ToUpper(), Session["Usuario"].ToString(), (int)Session["Idsucursal"]);
        
        if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("100"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('Ocurrio un error.','Error');", true);
            return;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal').modal('hide');" +
                    "toastr.success('Se realizó el registro de categoria con éxito', 'Bien');",
                    true);
            cargarCategorias();
            cargarCategorias2();
            cargarCategorias3();
            txtCategoria.Value = "";
        }
    }

    protected void BtnGuardar2_Click(object sender, EventArgs e)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;
        
        if (ddlCategoria2.SelectedValue.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Seleccione una Categoria','Categoria');", true);
            return;
        }
        if (txtSCategoria.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Agregue el nombre de la SubCategoria.','Sub-Categoria');", true);
            return;
        }

        ldtResponse = lobjProducto.registrarSCategoria(txtSCategoria.Value.ToUpper(), ddlCategoria2.SelectedValue.ToString(), Session["Usuario"].ToString(), (int)Session["Idsucursal"]);

        if (ldtResponse.Rows[0]["CodigoRespuesta"].ToString().Equals("100"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('Ocurrio un error.','Error');", true);
            return;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal2').modal('hide');" +
                    "toastr.success('Se realizó el registro de la sub-categoria con éxito', 'Bien');",
                    true);
            
            ddlCategoria.SelectedValue = ddlCategoria2.SelectedValue;
            cargarSCategorias(ddlCategoria2.SelectedValue.ToString());
            ddlCategoria2.SelectedIndex = -1;
            txtSCategoria.Value = "";
        }
    }

    protected void BtnGuardar3_Click(object sender, EventArgs e)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        if (ddlCategoria3.SelectedValue.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Seleccione una categoría.','Categoría');", true);
            return;
        }

        if (ddlSCategoria2.SelectedValue.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Seleccione una Sub-categoría.','Sub-categoría');", true);
            return;
        }

        if (txtDescripcion.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Ingrese el nombre del producto.','Producto');", true);
            return;
        }

        if (txtPrecio.Value.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.info('Ingrese el precio del producto.','Precio');", true);
            return;
        }

        if (!double.TryParse(txtPrecio.Value.Trim(), out _))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('Ingrese un valor válido para el precio.');", true);
            return;
        }

        ldtResponse = lobjProducto.grabarDatosProductoMant(0,
                                                           ddlCategoria3.SelectedValue.ToString(),
                                                           ddlSCategoria2.SelectedValue.ToString(),
                                                           txtDescripcion.Value.Trim(),
                                                           Convert.ToDouble(txtPrecio.Value.Trim()),
                                                           "ACT",
                                                           "C",
                                                           (int)Session["Idsucursal"]);
        if (ldtResponse.Rows[0]["column1"].ToString().Equals("100"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('Ocurrio un error.','Error');", true);
            return;
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script",
                    "$('#mymodal3').modal('hide');" +
                    "toastr.success('Se realizó el registro del producto con éxito', 'Bien');",
                    true);
        cargarProductoBusqueda(ddlCategoria3.SelectedValue, ddlSCategoria2.SelectedValue, txtDescripcion.Value.Trim());
        ddlCategoria3.SelectedIndex = -1;
        ddlSCategoria2.Items.Clear();
        txtDescripcion.Value = "";
        txtPrecio.Value = "";
    }

    protected void ddlCategoria3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlCategoria3.SelectedValue.Equals(""))
        {
            cargarSCategorias2(ddlCategoria3.SelectedValue.ToString());
        }
        else
        {
            ddlSCategoria2.Items.Clear();
            ddlSCategoria2.Items.Add(new ListItem("--seleccione--", ""));
        }
    }

}