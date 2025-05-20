using bussinessLayer;
using Common;
using GMT_Sfe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace WebSites.Utils
{
    public class EnvioSunat
    {
        #region [ variables ]
        HelperLog hpLog = new HelperLog();
        Int32 gintCodRespuestaSunat = 0;
        String gstrDigestValue = "";
        String gstrEstado = "";
        String gvchMensajeRespuesta = "";
        String gstrRutaCDR = "";
        String gstrRutaXML = "";
        String gstrRutaPDF = "";
        String gstrTicket = "";
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

        #endregion

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
        public async Task enviarPendientes(int id)
        {
            cargarDataEmisor();
            clsProducto lobjProducto = new clsProducto();
            DataTable dtResponse = lobjProducto.obtenerListadoStatusSUNAT("",id);
            foreach (DataRow row in dtResponse.Rows)
            {
                DataTable dtPedido = new DataTable();
                int ordenID = int.Parse(row["ordenID"].ToString());
                string vchNumDocu = row["comprobanteNumDocu"].ToString();
                string MontoaPagar = MontoPagarTotal(ordenID, ref dtPedido);

                dtResponse = lobjProducto.obtenerDatosDocumentoVenta(vchNumDocu);

                string Comprob = dtResponse.Rows[0]["comprobanteTipDocu_1"].ToString();
                string Ruc = dtResponse.Rows[0]["comprobanteRUCCli"].ToString();
                string Nombre = dtResponse.Rows[0]["comprobanteNombreCli"].ToString();
                string Direccion = dtResponse.Rows[0]["comprobanteDirecc"].ToString();
                string MedioPago = dtResponse.Rows[0]["comprobanteMedioPago"].ToString();
                MontoaPagar = Convert.ToDouble(dtResponse.Rows[0]["comprobanteTotal"].ToString()).ToString("n2");
                string Efectivo = Convert.ToDouble(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()).ToString("n2");
                string Vuelto = (Convert.ToDouble(dtResponse.Rows[0]["comprobanteMontoPagado"].ToString()) - Convert.ToDouble(dtResponse.Rows[0]["comprobanteTotal"].ToString())).ToString("n2");

                hpLog.generarLog("Serie del comprobante : gNumDocuGenerado: " + vchNumDocu);
                if (Comprob.Equals("FAC"))
                    mcp_generar_factura(vchNumDocu, MontoaPagar, Comprob, Ruc, Nombre, Direccion, MedioPago, Efectivo, Vuelto, dtPedido);
                else if (Comprob.Equals("BOL"))
                    mcp_generar_boleta_venta(vchNumDocu, MontoaPagar, Comprob, Ruc, Nombre, Direccion, MedioPago, Efectivo, Vuelto, dtPedido);

                hpLog.generarLog("Estado SUNAT: gstrEstado: " + gstrEstado);
                hpLog.generarLog("codigo SUNAT: gintCodRespuestaSunat: " + gintCodRespuestaSunat);
                hpLog.generarLog("mensaje SUNAT: gvchMensajeRespuesta: " + gvchMensajeRespuesta);

                lobjProducto.grabarRespuestaSUNAT(vchNumDocu, gintCodRespuestaSunat, gstrDigestValue, gstrEstado, gvchMensajeRespuesta, gstrRutaCDR, gstrRutaPDF, gstrRutaXML, gstrTicket);
                
            }
        }
        private string MontoPagarTotal(int ordenID,ref DataTable dtPedido)
        {
            clsProducto lobjProducto = new clsProducto();
            double montoAcum = 0.0;
            dtPedido = lobjProducto.obtenerDetalleOrden(ordenID);
            if (dtPedido.Rows.Count == 0)
                return "0.00";

            for (int i = 0; i <= dtPedido.Rows.Count - 1; i++)
                montoAcum = montoAcum + Convert.ToDouble(dtPedido.Rows[i]["numPrecioTot"].ToString());

            if (montoAcum != 0)
                return montoAcum.ToString("n2");
            else
                return "0.00";


        }
        private void mcp_generar_factura(string vchNumDocu, string MontoaPagar, string Comprob, 
            string Ruc, string Nombre, string Direccion, string MedioPago, string Efectivo, string Vuelto, DataTable dtPedido)
        {
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;
            string[] valores = vchNumDocu.Split('-');
            Double dblMontoTotalsinIGV = 0.0;
            Double dblMontoTotalIGV = 0.0;
            Double dblMontoTotalconIGV = 0.0;

            String lstrDigestValue = "";
            String lstrRutaCDR = "";
            String lstrRutaXML = "";
            String lstrRutaPDF = "";
            String lstrTicket = "";

            dblMontoTotalsinIGV = Math.Round(Convert.ToDouble(MontoaPagar) / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
            dblMontoTotalIGV = Math.Round(Convert.ToDouble(MontoaPagar) - (Convert.ToDouble(MontoaPagar) / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00))), 2);
            dblMontoTotalconIGV = Math.Round(Convert.ToDouble(MontoaPagar), 2);



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
                oCabecera.NroDoc_Receptor = Ruc.Trim();
                oCabecera.RSocial_Receptor = Nombre.Trim().ToUpper();
                oCabecera.Direccion_Receptor = Direccion.Trim().ToUpper();

                oCabecera.Codigo_Documento = Constantes.FACTURA;
                oCabecera.Serie_Documento = valores[0];
                oCabecera.Numero_Documento = valores[1];
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

                oCabecera.Importe_Gravado = Convert.ToDecimal(dblMontoTotalsinIGV);
                oCabecera.Importe_Exonerado = Convert.ToDecimal("0.00");
                oCabecera.Importe_Inafecto = Convert.ToDecimal("0.00");
                oCabecera.Importe_Gratuito = Convert.ToDecimal("0.00");
                oCabecera.Importe_SubTotal = Convert.ToDecimal(dblMontoTotalsinIGV);
                oCabecera.Importe_ValorVenta = Convert.ToDecimal(dblMontoTotalsinIGV); 
                oCabecera.Importe_Descuento = Convert.ToDecimal("0.00");
                oCabecera.Importe_IGV = Convert.ToDecimal(dblMontoTotalIGV); 
                oCabecera.Importe_ISC = Convert.ToDecimal("0.00");
                oCabecera.Importe_Total = Convert.ToDecimal(dblMontoTotalconIGV);
                oCabecera.Importe_Cobrado = Convert.ToDecimal(dblMontoTotalconIGV);
                oCabecera.Importe_OtrosCargos = Convert.ToDecimal("0.00");
                oCabecera.Importe_OtrosTributos = Convert.ToDecimal("0.00");

                oCabecera.Importe_Percepcion = Convert.ToDecimal("0.00");
                oCabecera.Codigo_Percepcion = "";
                oCabecera.Porcentaje_Percepcion = Convert.ToDecimal("0.00");
                oCabecera.Base_Percepcion = Convert.ToDecimal("0.00");

                oCabecera.PorcentajeIGV = 100m * (Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]) / 100m);
                oCabecera.Importe_Base_ISC = Convert.ToDecimal("0.00");
                oCabecera.Importe_Base_OtrosTributos = Convert.ToDecimal("0.00");



                oCabecera.Texto_Importe_Total = NumberToText.Convertir_Valor(Convert.ToDecimal(dblMontoTotalconIGV)).ToUpper();

                #endregion

                #region DETALLE

                List<ComprobanteDetalle> oLstDetalle = new List<ComprobanteDetalle>();

                for (int i = 0; i <= dtPedido.Rows.Count - 1; i++)
                {
                    ComprobanteDetalle oDetalle = new ComprobanteDetalle();
                    double dblCantidad = 0.0;
                    double dblPrecioUniSinIGV = 0.0;
                    double dblPrecioUni = 0.0;
                    double dblPrecioTotal = 0.0;
                    double dblPrecioTotalSinIGV = 0.0;
                    double dblMontoIGV = 0.0;

                    dblCantidad = Math.Round(Convert.ToDouble(dtPedido.Rows[i]["intCantidad"].ToString()), 2);
                    dblPrecioUni = Math.Round(Convert.ToDouble(dtPedido.Rows[i]["numPrecioTot"].ToString()) / Convert.ToDouble(dtPedido.Rows[i]["intCantidad"].ToString()), 2);
                    dblPrecioUniSinIGV = Math.Round(dblPrecioUni / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
                    dblPrecioTotal = Math.Round(Convert.ToDouble(dtPedido.Rows[i]["numPrecioTot"].ToString()), 2);
                    dblPrecioTotalSinIGV = Math.Round(dblPrecioTotal / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
                    dblMontoIGV = Math.Round(dblPrecioTotal - dblPrecioTotalSinIGV, 2);

                    oDetalle.NroItem = (i + 1).ToString(); //"1";
                    oDetalle.Codigo_Articulo = dtPedido.Rows[i]["vchCodigo"].ToString();
                    oDetalle.Codigo_Unidad = "C62";
                    oDetalle.Descripcion_Articulo = dtPedido.Rows[i]["vchDeItem"].ToString().ToUpper();
                    oDetalle.Cantidad = Convert.ToDecimal(dtPedido.Rows[i]["intCantidad"].ToString());
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

                #region FORMA-DE-PAGO

                List<FacturaFormaPago> oLstFormaPago = new List<FacturaFormaPago>();

                FacturaFormaPago oFormaPago = new FacturaFormaPago();
                oFormaPago.Forma_Pago = "Contado"; //Credito / Contado
                oFormaPago.Codigo_Moneda = "PEN";
                oFormaPago.Monto_Neto = Convert.ToDecimal(dblMontoTotalconIGV);
                oLstFormaPago.Add(oFormaPago);

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

            }
            catch (Exception ex)
            {
                hpLog.generarLog("Error: " + ex.Message.ToString());
            }
        }

        private void mcp_generar_boleta_venta(string vchNumDocu, string MontoaPagar, string Comprob,
            string Ruc, string Nombre, string Direccion, string MedioPago, string Efectivo, string Vuelto, DataTable dtPedido)
        {
            //PrintDocument lobjPrinter;
            clsProducto lobjProducto = new clsProducto();
            DataTable ldtResponse;
            string[] valores = vchNumDocu.Split('-');
            Double dblMontoTotalsinIGV = 0.0;
            Double dblMontoTotalIGV = 0.0;
            Double dblMontoTotalconIGV = 0.0;

            String lstrDigestValue = "";
            String lstrRutaCDR = "";
            String lstrRutaXML = "";
            String lstrRutaPDF = "";
            String lstrTicket = "";

            dblMontoTotalsinIGV = Math.Round(Convert.ToDouble(MontoaPagar) / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
            dblMontoTotalIGV = Math.Round(Convert.ToDouble(MontoaPagar) - (Convert.ToDouble(MontoaPagar) / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00))), 2);
            dblMontoTotalconIGV = Math.Round(Convert.ToDouble(MontoaPagar), 2);


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

                oCabecera.TipoDoc_Receptor = "1";
                oCabecera.NroDoc_Receptor = Ruc.Trim(); 
                if (Nombre.Trim().ToUpper().Trim().Equals(".") || Nombre.Trim().ToUpper().Trim().Equals(""))
                {
                    oCabecera.RSocial_Receptor = "CLIENTE";
                }
                else
                {
                    oCabecera.RSocial_Receptor = Nombre.Trim().ToUpper();
                }
                oCabecera.Direccion_Receptor = Direccion.Trim().ToUpper();

                oCabecera.Codigo_Documento = Constantes.BOLETA_VENTA;
                oCabecera.Serie_Documento = valores[0];
                oCabecera.Numero_Documento = valores[1];
                oCabecera.Fecha_Emision = DateTime.Now;
                oCabecera.Hora_Emision = DateTime.Now.ToString("hh:mm:ss");

                oCabecera.Tipo_Venta = "L";
                oCabecera.Codigo_Moneda = "PEN";
                oCabecera.Sigla_Moneda = "S/";

                oCabecera.Porcentaje_Detraccion = 0;
                oCabecera.Codigo_Detraccion = "";
                oCabecera.Importe_Detraccion = 0;
                oCabecera.NroCuenta_Detraccion = "";

                oCabecera.Importe_Gravado = Convert.ToDecimal(dblMontoTotalsinIGV);
                oCabecera.Importe_Exonerado = Convert.ToDecimal("0.00");
                oCabecera.Importe_Inafecto = Convert.ToDecimal("0.00");
                oCabecera.Importe_Gratuito = Convert.ToDecimal("0.00");
                oCabecera.Importe_SubTotal = Convert.ToDecimal(dblMontoTotalsinIGV);
                oCabecera.Importe_ValorVenta = Convert.ToDecimal(dblMontoTotalsinIGV);
                oCabecera.Importe_Descuento = Convert.ToDecimal("0.00");
                oCabecera.Importe_IGV = Convert.ToDecimal(dblMontoTotalIGV);
                oCabecera.Importe_ISC = Convert.ToDecimal("0.00");
                oCabecera.Importe_Total = Convert.ToDecimal(dblMontoTotalconIGV);
                oCabecera.Importe_Cobrado = Convert.ToDecimal(dblMontoTotalconIGV);
                oCabecera.Importe_OtrosCargos = Convert.ToDecimal("0.00");
                oCabecera.Importe_OtrosTributos = Convert.ToDecimal("0.00");

                oCabecera.Importe_Percepcion = Convert.ToDecimal("0.00");
                oCabecera.Codigo_Percepcion = "";
                oCabecera.Porcentaje_Percepcion = Convert.ToDecimal("0.00");
                oCabecera.Base_Percepcion = Convert.ToDecimal("0.00");

                oCabecera.PorcentajeIGV = Convert.ToDecimal(ConfigurationManager.AppSettings["IGV"]);
                oCabecera.Importe_Base_ISC = Convert.ToDecimal("0.00");
                oCabecera.Importe_Base_OtrosTributos = Convert.ToDecimal("0.00");

                oCabecera.Texto_Importe_Total = NumberToText.Convertir_Valor(Convert.ToDecimal(dblMontoTotalconIGV)).ToUpper();

                #endregion

                #region DETALLE

                List<ComprobanteDetalle> oLstDetalle = new List<ComprobanteDetalle>();

                for (int i = 0; i <= dtPedido.Rows.Count - 1; i++)
                {
                    ComprobanteDetalle oDetalle = new ComprobanteDetalle();
                    double dblCantidad = 0.0;
                    double dblPrecioUniSinIGV = 0.0;
                    double dblPrecioUni = 0.0;
                    double dblPrecioTotal = 0.0;
                    double dblPrecioTotalSinIGV = 0.0;
                    double dblMontoIGV = 0.0;

                    dblCantidad = Math.Round(Convert.ToDouble(dtPedido.Rows[i]["intCantidad"].ToString()), 2);
                    dblPrecioUni = Math.Round(Convert.ToDouble(dtPedido.Rows[i]["numPrecioTot"].ToString()) / Convert.ToDouble(dtPedido.Rows[i]["intCantidad"].ToString()), 2);
                    dblPrecioUniSinIGV = Math.Round(dblPrecioUni / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
                    dblPrecioTotal = Math.Round(Convert.ToDouble(dtPedido.Rows[i]["numPrecioTot"].ToString()), 2);
                    dblPrecioTotalSinIGV = Math.Round(dblPrecioTotal / (1 + (Convert.ToInt16(ConfigurationManager.AppSettings["IGV"]) / 100.00)), 2);
                    dblMontoIGV = Math.Round(dblPrecioTotal - dblPrecioTotalSinIGV, 2);

                    oDetalle.NroItem = (i + 1).ToString(); //"1";
                    oDetalle.Codigo_Articulo = dtPedido.Rows[i]["vchCodigo"].ToString();
                    oDetalle.Codigo_Unidad = "C62";
                    oDetalle.Descripcion_Articulo = dtPedido.Rows[i]["vchDeItem"].ToString().ToUpper();
                    oDetalle.Cantidad = Convert.ToDecimal(dtPedido.Rows[i]["intCantidad"].ToString());
                    oDetalle.Precio_Unitario_SinIGV = Convert.ToDecimal(dblPrecioUniSinIGV);
                    oDetalle.Precio_Unitario_ConIGV = Convert.ToDecimal(dblPrecioUni);
                    oDetalle.Importe_SubTotal = Convert.ToDecimal(dblPrecioTotalSinIGV);
                    oDetalle.Importe_Descuento = Convert.ToDecimal("0.00");
                    oDetalle.Importe_ValorVenta = Convert.ToDecimal(dblPrecioTotalSinIGV);
                    oDetalle.Importe_IGV = Convert.ToDecimal(dblMontoIGV);
                    oDetalle.Importe_ISC = Convert.ToDecimal("0.00");
                    oDetalle.Importe_Total = Convert.ToDecimal(dblPrecioTotal);

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
                hpLog.generarLog("Error: " + ex.Message.ToString());
            }
        }

    }
}