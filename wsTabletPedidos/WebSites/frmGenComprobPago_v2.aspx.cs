using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using bussinessLayer;
using System.Drawing;
using CrearTicketVenta;

using System.IO;
using System.Net.Mail;
using System.Configuration;

using GMT_Sfe;
using System.Drawing.Printing;
using Spire.Pdf;
using System.Text.RegularExpressions;
using Aspose.Pdf.Facades;
using Common;


public partial class frmGenComprobPago_v2 : System.Web.UI.Page
{
    Int32 gFacCorrelaComBaja = 0;
    HelperLog hpLog = new HelperLog();
    String gNumDocuGenerado = "";
    Int32 gintCodRespuestaSunat = 0;
    String gstrDigestValue = "";
    String gstrEstado = "";
    String gvchMensajeRespuesta = "";
    String gstrRutaCDR = "";
    String gstrRutaXML = "";
    String gstrRutaPDF = "";
    String gstrTicket = "";


    #region [ variables ]

    GenerarArchivo oGENERAR_ARCHIVO = null;
    RespuestaSunat oRESPUESTA = null;
    static CuentaSunat oCUENTA_SUNAT = null;
    static Certificado oCERTIFICADO = null;

    private static string oRUC = string.Empty;
    private static string oRAZONSOCIAL = string.Empty;
    private static string oDIRECCION = string.Empty;
    private static string oDEPARTAMENTO = string.Empty;
    private static string oPROVINCIA = string.Empty;
    private static string oDISTRITO = string.Empty;

    Int32 oTipoComprobante = 0;

    #endregion

    #region [ metodos FACTURACION ]
    private void cargarDataEmisor()
    {
        clsSucursal lobj = new clsSucursal();

        var obj = lobj.obtenerEmpresa();
        if (obj.Rows.Count > 0)
        {
            foreach (DataRow row in obj.Rows)
            {
                oRAZONSOCIAL = row["RazonSocial"].ToString();
                oRUC = row["RUC"].ToString();
                oDIRECCION = row["Direccion"].ToString();
                oDEPARTAMENTO = row["Departamento"].ToString();
                oPROVINCIA = row["Provincia"].ToString();
                oPROVINCIA = row["Distrito"].ToString();
                oCUENTA_SUNAT = new CuentaSunat() { Usuario = oRUC + row["CuentaRUC"].ToString(), Contrasena = row["CuentaPass"].ToString() };
                oCERTIFICADO = new Certificado() { Contrasena = row["CertPass"].ToString(), Ruta = row["CertRuta"].ToString() + oRUC + ".pfx" };
            }
        }

    }

    private void mcp_generar_comprobante()
    {
        try
        {
            switch (oTipoComprobante)
            {
                case 1:
                    mcp_generar_factura();
                    break;

                case 2:
                    mcp_generar_boleta_venta();
                    break;

                case 3:
                    mcp_generar_nota_credito();
                    break;

                case 4:
                    mcp_generar_nota_debito();
                    break;

                case 5:
                    mcp_generar_guia_remision();
                    break;

                case 6:
                    mcp_generar_resumen_diario();
                    break;

                case 7:
                    mcp_generar_comunicacion_de_baja();
                    break;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('" + ex.Message.ToString() + "','Generar Comprobante');", true);
            return;
        }
    }

    private void mcp_generar_factura()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;
        string[] valores = gNumDocuGenerado.Split('-');
        Double dblMontoTotalsinIGV = 0.0;
        Double dblMontoTotalIGV = 0.0;
        Double dblMontoTotalconIGV = 0.0;

        String lstrDigestValue = "";
        String lstrRutaCDR = "";
        String lstrRutaXML = "";
        String lstrRutaPDF = "";
        String lstrTicket = "";

        dblMontoTotalsinIGV = Math.Round(Convert.ToDouble(txtMontoaPagar.Text) / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
        dblMontoTotalIGV = Math.Round(Convert.ToDouble(txtMontoaPagar.Text) - (Convert.ToDouble(txtMontoaPagar.Text) / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00))), 2);
        dblMontoTotalconIGV = Math.Round(Convert.ToDouble(txtMontoaPagar.Text), 2);



        oGENERAR_ARCHIVO = new GenerarArchivo(oRUC, oCUENTA_SUNAT, oCERTIFICADO);

        try
        {
            #region DATOS DEL COMPROBANTE

            #region CABECERA
            ComprobanteCabecera oCabecera = new ComprobanteCabecera();

            oCabecera.TipoDoc_Emisor = "6";
            oCabecera.NroDoc_Emisor = oRUC;
            oCabecera.RSocial_Emisor = oRAZONSOCIAL;
            oCabecera.NombreCorto_Emisor = "-";

            oCabecera.Codigo_Domicilio_Emisor = "0000";
            oCabecera.Direccion_Emisor = oDIRECCION;
            oCabecera.Dpto_Emisor = oDEPARTAMENTO;
            oCabecera.Prov_Emisor = oPROVINCIA;
            oCabecera.Dist_Emisor = oDISTRITO;
            oCabecera.CodPais_Emisor = "PE";

            oCabecera.TipoDoc_Receptor = "6";
            oCabecera.NroDoc_Receptor = txtRuc.Text.Trim();// "20100134706";
            oCabecera.RSocial_Receptor = txtNombre.Text.Trim().ToUpper();// "SANDVIK DEL PERU S A";
            oCabecera.Direccion_Receptor = txtDireccion.Text.Trim().ToUpper();// "AV. EL DERBY NRO. 254 INT. 2305 URB. EL DERBY LIMA - LIMA - SANTIAGO DE SURCO";

            oCabecera.Codigo_Documento = Constantes.FACTURA;
            oCabecera.Serie_Documento = valores[0];//"F001";
            oCabecera.Numero_Documento = valores[1];// "00000001";
            oCabecera.Fecha_Emision = DateTime.Now;
            oCabecera.Hora_Emision = DateTime.Now.ToString("hh:mm:ss");
            oCabecera.Fecha_Vencimiento = DateTime.Now;

            oCabecera.Tipo_Venta = "L";
            oCabecera.Codigo_Moneda = "PEN";
            oCabecera.Sigla_Moneda = "S/";

            oCabecera.Porcentaje_Detraccion = 0;
            oCabecera.Codigo_Detraccion = "";
            oCabecera.Importe_Detraccion = 0;
            oCabecera.NroCuenta_Detraccion = "";

            oCabecera.Importe_Gravado = Convert.ToDecimal(dblMontoTotalsinIGV);//Convert.ToDecimal("100.00");
            oCabecera.Importe_Exonerado = Convert.ToDecimal("0.00");
            oCabecera.Importe_Inafecto = Convert.ToDecimal("0.00");
            oCabecera.Importe_Gratuito = Convert.ToDecimal("0.00");
            oCabecera.Importe_SubTotal = Convert.ToDecimal(dblMontoTotalsinIGV);//Convert.ToDecimal("100.00");
            oCabecera.Importe_ValorVenta = Convert.ToDecimal(dblMontoTotalsinIGV); //Convert.ToDecimal("100.00");
            oCabecera.Importe_Descuento = Convert.ToDecimal("0.00");
            oCabecera.Importe_IGV = Convert.ToDecimal(dblMontoTotalIGV); //Convert.ToDecimal("18.00");
            oCabecera.Importe_ISC = Convert.ToDecimal("0.00");
            oCabecera.Importe_Total = Convert.ToDecimal(dblMontoTotalconIGV); //Convert.ToDecimal("180.00");
            oCabecera.Importe_Cobrado = Convert.ToDecimal(dblMontoTotalconIGV); //Convert.ToDecimal("180.00");
            oCabecera.Importe_OtrosCargos = Convert.ToDecimal("0.00");
            oCabecera.Importe_OtrosTributos = Convert.ToDecimal("0.00");

            oCabecera.Importe_Percepcion = Convert.ToDecimal("0.00");
            oCabecera.Codigo_Percepcion = "";
            oCabecera.Porcentaje_Percepcion = Convert.ToDecimal("0.00");
            oCabecera.Base_Percepcion = Convert.ToDecimal("0.00");

            oCabecera.PorcentajeIGV = 100m * (Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]) / 100m);
            oCabecera.Importe_Base_ISC = Convert.ToDecimal("0.00");
            oCabecera.Importe_Base_OtrosTributos = Convert.ToDecimal("0.00");



            oCabecera.Texto_Importe_Total = NumberToText.Convertir_Valor(Convert.ToDecimal(dblMontoTotalconIGV)).ToUpper(); //"CIENTO DIECIOCHO CON (00/100) SOLES";

            #endregion

            #region DETALLE

            List<ComprobanteDetalle> oLstDetalle = new List<ComprobanteDetalle>();

            for (int i = 0; i <= gdPedido.Rows.Count - 1; i++)
            {
                ComprobanteDetalle oDetalle = new ComprobanteDetalle();
                double dblCantidad = 0.0;
                double dblPrecioUniSinIGV = 0.0;
                double dblPrecioUni = 0.0;
                double dblPrecioTotal = 0.0;
                double dblPrecioTotalSinIGV = 0.0;
                double dblMontoIGV = 0.0;

                dblCantidad = Math.Round(Convert.ToDouble(gdPedido.Rows[i].Cells[1].Text), 2);
                dblPrecioUni = Math.Round(Convert.ToDouble(gdPedido.Rows[i].Cells[3].Text) / Convert.ToDouble(gdPedido.Rows[i].Cells[1].Text), 2);
                dblPrecioUniSinIGV = Math.Round(dblPrecioUni / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
                dblPrecioTotal = Math.Round(Convert.ToDouble(gdPedido.Rows[i].Cells[3].Text), 2);
                dblPrecioTotalSinIGV = Math.Round(dblPrecioTotal / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
                dblMontoIGV = Math.Round(dblPrecioTotal - dblPrecioTotalSinIGV, 2);

                oDetalle.NroItem = (i + 1).ToString(); //"1";
                oDetalle.Codigo_Articulo = gdPedido.DataKeys[i].Values[0].ToString();
                oDetalle.Codigo_Unidad = "C62";
                oDetalle.Descripcion_Articulo = gdPedido.Rows[i].Cells[2].Text.ToUpper();
                oDetalle.Cantidad = Convert.ToDecimal(gdPedido.Rows[i].Cells[1].Text);
                oDetalle.Precio_Unitario_SinIGV = Convert.ToDecimal(dblPrecioUniSinIGV); // Convert.ToDecimal("100.00");
                oDetalle.Precio_Unitario_ConIGV = Convert.ToDecimal(dblPrecioUni); // Convert.ToDecimal("118.00");
                oDetalle.Importe_SubTotal = Convert.ToDecimal(dblPrecioTotalSinIGV); //Convert.ToDecimal("100.00");
                oDetalle.Importe_Descuento = Convert.ToDecimal("0.00");
                oDetalle.Importe_ValorVenta = Convert.ToDecimal(dblPrecioTotalSinIGV); //Convert.ToDecimal("100.00");
                oDetalle.Importe_IGV = Convert.ToDecimal(dblMontoIGV);// Convert.ToDecimal("18.00");
                oDetalle.Importe_ISC = Convert.ToDecimal("0.00");
                oDetalle.Importe_Total = Convert.ToDecimal(dblPrecioTotal);// Convert.ToDecimal("118.00");

                oDetalle.EsGravado = true;
                oDetalle.EsExonerado = false;
                oDetalle.EsInafecto = false;
                oDetalle.EsGratuito = false;

                oDetalle.Tipo_AfeccionIGV = "10";

                oLstDetalle.Add(oDetalle);
            }

            #endregion

            #region GUIAS

            //List<FacturaGuias> oLstGuias = new List<FacturaGuias>();

            //FacturaGuias oGuias = new FacturaGuias();
            //oGuias.Codigo_Guia = Constantes.GUIA_REMISION_REMITENTE;
            //oGuias.Serie_Guia = "001";
            //oGuias.Numero_Guia = "000001";
            //oLstGuias.Add(oGuias);

            //oGuias = new FacturaGuias();
            //oGuias.Codigo_Guia = Constantes.GUIA_REMISION_REMITENTE;
            //oGuias.Serie_Guia = "002";
            //oGuias.Numero_Guia = "000002";
            //oLstGuias.Add(oGuias);

            //oGuias = new FacturaGuias();
            //oGuias.Codigo_Guia = Constantes.GUIA_REMISION_REMITENTE;
            //oGuias.Serie_Guia = "003";
            //oGuias.Numero_Guia = "000003";
            //oLstGuias.Add(oGuias);

            #endregion

            #region FORMA-DE-PAGO

            List<FacturaFormaPago> oLstFormaPago = new List<FacturaFormaPago>();

            FacturaFormaPago oFormaPago = new FacturaFormaPago();
            oFormaPago.Forma_Pago = "Contado"; //Credito / Contado
            oFormaPago.Codigo_Moneda = "PEN";
            oFormaPago.Monto_Neto = Convert.ToDecimal(dblMontoTotalconIGV);
            oLstFormaPago.Add(oFormaPago);

            //oFormaPago = new FacturaFormaPago();
            //oFormaPago.Forma_Pago = "Cuota001"; //En caso sea -> Credito
            //oFormaPago.Codigo_Moneda = "PEN";
            //oFormaPago.Monto_Neto = Convert.ToDecimal("59.00");
            //oFormaPago.Fecha_Pago = DateTime.Now.AddMonths(1);
            //oLstFormaPago.Add(oFormaPago);

            //oFormaPago = new FacturaFormaPago();
            //oFormaPago.Forma_Pago = "Cuota002"; //En caso sea -> Credito
            //oFormaPago.Codigo_Moneda = "PEN";
            //oFormaPago.Monto_Neto = Convert.ToDecimal("59.00");
            //oFormaPago.Fecha_Pago = DateTime.Now.AddMonths(2);
            //oLstFormaPago.Add(oFormaPago);

            #endregion

            //-- AGREGAMOS LA LISTA DE ITEMS
            oCabecera.LstComprobanteDetalle = oLstDetalle;

            //-- AGREGAMOS LAS LISTA DE GUIAS
            //oCabecera.LstGuias = oLstGuias;

            //-- AGREGAMOS LAS LISTA DE FORMA DE PAGO
            oCabecera.LstFormaPago = oLstFormaPago;

            #endregion

            //-- METODO PARA GENERACION, VALIDACION Y ALMACENAMIENTO DEL ARCHIVO XML
            oRESPUESTA = new RespuestaSunat();
            hpLog.generarLog("INICIA CONSULTA SERVICIO SUNAT");
            oGENERAR_ARCHIVO = new GenerarArchivo(oRUC, oCUENTA_SUNAT, oCERTIFICADO);
            oRESPUESTA = oGENERAR_ARCHIVO.GenerarComprobante(oCabecera, true, false);
            hpLog.generarLog("oRESPUESTA.RutaCDR: " + oRESPUESTA.RutaCDR);
            hpLog.generarLog("oRESPUESTA.RutaXML: " + oRESPUESTA.RutaXML);
            hpLog.generarLog("FINALIZA CONSULTA SERVICIO SUNAT");

            if (oRESPUESTA.DigestValue == null)
            {
                lstrDigestValue = "";
            }
            else
            {
                lstrDigestValue = oRESPUESTA.DigestValue;
            }

            if (oRESPUESTA.RutaCDR == null)
            {
                lstrRutaCDR = "";
            }
            else
            {
                lstrRutaCDR = oRESPUESTA.RutaCDR;
            }

            if (oRESPUESTA.RutaXML == null)
            {
                lstrRutaXML = "";
            }
            else
            {
                lstrRutaXML = oRESPUESTA.RutaXML;
            }

            if (oRESPUESTA.RutaPDF == null)
            {
                lstrRutaPDF = "";
            }
            else
            {
                lstrRutaPDF = oRESPUESTA.RutaPDF;
            }

            if (oRESPUESTA.Ticket == null)
            {
                lstrTicket = "";
            }
            else
            {
                lstrTicket = oRESPUESTA.Ticket;
            }

            gintCodRespuestaSunat = Convert.ToInt32(oRESPUESTA.Codigo);
            gstrDigestValue = lstrDigestValue;
            gstrEstado = oRESPUESTA.Estado.ToString();
            gvchMensajeRespuesta = oRESPUESTA.Mensaje;
            gstrRutaCDR = lstrRutaCDR;
            gstrRutaXML = lstrRutaXML;
            gstrRutaPDF = lstrRutaPDF;
            gstrTicket = lstrTicket;

            //PdfViewer viewer = new PdfViewer();
            //Open input PDF file
            //viewer.BindPdf(oRESPUESTA.RutaPDF);
            //Print PDF document
            //viewer.PrintDocument();
            //Close PDF file
            //viewer.Close();

        }
        catch (Exception ex)
        {
            txtDireccion.Text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('" + ex.Message.ToString() + "','Generar factura');", true);
            return;
        }
    }

    private void mcp_generar_boleta_venta()
    {
        //PrintDocument lobjPrinter;
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;
        string[] valores = gNumDocuGenerado.Split('-');
        Double dblMontoTotalsinIGV = 0.0;
        Double dblMontoTotalIGV = 0.0;
        Double dblMontoTotalconIGV = 0.0;

        String lstrDigestValue = "";
        String lstrRutaCDR = "";
        String lstrRutaXML = "";
        String lstrRutaPDF = "";
        String lstrTicket = "";

        dblMontoTotalsinIGV = Math.Round(Convert.ToDouble(txtMontoaPagar.Text) / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
        dblMontoTotalIGV = Math.Round(Convert.ToDouble(txtMontoaPagar.Text) - (Convert.ToDouble(txtMontoaPagar.Text) / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00))), 2);
        dblMontoTotalconIGV = Math.Round(Convert.ToDouble(txtMontoaPagar.Text), 2);


        oGENERAR_ARCHIVO = new GenerarArchivo(oRUC, oCUENTA_SUNAT, oCERTIFICADO);

        try
        {
            #region DATOS DEL COMPROBANTE

            #region CABECERA

            ComprobanteCabecera oCabecera = new ComprobanteCabecera();

            oCabecera.TipoDoc_Emisor = "6";
            oCabecera.NroDoc_Emisor = oRUC;
            oCabecera.RSocial_Emisor = oRAZONSOCIAL;
            oCabecera.NombreCorto_Emisor = "-";

            oCabecera.Codigo_Domicilio_Emisor = "0000";
            oCabecera.Direccion_Emisor = oDIRECCION;
            oCabecera.Dpto_Emisor = oDEPARTAMENTO;
            oCabecera.Prov_Emisor = oPROVINCIA;
            oCabecera.Dist_Emisor = oDISTRITO;
            oCabecera.CodPais_Emisor = "PE";

            oCabecera.TipoDoc_Receptor = "1";//"6";
            oCabecera.NroDoc_Receptor = txtRuc.Text.Trim(); //"20100134706";
            if (txtNombre.Text.Trim().ToUpper().Trim().Equals(".") || txtNombre.Text.Trim().ToUpper().Trim().Equals(""))
            {
                oCabecera.RSocial_Receptor = "CLIENTE"; //"SANDVIK DEL PERU S A";
            }
            else
            {
                oCabecera.RSocial_Receptor = txtNombre.Text.Trim().ToUpper(); //"SANDVIK DEL PERU S A";
            }
            oCabecera.Direccion_Receptor = txtDireccion.Text.Trim().ToUpper(); //"AV. EL DERBY NRO. 254 INT. 2305 URB. EL DERBY LIMA - LIMA - SANTIAGO DE SURCO";

            oCabecera.Codigo_Documento = Constantes.BOLETA_VENTA;
            oCabecera.Serie_Documento = valores[0]; //B001";
            oCabecera.Numero_Documento = valores[1]; // "00000001";
            oCabecera.Fecha_Emision = DateTime.Now;
            oCabecera.Hora_Emision = DateTime.Now.ToString("hh:mm:ss");

            oCabecera.Tipo_Venta = "L";
            oCabecera.Codigo_Moneda = "PEN";
            oCabecera.Sigla_Moneda = "S/";

            oCabecera.Porcentaje_Detraccion = 0;
            oCabecera.Codigo_Detraccion = "";
            oCabecera.Importe_Detraccion = 0;
            oCabecera.NroCuenta_Detraccion = "";

            oCabecera.Importe_Gravado = Convert.ToDecimal(dblMontoTotalsinIGV);//Convert.ToDecimal("100.00");
            oCabecera.Importe_Exonerado = Convert.ToDecimal("0.00");
            oCabecera.Importe_Inafecto = Convert.ToDecimal("0.00");
            oCabecera.Importe_Gratuito = Convert.ToDecimal("0.00");
            oCabecera.Importe_SubTotal = Convert.ToDecimal(dblMontoTotalsinIGV);//Convert.ToDecimal("100.00");
            oCabecera.Importe_ValorVenta = Convert.ToDecimal(dblMontoTotalsinIGV); //Convert.ToDecimal("100.00");
            oCabecera.Importe_Descuento = Convert.ToDecimal("0.00");
            oCabecera.Importe_IGV = Convert.ToDecimal(dblMontoTotalIGV); //Convert.ToDecimal("18.00");
            oCabecera.Importe_ISC = Convert.ToDecimal("0.00");
            oCabecera.Importe_Total = Convert.ToDecimal(dblMontoTotalconIGV); //Convert.ToDecimal("180.00");
            oCabecera.Importe_Cobrado = Convert.ToDecimal(dblMontoTotalconIGV); //Convert.ToDecimal("180.00");
            oCabecera.Importe_OtrosCargos = Convert.ToDecimal("0.00");
            oCabecera.Importe_OtrosTributos = Convert.ToDecimal("0.00");

            oCabecera.Importe_Percepcion = Convert.ToDecimal("0.00");
            oCabecera.Codigo_Percepcion = "";
            oCabecera.Porcentaje_Percepcion = Convert.ToDecimal("0.00");
            oCabecera.Base_Percepcion = Convert.ToDecimal("0.00");

            oCabecera.PorcentajeIGV = Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]);
            oCabecera.Importe_Base_ISC = Convert.ToDecimal("0.00");
            oCabecera.Importe_Base_OtrosTributos = Convert.ToDecimal("0.00");

            oCabecera.Texto_Importe_Total = NumberToText.Convertir_Valor(Convert.ToDecimal(dblMontoTotalconIGV)).ToUpper(); //"CIENTO DIECIOCHO CON (00/100) SOLES";

            #endregion

            #region DETALLE

            List<ComprobanteDetalle> oLstDetalle = new List<ComprobanteDetalle>();

            for (int i = 0; i <= gdPedido.Rows.Count - 1; i++)
            {
                ComprobanteDetalle oDetalle = new ComprobanteDetalle();
                double dblCantidad = 0.0;
                double dblPrecioUniSinIGV = 0.0;
                double dblPrecioUni = 0.0;
                double dblPrecioTotal = 0.0;
                double dblPrecioTotalSinIGV = 0.0;
                double dblMontoIGV = 0.0;

                dblCantidad = Math.Round(Convert.ToDouble(gdPedido.Rows[i].Cells[1].Text), 2);
                dblPrecioUni = Math.Round(Convert.ToDouble(gdPedido.Rows[i].Cells[3].Text) / Convert.ToDouble(gdPedido.Rows[i].Cells[1].Text), 2);
                dblPrecioUniSinIGV = Math.Round(dblPrecioUni / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
                dblPrecioTotal = Math.Round(Convert.ToDouble(gdPedido.Rows[i].Cells[3].Text), 2);
                dblPrecioTotalSinIGV = Math.Round(dblPrecioTotal / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
                dblMontoIGV = Math.Round(dblPrecioTotal - dblPrecioTotalSinIGV, 2);

                oDetalle.NroItem = (i + 1).ToString(); //"1";
                oDetalle.Codigo_Articulo = gdPedido.DataKeys[i].Values[0].ToString();
                oDetalle.Codigo_Unidad = "C62";
                oDetalle.Descripcion_Articulo = gdPedido.Rows[i].Cells[2].Text.ToUpper();
                oDetalle.Cantidad = Convert.ToDecimal(gdPedido.Rows[i].Cells[1].Text);
                oDetalle.Precio_Unitario_SinIGV = Convert.ToDecimal(dblPrecioUniSinIGV); // Convert.ToDecimal("100.00");
                oDetalle.Precio_Unitario_ConIGV = Convert.ToDecimal(dblPrecioUni); // Convert.ToDecimal("118.00");
                oDetalle.Importe_SubTotal = Convert.ToDecimal(dblPrecioTotalSinIGV); //Convert.ToDecimal("100.00");
                oDetalle.Importe_Descuento = Convert.ToDecimal("0.00");
                oDetalle.Importe_ValorVenta = Convert.ToDecimal(dblPrecioTotalSinIGV); //Convert.ToDecimal("100.00");
                oDetalle.Importe_IGV = Convert.ToDecimal(dblMontoIGV);// Convert.ToDecimal("18.00");
                oDetalle.Importe_ISC = Convert.ToDecimal("0.00");
                oDetalle.Importe_Total = Convert.ToDecimal(dblPrecioTotal);// Convert.ToDecimal("118.00");

                oDetalle.EsGravado = true;
                oDetalle.EsExonerado = false;
                oDetalle.EsInafecto = false;
                oDetalle.EsGratuito = false;

                oDetalle.Tipo_AfeccionIGV = "10";

                oLstDetalle.Add(oDetalle);
            }

            #endregion

            //-- AGREGAMOS LA LISTA DE ITEMS
            oCabecera.LstComprobanteDetalle = oLstDetalle;

            #endregion

            //-- METODO PARA GENERACION, Y ALMACENAMIENTO DEL ARCHIVO XML
            oRESPUESTA = new RespuestaSunat();
            hpLog.generarLog("INICIA CONSULTA SERVICIO SUNAT");
            oGENERAR_ARCHIVO = new GenerarArchivo(oRUC, oCUENTA_SUNAT, oCERTIFICADO);
            oRESPUESTA = oGENERAR_ARCHIVO.GenerarComprobante(oCabecera, true, false);
            hpLog.generarLog("oRESPUESTA.RutaCDR: " + oRESPUESTA.RutaCDR);
            hpLog.generarLog("oRESPUESTA.RutaXML: " + oRESPUESTA.RutaXML);
            hpLog.generarLog("FINALIZA CONSULTA SERVICIO SUNAT");

            if (oRESPUESTA.DigestValue == null)
            {
                lstrDigestValue = "";
            }
            else
            {
                lstrDigestValue = oRESPUESTA.DigestValue;
            }

            if (oRESPUESTA.RutaCDR == null)
            {
                lstrRutaCDR = "";
            }
            else
            {
                lstrRutaCDR = oRESPUESTA.RutaCDR;
            }

            if (oRESPUESTA.RutaXML == null)
            {
                lstrRutaXML = "";
            }
            else
            {
                lstrRutaXML = oRESPUESTA.RutaXML;
            }

            if (oRESPUESTA.RutaPDF == null)
            {
                lstrRutaPDF = "";
            }
            else
            {
                lstrRutaPDF = oRESPUESTA.RutaPDF;
            }

            if (oRESPUESTA.Ticket == null)
            {
                lstrTicket = "";
            }
            else
            {
                lstrTicket = oRESPUESTA.Ticket;
            }

            gintCodRespuestaSunat = Convert.ToInt32(oRESPUESTA.Codigo);
            gstrDigestValue = lstrDigestValue;
            gstrEstado = oRESPUESTA.Estado.ToString();
            gvchMensajeRespuesta = oRESPUESTA.Mensaje;
            gstrRutaCDR = lstrRutaCDR;
            gstrRutaXML = lstrRutaXML;
            gstrRutaPDF = lstrRutaPDF;
            gstrTicket = lstrTicket;

        }
        catch (Exception ex)
        {
            txtDireccion.Text = ex.Message.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('" + ex.Message.ToString() + "','Generar boleta');", true);
            return;
        }
    }

    private void mcp_generar_nota_credito()
    {
        try
        {
            #region DATOS DEL COMPROBANTE

            #region CABECERA

            ComprobanteCabecera oCabecera = new ComprobanteCabecera();

            oCabecera.TipoDoc_Emisor = "6";
            oCabecera.NroDoc_Emisor = oRUC;
            oCabecera.RSocial_Emisor = oRAZONSOCIAL;
            oCabecera.NombreCorto_Emisor = "-";

            oCabecera.Codigo_Domicilio_Emisor = "0000";
            oCabecera.Direccion_Emisor = oDIRECCION;
            oCabecera.Dpto_Emisor = oDEPARTAMENTO;
            oCabecera.Prov_Emisor = oPROVINCIA;
            oCabecera.Dist_Emisor = oDISTRITO;
            oCabecera.CodPais_Emisor = "PE";

            oCabecera.TipoDoc_Receptor = "6";
            oCabecera.NroDoc_Receptor = "20100134706";
            oCabecera.RSocial_Receptor = "SANDVIK DEL PERU S A";
            oCabecera.Direccion_Receptor = "AV. EL DERBY NRO. 254 INT. 2305 URB. EL DERBY LIMA - LIMA - SANTIAGO DE SURCO";

            oCabecera.Codigo_Documento = Constantes.NOTA_CREDITO;
            oCabecera.Serie_Documento = "F010";
            oCabecera.Numero_Documento = "00000001";
            oCabecera.Fecha_Emision = DateTime.Now;
            oCabecera.Hora_Emision = DateTime.Now.ToString("hh:mm:ss");

            oCabecera.Tipo_Venta = "L";
            oCabecera.Codigo_Moneda = "PEN";
            oCabecera.Sigla_Moneda = "S/";

            oCabecera.Porcentaje_Detraccion = 0;
            oCabecera.Codigo_Detraccion = "";
            oCabecera.Importe_Detraccion = 0;
            oCabecera.NroCuenta_Detraccion = "";

            oCabecera.Importe_Gravado = Convert.ToDecimal("100.00");
            oCabecera.Importe_Exonerado = Convert.ToDecimal("0.00");
            oCabecera.Importe_Inafecto = Convert.ToDecimal("0.00");
            oCabecera.Importe_Gratuito = Convert.ToDecimal("0.00");
            oCabecera.Importe_SubTotal = Convert.ToDecimal("100.00");
            oCabecera.Importe_ValorVenta = Convert.ToDecimal("100.00");
            oCabecera.Importe_Descuento = Convert.ToDecimal("0.00");
            oCabecera.Importe_IGV = Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]);
            oCabecera.Importe_ISC = Convert.ToDecimal("0.00");
            oCabecera.Importe_Total = 100m * (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100m));
            oCabecera.Importe_Cobrado = 100m * (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100m));

            oCabecera.Importe_OtrosCargos = Convert.ToDecimal("0.00");
            oCabecera.Importe_OtrosTributos = Convert.ToDecimal("0.00");
            oCabecera.Importe_Percepcion = Convert.ToDecimal("0.00");

            oCabecera.PorcentajeIGV = 100m * (Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]) / 100m);
            oCabecera.Importe_Base_ISC = Convert.ToDecimal("0.00"); ;
            oCabecera.Importe_Base_OtrosTributos = Convert.ToDecimal("0.00"); ;
            oCabecera.Texto_Importe_Total = "CIENTO DIECIOCHO CON 00/100";

            oCabecera.Codigo_Documento_Ref = Constantes.FACTURA;
            oCabecera.Documento_Ref = "F001-00000001";
            oCabecera.Fecha_Documento_Ref = DateTime.Now;
            oCabecera.Codigo_Motivo_Ref = "01";
            oCabecera.Descripcion_Motivo_Ref = "ANULACION DE LA OPERACION";

            #endregion

            #region DETALLE

            List<ComprobanteDetalle> oLstDetalle = new List<ComprobanteDetalle>();

            ComprobanteDetalle oDetalle = new ComprobanteDetalle();
            oDetalle.NroItem = "1";
            oDetalle.Codigo_Articulo = "000001";
            oDetalle.Codigo_Unidad = "C62";// "UNI";
            oDetalle.Descripcion_Articulo = "SERVICIOS GENERALES";
            oDetalle.Cantidad = Convert.ToDecimal("1");
            oDetalle.Precio_Unitario_SinIGV = Convert.ToDecimal("100.00");
            oDetalle.Precio_Unitario_ConIGV = 100m * (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100m));
            oDetalle.Importe_SubTotal = Convert.ToDecimal("100.00");
            oDetalle.Importe_Descuento = Convert.ToDecimal("0.00");
            oDetalle.Importe_ValorVenta = Convert.ToDecimal("100.00");
            oDetalle.Importe_IGV = 100m * (Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]) / 100m);
            oDetalle.Importe_ISC = Convert.ToDecimal("0.00");
            oDetalle.Importe_Total = 100m * (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100m));

            oDetalle.EsGravado = true;
            oDetalle.EsExonerado = false;
            oDetalle.EsInafecto = false;
            oDetalle.EsGratuito = false;

            oDetalle.Tipo_AfeccionIGV = "10";

            oLstDetalle.Add(oDetalle);

            #endregion

            //-- AGREGAMOS LA LISTA DE ITEMS
            oCabecera.LstComprobanteDetalle = oLstDetalle;

            #endregion

            //-- METODO PARA GENERACION, VALIDACION Y ALMACENAMIENTO DEL ARCHIVO XML
            oRESPUESTA = new RespuestaSunat();
            oGENERAR_ARCHIVO = new GenerarArchivo(oRUC, oCUENTA_SUNAT, oCERTIFICADO);
            oRESPUESTA = oGENERAR_ARCHIVO.GenerarComprobante(oCabecera, true, false);

            oGENERAR_ARCHIVO.GenerarPDF(oCabecera, oRESPUESTA, "Ticket");


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('" + ex.Message.ToString() + "','Generar nota de credito');", true);
            return;
        }
    }

    private void mcp_generar_nota_debito()
    {
        try
        {
            #region DATOS DEL COMPROBANTE

            #region CABECERA

            ComprobanteCabecera oCabecera = new ComprobanteCabecera();

            oCabecera.TipoDoc_Emisor = "6";
            oCabecera.NroDoc_Emisor = oRUC;
            oCabecera.RSocial_Emisor = oRAZONSOCIAL;
            oCabecera.NombreCorto_Emisor = "-";

            oCabecera.Codigo_Domicilio_Emisor = "0000";
            oCabecera.Direccion_Emisor = oDIRECCION;
            oCabecera.Dpto_Emisor = oDEPARTAMENTO;
            oCabecera.Prov_Emisor = oPROVINCIA;
            oCabecera.Dist_Emisor = oDISTRITO;
            oCabecera.CodPais_Emisor = "PE";

            oCabecera.TipoDoc_Receptor = "6";
            oCabecera.NroDoc_Receptor = "20100134706";
            oCabecera.RSocial_Receptor = "SANDVIK DEL PERU S A";
            oCabecera.Direccion_Receptor = "AV. EL DERBY NRO. 254 INT. 2305 URB. EL DERBY LIMA - LIMA - SANTIAGO DE SURCO";

            oCabecera.Codigo_Documento = Constantes.NOTA_DEBITO;
            oCabecera.Serie_Documento = "F011";
            oCabecera.Numero_Documento = "00000001";
            oCabecera.Fecha_Emision = DateTime.Now;
            oCabecera.Hora_Emision = DateTime.Now.ToString("hh:mm:ss");

            oCabecera.Tipo_Venta = "L";
            oCabecera.Codigo_Moneda = "PEN";
            oCabecera.Sigla_Moneda = "S/";

            oCabecera.Porcentaje_Detraccion = 0;
            oCabecera.Codigo_Detraccion = "";
            oCabecera.Importe_Detraccion = 0;
            oCabecera.NroCuenta_Detraccion = "";

            oCabecera.Importe_Gravado = Convert.ToDecimal("100.00");
            oCabecera.Importe_Exonerado = Convert.ToDecimal("0.00");
            oCabecera.Importe_Inafecto = Convert.ToDecimal("0.00");
            oCabecera.Importe_Gratuito = Convert.ToDecimal("0.00");
            oCabecera.Importe_SubTotal = Convert.ToDecimal("100.00");
            oCabecera.Importe_ValorVenta = Convert.ToDecimal("100.00");
            oCabecera.Importe_Descuento = Convert.ToDecimal("0.00");
            oCabecera.Importe_IGV = 100m * ( Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]) / 100m);
            oCabecera.Importe_ISC = Convert.ToDecimal("0.00");
            oCabecera.Importe_Total = 100m * (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100m));
            oCabecera.Importe_Cobrado = 100m * (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100m));
            oCabecera.Importe_OtrosCargos = Convert.ToDecimal("0.00");
            oCabecera.Importe_OtrosTributos = Convert.ToDecimal("0.00");
            oCabecera.Importe_Percepcion = Convert.ToDecimal("0.00");

            oCabecera.PorcentajeIGV = 100m * ( Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]) / 100m);
            oCabecera.Importe_Base_ISC = 0;
            oCabecera.Importe_Base_OtrosTributos = 0;
            oCabecera.Texto_Importe_Total = "CIENTO DIECIOCHO CON 00/100";

            oCabecera.Codigo_Documento_Ref = Constantes.FACTURA;
            oCabecera.Documento_Ref = "F001-00000001";
            oCabecera.Fecha_Documento_Ref = DateTime.Now;
            oCabecera.Codigo_Motivo_Ref = "01";
            oCabecera.Descripcion_Motivo_Ref = "INTERES POR MORA";

            #endregion

            #region DETALLE

            List<ComprobanteDetalle> oLstDetalle = new List<ComprobanteDetalle>();

            ComprobanteDetalle oDetalle = new ComprobanteDetalle();
            oDetalle.NroItem = "1";
            oDetalle.Codigo_Articulo = "000001";
            oDetalle.Codigo_Unidad = "UNI";
            oDetalle.Descripcion_Articulo = "SERVICIOS GENERALES";
            oDetalle.Cantidad = Convert.ToDecimal("1");
            oDetalle.Precio_Unitario_SinIGV = Convert.ToDecimal("100.00");
            oDetalle.Precio_Unitario_ConIGV = 100m * (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100m));
            oDetalle.Importe_SubTotal = Convert.ToDecimal("100.00");
            oDetalle.Porcentaje_Descuento = Convert.ToDecimal("0.00");
            oDetalle.Importe_Descuento = Convert.ToDecimal("0.00");
            oDetalle.Importe_ValorVenta = Convert.ToDecimal("100.00");
            oDetalle.Importe_IGV = 100m * ( Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]) / 100m);
            oDetalle.Porcentaje_ISC = Convert.ToDecimal("0.00");
            oDetalle.Importe_ISC = Convert.ToDecimal("0.00");
            oDetalle.Importe_Total = 100m * (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100m));

            oDetalle.EsGravado = true;
            oDetalle.EsExonerado = false;
            oDetalle.EsInafecto = false;
            oDetalle.EsGratuito = false;

            oDetalle.Tipo_AfeccionIGV = "10";

            oLstDetalle.Add(oDetalle);

            #endregion

            //-- AGREGAMOS LA LISTA DE ITEMS 
            oCabecera.LstComprobanteDetalle = oLstDetalle;

            #endregion

            //-- METODO PARA GENERACION, VALIDACION Y ALMACENAMIENTO DEL ARCHIVO XML
            oRESPUESTA = new RespuestaSunat();
            oGENERAR_ARCHIVO = new GenerarArchivo(oRUC, oCUENTA_SUNAT, oCERTIFICADO);
            oRESPUESTA = oGENERAR_ARCHIVO.GenerarComprobante(oCabecera, true, false);

            oGENERAR_ARCHIVO.GenerarPDF(oCabecera, oRESPUESTA, "Ticket");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('" + ex.Message.ToString() + "','Generar nota de debito');", true);
            return;
        }
    }

    private void mcp_generar_guia_remision()
    {
        try
        {
            #region DATOS DEL COMPROBANTE

            #region CABECERA
            GuiaRemisionCabecera oCabecera = new GuiaRemisionCabecera();

            oCabecera.TipoDoc_Emisor = "6";
            oCabecera.NroDoc_Emisor = oRUC;
            oCabecera.RSocial_Emisor = oRAZONSOCIAL;
            oCabecera.Direccion_Emisor = oDIRECCION;
            oCabecera.Dpto_Emisor = oDEPARTAMENTO;
            oCabecera.Prov_Emisor = oPROVINCIA;
            oCabecera.Dist_Emisor = oDISTRITO;

            oCabecera.Tipo_Documento = Constantes.GUIA_REMISION_REMITENTE;
            oCabecera.Serie_Documento = "T001";
            oCabecera.Numero_Documento = "00000001";
            oCabecera.Fecha_Emision = DateTime.Now;
            oCabecera.Hora_Emision = DateTime.Now.ToString("hh:mm:ss");
            oCabecera.Fecha_Inicio_Traslado = DateTime.Now;
            oCabecera.Observaciones = "CINCO BOTELLAS MAS UNA GALONERA";

            oCabecera.TipoDoc_Destino = "6";
            oCabecera.NroDoc_Destino = "20100134706";
            oCabecera.RSocial_Destino = "SANDVIK DEL PERU S A";
            oCabecera.Direccion_Destino = "AV. EL DERBY NRO. 254 INT. 2305 URB. EL DERBY LIMA - LIMA - SANTIAGO DE SURCO";

            oCabecera.Motivo_Traslado = "01";
            oCabecera.Descripcion_Motivo_Traslado = "VENTA";

            oCabecera.Modalidad_Transporte = "01";
            oCabecera.Descripcion_Modalidad_Transporte = "PUBLICO";

            oCabecera.Peso_Bruto = 10000;
            oCabecera.Unidad_Medida_Peso_Bruto = "KGM";
            oCabecera.Cantidad_Bultos = 1;

            //01 PUBLICO
            oCabecera.TipoDoc_Transportista = "6";
            oCabecera.NroDoc_Transportista = "20100134706";
            oCabecera.RSocial_Transportista = "SANDVIK DEL PERU S A";

            //02 PRIVADO
            //oCabecera.TipoDoc_Conductor = "1";
            //oCabecera.NroDoc_Conductor = "41365120";
            //oCabecera.Placa_Vehiculo = "AJC-791";

            oCabecera.Ubigeo_Partida = "020802";
            oCabecera.Direccion_Partida = oDIRECCION + " " + oDEPARTAMENTO + " - " + oPROVINCIA + " - " + oDISTRITO;

            oCabecera.Ubigeo_Llegada = "020801";
            oCabecera.Direccion_Llegada = "AV. EL DERBY NRO. 254 INT. 2305 URB. EL DERBY LIMA - LIMA - SANTIAGO DE SURCO";

            #endregion

            #region DETALLE

            List<GuiaRemisionDetalle> oLstDetalle = new List<GuiaRemisionDetalle>();

            GuiaRemisionDetalle oDetalle = new GuiaRemisionDetalle();

            oDetalle.NroItem = "1";
            oDetalle.Codigo_Articulo = "A0000001";
            oDetalle.Codigo_Unidad = "NIU";
            oDetalle.Descripcion_Unidad = "UNIDAD";
            oDetalle.Descripcion_Articulo = "ARTICULO DE PRUEBA";
            oDetalle.Cantidad = Convert.ToDecimal("45");

            oLstDetalle.Add(oDetalle);

            oCabecera.LstGuiaDetalle = oLstDetalle;

            #endregion

            #endregion

            oRESPUESTA = new RespuestaSunat();
            oRESPUESTA = oGENERAR_ARCHIVO.GenerarGuiaRemision(oCabecera, false);

            //oGENERAR_ARCHIVO.GeneraPDFGuiaRemision(oCabecera, oRESPUESTA);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('" + ex.Message.ToString() + "','Generar guia de remisión');", true);
            return;
        }
    }

    private void mcp_generar_resumen_diario()
    {


        try
        {
            #region DATOS DEL RESUMEN

            #region CABECERA

            ResumenDiarioCabecera oCabecera = new ResumenDiarioCabecera();
            oCabecera.TipoDoc_Emisor = "6";
            oCabecera.NroDoc_Emisor = oRUC;
            oCabecera.RSocial_Emisor = oRAZONSOCIAL;
            oCabecera.NombreCorto_Emisor = "-";

            oCabecera.Codigo_Moneda = "PEN";
            oCabecera.Fecha_Emision = DateTime.Now;
            oCabecera.Fecha_Resumen = DateTime.Now;
            oCabecera.Identificador = "RC-" + DateTime.Now.ToString("yyyyMMdd") + "-1";


            #endregion

            #region DETALLE

            List<ResumenDiarioDetalle> oLstDetalle = new List<ResumenDiarioDetalle>();

            ResumenDiarioDetalle oDetalle = new ResumenDiarioDetalle();

            oDetalle = new ResumenDiarioDetalle();
            oDetalle.Codigo_Documento = Constantes.BOLETA_VENTA;
            oDetalle.Serie_Documento = "B001";
            oDetalle.Numero_Documento = "1";
            oDetalle.TipoDoc_Receptor = "1";
            oDetalle.NroDoc_Receptor = "12345678";
            oDetalle.Importe_Gravado = Convert.ToDecimal("100.00");
            oDetalle.Importe_Exonerado = Convert.ToDecimal("0.00");
            oDetalle.Importe_Inafecto = Convert.ToDecimal("0.00");
            oDetalle.Importe_Gratuito = Convert.ToDecimal("0.00");
            oDetalle.Importe_OtrosCargos = Convert.ToDecimal("0.00");
            oDetalle.Importe_IGV = 100m * ( Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]) / 100m);
            oDetalle.Importe_ISC = Convert.ToDecimal("0.00");
            oDetalle.Importe_OtrosTributos = Convert.ToDecimal("0.00");
            oDetalle.Importe_Total = 100m * (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100m));

            oDetalle.Importe_Percepcion = 0;
            oDetalle.Base_Percepcion = 0;
            oDetalle.Regimen_Percepcion = "";
            oDetalle.Tasa_Percepcion = 0;
            oDetalle.Estado = "1";

            oLstDetalle.Add(oDetalle);

            #endregion

            //-- AGREGAR LA LISTA DE ITEMS
            oCabecera.LstResumenDetalle = oLstDetalle;

            #endregion

            //-- METODO PARA GENERACION, TICKET Y ALMACENAMIENTO DEL ARCHIVO XML
            oRESPUESTA = new RespuestaSunat();
            oRESPUESTA = oGENERAR_ARCHIVO.GenerarResumenDiario(oCabecera, false);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('" + ex.Message.ToString() + "','Generar resumen diario');", true);
            return;
        }
    }

    private void mcp_generar_comunicacion_de_baja()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;
        string[] valores = gNumDocuGenerado.Split('-');

        String lstrDigestValue = "";
        String lstrRutaCDR = "";
        String lstrRutaXML = "";
        String lstrRutaPDF = "";
        String lstrTicket = "";

        try
        {
            #region DATOS DE LA BAJA

            #region CABECERA

            BajaCabecera oCabecera = new BajaCabecera();
            oCabecera.TipoDoc_Emisor = "6";
            oCabecera.NroDoc_Emisor = oRUC;
            oCabecera.RSocial_Emisor = oRAZONSOCIAL;
            oCabecera.NombreCorto_Emisor = "-";
            oCabecera.Fecha_Emision = DateTime.Now;
            oCabecera.Identificador = "RA-" + DateTime.Now.ToString("yyyyMMdd") + "-" + gFacCorrelaComBaja.ToString();
            oCabecera.Fecha_Baja = DateTime.Now;

            #endregion

            #region DETALLE

            List<BajaDetalle> oLstDetalle = new List<BajaDetalle>();

            BajaDetalle oDetalle = new BajaDetalle();
            oDetalle.Codigo_Documento = Constantes.FACTURA;
            oDetalle.Serie_Documento = valores[0];
            oDetalle.Numero_Documento = valores[1];
            oDetalle.Motivo_Baja = "CLIENTE SE EQUIVOCO AL DIGITAR SUS DATOS";// "DESCRIPCION DEL MOTIVO DE LA BAJA";

            oLstDetalle.Add(oDetalle);

            #endregion

            //-- AGREGAR LA LISTA DE ITEMS 
            oCabecera.LstBajaDetalle = oLstDetalle;

            #endregion

            //-- METODO PARA GENERACION, TICKET Y ALMACENAMIENTO DEL ARCHIVO XML              
            oRESPUESTA = new RespuestaSunat();
            oRESPUESTA = oGENERAR_ARCHIVO.GenerarComunicacionBaja(oCabecera, false);

            if (oRESPUESTA.DigestValue == null)
            {
                lstrDigestValue = "";
            }
            else
            {
                lstrDigestValue = oRESPUESTA.DigestValue;
            }

            if (oRESPUESTA.RutaCDR == null)
            {
                lstrRutaCDR = "";
            }
            else
            {
                lstrRutaCDR = oRESPUESTA.RutaCDR;
            }

            if (oRESPUESTA.RutaXML == null)
            {
                lstrRutaXML = "";
            }
            else
            {
                lstrRutaXML = oRESPUESTA.RutaXML;
            }

            if (oRESPUESTA.RutaPDF == null)
            {
                lstrRutaPDF = "";
            }
            else
            {
                lstrRutaPDF = oRESPUESTA.RutaPDF;
            }

            if (oRESPUESTA.Ticket == null)
            {
                lstrTicket = "";
            }
            else
            {
                lstrTicket = oRESPUESTA.Ticket;
            }

            ldtResponse = lobjProducto.grabarRespuestaComBajaSUNAT(gNumDocuGenerado, Convert.ToInt32(oRESPUESTA.Codigo), oRESPUESTA.Estado.ToString(), oRESPUESTA.Mensaje, lstrRutaXML, lstrTicket);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "toastr.error('" + ex.Message.ToString() + "','Generar comunicación de baja');", true);
            return;
        }
    }

    private void mcp_validar_documentos()
    {
        try
        {
            //-- ESTOS METODOS DE VALIDACION ESTAN IMPLICITOS EN LOS METODOS DE GENERACION.
            //-- PODRA HACER USO DE ELLOS DE FORMA SEPARADA EN CASO DECIDA  
            RespuestaSunat oRPR_1 = oGENERAR_ARCHIVO.ValidarComprobante(Constantes.FACTURA, "RUTA_XML", false);

            //-- ESTOS METODOS DE VALIDACION "NO" ESTAN IMPLICITOS EN LOS METODOS DE GENERACION.
            //-- SE RECOMIENDA EJECUTAR ESTOS METODOS UN DIA DESPUES DE HABER OBTENIDO EL NUMERO DE TICKET.
            RespuestaSunat oRPR_4 = oGENERAR_ARCHIVO.ValidarTicketBaja("NUMERO_TICKET", "RUTA_XML", false);
            RespuestaSunat oRPR_5 = oGENERAR_ARCHIVO.ValidarTicketResumen("NUMERO_TICKET", "RUTA_XML", false);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex.Message.ToString() + "');", true);
            return;
        }
    }

    #endregion

    void calcularMontoTotal()
    {
        DataTable dt;
        double montoAcum = 0.0;
        dt = Session["dtPedido"] as DataTable;

        if (dt.Rows.Count == 0)
        {
            txtMontoaPagar.Text = "0.00";
            txtMontoaPagar.Enabled = false;
            txtMontoaPagar.Font.Bold = true;
            txtMontoaPagar.ForeColor = Color.Red;
            //imgCocina.Visible = false;
            //btnEnviarCocina.Visible = false;
            return;
        }

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            montoAcum = montoAcum + Convert.ToDouble(dt.Rows[i]["numPrecioTot"].ToString());
        }

        if (montoAcum != 0)
        {
            txtMontoaPagar.Text = montoAcum.ToString("n2");
            txtMontoaPagar.Enabled = false;
            txtMontoaPagar.Font.Bold = true;
            txtMontoaPagar.ForeColor = Color.Red;
            //imgCocina.Visible = true;
            //btnEnviarCocina.Visible = true;
        }
    }
    void armarTablaPedidos()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("vchNumSecu");
        dt.Columns.Add("intCantidad");
        dt.Columns.Add("vchCodigo");
        dt.Columns.Add("vchDeItem");
        dt.Columns.Add("numPrecioUni");
        dt.Columns.Add("numPrecioTot");
        dt.Columns.Add("vchComentario");
        dt.Columns.Add("vchImpresion");

        Session["dtPedido"] = dt;
    }

    void armarTablaPedidos(Int32 pintordenID)
    {
        clsProducto lobjProducto = new clsProducto();
        //DataTable dt = new DataTable();

        DataTable dt = lobjProducto.obtenerDetalleOrden(pintordenID);

        //dt.Columns.Add("vchNumSecu");
        //dt.Columns.Add("intCantidad");
        //dt.Columns.Add("vchCodigo");
        //dt.Columns.Add("vchDeItem");
        //dt.Columns.Add("numPrecioUni");
        //dt.Columns.Add("numPrecioTot");
        //dt.Columns.Add("vchComentario");

        Session["dtPedido"] = dt;

        gdPedido.DataSource = dt;
        gdPedido.DataBind();
        gdPedido.Columns[0].Visible = false;
        calcularMontoTotal();
    }

    void obtenerDatosDocumentoVenta(String pstrNumDocu)
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;

        dtResponse = lobjProducto.obtenerDatosDocumentoVenta(pstrNumDocu);

        lblinfoDoc.Visible = true;
        txtNumDoc.Text = pstrNumDocu;
        txtNumDoc.Visible = true;
        ddlComprob.SelectedValue = dtResponse.Rows[0]["comprobanteTipDocu_1"].ToString();
        ddlComprob.Enabled = false;
        if (dtResponse.Rows[0]["vchEstadoSUNAT"].ToString().Equals("Aceptado") && dtResponse.Rows[0]["intCodigoSUNAT"].ToString().Equals("0") && dtResponse.Rows[0]["comprobanteTipDocu_1"].ToString().Equals("FAC"))
        {
            if (Session["Perfil"].ToString().Equals("Administrators"))
            {
                btnAnular.Visible = true;
            }
            else
            {
                btnAnular.Visible = false;
            }
        }
        else
        {
            btnAnular.Visible = false;
        }
        if (dtResponse.Rows[0]["comprobanteFlagDeclara"].ToString().Equals("S"))
        {
            chkEnviar.Checked = true;
        }
        else
        {
            chkEnviar.Checked = false;
        }
        if (ddlComprob.SelectedValue.Equals("FAC"))
        {
            lblRuc.Visible = true;
            txtRuc.Visible = true;
            txtRuc.Text = dtResponse.Rows[0]["comprobanteRUCCli"].ToString();
            txtRuc.Enabled = false;
            lblNombre.Text = "Razon Social";
            txtNombre.Text = dtResponse.Rows[0]["comprobanteNombreCli"].ToString();
            txtNombre.Enabled = false;
            txtDireccion.Text = dtResponse.Rows[0]["comprobanteDirecc"].ToString();
            txtDireccion.Enabled = false;
        }

        if (ddlComprob.SelectedValue.Equals("BOL"))
        {
            lblRuc.Visible = true;
            txtRuc.Visible = true;
            txtRuc.Text = dtResponse.Rows[0]["comprobanteRUCCli"].ToString();
            txtRuc.Enabled = false;
            lblNombre.Text = "Nombres";
            txtNombre.Text = dtResponse.Rows[0]["comprobanteNombreCli"].ToString();
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
        }
        ddlMedioPago.SelectedValue = dtResponse.Rows[0]["comprobanteMedioPago"].ToString();
        ddlMedioPago.Enabled = false;
        txtMontoaPagar.Text = Convert.ToDouble(dtResponse.Rows[0]["comprobanteTotal"].ToString()).ToString("n2");
        txtMontoaPagar.Enabled = false;
        txtEfectivo.Text = Convert.ToDouble(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()).ToString("n2");
        txtEfectivo.Enabled = false;
        txtVuelto.Text = (Convert.ToDouble(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()) - Convert.ToDouble(dtResponse.Rows[0]["comprobanteTotal"].ToString())).ToString("n2");
        txtVuelto.Enabled = false;
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
            cargarDataEmisor();
            //armarTablaPedidos();
            //cargarDataEmisor();
            armarTablaPedidos();
            armarTablaPedidos(Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()));
            if (!Request.QueryString["vchNumDocu"].ToString().Equals("-"))
            {
                obtenerDatosDocumentoVenta(Request.QueryString["vchNumDocu"].ToString());
            }
            if (Request.QueryString["vchEstado"].Equals("ANULADO"))
            {
                btnPagar.Visible = false;
                btnAnular.Visible = false;
                btnReImpresion.Visible = false;
            }
            if (Request.QueryString["vchEstado"].Equals("ACTIVO"))
            {
                btnPagar.Visible = true;
                btnAnular.Visible = false;
                btnReImpresion.Visible = false;
            }
            if (Request.QueryString["vchEstado"].Equals("PAGADO"))
            {
                btnPagar.Visible = false;
                //if (!Session["Perfil"].ToString().Equals("Administrators"))
                //{
                //    imgAnular.Visible = false;
                //    btnAnular.Visible = false;
                //}
                //else {
                //    if (ddlComprob.SelectedValue.Equals("FAC")) {
                //        imgAnular.Visible = true;
                //        btnAnular.Visible = true;
                //    }
                //}

                if (ddlComprob.SelectedValue.ToString().Equals("BOL"))
                {
                    btnReImpresion.Visible = false;
                }
                else
                {
                    btnReImpresion.Visible = false;
                }
            }

            try
            {
                if (!Request.QueryString["vchRuc"].ToString().Equals(""))
                {
                    clsProducto lobjProducto = new clsProducto();
                    DataTable ldtResponse;
                    ddlComprob.SelectedValue = "FAC";
                    lblRuc.Text = "RUC";
                    lblRuc.Visible = true;
                    txtRuc.Visible = true;
                    lblNombre.Text = "Razon Social";
                    chkEnviar.Checked = true;
                    chkEnviar.Disabled = true;
                    txtRuc.Text = Request.QueryString["vchRuc"].ToString();

                    ldtResponse = lobjProducto.obtenerDatosProveedorSunat(txtRuc.Text);

                    txtNombre.Text = ldtResponse.Rows[0]["vchRazonSocial"].ToString();
                    txtDireccion.Text = ldtResponse.Rows[0]["vchDireccion"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void ddlMedioPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lblMsgError.Text = "";
        if (ddlMedioPago.SelectedValue.Equals("EFECTIVO"))
        {
            txtEfectivo.Text = "";
            txtEfectivo.Enabled = true;
        }
        else
        {
            txtEfectivo.Text = txtMontoaPagar.Text;
            txtEfectivo.Enabled = false;
            txtVuelto.Text = "";
        }
    }
    protected void ddlComprob_SelectedIndexChanged(object sender, EventArgs e)
    {
        //lblMsgError.Text = "";
        if (ddlComprob.SelectedValue.Equals("FAC"))
        {
            lblRuc.Text = "RUC";
            lblRuc.Visible = true;
            txtRuc.Visible = true;
            txtRuc.Text = "";
            lblNombre.Text = "Razon Social";
            txtNombre.Text = "";
            chkEnviar.Checked = true;
            chkEnviar.Disabled = true;
        }

        if (ddlComprob.SelectedValue.Equals("BOL"))
        {
            lblRuc.Text = "DNI";
            txtRuc.Visible = true;
            txtRuc.Text = "";
            lblNombre.Text = "Nombres";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            chkEnviar.Checked = false;
            chkEnviar.Disabled = false;
        }
    }
    void generaComprobante()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable dtResponse;
        DataTable dtResponseSerie;
        DataTable ldtResponseActualizarSerie;
        DataTable dtResponseDocumento;
        DataTable dtResponseActualiza;
        String lstrFlagDeclara = "";
        Double ldblMontoPagar = 0.0;
        Double ldblMontoEfectivo = 0.0;

        if (ddlComprob.SelectedValue.ToString().Equals("FAC"))
        {
            if (txtRuc.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese el RUC!');", true);
                return;
            }
        }

        if (ddlComprob.SelectedValue.ToString().Equals("BOL"))
        {
            if (txtNombre.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese el nombre del Cliente!');", true);
                return;
            }
        }
        else
        {
            if (txtNombre.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese la Razon Social!');", true);
                return;
            }

            if (txtDireccion.Text.Trim().Equals(""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese la dirección!');", true);
                return;
            }
        }

        if (txtEfectivo.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese el monto con el que cancela!');", true);
            return;
        }

        try
        {
            ldblMontoPagar = Convert.ToDouble(txtMontoaPagar.Text);
            ldblMontoEfectivo = Convert.ToDouble(txtEfectivo.Text.Trim());
            //txtVuelto.Text = (ldblMontoPagar - ldblMontoEfectivo).ToString();
        }
        catch (Exception ex)
        {
            txtVuelto.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese un monto válido.');", true);
            return;
        }

        if (Convert.ToDouble(txtEfectivo.Text.Trim()) - Convert.ToDouble(txtMontoaPagar.Text) < 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe completar el monto a pagar.');", true);
            return;
        }

        if (chkEnviar.Checked)
            lstrFlagDeclara = "S";
        else
            lstrFlagDeclara = "N";

        //dtResponseSerie = lobjProducto.obtenerSerieDocumento(lstrFlagDeclara, ddlComprob.SelectedValue.ToString());

        //gNumDocuGenerado = dtResponseSerie.Rows[0]["vchTipDocumento"].ToString();
        gNumDocuGenerado = Request.QueryString["vchNumDocu"].ToString();
        hpLog.generarLog("Serie del comprobante : gNumDocuGenerado: " + gNumDocuGenerado);

        if (chkEnviar.Checked)
        {
            //imprimirComprobante(dtResponse,"N");
            if (ddlComprob.SelectedValue == "FAC")
            {
                oTipoComprobante = 1;
                mcp_generar_comprobante();
            }
            if (ddlComprob.SelectedValue == "BOL")
            {
                oTipoComprobante = 2;
                mcp_generar_comprobante();
            }
            hpLog.generarLog("Estado SUNAT: gstrEstado: " + gstrEstado);
            hpLog.generarLog("codigo SUNAT: gintCodRespuestaSunat: " + gintCodRespuestaSunat);
            hpLog.generarLog("mensaje SUNAT: gvchMensajeRespuesta: " + gvchMensajeRespuesta);
            if (gintCodRespuestaSunat == 0 && gstrEstado.Equals("Aceptado"))
            {
                //dtResponse = lobjProducto.generarComprobantePago(gNumDocuGenerado,
                                                             //ddlComprob.SelectedValue.ToString(),
                                                             //lstrFlagDeclara,
                                                             //txtRuc.Text.Trim(),
                                                             //txtNombre.Text.Trim(),
                                                             //ddlMedioPago.SelectedValue,
                                                             //Convert.ToDouble(txtMontoaPagar.Text),
                                                             //Convert.ToDouble(txtEfectivo.Text),
                                                             //Convert.ToInt32(Request.QueryString["vchOrdenID"].ToString()),
                                                             //Session["Usuario"].ToString(),
                                                             //txtDireccion.Text.Trim().ToUpper());

                ldtResponseActualizarSerie = lobjProducto.grabarRespuestaSUNAT(gNumDocuGenerado, gintCodRespuestaSunat, gstrDigestValue, gstrEstado, gvchMensajeRespuesta, gstrRutaCDR, gstrRutaPDF, gstrRutaXML, gstrTicket);
                //dtResponseDocumento = lobjProducto.actualizaDocumentoReferencia(Request.QueryString["vchNumDocu"].ToString(), gNumDocuGenerado);
                
                
                //PdfDocument lobjPdfDocument = new PdfDocument();
                //lobjPdfDocument.LoadFromFile(gstrRutaPDF);
                //lobjPdfDocument.PrintSettings.PrinterName = "CajaPri";
                //lobjPdfDocument.Print();
                //imprimirComprobante(dtResponse, "S");

                Response.Redirect("frmListadoMesasPagar");
            }
            else
            {
                if (!gstrEstado.Equals("Generado"))
                {
                    ldtResponseActualizarSerie = lobjProducto.grabarRespuestaSUNAT(gNumDocuGenerado, gintCodRespuestaSunat, gstrDigestValue, gstrEstado, gvchMensajeRespuesta, gstrRutaCDR, gstrRutaPDF, gstrRutaXML, gstrTicket);
                    // dtResponseActualiza = lobjProducto.actualizaSerieDocumento(ddlComprob.SelectedValue.ToString());
                }

                //lblMsgError.Text = gstrEstado + " - " + gvchMensajeRespuesta;
                return;
            }
        }
        else
        {
            Response.Redirect("frmListadoMesasPagar");
        }

    }

    void imprimirComprobante(DataTable dtResponse,
                             String copiaCliente)
    {
        DataTable dt;
        dt = Session["dtPedido"] as DataTable;
        decimal decMontoTotal = 0;
        //Creamos una instancia d ela clase CrearTicket
        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("RUC: 20601486718");
        ticket.TextoCentro("INVERSIONES Y NEGOCIOS GRIMALDINA & MARTIN E.I.R.L");
        ticket.TextoCentro("Av. Carlos Shuton Mza. Z1 Lote 10 C.P.");
        ticket.TextoCentro("Arequipa-Caylloma-Majes");
        ticket.TextoCentro("Cel. 979293445 - 989665180");
        ticket.TextoCentro("Tlf. (053) 328145");
        ticket.TextoCentro(dtResponse.Rows[0]["comprobanteTipDocu"].ToString());
        ticket.TextoCentro(dtResponse.Rows[0]["comprobanteNumDocu"].ToString());

        //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("Caja #1", dtResponse.Rows[0]["comprobanteTipDocu"] + " #" + dtResponse.Rows[0]["comprobanteNumDocu"]);
        ticket.lineasAsteriscos();

        //Sub cabecera.
        ticket.TextoIzquierda("");
        if (dtResponse.Rows[0]["comprobanteTipDocu"].ToString().Equals("FACTURA"))
        {
            ticket.TextoIzquierda("RUC: " + dtResponse.Rows[0]["comprobanteRUCCli"].ToString());
            ticket.TextoIzquierda("Razon Social: " + dtResponse.Rows[0]["comprobanteNombreCli"].ToString());
            ticket.TextoIzquierda("Dirección: " + dtResponse.Rows[0]["comprobanteDirecc"].ToString().ToUpper());
        }
        else
        {
            ticket.TextoIzquierda("CLIENTE: " + dtResponse.Rows[0]["comprobanteNombreCli"].ToString());
        }
        //ticket.TextoIzquierda("ATENDIÓ: " + Session["Usuario"]);
        //ticket.TextoIzquierda("CLIENTE: PUBLICO EN GENERAL");
        ticket.TextoIzquierda("");
        ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
        ticket.lineasAsteriscos();

        //Articulos a vender.
        ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            decMontoTotal = decMontoTotal + Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString());
            ticket.AgregaArticulo(dt.Rows[i]["vchDeItem"].ToString(),
                                  Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()),
                                  Convert.ToDecimal(dt.Rows[i]["numPrecioUni"].ToString()),
                                  Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString()));
        }
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        ticket.lineasIgual();

        //Resumen de la venta. Sólo son ejemplos
        ticket.AgregarTotales("         SUBTOTAL....S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteSubtotal"].ToString()));
        ticket.AgregarTotales("         IGV.........S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteIGV"].ToString()));//La M indica que es un decimal en C#
        ticket.AgregarTotales("        TOTAL.......S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteTotal"].ToString()));
        ticket.TextoIzquierda("");
        if (dtResponse.Rows[0]["comprobanteMedioPago"].ToString().Equals("EFECTIVO"))
        {
            ticket.AgregarTotales("         EFECTIVO....S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()));
            ticket.AgregarTotales("         VUELTO......S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()) - Convert.ToDecimal(dtResponse.Rows[0]["comprobanteTotal"].ToString()));
        }

        //Texto final del Ticket.
        //ticket.TextoIzquierda("");
        //ticket.lineasIgual();
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        if (copiaCliente.Equals("S"))
        {
            ticket.lineasIgual();
            //ticket.TextoCentro("<<Copia Cliente>>");
        }
        ticket.TextoIzquierda("");
        ticket.TextoCentro("¡GRACIAS POR SU VISITA!");
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("CajaPri");//Nombre de la impresora ticketera
    }

    protected void imgVolver_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("frmListadoMesasPagar");
    }

    void reImpresion()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        if (txtRuc.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese el RUC!');", true);
            return;
        }

        if (txtNombre.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese la Razon Social!');", true);
            return;
        }

        ldtResponse = lobjProducto.actualizarReimpresionDocu(txtNumDoc.Text,
                                                             txtRuc.Text.Trim().ToUpper(),
                                                             txtNombre.Text.Trim().ToUpper());
        //reImprimirComprobante(ldtResponse, "N");
        reImprimirComprobante(ldtResponse, "S");
    }

    void reImprimirComprobante(DataTable dtResponse,
                               String copiaCliente)
    {
        DataTable dt;
        dt = Session["dtPedido"] as DataTable;
        decimal decMontoTotal = 0;
        //Creamos una instancia d ela clase CrearTicket
        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("RUC: 20601486718");
        ticket.TextoCentro("INVERSIONES Y NEGOCIOS GRIMALDINA & MARTIN E.I.R.L");
        ticket.TextoCentro("Av. Carlos Shuton Mza. Z1 Lote 10 C.P.");
        ticket.TextoCentro("Arequipa-Caylloma-Majes");
        ticket.TextoCentro("Cel. 979293445 - 989665180");
        ticket.TextoCentro("Tlf. (053) 328145");
        ticket.TextoCentro(dtResponse.Rows[0]["comprobanteTipDocu"].ToString());
        ticket.TextoCentro(dtResponse.Rows[0]["comprobanteNumDocu"].ToString());

        //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("Caja #1", dtResponse.Rows[0]["comprobanteTipDocu"] + " #" + dtResponse.Rows[0]["comprobanteNumDocu"]);
        ticket.lineasAsteriscos();

        //Sub cabecera.
        ticket.TextoIzquierda("");
        if (dtResponse.Rows[0]["comprobanteTipDocu"].ToString().Equals("FACTURA"))
        {
            ticket.TextoIzquierda("RUC: " + txtRuc.Text.Trim());
            ticket.TextoIzquierda("Razon Social: " + txtNombre.Text.Trim().ToUpper());
            ticket.TextoIzquierda("Dirección: " + txtDireccion.Text.Trim().ToUpper());
        }
        else
        {
            ticket.TextoIzquierda("CLIENTE: " + txtNombre.Text.Trim().ToUpper());
        }
        //ticket.TextoIzquierda("ATENDIÓ: " + Session["Usuario"]);
        //ticket.TextoIzquierda("CLIENTE: PUBLICO EN GENERAL");
        ticket.TextoIzquierda("");
        ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
        ticket.lineasAsteriscos();

        //Articulos a vender.
        ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            decMontoTotal = decMontoTotal + Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString());
            ticket.AgregaArticulo(dt.Rows[i]["vchDeItem"].ToString(),
                                  Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()),
                                  Convert.ToDecimal(dt.Rows[i]["numPrecioUni"].ToString()),
                                  Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString()));
        }
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        ticket.lineasIgual();

        //Resumen de la venta. Sólo son ejemplos
        ticket.AgregarTotales("         SUBTOTAL....S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteSubtotal"].ToString()));
        ticket.AgregarTotales("         IGV.........S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteIGV"].ToString()));//La M indica que es un decimal en C#
        ticket.AgregarTotales("        TOTAL.......S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteTotal"].ToString()));
        ticket.TextoIzquierda("");
        if (dtResponse.Rows[0]["comprobanteMedioPago"].ToString().Equals("EFECTIVO"))
        {
            ticket.AgregarTotales("         EFECTIVO....S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()));
            ticket.AgregarTotales("         VUELTO......S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()) - Convert.ToDecimal(dtResponse.Rows[0]["comprobanteTotal"].ToString()));
        }

        //Texto final del Ticket.
        //ticket.TextoIzquierda("");
        //ticket.lineasIgual();
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        if (copiaCliente.Equals("S"))
        {
            ticket.lineasIgual();
            //ticket.TextoCentro("<<Copia Cliente>>");
        }
        ticket.TextoIzquierda("");
        ticket.TextoCentro("¡GRACIAS POR SU VISITA!");
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("CajaPri");//Nombre de la impresora ticketera
    }
    

    void anularDocumento()
    {
        clsProducto lobjProducto = new clsProducto();
        DataTable ldtResponse;

        ldtResponse = lobjProducto.anularDocumentoCli(txtNumDoc.Text,
                                                      Session["Usuario"].ToString());

        gNumDocuGenerado = txtNumDoc.Text;

        gFacCorrelaComBaja = Convert.ToInt32(ldtResponse.Rows[0]["comprobanteComBajaCorrela"].ToString());

        oTipoComprobante = 7;
        mcp_generar_comprobante();

        //ImprimirAnulacion(ldtResponse, "N");
    }

    void ImprimirAnulacion(DataTable dtResponse,
                           String copiaCliente)
    {
        DataTable dt;
        dt = Session["dtPedido"] as DataTable;
        decimal decMontoTotal = 0;
        //Creamos una instancia d ela clase CrearTicket
        CrearTicket ticket = new CrearTicket();
        //Ya podemos usar todos sus metodos
        ticket.AbreCajon();//Para abrir el cajon de dinero.

        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        //Datos de la cabecera del Ticket.
        ticket.TextoCentro("************ANULACION***********");
        ticket.TextoCentro("RUC: 20601486718");
        ticket.TextoCentro("INVERSIONES Y NEGOCIOS GRIMALDINA & MARTIN E.I.R.L");
        ticket.TextoCentro("Av. Carlos Shuton Mza. Z1 Lote 10 C.P.");
        ticket.TextoCentro("Arequipa-Caylloma-Majes");
        ticket.TextoCentro("Cel. 979293445 - 989665180");
        ticket.TextoCentro("Tlf. (053) 328145");
        ticket.TextoCentro(dtResponse.Rows[0]["comprobanteTipDocu"].ToString());
        ticket.TextoCentro(dtResponse.Rows[0]["comprobanteNumDocu"].ToString());

        //ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com");//Es el mio por si me quieren contactar ...
        //ticket.TextoIzquierda("");
        //ticket.TextoExtremos("Caja #1", dtResponse.Rows[0]["comprobanteTipDocu"] + " #" + dtResponse.Rows[0]["comprobanteNumDocu"]);
        ticket.lineasAsteriscos();

        //Sub cabecera.
        ticket.TextoIzquierda("");
        if (dtResponse.Rows[0]["comprobanteTipDocu"].ToString().Equals("FACTURA"))
        {
            ticket.TextoIzquierda("RUC: " + dtResponse.Rows[0]["comprobanteRUCCli"].ToString());
            ticket.TextoIzquierda("Razon Social: " + dtResponse.Rows[0]["comprobanteNombreCli"].ToString());
        }
        else
        {
            ticket.TextoIzquierda("CLIENTE: " + dtResponse.Rows[0]["comprobanteNombreCli"].ToString());
        }
        //ticket.TextoIzquierda("ATENDIÓ: " + Session["Usuario"]);
        //ticket.TextoIzquierda("CLIENTE: PUBLICO EN GENERAL");
        ticket.TextoIzquierda("");
        ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
        ticket.lineasAsteriscos();

        //Articulos a vender.
        ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        ticket.lineasAsteriscos();
        //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        //{
        //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        //}
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            decMontoTotal = decMontoTotal + Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString());
            ticket.AgregaArticulo(dt.Rows[i]["vchDeItem"].ToString(),
                                  Convert.ToInt32(dt.Rows[i]["intCantidad"].ToString()),
                                  Convert.ToDecimal(dt.Rows[i]["numPrecioUni"].ToString()),
                                  Convert.ToDecimal(dt.Rows[i]["numPrecioTot"].ToString()));
        }
        //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
        //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
        //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
        ticket.lineasIgual();

        //Resumen de la venta. Sólo son ejemplos
        ticket.AgregarTotales("         SUBTOTAL....S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteSubtotal"].ToString()));
        ticket.AgregarTotales("         IGV.........S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteIGV"].ToString()));//La M indica que es un decimal en C#
        ticket.AgregarTotales("        TOTAL.......S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteTotal"].ToString()));
        ticket.TextoIzquierda(" ");
        if (dtResponse.Rows[0]["comprobanteMedioPago"].ToString().Equals("EFECTIVO"))
        {
            ticket.AgregarTotales("         EFECTIVO....S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()));
            ticket.AgregarTotales("         VUELTO......S/.", Convert.ToDecimal(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()) - Convert.ToDecimal(dtResponse.Rows[0]["comprobanteTotal"].ToString()));
        }

        //Texto final del Ticket.
        //ticket.TextoIzquierda("");
        //ticket.lineasIgual();
        //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + gdPedido.Rows.Count.ToString());
        if (copiaCliente.Equals("S"))
        {
            ticket.lineasIgual();
            //ticket.TextoCentro("<<Copia Cliente>>");
        }
        ticket.TextoIzquierda("");
        ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("");
        ticket.TextoIzquierda("");
        //ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
        ticket.CortaTicket();
        ticket.ImprimirTicket("CajaPri");//Nombre de la impresora ticketera
    }

    
    protected void txtEfectivo_TextChanged(object sender, EventArgs e)
    {
        Double ldblMontoEfectivo = 0.0;
        Double ldblMontoPagar = 0.0;

        ldblMontoPagar = Convert.ToDouble(txtMontoaPagar.Text);

        //lblMsgError.Text = "";

        if (txtEfectivo.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Por favor completo el monto con el que pagan.');", true);
        }

        try
        {
            ldblMontoEfectivo = Convert.ToDouble(txtEfectivo.Text.Trim());
        }
        catch (Exception )
        {
            txtVuelto.Text = "";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese un valor válido.');", true);
            //return;
        }

        txtVuelto.Text = (ldblMontoEfectivo - ldblMontoPagar).ToString("n2");

    }
    protected void txtRuc_TextChanged(object sender, EventArgs e)
    {
        if (!txtRuc.Text.Trim().Equals(""))
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;

            ldtResponse = lobjProducto.obtenerDatosxRuc(txtRuc.Text.Trim());

            if (ldtResponse.Rows.Count == 0)
            {
                txtNombre.Text = "";
                txtDireccion.Text = "";
            }
            else
            {
                txtNombre.Text = ldtResponse.Rows[0]["comprobanteNombreCli"].ToString();
                txtDireccion.Text = ldtResponse.Rows[0]["comprobanteDirecc"].ToString(); ;
            }
        }
    }

  

    protected void btnPagar_Click(object sender, EventArgs e)
    {
        hpLog.generarLog("INICIO - REENVIO COMPROBANTES GENERADOS A SUNAT");
        if (chkEnviar.Checked)
        {
            if (ddlComprob.SelectedValue.Equals("BOL"))
            {
                if (txtRuc.Text.Trim().Equals(""))
                {
                    //lblMsgError.Text = "El DNI no puede estar vacío!";
                    return;
                }
                if (txtRuc.Text.Trim().Length != 8)
                {
                    //lblMsgError.Text = "El DNI debe tener 8 dígitos!";
                    return;
                }
                if (txtNombre.Text.Trim().Equals(""))
                {
                    //lblMsgError.Text = "Debe escribir el nombre del cliente";
                    return;
                }
            }

            if (ddlComprob.SelectedValue.Equals("FAC"))
            {
                if (txtRuc.Text.Trim().Equals(""))
                {
                    //lblMsgError.Text = "El RUC no puede estar vacío!";
                    return;
                }
                if (txtRuc.Text.Trim().Length != 11)
                {
                    //lblMsgError.Text = "El RUC debe tener 11 dígitos!";
                    return;
                }
                if (txtNombre.Text.Trim().Equals(""))
                {
                    //lblMsgError.Text = "Debe escribir la razon social del cliente";
                    return;
                }
                if (txtDireccion.Text.Trim().Equals(""))
                {
                    //lblMsgError.Text = "Debe escribir la dirección del cliente')";
                    return;
                }
            }
        }
        generaComprobante();
    }

    protected void btnAnular_Click(object sender, EventArgs e)
    {
        anularDocumento();
        Response.Redirect("frmListadoPedidosxPagar");
    }

    protected void imgBuscar_Click(object sender, EventArgs e)
    {
        //if (txtRuc.Text.Trim().Equals("")) {
        //    lblMsgError.Text = "El ruc no debe estar vacio!";
        //    return;
        //}

        //if (txtRuc.Text.Trim().Length != 11)
        //{
        //    lblMsgError.Text = "El ruc debe tener 11 dígitos!";
        //    return;
        //}

        if (ddlComprob.SelectedValue.Equals("FAC"))
        {
            Response.Redirect("http://192.168.0.110:9091/frmConsultaSunat?&ordenID=" + Request.QueryString["vchOrdenID"].ToString());
        }
        if (ddlComprob.SelectedValue.Equals("BOL"))
        {
            if (!txtRuc.Text.Trim().Equals(""))
            {
                clsProducto lobjProducto = new clsProducto();
                DataTable ldtResponse;

                ldtResponse = lobjProducto.obtenerDatosxRuc(txtRuc.Text.Trim());

                if (ldtResponse.Rows.Count == 0)
                {
                    txtNombre.Text = "";
                    txtDireccion.Text = "";
                }
                else
                {
                    txtNombre.Text = ldtResponse.Rows[0]["comprobanteNombreCli"].ToString();
                    txtDireccion.Text = ldtResponse.Rows[0]["comprobanteDirecc"].ToString();
                }
            }
        }
    }
    protected void btnReImpresion_Click(object sender, EventArgs e)
    {
        reImpresion();
    }
}