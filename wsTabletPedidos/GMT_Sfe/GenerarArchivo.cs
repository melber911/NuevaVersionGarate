using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Common;
using Ionic.Zip;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;

namespace GMT_Sfe
{
    public class GenerarArchivo
    {
        private XmlSerializerNamespaces XMLNamespace = new XmlSerializerNamespaces();
        private XmlSerializerNamespaces XMLNamespaceExt = new XmlSerializerNamespaces();
        private XmlSerializer XMLSerializerFact = new XmlSerializer(typeof(InvoiceType));
        private XmlSerializer XMLSerializerNCred = new XmlSerializer(typeof(CreditNoteType));
        private XmlSerializer XMLSerializerNDeb = new XmlSerializer(typeof(DebitNoteType));
        private XmlSerializer XMLSerializerBolVta = new XmlSerializer(typeof(InvoiceType));
        private XmlSerializer XMLSerializerBaja = new XmlSerializer(typeof(VoidedDocumentsType));
        private XmlSerializer XMLSerializerResumen = new XmlSerializer(typeof(SummaryDocumentsType));
        private XmlSerializer XMLSerializerDespatchAdvice = new XmlSerializer(typeof(DespatchAdviceType));
        private InvoiceType XMLInvoice = new InvoiceType();
        private CreditNoteType XMLCreditNote = new CreditNoteType();
        private DebitNoteType XMLDebitNote = new DebitNoteType();
        private InvoiceType XMLBoletaVta = new InvoiceType();
        private VoidedDocumentsType XMLVoidedDocuments = new VoidedDocumentsType();
        private SummaryDocumentsType XMLSummaryDocuments = new SummaryDocumentsType();
        private RetentionType XMLRetention = new RetentionType();
        private PerceptionType XMLPerception = new PerceptionType();
        private DespatchAdviceType XMLDespatchAdvice = new DespatchAdviceType();
        private UBLExtensionType[] oLstUBLExtensionType = new UBLExtensionType[2];
        private BasicHttpBinding binding = (BasicHttpBinding)null;
        private bool bEsValidacion = false;
        private List<string> oLstCarpetas = new List<string>()
        {
            "FACTURA",
            "BOLETA",
            "NOTACREDITO",
            "NOTADEBITO",
            "COMUNICACIONBAJA",
            "RESUMENDIARIO",
            "GUIAREMISION"
        };
        private CuentaSunat oCuentaSunat = new CuentaSunat();
        private Certificado oCertificado = new Certificado();
        private string RUTA_BOLETA = (string)null;
        private string RUTA_COMUNICACIONBAJA = (string)null;
        private string RUTA_FACTURA = (string)null;
        private string RUTA_NOTACREDITO = (string)null;
        private string RUTA_NOTADEBITO = (string)null;
        private string RUTA_RESUMENDIARIO = (string)null;
        private string RUTA_GUIAREMISION = (string)null;
        private string URL_SUNAT_OSE = (string)null;
        private string URL_SUNAT_FE = (string)null;
        private string URL_SUNAT_CO = (string)null;
        private string URL_SUNAT_GR = (string)null;
        private string IGV = (string)null;
        private string NRO_RESOLUCION = (string)null;
        private string LINK_DESCARGA_ARCHIVOS = (string)null;
        private HelperLog hpLog = new HelperLog();
        public GenerarArchivo()
        {
        }

        public GenerarArchivo(string pRucEmisor, CuentaSunat pCuentaSunat, Certificado pCertificado)
        {
            ServicePointManager.UseNagleAlgorithm = true;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            new WebProxy("https://www.sunat.gob.pe", 443).Credentials = CredentialCache.DefaultCredentials;
            this.binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            this.binding.OpenTimeout = new TimeSpan(0, 2, 0);
            this.binding.CloseTimeout = new TimeSpan(0, 2, 0);
            this.binding.SendTimeout = new TimeSpan(0, 2, 0);
            this.binding.ReceiveTimeout = new TimeSpan(0, 2, 0);
            this.binding.AllowCookies = false;
            this.binding.BypassProxyOnLocal = false;
            this.binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            this.binding.MaxBufferSize = 30000000;
            this.binding.MaxBufferPoolSize = 30000000L;
            this.binding.MaxReceivedMessageSize = 30000000L;
            this.binding.MessageEncoding = WSMessageEncoding.Text;
            this.binding.TextEncoding = Encoding.UTF8;
            this.binding.TransferMode = TransferMode.Buffered;
            this.binding.UseDefaultWebProxy = true;
            this.binding.ReaderQuotas.MaxDepth = 30000000;
            this.binding.ReaderQuotas.MaxStringContentLength = 30000000;
            this.binding.ReaderQuotas.MaxArrayLength = 30000000;
            this.binding.ReaderQuotas.MaxBytesPerRead = 30000000;
            this.binding.ReaderQuotas.MaxNameTableCharCount = 30000000;
            this.binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            this.binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
            this.binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            this.binding.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Default;
            this.oCuentaSunat = pCuentaSunat;
            this.oCertificado = pCertificado;
            this.ValidarRutas(pRucEmisor);
            this.URL_SUNAT_OSE = ConfigurationManager.AppSettings["URL_SNT_OSE"];
            this.URL_SUNAT_FE = ConfigurationManager.AppSettings["URL_SNT_FE"];
            this.URL_SUNAT_CO = ConfigurationManager.AppSettings["URL_SNT_CO"];
            this.URL_SUNAT_GR = ConfigurationManager.AppSettings["URL_SNT_GR"];
            this.IGV = ConfigurationManager.AppSettings["IGV"];
            this.NRO_RESOLUCION = ConfigurationManager.AppSettings["NRO_RESOLUCION"];
            this.LINK_DESCARGA_ARCHIVOS = ConfigurationManager.AppSettings["LINK_DESCARGA_ARCHIVOS"];
        }

        private void SetXML()
        {
            this.XMLNamespace.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            this.XMLNamespace.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            this.XMLNamespace.Add("ccts", "urn:un:unece:uncefact:documentation:2");
            this.XMLNamespace.Add("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
            this.XMLNamespace.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            this.XMLNamespace.Add("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
            this.XMLNamespace.Add("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1");
            this.XMLNamespace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            this.XMLNamespace.Add("xsd", "http://www.w3.org/2001/XMLSchema");
            this.XMLNamespace.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
            this.XMLNamespaceExt.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            this.XMLNamespaceExt.Add("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1");
        }

        public RespuestaSunat GenerarComprobante(ComprobanteCabecera oCabecera, bool bValidar, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();
            string rutaDocumento = string.Empty;

            try
            {
                this.SetXML();

                if (oCabecera.Codigo_Documento == "01")
                {
                    this.GeneraFactura(oCabecera, oCabecera.LstComprobanteDetalle, oCabecera.LstGuias, oCabecera.LstFormaPago);
                    rutaDocumento = this.RUTA_FACTURA;
                }
                else if (oCabecera.Codigo_Documento == "03")
                {
                    if (oCabecera.Importe_Detraccion > new Decimal(0))
                        throw new Exception("La boleta de venta no puede tener detracción");

                    this.GeneraBoletaVenta(oCabecera, oCabecera.LstComprobanteDetalle);
                    rutaDocumento = this.RUTA_BOLETA;
                }
                else if (oCabecera.Codigo_Documento == "07")
                {
                    if (oCabecera.Importe_Detraccion > new Decimal(0))
                        throw new Exception("La nota de crédito no puede tener detracción");
                    if (oCabecera.Importe_Anticipos > new Decimal(0))
                        throw new Exception("La nota de crédito no puede tener anticipos");
                    if (oCabecera.Importe_Percepcion > new Decimal(0))
                        throw new Exception("La nota de crédito no puede tener percepcion");

                    this.GeneraNotaCredito(oCabecera, oCabecera.LstComprobanteDetalle);
                    rutaDocumento = this.RUTA_NOTACREDITO;
                }
                else if (oCabecera.Codigo_Documento == "08")
                {
                    if (oCabecera.Importe_Detraccion > new Decimal(0))
                        throw new Exception("La nota de débito no puede tener detracción");
                    if (oCabecera.Importe_Anticipos > new Decimal(0))
                        throw new Exception("La nota de débito no puede tener anticipos");
                    if (oCabecera.Importe_Percepcion > new Decimal(0))
                        throw new Exception("La nota de débito no puede tener percepcion");

                    this.GeneraNotaDebito(oCabecera, oCabecera.LstComprobanteDetalle);
                    rutaDocumento = this.RUTA_NOTADEBITO;
                }

                string documentoXML = rutaDocumento + oCabecera.NroDoc_Emisor + "-" + oCabecera.Codigo_Documento + "-" + oCabecera.Serie_Documento + "-" + oCabecera.Numero_Documento + ".xml";

                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    ConformanceLevel = ConformanceLevel.Auto,
                    Indent = true,
                    IndentChars = "\t",
                    Encoding = Encoding.GetEncoding("ISO-8859-1")
                };

                if (System.IO.File.Exists(documentoXML))
                    System.IO.File.Delete(documentoXML);

                using (XmlWriter xmlWriter = XmlWriter.Create(documentoXML, settings))
                {
                    if (oCabecera.Codigo_Documento == "01")
                        this.XMLSerializerFact.Serialize(xmlWriter, (object)this.XMLInvoice, this.XMLNamespace);
                    else if (oCabecera.Codigo_Documento == "07")
                        this.XMLSerializerNCred.Serialize(xmlWriter, (object)this.XMLCreditNote, this.XMLNamespace);
                    else if (oCabecera.Codigo_Documento == "08")
                        this.XMLSerializerNDeb.Serialize(xmlWriter, (object)this.XMLDebitNote, this.XMLNamespace);
                    else if (oCabecera.Codigo_Documento == "03")
                        this.XMLSerializerBolVta.Serialize(xmlWriter, (object)this.XMLBoletaVta, this.XMLNamespace);
                }

                this.GenerarFirma(documentoXML, 0);

                if (bValidar)
                {
                    respuestaSunat = this.ValidarComprobante(oCabecera.Codigo_Documento, documentoXML, bOSE);
                }
                else
                {
                    respuestaSunat.Codigo = "0";
                    respuestaSunat.Mensaje = "Válidado";
                    respuestaSunat.RutaXML = documentoXML;
                    respuestaSunat.Estado = Estado.Aceptado;
                }

                if (!string.IsNullOrEmpty(respuestaSunat.RutaXML) && System.IO.File.Exists(respuestaSunat.RutaXML))
                {
                    respuestaSunat.DigestValue = this.ObtenerDigestValue(oCabecera.Codigo_Documento, respuestaSunat.RutaXML);
                    respuestaSunat.SignatureValue = this.ObtenerSignatureValue(oCabecera.Codigo_Documento, respuestaSunat.RutaXML);
                }
            }
            catch (Exception ex)
            {
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = ex.Message;
                respuestaSunat.Estado = Estado.Error;
            }

            return respuestaSunat;
        }

        public RespuestaSunat GenerarComunicacionBaja(BajaCabecera pCabecera, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();

            try
            {
                this.SetXML();

                this.GeneraComunicacionBaja(pCabecera, pCabecera.LstBajaDetalle);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Auto;
                settings.Indent = true;
                settings.IndentChars = "\t";
                settings.Encoding = Encoding.GetEncoding("ISO-8859-1");

                string documentoXML = this.RUTA_COMUNICACIONBAJA + pCabecera.NroDoc_Emisor + "-" + pCabecera.Identificador + ".xml";

                if (System.IO.File.Exists(documentoXML))
                    System.IO.File.Delete(documentoXML);

                using (XmlWriter xmlWriter = XmlWriter.Create(documentoXML, settings))
                    this.XMLSerializerBaja.Serialize(xmlWriter, (object)this.XMLVoidedDocuments, this.XMLNamespace);

                this.GenerarFirma(documentoXML, 0);

                respuestaSunat = this.GenerarTicketSunatRB(documentoXML, bOSE);
            }
            catch (Exception ex)
            {
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = ex.Message;
                respuestaSunat.Estado = Estado.Error;
            }

            return respuestaSunat;
        }

        public RespuestaSunat GenerarResumenDiario(ResumenDiarioCabecera pCabecera, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();

            try
            {
                this.SetXML();

                this.GeneraResumenDiario(pCabecera, pCabecera.LstResumenDetalle);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Auto;
                settings.Indent = true;
                settings.IndentChars = "\t";
                settings.Encoding = Encoding.GetEncoding("ISO-8859-1");

                string documentoXML = this.RUTA_RESUMENDIARIO + pCabecera.NroDoc_Emisor + "-" + pCabecera.Identificador + ".xml";

                if (System.IO.File.Exists(documentoXML))
                    System.IO.File.Delete(documentoXML);

                using (XmlWriter xmlWriter = XmlWriter.Create(documentoXML, settings))
                    this.XMLSerializerResumen.Serialize(xmlWriter, (object)this.XMLSummaryDocuments, this.XMLNamespace);

                this.GenerarFirma(documentoXML, 0);

                respuestaSunat = this.GenerarTicketSunatRB(documentoXML, bOSE);
            }
            catch (Exception ex)
            {
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = ex.Message;
                respuestaSunat.Estado = Estado.Error;
            }

            return respuestaSunat;
        }

        public RespuestaSunat GenerarGuiaRemision(GuiaRemisionCabecera pCabecera, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();

            try
            {
                this.SetXML();

                this.GeneraGuiaRemision(pCabecera, pCabecera.LstGuiaDetalle);

                string documentoXML = this.RUTA_GUIAREMISION + pCabecera.NroDoc_Emisor + "-" + pCabecera.Tipo_Documento + "-" + pCabecera.Serie_Documento + "-" + pCabecera.Numero_Documento + ".xml";

                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    ConformanceLevel = ConformanceLevel.Auto,
                    Indent = true,
                    IndentChars = "\t",
                    Encoding = Encoding.GetEncoding("ISO-8859-1")
                };

                if (System.IO.File.Exists(documentoXML))
                    System.IO.File.Delete(documentoXML);

                using (XmlWriter xmlWriter = XmlWriter.Create(documentoXML, settings))
                    this.XMLSerializerDespatchAdvice.Serialize(xmlWriter, (object)this.XMLDespatchAdvice, this.XMLNamespace);

                this.GenerarFirma(documentoXML, 0);

                respuestaSunat = this.ValidarGuiaRemision(documentoXML, bOSE);

                if (!string.IsNullOrEmpty(respuestaSunat.RutaXML))
                {
                    if (System.IO.File.Exists(respuestaSunat.RutaXML))
                    {
                        respuestaSunat.DigestValue = this.ObtenerDigestValue(pCabecera.Tipo_Documento, respuestaSunat.RutaXML);
                        respuestaSunat.SignatureValue = this.ObtenerSignatureValue(pCabecera.Tipo_Documento, respuestaSunat.RutaXML);
                    }
                }
            }
            catch (Exception ex)
            {
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = ex.Message;
                respuestaSunat.Estado = Estado.Error;
            }

            return respuestaSunat;
        }

        private void GeneraFactura(ComprobanteCabecera pCabecera, List<ComprobanteDetalle> pLstDetalle, List<FacturaGuias> pLstGuias, List<FacturaFormaPago> pLstFormaPago)
        {
            try
            {
                this.XMLInvoice = new InvoiceType();

                this.oLstUBLExtensionType[0] = new UBLExtensionType()
                {
                    ExtensionContent = new XmlDocument().CreateElement("dummy")
                };
                this.XMLInvoice.UBLExtensions = this.oLstUBLExtensionType;

                PartyIdentificationType identificationType1 = new PartyIdentificationType();

                //-- Número de RUC
                PartyIdentificationType identificationType2 = identificationType1;
                IDType idType1 = new IDType();
                idType1.Value = pCabecera.NroDoc_Emisor;
                IDType idType2 = idType1;
                identificationType2.ID = idType2;

                //-- Nombre comercial
                PartyIdentificationType identificationType3 = identificationType1;
                PartyNameType partyNameType1 = new PartyNameType();
                PartyNameType partyNameType2 = partyNameType1;
                NameType1 nameType1_1 = new NameType1();
                nameType1_1.Value = pCabecera.RSocial_Emisor;
                NameType1 nameType1_2 = nameType1_1;
                partyNameType2.Name = nameType1_2;

                PartyNameType partyNameType3 = partyNameType1;
                PartyType partyType = new PartyType()
                {
                    PartyIdentification = new PartyIdentificationType[1]
                    {
                        identificationType3
                    },
                    PartyName = new PartyNameType[1] { partyNameType3 }
                };

                AttachmentType attachmentType1 = new AttachmentType();
                AttachmentType attachmentType2 = attachmentType1;
                ExternalReferenceType externalReferenceType1 = new ExternalReferenceType();
                ExternalReferenceType externalReferenceType2 = externalReferenceType1;
                URIType uriType1 = new URIType();
                uriType1.Value = "#SignatureKG";
                URIType uriType2 = uriType1;
                externalReferenceType2.URI = uriType2;
                ExternalReferenceType externalReferenceType3 = externalReferenceType1;
                attachmentType2.ExternalReference = externalReferenceType3;

                AttachmentType attachmentType3 = attachmentType1;
                SignatureType signatureType1 = new SignatureType();
                SignatureType signatureType2 = signatureType1;
                IDType idType3 = new IDType();
                idType3.Value = pCabecera.NroDoc_Emisor;
                IDType idType4 = idType3;
                signatureType2.ID = idType4;
                signatureType1.SignatoryParty = partyType;
                signatureType1.DigitalSignatureAttachment = attachmentType3;

                this.XMLInvoice.Signature = new SignatureType[1]
                {
                    signatureType1
                };

                InvoiceType invoiceType1 = this.XMLInvoice;

                UBLVersionIDType ublVersionIdType1 = new UBLVersionIDType();
                ublVersionIdType1.Value = "2.1";

                UBLVersionIDType ublVersionIdType2 = ublVersionIdType1;
                invoiceType1.UBLVersionID = ublVersionIdType2;

                InvoiceType invoiceType2 = this.XMLInvoice;
                CustomizationIDType customizationIdType1 = new CustomizationIDType();
                customizationIdType1.Value = "2.0";
                CustomizationIDType customizationIdType2 = customizationIdType1;
                invoiceType2.CustomizationID = customizationIdType2;

                InvoiceType invoiceType3 = this.XMLInvoice;
                IDType idType5 = new IDType();
                idType5.Value = pCabecera.Serie_Documento + "-" + pCabecera.Numero_Documento;
                IDType idType6 = idType5;
                invoiceType3.ID = idType6;

                InvoiceType invoiceType4 = this.XMLInvoice;
                IssueDateType issueDateType1 = new IssueDateType();
                issueDateType1.Value = pCabecera.Fecha_Emision;
                IssueDateType issueDateType2 = issueDateType1;
                invoiceType4.IssueDate = issueDateType2;

                InvoiceType invoiceType5 = this.XMLInvoice;
                IssueTimeType issueTimeType1 = new IssueTimeType();
                issueTimeType1.TimeString = pCabecera.Hora_Emision;
                IssueTimeType issueTimeType2 = issueTimeType1;
                invoiceType5.IssueTime = issueTimeType2;

                if (pCabecera.Fecha_Vencimiento.HasValue)
                {
                    InvoiceType invoiceType6 = this.XMLInvoice;
                    DueDateType dueDateType1 = new DueDateType();
                    dueDateType1.Value = Convert.ToDateTime((object)pCabecera.Fecha_Vencimiento);
                    DueDateType dueDateType2 = dueDateType1;
                    invoiceType6.DueDate = dueDateType2;
                }

                InvoiceType invoiceType7 = this.XMLInvoice;
                InvoiceTypeCodeType invoiceTypeCodeType1 = new InvoiceTypeCodeType();
                invoiceTypeCodeType1.listAgencyName = "PE:SUNAT";
                invoiceTypeCodeType1.listName = "Tipo de Documento"; //"SUNAT:Identificador de Tipo de Documento";
                invoiceTypeCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01";
                invoiceTypeCodeType1.listID = pCabecera.Tipo_Venta == "E" ? "0102" : (pCabecera.EsAnticipo ? "0101" : "0101");
                invoiceTypeCodeType1.Value = pCabecera.Codigo_Documento;
                invoiceTypeCodeType1.name = "Tipo de Operacion";
                invoiceTypeCodeType1.listSchemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo51";
                InvoiceTypeCodeType invoiceTypeCodeType2 = invoiceTypeCodeType1;
                invoiceType7.InvoiceTypeCode = invoiceTypeCodeType2;

                NoteType[] array1 = new NoteType[1];
                NoteType[] noteTypeArray1 = array1;
                int index1 = array1.Length - 1;

                NoteType noteType1 = new NoteType();
                noteType1.languageLocaleID = "1000";
                noteType1.Value = pCabecera.Texto_Importe_Total;

                NoteType noteType2 = noteType1;
                noteTypeArray1[index1] = noteType2;

                if (pCabecera.Importe_Total == pCabecera.Importe_Gratuito)
                {
                    Array.Resize<NoteType>(ref array1, array1.Length + 1);
                    NoteType[] noteTypeArray2 = array1;
                    int index2 = array1.Length - 1;
                    NoteType noteType3 = new NoteType();
                    noteType3.languageLocaleID = "1002";
                    noteType3.Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE";
                    NoteType noteType4 = noteType3;
                    noteTypeArray2[index2] = noteType4;
                }

                if (pCabecera.Importe_Percepcion > new Decimal(0))
                {
                    Array.Resize<NoteType>(ref array1, array1.Length + 1);
                    NoteType[] noteTypeArray2 = array1;
                    int index2 = array1.Length - 1;
                    NoteType noteType3 = new NoteType();
                    noteType3.languageLocaleID = "2000";
                    noteType3.Value = "COMPROBANTE DE PERCEPCIÓN";
                    NoteType noteType4 = noteType3;
                    noteTypeArray2[index2] = noteType4;
                }

                if (pCabecera.Importe_Detraccion > new Decimal(0))
                {
                    Array.Resize<NoteType>(ref array1, array1.Length + 1);
                    NoteType[] noteTypeArray2 = array1;
                    int index2 = array1.Length - 1;
                    NoteType noteType3 = new NoteType();
                    noteType3.languageLocaleID = "2006";
                    noteType3.Value = "Operación sujeta a detracción";
                    NoteType noteType4 = noteType3;
                    noteTypeArray2[index2] = noteType4;
                }

                this.XMLInvoice.Note = array1;

                InvoiceType invoiceType8 = this.XMLInvoice;
                DocumentCurrencyCodeType currencyCodeType1 = new DocumentCurrencyCodeType();
                currencyCodeType1.listID = "ISO 4217 Alpha";
                currencyCodeType1.listName = "Currency";
                currencyCodeType1.listAgencyName = "United Nations Economic Commission for Europe";
                currencyCodeType1.Value = pCabecera.Codigo_Moneda;
                DocumentCurrencyCodeType currencyCodeType2 = currencyCodeType1;
                invoiceType8.DocumentCurrencyCode = currencyCodeType2;

                PartyNameType[] partyNameTypeArray1 = new PartyNameType[1];
                PartyNameType[] partyNameTypeArray2 = partyNameTypeArray1;
                PartyNameType partyNameType4 = new PartyNameType();
                PartyNameType partyNameType5 = partyNameType4;
                NameType1 nameType1_3 = new NameType1();
                nameType1_3.Value = pCabecera.NombreCorto_Emisor;
                NameType1 nameType1_4 = nameType1_3;
                partyNameType5.Name = nameType1_4;
                PartyNameType partyNameType6 = partyNameType4;
                partyNameTypeArray2[0] = partyNameType6;

                PartyLegalEntityType[] partyLegalEntityTypeArray1 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray2 = partyLegalEntityTypeArray1;
                PartyLegalEntityType partyLegalEntityType1 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType2 = partyLegalEntityType1;
                RegistrationNameType registrationNameType1 = new RegistrationNameType();
                registrationNameType1.Value = pCabecera.RSocial_Emisor;
                RegistrationNameType registrationNameType2 = registrationNameType1;
                partyLegalEntityType2.RegistrationName = registrationNameType2;

                PartyLegalEntityType partyLegalEntityType3 = partyLegalEntityType1;
                AddressType addressType1 = new AddressType();
                AddressType addressType2 = addressType1;
                CountrySubentityType countrySubentityType1 = new CountrySubentityType();
                countrySubentityType1.Value = pCabecera.Dpto_Emisor;
                CountrySubentityType countrySubentityType2 = countrySubentityType1;
                addressType2.CountrySubentity = countrySubentityType2;

                AddressType addressType3 = addressType1;
                CityNameType cityNameType1 = new CityNameType();
                cityNameType1.Value = pCabecera.Prov_Emisor;
                CityNameType cityNameType2 = cityNameType1;
                addressType3.CityName = cityNameType2;

                AddressType addressType4 = addressType1;
                DistrictType districtType1 = new DistrictType();
                districtType1.Value = pCabecera.Dist_Emisor;
                DistrictType districtType2 = districtType1;
                addressType4.District = districtType2;

                AddressType addressType5 = addressType1;
                CountryType countryType1 = new CountryType();
                CountryType countryType2 = countryType1;
                IdentificationCodeType identificationCodeType1 = new IdentificationCodeType();
                identificationCodeType1.Value = pCabecera.CodPais_Emisor;
                IdentificationCodeType identificationCodeType2 = identificationCodeType1;
                countryType2.IdentificationCode = identificationCodeType2;

                CountryType countryType3 = countryType1;
                addressType5.Country = countryType3;

                AddressType addressType6 = addressType1;
                AddressTypeCodeType addressTypeCodeType1 = new AddressTypeCodeType();
                addressTypeCodeType1.Value = pCabecera.Codigo_Domicilio_Emisor;
                AddressTypeCodeType addressTypeCodeType2 = addressTypeCodeType1;
                addressType6.AddressTypeCode = addressTypeCodeType2;

                AddressType addressType7 = addressType1;
                partyLegalEntityType3.RegistrationAddress = addressType7;

                PartyLegalEntityType partyLegalEntityType4 = partyLegalEntityType1;
                partyLegalEntityTypeArray2[0] = partyLegalEntityType4;

                PartyIdentificationType[] identificationTypeArray1 = new PartyIdentificationType[1];
                PartyIdentificationType[] identificationTypeArray2 = identificationTypeArray1;

                PartyIdentificationType identificationType4 = new PartyIdentificationType();
                PartyIdentificationType identificationType5 = identificationType4;
                IDType idType7 = new IDType();
                idType7.schemeID = pCabecera.TipoDoc_Emisor;
                idType7.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                idType7.schemeAgencyName = "PE:SUNAT";
                idType7.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                idType7.Value = pCabecera.NroDoc_Emisor;
                IDType idType8 = idType7;
                identificationType5.ID = idType8;

                PartyIdentificationType identificationType6 = identificationType4;
                identificationTypeArray2[0] = identificationType6;

                new PartyTaxSchemeType().RegistrationAddress = new AddressType();

                this.XMLInvoice.AccountingSupplierParty = new SupplierPartyType()
                {
                    Party = new PartyType()
                    {
                        PartyName = partyNameTypeArray1,
                        PartyLegalEntity = partyLegalEntityTypeArray1,
                        PartyIdentification = identificationTypeArray1
                    }
                };

                PartyLegalEntityType[] partyLegalEntityTypeArray3 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray4 = partyLegalEntityTypeArray3;

                PartyLegalEntityType partyLegalEntityType5 = new PartyLegalEntityType();

                PartyLegalEntityType partyLegalEntityType6 = partyLegalEntityType5;
                RegistrationNameType registrationNameType3 = new RegistrationNameType();
                registrationNameType3.Value = pCabecera.RSocial_Receptor;
                RegistrationNameType registrationNameType4 = registrationNameType3;
                partyLegalEntityType6.RegistrationName = registrationNameType4;

                PartyLegalEntityType partyLegalEntityType7 = partyLegalEntityType5;
                partyLegalEntityTypeArray4[0] = partyLegalEntityType7;

                PartyIdentificationType[] identificationTypeArray3 = new PartyIdentificationType[1];

                if (pCabecera.Tipo_Venta == "L")
                {
                    PartyIdentificationType[] identificationTypeArray4 = identificationTypeArray3;

                    PartyIdentificationType identificationType7 = new PartyIdentificationType();
                    PartyIdentificationType identificationType8 = identificationType7;
                    IDType idType9 = new IDType();
                    idType9.schemeID = pCabecera.TipoDoc_Receptor;
                    idType9.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                    idType9.schemeAgencyName = "PE:SUNAT";
                    idType9.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                    idType9.Value = pCabecera.NroDoc_Receptor;
                    IDType idType10 = idType9;
                    identificationType8.ID = idType10;

                    PartyIdentificationType identificationType9 = identificationType7;
                    identificationTypeArray4[0] = identificationType9;
                }
                else
                {
                    PartyIdentificationType[] identificationTypeArray4 = identificationTypeArray3;

                    PartyIdentificationType identificationType7 = new PartyIdentificationType();
                    PartyIdentificationType identificationType8 = identificationType7;
                    IDType idType9 = new IDType();
                    idType9.schemeID = "-";
                    idType9.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                    idType9.schemeAgencyName = "PE:SUNAT";
                    idType9.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                    idType9.Value = "0";
                    IDType idType10 = idType9;
                    identificationType8.ID = idType10;

                    PartyIdentificationType identificationType9 = identificationType7;
                    identificationTypeArray4[0] = identificationType9;
                }

                this.XMLInvoice.AccountingCustomerParty = new CustomerPartyType()
                {
                    Party = new PartyType()
                    {
                        PartyLegalEntity = partyLegalEntityTypeArray3,
                        PartyIdentification = identificationTypeArray3
                    }
                };

                AllowanceChargeType[] array2;
                if (pCabecera.Importe_DctoGlobal + pCabecera.Importe_Percepcion + pCabecera.Importe_Anticipos != new Decimal(0))
                {
                    array2 = new AllowanceChargeType[0];

                    if (pCabecera.Importe_DctoGlobal != new Decimal(0))
                    {
                        Array.Resize<AllowanceChargeType>(ref array2, array2.Length + 1);

                        AllowanceChargeType[] allowanceChargeTypeArray = array2;
                        int index2 = array2.Length - 1;

                        AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                        AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                        ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                        chargeIndicatorType1.Value = false; //true: cargo | false: descuento
                        ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                        allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;

                        AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                        AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                        chargeReasonCodeType1.Value = "00"; //00: Descuentos que afectan la base imponible del IGV/IVAP
                        AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                        allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;

                        AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                        MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                        factorNumericType1.Value = pCabecera.PorcentajeDctoGlobal / new Decimal(100);
                        MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                        allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;

                        AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                        AmountType2 amountType2_1 = new AmountType2();
                        amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                        amountType2_1.Value = pCabecera.Importe_DctoGlobal;
                        AmountType2 amountType2_2 = amountType2_1;
                        allowanceChargeType5.Amount = amountType2_2;

                        AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                        BaseAmountType baseAmountType1 = new BaseAmountType();
                        baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        baseAmountType1.Value = pCabecera.Importe_SubTotal - pCabecera.Importe_Descuento;
                        BaseAmountType baseAmountType2 = baseAmountType1;
                        allowanceChargeType6.BaseAmount = baseAmountType2;

                        AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                        allowanceChargeTypeArray[index2] = allowanceChargeType7;
                    }

                    if (pCabecera.Importe_Percepcion != new Decimal(0))
                    {
                        Array.Resize<AllowanceChargeType>(ref array2, array2.Length + 1);

                        AllowanceChargeType[] allowanceChargeTypeArray = array2;
                        int index2 = array2.Length - 1;

                        AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();

                        AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                        ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                        chargeIndicatorType1.Value = true; //true: cargo | false: descuento
                        ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                        allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;

                        AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                        AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                        chargeReasonCodeType1.Value = pCabecera.Codigo_Percepcion;
                        AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                        allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;

                        AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                        MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                        factorNumericType1.Value = pCabecera.Porcentaje_Percepcion / new Decimal(100);
                        MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                        allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;

                        AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                        AmountType2 amountType2_1 = new AmountType2();
                        amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                        amountType2_1.Value = pCabecera.Importe_Percepcion;
                        AmountType2 amountType2_2 = amountType2_1;
                        allowanceChargeType5.Amount = amountType2_2;

                        AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                        BaseAmountType baseAmountType1 = new BaseAmountType();
                        baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        baseAmountType1.Value = pCabecera.Base_Percepcion;
                        BaseAmountType baseAmountType2 = baseAmountType1;
                        allowanceChargeType6.BaseAmount = baseAmountType2;

                        AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                        allowanceChargeTypeArray[index2] = allowanceChargeType7;
                    }

                    if (pCabecera.Importe_Anticipos != new Decimal(0))
                    {
                        Array.Resize<AllowanceChargeType>(ref array2, array2.Length + 1);

                        AllowanceChargeType[] allowanceChargeTypeArray = array2;
                        int index2 = array2.Length - 1;

                        //-- Indicador de cargo/descuento
                        AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                        AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                        ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                        chargeIndicatorType1.Value = false; //true: cargo | false: descuento
                        ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                        allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;

                        //-- Código de motivo de cargo/descuento
                        AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                        AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                        chargeReasonCodeType1.listAgencyName = "PE:SUNAT";
                        chargeReasonCodeType1.listName = "Cargo/descuento";
                        chargeReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo53";
                        chargeReasonCodeType1.Value = "04"; //04: Descuentos globales por anticipos gravados que afectan la base imponible del IGV/IVAP 
                        AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                        allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;

                        //-- Factor de cargo/descuento
                        AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                        MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                        factorNumericType1.Value = Convert.ToDecimal(String.Format("{0:#,0.00}", Convert.ToDecimal(pCabecera.Importe_Anticipos / (pCabecera.Importe_SubTotal + pCabecera.Importe_Anticipos)))); //pCabecera.PorcentajeDctoGlobal / new Decimal(100);
                        MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                        allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;

                        //-- Monto del cargo/descuento global
                        AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                        AmountType2 amountType2_1 = new AmountType2();
                        amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                        amountType2_1.Value = pCabecera.Importe_Anticipos;
                        AmountType2 amountType2_2 = amountType2_1;
                        allowanceChargeType5.Amount = amountType2_2;

                        //-- Monto base del cargo/descuento
                        AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                        BaseAmountType baseAmountType1 = new BaseAmountType();
                        baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        baseAmountType1.Value = pCabecera.Importe_SubTotal + pCabecera.Importe_Anticipos; //- pCabecera.Importe_Anticipos;
                        BaseAmountType baseAmountType2 = baseAmountType1;
                        allowanceChargeType6.BaseAmount = baseAmountType2;

                        AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                        allowanceChargeTypeArray[index2] = allowanceChargeType7;
                    }

                    this.XMLInvoice.AllowanceCharge = array2;
                }

                #region [ TaxTotal ]

                //- Totales de la Factura
                TaxSubtotalType[] array3 = new TaxSubtotalType[0];

                //-- Monto total de tributos
                TaxAmountType taxAmountType1 = new TaxAmountType();
                taxAmountType1.currencyID = pCabecera.Codigo_Moneda;
                taxAmountType1.Value = pCabecera.Importe_IGV + pCabecera.Importe_ISC;
                TaxAmountType taxAmountType2 = taxAmountType1;

                //-- Total valor de venta - operaciones gravadas (IGV/IVAP) | Sumatoria de IGV/IVAP
                if (pCabecera.Importe_IGV > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                    //-- Total valor de venta operaciones gravadas
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Gravado + pCabecera.Importe_ISC;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    //-- Monto de la sumatoria de IGV/IVAP según corresponda
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_IGV;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;

                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();

                    //TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    //IDType idType9 = new IDType();
                    //idType9.schemeID = "UN/ECE 5305";
                    //idType9.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                    //idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    //idType9.Value = "S";
                    //IDType idType10 = idType9;
                    //taxCategoryType2.ID = idType10;

                    //-- Código de tributo
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "1000";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;

                    //-- Nombre de tributo
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "IGV";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    //-- Código internacional de tributo
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "VAT";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }

                //-- Sumatoria ISC | Sumatoria ICBPER
                if (pCabecera.Importe_ISC > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                    //-- Monto base
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Base_ISC;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    //-- Monto de la sumatoria
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_ISC;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;

                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();

                    //TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    //IDType idType9 = new IDType();
                    //idType9.schemeID = "UN/ECE 5305";
                    //idType9.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                    //idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    //idType9.Value = "S";
                    //IDType idType10 = idType9;
                    //taxCategoryType2.ID = idType10;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();

                    //-- Código de tributo
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "2000";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;

                    //-- Nombre de tributo
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "ISC";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    //-- Código internacional de tributo
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "EXC";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }

                //-- Sumatoria otros tributos
                if (pCabecera.Importe_OtrosTributos > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                    //-- Monto base
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Base_OtrosTributos;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    //-- Monto de la sumatoria
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_OtrosTributos;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;

                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();

                    //TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    //IDType idType9 = new IDType();
                    //idType9.schemeID = "UN/ECE 5305";
                    //idType9.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                    //idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    //idType9.Value = "S";
                    //IDType idType10 = idType9;
                    //taxCategoryType2.ID = idType10;

                    //-- Código de tributo
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "9999";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;

                    //-- Nombre de tributo
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "OTR";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    //-- Código internacional de tributo
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "OTH";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }

                //-- Total valor de venta - operaciones exoneradas
                if (pCabecera.Importe_Exonerado > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                    //-- Total valor de venta
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Exonerado;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    //-- Importe del tributo
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;


                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();

                    //TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    //IDType idType9 = new IDType();
                    //idType9.schemeID = "UN/ECE 5305";
                    //idType9.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                    //idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    //idType9.Value = "E";
                    //IDType idType10 = idType9;
                    //taxCategoryType2.ID = idType10;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();

                    //-- Código de tributo
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "9997";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;

                    //-- Nombre de tributo
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "EXO";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    //-- Código internacional de tributo
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "VAT";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }

                //-- Total valor de venta - operaciones inafectas
                if (pCabecera.Importe_Inafecto > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                    //-- Total valor de venta
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Inafecto;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    //-- Importe del tributo
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;

                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();

                    //TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    //IDType idType9 = new IDType();
                    //idType9.schemeID = "UN/ECE 5305";
                    //idType9.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                    //idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    //idType9.Value = "O";
                    //IDType idType10 = idType9;
                    //taxCategoryType2.ID = idType10;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();

                    //-- Código de tributo
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "9998";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;

                    //-- Nombre de tributo
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "INA";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    //-- Código internacional de tributo
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "FRE";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }

                //-- Total valor de venta - operaciones gratuitas | Sumatoria de tributos de operaciones gratuitas
                if (pCabecera.Importe_Gratuito > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                    //-- Total valor de venta - operaciones gratuitas
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Gratuito;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    //-- Sumatoria de tributos de operaciones gratuitas
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0); //pCabecera.Importe_IGV;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;

                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();

                    //TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    //IDType idType9 = new IDType();
                    //idType9.schemeID = "UN/ECE 5305";
                    //idType9.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                    //idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    //idType9.Value = "Z";
                    //IDType idType10 = idType9;
                    //taxCategoryType2.ID = idType10;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();

                    //-- Código de tributo
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    //idType11.schemeID = "UN/ECE 5153";                    
                    //idType11.schemeAgencyID = "6";
                    idType11.schemeName = "Codigo de tributos";
                    idType11.schemeAgencyName = "PE:SUNAT";
                    idType11.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
                    idType11.Value = "9996";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;

                    //-- Nombre de tributo
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "GRA";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    //-- Código internacional de tributo
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "FRE";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }

                this.XMLInvoice.TaxTotal = new TaxTotalType[1]
                {
                      new TaxTotalType()
                      {
                        TaxAmount = taxAmountType2,
                        TaxSubtotal = array3
                      }
                };

                #endregion

                if (pCabecera.Porcentaje_Detraccion > new Decimal(0))
                {
                    PaymentMeansType[] paymentMeansTypeArray1 = new PaymentMeansType[1];
                    PaymentMeansType[] paymentMeansTypeArray2 = paymentMeansTypeArray1;

                    PaymentMeansType paymentMeansType1 = new PaymentMeansType();
                    PaymentMeansType paymentMeansType2 = paymentMeansType1;

                    FinancialAccountType payeeFinancialAccountType1 = new FinancialAccountType();
                    FinancialAccountType payeeFinancialAccountType2 = payeeFinancialAccountType1;

                    PaymentMeansCodeType paymentMeansCodeType1 = new PaymentMeansCodeType();
                    paymentMeansCodeType1.Value = "001";
                    PaymentMeansCodeType paymentMeansCodeType2 = paymentMeansCodeType1;

                    IDType idType9 = new IDType();
                    idType9.Value = pCabecera.NroCuenta_Detraccion;
                    IDType idType10 = idType9;
                    payeeFinancialAccountType2.ID = idType10;

                    PaymentMeansType paymentMeansType3 = paymentMeansType1;
                    paymentMeansType3.PaymentMeansCode = paymentMeansCodeType2;

                    PaymentMeansType paymentMeansType4 = paymentMeansType1;
                    paymentMeansType4.PayeeFinancialAccount = payeeFinancialAccountType2;

                    PaymentMeansType paymentMeansType5 = paymentMeansType1;
                    paymentMeansTypeArray2[0] = paymentMeansType5;

                    this.XMLInvoice.PaymentMeans = paymentMeansTypeArray1;

                    PaymentTermsType[] paymentTermsTypeArray1 = new PaymentTermsType[1];
                    PaymentTermsType[] paymentTermsTypeArray2 = paymentTermsTypeArray1;

                    PaymentTermsType paymentTermsType1 = new PaymentTermsType();
                    PaymentTermsType paymentTermsType2 = paymentTermsType1;

                    IDType idType11 = new IDType();
                    idType11.schemeName = "SUNAT:Codigo de detraccion";
                    idType11.schemeAgencyName = "PE:SUNAT";
                    idType11.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo54";
                    idType11.Value = pCabecera.Codigo_Detraccion;

                    IDType idType12 = idType11;
                    paymentTermsType2.ID = idType12;

                    PaymentTermsType paymentTermsType3 = paymentTermsType1;

                    PaymentPercentType paymentPercentType1 = new PaymentPercentType();
                    paymentPercentType1.Value = pCabecera.Porcentaje_Detraccion;

                    PaymentPercentType paymentPercentType2 = paymentPercentType1;
                    paymentTermsType3.PaymentPercent = paymentPercentType2;

                    PaymentTermsType paymentTermsType4 = paymentTermsType1;
                    AmountType2 amountType2_1 = new AmountType2();
                    amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                    amountType2_1.Value = pCabecera.Importe_Detraccion;

                    AmountType2 amountType2_2 = amountType2_1;
                    paymentTermsType4.Amount = amountType2_2;

                    PaymentTermsType paymentTermsType5 = paymentTermsType1;
                    paymentTermsTypeArray2[0] = paymentTermsType5;

                    this.XMLInvoice.PaymentTerms = paymentTermsTypeArray1;
                }

                DocumentReferenceType[] documentReferenceTypeArray = new DocumentReferenceType[pLstDetalle.Count];
                PaymentType[] paymentTypeArray = new PaymentType[pLstDetalle.Count];

                for (int index2 = 0; index2 < pLstDetalle.Count; ++index2)
                {
                    if (pLstDetalle[index2].EsAnticipo)
                    {
                        DocumentReferenceType documentReferenceType1 = new DocumentReferenceType();

                        DocumentReferenceType documentReferenceType2 = documentReferenceType1;
                        IDType idType9 = new IDType();
                        idType9.schemeID = pLstDetalle[index2].Codigo_Documento_Anticipo == "01" ? "01" : "03";
                        idType9.Value = pLstDetalle[index2].Serie_Documento_Anticipo + "-" + pLstDetalle[index2].Numero_Documento_Anticipo;
                        IDType idType10 = idType9;
                        documentReferenceType2.ID = idType10;

                        DocumentReferenceType documentReferenceType3 = documentReferenceType1;
                        DocumentTypeCodeType documentTypeCodeType1 = new DocumentTypeCodeType();
                        documentTypeCodeType1.listAgencyName = "PE:SUNAT";
                        documentTypeCodeType1.listName = "Documento Relacionado"; //"SUNAT: Identificador de documento relacionado";
                        documentTypeCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo12";
                        documentTypeCodeType1.Value = "02";
                        DocumentTypeCodeType documentTypeCodeType2 = documentTypeCodeType1;
                        documentReferenceType3.DocumentTypeCode = documentTypeCodeType2;

                        DocumentReferenceType documentReferenceType4 = documentReferenceType1;
                        DocumentStatusCodeType documentStatusCodeType1 = new DocumentStatusCodeType();
                        documentStatusCodeType1.listName = "Anticipo";
                        documentStatusCodeType1.listAgencyName = "PE:SUNAT";
                        documentStatusCodeType1.Value = pLstDetalle[index2].Serie_Documento_Anticipo + "-" + pLstDetalle[index2].Numero_Documento_Anticipo;
                        DocumentStatusCodeType documentStatusCodeType2 = documentStatusCodeType1;
                        documentReferenceType4.DocumentStatusCode = documentStatusCodeType2;

                        DocumentReferenceType documentReferenceType5 = documentReferenceType1;
                        PartyIdentificationType[] partyIdentificationTypeArray1 = new PartyIdentificationType[1];
                        PartyIdentificationType[] partyIdentificationTypeArray2 = partyIdentificationTypeArray1;
                        PartyIdentificationType partyIdentificationType4 = new PartyIdentificationType();
                        PartyIdentificationType partyIdentificationType5 = partyIdentificationType4;

                        IDType idType14 = new IDType();
                        idType14.schemeID = pCabecera.TipoDoc_Emisor;
                        idType14.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                        idType14.schemeAgencyName = "PE:SUNAT";
                        idType14.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                        idType14.Value = pCabecera.NroDoc_Emisor;

                        IDType idType15 = idType14;
                        partyIdentificationType5.ID = idType15;

                        PartyIdentificationType partyIdentificationType6 = partyIdentificationType4;
                        partyIdentificationTypeArray2[0] = partyIdentificationType6;

                        PartyType partyType1 = new PartyType()
                        {
                            PartyIdentification = partyIdentificationTypeArray1
                        };

                        PartyType partyType2 = partyType1;
                        documentReferenceType5.IssuerParty = partyType2;

                        DocumentReferenceType documentReferenceType6 = documentReferenceType1;
                        documentReferenceTypeArray[index2] = documentReferenceType1;

                        PaymentType paymentType1 = new PaymentType();

                        PaymentType paymentType2 = paymentType1;
                        IDType idType12 = new IDType();
                        //idType9.schemeID = pLstDetalle[index2].Codigo_Documento_Anticipo == "01" ? "01" : "03";
                        idType12.schemeName = "Anticipo"; //<--nuevo
                        idType12.schemeAgencyName = "PE:SUNAT"; //<--nuevo
                        idType12.Value = pLstDetalle[index2].Serie_Documento_Anticipo + "-" + pLstDetalle[index2].Numero_Documento_Anticipo;
                        IDType idType13 = idType12;
                        paymentType2.ID = idType13;

                        PaymentType paymentType3 = paymentType1;
                        PaidAmountType paidAmountType1 = new PaidAmountType();
                        paidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        paidAmountType1.Value = pLstDetalle[index2].Importe_SubTotal; //pLstDetalle[index2].Importe_Total;
                        PaidAmountType paidAmountType2 = paidAmountType1;
                        paymentType3.PaidAmount = paidAmountType2;

                        //PaymentType paymentType4 = paymentType1;
                        //InstructionIDType instructionIdType1 = new InstructionIDType();
                        //instructionIdType1.schemeID = pCabecera.TipoDoc_Emisor;
                        //instructionIdType1.Value = pCabecera.NroDoc_Emisor;
                        //InstructionIDType instructionIdType2 = instructionIdType1;
                        //paymentType4.InstructionID = instructionIdType2;

                        paymentTypeArray[index2] = paymentType1;
                    }
                }

                this.XMLInvoice.AdditionalDocumentReference = documentReferenceTypeArray;
                this.XMLInvoice.PrepaidPayment = paymentTypeArray;

                if (pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion > new Decimal(0))
                {
                    //-- verificar esta línea
                    if (pCabecera.Importe_Anticipos > new Decimal(0))
                    {
                        InvoiceType invoiceType6 = this.XMLInvoice;

                        MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();
                        MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                        LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                        extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        extensionAmountType1.Value = pCabecera.Importe_SubTotal;
                        LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                        monetaryTotalType2.LineExtensionAmount = extensionAmountType2;

                        MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                        TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                        exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        exclusiveAmountType1.Value = pCabecera.Importe_Total;

                        TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                        monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;

                        MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                        AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                        allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;

                        AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                        monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;

                        MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                        ChargeTotalAmountType chargeTotalAmountType1 = new ChargeTotalAmountType();
                        chargeTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        chargeTotalAmountType1.Value = pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;

                        ChargeTotalAmountType chargeTotalAmountType2 = chargeTotalAmountType1;
                        monetaryTotalType5.ChargeTotalAmount = chargeTotalAmountType2;

                        MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                        PrepaidAmountType prepaidAmountType1 = new PrepaidAmountType();
                        prepaidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        prepaidAmountType1.Value = pCabecera.Importe_Anticipos;

                        PrepaidAmountType prepaidAmountType2 = prepaidAmountType1;
                        monetaryTotalType6.PrepaidAmount = prepaidAmountType2;

                        MonetaryTotalType monetaryTotalType7 = monetaryTotalType1;
                        PayableAmountType payableAmountType1 = new PayableAmountType();
                        payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;

                        PayableAmountType payableAmountType2 = payableAmountType1;
                        monetaryTotalType7.PayableAmount = payableAmountType2;

                        MonetaryTotalType monetaryTotalType8 = monetaryTotalType1;
                        invoiceType6.LegalMonetaryTotal = monetaryTotalType8;
                    }
                    else
                    {
                        InvoiceType invoiceType6 = this.XMLInvoice;

                        MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();

                        MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                        LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                        extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        extensionAmountType1.Value = pCabecera.Importe_SubTotal;

                        LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                        monetaryTotalType2.LineExtensionAmount = extensionAmountType2;

                        MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                        TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                        exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        exclusiveAmountType1.Value = pCabecera.Importe_Total;

                        TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                        monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;

                        MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                        AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                        allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;

                        AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                        monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;

                        MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                        ChargeTotalAmountType chargeTotalAmountType1 = new ChargeTotalAmountType();
                        chargeTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        chargeTotalAmountType1.Value = pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;

                        ChargeTotalAmountType chargeTotalAmountType2 = chargeTotalAmountType1;
                        monetaryTotalType5.ChargeTotalAmount = chargeTotalAmountType2;

                        MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                        PayableAmountType payableAmountType1 = new PayableAmountType();
                        payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;

                        PayableAmountType payableAmountType2 = payableAmountType1;
                        monetaryTotalType6.PayableAmount = payableAmountType2;

                        MonetaryTotalType monetaryTotalType7 = monetaryTotalType1;
                        invoiceType6.LegalMonetaryTotal = monetaryTotalType7;
                    }
                }
                else if (pCabecera.Importe_Anticipos > new Decimal(0))
                {
                    InvoiceType invoiceType6 = this.XMLInvoice;

                    MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();

                    //-- Total valor de venta
                    MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pCabecera.Importe_SubTotal + pCabecera.Importe_Anticipos;

                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    monetaryTotalType2.LineExtensionAmount = extensionAmountType2;

                    MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                    TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                    exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    exclusiveAmountType1.Value = pCabecera.Importe_Total;

                    TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                    monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;

                    MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                    AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                    allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;

                    AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                    monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;

                    MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                    ChargeTotalAmountType chargeTotalAmountType1 = new ChargeTotalAmountType();
                    chargeTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    chargeTotalAmountType1.Value = Convert.ToDecimal("0.00");

                    ChargeTotalAmountType chargeTotalAmountType2 = chargeTotalAmountType1;
                    monetaryTotalType5.ChargeTotalAmount = chargeTotalAmountType2;

                    MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                    PrepaidAmountType prepaidAmountType1 = new PrepaidAmountType();
                    prepaidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    prepaidAmountType1.Value = pCabecera.Importe_Anticipos;

                    PrepaidAmountType prepaidAmountType2 = prepaidAmountType1;
                    monetaryTotalType6.PrepaidAmount = prepaidAmountType2;

                    MonetaryTotalType monetaryTotalType7 = monetaryTotalType1;
                    PayableAmountType payableAmountType1 = new PayableAmountType();
                    payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_Percepcion;

                    PayableAmountType payableAmountType2 = payableAmountType1;
                    monetaryTotalType7.PayableAmount = payableAmountType2;

                    MonetaryTotalType monetaryTotalType8 = monetaryTotalType1;
                    invoiceType6.LegalMonetaryTotal = monetaryTotalType8;
                }
                else
                {
                    InvoiceType invoiceType6 = this.XMLInvoice;

                    MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();

                    MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pCabecera.Importe_SubTotal;

                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    monetaryTotalType2.LineExtensionAmount = extensionAmountType2;

                    MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                    TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                    exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    exclusiveAmountType1.Value = pCabecera.Importe_Total;

                    TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                    monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;

                    MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                    AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                    allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;

                    AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                    monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;

                    MonetaryTotalType monetaryTotalType9 = monetaryTotalType1;
                    TaxInclusiveAmountType inclusiveAmountType1 = new TaxInclusiveAmountType();
                    inclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    inclusiveAmountType1.Value = pCabecera.Importe_Total;

                    TaxInclusiveAmountType inclusiveAmountType2 = inclusiveAmountType1;
                    monetaryTotalType9.TaxInclusiveAmount = inclusiveAmountType2;

                    if (pCabecera.EsAnticipo)
                    {
                        MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                        ChargeTotalAmountType chargeTotalAmountType1 = new ChargeTotalAmountType();
                        chargeTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        chargeTotalAmountType1.Value = Convert.ToDecimal("0.00");

                        ChargeTotalAmountType chargeTotalAmountType2 = chargeTotalAmountType1;
                        monetaryTotalType5.ChargeTotalAmount = chargeTotalAmountType2;

                        MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                        PrepaidAmountType prepaidAmountType1 = new PrepaidAmountType();
                        prepaidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        prepaidAmountType1.Value = Convert.ToDecimal("0.00");

                        PrepaidAmountType prepaidAmountType2 = prepaidAmountType1;
                        monetaryTotalType6.PrepaidAmount = prepaidAmountType2;
                    }

                    MonetaryTotalType monetaryTotalType7 = monetaryTotalType1;
                    PayableAmountType payableAmountType1 = new PayableAmountType();
                    payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_Percepcion;

                    PayableAmountType payableAmountType2 = payableAmountType1;
                    monetaryTotalType7.PayableAmount = payableAmountType2;

                    MonetaryTotalType monetaryTotalType8 = monetaryTotalType1;
                    invoiceType6.LegalMonetaryTotal = monetaryTotalType8;
                }

                InvoiceLineType[] invoiceLineTypeArray = new InvoiceLineType[pLstDetalle.Count];
                for (int index2 = 0; index2 < pLstDetalle.Count; ++index2)
                {
                    if (!pLstDetalle[index2].EsAnticipo)
                    {
                        InvoiceLineType invoiceLineType1 = new InvoiceLineType();

                        InvoiceLineType invoiceLineType2 = invoiceLineType1;
                        IDType idType9 = new IDType();
                        idType9.Value = pLstDetalle[index2].NroItem.Trim();

                        IDType idType10 = idType9;
                        invoiceLineType2.ID = idType10;

                        InvoiceLineType invoiceLineType3 = invoiceLineType1;
                        InvoicedQuantityType invoicedQuantityType1 = new InvoicedQuantityType();
                        invoicedQuantityType1.Value = pLstDetalle[index2].Cantidad;
                        invoicedQuantityType1.unitCode = pLstDetalle[index2].Codigo_Unidad;
                        invoicedQuantityType1.unitCodeListID = "UN/ECE rec 20";
                        invoicedQuantityType1.unitCodeListAgencyName = "United Nations Economic Commission for Europe";

                        InvoicedQuantityType invoicedQuantityType2 = invoicedQuantityType1;
                        invoiceLineType3.InvoicedQuantity = invoicedQuantityType2;

                        LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                        extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        extensionAmountType1.Value = Convert.ToDecimal(pLstDetalle[index2].Importe_ValorVenta); //pLstDetalle[index2].EsGratuito ? new Decimal(0) : Convert.ToDecimal(pLstDetalle[index2].Importe_ValorVenta);

                        LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                        invoiceLineType1.LineExtensionAmount = extensionAmountType2;

                        PriceType[] priceTypeArray = new PriceType[1];

                        PriceType priceType1 = new PriceType();

                        PriceType priceType2 = priceType1;
                        PriceAmountType priceAmountType1 = new PriceAmountType();
                        priceAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        priceAmountType1.Value = pLstDetalle[index2].Precio_Unitario_ConIGV;

                        PriceAmountType priceAmountType2 = priceAmountType1;
                        priceType2.PriceAmount = priceAmountType2;

                        PriceType priceType3 = priceType1;
                        PriceTypeCodeType priceTypeCodeType1 = new PriceTypeCodeType();
                        priceTypeCodeType1.listName = "Tipo de Precio"; //"SUNAT:Indicador de Tipo de Precio";
                        priceTypeCodeType1.listAgencyName = "PE:SUNAT";
                        priceTypeCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16";
                        priceTypeCodeType1.Value = pCabecera.Tipo_Venta == "E" || pLstDetalle[index2].EsGratuito ? "02" : "01";

                        PriceTypeCodeType priceTypeCodeType2 = priceTypeCodeType1;
                        priceType3.PriceTypeCode = priceTypeCodeType2;

                        PriceType priceType4 = priceType1;
                        priceTypeArray[0] = priceType4;

                        PricingReferenceType pricingReferenceType = new PricingReferenceType()
                        {
                            AlternativeConditionPrice = priceTypeArray
                        };
                        invoiceLineType1.PricingReference = pricingReferenceType;

                        if (pLstDetalle[index2].Importe_Descuento > new Decimal(0))
                        {
                            array2 = new AllowanceChargeType[1];

                            AllowanceChargeType[] allowanceChargeTypeArray = array2;
                            AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                            AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;

                            ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                            chargeIndicatorType1.Value = false;

                            ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                            allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;

                            AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                            AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                            chargeReasonCodeType1.Value = "00";

                            AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                            allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;

                            AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                            MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                            factorNumericType1.Value = pLstDetalle[index2].Porcentaje_Descuento / new Decimal(100);

                            MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                            allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;

                            AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                            AmountType2 amountType2_1 = new AmountType2();
                            amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                            amountType2_1.Value = pLstDetalle[index2].Importe_Descuento;

                            AmountType2 amountType2_2 = amountType2_1;
                            allowanceChargeType5.Amount = amountType2_2;

                            AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                            BaseAmountType baseAmountType1 = new BaseAmountType();
                            baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                            baseAmountType1.Value = pLstDetalle[index2].Importe_SubTotal;

                            BaseAmountType baseAmountType2 = baseAmountType1;
                            allowanceChargeType6.BaseAmount = baseAmountType2;

                            AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                            allowanceChargeTypeArray[0] = allowanceChargeType7;

                            invoiceLineType1.AllowanceCharge = array2;
                        }

                        array3 = new TaxSubtotalType[0];

                        TaxAmountType taxAmountType3 = new TaxAmountType();
                        taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType3.Value = pLstDetalle[index2].Importe_IGV;
                        TaxAmountType taxAmountType4 = taxAmountType3;

                        if (pLstDetalle[index2].Importe_IGV > new Decimal(0))
                        {
                            if (pLstDetalle[index2].EsGratuito == false)
                            {
                                Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                                TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                                TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                                TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                                taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                                taxableAmountType1.Value = pLstDetalle[index2].Importe_ValorVenta - pCabecera.Importe_ISC;

                                TaxableAmountType taxableAmountType2 = taxableAmountType1;
                                taxSubtotalType2.TaxableAmount = taxableAmountType2;

                                TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                                TaxAmountType taxAmountType5 = new TaxAmountType();
                                taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                                taxAmountType5.Value = pLstDetalle[index2].Importe_IGV;

                                TaxAmountType taxAmountType6 = taxAmountType5;
                                taxSubtotalType3.TaxAmount = taxAmountType6;

                                TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                                TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                                TaxCategoryType taxCategoryType2 = taxCategoryType1;
                                IDType idType11 = new IDType();
                                idType11.schemeID = "UN/ECE 5305";
                                idType11.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                                idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                                idType11.Value = "S";

                                IDType idType12 = idType11;
                                taxCategoryType2.ID = idType12;

                                TaxCategoryType taxCategoryType3 = taxCategoryType1;
                                PercentType1 percentType1_1 = new PercentType1();
                                percentType1_1.Value = pCabecera.PorcentajeIGV;

                                PercentType1 percentType1_2 = percentType1_1;
                                taxCategoryType3.Percent = percentType1_2;

                                TaxCategoryType taxCategoryType4 = taxCategoryType1;
                                TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                                exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                                exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                                exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                                exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                                TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                                taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                                TaxCategoryType taxCategoryType5 = taxCategoryType1;
                                TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                                TaxSchemeType taxSchemeType2 = taxSchemeType1;
                                IDType idType13 = new IDType();
                                //idType13.schemeID = "UN/ECE 5153";
                                idType13.schemeName = "Codigo de tributos"; //"Tax Schema Identifier";
                                idType13.schemeAgencyName = "PE:SUNAT"; //"United Nations Economic Commission for Europe";
                                idType13.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
                                idType13.Value = "1000";
                                IDType idType14 = idType13;
                                taxSchemeType2.ID = idType14;

                                TaxSchemeType taxSchemeType3 = taxSchemeType1;
                                NameType1 nameType1_5 = new NameType1();
                                nameType1_5.Value = "IGV";

                                NameType1 nameType1_6 = nameType1_5;
                                taxSchemeType3.Name = nameType1_6;

                                TaxSchemeType taxSchemeType4 = taxSchemeType1;
                                TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                                taxTypeCodeType1.Value = "VAT";

                                TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                                taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                                TaxSchemeType taxSchemeType5 = taxSchemeType1;
                                taxCategoryType5.TaxScheme = taxSchemeType5;

                                TaxCategoryType taxCategoryType6 = taxCategoryType1;
                                taxSubtotalType4.TaxCategory = taxCategoryType6;

                                TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                                array3[array3.Length - 1] = taxSubtotalType5;
                            }
                        }

                        if (pLstDetalle[index2].Importe_ISC > new Decimal(0))
                        {
                            Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                            TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                            TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                            TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                            taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                            taxableAmountType1.Value = pLstDetalle[index2].Importe_ValorVenta;

                            TaxableAmountType taxableAmountType2 = taxableAmountType1;
                            taxSubtotalType2.TaxableAmount = taxableAmountType2;

                            TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                            TaxAmountType taxAmountType5 = new TaxAmountType();
                            taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                            taxAmountType5.Value = pLstDetalle[index2].Importe_ISC;

                            TaxAmountType taxAmountType6 = taxAmountType5;
                            taxSubtotalType3.TaxAmount = taxAmountType6;

                            TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                            TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                            TaxCategoryType taxCategoryType2 = taxCategoryType1;
                            IDType idType11 = new IDType();
                            idType11.schemeID = "UN/ECE 5305";
                            idType11.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                            idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                            idType11.Value = "S";

                            IDType idType12 = idType11;
                            taxCategoryType2.ID = idType12;

                            TaxCategoryType taxCategoryType3 = taxCategoryType1;
                            PercentType1 percentType1_1 = new PercentType1();
                            percentType1_1.Value = pLstDetalle[index2].Porcentaje_ISC;

                            PercentType1 percentType1_2 = percentType1_1;
                            taxCategoryType3.Percent = percentType1_2;

                            TaxCategoryType taxCategoryType4 = taxCategoryType1;
                            TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                            exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                            exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                            exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                            exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                            TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                            taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                            TaxCategoryType taxCategoryType5 = taxCategoryType1;
                            TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                            TaxSchemeType taxSchemeType2 = taxSchemeType1;
                            IDType idType13 = new IDType();
                            idType13.schemeID = "UN/ECE 5153";
                            idType13.schemeName = "Tax Schema Identifier";
                            idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                            idType13.Value = "2000";

                            IDType idType14 = idType13;
                            taxSchemeType2.ID = idType14;

                            TaxSchemeType taxSchemeType3 = taxSchemeType1;
                            NameType1 nameType1_5 = new NameType1();
                            nameType1_5.Value = "ISC";

                            NameType1 nameType1_6 = nameType1_5;
                            taxSchemeType3.Name = nameType1_6;

                            TaxSchemeType taxSchemeType4 = taxSchemeType1;
                            TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                            taxTypeCodeType1.Value = "EXC";

                            TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                            taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                            TaxSchemeType taxSchemeType5 = taxSchemeType1;
                            taxCategoryType5.TaxScheme = taxSchemeType5;

                            TaxCategoryType taxCategoryType6 = taxCategoryType1;
                            taxSubtotalType4.TaxCategory = taxCategoryType6;

                            TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                            array3[array3.Length - 1] = taxSubtotalType5;
                        }

                        if (pLstDetalle[index2].EsExonerado)
                        {
                            Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                            TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                            TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                            TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                            taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                            taxableAmountType1.Value = new Decimal(0);

                            TaxableAmountType taxableAmountType2 = taxableAmountType1;
                            taxSubtotalType2.TaxableAmount = taxableAmountType2;

                            TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                            TaxAmountType taxAmountType5 = new TaxAmountType();
                            taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                            taxAmountType5.Value = new Decimal(0);

                            TaxAmountType taxAmountType6 = taxAmountType5;
                            taxSubtotalType3.TaxAmount = taxAmountType6;

                            TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                            TaxCategoryType taxCategoryType1 = new TaxCategoryType();

                            TaxCategoryType taxCategoryType2 = taxCategoryType1;
                            IDType idType11 = new IDType();
                            idType11.schemeID = "UN/ECE 5305";
                            idType11.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                            idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                            idType11.Value = "E";

                            IDType idType12 = idType11;
                            taxCategoryType2.ID = idType12;

                            TaxCategoryType taxCategoryType3 = taxCategoryType1;
                            PercentType1 percentType1_1 = new PercentType1();
                            percentType1_1.Value = pCabecera.PorcentajeIGV;

                            PercentType1 percentType1_2 = percentType1_1;
                            taxCategoryType3.Percent = percentType1_2;

                            TaxCategoryType taxCategoryType4 = taxCategoryType1;
                            TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                            exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                            exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                            exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                            exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                            TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                            taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                            TaxCategoryType taxCategoryType5 = taxCategoryType1;
                            TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                            TaxSchemeType taxSchemeType2 = taxSchemeType1;
                            IDType idType13 = new IDType();
                            idType13.schemeID = "UN/ECE 5153";
                            idType13.schemeName = "Tax Schema Identifier";
                            idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                            idType13.Value = "9997";

                            IDType idType14 = idType13;
                            taxSchemeType2.ID = idType14;

                            TaxSchemeType taxSchemeType3 = taxSchemeType1;
                            NameType1 nameType1_5 = new NameType1();
                            nameType1_5.Value = "EXO";

                            NameType1 nameType1_6 = nameType1_5;
                            taxSchemeType3.Name = nameType1_6;

                            TaxSchemeType taxSchemeType4 = taxSchemeType1;
                            TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                            taxTypeCodeType1.Value = "VAT";

                            TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                            taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                            TaxSchemeType taxSchemeType5 = taxSchemeType1;
                            taxCategoryType5.TaxScheme = taxSchemeType5;

                            TaxCategoryType taxCategoryType6 = taxCategoryType1;
                            taxSubtotalType4.TaxCategory = taxCategoryType6;

                            TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                            array3[array3.Length - 1] = taxSubtotalType5;
                        }

                        if (pLstDetalle[index2].EsInafecto)
                        {
                            Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                            TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                            TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                            TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                            taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                            taxableAmountType1.Value = new Decimal(0);

                            TaxableAmountType taxableAmountType2 = taxableAmountType1;
                            taxSubtotalType2.TaxableAmount = taxableAmountType2;

                            TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                            TaxAmountType taxAmountType5 = new TaxAmountType();
                            taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                            taxAmountType5.Value = pLstDetalle[index2].Importe_ValorVenta;

                            TaxAmountType taxAmountType6 = taxAmountType5;
                            taxSubtotalType3.TaxAmount = taxAmountType6;

                            TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                            TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                            TaxCategoryType taxCategoryType2 = taxCategoryType1;
                            IDType idType11 = new IDType();
                            idType11.schemeID = "UN/ECE 5305";
                            idType11.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                            idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                            idType11.Value = "O";

                            IDType idType12 = idType11;
                            taxCategoryType2.ID = idType12;

                            TaxCategoryType taxCategoryType3 = taxCategoryType1;
                            PercentType1 percentType1_1 = new PercentType1();
                            percentType1_1.Value = pCabecera.PorcentajeIGV;

                            PercentType1 percentType1_2 = percentType1_1;
                            taxCategoryType3.Percent = percentType1_2;

                            TaxCategoryType taxCategoryType4 = taxCategoryType1;
                            TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                            exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                            exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                            exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                            exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                            TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                            taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                            TaxCategoryType taxCategoryType5 = taxCategoryType1;
                            TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                            TaxSchemeType taxSchemeType2 = taxSchemeType1;
                            IDType idType13 = new IDType();
                            idType13.schemeID = "UN/ECE 5153";
                            idType13.schemeName = "Tax Schema Identifier";
                            idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                            idType13.Value = "9998";

                            IDType idType14 = idType13;
                            taxSchemeType2.ID = idType14;

                            TaxSchemeType taxSchemeType3 = taxSchemeType1;
                            NameType1 nameType1_5 = new NameType1();
                            nameType1_5.Value = "INA";

                            NameType1 nameType1_6 = nameType1_5;
                            taxSchemeType3.Name = nameType1_6;

                            TaxSchemeType taxSchemeType4 = taxSchemeType1;
                            TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                            taxTypeCodeType1.Value = "FRE";

                            TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                            taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                            TaxSchemeType taxSchemeType5 = taxSchemeType1;
                            taxCategoryType5.TaxScheme = taxSchemeType5;

                            TaxCategoryType taxCategoryType6 = taxCategoryType1;
                            taxSubtotalType4.TaxCategory = taxCategoryType6;

                            TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                            array3[array3.Length - 1] = taxSubtotalType5;
                        }

                        if (pLstDetalle[index2].EsGratuito)
                        {
                            Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);

                            TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                            TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                            TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                            taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                            taxableAmountType1.Value = new Decimal(0); //pLstDetalle[index2].Importe_SubTotal;

                            TaxableAmountType taxableAmountType2 = taxableAmountType1;
                            taxSubtotalType2.TaxableAmount = taxableAmountType2;

                            TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                            TaxAmountType taxAmountType5 = new TaxAmountType();
                            taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                            taxAmountType5.Value = pLstDetalle[index2].Importe_IGV; //pLstDetalle[index2].Importe_ValorVenta;

                            TaxAmountType taxAmountType6 = taxAmountType5;
                            taxSubtotalType3.TaxAmount = taxAmountType6;

                            TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                            TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                            TaxCategoryType taxCategoryType2 = taxCategoryType1;
                            IDType idType11 = new IDType();
                            idType11.schemeID = "UN/ECE 5305";
                            idType11.schemeName = "Tax Category Identifier"; //"Tax Category identifierField";
                            idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                            idType11.Value = "O";

                            IDType idType12 = idType11;
                            taxCategoryType2.ID = idType12;

                            TaxCategoryType taxCategoryType3 = taxCategoryType1;
                            PercentType1 percentType1_1 = new PercentType1();
                            percentType1_1.Value = pCabecera.PorcentajeIGV;

                            PercentType1 percentType1_2 = percentType1_1;
                            taxCategoryType3.Percent = percentType1_2;

                            TaxCategoryType taxCategoryType4 = taxCategoryType1;
                            TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                            exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                            exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                            exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                            exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                            TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                            taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                            TaxCategoryType taxCategoryType5 = taxCategoryType1;
                            TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                            TaxSchemeType taxSchemeType2 = taxSchemeType1;
                            IDType idType13 = new IDType();
                            //idType13.schemeID = "UN/ECE 5153";
                            idType13.schemeName = "Codigo de tributos"; //"Tax Schema Identifie";
                            idType13.schemeAgencyName = "PE:SUNAT"; //"United Nations Economic Commission for Europe";
                            idType13.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
                            idType13.Value = "9996";

                            IDType idType14 = idType13;
                            taxSchemeType2.ID = idType14;

                            TaxSchemeType taxSchemeType3 = taxSchemeType1;
                            NameType1 nameType1_5 = new NameType1();
                            nameType1_5.Value = "GRA";

                            NameType1 nameType1_6 = nameType1_5;
                            taxSchemeType3.Name = nameType1_6;

                            TaxSchemeType taxSchemeType4 = taxSchemeType1;
                            TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                            taxTypeCodeType1.Value = "FRE";

                            TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                            taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                            TaxSchemeType taxSchemeType5 = taxSchemeType1;
                            taxCategoryType5.TaxScheme = taxSchemeType5;

                            TaxCategoryType taxCategoryType6 = taxCategoryType1;
                            taxSubtotalType4.TaxCategory = taxCategoryType6;

                            TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                            array3[array3.Length - 1] = taxSubtotalType5;
                        }

                        TaxTotalType[] taxTotalTypeArray = new TaxTotalType[1]
                        {
                            new TaxTotalType()
                            {
                              TaxAmount = taxAmountType4,
                              TaxSubtotal = array3
                            }
                        };
                        invoiceLineType1.TaxTotal = taxTotalTypeArray;

                        DescriptionType descriptionType = new DescriptionType();
                        descriptionType.Value = pLstDetalle[index2].Descripcion_Articulo.Trim();

                        DescriptionType[] descriptionTypeArray = new DescriptionType[1]
                        {
                            descriptionType
                        };

                        ItemIdentificationType identificationType7 = new ItemIdentificationType();
                        ItemIdentificationType identificationType8 = identificationType7;
                        IDType idType15 = new IDType();
                        idType15.Value = pLstDetalle[index2].Codigo_Articulo;

                        IDType idType16 = idType15;
                        identificationType8.ID = idType16;

                        ItemIdentificationType identificationType9 = identificationType7;
                        if (string.IsNullOrEmpty(pLstDetalle[index2].Codigo_Producto_Sunat))
                        {
                            invoiceLineType1.Item = new ItemType()
                            {
                                Description = descriptionTypeArray,
                                SellersItemIdentification = identificationType9
                            };
                        }
                        else
                        {
                            ItemClassificationCodeType classificationCodeType1 = new ItemClassificationCodeType();
                            classificationCodeType1.Value = pLstDetalle[index2].Codigo_Producto_Sunat;
                            classificationCodeType1.listID = "UNSPSC";
                            classificationCodeType1.listAgencyName = "GS1 US";
                            classificationCodeType1.listName = "Item Classification";

                            ItemClassificationCodeType classificationCodeType2 = classificationCodeType1;
                            CommodityClassificationType[] classificationTypeArray = new CommodityClassificationType[1]
                            {
                                new CommodityClassificationType()
                                {
                                    ItemClassificationCode = classificationCodeType2
                                }
                            };

                            invoiceLineType1.Item = new ItemType()
                            {
                                Description = descriptionTypeArray,
                                SellersItemIdentification = identificationType9,
                                CommodityClassification = classificationTypeArray
                            };
                        }

                        PriceAmountType priceAmountType3;
                        if (pCabecera.Tipo_Venta == "E")
                        {
                            PriceAmountType priceAmountType4 = new PriceAmountType();
                            priceAmountType4.currencyID = pCabecera.Codigo_Moneda;
                            priceAmountType4.Value = new Decimal(0);
                            priceAmountType3 = priceAmountType4;
                        }
                        else
                        {
                            PriceAmountType priceAmountType4 = new PriceAmountType();
                            priceAmountType4.currencyID = pCabecera.Codigo_Moneda;
                            priceAmountType4.Value = pLstDetalle[index2].EsGratuito ? new Decimal(0) : Convert.ToDecimal(pLstDetalle[index2].Precio_Unitario_SinIGV);
                            priceAmountType3 = priceAmountType4;
                        }

                        invoiceLineType1.Price = new PriceType()
                        {
                            PriceAmount = priceAmountType3
                        };
                        invoiceLineTypeArray[index2] = invoiceLineType1;
                    }
                }
                this.XMLInvoice.InvoiceLine = invoiceLineTypeArray;

                if (pLstFormaPago != null)
                {
                    if (pLstFormaPago.Count > 0)
                    {
                        PaymentTermsType[] paymentTermsTypeArrayFP1 = new PaymentTermsType[pLstFormaPago.Count];
                        for (int index2 = 0; index2 <= pLstFormaPago.Count - 1; ++index2)
                        {
                            PaymentTermsType paymentTermsType1 = new PaymentTermsType();
                            PaymentTermsType paymentTermsType2 = paymentTermsType1;
                            IDType idType11 = new IDType();
                            idType11.Value = "FormaPago";
                            IDType idType12 = idType11;
                            paymentTermsType2.ID = idType12;
                            PaymentTermsType paymentTermsType3 = paymentTermsType1;
                            PaymentTermsType paymentTermsType4 = paymentTermsType3;
                            PaymentMeansIDType paymentMeansIDType1 = new PaymentMeansIDType();
                            paymentMeansIDType1.Value = pLstFormaPago[index2].Forma_Pago;
                            PaymentMeansIDType paymentMeansIDType2 = paymentMeansIDType1;
                            paymentTermsType4.PaymentMeansID = paymentMeansIDType2;
                            PaymentTermsType paymentTermsType5 = paymentTermsType1;
                            PaymentTermsType paymentTermsType6 = paymentTermsType1;
                            AmountType2 amountType2_1 = new AmountType2();
                            amountType2_1.currencyID = pLstFormaPago[index2].Codigo_Moneda;
                            amountType2_1.Value = pLstFormaPago[index2].Monto_Neto;
                            AmountType2 amountType2_2 = amountType2_1;
                            paymentTermsType5.Amount = amountType2_2;
                            paymentTermsTypeArrayFP1[index2] = paymentTermsType6;
                            if (pLstFormaPago[index2].Forma_Pago != "Credito" && pLstFormaPago[index2].Forma_Pago != "Contado")
                            {
                                PaymentTermsType paymentTermsType7 = paymentTermsType1;
                                PaymentTermsType paymentTermsType8 = paymentTermsType7;
                                PaymentDueDateType paymentDueDateType1 = new PaymentDueDateType();
                                paymentDueDateType1.Value = pLstFormaPago[index2].Fecha_Pago;
                                PaymentDueDateType paymentDueDateType2 = paymentDueDateType1;
                                paymentTermsType8.PaymentDueDate = paymentDueDateType2;
                            }
                        }
                        this.XMLInvoice.PaymentTerms = paymentTermsTypeArrayFP1;
                    }
                }

                if (pLstGuias != null)
                {
                    if (pLstGuias.Count > 0)
                    {
                DocumentReferenceType[] documentReferenceTypeArray2 = new DocumentReferenceType[pLstGuias.Count];
                for (int index2 = 0; index2 <= pLstGuias.Count - 1; ++index2)
                {
                    DocumentReferenceType documentReferenceType1 = new DocumentReferenceType();
                    DocumentReferenceType documentReferenceType2 = documentReferenceType1;

                    IDType idType9 = new IDType();
                    idType9.Value = pLstGuias[index2].Serie_Guia + "-" + pLstGuias[index2].Numero_Guia;

                    IDType idType10 = idType9;
                    documentReferenceType2.ID = idType10;

                    DocumentReferenceType documentReferenceType3 = documentReferenceType1;
                    DocumentTypeCodeType documentTypeCodeType1 = new DocumentTypeCodeType();
                    documentTypeCodeType1.listAgencyName = "PE:SUNAT";
                    documentTypeCodeType1.listName = "SUNAT: Identificador de documento relacionado";
                    documentTypeCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01";
                    documentTypeCodeType1.Value = pLstGuias[index2].Codigo_Guia;

                    DocumentTypeCodeType documentTypeCodeType2 = documentTypeCodeType1;
                    documentReferenceType3.DocumentTypeCode = documentTypeCodeType2;

                    DocumentReferenceType documentReferenceType4 = documentReferenceType1;
                    documentReferenceTypeArray2[index2] = documentReferenceType4;
                }
                this.XMLInvoice.DespatchDocumentReference = documentReferenceTypeArray2;
            }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraNotaCredito(ComprobanteCabecera pCabecera, List<ComprobanteDetalle> pLstDetalle)
        {
            try
            {
                this.XMLCreditNote = new CreditNoteType();

                this.oLstUBLExtensionType[0] = new UBLExtensionType()
                {
                    ExtensionContent = new XmlDocument().CreateElement("dummy")
                };

                this.XMLCreditNote.UBLExtensions = this.oLstUBLExtensionType;

                PartyIdentificationType identificationType1 = new PartyIdentificationType();

                PartyIdentificationType identificationType2 = identificationType1;
                IDType idType1 = new IDType();
                idType1.Value = pCabecera.NroDoc_Emisor;

                IDType idType2 = idType1;
                identificationType2.ID = idType2;

                PartyIdentificationType identificationType3 = identificationType1;
                PartyNameType partyNameType1 = new PartyNameType();
                PartyNameType partyNameType2 = partyNameType1;
                NameType1 nameType1_1 = new NameType1();
                nameType1_1.Value = pCabecera.RSocial_Emisor;

                NameType1 nameType1_2 = nameType1_1;
                partyNameType2.Name = nameType1_2;

                PartyNameType partyNameType3 = partyNameType1;
                PartyType partyType = new PartyType()
                {
                    PartyIdentification = new PartyIdentificationType[1]
                    {
                      identificationType3
                    },
                    PartyName = new PartyNameType[1] { partyNameType3 }
                };

                AttachmentType attachmentType1 = new AttachmentType();
                AttachmentType attachmentType2 = attachmentType1;
                ExternalReferenceType externalReferenceType1 = new ExternalReferenceType();

                ExternalReferenceType externalReferenceType2 = externalReferenceType1;
                URIType uriType1 = new URIType();
                uriType1.Value = "#SignatureKG";

                URIType uriType2 = uriType1;
                externalReferenceType2.URI = uriType2;

                ExternalReferenceType externalReferenceType3 = externalReferenceType1;
                attachmentType2.ExternalReference = externalReferenceType3;

                AttachmentType attachmentType3 = attachmentType1;
                SignatureType signatureType1 = new SignatureType();
                SignatureType signatureType2 = signatureType1;
                IDType idType3 = new IDType();
                idType3.Value = pCabecera.NroDoc_Emisor;

                IDType idType4 = idType3;
                signatureType2.ID = idType4;

                signatureType1.SignatoryParty = partyType;
                signatureType1.DigitalSignatureAttachment = attachmentType3;

                this.XMLCreditNote.Signature = new SignatureType[1]
                {
                    signatureType1
                };

                CreditNoteType creditNoteType1 = this.XMLCreditNote;

                UBLVersionIDType ublVersionIdType1 = new UBLVersionIDType();
                ublVersionIdType1.Value = "2.1";

                UBLVersionIDType ublVersionIdType2 = ublVersionIdType1;
                creditNoteType1.UBLVersionID = ublVersionIdType2;

                CreditNoteType creditNoteType2 = this.XMLCreditNote;
                CustomizationIDType customizationIdType1 = new CustomizationIDType();
                customizationIdType1.Value = "2.0";

                CustomizationIDType customizationIdType2 = customizationIdType1;
                creditNoteType2.CustomizationID = customizationIdType2;

                CreditNoteType creditNoteType3 = this.XMLCreditNote;
                ProfileIDType profileIdType1 = new ProfileIDType();
                profileIdType1.schemeName = "Tipo de Operacion"; //"SUNAT:Identificador de Tipo de Operacion";
                profileIdType1.schemeAgencyName = "PE:SUNAT";
                profileIdType1.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17";
                profileIdType1.Value = pCabecera.Tipo_Venta == "E" ? "0102" : (pCabecera.EsAnticipo ? "0104" : "0101");

                ProfileIDType profileIdType2 = profileIdType1;
                creditNoteType3.ProfileID = profileIdType2;

                CreditNoteType creditNoteType4 = this.XMLCreditNote;
                IDType idType5 = new IDType();
                idType5.Value = pCabecera.Serie_Documento + "-" + pCabecera.Numero_Documento;

                IDType idType6 = idType5;
                creditNoteType4.ID = idType6;

                CreditNoteType creditNoteType5 = this.XMLCreditNote;
                IssueDateType issueDateType1 = new IssueDateType();
                issueDateType1.Value = pCabecera.Fecha_Emision;

                IssueDateType issueDateType2 = issueDateType1;
                creditNoteType5.IssueDate = issueDateType2;

                CreditNoteType creditNoteType6 = this.XMLCreditNote;
                IssueTimeType issueTimeType1 = new IssueTimeType();
                issueTimeType1.TimeString = pCabecera.Hora_Emision;

                IssueTimeType issueTimeType2 = issueTimeType1;
                creditNoteType6.IssueTime = issueTimeType2;

                NoteType[] array1 = new NoteType[1];
                NoteType[] noteTypeArray1 = array1;
                int index1 = array1.Length - 1;
                NoteType noteType1 = new NoteType();
                noteType1.languageLocaleID = "1000";
                noteType1.Value = pCabecera.Texto_Importe_Total;

                NoteType noteType2 = noteType1;
                noteTypeArray1[index1] = noteType2;

                if (pCabecera.Importe_Total == pCabecera.Importe_Gratuito)
                {
                    Array.Resize<NoteType>(ref array1, array1.Length + 1);

                    NoteType[] noteTypeArray2 = array1;
                    int index2 = array1.Length - 1;

                    NoteType noteType3 = new NoteType();
                    noteType3.languageLocaleID = "1002";
                    noteType3.Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE";

                    NoteType noteType4 = noteType3;
                    noteTypeArray2[index2] = noteType4;
                }
                this.XMLCreditNote.Note = array1;

                CreditNoteType creditNoteType7 = this.XMLCreditNote;
                DocumentCurrencyCodeType currencyCodeType1 = new DocumentCurrencyCodeType();
                currencyCodeType1.listID = "ISO 4217 Alpha";
                currencyCodeType1.listName = "Currency";
                currencyCodeType1.listAgencyName = "United Nations Economic Commission for Europe";
                currencyCodeType1.Value = pCabecera.Codigo_Moneda;

                DocumentCurrencyCodeType currencyCodeType2 = currencyCodeType1;
                creditNoteType7.DocumentCurrencyCode = currencyCodeType2;

                ResponseType responseType1 = new ResponseType();
                ResponseType responseType2 = responseType1;
                ReferenceIDType referenceIdType1 = new ReferenceIDType();
                referenceIdType1.Value = pCabecera.Documento_Ref;

                ReferenceIDType referenceIdType2 = referenceIdType1;
                responseType2.ReferenceID = referenceIdType2;

                ResponseType responseType3 = responseType1;
                ResponseCodeType responseCodeType1 = new ResponseCodeType();
                responseCodeType1.listAgencyName = "PE:SUNAT";
                responseCodeType1.listName = "Tipo de nota de credito";
                responseCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo09";
                responseCodeType1.Value = pCabecera.Codigo_Motivo_Ref;

                ResponseCodeType responseCodeType2 = responseCodeType1;
                responseType3.ResponseCode = responseCodeType2;

                ResponseType responseType4 = responseType1;

                DescriptionType[] descriptionTypeArray1 = new DescriptionType[1];
                DescriptionType[] descriptionTypeArray2 = descriptionTypeArray1;
                DescriptionType descriptionType1 = new DescriptionType();
                descriptionType1.Value = pCabecera.Descripcion_Motivo_Ref;

                DescriptionType descriptionType2 = descriptionType1;
                descriptionTypeArray2[0] = descriptionType2;

                DescriptionType[] descriptionTypeArray3 = descriptionTypeArray1;
                responseType4.Description = descriptionTypeArray3;

                this.XMLCreditNote.DiscrepancyResponse = new ResponseType[1]
                {
                    responseType1
                };

                DocumentReferenceType documentReferenceType1 = new DocumentReferenceType();
                DocumentReferenceType documentReferenceType2 = documentReferenceType1;
                IDType idType7 = new IDType();
                idType7.Value = pCabecera.Documento_Ref;

                IDType idType8 = idType7;
                documentReferenceType2.ID = idType8;

                DocumentReferenceType documentReferenceType3 = documentReferenceType1;
                IssueDateType issueDateType3 = new IssueDateType();
                issueDateType3.Value = pCabecera.Fecha_Documento_Ref.Value;

                IssueDateType issueDateType4 = issueDateType3;
                documentReferenceType3.IssueDate = issueDateType4;

                DocumentReferenceType documentReferenceType4 = documentReferenceType1;
                DocumentTypeCodeType documentTypeCodeType1 = new DocumentTypeCodeType();
                documentTypeCodeType1.listAgencyName = "PE:SUNAT";
                documentTypeCodeType1.listName = "Tipo de Documento";
                documentTypeCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01";
                documentTypeCodeType1.Value = pCabecera.Codigo_Documento_Ref;

                DocumentTypeCodeType documentTypeCodeType2 = documentTypeCodeType1;
                documentReferenceType4.DocumentTypeCode = documentTypeCodeType2;

                DocumentReferenceType documentReferenceType5 = documentReferenceType1;
                this.XMLCreditNote.BillingReference = new BillingReferenceType[1]
                {
                    new BillingReferenceType()
                    {
                        InvoiceDocumentReference = documentReferenceType5
                    }
                };

                PartyNameType[] partyNameTypeArray1 = new PartyNameType[1];
                PartyNameType[] partyNameTypeArray2 = partyNameTypeArray1;
                PartyNameType partyNameType4 = new PartyNameType();
                PartyNameType partyNameType5 = partyNameType4;
                NameType1 nameType1_3 = new NameType1();
                nameType1_3.Value = pCabecera.NombreCorto_Emisor;

                NameType1 nameType1_4 = nameType1_3;
                partyNameType5.Name = nameType1_4;

                PartyNameType partyNameType6 = partyNameType4;
                partyNameTypeArray2[0] = partyNameType6;

                PartyLegalEntityType[] partyLegalEntityTypeArray1 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray2 = partyLegalEntityTypeArray1;

                PartyLegalEntityType partyLegalEntityType1 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType2 = partyLegalEntityType1;

                RegistrationNameType registrationNameType1 = new RegistrationNameType();
                registrationNameType1.Value = pCabecera.RSocial_Emisor;

                RegistrationNameType registrationNameType2 = registrationNameType1;
                partyLegalEntityType2.RegistrationName = registrationNameType2;

                PartyLegalEntityType partyLegalEntityType3 = partyLegalEntityType1;

                AddressType addressType1 = new AddressType();
                AddressType addressType2 = addressType1;
                CountrySubentityType countrySubentityType1 = new CountrySubentityType();
                countrySubentityType1.Value = pCabecera.Dpto_Emisor;

                CountrySubentityType countrySubentityType2 = countrySubentityType1;
                addressType2.CountrySubentity = countrySubentityType2;

                AddressType addressType3 = addressType1;
                CityNameType cityNameType1 = new CityNameType();
                cityNameType1.Value = pCabecera.Prov_Emisor;

                CityNameType cityNameType2 = cityNameType1;
                addressType3.CityName = cityNameType2;

                AddressType addressType4 = addressType1;
                DistrictType districtType1 = new DistrictType();
                districtType1.Value = pCabecera.Dist_Emisor;

                DistrictType districtType2 = districtType1;
                addressType4.District = districtType2;

                AddressType addressType5 = addressType1;
                CountryType countryType1 = new CountryType();
                CountryType countryType2 = countryType1;
                IdentificationCodeType identificationCodeType1 = new IdentificationCodeType();
                identificationCodeType1.listID = "ISO 3166-1";
                identificationCodeType1.listAgencyName = "United Nations Economic Commission for Europe";
                identificationCodeType1.listName = "Country";
                identificationCodeType1.Value = pCabecera.CodPais_Emisor;

                IdentificationCodeType identificationCodeType2 = identificationCodeType1;
                countryType2.IdentificationCode = identificationCodeType2;

                CountryType countryType3 = countryType1;
                addressType5.Country = countryType3;

                AddressType addressType6 = addressType1;
                AddressTypeCodeType addressTypeCodeType1 = new AddressTypeCodeType();
                addressTypeCodeType1.listAgencyName = "PE:SUNAT";
                addressTypeCodeType1.listName = "Establecimientos anexos";
                addressTypeCodeType1.Value = pCabecera.Codigo_Domicilio_Emisor;

                AddressTypeCodeType addressTypeCodeType2 = addressTypeCodeType1;
                addressType6.AddressTypeCode = addressTypeCodeType2;

                AddressType addressType7 = addressType1;
                partyLegalEntityType3.RegistrationAddress = addressType7;

                PartyLegalEntityType partyLegalEntityType4 = partyLegalEntityType1;
                partyLegalEntityTypeArray2[0] = partyLegalEntityType4;

                PartyIdentificationType[] identificationTypeArray1 = new PartyIdentificationType[1];
                PartyIdentificationType[] identificationTypeArray2 = identificationTypeArray1;
                PartyIdentificationType identificationType4 = new PartyIdentificationType();
                PartyIdentificationType identificationType5 = identificationType4;

                IDType idType9 = new IDType();
                idType9.schemeID = pCabecera.TipoDoc_Emisor;
                idType9.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                idType9.schemeAgencyName = "PE:SUNAT";
                idType9.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                idType9.Value = pCabecera.NroDoc_Emisor;

                IDType idType10 = idType9;
                identificationType5.ID = idType10;

                PartyIdentificationType identificationType6 = identificationType4;
                identificationTypeArray2[0] = identificationType6;

                this.XMLCreditNote.AccountingSupplierParty = new SupplierPartyType()
                {
                    Party = new PartyType()
                    {
                        PartyName = partyNameTypeArray1,
                        PartyLegalEntity = partyLegalEntityTypeArray1,
                        PartyIdentification = identificationTypeArray1
                    }
                };

                PartyLegalEntityType[] partyLegalEntityTypeArray3 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray4 = partyLegalEntityTypeArray3;
                PartyLegalEntityType partyLegalEntityType5 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType6 = partyLegalEntityType5;

                RegistrationNameType registrationNameType3 = new RegistrationNameType();
                registrationNameType3.Value = pCabecera.RSocial_Receptor;

                RegistrationNameType registrationNameType4 = registrationNameType3;
                partyLegalEntityType6.RegistrationName = registrationNameType4;

                PartyLegalEntityType partyLegalEntityType7 = partyLegalEntityType5;
                partyLegalEntityTypeArray4[0] = partyLegalEntityType7;

                PartyIdentificationType[] identificationTypeArray3 = new PartyIdentificationType[1];
                if (pCabecera.Tipo_Venta == "L")
                {
                    PartyIdentificationType[] identificationTypeArray4 = identificationTypeArray3;
                    PartyIdentificationType identificationType7 = new PartyIdentificationType();
                    PartyIdentificationType identificationType8 = identificationType7;

                    IDType idType11 = new IDType();
                    idType11.schemeID = pCabecera.TipoDoc_Receptor;
                    idType11.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                    idType11.schemeAgencyName = "PE:SUNAT";
                    idType11.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                    idType11.Value = pCabecera.NroDoc_Receptor;

                    IDType idType12 = idType11;
                    identificationType8.ID = idType12;

                    PartyIdentificationType identificationType9 = identificationType7;
                    identificationTypeArray4[0] = identificationType9;
                }
                else
                {
                    PartyIdentificationType[] identificationTypeArray4 = identificationTypeArray3;
                    PartyIdentificationType identificationType7 = new PartyIdentificationType();
                    PartyIdentificationType identificationType8 = identificationType7;

                    IDType idType11 = new IDType();
                    idType11.schemeID = "-";
                    idType11.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                    idType11.schemeAgencyName = "PE:SUNAT";
                    idType11.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                    idType11.Value = "0";

                    IDType idType12 = idType11;
                    identificationType8.ID = idType12;

                    PartyIdentificationType identificationType9 = identificationType7;
                    identificationTypeArray4[0] = identificationType9;
                }

                this.XMLCreditNote.AccountingCustomerParty = new CustomerPartyType()
                {
                    Party = new PartyType()
                    {
                        PartyLegalEntity = partyLegalEntityTypeArray3,
                        PartyIdentification = identificationTypeArray3
                    }
                };

                if (pCabecera.Importe_DctoGlobal != new Decimal(0))
                {
                    AllowanceChargeType[] allowanceChargeTypeArray1 = new AllowanceChargeType[1];
                    AllowanceChargeType[] allowanceChargeTypeArray2 = allowanceChargeTypeArray1;
                    AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                    AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;

                    ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                    chargeIndicatorType1.Value = false;

                    ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                    allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;

                    AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                    AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                    chargeReasonCodeType1.Value = "00";

                    AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                    allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;

                    AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                    MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                    factorNumericType1.Value = pCabecera.PorcentajeDctoGlobal / new Decimal(100);

                    MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                    allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;

                    AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                    AmountType2 amountType2_1 = new AmountType2();
                    amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                    amountType2_1.Value = pCabecera.Importe_DctoGlobal;

                    AmountType2 amountType2_2 = amountType2_1;
                    allowanceChargeType5.Amount = amountType2_2;

                    AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                    BaseAmountType baseAmountType1 = new BaseAmountType();
                    baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    baseAmountType1.Value = pCabecera.Importe_SubTotal - pCabecera.Importe_Descuento;

                    BaseAmountType baseAmountType2 = baseAmountType1;
                    allowanceChargeType6.BaseAmount = baseAmountType2;

                    AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                    allowanceChargeTypeArray2[0] = allowanceChargeType7;

                    this.XMLCreditNote.AllowanceCharge = allowanceChargeTypeArray1;
                }

                TaxSubtotalType[] array2 = new TaxSubtotalType[0];

                TaxAmountType taxAmountType1 = new TaxAmountType();
                taxAmountType1.currencyID = pCabecera.Codigo_Moneda;
                taxAmountType1.Value = pCabecera.Importe_IGV + pCabecera.Importe_ISC;
                TaxAmountType taxAmountType2 = taxAmountType1;

                if (pCabecera.Importe_IGV > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;

                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Gravado + pCabecera.Importe_ISC;

                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_IGV;

                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;

                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;

                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "S";

                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;

                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "1000";

                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;

                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "IGV";

                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "VAT";

                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }

                if (pCabecera.Importe_ISC > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Base_ISC;

                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_ISC;

                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;

                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();

                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "S";

                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "2000";

                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;

                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "ISC";

                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "EXC";

                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }

                if (pCabecera.Importe_OtrosTributos > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;

                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Base_OtrosTributos;

                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_OtrosTributos;

                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;

                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;

                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "S";

                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();

                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "9999";

                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;

                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "OTR";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "OTH";

                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }

                if (pCabecera.Importe_Exonerado > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Exonerado;

                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);

                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;

                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "E";

                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "9997";

                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;

                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "EXO";

                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "VAT";

                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }

                if (pCabecera.Importe_Inafecto > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Inafecto;

                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);

                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;

                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "O";

                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "9998";

                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;

                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "INA";

                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "FRE";

                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }

                if (pCabecera.Importe_Gratuito > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();

                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Gratuito;

                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;

                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);

                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;

                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "Z";

                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;

                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "9996";

                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;

                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "GRA";

                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;

                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "FRE";

                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;

                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;

                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;

                }

                this.XMLCreditNote.TaxTotal = new TaxTotalType[1]
                {
                  new TaxTotalType()
                  {
                    TaxAmount = taxAmountType2,
                    TaxSubtotal = array2
                  }
                };

                if (pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion > new Decimal(0))
                {
                    CreditNoteType creditNoteType8 = this.XMLCreditNote;

                    MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();
                    MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pCabecera.Importe_SubTotal;

                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    monetaryTotalType2.LineExtensionAmount = extensionAmountType2;

                    MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                    TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                    exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    exclusiveAmountType1.Value = pCabecera.Importe_Total;

                    TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                    monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;

                    MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                    AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                    allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;

                    AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                    monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;

                    MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                    ChargeTotalAmountType chargeTotalAmountType1 = new ChargeTotalAmountType();
                    chargeTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    chargeTotalAmountType1.Value = pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;

                    ChargeTotalAmountType chargeTotalAmountType2 = chargeTotalAmountType1;
                    monetaryTotalType5.ChargeTotalAmount = chargeTotalAmountType2;

                    MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                    PayableAmountType payableAmountType1 = new PayableAmountType();
                    payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;

                    PayableAmountType payableAmountType2 = payableAmountType1;
                    monetaryTotalType6.PayableAmount = payableAmountType2;

                    MonetaryTotalType monetaryTotalType7 = monetaryTotalType1;
                    creditNoteType8.LegalMonetaryTotal = monetaryTotalType7;
                }
                else
                {
                    CreditNoteType creditNoteType8 = this.XMLCreditNote;

                    MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();
                    MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pCabecera.Importe_SubTotal;

                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    monetaryTotalType2.LineExtensionAmount = extensionAmountType2;

                    MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                    TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                    exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    exclusiveAmountType1.Value = pCabecera.Importe_Total;

                    TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                    monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;

                    MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                    AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                    allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;

                    AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                    monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;

                    MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                    PayableAmountType payableAmountType1 = new PayableAmountType();
                    payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_Percepcion;

                    PayableAmountType payableAmountType2 = payableAmountType1;
                    monetaryTotalType5.PayableAmount = payableAmountType2;

                    MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                    creditNoteType8.LegalMonetaryTotal = monetaryTotalType6;
                }

                CreditNoteLineType[] creditNoteLineTypeArray = new CreditNoteLineType[pLstDetalle.Count];
                for (int index2 = 0; index2 < pLstDetalle.Count; ++index2)
                {
                    CreditNoteLineType creditNoteLineType1 = new CreditNoteLineType();
                    CreditNoteLineType creditNoteLineType2 = creditNoteLineType1;
                    IDType idType11 = new IDType();
                    idType11.Value = pLstDetalle[index2].NroItem.Trim();

                    IDType idType12 = idType11;
                    creditNoteLineType2.ID = idType12;

                    CreditNoteLineType creditNoteLineType3 = creditNoteLineType1;
                    CreditedQuantityType creditedQuantityType1 = new CreditedQuantityType();
                    creditedQuantityType1.Value = pLstDetalle[index2].Cantidad;
                    creditedQuantityType1.unitCode = pLstDetalle[index2].Codigo_Unidad;
                    creditedQuantityType1.unitCodeListID = "UN/ECE rec 20";
                    creditedQuantityType1.unitCodeListAgencyName = "United Nations Economic Commission for Europe";

                    CreditedQuantityType creditedQuantityType2 = creditedQuantityType1;
                    creditNoteLineType3.CreditedQuantity = creditedQuantityType2;

                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pLstDetalle[index2].EsGratuito ? new Decimal(0) : Convert.ToDecimal(pLstDetalle[index2].Importe_ValorVenta);

                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    creditNoteLineType1.LineExtensionAmount = extensionAmountType2;

                    PriceType[] priceTypeArray = new PriceType[1];
                    PriceType priceType1 = new PriceType();
                    PriceType priceType2 = priceType1;
                    PriceAmountType priceAmountType1 = new PriceAmountType();
                    priceAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    priceAmountType1.Value = pLstDetalle[index2].Precio_Unitario_ConIGV;

                    PriceAmountType priceAmountType2 = priceAmountType1;
                    priceType2.PriceAmount = priceAmountType2;

                    PriceType priceType3 = priceType1;
                    PriceTypeCodeType priceTypeCodeType1 = new PriceTypeCodeType();
                    priceTypeCodeType1.listName = "Tipo de Precio"; //"SUNAT:Indicador de Tipo de Precio";
                    priceTypeCodeType1.listAgencyName = "PE:SUNAT";
                    priceTypeCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16";
                    priceTypeCodeType1.Value = pCabecera.Tipo_Venta == "E" || pLstDetalle[index2].EsGratuito ? "02" : "01";

                    PriceTypeCodeType priceTypeCodeType2 = priceTypeCodeType1;
                    priceType3.PriceTypeCode = priceTypeCodeType2;

                    PriceType priceType4 = priceType1;
                    priceTypeArray[0] = priceType4;

                    PricingReferenceType pricingReferenceType = new PricingReferenceType()
                    {
                        AlternativeConditionPrice = priceTypeArray
                    };
                    creditNoteLineType1.PricingReference = pricingReferenceType;

                    if (pLstDetalle[index2].Importe_Descuento > new Decimal(0))
                    {
                        AllowanceChargeType[] allowanceChargeTypeArray1 = new AllowanceChargeType[1];
                        AllowanceChargeType[] allowanceChargeTypeArray2 = allowanceChargeTypeArray1;
                        AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                        AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                        ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                        chargeIndicatorType1.Value = false;

                        ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                        allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;

                        AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                        AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                        chargeReasonCodeType1.Value = "00";

                        AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                        allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;

                        AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                        MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                        factorNumericType1.Value = pLstDetalle[index2].Porcentaje_Descuento / new Decimal(100);

                        MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                        allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;

                        AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                        AmountType2 amountType2_1 = new AmountType2();
                        amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                        amountType2_1.Value = pLstDetalle[index2].Importe_Descuento;

                        AmountType2 amountType2_2 = amountType2_1;
                        allowanceChargeType5.Amount = amountType2_2;

                        AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                        BaseAmountType baseAmountType1 = new BaseAmountType();
                        baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        baseAmountType1.Value = pLstDetalle[index2].Importe_SubTotal;

                        BaseAmountType baseAmountType2 = baseAmountType1;
                        allowanceChargeType6.BaseAmount = baseAmountType2;

                        AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                        allowanceChargeTypeArray2[0] = allowanceChargeType7;

                        creditNoteLineType1.AllowanceCharge = allowanceChargeTypeArray1;
                    }

                    array2 = new TaxSubtotalType[0];
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pLstDetalle[index2].Importe_IGV;

                    TaxAmountType taxAmountType4 = taxAmountType3;

                    if (pLstDetalle[index2].Importe_IGV > new Decimal(0))
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = pLstDetalle[index2].Importe_ValorVenta - pCabecera.Importe_ISC;

                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;

                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_IGV;

                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;

                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "S";

                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;

                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;

                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;

                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectacion del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        //idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Codigo de tributos"; //"Tax Schema Identifier";
                        idType15.schemeAgencyName = "PE:SUNAT"; //"United Nations Economic Commission for Europe";
                        idType15.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
                        idType15.Value = "1000";

                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;

                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "IGV";

                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;

                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "VAT";

                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;

                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;

                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }

                    if (pLstDetalle[index2].Importe_ISC > new Decimal(0))
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = pLstDetalle[index2].Importe_ValorVenta;

                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;

                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_ISC;

                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;

                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "S";

                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;

                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pLstDetalle[index2].Porcentaje_ISC;

                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;

                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectacion del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Tax Schema Identifier";
                        idType15.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType15.Value = "2000";

                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;

                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "ISC";

                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;

                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "EXC";

                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;

                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;

                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }

                    if (pLstDetalle[index2].EsExonerado)
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = new Decimal(0);

                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;

                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = new Decimal(0);

                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;

                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "E";

                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;

                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;

                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;

                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectacion del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Tax Schema Identifier";
                        idType15.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType15.Value = "9997";

                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;

                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "EXO";

                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;

                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "VAT";

                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;

                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;

                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }

                    if (pLstDetalle[index2].EsInafecto)
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = new Decimal(0);

                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;

                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_ValorVenta;

                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;

                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "O";

                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;

                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;

                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;

                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectacion del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Tax Schema Identifier";
                        idType15.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType15.Value = "9998";
                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;

                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "INA";

                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;

                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "FRE";

                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;

                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;

                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }

                    if (pLstDetalle[index2].EsGratuito)
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);

                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = new Decimal(0);

                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;

                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_ValorVenta;

                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;

                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "O";

                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;

                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;

                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;

                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectacion del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;

                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;

                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Tax Schema Identifie";
                        idType15.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType15.Value = "9996";

                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;

                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "GRA";

                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;

                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "FRE";

                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;

                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;

                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;

                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }

                    TaxTotalType[] taxTotalTypeArray = new TaxTotalType[1]
                    {
                        new TaxTotalType()
                        {
                          TaxAmount = taxAmountType4,
                          TaxSubtotal = array2
                        }
                    };
                    creditNoteLineType1.TaxTotal = taxTotalTypeArray;

                    DescriptionType descriptionType3 = new DescriptionType();
                    descriptionType3.Value = pLstDetalle[index2].Descripcion_Articulo.Trim();
                    DescriptionType[] descriptionTypeArray4 = new DescriptionType[1]
                    {
                        descriptionType3
                    };

                    ItemIdentificationType identificationType7 = new ItemIdentificationType();
                    ItemIdentificationType identificationType8 = identificationType7;
                    IDType idType17 = new IDType();
                    idType17.Value = pLstDetalle[index2].Codigo_Articulo;

                    IDType idType18 = idType17;
                    identificationType8.ID = idType18;

                    ItemIdentificationType identificationType9 = identificationType7;
                    if (string.IsNullOrEmpty(pLstDetalle[index2].Codigo_Producto_Sunat))
                    {
                        creditNoteLineType1.Item = new ItemType()
                        {
                            Description = descriptionTypeArray4,
                            SellersItemIdentification = identificationType9
                        };
                    }
                    else
                    {
                        ItemClassificationCodeType classificationCodeType1 = new ItemClassificationCodeType();
                        classificationCodeType1.Value = pLstDetalle[index2].Codigo_Producto_Sunat;
                        classificationCodeType1.listID = "UNSPSC";
                        classificationCodeType1.listAgencyName = "GS1 US";
                        classificationCodeType1.listName = "Item Classification";
                        ItemClassificationCodeType classificationCodeType2 = classificationCodeType1;

                        CommodityClassificationType[] classificationTypeArray = new CommodityClassificationType[1]
                        {
                          new CommodityClassificationType()
                          {
                            ItemClassificationCode = classificationCodeType2
                          }
                        };

                        creditNoteLineType1.Item = new ItemType()
                        {
                            Description = descriptionTypeArray4,
                            SellersItemIdentification = identificationType9,
                            CommodityClassification = classificationTypeArray
                        };
                    }

                    PriceAmountType priceAmountType3;
                    if (pCabecera.Tipo_Venta == "E")
                    {
                        PriceAmountType priceAmountType4 = new PriceAmountType();
                        priceAmountType4.currencyID = pCabecera.Codigo_Moneda;
                        priceAmountType4.Value = new Decimal(0);
                        priceAmountType3 = priceAmountType4;
                    }
                    else
                    {
                        PriceAmountType priceAmountType4 = new PriceAmountType();
                        priceAmountType4.currencyID = pCabecera.Codigo_Moneda;
                        priceAmountType4.Value = pLstDetalle[index2].EsGratuito ? new Decimal(0) : Convert.ToDecimal(pLstDetalle[index2].Precio_Unitario_SinIGV);
                        priceAmountType3 = priceAmountType4;
                    }

                    creditNoteLineType1.Price = new PriceType()
                    {
                        PriceAmount = priceAmountType3
                    };
                    creditNoteLineTypeArray[index2] = creditNoteLineType1;
                }
                this.XMLCreditNote.CreditNoteLine = creditNoteLineTypeArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraNotaDebito(ComprobanteCabecera pCabecera, List<ComprobanteDetalle> pLstDetalle)
        {
            try
            {
                this.XMLDebitNote = new DebitNoteType();
                this.oLstUBLExtensionType[0] = new UBLExtensionType()
                {
                    ExtensionContent = new XmlDocument().CreateElement("dummy")
                };
                this.XMLDebitNote.UBLExtensions = this.oLstUBLExtensionType;
                PartyIdentificationType identificationType1 = new PartyIdentificationType();
                PartyIdentificationType identificationType2 = identificationType1;
                IDType idType1 = new IDType();
                idType1.Value = pCabecera.NroDoc_Emisor;
                IDType idType2 = idType1;
                identificationType2.ID = idType2;
                PartyIdentificationType identificationType3 = identificationType1;
                PartyNameType partyNameType1 = new PartyNameType();
                PartyNameType partyNameType2 = partyNameType1;
                NameType1 nameType1_1 = new NameType1();
                nameType1_1.Value = pCabecera.RSocial_Emisor;
                NameType1 nameType1_2 = nameType1_1;
                partyNameType2.Name = nameType1_2;
                PartyNameType partyNameType3 = partyNameType1;
                PartyType partyType = new PartyType()
                {
                    PartyIdentification = new PartyIdentificationType[1]
                    {
                        identificationType3
                    },
                    PartyName = new PartyNameType[1] { partyNameType3 }
                };
                AttachmentType attachmentType1 = new AttachmentType();
                AttachmentType attachmentType2 = attachmentType1;
                ExternalReferenceType externalReferenceType1 = new ExternalReferenceType();
                ExternalReferenceType externalReferenceType2 = externalReferenceType1;
                URIType uriType1 = new URIType();
                uriType1.Value = "#SignatureKG";
                URIType uriType2 = uriType1;
                externalReferenceType2.URI = uriType2;
                ExternalReferenceType externalReferenceType3 = externalReferenceType1;
                attachmentType2.ExternalReference = externalReferenceType3;
                AttachmentType attachmentType3 = attachmentType1;
                SignatureType signatureType1 = new SignatureType();
                SignatureType signatureType2 = signatureType1;
                IDType idType3 = new IDType();
                idType3.Value = pCabecera.NroDoc_Emisor;
                IDType idType4 = idType3;
                signatureType2.ID = idType4;
                signatureType1.SignatoryParty = partyType;
                signatureType1.DigitalSignatureAttachment = attachmentType3;
                this.XMLDebitNote.Signature = new SignatureType[1]
                {
                    signatureType1
                };
                DebitNoteType debitNoteType1 = this.XMLDebitNote;
                UBLVersionIDType ublVersionIdType1 = new UBLVersionIDType();
                ublVersionIdType1.Value = "2.1";
                UBLVersionIDType ublVersionIdType2 = ublVersionIdType1;
                debitNoteType1.UBLVersionID = ublVersionIdType2;
                DebitNoteType debitNoteType2 = this.XMLDebitNote;
                CustomizationIDType customizationIdType1 = new CustomizationIDType();
                customizationIdType1.Value = "2.0";
                CustomizationIDType customizationIdType2 = customizationIdType1;
                debitNoteType2.CustomizationID = customizationIdType2;
                DebitNoteType debitNoteType3 = this.XMLDebitNote;
                ProfileIDType profileIdType1 = new ProfileIDType();
                profileIdType1.schemeName = "Tipo de Operación"; //"SUNAT:Identificador de Tipo de Operación";
                profileIdType1.schemeAgencyName = "PE:SUNAT";
                profileIdType1.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo17";
                profileIdType1.Value = pCabecera.Tipo_Venta == "E" ? "0102" : (pCabecera.EsAnticipo ? "0104" : "0101");
                ProfileIDType profileIdType2 = profileIdType1;
                debitNoteType3.ProfileID = profileIdType2;
                DebitNoteType debitNoteType4 = this.XMLDebitNote;
                IDType idType5 = new IDType();
                idType5.Value = pCabecera.Serie_Documento + "-" + pCabecera.Numero_Documento;
                IDType idType6 = idType5;
                debitNoteType4.ID = idType6;
                DebitNoteType debitNoteType5 = this.XMLDebitNote;
                IssueDateType issueDateType1 = new IssueDateType();
                issueDateType1.Value = pCabecera.Fecha_Emision;
                IssueDateType issueDateType2 = issueDateType1;
                debitNoteType5.IssueDate = issueDateType2;
                DebitNoteType debitNoteType6 = this.XMLDebitNote;
                IssueTimeType issueTimeType1 = new IssueTimeType();
                issueTimeType1.TimeString = pCabecera.Hora_Emision;
                IssueTimeType issueTimeType2 = issueTimeType1;
                debitNoteType6.IssueTime = issueTimeType2;
                NoteType[] array1 = new NoteType[1];
                NoteType[] noteTypeArray1 = array1;
                int index1 = array1.Length - 1;
                NoteType noteType1 = new NoteType();
                noteType1.languageLocaleID = "1000";
                noteType1.Value = pCabecera.Texto_Importe_Total;
                NoteType noteType2 = noteType1;
                noteTypeArray1[index1] = noteType2;
                if (pCabecera.Importe_Total == pCabecera.Importe_Gratuito)
                {
                    Array.Resize<NoteType>(ref array1, array1.Length + 1);
                    NoteType[] noteTypeArray2 = array1;
                    int index2 = array1.Length - 1;
                    NoteType noteType3 = new NoteType();
                    noteType3.languageLocaleID = "1002";
                    noteType3.Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE";
                    NoteType noteType4 = noteType3;
                    noteTypeArray2[index2] = noteType4;
                }
                this.XMLDebitNote.Note = array1;
                DebitNoteType debitNoteType7 = this.XMLDebitNote;
                DocumentCurrencyCodeType currencyCodeType1 = new DocumentCurrencyCodeType();
                currencyCodeType1.listID = "ISO 4217 Alpha";
                currencyCodeType1.listName = "Currency";
                currencyCodeType1.listAgencyName = "United Nations Economic Commission for Europe";
                currencyCodeType1.Value = pCabecera.Codigo_Moneda;
                DocumentCurrencyCodeType currencyCodeType2 = currencyCodeType1;
                debitNoteType7.DocumentCurrencyCode = currencyCodeType2;
                ResponseType responseType1 = new ResponseType();
                ResponseType responseType2 = responseType1;
                ReferenceIDType referenceIdType1 = new ReferenceIDType();
                referenceIdType1.Value = pCabecera.Documento_Ref;
                ReferenceIDType referenceIdType2 = referenceIdType1;
                responseType2.ReferenceID = referenceIdType2;
                ResponseType responseType3 = responseType1;
                ResponseCodeType responseCodeType1 = new ResponseCodeType();
                responseCodeType1.Value = pCabecera.Codigo_Motivo_Ref;
                ResponseCodeType responseCodeType2 = responseCodeType1;
                responseType3.ResponseCode = responseCodeType2;
                ResponseType responseType4 = responseType1;
                DescriptionType[] descriptionTypeArray1 = new DescriptionType[1];
                DescriptionType[] descriptionTypeArray2 = descriptionTypeArray1;
                DescriptionType descriptionType1 = new DescriptionType();
                descriptionType1.Value = pCabecera.Descripcion_Motivo_Ref;
                DescriptionType descriptionType2 = descriptionType1;
                descriptionTypeArray2[0] = descriptionType2;
                DescriptionType[] descriptionTypeArray3 = descriptionTypeArray1;
                responseType4.Description = descriptionTypeArray3;
                this.XMLDebitNote.DiscrepancyResponse = new ResponseType[1]
                {
          responseType1
                };
                DocumentReferenceType documentReferenceType1 = new DocumentReferenceType();
                DocumentReferenceType documentReferenceType2 = documentReferenceType1;
                IDType idType7 = new IDType();
                idType7.Value = pCabecera.Documento_Ref;
                IDType idType8 = idType7;
                documentReferenceType2.ID = idType8;
                DocumentReferenceType documentReferenceType3 = documentReferenceType1;
                IssueDateType issueDateType3 = new IssueDateType();
                issueDateType3.Value = pCabecera.Fecha_Documento_Ref.Value;
                IssueDateType issueDateType4 = issueDateType3;
                documentReferenceType3.IssueDate = issueDateType4;
                DocumentReferenceType documentReferenceType4 = documentReferenceType1;
                DocumentTypeCodeType documentTypeCodeType1 = new DocumentTypeCodeType();
                documentTypeCodeType1.Value = pCabecera.Codigo_Documento_Ref;
                DocumentTypeCodeType documentTypeCodeType2 = documentTypeCodeType1;
                documentReferenceType4.DocumentTypeCode = documentTypeCodeType2;
                DocumentReferenceType documentReferenceType5 = documentReferenceType1;
                this.XMLDebitNote.BillingReference = new BillingReferenceType[1]
                {
          new BillingReferenceType()
          {
            InvoiceDocumentReference = documentReferenceType5
          }
                };
                PartyNameType[] partyNameTypeArray1 = new PartyNameType[1];
                PartyNameType[] partyNameTypeArray2 = partyNameTypeArray1;
                PartyNameType partyNameType4 = new PartyNameType();
                PartyNameType partyNameType5 = partyNameType4;
                NameType1 nameType1_3 = new NameType1();
                nameType1_3.Value = pCabecera.NombreCorto_Emisor;
                NameType1 nameType1_4 = nameType1_3;
                partyNameType5.Name = nameType1_4;
                PartyNameType partyNameType6 = partyNameType4;
                partyNameTypeArray2[0] = partyNameType6;
                PartyLegalEntityType[] partyLegalEntityTypeArray1 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray2 = partyLegalEntityTypeArray1;
                PartyLegalEntityType partyLegalEntityType1 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType2 = partyLegalEntityType1;
                RegistrationNameType registrationNameType1 = new RegistrationNameType();
                registrationNameType1.Value = pCabecera.RSocial_Emisor;
                RegistrationNameType registrationNameType2 = registrationNameType1;
                partyLegalEntityType2.RegistrationName = registrationNameType2;
                PartyLegalEntityType partyLegalEntityType3 = partyLegalEntityType1;
                AddressType addressType1 = new AddressType();
                AddressType addressType2 = addressType1;
                CountrySubentityType countrySubentityType1 = new CountrySubentityType();
                countrySubentityType1.Value = pCabecera.Dpto_Emisor;
                CountrySubentityType countrySubentityType2 = countrySubentityType1;
                addressType2.CountrySubentity = countrySubentityType2;
                AddressType addressType3 = addressType1;
                CityNameType cityNameType1 = new CityNameType();
                cityNameType1.Value = pCabecera.Prov_Emisor;
                CityNameType cityNameType2 = cityNameType1;
                addressType3.CityName = cityNameType2;
                AddressType addressType4 = addressType1;
                DistrictType districtType1 = new DistrictType();
                districtType1.Value = pCabecera.Dist_Emisor;
                DistrictType districtType2 = districtType1;
                addressType4.District = districtType2;
                AddressType addressType5 = addressType1;
                CountryType countryType1 = new CountryType();
                CountryType countryType2 = countryType1;
                IdentificationCodeType identificationCodeType1 = new IdentificationCodeType();
                identificationCodeType1.Value = pCabecera.CodPais_Emisor;
                IdentificationCodeType identificationCodeType2 = identificationCodeType1;
                countryType2.IdentificationCode = identificationCodeType2;
                CountryType countryType3 = countryType1;
                addressType5.Country = countryType3;
                AddressType addressType6 = addressType1;
                AddressTypeCodeType addressTypeCodeType1 = new AddressTypeCodeType();
                addressTypeCodeType1.Value = pCabecera.Codigo_Domicilio_Emisor;
                AddressTypeCodeType addressTypeCodeType2 = addressTypeCodeType1;
                addressType6.AddressTypeCode = addressTypeCodeType2;
                AddressType addressType7 = addressType1;
                partyLegalEntityType3.RegistrationAddress = addressType7;
                PartyLegalEntityType partyLegalEntityType4 = partyLegalEntityType1;
                partyLegalEntityTypeArray2[0] = partyLegalEntityType4;
                PartyIdentificationType[] identificationTypeArray1 = new PartyIdentificationType[1];
                PartyIdentificationType[] identificationTypeArray2 = identificationTypeArray1;
                PartyIdentificationType identificationType4 = new PartyIdentificationType();
                PartyIdentificationType identificationType5 = identificationType4;
                IDType idType9 = new IDType();
                idType9.schemeID = pCabecera.TipoDoc_Emisor;
                idType9.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                idType9.schemeAgencyName = "PE:SUNAT";
                idType9.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                idType9.Value = pCabecera.NroDoc_Emisor;
                IDType idType10 = idType9;
                identificationType5.ID = idType10;
                PartyIdentificationType identificationType6 = identificationType4;
                identificationTypeArray2[0] = identificationType6;
                this.XMLDebitNote.AccountingSupplierParty = new SupplierPartyType()
                {
                    Party = new PartyType()
                    {
                        PartyName = partyNameTypeArray1,
                        PartyLegalEntity = partyLegalEntityTypeArray1,
                        PartyIdentification = identificationTypeArray1
                    }
                };
                PartyLegalEntityType[] partyLegalEntityTypeArray3 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray4 = partyLegalEntityTypeArray3;
                PartyLegalEntityType partyLegalEntityType5 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType6 = partyLegalEntityType5;
                RegistrationNameType registrationNameType3 = new RegistrationNameType();
                registrationNameType3.Value = pCabecera.RSocial_Receptor;
                RegistrationNameType registrationNameType4 = registrationNameType3;
                partyLegalEntityType6.RegistrationName = registrationNameType4;
                PartyLegalEntityType partyLegalEntityType7 = partyLegalEntityType5;
                partyLegalEntityTypeArray4[0] = partyLegalEntityType7;
                PartyIdentificationType[] identificationTypeArray3 = new PartyIdentificationType[1];
                if (pCabecera.Tipo_Venta == "L")
                {
                    PartyIdentificationType[] identificationTypeArray4 = identificationTypeArray3;
                    PartyIdentificationType identificationType7 = new PartyIdentificationType();
                    PartyIdentificationType identificationType8 = identificationType7;
                    IDType idType11 = new IDType();
                    idType11.schemeID = pCabecera.TipoDoc_Receptor;
                    idType11.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                    idType11.schemeAgencyName = "PE:SUNAT";
                    idType11.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                    idType11.Value = pCabecera.NroDoc_Receptor;
                    IDType idType12 = idType11;
                    identificationType8.ID = idType12;
                    PartyIdentificationType identificationType9 = identificationType7;
                    identificationTypeArray4[0] = identificationType9;
                }
                else
                {
                    PartyIdentificationType[] identificationTypeArray4 = identificationTypeArray3;
                    PartyIdentificationType identificationType7 = new PartyIdentificationType();
                    PartyIdentificationType identificationType8 = identificationType7;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "-";
                    idType11.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                    idType11.schemeAgencyName = "PE:SUNAT";
                    idType11.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                    idType11.Value = "0";
                    IDType idType12 = idType11;
                    identificationType8.ID = idType12;
                    PartyIdentificationType identificationType9 = identificationType7;
                    identificationTypeArray4[0] = identificationType9;
                }
                this.XMLDebitNote.AccountingCustomerParty = new CustomerPartyType()
                {
                    Party = new PartyType()
                    {
                        PartyLegalEntity = partyLegalEntityTypeArray3,
                        PartyIdentification = identificationTypeArray3
                    }
                };
                if (pCabecera.Importe_DctoGlobal != new Decimal(0))
                {
                    AllowanceChargeType[] allowanceChargeTypeArray1 = new AllowanceChargeType[1];
                    AllowanceChargeType[] allowanceChargeTypeArray2 = allowanceChargeTypeArray1;
                    AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                    AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                    ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                    chargeIndicatorType1.Value = false;
                    ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                    allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;
                    AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                    AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                    chargeReasonCodeType1.Value = "00";
                    AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                    allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;
                    AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                    MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                    factorNumericType1.Value = pCabecera.PorcentajeDctoGlobal / new Decimal(100);
                    MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                    allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;
                    AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                    AmountType2 amountType2_1 = new AmountType2();
                    amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                    amountType2_1.Value = pCabecera.Importe_DctoGlobal;
                    AmountType2 amountType2_2 = amountType2_1;
                    allowanceChargeType5.Amount = amountType2_2;
                    AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                    BaseAmountType baseAmountType1 = new BaseAmountType();
                    baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    baseAmountType1.Value = pCabecera.Importe_SubTotal - pCabecera.Importe_Descuento;
                    BaseAmountType baseAmountType2 = baseAmountType1;
                    allowanceChargeType6.BaseAmount = baseAmountType2;
                    AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                    allowanceChargeTypeArray2[0] = allowanceChargeType7;
                    this.XMLDebitNote.AllowanceCharge = allowanceChargeTypeArray1;
                }
                TaxSubtotalType[] array2 = new TaxSubtotalType[0];
                TaxAmountType taxAmountType1 = new TaxAmountType();
                taxAmountType1.currencyID = pCabecera.Codigo_Moneda;
                taxAmountType1.Value = pCabecera.Importe_IGV + pCabecera.Importe_ISC;
                TaxAmountType taxAmountType2 = taxAmountType1;
                if (pCabecera.Importe_IGV > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Gravado + pCabecera.Importe_ISC;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_IGV;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "S";
                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "1000";
                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "IGV";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "VAT";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_ISC > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Base_ISC;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_ISC;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "S";
                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "2000";
                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "ISC";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "EXC";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_OtrosTributos > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Base_OtrosTributos;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_OtrosTributos;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "S";
                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "9999";
                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "OTR";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "OTH";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_Exonerado > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Exonerado;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "E";
                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "9997";
                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "EXO";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "VAT";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_Inafecto > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Inafecto;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "O";
                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "9998";
                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "INA";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "FRE";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_Gratuito > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Gratuito;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5305";
                    idType11.schemeName = "Tax Category identifierField";
                    idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType11.Value = "Z";
                    IDType idType12 = idType11;
                    taxCategoryType2.ID = idType12;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType13 = new IDType();
                    idType13.schemeID = "UN/ECE 5153";
                    idType13.schemeAgencyID = "6";
                    idType13.Value = "9996";
                    IDType idType14 = idType13;
                    taxSchemeType2.ID = idType14;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "GRA";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "FRE";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array2[array2.Length - 1] = taxSubtotalType5;
                }
                this.XMLDebitNote.TaxTotal = new TaxTotalType[1]
                {
          new TaxTotalType()
          {
            TaxAmount = taxAmountType2,
            TaxSubtotal = array2
          }
                };
                if (pCabecera.Importe_OtrosCargos > new Decimal(0))
                {
                    DebitNoteType debitNoteType8 = this.XMLDebitNote;
                    MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();
                    MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pCabecera.Importe_SubTotal;
                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    monetaryTotalType2.LineExtensionAmount = extensionAmountType2;
                    MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                    TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                    exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    exclusiveAmountType1.Value = pCabecera.Importe_Total;
                    TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                    monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;
                    MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                    AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                    allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;
                    AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                    monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;
                    MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                    ChargeTotalAmountType chargeTotalAmountType1 = new ChargeTotalAmountType();
                    chargeTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    chargeTotalAmountType1.Value = pCabecera.Importe_OtrosCargos;
                    ChargeTotalAmountType chargeTotalAmountType2 = chargeTotalAmountType1;
                    monetaryTotalType5.ChargeTotalAmount = chargeTotalAmountType2;
                    MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                    PayableAmountType payableAmountType1 = new PayableAmountType();
                    payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;
                    PayableAmountType payableAmountType2 = payableAmountType1;
                    monetaryTotalType6.PayableAmount = payableAmountType2;
                    MonetaryTotalType monetaryTotalType7 = monetaryTotalType1;
                    debitNoteType8.RequestedMonetaryTotal = monetaryTotalType7;
                }
                else
                {
                    DebitNoteType debitNoteType8 = this.XMLDebitNote;
                    MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();
                    MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pCabecera.Importe_SubTotal;
                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    monetaryTotalType2.LineExtensionAmount = extensionAmountType2;
                    MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                    TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                    exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    exclusiveAmountType1.Value = pCabecera.Importe_Total;
                    TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                    monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;
                    MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                    AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                    allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;
                    AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                    monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;
                    MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                    PayableAmountType payableAmountType1 = new PayableAmountType();
                    payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_Percepcion;
                    PayableAmountType payableAmountType2 = payableAmountType1;
                    monetaryTotalType5.PayableAmount = payableAmountType2;
                    MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                    debitNoteType8.RequestedMonetaryTotal = monetaryTotalType6;
                }
                DebitNoteLineType[] debitNoteLineTypeArray = new DebitNoteLineType[pLstDetalle.Count];
                for (int index2 = 0; index2 < pLstDetalle.Count; ++index2)
                {
                    DebitNoteLineType debitNoteLineType1 = new DebitNoteLineType();
                    DebitNoteLineType debitNoteLineType2 = debitNoteLineType1;
                    IDType idType11 = new IDType();
                    idType11.Value = pLstDetalle[index2].NroItem.Trim();
                    IDType idType12 = idType11;
                    debitNoteLineType2.ID = idType12;
                    DebitNoteLineType debitNoteLineType3 = debitNoteLineType1;
                    DebitedQuantityType debitedQuantityType1 = new DebitedQuantityType();
                    debitedQuantityType1.Value = pLstDetalle[index2].Cantidad;
                    debitedQuantityType1.unitCode = pLstDetalle[index2].Codigo_Unidad;
                    debitedQuantityType1.unitCodeListID = "UN/ECE rec 20";
                    debitedQuantityType1.unitCodeListAgencyName = "United Nations Economic Commission for Europe";
                    DebitedQuantityType debitedQuantityType2 = debitedQuantityType1;
                    debitNoteLineType3.DebitedQuantity = debitedQuantityType2;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pLstDetalle[index2].EsGratuito ? new Decimal(0) : Convert.ToDecimal(pLstDetalle[index2].Importe_ValorVenta);
                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    debitNoteLineType1.LineExtensionAmount = extensionAmountType2;
                    PriceType[] priceTypeArray = new PriceType[1];
                    PriceType priceType1 = new PriceType();
                    PriceType priceType2 = priceType1;
                    PriceAmountType priceAmountType1 = new PriceAmountType();
                    priceAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    priceAmountType1.Value = pLstDetalle[index2].Precio_Unitario_ConIGV;
                    PriceAmountType priceAmountType2 = priceAmountType1;
                    priceType2.PriceAmount = priceAmountType2;
                    PriceType priceType3 = priceType1;
                    PriceTypeCodeType priceTypeCodeType1 = new PriceTypeCodeType();
                    priceTypeCodeType1.listName = "Tipo de Precio"; //"SUNAT:Indicador de Tipo de Precio";
                    priceTypeCodeType1.listAgencyName = "PE:SUNAT";
                    priceTypeCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16";
                    priceTypeCodeType1.Value = pCabecera.Tipo_Venta == "E" || pLstDetalle[index2].EsGratuito ? "03" : "01";
                    PriceTypeCodeType priceTypeCodeType2 = priceTypeCodeType1;
                    priceType3.PriceTypeCode = priceTypeCodeType2;
                    PriceType priceType4 = priceType1;
                    priceTypeArray[0] = priceType4;
                    PricingReferenceType pricingReferenceType = new PricingReferenceType()
                    {
                        AlternativeConditionPrice = priceTypeArray
                    };
                    debitNoteLineType1.PricingReference = pricingReferenceType;
                    if (pLstDetalle[index2].Importe_Descuento > new Decimal(0))
                    {
                        AllowanceChargeType[] allowanceChargeTypeArray1 = new AllowanceChargeType[1];
                        AllowanceChargeType[] allowanceChargeTypeArray2 = allowanceChargeTypeArray1;
                        AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                        AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                        ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                        chargeIndicatorType1.Value = false;
                        ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                        allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;
                        AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                        AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                        chargeReasonCodeType1.Value = "00";
                        AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                        allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;
                        AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                        MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                        factorNumericType1.Value = pLstDetalle[index2].Porcentaje_Descuento / new Decimal(100);
                        MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                        allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;
                        AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                        AmountType2 amountType2_1 = new AmountType2();
                        amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                        amountType2_1.Value = pLstDetalle[index2].Importe_Descuento;
                        AmountType2 amountType2_2 = amountType2_1;
                        allowanceChargeType5.Amount = amountType2_2;
                        AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                        BaseAmountType baseAmountType1 = new BaseAmountType();
                        baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        baseAmountType1.Value = pLstDetalle[index2].Importe_SubTotal;
                        BaseAmountType baseAmountType2 = baseAmountType1;
                        allowanceChargeType6.BaseAmount = baseAmountType2;
                        AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                        allowanceChargeTypeArray2[0] = allowanceChargeType7;
                        debitNoteLineType1.AllowanceCharge = allowanceChargeTypeArray1;
                    }
                    array2 = new TaxSubtotalType[0];
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pLstDetalle[index2].Importe_IGV;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    if (pLstDetalle[index2].Importe_IGV > new Decimal(0))
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = pLstDetalle[index2].Importe_ValorVenta - pCabecera.Importe_ISC;
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_IGV;
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "S";
                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectación del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Tax Schema Identifier";
                        idType15.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType15.Value = "1000";
                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "IGV";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "VAT";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }
                    if (pLstDetalle[index2].Importe_ISC > new Decimal(0))
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = pLstDetalle[index2].Importe_ValorVenta;
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_ISC;
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "S";
                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pLstDetalle[index2].Porcentaje_ISC;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectación del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Tax Schema Identifier";
                        idType15.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType15.Value = "2000";
                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "ISC";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "EXC";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }
                    if (pLstDetalle[index2].EsExonerado)
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = new Decimal(0);
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = new Decimal(0);
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "E";
                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectación del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Tax Schema Identifier";
                        idType15.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType15.Value = "9997";
                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "EXO";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "VAT";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }
                    if (pLstDetalle[index2].EsInafecto)
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = new Decimal(0);
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_ValorVenta;
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "O";
                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectación del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Tax Schema Identifier";
                        idType15.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType15.Value = "9998";
                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "INA";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "FRE";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }
                    if (pLstDetalle[index2].EsGratuito)
                    {
                        Array.Resize<TaxSubtotalType>(ref array2, array2.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = new Decimal(0);
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_ValorVenta;
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5305";
                        idType13.schemeName = "Tax Category identifierField";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "O";
                        IDType idType14 = idType13;
                        taxCategoryType2.ID = idType14;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectación del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType15 = new IDType();
                        idType15.schemeID = "UN/ECE 5153";
                        idType15.schemeName = "Tax Schema Identifie";
                        idType15.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType15.Value = "9996";
                        IDType idType16 = idType15;
                        taxSchemeType2.ID = idType16;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "GRA";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "FRE";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array2[array2.Length - 1] = taxSubtotalType5;
                    }
                    TaxTotalType[] taxTotalTypeArray = new TaxTotalType[1]
                    {
            new TaxTotalType()
            {
              TaxAmount = taxAmountType4,
              TaxSubtotal = array2
            }
                    };
                    debitNoteLineType1.TaxTotal = taxTotalTypeArray;
                    DescriptionType descriptionType3 = new DescriptionType();
                    descriptionType3.Value = pLstDetalle[index2].Descripcion_Articulo.Trim();
                    DescriptionType[] descriptionTypeArray4 = new DescriptionType[1]
                    {
            descriptionType3
                    };
                    ItemIdentificationType identificationType7 = new ItemIdentificationType();
                    ItemIdentificationType identificationType8 = identificationType7;
                    IDType idType17 = new IDType();
                    idType17.Value = pLstDetalle[index2].Codigo_Articulo;
                    IDType idType18 = idType17;
                    identificationType8.ID = idType18;
                    ItemIdentificationType identificationType9 = identificationType7;
                    if (string.IsNullOrEmpty(pLstDetalle[index2].Codigo_Producto_Sunat))
                    {
                        debitNoteLineType1.Item = new ItemType()
                        {
                            Description = descriptionTypeArray4,
                            SellersItemIdentification = identificationType9
                        };
                    }
                    else
                    {
                        ItemClassificationCodeType classificationCodeType1 = new ItemClassificationCodeType();
                        classificationCodeType1.Value = pLstDetalle[index2].Codigo_Producto_Sunat;
                        classificationCodeType1.listID = "UNSPSC";
                        classificationCodeType1.listAgencyName = "GS1 US";
                        classificationCodeType1.listName = "Item Classification";
                        ItemClassificationCodeType classificationCodeType2 = classificationCodeType1;
                        CommodityClassificationType[] classificationTypeArray = new CommodityClassificationType[1]
                        {
              new CommodityClassificationType()
              {
                ItemClassificationCode = classificationCodeType2
              }
                        };
                        debitNoteLineType1.Item = new ItemType()
                        {
                            Description = descriptionTypeArray4,
                            SellersItemIdentification = identificationType9,
                            CommodityClassification = classificationTypeArray
                        };
                    }
                    PriceAmountType priceAmountType3;
                    if (pCabecera.Tipo_Venta == "E")
                    {
                        PriceAmountType priceAmountType4 = new PriceAmountType();
                        priceAmountType4.currencyID = pCabecera.Codigo_Moneda;
                        priceAmountType4.Value = new Decimal(0);
                        priceAmountType3 = priceAmountType4;
                    }
                    else
                    {
                        PriceAmountType priceAmountType4 = new PriceAmountType();
                        priceAmountType4.currencyID = pCabecera.Codigo_Moneda;
                        priceAmountType4.Value = pLstDetalle[index2].EsGratuito ? new Decimal(0) : Convert.ToDecimal(pLstDetalle[index2].Precio_Unitario_SinIGV);
                        priceAmountType3 = priceAmountType4;
                    }
                    debitNoteLineType1.Price = new PriceType()
                    {
                        PriceAmount = priceAmountType3
                    };
                    debitNoteLineTypeArray[index2] = debitNoteLineType1;
                }
                this.XMLDebitNote.DebitNoteLine = debitNoteLineTypeArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraBoletaVenta(ComprobanteCabecera pCabecera, List<ComprobanteDetalle> pLstDetalle)
        {
            try
            {
                this.XMLBoletaVta = new InvoiceType();
                this.oLstUBLExtensionType[0] = new UBLExtensionType()
                {
                    ExtensionContent = new XmlDocument().CreateElement("dummy")
                };
                this.XMLBoletaVta.UBLExtensions = this.oLstUBLExtensionType;
                PartyIdentificationType identificationType1 = new PartyIdentificationType();
                PartyIdentificationType identificationType2 = identificationType1;
                IDType idType1 = new IDType();
                idType1.Value = pCabecera.NroDoc_Emisor;
                IDType idType2 = idType1;
                identificationType2.ID = idType2;
                PartyIdentificationType identificationType3 = identificationType1;
                PartyNameType partyNameType1 = new PartyNameType();
                PartyNameType partyNameType2 = partyNameType1;
                NameType1 nameType1_1 = new NameType1();
                nameType1_1.Value = pCabecera.RSocial_Emisor;
                NameType1 nameType1_2 = nameType1_1;
                partyNameType2.Name = nameType1_2;
                PartyNameType partyNameType3 = partyNameType1;
                PartyType partyType = new PartyType()
                {
                    PartyIdentification = new PartyIdentificationType[1]
                    {
                        identificationType3
                    },
                    PartyName = new PartyNameType[1] { partyNameType3 }
                };
                AttachmentType attachmentType1 = new AttachmentType();
                AttachmentType attachmentType2 = attachmentType1;
                ExternalReferenceType externalReferenceType1 = new ExternalReferenceType();
                ExternalReferenceType externalReferenceType2 = externalReferenceType1;
                URIType uriType1 = new URIType();
                uriType1.Value = "#SignatureKG";
                URIType uriType2 = uriType1;
                externalReferenceType2.URI = uriType2;
                ExternalReferenceType externalReferenceType3 = externalReferenceType1;
                attachmentType2.ExternalReference = externalReferenceType3;
                AttachmentType attachmentType3 = attachmentType1;
                SignatureType signatureType1 = new SignatureType();
                SignatureType signatureType2 = signatureType1;
                IDType idType3 = new IDType();
                idType3.Value = pCabecera.NroDoc_Emisor;
                IDType idType4 = idType3;
                signatureType2.ID = idType4;
                signatureType1.SignatoryParty = partyType;
                signatureType1.DigitalSignatureAttachment = attachmentType3;
                this.XMLBoletaVta.Signature = new SignatureType[1]
                {
                    signatureType1
                };

                InvoiceType invoiceType1 = this.XMLBoletaVta;
                UBLVersionIDType ublVersionIdType1 = new UBLVersionIDType();
                ublVersionIdType1.Value = "2.1";
                UBLVersionIDType ublVersionIdType2 = ublVersionIdType1;
                invoiceType1.UBLVersionID = ublVersionIdType2;

                InvoiceType invoiceType2 = this.XMLBoletaVta;
                CustomizationIDType customizationIdType1 = new CustomizationIDType();
                customizationIdType1.Value = "2.0";
                CustomizationIDType customizationIdType2 = customizationIdType1;
                invoiceType2.CustomizationID = customizationIdType2;

                InvoiceType invoiceType3 = this.XMLBoletaVta;
                IDType idType5 = new IDType();
                idType5.Value = pCabecera.Serie_Documento + "-" + pCabecera.Numero_Documento;
                IDType idType6 = idType5;
                invoiceType3.ID = idType6;

                InvoiceType invoiceType4 = this.XMLBoletaVta;
                IssueDateType issueDateType1 = new IssueDateType();
                issueDateType1.Value = pCabecera.Fecha_Emision;
                IssueDateType issueDateType2 = issueDateType1;
                invoiceType4.IssueDate = issueDateType2;

                InvoiceType invoiceType5 = this.XMLBoletaVta;
                IssueTimeType issueTimeType1 = new IssueTimeType();
                issueTimeType1.TimeString = pCabecera.Hora_Emision;
                IssueTimeType issueTimeType2 = issueTimeType1;
                invoiceType5.IssueTime = issueTimeType2;

                if (pCabecera.Fecha_Vencimiento.HasValue)
                {
                    InvoiceType invoiceType6 = this.XMLBoletaVta;
                    DueDateType dueDateType1 = new DueDateType();
                    dueDateType1.Value = Convert.ToDateTime((object)pCabecera.Fecha_Vencimiento);
                    DueDateType dueDateType2 = dueDateType1;
                    invoiceType6.DueDate = dueDateType2;
                }
                InvoiceType invoiceType7 = this.XMLBoletaVta;
                InvoiceTypeCodeType invoiceTypeCodeType1 = new InvoiceTypeCodeType();
                invoiceTypeCodeType1.listAgencyName = "PE:SUNAT";
                invoiceTypeCodeType1.listName = "Tipo de Documento"; //"SUNAT:Identificador de Tipo de Documento";
                invoiceTypeCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01";
                invoiceTypeCodeType1.listID = pCabecera.Tipo_Venta == "E" ? "0102" : (pCabecera.EsAnticipo ? "0104" : "0101");
                invoiceTypeCodeType1.Value = pCabecera.Codigo_Documento;
                InvoiceTypeCodeType invoiceTypeCodeType2 = invoiceTypeCodeType1;
                invoiceType7.InvoiceTypeCode = invoiceTypeCodeType2;
                NoteType[] array1 = new NoteType[1];
                NoteType[] noteTypeArray1 = array1;
                int index1 = array1.Length - 1;
                NoteType noteType1 = new NoteType();
                noteType1.languageLocaleID = "1000";
                noteType1.Value = pCabecera.Texto_Importe_Total;
                NoteType noteType2 = noteType1;
                noteTypeArray1[index1] = noteType2;
                if (pCabecera.Importe_Total == pCabecera.Importe_Gratuito)
                {
                    Array.Resize<NoteType>(ref array1, array1.Length + 1);
                    NoteType[] noteTypeArray2 = array1;
                    int index2 = array1.Length - 1;
                    NoteType noteType3 = new NoteType();
                    noteType3.languageLocaleID = "1002";
                    noteType3.Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE";
                    NoteType noteType4 = noteType3;
                    noteTypeArray2[index2] = noteType4;
                }
                if (pCabecera.Importe_Percepcion > new Decimal(0))
                {
                    Array.Resize<NoteType>(ref array1, array1.Length + 1);
                    NoteType[] noteTypeArray2 = array1;
                    int index2 = array1.Length - 1;
                    NoteType noteType3 = new NoteType();
                    noteType3.languageLocaleID = "2000";
                    noteType3.Value = "COMPROBANTE DE PERCEPCIÓN";
                    NoteType noteType4 = noteType3;
                    noteTypeArray2[index2] = noteType4;
                }
                this.XMLBoletaVta.Note = array1;
                InvoiceType invoiceType8 = this.XMLBoletaVta;
                DocumentCurrencyCodeType currencyCodeType1 = new DocumentCurrencyCodeType();
                currencyCodeType1.listID = "ISO 4217 Alpha";
                currencyCodeType1.listName = "Currency";
                currencyCodeType1.listAgencyName = "United Nations Economic Commission for Europe";
                currencyCodeType1.Value = pCabecera.Codigo_Moneda;
                DocumentCurrencyCodeType currencyCodeType2 = currencyCodeType1;
                invoiceType8.DocumentCurrencyCode = currencyCodeType2;
                PartyNameType[] partyNameTypeArray1 = new PartyNameType[1];
                PartyNameType[] partyNameTypeArray2 = partyNameTypeArray1;
                PartyNameType partyNameType4 = new PartyNameType();
                PartyNameType partyNameType5 = partyNameType4;
                NameType1 nameType1_3 = new NameType1();
                nameType1_3.Value = pCabecera.NombreCorto_Emisor;
                NameType1 nameType1_4 = nameType1_3;
                partyNameType5.Name = nameType1_4;
                PartyNameType partyNameType6 = partyNameType4;
                partyNameTypeArray2[0] = partyNameType6;
                PartyLegalEntityType[] partyLegalEntityTypeArray1 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray2 = partyLegalEntityTypeArray1;
                PartyLegalEntityType partyLegalEntityType1 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType2 = partyLegalEntityType1;
                RegistrationNameType registrationNameType1 = new RegistrationNameType();
                registrationNameType1.Value = pCabecera.RSocial_Emisor;
                RegistrationNameType registrationNameType2 = registrationNameType1;
                partyLegalEntityType2.RegistrationName = registrationNameType2;
                PartyLegalEntityType partyLegalEntityType3 = partyLegalEntityType1;
                AddressType addressType1 = new AddressType();
                AddressType addressType2 = addressType1;
                CountrySubentityType countrySubentityType1 = new CountrySubentityType();
                countrySubentityType1.Value = pCabecera.Dpto_Emisor;
                CountrySubentityType countrySubentityType2 = countrySubentityType1;
                addressType2.CountrySubentity = countrySubentityType2;
                AddressType addressType3 = addressType1;
                CityNameType cityNameType1 = new CityNameType();
                cityNameType1.Value = pCabecera.Prov_Emisor;
                CityNameType cityNameType2 = cityNameType1;
                addressType3.CityName = cityNameType2;
                AddressType addressType4 = addressType1;
                DistrictType districtType1 = new DistrictType();
                districtType1.Value = pCabecera.Dist_Emisor;
                DistrictType districtType2 = districtType1;
                addressType4.District = districtType2;
                AddressType addressType5 = addressType1;
                CountryType countryType1 = new CountryType();
                CountryType countryType2 = countryType1;
                IdentificationCodeType identificationCodeType1 = new IdentificationCodeType();
                identificationCodeType1.Value = pCabecera.CodPais_Emisor;
                IdentificationCodeType identificationCodeType2 = identificationCodeType1;
                countryType2.IdentificationCode = identificationCodeType2;
                CountryType countryType3 = countryType1;
                addressType5.Country = countryType3;
                AddressType addressType6 = addressType1;
                AddressTypeCodeType addressTypeCodeType1 = new AddressTypeCodeType();
                addressTypeCodeType1.Value = pCabecera.Codigo_Domicilio_Emisor;
                AddressTypeCodeType addressTypeCodeType2 = addressTypeCodeType1;
                addressType6.AddressTypeCode = addressTypeCodeType2;
                AddressType addressType7 = addressType1;
                partyLegalEntityType3.RegistrationAddress = addressType7;
                PartyLegalEntityType partyLegalEntityType4 = partyLegalEntityType1;
                partyLegalEntityTypeArray2[0] = partyLegalEntityType4;
                PartyIdentificationType[] identificationTypeArray1 = new PartyIdentificationType[1];
                PartyIdentificationType[] identificationTypeArray2 = identificationTypeArray1;
                PartyIdentificationType identificationType4 = new PartyIdentificationType();
                PartyIdentificationType identificationType5 = identificationType4;
                IDType idType7 = new IDType();
                idType7.schemeID = pCabecera.TipoDoc_Emisor;
                idType7.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                idType7.schemeAgencyName = "PE:SUNAT";
                idType7.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                idType7.Value = pCabecera.NroDoc_Emisor;
                IDType idType8 = idType7;
                identificationType5.ID = idType8;
                PartyIdentificationType identificationType6 = identificationType4;
                identificationTypeArray2[0] = identificationType6;
                this.XMLBoletaVta.AccountingSupplierParty = new SupplierPartyType()
                {
                    Party = new PartyType()
                    {
                        PartyName = partyNameTypeArray1,
                        PartyLegalEntity = partyLegalEntityTypeArray1,
                        PartyIdentification = identificationTypeArray1
                    }
                };
                PartyLegalEntityType[] partyLegalEntityTypeArray3 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray4 = partyLegalEntityTypeArray3;
                PartyLegalEntityType partyLegalEntityType5 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType6 = partyLegalEntityType5;
                RegistrationNameType registrationNameType3 = new RegistrationNameType();
                registrationNameType3.Value = pCabecera.RSocial_Receptor;
                RegistrationNameType registrationNameType4 = registrationNameType3;
                partyLegalEntityType6.RegistrationName = registrationNameType4;
                PartyLegalEntityType partyLegalEntityType7 = partyLegalEntityType5;
                partyLegalEntityTypeArray4[0] = partyLegalEntityType7;
                PartyIdentificationType[] identificationTypeArray3 = new PartyIdentificationType[1];
                if (pCabecera.Tipo_Venta == "L")
                {
                    PartyIdentificationType[] identificationTypeArray4 = identificationTypeArray3;
                    PartyIdentificationType identificationType7 = new PartyIdentificationType();
                    PartyIdentificationType identificationType8 = identificationType7;
                    IDType idType9 = new IDType();
                    idType9.schemeID = pCabecera.TipoDoc_Receptor;
                    idType9.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                    idType9.schemeAgencyName = "PE:SUNAT";
                    idType9.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                    idType9.Value = pCabecera.NroDoc_Receptor;
                    IDType idType10 = idType9;
                    identificationType8.ID = idType10;
                    PartyIdentificationType identificationType9 = identificationType7;
                    identificationTypeArray4[0] = identificationType9;
                }
                else
                {
                    PartyIdentificationType[] identificationTypeArray4 = identificationTypeArray3;
                    PartyIdentificationType identificationType7 = new PartyIdentificationType();
                    PartyIdentificationType identificationType8 = identificationType7;
                    IDType idType9 = new IDType();
                    idType9.schemeID = "-";
                    idType9.schemeName = "Documento de Identidad"; //"SUNAT: Identificador de Documento de Identidad";
                    idType9.schemeAgencyName = "PE:SUNAT";
                    idType9.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06";
                    idType9.Value = "0";
                    IDType idType10 = idType9;
                    identificationType8.ID = idType10;
                    PartyIdentificationType identificationType9 = identificationType7;
                    identificationTypeArray4[0] = identificationType9;
                }
                this.XMLBoletaVta.AccountingCustomerParty = new CustomerPartyType()
                {
                    Party = new PartyType()
                    {
                        PartyLegalEntity = partyLegalEntityTypeArray3,
                        PartyIdentification = identificationTypeArray3
                    }
                };
                AllowanceChargeType[] array2;
                if (pCabecera.Importe_DctoGlobal + pCabecera.Importe_Percepcion != new Decimal(0))
                {
                    array2 = new AllowanceChargeType[0];
                    if (pCabecera.Importe_DctoGlobal != new Decimal(0))
                    {
                        Array.Resize<AllowanceChargeType>(ref array2, array2.Length + 1);
                        AllowanceChargeType[] allowanceChargeTypeArray = array2;
                        int index2 = array2.Length - 1;
                        AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                        AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                        ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                        chargeIndicatorType1.Value = false;
                        ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                        allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;
                        AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                        AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                        chargeReasonCodeType1.Value = "00";
                        AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                        allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;
                        AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                        MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                        factorNumericType1.Value = pCabecera.PorcentajeDctoGlobal / new Decimal(100);
                        MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                        allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;
                        AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                        AmountType2 amountType2_1 = new AmountType2();
                        amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                        amountType2_1.Value = pCabecera.Importe_DctoGlobal;
                        AmountType2 amountType2_2 = amountType2_1;
                        allowanceChargeType5.Amount = amountType2_2;
                        AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                        BaseAmountType baseAmountType1 = new BaseAmountType();
                        baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        baseAmountType1.Value = pCabecera.Importe_SubTotal - pCabecera.Importe_Descuento;
                        BaseAmountType baseAmountType2 = baseAmountType1;
                        allowanceChargeType6.BaseAmount = baseAmountType2;
                        AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                        allowanceChargeTypeArray[index2] = allowanceChargeType7;
                    }
                    if (pCabecera.Importe_Percepcion != new Decimal(0))
                    {
                        Array.Resize<AllowanceChargeType>(ref array2, array2.Length + 1);
                        AllowanceChargeType[] allowanceChargeTypeArray = array2;
                        int index2 = array2.Length - 1;
                        AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                        AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                        ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                        chargeIndicatorType1.Value = true;
                        ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                        allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;
                        AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                        AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                        chargeReasonCodeType1.Value = pCabecera.Codigo_Percepcion;
                        AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                        allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;
                        AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                        MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                        factorNumericType1.Value = pCabecera.Porcentaje_Percepcion / new Decimal(100);
                        MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                        allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;
                        AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                        AmountType2 amountType2_1 = new AmountType2();
                        amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                        amountType2_1.Value = pCabecera.Importe_Percepcion;
                        AmountType2 amountType2_2 = amountType2_1;
                        allowanceChargeType5.Amount = amountType2_2;
                        AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                        BaseAmountType baseAmountType1 = new BaseAmountType();
                        baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        baseAmountType1.Value = pCabecera.Base_Percepcion;
                        BaseAmountType baseAmountType2 = baseAmountType1;
                        allowanceChargeType6.BaseAmount = baseAmountType2;
                        AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                        allowanceChargeTypeArray[index2] = allowanceChargeType7;
                    }
                    this.XMLBoletaVta.AllowanceCharge = array2;
                }
                TaxSubtotalType[] array3 = new TaxSubtotalType[0];
                TaxAmountType taxAmountType1 = new TaxAmountType();
                taxAmountType1.currencyID = pCabecera.Codigo_Moneda;
                taxAmountType1.Value = pCabecera.Importe_IGV + pCabecera.Importe_ISC;
                TaxAmountType taxAmountType2 = taxAmountType1;
                if (pCabecera.Importe_IGV > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;

                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Gravado + pCabecera.Importe_ISC;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;

                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_IGV;
                    TaxAmountType taxAmountType4 = taxAmountType3;

                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType9 = new IDType();
                    idType9.schemeID = "UN/ECE 5305";
                    idType9.schemeName = "Tax Category identifierField";
                    idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType9.Value = "S";
                    IDType idType10 = idType9;
                    taxCategoryType2.ID = idType10;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "1000";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "IGV";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "VAT";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_ISC > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Base_ISC;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_ISC;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType9 = new IDType();
                    idType9.schemeID = "UN/ECE 5305";
                    idType9.schemeName = "Tax Category identifierField";
                    idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType9.Value = "S";
                    IDType idType10 = idType9;
                    taxCategoryType2.ID = idType10;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "2000";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "ISC";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "EXC";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_OtrosTributos > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Base_OtrosTributos;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pCabecera.Importe_OtrosTributos;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType9 = new IDType();
                    idType9.schemeID = "UN/ECE 5305";
                    idType9.schemeName = "Tax Category identifierField";
                    idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType9.Value = "S";
                    IDType idType10 = idType9;
                    taxCategoryType2.ID = idType10;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "9999";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "OTR";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "OTH";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_Exonerado > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Exonerado;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType9 = new IDType();
                    idType9.schemeID = "UN/ECE 5305";
                    idType9.schemeName = "Tax Category identifierField";
                    idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType9.Value = "E";
                    IDType idType10 = idType9;
                    taxCategoryType2.ID = idType10;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "9997";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "EXO";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "VAT";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_Inafecto > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Inafecto;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType9 = new IDType();
                    idType9.schemeID = "UN/ECE 5305";
                    idType9.schemeName = "Tax Category identifierField";
                    idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType9.Value = "O";
                    IDType idType10 = idType9;
                    taxCategoryType2.ID = idType10;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeID = "UN/ECE 5153";
                    idType11.schemeAgencyID = "6";
                    idType11.Value = "9998";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "INA";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "FRE";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }
                if (pCabecera.Importe_Gratuito > new Decimal(0))
                {
                    Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                    TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                    TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                    TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                    taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxableAmountType1.Value = pCabecera.Importe_Gratuito;
                    TaxableAmountType taxableAmountType2 = taxableAmountType1;
                    taxSubtotalType2.TaxableAmount = taxableAmountType2;
                    TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = new Decimal(0);
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    taxSubtotalType3.TaxAmount = taxAmountType4;
                    TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                    TaxCategoryType taxCategoryType2 = taxCategoryType1;
                    IDType idType9 = new IDType();
                    idType9.schemeID = "UN/ECE 5305";
                    idType9.schemeName = "Tax Category identifierField";
                    idType9.schemeAgencyName = "United Nations Economic Commission for Europe";
                    idType9.Value = "Z";
                    IDType idType10 = idType9;
                    taxCategoryType2.ID = idType10;
                    TaxCategoryType taxCategoryType3 = taxCategoryType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.schemeName = "Codigo de tributos";
                    idType11.schemeAgencyName = "PE:SUNAT";
                    idType11.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
                    //idType11.schemeID = "UN/ECE 5153";
                    //idType11.schemeAgencyID = "6";
                    idType11.Value = "9996";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "GRA";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "FRE";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    taxCategoryType3.TaxScheme = taxSchemeType5;
                    TaxCategoryType taxCategoryType4 = taxCategoryType1;
                    taxSubtotalType4.TaxCategory = taxCategoryType4;
                    TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                    array3[array3.Length - 1] = taxSubtotalType5;
                }
                this.XMLBoletaVta.TaxTotal = new TaxTotalType[1]
                {
                    new TaxTotalType()
                    {
                        TaxAmount = taxAmountType2,
                        TaxSubtotal = array3
                    }
                };
                PaymentType[] paymentTypeArray = new PaymentType[pLstDetalle.Count];
                for (int index2 = 0; index2 < pLstDetalle.Count; ++index2)
                {
                    if (pLstDetalle[index2].EsAnticipo)
                    {
                        PaymentType paymentType1 = new PaymentType();
                        PaymentType paymentType2 = paymentType1;
                        IDType idType9 = new IDType();
                        idType9.schemeID = pLstDetalle[index2].Codigo_Documento_Anticipo == "01" ? "03" : "03";
                        idType9.Value = pLstDetalle[index2].Serie_Documento_Anticipo + "-" + pLstDetalle[index2].Numero_Documento_Anticipo;
                        IDType idType10 = idType9;
                        paymentType2.ID = idType10;
                        PaymentType paymentType3 = paymentType1;
                        PaidAmountType paidAmountType1 = new PaidAmountType();
                        paidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        paidAmountType1.Value = pLstDetalle[index2].Importe_Total;
                        PaidAmountType paidAmountType2 = paidAmountType1;
                        paymentType3.PaidAmount = paidAmountType2;
                        PaymentType paymentType4 = paymentType1;
                        InstructionIDType instructionIdType1 = new InstructionIDType();
                        instructionIdType1.schemeID = pCabecera.TipoDoc_Emisor;
                        instructionIdType1.Value = pCabecera.NroDoc_Emisor;
                        InstructionIDType instructionIdType2 = instructionIdType1;
                        paymentType4.InstructionID = instructionIdType2;
                        paymentTypeArray[index2] = paymentType1;
                    }
                }
                this.XMLBoletaVta.PrepaidPayment = paymentTypeArray;
                if (pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion > new Decimal(0))
                {
                    if (pCabecera.Importe_Anticipos > new Decimal(0))
                    {
                        InvoiceType invoiceType6 = this.XMLBoletaVta;
                        MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();
                        MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                        LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                        extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        extensionAmountType1.Value = pCabecera.Importe_SubTotal;
                        LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                        monetaryTotalType2.LineExtensionAmount = extensionAmountType2;
                        MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                        TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                        exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        exclusiveAmountType1.Value = pCabecera.Importe_Total;
                        TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                        monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;
                        MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                        AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                        allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;
                        AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                        monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;
                        MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                        ChargeTotalAmountType chargeTotalAmountType1 = new ChargeTotalAmountType();
                        chargeTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        chargeTotalAmountType1.Value = pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;
                        ChargeTotalAmountType chargeTotalAmountType2 = chargeTotalAmountType1;
                        monetaryTotalType5.ChargeTotalAmount = chargeTotalAmountType2;
                        MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                        PrepaidAmountType prepaidAmountType1 = new PrepaidAmountType();
                        prepaidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        prepaidAmountType1.Value = pCabecera.Importe_Anticipos;
                        PrepaidAmountType prepaidAmountType2 = prepaidAmountType1;
                        monetaryTotalType6.PrepaidAmount = prepaidAmountType2;
                        MonetaryTotalType monetaryTotalType7 = monetaryTotalType1;
                        PayableAmountType payableAmountType1 = new PayableAmountType();
                        payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;
                        PayableAmountType payableAmountType2 = payableAmountType1;
                        monetaryTotalType7.PayableAmount = payableAmountType2;
                        MonetaryTotalType monetaryTotalType8 = monetaryTotalType1;
                        invoiceType6.LegalMonetaryTotal = monetaryTotalType8;
                    }
                    else
                    {
                        InvoiceType invoiceType6 = this.XMLBoletaVta;
                        MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();
                        MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                        LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                        extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        extensionAmountType1.Value = pCabecera.Importe_SubTotal;
                        LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                        monetaryTotalType2.LineExtensionAmount = extensionAmountType2;
                        MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                        TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                        exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        exclusiveAmountType1.Value = pCabecera.Importe_Total;
                        TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                        monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;
                        MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                        AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                        allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;
                        AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                        monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;
                        MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                        ChargeTotalAmountType chargeTotalAmountType1 = new ChargeTotalAmountType();
                        chargeTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        chargeTotalAmountType1.Value = pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;
                        ChargeTotalAmountType chargeTotalAmountType2 = chargeTotalAmountType1;
                        monetaryTotalType5.ChargeTotalAmount = chargeTotalAmountType2;
                        MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                        PayableAmountType payableAmountType1 = new PayableAmountType();
                        payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_OtrosCargos + pCabecera.Importe_Percepcion;
                        PayableAmountType payableAmountType2 = payableAmountType1;
                        monetaryTotalType6.PayableAmount = payableAmountType2;
                        MonetaryTotalType monetaryTotalType7 = monetaryTotalType1;
                        invoiceType6.LegalMonetaryTotal = monetaryTotalType7;
                    }
                }
                else if (pCabecera.Importe_Anticipos > new Decimal(0))
                {
                    InvoiceType invoiceType6 = this.XMLBoletaVta;
                    MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();
                    MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pCabecera.Importe_SubTotal;
                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    monetaryTotalType2.LineExtensionAmount = extensionAmountType2;
                    MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                    TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                    exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    exclusiveAmountType1.Value = pCabecera.Importe_Total;
                    TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                    monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;
                    MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                    AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                    allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;
                    AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                    monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;
                    MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                    PrepaidAmountType prepaidAmountType1 = new PrepaidAmountType();
                    prepaidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    prepaidAmountType1.Value = pCabecera.Importe_Anticipos;
                    PrepaidAmountType prepaidAmountType2 = prepaidAmountType1;
                    monetaryTotalType5.PrepaidAmount = prepaidAmountType2;
                    MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                    PayableAmountType payableAmountType1 = new PayableAmountType();
                    payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_Percepcion;
                    PayableAmountType payableAmountType2 = payableAmountType1;
                    monetaryTotalType6.PayableAmount = payableAmountType2;
                    MonetaryTotalType monetaryTotalType7 = monetaryTotalType1;
                    invoiceType6.LegalMonetaryTotal = monetaryTotalType7;
                }
                else
                {
                    InvoiceType invoiceType6 = this.XMLBoletaVta;
                    MonetaryTotalType monetaryTotalType1 = new MonetaryTotalType();
                    MonetaryTotalType monetaryTotalType2 = monetaryTotalType1;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pCabecera.Importe_SubTotal;
                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    monetaryTotalType2.LineExtensionAmount = extensionAmountType2;
                    MonetaryTotalType monetaryTotalType3 = monetaryTotalType1;
                    TaxExclusiveAmountType exclusiveAmountType1 = new TaxExclusiveAmountType();
                    exclusiveAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    exclusiveAmountType1.Value = pCabecera.Importe_Total;
                    TaxExclusiveAmountType exclusiveAmountType2 = exclusiveAmountType1;
                    monetaryTotalType3.TaxExclusiveAmount = exclusiveAmountType2;
                    MonetaryTotalType monetaryTotalType4 = monetaryTotalType1;
                    AllowanceTotalAmountType allowanceTotalAmountType1 = new AllowanceTotalAmountType();
                    allowanceTotalAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    allowanceTotalAmountType1.Value = pCabecera.Importe_DctoGlobal + pCabecera.Importe_Descuento;
                    AllowanceTotalAmountType allowanceTotalAmountType2 = allowanceTotalAmountType1;
                    monetaryTotalType4.AllowanceTotalAmount = allowanceTotalAmountType2;
                    MonetaryTotalType monetaryTotalType5 = monetaryTotalType1;
                    PayableAmountType payableAmountType1 = new PayableAmountType();
                    payableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    payableAmountType1.Value = pCabecera.Importe_Total + pCabecera.Importe_Percepcion;
                    PayableAmountType payableAmountType2 = payableAmountType1;
                    monetaryTotalType5.PayableAmount = payableAmountType2;
                    MonetaryTotalType monetaryTotalType6 = monetaryTotalType1;
                    invoiceType6.LegalMonetaryTotal = monetaryTotalType6;
                }
                InvoiceLineType[] invoiceLineTypeArray = new InvoiceLineType[pLstDetalle.Count];
                for (int index2 = 0; index2 < pLstDetalle.Count; ++index2)
                {
                    InvoiceLineType invoiceLineType1 = new InvoiceLineType();
                    InvoiceLineType invoiceLineType2 = invoiceLineType1;
                    IDType idType9 = new IDType();
                    idType9.Value = pLstDetalle[index2].NroItem.Trim();
                    IDType idType10 = idType9;
                    invoiceLineType2.ID = idType10;
                    InvoiceLineType invoiceLineType3 = invoiceLineType1;
                    InvoicedQuantityType invoicedQuantityType1 = new InvoicedQuantityType();
                    invoicedQuantityType1.Value = pLstDetalle[index2].Cantidad;
                    invoicedQuantityType1.unitCode = pLstDetalle[index2].Codigo_Unidad;
                    invoicedQuantityType1.unitCodeListID = "UN/ECE rec 20";
                    invoicedQuantityType1.unitCodeListAgencyName = "United Nations Economic Commission for Europe";
                    InvoicedQuantityType invoicedQuantityType2 = invoicedQuantityType1;
                    invoiceLineType3.InvoicedQuantity = invoicedQuantityType2;
                    LineExtensionAmountType extensionAmountType1 = new LineExtensionAmountType();
                    extensionAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    extensionAmountType1.Value = pLstDetalle[index2].EsGratuito ? new Decimal(0) : Convert.ToDecimal(pLstDetalle[index2].Importe_SubTotal);
                    LineExtensionAmountType extensionAmountType2 = extensionAmountType1;
                    invoiceLineType1.LineExtensionAmount = extensionAmountType2;
                    PriceType[] priceTypeArray = new PriceType[1];
                    PriceType priceType1 = new PriceType();
                    PriceType priceType2 = priceType1;
                    PriceAmountType priceAmountType1 = new PriceAmountType();
                    priceAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    priceAmountType1.Value = pLstDetalle[index2].Precio_Unitario_ConIGV;
                    PriceAmountType priceAmountType2 = priceAmountType1;
                    priceType2.PriceAmount = priceAmountType2;
                    PriceType priceType3 = priceType1;
                    PriceTypeCodeType priceTypeCodeType1 = new PriceTypeCodeType();
                    priceTypeCodeType1.listName = "Tipo de Precio"; //"SUNAT:Indicador de Tipo de Precio";
                    priceTypeCodeType1.listAgencyName = "PE:SUNAT";
                    priceTypeCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16";
                    priceTypeCodeType1.Value = pCabecera.Tipo_Venta == "E" || pLstDetalle[index2].EsGratuito ? "02" : "01";
                    PriceTypeCodeType priceTypeCodeType2 = priceTypeCodeType1;
                    priceType3.PriceTypeCode = priceTypeCodeType2;
                    PriceType priceType4 = priceType1;
                    priceTypeArray[0] = priceType4;
                    PricingReferenceType pricingReferenceType = new PricingReferenceType()
                    {
                        AlternativeConditionPrice = priceTypeArray
                    };
                    invoiceLineType1.PricingReference = pricingReferenceType;
                    if (pLstDetalle[index2].Importe_Descuento > new Decimal(0))
                    {
                        array2 = new AllowanceChargeType[1];
                        AllowanceChargeType[] allowanceChargeTypeArray = array2;
                        AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                        AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                        ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                        chargeIndicatorType1.Value = false;
                        ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                        allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;
                        AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                        AllowanceChargeReasonCodeType chargeReasonCodeType1 = new AllowanceChargeReasonCodeType();
                        chargeReasonCodeType1.Value = "00";
                        AllowanceChargeReasonCodeType chargeReasonCodeType2 = chargeReasonCodeType1;
                        allowanceChargeType3.AllowanceChargeReasonCode = chargeReasonCodeType2;
                        AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                        MultiplierFactorNumericType factorNumericType1 = new MultiplierFactorNumericType();
                        factorNumericType1.Value = pLstDetalle[index2].Porcentaje_Descuento / new Decimal(100);
                        MultiplierFactorNumericType factorNumericType2 = factorNumericType1;
                        allowanceChargeType4.MultiplierFactorNumeric = factorNumericType2;
                        AllowanceChargeType allowanceChargeType5 = allowanceChargeType1;
                        AmountType2 amountType2_1 = new AmountType2();
                        amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                        amountType2_1.Value = pLstDetalle[index2].Importe_Descuento;
                        AmountType2 amountType2_2 = amountType2_1;
                        allowanceChargeType5.Amount = amountType2_2;
                        AllowanceChargeType allowanceChargeType6 = allowanceChargeType1;
                        BaseAmountType baseAmountType1 = new BaseAmountType();
                        baseAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        baseAmountType1.Value = pLstDetalle[index2].Importe_SubTotal;
                        BaseAmountType baseAmountType2 = baseAmountType1;
                        allowanceChargeType6.BaseAmount = baseAmountType2;
                        AllowanceChargeType allowanceChargeType7 = allowanceChargeType1;
                        allowanceChargeTypeArray[0] = allowanceChargeType7;
                        invoiceLineType1.AllowanceCharge = array2;
                    }
                    array3 = new TaxSubtotalType[0];
                    TaxAmountType taxAmountType3 = new TaxAmountType();
                    taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType3.Value = pLstDetalle[index2].Importe_IGV;
                    TaxAmountType taxAmountType4 = taxAmountType3;
                    if (pLstDetalle[index2].Importe_IGV > new Decimal(0))
                    {
                        Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = pLstDetalle[index2].Importe_SubTotal - pCabecera.Importe_ISC;
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_IGV;
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType11 = new IDType();
                        idType11.schemeID = "UN/ECE 5305";
                        idType11.schemeName = "Tax Category identifierField";
                        idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType11.Value = "S";
                        IDType idType12 = idType11;
                        taxCategoryType2.ID = idType12;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType13 = new IDType();
                        //idType13.schemeID = "UN/ECE 5153";
                        idType13.schemeName = "Codigo de tributos"; //"Tax Schema Identifier";
                        idType13.schemeAgencyName = "PE:SUNAT"; //"United Nations Economic Commission for Europe";
                        idType13.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
                        idType13.Value = "1000";
                        IDType idType14 = idType13;
                        taxSchemeType2.ID = idType14;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "IGV";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "VAT";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array3[array3.Length - 1] = taxSubtotalType5;
                    }
                    if (pLstDetalle[index2].Importe_ISC > new Decimal(0))
                    {
                        Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = pLstDetalle[index2].Importe_ValorVenta;
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_ISC;
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType11 = new IDType();
                        idType11.schemeID = "UN/ECE 5305";
                        idType11.schemeName = "Tax Category identifierField";
                        idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType11.Value = "S";
                        IDType idType12 = idType11;
                        taxCategoryType2.ID = idType12;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pLstDetalle[index2].Porcentaje_ISC;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5153";
                        idType13.schemeName = "Tax Schema Identifier";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "2000";
                        IDType idType14 = idType13;
                        taxSchemeType2.ID = idType14;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "ISC";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "EXC";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array3[array3.Length - 1] = taxSubtotalType5;
                    }
                    if (pLstDetalle[index2].EsExonerado)
                    {
                        Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = new Decimal(0);
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = new Decimal(0);
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType11 = new IDType();
                        idType11.schemeID = "UN/ECE 5305";
                        idType11.schemeName = "Tax Category identifierField";
                        idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType11.Value = "E";
                        IDType idType12 = idType11;
                        taxCategoryType2.ID = idType12;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5153";
                        idType13.schemeName = "Tax Schema Identifier";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "9997";
                        IDType idType14 = idType13;
                        taxSchemeType2.ID = idType14;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "EXO";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "VAT";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array3[array3.Length - 1] = taxSubtotalType5;
                    }
                    if (pLstDetalle[index2].EsInafecto)
                    {
                        Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = new Decimal(0);
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_ValorVenta;
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType11 = new IDType();
                        idType11.schemeID = "UN/ECE 5305";
                        idType11.schemeName = "Tax Category identifierField";
                        idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType11.Value = "O";
                        IDType idType12 = idType11;
                        taxCategoryType2.ID = idType12;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType13 = new IDType();
                        idType13.schemeID = "UN/ECE 5153";
                        idType13.schemeName = "Tax Schema Identifier";
                        idType13.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType13.Value = "9998";
                        IDType idType14 = idType13;
                        taxSchemeType2.ID = idType14;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "INA";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "FRE";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array3[array3.Length - 1] = taxSubtotalType5;
                    }
                    if (pLstDetalle[index2].EsGratuito)
                    {
                        Array.Resize<TaxSubtotalType>(ref array3, array3.Length + 1);
                        TaxSubtotalType taxSubtotalType1 = new TaxSubtotalType();
                        TaxSubtotalType taxSubtotalType2 = taxSubtotalType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = new Decimal(0);
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        taxSubtotalType2.TaxableAmount = taxableAmountType2;
                        TaxSubtotalType taxSubtotalType3 = taxSubtotalType1;
                        TaxAmountType taxAmountType5 = new TaxAmountType();
                        taxAmountType5.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType5.Value = pLstDetalle[index2].Importe_ValorVenta;
                        TaxAmountType taxAmountType6 = taxAmountType5;
                        taxSubtotalType3.TaxAmount = taxAmountType6;
                        TaxSubtotalType taxSubtotalType4 = taxSubtotalType1;
                        TaxCategoryType taxCategoryType1 = new TaxCategoryType();
                        TaxCategoryType taxCategoryType2 = taxCategoryType1;
                        IDType idType11 = new IDType();
                        idType11.schemeID = "UN/ECE 5305";
                        idType11.schemeName = "Tax Category identifierField";
                        idType11.schemeAgencyName = "United Nations Economic Commission for Europe";
                        idType11.Value = "O";
                        IDType idType12 = idType11;
                        taxCategoryType2.ID = idType12;
                        TaxCategoryType taxCategoryType3 = taxCategoryType1;
                        PercentType1 percentType1_1 = new PercentType1();
                        percentType1_1.Value = pCabecera.PorcentajeIGV;
                        PercentType1 percentType1_2 = percentType1_1;
                        taxCategoryType3.Percent = percentType1_2;
                        TaxCategoryType taxCategoryType4 = taxCategoryType1;
                        TaxExemptionReasonCodeType exemptionReasonCodeType1 = new TaxExemptionReasonCodeType();
                        exemptionReasonCodeType1.listAgencyName = "PE:SUNAT";
                        exemptionReasonCodeType1.listName = "Afectacion del IGV"; //"SUNAT:Codigo de Tipo de Afectación del IGV";
                        exemptionReasonCodeType1.listURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07";
                        exemptionReasonCodeType1.Value = pLstDetalle[index2].Tipo_AfeccionIGV;
                        TaxExemptionReasonCodeType exemptionReasonCodeType2 = exemptionReasonCodeType1;
                        taxCategoryType4.TaxExemptionReasonCode = exemptionReasonCodeType2;
                        TaxCategoryType taxCategoryType5 = taxCategoryType1;
                        TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType2 = taxSchemeType1;
                        IDType idType13 = new IDType();
                        //idType13.schemeID = "UN/ECE 5153";
                        idType13.schemeName = "Codigo de tributos"; //"Tax Schema Identifie";
                        idType13.schemeAgencyName = "PE:SUNAT"; //"United Nations Economic Commission for Europe";
                        idType13.schemeURI = "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo05";
                        idType13.Value = "9996";
                        IDType idType14 = idType13;
                        taxSchemeType2.ID = idType14;
                        TaxSchemeType taxSchemeType3 = taxSchemeType1;
                        NameType1 nameType1_5 = new NameType1();
                        nameType1_5.Value = "GRA";
                        NameType1 nameType1_6 = nameType1_5;
                        taxSchemeType3.Name = nameType1_6;
                        TaxSchemeType taxSchemeType4 = taxSchemeType1;
                        TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                        taxTypeCodeType1.Value = "FRE";
                        TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                        taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                        TaxSchemeType taxSchemeType5 = taxSchemeType1;
                        taxCategoryType5.TaxScheme = taxSchemeType5;
                        TaxCategoryType taxCategoryType6 = taxCategoryType1;
                        taxSubtotalType4.TaxCategory = taxCategoryType6;
                        TaxSubtotalType taxSubtotalType5 = taxSubtotalType1;
                        array3[array3.Length - 1] = taxSubtotalType5;
                    }
                    TaxTotalType[] taxTotalTypeArray = new TaxTotalType[1]
                    {
                        new TaxTotalType()
                        {
                          TaxAmount = taxAmountType4,
                          TaxSubtotal = array3
                        }
                    };
                    invoiceLineType1.TaxTotal = taxTotalTypeArray;
                    DescriptionType descriptionType = new DescriptionType();
                    descriptionType.Value = pLstDetalle[index2].Descripcion_Articulo.Trim();
                    DescriptionType[] descriptionTypeArray = new DescriptionType[1]
                    {
                        descriptionType
                    };
                    ItemIdentificationType identificationType7 = new ItemIdentificationType();
                    ItemIdentificationType identificationType8 = identificationType7;
                    IDType idType15 = new IDType();
                    idType15.Value = pLstDetalle[index2].Codigo_Articulo;
                    IDType idType16 = idType15;
                    identificationType8.ID = idType16;
                    ItemIdentificationType identificationType9 = identificationType7;
                    if (string.IsNullOrEmpty(pLstDetalle[index2].Codigo_Producto_Sunat))
                    {
                        invoiceLineType1.Item = new ItemType()
                        {
                            Description = descriptionTypeArray,
                            SellersItemIdentification = identificationType9
                        };
                    }
                    else
                    {
                        ItemClassificationCodeType classificationCodeType1 = new ItemClassificationCodeType();
                        classificationCodeType1.Value = pLstDetalle[index2].Codigo_Producto_Sunat;
                        classificationCodeType1.listID = "UNSPSC";
                        classificationCodeType1.listAgencyName = "GS1 US";
                        classificationCodeType1.listName = "Item Classification";
                        ItemClassificationCodeType classificationCodeType2 = classificationCodeType1;
                        CommodityClassificationType[] classificationTypeArray = new CommodityClassificationType[1]
                        {
                            new CommodityClassificationType()
                            {
                                ItemClassificationCode = classificationCodeType2
                            }
                        };
                        invoiceLineType1.Item = new ItemType()
                        {
                            Description = descriptionTypeArray,
                            SellersItemIdentification = identificationType9,
                            CommodityClassification = classificationTypeArray
                        };
                    }
                    PriceAmountType priceAmountType3;
                    if (pCabecera.Tipo_Venta == "E")
                    {
                        PriceAmountType priceAmountType4 = new PriceAmountType();
                        priceAmountType4.currencyID = pCabecera.Codigo_Moneda;
                        priceAmountType4.Value = new Decimal(0);
                        priceAmountType3 = priceAmountType4;
                    }
                    else
                    {
                        PriceAmountType priceAmountType4 = new PriceAmountType();
                        priceAmountType4.currencyID = pCabecera.Codigo_Moneda;
                        priceAmountType4.Value = pLstDetalle[index2].EsGratuito ? new Decimal(0) : Convert.ToDecimal(pLstDetalle[index2].Precio_Unitario_SinIGV);
                        priceAmountType3 = priceAmountType4;
                    }
                    invoiceLineType1.Price = new PriceType()
                    {
                        PriceAmount = priceAmountType3
                    };
                    invoiceLineTypeArray[index2] = invoiceLineType1;
                }
                this.XMLBoletaVta.InvoiceLine = invoiceLineTypeArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraResumenDiario(ResumenDiarioCabecera pCabecera, List<ResumenDiarioDetalle> pLstDetalle)
        {
            try
            {
                this.XMLSummaryDocuments = new SummaryDocumentsType();
                SummaryDocumentsType summaryDocumentsType1 = this.XMLSummaryDocuments;
                UBLVersionIDType ublVersionIdType1 = new UBLVersionIDType();
                ublVersionIdType1.Value = "2.0";
                UBLVersionIDType ublVersionIdType2 = ublVersionIdType1;
                summaryDocumentsType1.UBLVersionID = ublVersionIdType2;
                SummaryDocumentsType summaryDocumentsType2 = this.XMLSummaryDocuments;
                CustomizationIDType customizationIdType1 = new CustomizationIDType();
                customizationIdType1.Value = "1.1";
                CustomizationIDType customizationIdType2 = customizationIdType1;
                summaryDocumentsType2.CustomizationID = customizationIdType2;
                SummaryDocumentsType summaryDocumentsType3 = this.XMLSummaryDocuments;
                IDType idType1 = new IDType();
                idType1.Value = pCabecera.Identificador;
                IDType idType2 = idType1;
                summaryDocumentsType3.ID = idType2;
                SummaryDocumentsType summaryDocumentsType4 = this.XMLSummaryDocuments;
                IssueDateType issueDateType1 = new IssueDateType();
                issueDateType1.Value = pCabecera.Fecha_Resumen;
                IssueDateType issueDateType2 = issueDateType1;
                summaryDocumentsType4.IssueDate = issueDateType2;
                SummaryDocumentsType summaryDocumentsType5 = this.XMLSummaryDocuments;
                ReferenceDateType referenceDateType1 = new ReferenceDateType();
                referenceDateType1.Value = Convert.ToDateTime(pCabecera.Fecha_Emision);
                ReferenceDateType referenceDateType2 = referenceDateType1;
                summaryDocumentsType5.ReferenceDate = referenceDateType2;
                PartyIdentificationType identificationType1 = new PartyIdentificationType();
                PartyIdentificationType identificationType2 = identificationType1;
                IDType idType3 = new IDType();
                idType3.Value = pCabecera.NroDoc_Emisor;
                IDType idType4 = idType3;
                identificationType2.ID = idType4;
                PartyIdentificationType identificationType3 = identificationType1;
                PartyNameType partyNameType1 = new PartyNameType();
                PartyNameType partyNameType2 = partyNameType1;
                NameType1 nameType1_1 = new NameType1();
                nameType1_1.Value = pCabecera.RSocial_Emisor;
                NameType1 nameType1_2 = nameType1_1;
                partyNameType2.Name = nameType1_2;
                PartyNameType partyNameType3 = partyNameType1;
                PartyType partyType1 = new PartyType()
                {
                    PartyIdentification = new PartyIdentificationType[1]
                  {
            identificationType3
                  },
                    PartyName = new PartyNameType[1] { partyNameType3 }
                };
                AttachmentType attachmentType1 = new AttachmentType();
                AttachmentType attachmentType2 = attachmentType1;
                ExternalReferenceType externalReferenceType1 = new ExternalReferenceType();
                ExternalReferenceType externalReferenceType2 = externalReferenceType1;
                URIType uriType1 = new URIType();
                uriType1.Value = "#SignatureKG";
                URIType uriType2 = uriType1;
                externalReferenceType2.URI = uriType2;
                ExternalReferenceType externalReferenceType3 = externalReferenceType1;
                attachmentType2.ExternalReference = externalReferenceType3;
                AttachmentType attachmentType3 = attachmentType1;
                SignatureType signatureType1 = new SignatureType();
                SignatureType signatureType2 = signatureType1;
                IDType idType5 = new IDType();
                idType5.Value = pCabecera.NroDoc_Emisor;
                IDType idType6 = idType5;
                signatureType2.ID = idType6;
                signatureType1.SignatoryParty = partyType1;
                signatureType1.DigitalSignatureAttachment = attachmentType3;
                SignatureType signatureType3 = signatureType1;
                UBLExtensionType ublExtensionType = new UBLExtensionType()
                {
                    ExtensionContent = new XmlDocument().CreateElement("dummy")
                };
                this.XMLSummaryDocuments.Signature = new SignatureType[1]
                {
          signatureType3
                };
                this.XMLSummaryDocuments.UBLExtensions = new UBLExtensionType[1]
                {
          ublExtensionType
                };
                PartyLegalEntityType partyLegalEntityType1 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType2 = partyLegalEntityType1;
                RegistrationNameType registrationNameType1 = new RegistrationNameType();
                registrationNameType1.Value = pCabecera.RSocial_Emisor;
                RegistrationNameType registrationNameType2 = registrationNameType1;
                partyLegalEntityType2.RegistrationName = registrationNameType2;
                PartyLegalEntityType partyLegalEntityType3 = partyLegalEntityType1;
                PartyNameType partyNameType4 = new PartyNameType();
                PartyNameType partyNameType5 = partyNameType4;
                NameType1 nameType1_3 = new NameType1();
                nameType1_3.Value = pCabecera.NombreCorto_Emisor;
                NameType1 nameType1_4 = nameType1_3;
                partyNameType5.Name = nameType1_4;
                PartyNameType partyNameType6 = partyNameType4;
                PartyType partyType2 = new PartyType()
                {
                    PartyName = new PartyNameType[1] { partyNameType6 },
                    PartyLegalEntity = new PartyLegalEntityType[1]
                  {
            partyLegalEntityType3
                  }
                };
                AdditionalAccountIDType additionalAccountIdType1 = new AdditionalAccountIDType();
                additionalAccountIdType1.Value = pCabecera.TipoDoc_Emisor;
                AdditionalAccountIDType additionalAccountIdType2 = additionalAccountIdType1;
                SupplierPartyType supplierPartyType1 = new SupplierPartyType();
                supplierPartyType1.Party = partyType2;
                SupplierPartyType supplierPartyType2 = supplierPartyType1;
                CustomerAssignedAccountIDType assignedAccountIdType1 = new CustomerAssignedAccountIDType();
                assignedAccountIdType1.Value = pCabecera.NroDoc_Emisor;
                CustomerAssignedAccountIDType assignedAccountIdType2 = assignedAccountIdType1;
                supplierPartyType2.CustomerAssignedAccountID = assignedAccountIdType2;
                supplierPartyType1.AdditionalAccountID = new AdditionalAccountIDType[1]
                {
          additionalAccountIdType2
                };
                this.XMLSummaryDocuments.AccountingSupplierParty = supplierPartyType1;
                SummaryDocumentsLineType[] documentsLineTypeArray = new SummaryDocumentsLineType[pLstDetalle.Count];
                for (int index1 = 0; index1 <= pLstDetalle.Count - 1; ++index1)
                {
                    SummaryDocumentsLineType documentsLineType1 = new SummaryDocumentsLineType();
                    SummaryDocumentsLineType documentsLineType2 = documentsLineType1;
                    LineIDType lineIdType1 = new LineIDType();
                    lineIdType1.Value = (index1 + 1).ToString();
                    LineIDType lineIdType2 = lineIdType1;
                    documentsLineType2.LineID = lineIdType2;
                    SummaryDocumentsLineType documentsLineType3 = documentsLineType1;
                    DocumentTypeCodeType documentTypeCodeType1 = new DocumentTypeCodeType();
                    documentTypeCodeType1.Value = pLstDetalle[index1].Codigo_Documento;
                    DocumentTypeCodeType documentTypeCodeType2 = documentTypeCodeType1;
                    documentsLineType3.DocumentTypeCode = documentTypeCodeType2;
                    SummaryDocumentsLineType documentsLineType4 = documentsLineType1;
                    IDType idType7 = new IDType();
                    idType7.Value = pLstDetalle[index1].Serie_Documento + "-" + pLstDetalle[index1].Numero_Documento;
                    IDType idType8 = idType7;
                    documentsLineType4.ID = idType8;
                    CustomerPartyType customerPartyType1 = new CustomerPartyType();
                    CustomerPartyType customerPartyType2 = customerPartyType1;
                    CustomerAssignedAccountIDType assignedAccountIdType3 = new CustomerAssignedAccountIDType();
                    assignedAccountIdType3.Value = pLstDetalle[index1].NroDoc_Receptor;
                    CustomerAssignedAccountIDType assignedAccountIdType4 = assignedAccountIdType3;
                    customerPartyType2.CustomerAssignedAccountID = assignedAccountIdType4;
                    CustomerPartyType customerPartyType3 = customerPartyType1;
                    AdditionalAccountIDType[] additionalAccountIdTypeArray1 = new AdditionalAccountIDType[1];
                    AdditionalAccountIDType[] additionalAccountIdTypeArray2 = additionalAccountIdTypeArray1;
                    AdditionalAccountIDType additionalAccountIdType3 = new AdditionalAccountIDType();
                    additionalAccountIdType3.Value = pLstDetalle[index1].TipoDoc_Receptor;
                    AdditionalAccountIDType additionalAccountIdType4 = additionalAccountIdType3;
                    additionalAccountIdTypeArray2[0] = additionalAccountIdType4;
                    AdditionalAccountIDType[] additionalAccountIdTypeArray3 = additionalAccountIdTypeArray1;
                    customerPartyType3.AdditionalAccountID = additionalAccountIdTypeArray3;
                    CustomerPartyType customerPartyType4 = customerPartyType1;
                    documentsLineType1.AccountingCustomerParty = customerPartyType4;
                    if (pLstDetalle[index1].Codigo_Documento == "07" || pLstDetalle[index1].Codigo_Documento == "08")
                    {
                        DocumentReferenceType documentReferenceType1 = new DocumentReferenceType();
                        DocumentReferenceType documentReferenceType2 = documentReferenceType1;
                        IDType idType9 = new IDType();
                        idType9.Value = pLstDetalle[index1].Documento_Refe;
                        IDType idType10 = idType9;
                        documentReferenceType2.ID = idType10;
                        DocumentReferenceType documentReferenceType3 = documentReferenceType1;
                        DocumentTypeCodeType documentTypeCodeType3 = new DocumentTypeCodeType();
                        documentTypeCodeType3.Value = pLstDetalle[index1].Codigo_Documento_Refe;
                        DocumentTypeCodeType documentTypeCodeType4 = documentTypeCodeType3;
                        documentReferenceType3.DocumentTypeCode = documentTypeCodeType4;
                        DocumentReferenceType documentReferenceType4 = documentReferenceType1;
                        BillingReferenceType billingReferenceType = new BillingReferenceType()
                        {
                            InvoiceDocumentReference = documentReferenceType4
                        };
                        documentsLineType1.BillingReference = billingReferenceType;
                    }
                    if (pLstDetalle[index1].Importe_Percepcion > new Decimal(0))
                    {
                        SummaryDocumentsLineType documentsLineType5 = documentsLineType1;
                        SUNATPerceptionSummaryDocumentReferenceType documentReferenceType1 = new SUNATPerceptionSummaryDocumentReferenceType();
                        SUNATPerceptionSummaryDocumentReferenceType documentReferenceType2 = documentReferenceType1;
                        IDType idType9 = new IDType();
                        idType9.Value = pLstDetalle[index1].Regimen_Percepcion;
                        IDType idType10 = idType9;
                        documentReferenceType2.SUNATPerceptionSystemCode = idType10;
                        SUNATPerceptionSummaryDocumentReferenceType documentReferenceType3 = documentReferenceType1;
                        PercentType percentType1 = new PercentType();
                        percentType1.Value = pLstDetalle[index1].Tasa_Percepcion;
                        PercentType percentType2 = percentType1;
                        documentReferenceType3.SUNATPerceptionPercent = percentType2;
                        SUNATPerceptionSummaryDocumentReferenceType documentReferenceType4 = documentReferenceType1;
                        TotalInvoiceAmountType invoiceAmountType1 = new TotalInvoiceAmountType();
                        invoiceAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        invoiceAmountType1.Value = pLstDetalle[index1].Importe_Percepcion;
                        TotalInvoiceAmountType invoiceAmountType2 = invoiceAmountType1;
                        documentReferenceType4.TotalInvoiceAmount = invoiceAmountType2;
                        SUNATPerceptionSummaryDocumentReferenceType documentReferenceType5 = documentReferenceType1;
                        AmountType1 amountType1_1 = new AmountType1();
                        amountType1_1.currencyID = pCabecera.Codigo_Moneda;
                        amountType1_1.Value = pLstDetalle[index1].Importe_Total;
                        AmountType1 amountType1_2 = amountType1_1;
                        documentReferenceType5.SUNATTotalCashed = amountType1_2;
                        SUNATPerceptionSummaryDocumentReferenceType documentReferenceType6 = documentReferenceType1;
                        TaxableAmountType taxableAmountType1 = new TaxableAmountType();
                        taxableAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        taxableAmountType1.Value = pLstDetalle[index1].Base_Percepcion;
                        TaxableAmountType taxableAmountType2 = taxableAmountType1;
                        documentReferenceType6.TaxableAmount = taxableAmountType2;
                        SUNATPerceptionSummaryDocumentReferenceType documentReferenceType7 = documentReferenceType1;
                        documentsLineType5.SUNATPerceptionSummaryDocumentReference = documentReferenceType7;
                    }
                    SummaryDocumentsLineType documentsLineType6 = documentsLineType1;
                    StatusType statusType1 = new StatusType();
                    StatusType statusType2 = statusType1;
                    ConditionCodeType conditionCodeType1 = new ConditionCodeType();
                    conditionCodeType1.Value = pLstDetalle[index1].Estado;
                    ConditionCodeType conditionCodeType2 = conditionCodeType1;
                    statusType2.ConditionCode = conditionCodeType2;
                    StatusType statusType3 = statusType1;
                    documentsLineType6.Status = statusType3;
                    AmountType1 amountType1_3 = new AmountType1();
                    amountType1_3.currencyID = pCabecera.Codigo_Moneda;
                    amountType1_3.Value = pLstDetalle[index1].Importe_Total;
                    AmountType1 amountType1_4 = amountType1_3;
                    documentsLineType1.TotalAmount = amountType1_4;
                    PaymentType[] array1 = new PaymentType[0];
                    if (pLstDetalle[index1].Importe_Gravado != new Decimal(0))
                    {
                        Array.Resize<PaymentType>(ref array1, array1.Length + 1);
                        PaymentType[] paymentTypeArray = array1;
                        int index2 = array1.Length - 1;
                        PaymentType paymentType1 = new PaymentType();
                        PaymentType paymentType2 = paymentType1;
                        PaidAmountType paidAmountType1 = new PaidAmountType();
                        paidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        paidAmountType1.Value = pLstDetalle[index1].Importe_Gravado;
                        PaidAmountType paidAmountType2 = paidAmountType1;
                        paymentType2.PaidAmount = paidAmountType2;
                        PaymentType paymentType3 = paymentType1;
                        InstructionIDType instructionIdType1 = new InstructionIDType();
                        instructionIdType1.Value = "01";
                        InstructionIDType instructionIdType2 = instructionIdType1;
                        paymentType3.InstructionID = instructionIdType2;
                        PaymentType paymentType4 = paymentType1;
                        paymentTypeArray[index2] = paymentType4;
                    }
                    if (pLstDetalle[index1].Importe_Exonerado != new Decimal(0))
                    {
                        Array.Resize<PaymentType>(ref array1, array1.Length + 1);
                        PaymentType[] paymentTypeArray = array1;
                        int index2 = array1.Length - 1;
                        PaymentType paymentType1 = new PaymentType();
                        PaymentType paymentType2 = paymentType1;
                        PaidAmountType paidAmountType1 = new PaidAmountType();
                        paidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        paidAmountType1.Value = pLstDetalle[index1].Importe_Exonerado;
                        PaidAmountType paidAmountType2 = paidAmountType1;
                        paymentType2.PaidAmount = paidAmountType2;
                        PaymentType paymentType3 = paymentType1;
                        InstructionIDType instructionIdType1 = new InstructionIDType();
                        instructionIdType1.Value = "03";
                        InstructionIDType instructionIdType2 = instructionIdType1;
                        paymentType3.InstructionID = instructionIdType2;
                        PaymentType paymentType4 = paymentType1;
                        paymentTypeArray[index2] = paymentType4;
                    }
                    if (pLstDetalle[index1].Importe_Inafecto != new Decimal(0))
                    {
                        Array.Resize<PaymentType>(ref array1, array1.Length + 1);
                        PaymentType[] paymentTypeArray = array1;
                        int index2 = array1.Length - 1;
                        PaymentType paymentType1 = new PaymentType();
                        PaymentType paymentType2 = paymentType1;
                        PaidAmountType paidAmountType1 = new PaidAmountType();
                        paidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        paidAmountType1.Value = pLstDetalle[index1].Importe_Inafecto;
                        PaidAmountType paidAmountType2 = paidAmountType1;
                        paymentType2.PaidAmount = paidAmountType2;
                        PaymentType paymentType3 = paymentType1;
                        InstructionIDType instructionIdType1 = new InstructionIDType();
                        instructionIdType1.Value = "03";
                        InstructionIDType instructionIdType2 = instructionIdType1;
                        paymentType3.InstructionID = instructionIdType2;
                        PaymentType paymentType4 = paymentType1;
                        paymentTypeArray[index2] = paymentType4;
                    }
                    if (pLstDetalle[index1].Importe_Gratuito != new Decimal(0))
                    {
                        Array.Resize<PaymentType>(ref array1, array1.Length + 1);
                        PaymentType[] paymentTypeArray = array1;
                        int index2 = array1.Length - 1;
                        PaymentType paymentType1 = new PaymentType();
                        PaymentType paymentType2 = paymentType1;
                        PaidAmountType paidAmountType1 = new PaidAmountType();
                        paidAmountType1.currencyID = pCabecera.Codigo_Moneda;
                        paidAmountType1.Value = pLstDetalle[index1].Importe_Gratuito;
                        PaidAmountType paidAmountType2 = paidAmountType1;
                        paymentType2.PaidAmount = paidAmountType2;
                        PaymentType paymentType3 = paymentType1;
                        InstructionIDType instructionIdType1 = new InstructionIDType();
                        instructionIdType1.Value = "05";
                        InstructionIDType instructionIdType2 = instructionIdType1;
                        paymentType3.InstructionID = instructionIdType2;
                        PaymentType paymentType4 = paymentType1;
                        paymentTypeArray[index2] = paymentType4;
                    }
                    AllowanceChargeType[] allowanceChargeTypeArray1 = new AllowanceChargeType[1];
                    AllowanceChargeType[] allowanceChargeTypeArray2 = allowanceChargeTypeArray1;
                    AllowanceChargeType allowanceChargeType1 = new AllowanceChargeType();
                    AllowanceChargeType allowanceChargeType2 = allowanceChargeType1;
                    ChargeIndicatorType chargeIndicatorType1 = new ChargeIndicatorType();
                    chargeIndicatorType1.Value = true;
                    ChargeIndicatorType chargeIndicatorType2 = chargeIndicatorType1;
                    allowanceChargeType2.ChargeIndicator = chargeIndicatorType2;
                    AllowanceChargeType allowanceChargeType3 = allowanceChargeType1;
                    AmountType2 amountType2_1 = new AmountType2();
                    amountType2_1.currencyID = pCabecera.Codigo_Moneda;
                    amountType2_1.Value = pLstDetalle[index1].Importe_OtrosCargos;
                    AmountType2 amountType2_2 = amountType2_1;
                    allowanceChargeType3.Amount = amountType2_2;
                    AllowanceChargeType allowanceChargeType4 = allowanceChargeType1;
                    allowanceChargeTypeArray2[0] = allowanceChargeType4;
                    AllowanceChargeType[] allowanceChargeTypeArray3 = allowanceChargeTypeArray1;
                    documentsLineType1.BillingPayment = array1;
                    if (pLstDetalle[index1].Importe_OtrosCargos != new Decimal(0))
                        documentsLineType1.AllowanceCharge = allowanceChargeTypeArray3;
                    TaxAmountType taxAmountType1 = new TaxAmountType();
                    taxAmountType1.currencyID = pCabecera.Codigo_Moneda;
                    taxAmountType1.Value = pLstDetalle[index1].Importe_IGV;
                    TaxAmountType taxAmountType2 = taxAmountType1;
                    TaxSchemeType taxSchemeType1 = new TaxSchemeType();
                    TaxSchemeType taxSchemeType2 = taxSchemeType1;
                    IDType idType11 = new IDType();
                    idType11.Value = "1000";
                    IDType idType12 = idType11;
                    taxSchemeType2.ID = idType12;
                    TaxSchemeType taxSchemeType3 = taxSchemeType1;
                    NameType1 nameType1_5 = new NameType1();
                    nameType1_5.Value = "IGV";
                    NameType1 nameType1_6 = nameType1_5;
                    taxSchemeType3.Name = nameType1_6;
                    TaxSchemeType taxSchemeType4 = taxSchemeType1;
                    TaxTypeCodeType taxTypeCodeType1 = new TaxTypeCodeType();
                    taxTypeCodeType1.Value = "VAT";
                    TaxTypeCodeType taxTypeCodeType2 = taxTypeCodeType1;
                    taxSchemeType4.TaxTypeCode = taxTypeCodeType2;
                    TaxSchemeType taxSchemeType5 = taxSchemeType1;
                    TaxCategoryType taxCategoryType1 = new TaxCategoryType()
                    {
                        TaxScheme = taxSchemeType5
                    };
                    TaxSubtotalType[] taxSubtotalTypeArray1 = new TaxSubtotalType[1]
                    {
            new TaxSubtotalType()
            {
              TaxAmount = taxAmountType2,
              TaxCategory = taxCategoryType1
            }
                    };
                    TaxTotalType[] array2 = new TaxTotalType[1]
                    {
            new TaxTotalType()
            {
              TaxAmount = taxAmountType2,
              TaxSubtotal = taxSubtotalTypeArray1
            }
                    };
                    if (pLstDetalle[index1].Importe_ISC != new Decimal(0))
                    {
                        TaxAmountType taxAmountType3 = new TaxAmountType();
                        taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType3.Value = pLstDetalle[index1].Importe_ISC;
                        TaxAmountType taxAmountType4 = taxAmountType3;
                        TaxSchemeType taxSchemeType6 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType7 = taxSchemeType6;
                        IDType idType9 = new IDType();
                        idType9.Value = "2000";
                        IDType idType10 = idType9;
                        taxSchemeType7.ID = idType10;
                        TaxSchemeType taxSchemeType8 = taxSchemeType6;
                        NameType1 nameType1_7 = new NameType1();
                        nameType1_7.Value = "ISC";
                        NameType1 nameType1_8 = nameType1_7;
                        taxSchemeType8.Name = nameType1_8;
                        TaxSchemeType taxSchemeType9 = taxSchemeType6;
                        TaxTypeCodeType taxTypeCodeType3 = new TaxTypeCodeType();
                        taxTypeCodeType3.Value = "EXC";
                        TaxTypeCodeType taxTypeCodeType4 = taxTypeCodeType3;
                        taxSchemeType9.TaxTypeCode = taxTypeCodeType4;
                        TaxSchemeType taxSchemeType10 = taxSchemeType6;
                        TaxCategoryType taxCategoryType2 = new TaxCategoryType()
                        {
                            TaxScheme = taxSchemeType10
                        };
                        TaxSubtotalType[] taxSubtotalTypeArray2 = new TaxSubtotalType[1]
                        {
              new TaxSubtotalType()
              {
                TaxAmount = taxAmountType4,
                TaxCategory = taxCategoryType2
              }
                        };
                        TaxTotalType taxTotalType = new TaxTotalType()
                        {
                            TaxAmount = taxAmountType4,
                            TaxSubtotal = taxSubtotalTypeArray2
                        };
                        Array.Resize<TaxTotalType>(ref array2, array2.Length + 1);
                        array2[1] = taxTotalType;
                    }
                    if (pLstDetalle[index1].Importe_OtrosTributos != new Decimal(0))
                    {
                        TaxAmountType taxAmountType3 = new TaxAmountType();
                        taxAmountType3.currencyID = pCabecera.Codigo_Moneda;
                        taxAmountType3.Value = pLstDetalle[index1].Importe_OtrosTributos;
                        TaxAmountType taxAmountType4 = taxAmountType3;
                        TaxSchemeType taxSchemeType6 = new TaxSchemeType();
                        TaxSchemeType taxSchemeType7 = taxSchemeType6;
                        IDType idType9 = new IDType();
                        idType9.Value = "9999";
                        IDType idType10 = idType9;
                        taxSchemeType7.ID = idType10;
                        TaxSchemeType taxSchemeType8 = taxSchemeType6;
                        NameType1 nameType1_7 = new NameType1();
                        nameType1_7.Value = "OTR";
                        NameType1 nameType1_8 = nameType1_7;
                        taxSchemeType8.Name = nameType1_8;
                        TaxSchemeType taxSchemeType9 = taxSchemeType6;
                        TaxTypeCodeType taxTypeCodeType3 = new TaxTypeCodeType();
                        taxTypeCodeType3.Value = "OTH";
                        TaxTypeCodeType taxTypeCodeType4 = taxTypeCodeType3;
                        taxSchemeType9.TaxTypeCode = taxTypeCodeType4;
                        TaxSchemeType taxSchemeType10 = taxSchemeType6;
                        TaxCategoryType taxCategoryType2 = new TaxCategoryType()
                        {
                            TaxScheme = taxSchemeType10
                        };
                        TaxSubtotalType[] taxSubtotalTypeArray2 = new TaxSubtotalType[1]
                        {
              new TaxSubtotalType()
              {
                TaxAmount = taxAmountType4,
                TaxCategory = taxCategoryType2
              }
                        };
                        TaxTotalType taxTotalType = new TaxTotalType()
                        {
                            TaxAmount = taxAmountType4,
                            TaxSubtotal = taxSubtotalTypeArray2
                        };
                        Array.Resize<TaxTotalType>(ref array2, array2.Length + 1);
                        array2[2] = taxTotalType;
                    }
                    documentsLineType1.TaxTotal = array2;
                    documentsLineTypeArray[index1] = documentsLineType1;
                }
                this.XMLSummaryDocuments.SummaryDocumentsLine = documentsLineTypeArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraComunicacionBaja(BajaCabecera pCabecera, List<BajaDetalle> pLstDetalle)
        {
            try
            {
                this.XMLSummaryDocuments = new SummaryDocumentsType();
                PartyLegalEntityType partyLegalEntityType1 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType2 = partyLegalEntityType1;
                RegistrationNameType registrationNameType1 = new RegistrationNameType();
                registrationNameType1.Value = pCabecera.RSocial_Emisor;
                RegistrationNameType registrationNameType2 = registrationNameType1;
                partyLegalEntityType2.RegistrationName = registrationNameType2;
                PartyLegalEntityType partyLegalEntityType3 = partyLegalEntityType1;
                PartyNameType partyNameType1 = new PartyNameType();
                PartyNameType partyNameType2 = partyNameType1;
                NameType1 nameType1_1 = new NameType1();
                nameType1_1.Value = pCabecera.NombreCorto_Emisor;
                NameType1 nameType1_2 = nameType1_1;
                partyNameType2.Name = nameType1_2;
                PartyNameType partyNameType3 = partyNameType1;
                PartyType partyType1 = new PartyType()
                {
                    PartyName = new PartyNameType[1] { partyNameType3 },
                    PartyLegalEntity = new PartyLegalEntityType[1]
                  {
            partyLegalEntityType3
                  }
                };
                AdditionalAccountIDType additionalAccountIdType1 = new AdditionalAccountIDType();
                additionalAccountIdType1.Value = pCabecera.TipoDoc_Emisor;
                AdditionalAccountIDType additionalAccountIdType2 = additionalAccountIdType1;
                SupplierPartyType supplierPartyType1 = new SupplierPartyType();
                supplierPartyType1.Party = partyType1;
                SupplierPartyType supplierPartyType2 = supplierPartyType1;
                CustomerAssignedAccountIDType assignedAccountIdType1 = new CustomerAssignedAccountIDType();
                assignedAccountIdType1.Value = pCabecera.NroDoc_Emisor;
                CustomerAssignedAccountIDType assignedAccountIdType2 = assignedAccountIdType1;
                supplierPartyType2.CustomerAssignedAccountID = assignedAccountIdType2;
                supplierPartyType1.AdditionalAccountID = new AdditionalAccountIDType[1]
                {
          additionalAccountIdType2
                };
                this.XMLVoidedDocuments.AccountingSupplierParty = supplierPartyType1;
                VoidedDocumentsType voidedDocumentsType1 = this.XMLVoidedDocuments;
                ReferenceDateType referenceDateType1 = new ReferenceDateType();
                referenceDateType1.Value = pCabecera.Fecha_Baja;
                ReferenceDateType referenceDateType2 = referenceDateType1;
                voidedDocumentsType1.ReferenceDate = referenceDateType2;
                VoidedDocumentsType voidedDocumentsType2 = this.XMLVoidedDocuments;
                IDType idType1 = new IDType();
                idType1.Value = pCabecera.Identificador;
                IDType idType2 = idType1;
                voidedDocumentsType2.ID = idType2;
                VoidedDocumentsType voidedDocumentsType3 = this.XMLVoidedDocuments;
                IssueDateType issueDateType1 = new IssueDateType();
                issueDateType1.Value = pCabecera.Fecha_Emision;
                IssueDateType issueDateType2 = issueDateType1;
                voidedDocumentsType3.IssueDate = issueDateType2;
                PartyIdentificationType identificationType1 = new PartyIdentificationType();
                PartyIdentificationType identificationType2 = identificationType1;
                IDType idType3 = new IDType();
                idType3.Value = pCabecera.NroDoc_Emisor;
                IDType idType4 = idType3;
                identificationType2.ID = idType4;
                PartyIdentificationType identificationType3 = identificationType1;
                PartyNameType partyNameType4 = new PartyNameType();
                PartyNameType partyNameType5 = partyNameType4;
                NameType1 nameType1_3 = new NameType1();
                nameType1_3.Value = pCabecera.RSocial_Emisor;
                NameType1 nameType1_4 = nameType1_3;
                partyNameType5.Name = nameType1_4;
                PartyNameType partyNameType6 = partyNameType4;
                PartyType partyType2 = new PartyType()
                {
                    PartyIdentification = new PartyIdentificationType[1]
                  {
            identificationType3
                  },
                    PartyName = new PartyNameType[1] { partyNameType6 }
                };
                AttachmentType attachmentType1 = new AttachmentType();
                AttachmentType attachmentType2 = attachmentType1;
                ExternalReferenceType externalReferenceType1 = new ExternalReferenceType();
                ExternalReferenceType externalReferenceType2 = externalReferenceType1;
                URIType uriType1 = new URIType();
                uriType1.Value = "#SignatureKG";
                URIType uriType2 = uriType1;
                externalReferenceType2.URI = uriType2;
                ExternalReferenceType externalReferenceType3 = externalReferenceType1;
                attachmentType2.ExternalReference = externalReferenceType3;
                AttachmentType attachmentType3 = attachmentType1;
                SignatureType signatureType1 = new SignatureType();
                SignatureType signatureType2 = signatureType1;
                IDType idType5 = new IDType();
                idType5.Value = pCabecera.NroDoc_Emisor;
                IDType idType6 = idType5;
                signatureType2.ID = idType6;
                signatureType1.SignatoryParty = partyType2;
                signatureType1.DigitalSignatureAttachment = attachmentType3;
                SignatureType signatureType3 = signatureType1;
                UBLExtensionType ublExtensionType = new UBLExtensionType()
                {
                    ExtensionContent = new XmlDocument().CreateElement("dummy")
                };
                this.XMLVoidedDocuments.Signature = new SignatureType[1]
                {
          signatureType3
                };
                this.XMLVoidedDocuments.UBLExtensions = new UBLExtensionType[1]
                {
          ublExtensionType
                };
                VoidedDocumentsType voidedDocumentsType4 = this.XMLVoidedDocuments;
                UBLVersionIDType ublVersionIdType1 = new UBLVersionIDType();
                ublVersionIdType1.Value = "2.0";
                UBLVersionIDType ublVersionIdType2 = ublVersionIdType1;
                voidedDocumentsType4.UBLVersionID = ublVersionIdType2;
                VoidedDocumentsType voidedDocumentsType5 = this.XMLVoidedDocuments;
                CustomizationIDType customizationIdType1 = new CustomizationIDType();
                customizationIdType1.Value = "1.0";
                CustomizationIDType customizationIdType2 = customizationIdType1;
                voidedDocumentsType5.CustomizationID = customizationIdType2;
                VoidedDocumentsLineType[] documentsLineTypeArray = new VoidedDocumentsLineType[pLstDetalle.Count];
                for (int index = 0; index < pLstDetalle.Count; ++index)
                {
                    VoidedDocumentsLineType documentsLineType1 = new VoidedDocumentsLineType();
                    VoidedDocumentsLineType documentsLineType2 = documentsLineType1;
                    LineIDType lineIdType1 = new LineIDType();
                    lineIdType1.Value = (index + 1).ToString();
                    LineIDType lineIdType2 = lineIdType1;
                    documentsLineType2.LineID = lineIdType2;
                    VoidedDocumentsLineType documentsLineType3 = documentsLineType1;
                    DocumentTypeCodeType documentTypeCodeType1 = new DocumentTypeCodeType();
                    documentTypeCodeType1.Value = pLstDetalle[index].Codigo_Documento;
                    DocumentTypeCodeType documentTypeCodeType2 = documentTypeCodeType1;
                    documentsLineType3.DocumentTypeCode = documentTypeCodeType2;
                    documentsLineType1.DocumentSerialID = new identifierFieldType()
                    {
                        Value = pLstDetalle[index].Serie_Documento
                    };
                    documentsLineType1.DocumentNumberID = new identifierFieldType()
                    {
                        Value = pLstDetalle[index].Numero_Documento
                    };
                    documentsLineType1.VoidReasonDescription = new TextType()
                    {
                        Value = pLstDetalle[index].Motivo_Baja
                    };
                    VoidedDocumentsLineType documentsLineType4 = documentsLineType1;
                    documentsLineTypeArray[index] = documentsLineType4;
                }
                this.XMLVoidedDocuments.VoidedDocumentsLine = documentsLineTypeArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraGuiaRemision(GuiaRemisionCabecera pCabecera, List<GuiaRemisionDetalle> pLstDetalle)
        {
            try
            {
                this.XMLDespatchAdvice = new DespatchAdviceType();
                DespatchAdviceType despatchAdviceType1 = this.XMLDespatchAdvice;
                UBLVersionIDType ublVersionIdType1 = new UBLVersionIDType();
                ublVersionIdType1.Value = "2.1";
                UBLVersionIDType ublVersionIdType2 = ublVersionIdType1;
                despatchAdviceType1.UBLVersionID = ublVersionIdType2;
                DespatchAdviceType despatchAdviceType2 = this.XMLDespatchAdvice;
                CustomizationIDType customizationIdType1 = new CustomizationIDType();
                customizationIdType1.Value = "1.0";
                CustomizationIDType customizationIdType2 = customizationIdType1;
                despatchAdviceType2.CustomizationID = customizationIdType2;
                DespatchAdviceType despatchAdviceType3 = this.XMLDespatchAdvice;
                IDType idType1 = new IDType();
                idType1.Value = pCabecera.Serie_Documento + "-" + pCabecera.Numero_Documento;
                IDType idType2 = idType1;
                despatchAdviceType3.ID = idType2;
                DespatchAdviceType despatchAdviceType4 = this.XMLDespatchAdvice;
                IssueDateType issueDateType1 = new IssueDateType();
                issueDateType1.Value = pCabecera.Fecha_Emision;
                IssueDateType issueDateType2 = issueDateType1;
                despatchAdviceType4.IssueDate = issueDateType2;
                DespatchAdviceType despatchAdviceType5 = this.XMLDespatchAdvice;
                IssueTimeType issueTimeType1 = new IssueTimeType();
                issueTimeType1.TimeString = pCabecera.Hora_Emision; //_param1.Fecha_Emision;
                IssueTimeType issueTimeType2 = issueTimeType1;
                despatchAdviceType5.IssueTime = issueTimeType2;
                DespatchAdviceType despatchAdviceType6 = this.XMLDespatchAdvice;
                DespatchAdviceTypeCodeType adviceTypeCodeType1 = new DespatchAdviceTypeCodeType();
                adviceTypeCodeType1.Value = pCabecera.Tipo_Documento;
                DespatchAdviceTypeCodeType adviceTypeCodeType2 = adviceTypeCodeType1;
                despatchAdviceType6.DespatchAdviceTypeCode = adviceTypeCodeType2;
                if (!string.IsNullOrEmpty(pCabecera.Observaciones))
                {
                    DespatchAdviceType despatchAdviceType7 = this.XMLDespatchAdvice;
                    NoteType[] noteTypeArray1 = new NoteType[1];
                    NoteType[] noteTypeArray2 = noteTypeArray1;
                    NoteType noteType1 = new NoteType();
                    noteType1.Value = pCabecera.Observaciones;
                    NoteType noteType2 = noteType1;
                    noteTypeArray2[0] = noteType2;
                    NoteType[] noteTypeArray3 = noteTypeArray1;
                    despatchAdviceType7.Note = noteTypeArray3;
                }
                if (pCabecera.Motivo_Traslado == "08" && !string.IsNullOrEmpty(pCabecera.Tipo_Documento_Rel))
                {
                    DespatchAdviceType despatchAdviceType7 = this.XMLDespatchAdvice;
                    DocumentReferenceType[] documentReferenceTypeArray1 = new DocumentReferenceType[1];
                    DocumentReferenceType[] documentReferenceTypeArray2 = documentReferenceTypeArray1;
                    DocumentReferenceType documentReferenceType1 = new DocumentReferenceType();
                    DocumentReferenceType documentReferenceType2 = documentReferenceType1;
                    IDType idType3 = new IDType();
                    idType3.Value = pCabecera.Serie_Documento_Rel + "-" + pCabecera.Numero_Documento_Rel;
                    IDType idType4 = idType3;
                    documentReferenceType2.ID = idType4;
                    DocumentReferenceType documentReferenceType3 = documentReferenceType1;
                    DocumentTypeCodeType documentTypeCodeType1 = new DocumentTypeCodeType();
                    documentTypeCodeType1.Value = "01";
                    DocumentTypeCodeType documentTypeCodeType2 = documentTypeCodeType1;
                    documentReferenceType3.DocumentTypeCode = documentTypeCodeType2;
                    DocumentReferenceType documentReferenceType4 = documentReferenceType1;
                    documentReferenceTypeArray2[0] = documentReferenceType4;
                    DocumentReferenceType[] documentReferenceTypeArray3 = documentReferenceTypeArray1;
                    despatchAdviceType7.AdditionalDocumentReference = documentReferenceTypeArray3;
                }
                PartyType partyType1 = new PartyType();
                PartyType partyType2 = partyType1;
                PartyIdentificationType[] identificationTypeArray1 = new PartyIdentificationType[1];
                PartyIdentificationType[] identificationTypeArray2 = identificationTypeArray1;
                PartyIdentificationType identificationType1 = new PartyIdentificationType();
                PartyIdentificationType identificationType2 = identificationType1;
                IDType idType5 = new IDType();
                idType5.Value = pCabecera.NroDoc_Emisor;
                IDType idType6 = idType5;
                identificationType2.ID = idType6;
                PartyIdentificationType identificationType3 = identificationType1;
                identificationTypeArray2[0] = identificationType3;
                PartyIdentificationType[] identificationTypeArray3 = identificationTypeArray1;
                partyType2.PartyIdentification = identificationTypeArray3;
                PartyType partyType3 = partyType1;
                PartyNameType[] partyNameTypeArray1 = new PartyNameType[1];
                PartyNameType[] partyNameTypeArray2 = partyNameTypeArray1;
                PartyNameType partyNameType1 = new PartyNameType();
                PartyNameType partyNameType2 = partyNameType1;
                NameType1 nameType1_1 = new NameType1();
                nameType1_1.Value = pCabecera.RSocial_Emisor;
                NameType1 nameType1_2 = nameType1_1;
                partyNameType2.Name = nameType1_2;
                PartyNameType partyNameType3 = partyNameType1;
                partyNameTypeArray2[0] = partyNameType3;
                PartyNameType[] partyNameTypeArray3 = partyNameTypeArray1;
                partyType3.PartyName = partyNameTypeArray3;
                PartyType partyType4 = partyType1;
                AttachmentType attachmentType1 = new AttachmentType();
                AttachmentType attachmentType2 = attachmentType1;
                ExternalReferenceType externalReferenceType1 = new ExternalReferenceType();
                ExternalReferenceType externalReferenceType2 = externalReferenceType1;
                URIType uriType1 = new URIType();
                uriType1.Value = "#SignatureKG";
                URIType uriType2 = uriType1;
                externalReferenceType2.URI = uriType2;
                ExternalReferenceType externalReferenceType3 = externalReferenceType1;
                attachmentType2.ExternalReference = externalReferenceType3;
                AttachmentType attachmentType3 = attachmentType1;
                SignatureType signatureType1 = new SignatureType();
                SignatureType signatureType2 = signatureType1;
                IDType idType7 = new IDType();
                idType7.Value = pCabecera.NroDoc_Emisor;
                IDType idType8 = idType7;
                signatureType2.ID = idType8;
                signatureType1.SignatoryParty = partyType4;
                signatureType1.DigitalSignatureAttachment = attachmentType3;
                this.XMLDespatchAdvice.UBLExtensions = new UBLExtensionType[1]
                {
                    new UBLExtensionType()
                    {
                        ExtensionContent = new XmlDocument().CreateElement("dummy")
                    }
                };
                SupplierPartyType supplierPartyType1 = new SupplierPartyType();
                SupplierPartyType supplierPartyType2 = supplierPartyType1;
                CustomerAssignedAccountIDType assignedAccountIdType1 = new CustomerAssignedAccountIDType();
                assignedAccountIdType1.schemeID = pCabecera.TipoDoc_Emisor;
                assignedAccountIdType1.Value = pCabecera.NroDoc_Emisor;
                CustomerAssignedAccountIDType assignedAccountIdType2 = assignedAccountIdType1;
                supplierPartyType2.CustomerAssignedAccountID = assignedAccountIdType2;
                SupplierPartyType supplierPartyType3 = supplierPartyType1;
                PartyType partyType5 = new PartyType();
                PartyType partyType6 = partyType5;
                PartyLegalEntityType[] partyLegalEntityTypeArray1 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray2 = partyLegalEntityTypeArray1;
                PartyLegalEntityType partyLegalEntityType1 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType2 = partyLegalEntityType1;
                RegistrationNameType registrationNameType1 = new RegistrationNameType();
                registrationNameType1.Value = pCabecera.RSocial_Emisor;
                RegistrationNameType registrationNameType2 = registrationNameType1;
                partyLegalEntityType2.RegistrationName = registrationNameType2;
                PartyLegalEntityType partyLegalEntityType3 = partyLegalEntityType1;
                partyLegalEntityTypeArray2[0] = partyLegalEntityType3;
                PartyLegalEntityType[] partyLegalEntityTypeArray3 = partyLegalEntityTypeArray1;
                partyType6.PartyLegalEntity = partyLegalEntityTypeArray3;
                PartyType partyType7 = partyType5;
                supplierPartyType3.Party = partyType7;
                this.XMLDespatchAdvice.DespatchSupplierParty = supplierPartyType1;
                CustomerPartyType customerPartyType1 = new CustomerPartyType();
                CustomerPartyType customerPartyType2 = customerPartyType1;
                CustomerAssignedAccountIDType assignedAccountIdType3 = new CustomerAssignedAccountIDType();
                assignedAccountIdType3.schemeID = pCabecera.TipoDoc_Destino;
                assignedAccountIdType3.Value = pCabecera.NroDoc_Destino;
                CustomerAssignedAccountIDType assignedAccountIdType4 = assignedAccountIdType3;
                customerPartyType2.CustomerAssignedAccountID = assignedAccountIdType4;
                CustomerPartyType customerPartyType3 = customerPartyType1;
                PartyType partyType8 = new PartyType();
                PartyType partyType9 = partyType8;
                PartyLegalEntityType[] partyLegalEntityTypeArray4 = new PartyLegalEntityType[1];
                PartyLegalEntityType[] partyLegalEntityTypeArray5 = partyLegalEntityTypeArray4;
                PartyLegalEntityType partyLegalEntityType4 = new PartyLegalEntityType();
                PartyLegalEntityType partyLegalEntityType5 = partyLegalEntityType4;
                RegistrationNameType registrationNameType3 = new RegistrationNameType();
                registrationNameType3.Value = pCabecera.RSocial_Destino;
                RegistrationNameType registrationNameType4 = registrationNameType3;
                partyLegalEntityType5.RegistrationName = registrationNameType4;
                PartyLegalEntityType partyLegalEntityType6 = partyLegalEntityType4;
                partyLegalEntityTypeArray5[0] = partyLegalEntityType6;
                PartyLegalEntityType[] partyLegalEntityTypeArray6 = partyLegalEntityTypeArray4;
                partyType9.PartyLegalEntity = partyLegalEntityTypeArray6;
                PartyType partyType10 = partyType8;
                customerPartyType3.Party = partyType10;
                this.XMLDespatchAdvice.DeliveryCustomerParty = customerPartyType1;
                ShipmentType shipmentType1 = new ShipmentType();
                ShipmentStageType[] shipmentStageTypeArray = new ShipmentStageType[1];
                ShipmentType shipmentType2 = shipmentType1;
                IDType idType9 = new IDType();
                idType9.Value = "1";
                IDType idType10 = idType9;
                shipmentType2.ID = idType10;
                ShipmentType shipmentType3 = shipmentType1;
                HandlingCodeType handlingCodeType1 = new HandlingCodeType();
                handlingCodeType1.Value = pCabecera.Motivo_Traslado;
                HandlingCodeType handlingCodeType2 = handlingCodeType1;
                shipmentType3.HandlingCode = handlingCodeType2;
                ShipmentType shipmentType4 = shipmentType1;
                GrossWeightMeasureType weightMeasureType1 = new GrossWeightMeasureType();
                weightMeasureType1.unitCode = pCabecera.Unidad_Medida_Peso_Bruto;
                weightMeasureType1.Value = pCabecera.Peso_Bruto;
                GrossWeightMeasureType weightMeasureType2 = weightMeasureType1;
                shipmentType4.GrossWeightMeasure = weightMeasureType2;
                ShipmentType shipmentType5 = shipmentType1;
                TotalTransportHandlingUnitQuantityType unitQuantityType1 = new TotalTransportHandlingUnitQuantityType();
                unitQuantityType1.Value = pCabecera.Cantidad_Bultos;
                TotalTransportHandlingUnitQuantityType unitQuantityType2 = unitQuantityType1;
                shipmentType5.TotalTransportHandlingUnitQuantity = unitQuantityType2;
                string motivoTraslado = pCabecera.Motivo_Traslado;
                switch (motivoTraslado)
                {
                    case "01":
                        ShipmentType shipmentType9 = shipmentType1;
                        InformationType[] informationTypeArray1 = new InformationType[1];
                        InformationType[] informationTypeArray2 = informationTypeArray1;
                        InformationType informationType1 = new InformationType();
                        informationType1.Value = "VENTA";
                        InformationType informationType2 = informationType1;
                        informationTypeArray2[0] = informationType2;
                        InformationType[] informationTypeArray3 = informationTypeArray1;
                        shipmentType9.Information = informationTypeArray3;
                        break;

                    case "02":
                        ShipmentType shipmentType10 = shipmentType1;
                        InformationType[] informationTypeArray4 = new InformationType[1];
                        InformationType[] informationTypeArray5 = informationTypeArray4;
                        InformationType informationType3 = new InformationType();
                        informationType3.Value = "COMPRA";
                        InformationType informationType4 = informationType3;
                        informationTypeArray5[0] = informationType4;
                        InformationType[] informationTypeArray6 = informationTypeArray4;
                        shipmentType10.Information = informationTypeArray6;
                        break;

                    case "04":
                        ShipmentType shipmentType11 = shipmentType1;
                        InformationType[] informationTypeArray7 = new InformationType[1];
                        InformationType[] informationTypeArray8 = informationTypeArray7;
                        InformationType informationType5 = new InformationType();
                        informationType5.Value = "TRASLADOS ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA";
                        InformationType informationType6 = informationType5;
                        informationTypeArray8[0] = informationType6;
                        InformationType[] informationTypeArray9 = informationTypeArray7;
                        shipmentType11.Information = informationTypeArray9;
                        break;

                    case "08":
                        ShipmentType shipmentType12 = shipmentType1;
                        InformationType[] informationTypeArray10 = new InformationType[1];
                        InformationType[] informationTypeArray11 = informationTypeArray10;
                        InformationType informationType7 = new InformationType();
                        informationType7.Value = "IMPORTACION";
                        InformationType informationType8 = informationType7;
                        informationTypeArray11[0] = informationType8;
                        InformationType[] informationTypeArray12 = informationTypeArray10;
                        shipmentType12.Information = informationTypeArray12;
                        break;

                    case "09":
                        ShipmentType shipmentType13 = shipmentType1;
                        InformationType[] informationTypeArray13 = new InformationType[1];
                        InformationType[] informationTypeArray14 = informationTypeArray13;
                        InformationType informationType9 = new InformationType();
                        informationType9.Value = "EXPORTACION";
                        InformationType informationType10 = informationType9;
                        informationTypeArray14[0] = informationType10;
                        InformationType[] informationTypeArray15 = informationTypeArray13;
                        shipmentType13.Information = informationTypeArray15;
                        break;

                    case "13":
                        ShipmentType shipmentType14 = shipmentType1;
                        InformationType[] informationTypeArray16 = new InformationType[1];
                        InformationType[] informationTypeArray17 = informationTypeArray16;
                        InformationType informationType11 = new InformationType();
                        informationType11.Value = "OTROS";
                        InformationType informationType12 = informationType11;
                        informationTypeArray17[0] = informationType12;
                        InformationType[] informationTypeArray18 = informationTypeArray16;
                        shipmentType14.Information = informationTypeArray18;
                        break;

                    case "14":
                        ShipmentType shipmentType15 = shipmentType1;
                        InformationType[] informationTypeArray19 = new InformationType[1];
                        InformationType[] informationTypeArray20 = informationTypeArray19;
                        InformationType informationType13 = new InformationType();
                        informationType13.Value = "VENTA SUJETA A CONFIRMACION DEL COMPRADOR";
                        InformationType informationType14 = informationType13;
                        informationTypeArray20[0] = informationType14;
                        InformationType[] informationTypeArray21 = informationTypeArray19;
                        shipmentType15.Information = informationTypeArray21;
                        break;

                    case "18":
                        ShipmentType shipmentType16 = shipmentType1;
                        InformationType[] informationTypeArray22 = new InformationType[1];
                        InformationType[] informationTypeArray23 = informationTypeArray22;
                        InformationType informationType15 = new InformationType();
                        informationType15.Value = "TRALADO EMISOR ITINERANTE CP";
                        InformationType informationType16 = informationType15;
                        informationTypeArray23[0] = informationType16;
                        InformationType[] informationTypeArray24 = informationTypeArray22;
                        shipmentType16.Information = informationTypeArray24;
                        break;

                    case "19":
                        ShipmentType shipmentType17 = shipmentType1;
                        InformationType[] informationTypeArray25 = new InformationType[1];
                        InformationType[] informationTypeArray26 = informationTypeArray25;
                        InformationType informationType17 = new InformationType();
                        informationType17.Value = "TRASLADO A ZONA PRIMARIA";
                        InformationType informationType18 = informationType17;
                        informationTypeArray26[0] = informationType18;
                        InformationType[] informationTypeArray27 = informationTypeArray25;
                        shipmentType17.Information = informationTypeArray27;
                        break;
                }
                ShipmentStageType shipmentStageType1 = new ShipmentStageType();
                ShipmentStageType shipmentStageType2 = shipmentStageType1;
                TransportModeCodeType transportModeCodeType1 = new TransportModeCodeType();
                transportModeCodeType1.Value = pCabecera.Modalidad_Transporte;
                TransportModeCodeType transportModeCodeType2 = transportModeCodeType1;
                shipmentStageType2.TransportModeCode = transportModeCodeType2;
                ShipmentStageType shipmentStageType3 = shipmentStageType1;
                PeriodType periodType1 = new PeriodType();
                PeriodType periodType2 = periodType1;
                StartDateType startDateType1 = new StartDateType();
                startDateType1.Value = pCabecera.Fecha_Inicio_Traslado;
                StartDateType startDateType2 = startDateType1;
                periodType2.StartDate = startDateType2;
                PeriodType periodType3 = periodType1;
                shipmentStageType3.TransitPeriod = periodType3;
                if (pCabecera.Modalidad_Transporte == "01")
                {
                    PartyType partyType11 = new PartyType();
                    PartyType partyType12 = partyType11;
                    PartyIdentificationType[] identificationTypeArray4 = new PartyIdentificationType[1];
                    PartyIdentificationType[] identificationTypeArray5 = identificationTypeArray4;
                    PartyIdentificationType identificationType4 = new PartyIdentificationType();
                    PartyIdentificationType identificationType5 = identificationType4;
                    IDType idType3 = new IDType();
                    idType3.schemeID = pCabecera.TipoDoc_Transportista;
                    idType3.Value = pCabecera.NroDoc_Transportista;
                    IDType idType4 = idType3;
                    identificationType5.ID = idType4;
                    PartyIdentificationType identificationType6 = identificationType4;
                    identificationTypeArray5[0] = identificationType6;
                    PartyIdentificationType[] identificationTypeArray6 = identificationTypeArray4;
                    partyType12.PartyIdentification = identificationTypeArray6;
                    PartyType partyType13 = partyType11;
                    PartyNameType[] partyNameTypeArray4 = new PartyNameType[1];
                    PartyNameType[] partyNameTypeArray5 = partyNameTypeArray4;
                    PartyNameType partyNameType4 = new PartyNameType();
                    PartyNameType partyNameType5 = partyNameType4;
                    NameType1 nameType1_3 = new NameType1();
                    nameType1_3.Value = pCabecera.RSocial_Transportista;
                    NameType1 nameType1_4 = nameType1_3;
                    partyNameType5.Name = nameType1_4;
                    PartyNameType partyNameType6 = partyNameType4;
                    partyNameTypeArray5[0] = partyNameType6;
                    PartyNameType[] partyNameTypeArray6 = partyNameTypeArray4;
                    partyType13.PartyName = partyNameTypeArray6;
                    PartyType partyType14 = partyType11;
                    shipmentStageType1.CarrierParty = new PartyType[1]
                    {
                        partyType14
                    };
                }
                else if (pCabecera.Modalidad_Transporte == "02")
                {
                    ShipmentStageType shipmentStageType4 = shipmentStageType1;
                    TransportMeansType transportMeansType1 = new TransportMeansType();
                    TransportMeansType transportMeansType2 = transportMeansType1;
                    RoadTransportType roadTransportType1 = new RoadTransportType();
                    RoadTransportType roadTransportType2 = roadTransportType1;
                    LicensePlateIDType licensePlateIdType1 = new LicensePlateIDType();
                    licensePlateIdType1.Value = pCabecera.Placa_Vehiculo;
                    LicensePlateIDType licensePlateIdType2 = licensePlateIdType1;
                    roadTransportType2.LicensePlateID = licensePlateIdType2;
                    RoadTransportType roadTransportType3 = roadTransportType1;
                    transportMeansType2.RoadTransport = roadTransportType3;
                    TransportMeansType transportMeansType3 = transportMeansType1;
                    shipmentStageType4.TransportMeans = transportMeansType3;
                    ShipmentStageType shipmentStageType5 = shipmentStageType1;
                    PersonType[] personTypeArray1 = new PersonType[1];
                    PersonType[] personTypeArray2 = personTypeArray1;
                    PersonType personType1 = new PersonType();
                    PersonType personType2 = personType1;
                    IDType idType3 = new IDType();
                    idType3.schemeID = pCabecera.TipoDoc_Conductor;
                    idType3.Value = pCabecera.NroDoc_Conductor;
                    IDType idType4 = idType3;
                    personType2.ID = idType4;
                    PersonType personType3 = personType1;
                    personTypeArray2[0] = personType3;
                    PersonType[] personTypeArray3 = personTypeArray1;
                    shipmentStageType5.DriverPerson = personTypeArray3;
                }
                shipmentStageTypeArray[0] = shipmentStageType1;
                shipmentType1.ShipmentStage = shipmentStageTypeArray;
                ShipmentType shipmentType6 = shipmentType1;
                AddressType addressType1 = new AddressType();
                AddressType addressType2 = addressType1;
                IDType idType11 = new IDType();
                idType11.Value = pCabecera.Ubigeo_Partida;
                IDType idType12 = idType11;
                addressType2.ID = idType12;
                AddressType addressType3 = addressType1;
                StreetNameType streetNameType1 = new StreetNameType();
                streetNameType1.Value = pCabecera.Direccion_Partida;
                StreetNameType streetNameType2 = streetNameType1;
                addressType3.StreetName = streetNameType2;
                AddressType addressType4 = addressType1;
                shipmentType6.OriginAddress = addressType4;
                ShipmentType shipmentType7 = shipmentType1;
                DeliveryType deliveryType1 = new DeliveryType();
                DeliveryType deliveryType2 = deliveryType1;
                AddressType addressType5 = new AddressType();
                AddressType addressType6 = addressType5;
                IDType idType13 = new IDType();
                idType13.Value = pCabecera.Ubigeo_Llegada;
                IDType idType14 = idType13;
                addressType6.ID = idType14;
                AddressType addressType7 = addressType5;
                StreetNameType streetNameType3 = new StreetNameType();
                streetNameType3.Value = pCabecera.Direccion_Llegada;
                StreetNameType streetNameType4 = streetNameType3;
                addressType7.StreetName = streetNameType4;
                AddressType addressType8 = addressType5;
                deliveryType2.DeliveryAddress = addressType8;
                DeliveryType deliveryType3 = deliveryType1;
                shipmentType7.Delivery = deliveryType3;
                if (pCabecera.Motivo_Traslado == "08")
                {
                    if (!string.IsNullOrEmpty(pCabecera.Numero_Contenedor))
                    {
                        TransportHandlingUnitType[] handlingUnitTypeArray1 = new TransportHandlingUnitType[1];
                        TransportHandlingUnitType[] handlingUnitTypeArray2 = handlingUnitTypeArray1;
                        TransportHandlingUnitType handlingUnitType1 = new TransportHandlingUnitType();
                        TransportHandlingUnitType handlingUnitType2 = handlingUnitType1;
                        TransportEquipmentType[] transportEquipmentTypeArray1 = new TransportEquipmentType[1];
                        TransportEquipmentType[] transportEquipmentTypeArray2 = transportEquipmentTypeArray1;
                        TransportEquipmentType transportEquipmentType1 = new TransportEquipmentType();
                        TransportEquipmentType transportEquipmentType2 = transportEquipmentType1;
                        IDType idType3 = new IDType();
                        idType3.Value = pCabecera.Numero_Contenedor;
                        IDType idType4 = idType3;
                        transportEquipmentType2.ID = idType4;
                        TransportEquipmentType transportEquipmentType3 = transportEquipmentType1;
                        transportEquipmentTypeArray2[0] = transportEquipmentType3;
                        TransportEquipmentType[] transportEquipmentTypeArray3 = transportEquipmentTypeArray1;
                        handlingUnitType2.TransportEquipment = transportEquipmentTypeArray3;
                        TransportHandlingUnitType handlingUnitType3 = handlingUnitType1;
                        handlingUnitTypeArray2[0] = handlingUnitType3;
                        TransportHandlingUnitType[] handlingUnitTypeArray3 = handlingUnitTypeArray1;
                        shipmentType1.TransportHandlingUnit = handlingUnitTypeArray3;
                    }
                    if (!string.IsNullOrEmpty(pCabecera.Codigo_Puerto))
                    {
                        ShipmentType shipmentType8 = shipmentType1;
                        LocationType1 locationType1_1 = new LocationType1();
                        LocationType1 locationType1_2 = locationType1_1;
                        IDType idType3 = new IDType();
                        idType3.Value = pCabecera.Codigo_Puerto;
                        IDType idType4 = idType3;
                        locationType1_2.ID = idType4;
                        LocationType1 locationType1_3 = locationType1_1;
                        shipmentType8.FirstArrivalPortLocation = locationType1_3;
                    }
                    this.XMLDespatchAdvice.Shipment = shipmentType1;
                }
                else
                    this.XMLDespatchAdvice.Shipment = shipmentType1;
                int count = pLstDetalle.Count;
                DespatchLineType[] despatchLineTypeArray = new DespatchLineType[count];
                for (int index = 0; index < count; ++index)
                {
                    DespatchLineType despatchLineType1 = new DespatchLineType();
                    DespatchLineType despatchLineType2 = despatchLineType1;
                    IDType idType3 = new IDType();
                    idType3.Value = pLstDetalle[index].NroItem;
                    IDType idType4 = idType3;
                    despatchLineType2.ID = idType4;
                    DespatchLineType despatchLineType3 = despatchLineType1;
                    OrderLineReferenceType[] lineReferenceTypeArray1 = new OrderLineReferenceType[1];
                    OrderLineReferenceType[] lineReferenceTypeArray2 = lineReferenceTypeArray1;
                    OrderLineReferenceType lineReferenceType1 = new OrderLineReferenceType();
                    OrderLineReferenceType lineReferenceType2 = lineReferenceType1;
                    LineIDType lineIdType1 = new LineIDType();
                    lineIdType1.Value = pLstDetalle[index].NroItem;
                    LineIDType lineIdType2 = lineIdType1;
                    lineReferenceType2.LineID = lineIdType2;
                    OrderLineReferenceType lineReferenceType3 = lineReferenceType1;
                    lineReferenceTypeArray2[0] = lineReferenceType3;
                    OrderLineReferenceType[] lineReferenceTypeArray3 = lineReferenceTypeArray1;
                    despatchLineType3.OrderLineReference = lineReferenceTypeArray3;
                    DespatchLineType despatchLineType4 = despatchLineType1;
                    DeliveredQuantityType deliveredQuantityType1 = new DeliveredQuantityType();
                    deliveredQuantityType1.unitCode = pLstDetalle[index].Codigo_Unidad;
                    deliveredQuantityType1.Value = Math.Round(pLstDetalle[index].Cantidad, 0);
                    DeliveredQuantityType deliveredQuantityType2 = deliveredQuantityType1;
                    despatchLineType4.DeliveredQuantity = deliveredQuantityType2;
                    DespatchLineType despatchLineType5 = despatchLineType1;
                    ItemType itemType1 = new ItemType();
                    ItemType itemType2 = itemType1;
                    NameType1 nameType1_3 = new NameType1();
                    nameType1_3.Value = pLstDetalle[index].Descripcion_Articulo;
                    NameType1 nameType1_4 = nameType1_3;
                    itemType2.Name = nameType1_4;
                    ItemType itemType3 = itemType1;
                    ItemIdentificationType identificationType4 = new ItemIdentificationType();
                    ItemIdentificationType identificationType5 = identificationType4;
                    IDType idType15 = new IDType();
                    idType15.Value = pLstDetalle[index].Codigo_Articulo;
                    IDType idType16 = idType15;
                    identificationType5.ID = idType16;
                    ItemIdentificationType identificationType6 = identificationType4;
                    itemType3.SellersItemIdentification = identificationType6;
                    ItemType itemType4 = itemType1;
                    despatchLineType5.Item = itemType4;
                    despatchLineTypeArray[index] = despatchLineType1;
                }
                this.XMLDespatchAdvice.DespatchLine = despatchLineTypeArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarFirma(string pRutaXML, int pTipo)
        {
            try
            {
                XmlDocument document = new XmlDocument();

                document.PreserveWhitespace = true;

                using (StreamReader streamReader = new StreamReader((Stream)System.IO.File.Open(pRutaXML, FileMode.Open), Encoding.GetEncoding("ISO-8859-1")))
                    document.Load((TextReader)streamReader);

                XmlNode xmlNode = document.GetElementsByTagName("ExtensionContent", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2").Item(pTipo);
                xmlNode.RemoveAll();

                if (!System.IO.File.Exists(this.oCertificado.Ruta))
                    throw new Exception("El certificado digital no se ubica en la siguiente ruta: " + this.oCertificado.Ruta);

                X509Certificate2 x509Certificate2 = new X509Certificate2(this.oCertificado.Ruta, this.oCertificado.Contrasena);
                SignedXml signedXml = new SignedXml(document);
                signedXml.SigningKey = x509Certificate2.PrivateKey;
                System.Security.Cryptography.Xml.Signature signature = signedXml.Signature;
                XmlDsigEnvelopedSignatureTransform signatureTransform = new XmlDsigEnvelopedSignatureTransform();
                Reference reference = new Reference("");
                reference.AddTransform((Transform)signatureTransform);
                signature.SignedInfo.AddReference(reference);
                KeyInfo keyInfo = new KeyInfo();
                KeyInfoX509Data keyInfoX509Data = new KeyInfoX509Data((X509Certificate)x509Certificate2);
                keyInfoX509Data.AddSubjectName(x509Certificate2.Subject);
                keyInfo.AddClause((KeyInfoClause)keyInfoX509Data);
                signature.KeyInfo = keyInfo;
                signature.Id = "SignatureSP";
                signedXml.ComputeSignature();
                xmlNode.AppendChild((XmlNode)signedXml.GetXml());

                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Encoding = Encoding.GetEncoding("ISO-8859-1")
                };

                using (XmlWriter w = XmlWriter.Create(pRutaXML, settings))
                    document.WriteTo(w);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ObtenerDigestValue(string pTipoDocumento, string pRutaXML)
        {
            string str1 = string.Empty;
            string str2 = string.Empty;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(pRutaXML);
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
                nsmgr.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                nsmgr.AddNamespace("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1");
                nsmgr.AddNamespace("ccts", "urn:un:unece:uncefact:documentation:2");
                nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                nsmgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                nsmgr.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                nsmgr.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                nsmgr.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                nsmgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
                if (pTipoDocumento == "01" || pTipoDocumento == "03")
                {
                    nsmgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
                    str1 = "Invoice";
                }
                else if (pTipoDocumento == "07")
                {
                    nsmgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2");
                    str1 = "CreditNote";
                }
                else if (pTipoDocumento == "08")
                {
                    nsmgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2");
                    str1 = "DebitNote";
                }
                else if (pTipoDocumento == "09")
                {
                    nsmgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:DespatchAdvice-2");
                    str1 = "DespatchAdvice";
                }
                XmlNode node = xmlDocument.SelectSingleNode("/tns:" + str1 + "/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature/ds:SignedInfo/ds:Reference", nsmgr);
                if (node != null)
                {
                    XmlNodeReader xmlNodeReader = new XmlNodeReader(node);
                    while (xmlNodeReader.Read())
                    {
                        if (xmlNodeReader.Name.Equals("DigestValue"))
                            str2 = xmlNodeReader.ReadString();
                    }
                }
            }
            catch (Exception ex)
            {
                str2 = string.Empty;
            }
            return str2;
        }

        private string ObtenerSignatureValue(string pTipoDocumento, string pRutaXML)
        {
            string str1 = string.Empty;
            string str2 = string.Empty;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(pRutaXML);
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
                nsmgr.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                nsmgr.AddNamespace("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1");
                nsmgr.AddNamespace("ccts", "urn:un:unece:uncefact:documentation:2");
                nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                nsmgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                nsmgr.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                nsmgr.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                nsmgr.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                nsmgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
                if (pTipoDocumento == "01" || pTipoDocumento == "03")
                {
                    nsmgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
                    str1 = "Invoice";
                }
                else if (pTipoDocumento == "07")
                {
                    nsmgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2");
                    str1 = "CreditNote";
                }
                else if (pTipoDocumento == "08")
                {
                    nsmgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2");
                    str1 = "DebitNote";
                }
                else if (pTipoDocumento == "09")
                {
                    nsmgr.AddNamespace("tns", "urn:oasis:names:specification:ubl:schema:xsd:DespatchAdvice-2");
                    str1 = "DespatchAdvice";
                }
                XmlNode node = xmlDocument.SelectSingleNode("/tns:" + str1 + "/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature", nsmgr);
                if (node != null)
                {
                    XmlNodeReader xmlNodeReader = new XmlNodeReader(node);
                    while (xmlNodeReader.Read())
                    {
                        if (xmlNodeReader.Name.Equals("SignatureValue"))
                            str2 = xmlNodeReader.ReadString();
                    }
                }
            }
            catch (Exception ex)
            {
                str2 = string.Empty;
            }
            return str2;
        }

        public RespuestaSunat ValidarComprobante(string pCodigoDocumento, string pRutaXML, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();

            string str1 = string.Empty;
            string str2 = string.Empty;
            byte[] bytes = (byte[])null;

            string URL = string.Empty;
            if (bOSE)
                URL = this.URL_SUNAT_OSE;
            else
                URL = this.URL_SUNAT_FE;

            try
            {
                string pRutaXML1 = Path.GetDirectoryName(pRutaXML) + (object)Path.DirectorySeparatorChar;
                string fileName1 = Path.GetFileName(pRutaXML);
                string str3 = fileName1;
                string fileName2 = fileName1.Replace(".xml", ".zip");
                string pRutaXML2 = pRutaXML1 + str3;

                str1 = pRutaXML1 + fileName2;

                string str4 = "R-" + str3;
                string str5 = "R-" + fileName2;

                str2 = pRutaXML1 + str5;

                if (System.IO.File.Exists(str1))
                    System.IO.File.Delete(str1);

                this.Comprimir(str1, pRutaXML2);
                byte[] contentFile = System.IO.File.ReadAllBytes(str1);

                GMT_Sfe.WS_SUNAT_FE.billServiceClient billServiceClient = new GMT_Sfe.WS_SUNAT_FE.billServiceClient((Binding)this.binding, new EndpointAddress(URL));
                billServiceClient.ClientCredentials.UserName.UserName = this.oCuentaSunat.Usuario;
                billServiceClient.ClientCredentials.UserName.Password = this.oCuentaSunat.Contrasena;
                BindingElementCollection bindingElements = billServiceClient.Endpoint.Binding.CreateBindingElements();
                bindingElements.Find<SecurityBindingElement>().IncludeTimestamp = false;
                billServiceClient.Endpoint.Binding = (Binding)new CustomBinding((IEnumerable<BindingElement>)bindingElements);

                try
                {
                    bytes = billServiceClient.sendBill(fileName2, contentFile);
                }
                catch (FaultException ex)
                {
                    string lst_faultcode = "";
                    string lst_faultstring = "";

                    if (bOSE)
                    {
                        MessageFault msgFault = ex.CreateMessageFault();
                        XmlElement elm = msgFault.GetDetail<XmlElement>();

                        lst_faultcode = ex.Message;
                        lst_faultstring = "FaultException Validación: " + elm.ChildNodes[0].Value;
                    }
                    else
                    {
                        lst_faultcode = Regex.Replace(ex.Code.Name.ToUpper(), "[^\\d]", "");
                        lst_faultstring = "FaultException Validación: " + ex.Message;
                    }

                    respuestaSunat.Codigo = lst_faultcode;
                    respuestaSunat.Mensaje = lst_faultstring;
                    respuestaSunat.RutaXML = pRutaXML;
                }
                catch (Exception ex)
                {
                    if (!this.bEsValidacion)
                    {
                        respuestaSunat.Codigo = "0";
                        respuestaSunat.Mensaje = "El archivo XML ha sido generado, pero aún no ha sido válidado con la SUNAT debido a que no hay conexión con la URL: " + this.URL_SUNAT_FE;
                        respuestaSunat.DigestValue = (string)null;
                        respuestaSunat.RutaXML = pRutaXML;
                        respuestaSunat.Estado = Estado.Generado;
                    }
                    else
                    {
                        respuestaSunat.Codigo = "-1";
                        respuestaSunat.Mensaje = "No se ha sido válidado con la SUNAT debido a que no hay conexión con la URL: " + this.URL_SUNAT_FE;
                        respuestaSunat.DigestValue = (string)null;
                        respuestaSunat.RutaXML = (string)null;
                        respuestaSunat.Estado = Estado.Error;
                    }
                    return respuestaSunat;
                }
                if (bytes != null)
                {
                    System.IO.File.WriteAllBytes(str2, bytes);

                    if (System.IO.File.Exists(pRutaXML1 + str4))
                        System.IO.File.Delete(pRutaXML1 + str4);

                    this.Descomprimir(str2, pRutaXML1);

                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(pRutaXML1 + str4);

                    XmlNodeList childNodes = xmlDocument.GetElementsByTagName("DocumentResponse", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2").Item(0).FirstChild.ChildNodes;
                    respuestaSunat.Codigo = childNodes[1].InnerText;
                    respuestaSunat.Mensaje = childNodes[2].InnerText;
                    respuestaSunat.RutaXML = pRutaXML;
                    respuestaSunat.RutaCDR = pRutaXML1 + str4;
                }

                if (respuestaSunat.Codigo != "")
                {
                    if (Convert.ToInt32(respuestaSunat.Codigo) == 0)
                        respuestaSunat.Estado = Estado.Aceptado;
                    else if (Convert.ToInt32(respuestaSunat.Codigo) >= 1 && Convert.ToInt32(respuestaSunat.Codigo) <= 1999)
                        respuestaSunat.Estado = Estado.Invalido;
                    else if (Convert.ToInt32(respuestaSunat.Codigo) >= 2000 && Convert.ToInt32(respuestaSunat.Codigo) <= 3999)
                        respuestaSunat.Estado = Estado.Rechazado;
                }
                else
                {
                    respuestaSunat.Codigo = "-1";
                    respuestaSunat.Estado = Estado.Error;
                }

                if (this.bEsValidacion)
                {
                    if (Estado.Generado == respuestaSunat.Estado || Estado.Aceptado == respuestaSunat.Estado || Estado.Rechazado == respuestaSunat.Estado)
                    {
                        respuestaSunat.DigestValue = this.ObtenerDigestValue(pCodigoDocumento, respuestaSunat.RutaXML);
                        respuestaSunat.SignatureValue = this.ObtenerSignatureValue(pCodigoDocumento, respuestaSunat.RutaXML);
                    }
                }
            }
            catch (Exception ex)
            {
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = "Exception Validación: " + ex.Message;
                respuestaSunat.Estado = Estado.Error;
            }
            finally
            {
                if (System.IO.File.Exists(str1))
                    System.IO.File.Delete(str1);

                if (System.IO.File.Exists(str2))
                    System.IO.File.Delete(str2);
            }

            return respuestaSunat;
        }

        public RespuestaSunat ValidarCDRComprobante(string pEmpresa, string pTipoDoc, string pSerie, string pNumero, string pRutaXML, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();

            string str1 = string.Empty;
            string path = string.Empty;
            string str2 = string.Empty;

            string URL = string.Empty;
            if (bOSE)
                URL = this.URL_SUNAT_OSE;
            else
                URL = this.URL_SUNAT_CO;

            try
            {
                string pRutaXML1 = Path.GetDirectoryName(pRutaXML) + (object)Path.DirectorySeparatorChar;
                string fileName = Path.GetFileName(pRutaXML);
                string str3 = fileName;
                string str4 = fileName.Replace(".xml", ".zip");

                str1 = pRutaXML1 + str3;
                path = pRutaXML1 + str4;

                string str5 = "R-" + str3;
                string str6 = "R-" + str4;

                str2 = pRutaXML1 + str6;

                GMT_Sfe.WS_SUNAT_CO.billServiceClient billServiceClient = new GMT_Sfe.WS_SUNAT_CO.billServiceClient((Binding)this.binding, new EndpointAddress(URL));
                billServiceClient.ClientCredentials.UserName.UserName = this.oCuentaSunat.Usuario;
                billServiceClient.ClientCredentials.UserName.Password = this.oCuentaSunat.Contrasena;
                BindingElementCollection bindingElements = billServiceClient.Endpoint.Binding.CreateBindingElements();
                bindingElements.Find<SecurityBindingElement>().IncludeTimestamp = false;
                billServiceClient.Endpoint.Binding = (Binding)new CustomBinding((IEnumerable<BindingElement>)bindingElements);

                byte[] content = billServiceClient.getStatus(pEmpresa, pTipoDoc, pSerie, Convert.ToInt32(pNumero)).content;

                if (content == null)
                {
                    respuestaSunat.Codigo = "-1";
                    respuestaSunat.Mensaje = "El documento " + pTipoDoc + "-" + pSerie + "-" + pNumero + " no se encuentra registrado en sunat";
                    respuestaSunat.DigestValue = (string)null;
                    respuestaSunat.RutaXML = (string)null;
                    respuestaSunat.Estado = Estado.Cdr_NoExiste;
                }
                else
                {
                    respuestaSunat.Estado = Estado.Generado;
                    //System.IO.File.WriteAllBytes(str2, content);

                    //if (System.IO.File.Exists(pRutaXML1 + str5))
                    //    System.IO.File.Delete(pRutaXML1 + str5);

                    //this.Descomprimir(str2, pRutaXML1);

                    //XmlDocument xmlDocument = new XmlDocument();
                    //xmlDocument.Load(pRutaXML1 + str5);

                    //XmlNodeList childNodes = xmlDocument.GetElementsByTagName("DocumentResponse", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2").Item(0).FirstChild.ChildNodes;
                    //string innerText1 = childNodes[1].InnerText;
                    //string innerText2 = childNodes[2].InnerText;

                    //respuestaSunat.Codigo = innerText1;
                    //respuestaSunat.Mensaje = innerText2;
                    //respuestaSunat.RutaXML = pRutaXML;
                    //respuestaSunat.RutaCDR = pRutaXML1 + str5;
                    //respuestaSunat.DigestValue = this.ObtenerDigestValue(pTipoDoc, respuestaSunat.RutaXML);
                    //respuestaSunat.SignatureValue = this.ObtenerSignatureValue(pTipoDoc, respuestaSunat.RutaXML);
                }

                //if (Convert.ToInt32(respuestaSunat.Codigo) == 0)
                //    respuestaSunat.Estado = Estado.Aceptado;
                //else if (Convert.ToInt32(respuestaSunat.Codigo) >= 1 && Convert.ToInt32(respuestaSunat.Codigo) <= 1999)
                //    respuestaSunat.Estado = Estado.Invalido;
                //else if (Convert.ToInt32(respuestaSunat.Codigo) >= 2000 && Convert.ToInt32(respuestaSunat.Codigo) <= 3999)
                //    respuestaSunat.Estado = Estado.Rechazado;
            }
            catch (Exception ex)
            {
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = "Exception Validación: " + ex.Message;
                respuestaSunat.Estado = Estado.Error;
            }
            finally
            {
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                if (System.IO.File.Exists(str2))
                    System.IO.File.Delete(str2);
            }

            return respuestaSunat;
        }

        private RespuestaSunat ValidarGuiaRemision(string pRutaXML, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();

            string str1 = string.Empty;
            string str2 = string.Empty;
            byte[] bytes = (byte[])null;

            string URL = string.Empty;
            if (bOSE)
                URL = this.URL_SUNAT_OSE;
            else
                URL = this.URL_SUNAT_GR;

            try
            {
                string pRutaXML1 = Path.GetDirectoryName(pRutaXML) + (object)Path.DirectorySeparatorChar;
                string fileName1 = Path.GetFileName(pRutaXML);
                string str3 = fileName1;
                string fileName2 = fileName1.Replace(".xml", ".zip");
                string pRutaXML2 = pRutaXML1 + str3;

                str1 = pRutaXML1 + fileName2;

                string str4 = "R-" + str3;
                string str5 = "R-" + fileName2;

                str2 = pRutaXML1 + str5;

                if (System.IO.File.Exists(str1))
                    System.IO.File.Delete(str1);

                this.Comprimir(str1, pRutaXML2);
                byte[] contentFile = System.IO.File.ReadAllBytes(str1);

                GMT_Sfe.WS_SUNAT_GR.billServiceClient billServiceClient = new GMT_Sfe.WS_SUNAT_GR.billServiceClient((Binding)this.binding, new EndpointAddress(URL));
                billServiceClient.ClientCredentials.UserName.UserName = this.oCuentaSunat.Usuario;
                billServiceClient.ClientCredentials.UserName.Password = this.oCuentaSunat.Contrasena;
                BindingElementCollection bindingElements = billServiceClient.Endpoint.Binding.CreateBindingElements();
                bindingElements.Find<SecurityBindingElement>().EnableUnsecuredResponse = true;
                billServiceClient.Endpoint.Binding = (Binding)new CustomBinding((IEnumerable<BindingElement>)bindingElements);

                try
                {
                    bytes = billServiceClient.sendBill(fileName2, contentFile, (string)null);
                }
                catch (FaultException ex)
                {
                    string lst_faultcode = "";
                    string lst_faultstring = "";

                    if (bOSE)
                    {
                        MessageFault msgFault = ex.CreateMessageFault();
                        XmlElement elm = msgFault.GetDetail<XmlElement>();

                        lst_faultcode = ex.Message;
                        lst_faultstring = "FaultException Validación: " + elm.ChildNodes[0].Value;
                    }
                    else
                    {
                        lst_faultcode = Regex.Replace(ex.Code.Name.ToUpper(), "[^\\d]", "");
                        lst_faultstring = "FaultException Validación: " + ex.Message;

                        lst_faultcode = string.IsNullOrEmpty(lst_faultcode.Trim()) ? Regex.Replace(lst_faultstring.ToUpper(), "[^\\d]", "") : lst_faultcode;
                    }

                    respuestaSunat.Codigo = lst_faultcode;
                    respuestaSunat.Mensaje = lst_faultstring;
                    respuestaSunat.RutaXML = pRutaXML;
                }
                catch (Exception ex)
                {
                    if (!this.bEsValidacion)
                    {
                        respuestaSunat.Codigo = "0";
                        respuestaSunat.Mensaje = "El archivo XML ha sido generado, pero aún no ha sido válidado con la SUNAT debido a que no hay conexión con la URL: " + this.URL_SUNAT_FE;
                        respuestaSunat.DigestValue = (string)null;
                        respuestaSunat.RutaXML = pRutaXML;
                        respuestaSunat.Estado = Estado.Generado;
                    }
                    else
                    {
                        respuestaSunat.Codigo = "-1";
                        respuestaSunat.Mensaje = "No se ha sido válidado con la SUNAT debido al siguiente problema: " + (ex.InnerException != null ? ex.InnerException : ex).Message;
                        respuestaSunat.DigestValue = (string)null;
                        respuestaSunat.RutaXML = (string)null;
                        respuestaSunat.Estado = Estado.Error;
                    }
                    return respuestaSunat;
                }

                if (bytes != null)
                {
                    System.IO.File.WriteAllBytes(str2, bytes);

                    if (System.IO.File.Exists(pRutaXML1 + str4))
                        System.IO.File.Delete(pRutaXML1 + str4);

                    this.Descomprimir(str2, pRutaXML1);

                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(pRutaXML1 + str4);

                    XmlNodeList childNodes = xmlDocument.GetElementsByTagName("DocumentResponse", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2").Item(0).FirstChild.ChildNodes;
                    respuestaSunat.Codigo = childNodes[1].InnerText;
                    respuestaSunat.Mensaje = childNodes[2].InnerText;
                    respuestaSunat.RutaXML = pRutaXML;
                    respuestaSunat.RutaCDR = pRutaXML1 + str4;
                }

                if (Convert.ToInt32(respuestaSunat.Codigo) == 0)
                    respuestaSunat.Estado = Estado.Aceptado;
                else if (Convert.ToInt32(respuestaSunat.Codigo) >= 1 && Convert.ToInt32(respuestaSunat.Codigo) <= 1999)
                    respuestaSunat.Estado = Estado.Invalido;
                else if (Convert.ToInt32(respuestaSunat.Codigo) >= 2000 && Convert.ToInt32(respuestaSunat.Codigo) <= 3999)
                    respuestaSunat.Estado = Estado.Rechazado;

                if (this.bEsValidacion)
                {
                    if (Estado.Generado == respuestaSunat.Estado || Estado.Aceptado == respuestaSunat.Estado || Estado.Rechazado == respuestaSunat.Estado)
                    {
                        respuestaSunat.DigestValue = this.ObtenerDigestValue("09", respuestaSunat.RutaXML);
                        respuestaSunat.SignatureValue = this.ObtenerSignatureValue("09", respuestaSunat.RutaXML);
                    }
                }
            }
            catch (Exception ex)
            {
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = "Exception Validación: " + (ex.InnerException != null ? ex.InnerException : ex).Message;
                respuestaSunat.Estado = Estado.Error;
            }
            finally
            {
                if (System.IO.File.Exists(str1))
                    System.IO.File.Delete(str1);

                if (System.IO.File.Exists(str2))
                    System.IO.File.Delete(str2);
            }

            return respuestaSunat;
        }

        private RespuestaSunat GenerarTicketSunatRB(string pRutaXML, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();

            string str1 = string.Empty;
            string path = string.Empty;

            string URL = string.Empty;
            if (bOSE)
                URL = this.URL_SUNAT_OSE;
            else
                URL = this.URL_SUNAT_FE;

            try
            {
                string str2 = Path.GetDirectoryName(pRutaXML) + (object)Path.DirectorySeparatorChar;
                string fileName = Path.GetFileName(pRutaXML);
                string str3 = fileName;
                string str4 = fileName.Replace(".xml", ".zip");
                string str5 = str2 + str3;
                path = str2 + str4;

                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                this.Comprimir(path, str5);

                byte[] numArray = System.IO.File.ReadAllBytes(path);

                ServicePointManager.UseNagleAlgorithm = true;
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.CheckCertificateRevocationList = true;
                BasicHttpBinding basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
                basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                basicHttpBinding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
                basicHttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                basicHttpBinding.Security.Message.AlgorithmSuite = SecurityAlgorithmSuite.Default;
                EndpointAddress endpointAddress = new EndpointAddress(URL);
                GMT_Sfe.WS_SUNAT_FE.billServiceClient billServiceClient = new GMT_Sfe.WS_SUNAT_FE.billServiceClient((Binding)basicHttpBinding, endpointAddress);
                billServiceClient.ClientCredentials.UserName.UserName = this.oCuentaSunat.Usuario;
                billServiceClient.ClientCredentials.UserName.Password = this.oCuentaSunat.Contrasena;
                BindingElementCollection bindingElements = billServiceClient.Endpoint.Binding.CreateBindingElements();
                bindingElements.Find<SecurityBindingElement>().IncludeTimestamp = false;
                billServiceClient.Endpoint.Binding = (Binding)new CustomBinding((IEnumerable<BindingElement>)bindingElements);

                try
                {
                    str1 = billServiceClient.sendSummary(str4, numArray);
                }
                catch (FaultException ex)
                {
                    string str6 = ex.Code.Name.ToUpper().Replace("SOAP-ENV-SERVER.", "").Replace("SOAP-ENV-SERVER", "");
                    string str7 = "FaultException Validación: " + ex.Message;

                    respuestaSunat.Codigo = str6;
                    respuestaSunat.Mensaje = str7;
                }
                catch (Exception ex)
                {
                    respuestaSunat.Codigo = "0";
                    respuestaSunat.Mensaje = "El archivo XML ha sido generado, pero aún no se obtuvo el Ticket de SUNAT debido a que no hay conexión con la URL: " + URL;
                    respuestaSunat.RutaXML = pRutaXML;
                    respuestaSunat.Estado = Estado.Generado;
                    return respuestaSunat;
                }
                if (string.IsNullOrEmpty(str1))
                {
                    respuestaSunat.Ticket = string.Empty;
                    respuestaSunat.Codigo = "-1";
                    respuestaSunat.Mensaje = "El archivo XML ha sido generado, pero no se ha generado el Ticket";
                    respuestaSunat.RutaXML = pRutaXML;
                    respuestaSunat.Estado = Estado.Generado;
                }
                else
                {
                    respuestaSunat.Ticket = str1;
                    respuestaSunat.Codigo = "0";
                    respuestaSunat.Mensaje = "Se acaba de generar el Ticket : " + str1;
                    respuestaSunat.RutaXML = pRutaXML;
                    respuestaSunat.Estado = Estado.Aceptado;
                }
            }
            catch (Exception ex)
            {
                respuestaSunat.Ticket = (string)null;
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = ex.Message;
                respuestaSunat.Estado = Estado.Error;
            }
            finally
            {
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }

            return respuestaSunat;
        }

        public RespuestaSunat ValidarTicketResumen(string pTicket, string pRutaXML, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();

            string str1 = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;

            string URL = string.Empty;
            if (bOSE)
                URL = this.URL_SUNAT_OSE;
            else
                URL = this.URL_SUNAT_FE;

            try
            {
                string pRutaXML1 = Path.GetDirectoryName(pRutaXML) + (object)Path.DirectorySeparatorChar;
                string fileName = Path.GetFileName(pRutaXML);
                string str4 = fileName;
                string str5 = fileName.Replace(".xml", ".zip");

                str1 = pRutaXML1 + str4;
                str2 = pRutaXML1 + str5;

                string str6 = "R-" + str4;
                string str7 = "R-" + str5;

                str3 = pRutaXML1 + str7;

                GMT_Sfe.WS_SUNAT_FE.billServiceClient billServiceClient = new GMT_Sfe.WS_SUNAT_FE.billServiceClient((Binding)this.binding, new EndpointAddress(URL));
                billServiceClient.ClientCredentials.UserName.UserName = this.oCuentaSunat.Usuario;
                billServiceClient.ClientCredentials.UserName.Password = this.oCuentaSunat.Contrasena;
                BindingElementCollection bindingElements = billServiceClient.Endpoint.Binding.CreateBindingElements();
                bindingElements.Find<SecurityBindingElement>().IncludeTimestamp = false;
                billServiceClient.Endpoint.Binding = (Binding)new CustomBinding((IEnumerable<BindingElement>)bindingElements);
                respuestaSunat.Ticket = pTicket;
                billServiceClient.getStatus(pTicket);

                try
                {
                    byte[] content = billServiceClient.getStatus(pTicket).content;

                    if (content != null)
                    {
                        System.IO.File.WriteAllBytes(str3, content);

                        if (System.IO.File.Exists(pRutaXML1 + str6))
                            System.IO.File.Delete(pRutaXML1 + str6);

                        this.Descomprimir(str3, pRutaXML1);

                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(pRutaXML1 + str6);

                        XmlNodeList childNodes = xmlDocument.GetElementsByTagName("DocumentResponse", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2").Item(0).FirstChild.ChildNodes;
                        string innerText1 = childNodes[1].InnerText;
                        string innerText2 = childNodes[2].InnerText;

                        respuestaSunat.Codigo = innerText1;
                        respuestaSunat.Mensaje = innerText2;
                        respuestaSunat.RutaXML = pRutaXML;
                        respuestaSunat.RutaCDR = pRutaXML1 + str6;
                    }
                }
                catch (FaultException ex)
                {
                    string str8 = ex.Code.Name.ToUpper().Replace("SOAP-ENV-SERVER.", "").Replace("SOAP-ENV-SERVER", "");
                    string message = ex.Message;

                    respuestaSunat.Codigo = str8;
                    respuestaSunat.Mensaje = message;
                }
            }
            catch (Exception ex)
            {
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = ex.Message;
            }
            finally
            {
                if (System.IO.File.Exists(str3))
                    System.IO.File.Delete(str3);
            }

            return respuestaSunat;
        }

        public RespuestaSunat ValidarTicketBaja(string pTicket, string pRutaXML, bool bOSE)
        {
            RespuestaSunat respuestaSunat = new RespuestaSunat();

            string str1 = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;

            string URL = string.Empty;
            if (bOSE)
                URL = this.URL_SUNAT_OSE;
            else
                URL = this.URL_SUNAT_FE;

            try
            {
                string pRutaXML1 = Path.GetDirectoryName(pRutaXML) + (object)Path.DirectorySeparatorChar;
                string fileName = Path.GetFileName(pRutaXML);
                string str4 = fileName;
                string str5 = fileName.Replace(".xml", ".zip");

                str1 = pRutaXML1 + str4;
                str2 = pRutaXML1 + str5;

                string str6 = "R-" + str4;
                string str7 = "R-" + str5;

                str3 = pRutaXML1 + str7;

                GMT_Sfe.WS_SUNAT_FE.billServiceClient billServiceClient = new GMT_Sfe.WS_SUNAT_FE.billServiceClient((Binding)this.binding, new EndpointAddress(URL));
                billServiceClient.ClientCredentials.UserName.UserName = this.oCuentaSunat.Usuario;
                billServiceClient.ClientCredentials.UserName.Password = this.oCuentaSunat.Contrasena;
                BindingElementCollection bindingElements = billServiceClient.Endpoint.Binding.CreateBindingElements();
                bindingElements.Find<SecurityBindingElement>().IncludeTimestamp = false;
                billServiceClient.Endpoint.Binding = (Binding)new CustomBinding((IEnumerable<BindingElement>)bindingElements);
                respuestaSunat.Ticket = pTicket;
                billServiceClient.getStatus(pTicket);

                try
                {
                    byte[] content = billServiceClient.getStatus(pTicket).content;

                    if (content != null)
                    {
                        System.IO.File.WriteAllBytes(str3, content);

                        if (System.IO.File.Exists(pRutaXML1 + str6))
                            System.IO.File.Delete(pRutaXML1 + str6);

                        this.Descomprimir(str3, pRutaXML1);

                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(pRutaXML1 + str6);

                        XmlNodeList childNodes = xmlDocument.GetElementsByTagName("DocumentResponse", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2").Item(0).FirstChild.ChildNodes;
                        string innerText1 = childNodes[1].InnerText;
                        string innerText2 = childNodes[2].InnerText;

                        respuestaSunat.Codigo = innerText1;
                        respuestaSunat.Mensaje = innerText2;
                        respuestaSunat.RutaXML = pRutaXML;
                        respuestaSunat.RutaCDR = pRutaXML1 + str6;
                    }
                }
                catch (FaultException ex)
                {
                    string str8 = ex.Code.Name.ToUpper().Replace("SOAP-ENV-SERVER.", "").Replace("SOAP-ENV-SERVER", "");
                    string message = ex.Message;

                    respuestaSunat.Codigo = str8;
                    respuestaSunat.Mensaje = message;
                }
            }
            catch (Exception ex)
            {
                respuestaSunat.Codigo = "-1";
                respuestaSunat.Mensaje = ex.Message;
            }
            finally
            {
                if (System.IO.File.Exists(str3))
                    System.IO.File.Delete(str3);
            }

            return respuestaSunat;
        }

        public void GenerarPDF(ComprobanteCabecera pCabecera, RespuestaSunat oRespuesta, string pHoja)
        {
            try
            {
                string str_file = pCabecera.NroDoc_Emisor + "-" + pCabecera.Codigo_Documento + "-" + pCabecera.Serie_Documento + "-" + pCabecera.Numero_Documento + ".pdf";

                if (pCabecera.Codigo_Documento == "01")
                {
                    oRespuesta.RutaPDF = this.RUTA_FACTURA + str_file;

                    if (pHoja == "A4")
                        this.GeneraPDFA4Factura(pCabecera, pCabecera.Sigla_Moneda, oRespuesta.DigestValue, oRespuesta.SignatureValue, oRespuesta.RutaPDF);
                    else if (pHoja == "Ticket")
                        this.GeneraPDFTicketFactura(pCabecera, pCabecera.Sigla_Moneda, oRespuesta.DigestValue, oRespuesta.SignatureValue, oRespuesta.RutaPDF);
                }
                else if (pCabecera.Codigo_Documento == "03")
                {
                    oRespuesta.RutaPDF = this.RUTA_BOLETA + str_file;

                    if (pHoja == "A4")
                        this.GeneraPDFA4Boleta(pCabecera, pCabecera.Sigla_Moneda, oRespuesta.DigestValue, oRespuesta.SignatureValue, oRespuesta.RutaPDF);
                    else if (pHoja == "Ticket")
                        this.GeneraPDFTicketBoleta(pCabecera, pCabecera.Sigla_Moneda, oRespuesta.DigestValue, oRespuesta.SignatureValue, oRespuesta.RutaPDF);
                }
                else if (pCabecera.Codigo_Documento == "07")
                {
                    oRespuesta.RutaPDF = this.RUTA_NOTACREDITO + str_file;

                    if (pHoja == "A4")
                        this.GeneraPDFA4NCredito(pCabecera, pCabecera.Sigla_Moneda, oRespuesta.DigestValue, oRespuesta.SignatureValue, oRespuesta.RutaPDF);
                    else if (pHoja == "Ticket")
                        this.GeneraPDFTicketNCredito(pCabecera, pCabecera.Sigla_Moneda, oRespuesta.DigestValue, oRespuesta.SignatureValue, oRespuesta.RutaPDF);
                }
                else if (pCabecera.Codigo_Documento == "08")
                {
                    oRespuesta.RutaPDF = this.RUTA_NOTADEBITO + str_file;

                    if (pHoja == "A4")
                        this.GeneraPDFA4NDebito(pCabecera, pCabecera.Sigla_Moneda, oRespuesta.DigestValue, oRespuesta.SignatureValue, oRespuesta.RutaPDF);
                    else if (pHoja == "Ticket")
                        this.GeneraPDFTicketNDebito(pCabecera, pCabecera.Sigla_Moneda, oRespuesta.DigestValue, oRespuesta.SignatureValue, oRespuesta.RutaPDF);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraPDFA4Factura(ComprobanteCabecera pCabecera, string pMoneda, string pDigestValue, string pSignature, string pFileName)
        {
            try
            {
                PdfPCell pdfPcell = new PdfPCell();
                string appSetting = ConfigurationManager.AppSettings["LOGO_EMPRESA"];
                if (pCabecera == null)
                    return;
                Document document = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance1 = PdfWriter.GetInstance(document, (Stream)memoryStream);
                iTextSharp.text.Font font1 = FontFactory.GetFont("Verdana", 12f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font2 = FontFactory.GetFont("Verdana", 10f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font3 = FontFactory.GetFont("Verdana", 6.3f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                BaseColor baseColor = new BaseColor(ColorTranslator.FromHtml("#EBEBEB"));
                document.Open();
                PdfPTable pdfPtable1 = new PdfPTable(3);
                pdfPtable1.HorizontalAlignment = 0;
                pdfPtable1.WidthPercentage = 100f;
                pdfPtable1.DefaultCell.Border = 0;
                PdfPTable table1 = new PdfPTable(1);
                table1.HorizontalAlignment = 0;
                table1.DefaultCell.Border = 0;
                iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance(appSetting);
                instance2.ScalePercent(30f);
                PdfPCell cell1 = new PdfPCell(instance2);
                cell1.Border = 0;
                cell1.HorizontalAlignment = 0;
                table1.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("", font2)); //pCabecera.RSocial_Emisor
                cell2.PaddingTop = 5f;
                cell2.Border = 0;
                cell2.HorizontalAlignment = 0;
                table1.AddCell(cell2);
                pdfPtable1.AddCell(table1);
                PdfPTable table2 = new PdfPTable(1);
                table2.HorizontalAlignment = 1;
                table2.DefaultCell.Border = 0;
                PdfPCell cell3 = new PdfPCell(new Phrase("Oficina Principal", font3));
                cell3.PaddingTop = 20f;
                cell3.Border = 0;
                cell3.HorizontalAlignment = 1;
                table2.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase(pCabecera.Direccion_Emisor, font3));
                cell4.Border = 0;
                cell4.HorizontalAlignment = 1;
                table2.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(pCabecera.Dist_Emisor + " - " + pCabecera.Prov_Emisor + " - " + pCabecera.Dpto_Emisor, font3));
                cell5.Border = 0;
                cell5.HorizontalAlignment = 1;
                table2.AddCell(cell5);
                pdfPtable1.AddCell(table2);
                PdfPTable table3 = new PdfPTable(1);
                table3.HorizontalAlignment = 1;
                PdfPCell cell6 = new PdfPCell(new Phrase("R.U.C. N° " + pCabecera.NroDoc_Emisor, font1));
                cell6.PaddingTop = 10f;
                cell6.Border = 13;
                cell6.HorizontalAlignment = 1;
                table3.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("FACTURA ELECTRONICA", font1));
                cell7.PaddingTop = 5f;
                cell7.Border = 12;
                cell7.HorizontalAlignment = 1;
                table3.AddCell(cell7);
                PdfPCell cell8 = new PdfPCell(new Phrase(pCabecera.Serie_Documento + " - " + pCabecera.Numero_Documento, font1));
                cell8.PaddingTop = 5f;
                cell8.Border = 12;
                cell8.HorizontalAlignment = 1;
                table3.AddCell(cell8);
                PdfPCell cell9 = new PdfPCell(new Phrase(" "));
                cell9.PaddingTop = 5f;
                cell9.Border = 14;
                cell9.HorizontalAlignment = 1;
                table3.AddCell(cell9);
                pdfPtable1.AddCell(table3);
                PdfPTable pdfPtable2 = new PdfPTable(4);
                pdfPtable2.HorizontalAlignment = 0;
                pdfPtable2.WidthPercentage = 100f;
                pdfPtable2.SpacingBefore = 5f;
                pdfPtable2.SetWidths(new float[4]
                {
                    90f,
                    90f,
                    90f,
                    90f
                });
                PdfPCell cell10 = new PdfPCell(new Phrase("Señor(es) : " + pCabecera.RSocial_Receptor, font3));
                cell10.Colspan = 4;
                cell10.Border = 13;
                cell10.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell10);
                PdfPCell cell11 = new PdfPCell(new Phrase("Dirección : " + pCabecera.Direccion_Receptor, font3));
                cell11.Colspan = 4;
                cell11.PaddingTop = 5f;
                cell11.Border = 12;
                cell11.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell11);
                PdfPCell cell12 = new PdfPCell(new Phrase("R.U.C. N° : " + pCabecera.NroDoc_Receptor, font3));
                cell12.Colspan = 3;
                cell12.PaddingTop = 5f;
                cell12.PaddingBottom = 10f;
                cell12.Border = 6;
                cell12.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell12);
                PdfPCell cell13 = new PdfPCell(new Phrase("Fecha de Emisión: " + Convert.ToDateTime(pCabecera.Fecha_Emision).ToString("dd/MM/yyyy"), font3));
                cell13.PaddingTop = 5f;
                cell13.PaddingBottom = 10f;
                cell13.Border = 10;
                cell13.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell13);
                PdfPTable pdfPtable3 = new PdfPTable(7);
                pdfPtable3.HorizontalAlignment = 0;
                pdfPtable3.WidthPercentage = 100f;
                pdfPtable3.SpacingBefore = 5f;
                pdfPtable3.SetWidths(new float[7]
                {
                    15f,
                    50f,
                    230f,
                    30f,
                    50f,
                    50f,
                    50f
                });
                PdfPCell cell14 = new PdfPCell(new Phrase("N°", font3));
                cell14.BackgroundColor = baseColor;
                cell14.HorizontalAlignment = 1;
                cell14.PaddingTop = 5f;
                cell14.PaddingBottom = 5f;
                cell14.Border = 15;
                pdfPtable3.AddCell(cell14);
                PdfPCell cell15 = new PdfPCell(new Phrase("CODIGO", font3));
                cell15.BackgroundColor = baseColor;
                cell15.HorizontalAlignment = 1;
                cell15.PaddingTop = 5f;
                cell15.PaddingBottom = 5f;
                cell15.Border = 15;
                pdfPtable3.AddCell(cell15);
                PdfPCell cell16 = new PdfPCell(new Phrase("DESCRIPCION", font3));
                cell16.BackgroundColor = baseColor;
                cell16.HorizontalAlignment = 1;
                cell16.PaddingTop = 5f;
                cell16.PaddingBottom = 5f;
                cell16.Border = 15;
                pdfPtable3.AddCell(cell16);
                PdfPCell cell17 = new PdfPCell(new Phrase("U.M.", font3));
                cell17.BackgroundColor = baseColor;
                cell17.HorizontalAlignment = 1;
                cell17.PaddingTop = 5f;
                cell17.PaddingBottom = 5f;
                cell17.Border = 15;
                pdfPtable3.AddCell(cell17);
                PdfPCell cell18 = new PdfPCell(new Phrase("CANTIDAD", font3));
                cell18.BackgroundColor = baseColor;
                cell18.HorizontalAlignment = 1;
                cell18.PaddingTop = 5f;
                cell18.PaddingBottom = 5f;
                cell18.Border = 15;
                pdfPtable3.AddCell(cell18);
                PdfPCell cell19 = new PdfPCell(new Phrase("PRECIO UNIT.", font3));
                cell19.BackgroundColor = baseColor;
                cell19.HorizontalAlignment = 1;
                cell19.PaddingTop = 5f;
                cell19.PaddingBottom = 5f;
                cell19.Border = 15;
                pdfPtable3.AddCell(cell19);
                PdfPCell cell20 = new PdfPCell(new Phrase("TOTAL", font3));
                cell20.BackgroundColor = baseColor;
                cell20.HorizontalAlignment = 1;
                cell20.PaddingTop = 5f;
                cell20.PaddingBottom = 5f;
                cell20.Border = 15;
                pdfPtable3.AddCell(cell20);
                List<ComprobanteDetalle> comprobanteDetalle = pCabecera.LstComprobanteDetalle;
                int count = comprobanteDetalle.Count;
                int num1 = 30;
                int num2 = num1 - 1;
                for (int index = 0; index < num1; ++index)
                {
                    if (index < count)
                    {
                        PdfPCell cell21 = new PdfPCell(new Phrase(comprobanteDetalle[index].NroItem, font3));
                        cell21.Border = 14;
                        cell21.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell21);
                        PdfPCell cell22 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Codigo_Articulo, font3));
                        cell22.Border = 14;
                        cell22.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell22);
                        PdfPCell cell23 = new PdfPCell(new Phrase(comprobanteDetalle[index].Descripcion_Articulo, font3));
                        cell23.Border = 14;
                        cell23.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell23);
                        PdfPCell cell24 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Codigo_Unidad, font3));
                        cell24.Border = 14;
                        cell24.HorizontalAlignment = 1;
                        pdfPtable3.AddCell(cell24);
                        PdfPCell cell25 = new PdfPCell(new Phrase(comprobanteDetalle[index].Cantidad.ToString(), font3));
                        cell25.Border = 14;
                        cell25.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell25);
                        PdfPCell cell26 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Precio_Unitario_SinIGV.ToString("#0.00"), font3));
                        cell26.Border = 14;
                        cell26.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell26);
                        PdfPCell cell27 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Importe_SubTotal.ToString("#,##0.00"), font3));
                        cell27.Border = 14;
                        cell27.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell27);
                    }
                    else
                    {
                        PdfPCell cell21 = new PdfPCell(new Phrase(" ", font3));
                        cell21.Border = num2 == index ? 14 : 12;
                        cell21.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell21);
                        PdfPCell cell22 = new PdfPCell(new Phrase(" ", font3));
                        cell22.Border = num2 == index ? 14 : 12;
                        cell22.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell22);
                        PdfPCell cell23 = new PdfPCell(new Phrase(" ", font3));
                        cell23.Border = num2 == index ? 14 : 12;
                        cell23.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell23);
                        PdfPCell cell24 = new PdfPCell(new Phrase(" ", font3));
                        cell24.Border = num2 == index ? 14 : 12;
                        cell24.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell24);
                        PdfPCell cell25 = new PdfPCell(new Phrase(" ", font3));
                        cell25.Border = num2 == index ? 14 : 12;
                        cell25.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell25);
                        PdfPCell cell26 = new PdfPCell(new Phrase(" ", font3));
                        cell26.Border = num2 == index ? 14 : 12;
                        cell26.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell26);
                        PdfPCell cell27 = new PdfPCell(new Phrase(" ", font3));
                        cell27.Border = num2 == index ? 14 : 12;
                        cell27.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell27);
                    }
                }
                PdfPTable pdfPtable4 = new PdfPTable(3);
                pdfPtable4.HorizontalAlignment = 0;
                pdfPtable4.WidthPercentage = 100f;
                pdfPtable4.SetWidths(new float[3] { 150f, 20f, 100f });
                PdfPCell cell28 = new PdfPCell(new Phrase("Operación Gravada", font3));
                cell28.Border = 0;
                cell28.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell28);
                PdfPCell cell29 = new PdfPCell(new Phrase(pMoneda, font3));
                cell29.Border = 0;
                pdfPtable4.AddCell(cell29);
                PdfPCell cell30 = new PdfPCell(new Phrase(pCabecera.Importe_Gravado.ToString("#,##0.00"), font3));
                cell30.Border = 0;
                cell30.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell30);
                PdfPCell cell31 = new PdfPCell(new Phrase("Operación Exonerada", font3));
                cell31.Border = 0;
                cell31.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell31);
                PdfPCell cell32 = new PdfPCell(new Phrase(pMoneda, font3));
                cell32.Border = 0;
                pdfPtable4.AddCell(cell32);
                PdfPCell cell33 = new PdfPCell(new Phrase(pCabecera.Importe_Exonerado.ToString("#,##0.00"), font3));
                cell33.Border = 0;
                cell33.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell33);
                PdfPCell cell34 = new PdfPCell(new Phrase("Operación Inafecta", font3));
                cell34.Border = 0;
                cell34.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell34);
                PdfPCell cell35 = new PdfPCell(new Phrase(pMoneda, font3));
                cell35.Border = 0;
                pdfPtable4.AddCell(cell35);
                PdfPCell cell36 = new PdfPCell(new Phrase(pCabecera.Importe_Inafecto.ToString("#,##0.00"), font3));
                cell36.Border = 0;
                cell36.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell36);
                PdfPCell cell37 = new PdfPCell(new Phrase("Operación Gratuita", font3));
                cell37.Border = 0;
                cell37.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell37);
                PdfPCell cell38 = new PdfPCell(new Phrase(pMoneda, font3));
                cell38.Border = 0;
                pdfPtable4.AddCell(cell38);
                PdfPCell cell39 = new PdfPCell(new Phrase(pCabecera.Importe_Gratuito.ToString("#,##0.00"), font3));
                cell39.Border = 0;
                cell39.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell39);
                PdfPCell cell40 = new PdfPCell(new Phrase("Anticipos", font3));
                cell40.Border = 0;
                cell40.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell40);
                PdfPCell cell41 = new PdfPCell(new Phrase(pMoneda, font3));
                cell41.Border = 0;
                pdfPtable4.AddCell(cell41);
                PdfPCell cell42 = new PdfPCell(new Phrase(pCabecera.Importe_Anticipos.ToString("#,##0.00"), font3));
                cell42.Border = 0;
                cell42.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell42);
                PdfPCell cell43 = new PdfPCell(new Phrase("Total Descuento", font3));
                cell43.Border = 0;
                cell43.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell43);
                PdfPCell cell44 = new PdfPCell(new Phrase(pMoneda, font3));
                cell44.Border = 0;
                pdfPtable4.AddCell(cell44);
                Decimal num3 = pCabecera.Importe_DctoGlobal;
                PdfPCell cell45 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell45.Border = 0;
                cell45.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell45);
                PdfPCell cell46 = new PdfPCell(new Phrase("I.G.V. (" + this.IGV + "%)", font3));
                cell46.Border = 0;
                cell46.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell46);
                PdfPCell cell47 = new PdfPCell(new Phrase(pMoneda, font3));
                cell47.Border = 0;
                pdfPtable4.AddCell(cell47);
                num3 = pCabecera.Importe_IGV;
                PdfPCell cell48 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell48.Border = 0;
                cell48.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell48);
                if (pCabecera.Importe_Percepcion == new Decimal(0))
                {
                    PdfPCell cell21 = new PdfPCell(new Phrase("Importe Total", font3));
                    cell21.Border = 0;
                    cell21.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell21);
                    PdfPCell cell22 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell22.Border = 0;
                    pdfPtable4.AddCell(cell22);
                    num3 = pCabecera.Importe_Total;
                    PdfPCell cell23 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell23.Border = 0;
                    cell23.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell23);
                }
                else
                {
                    PdfPCell cell21 = new PdfPCell(new Phrase("Total a Pagar", font3));
                    cell21.Border = 0;
                    cell21.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell21);
                    PdfPCell cell22 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell22.Border = 0;
                    pdfPtable4.AddCell(cell22);
                    num3 = pCabecera.Importe_Total;
                    PdfPCell cell23 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell23.Border = 0;
                    cell23.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell23);
                    PdfPCell cell24 = new PdfPCell(new Phrase("Percepción", font3));
                    cell24.Border = 0;
                    cell24.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell24);
                    PdfPCell cell25 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell25.Border = 0;
                    pdfPtable4.AddCell(cell25);
                    num3 = pCabecera.Importe_Percepcion;
                    PdfPCell cell26 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell26.Border = 0;
                    cell26.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell26);
                    PdfPCell cell27 = new PdfPCell(new Phrase("Importe Total", font3));
                    cell27.Border = 0;
                    cell27.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell27);
                    PdfPCell cell49 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell49.Border = 0;
                    pdfPtable4.AddCell(cell49);
                    num3 = pCabecera.Importe_Cobrado;
                    PdfPCell cell50 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell50.Border = 0;
                    cell50.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell50);
                }
                PdfPCell cell51 = new PdfPCell(new Phrase("SON:", font3));
                cell51.Colspan = 3;
                cell51.Border = 14;
                pdfPtable3.AddCell(cell51);
                PdfPCell cell52 = new PdfPCell(new Phrase(" ", font3));
                cell52.Colspan = 4;
                cell52.Border = 0;
                pdfPtable3.AddCell(cell52);
                PdfPCell cell53 = new PdfPCell(new Phrase(pCabecera.Texto_Importe_Total, font3));
                cell53.Colspan = 3;
                cell53.PaddingLeft = 10f;
                cell53.PaddingBottom = 40f;
                cell53.Border = 14;
                pdfPtable3.AddCell(cell53);
                PdfPCell cell54 = new PdfPCell(new Phrase(" ", font3));
                cell54.Colspan = 4;
                cell54.Rowspan = 9;
                cell54.Border = 0;
                cell54.AddElement((IElement)pdfPtable4);
                pdfPtable3.AddCell(cell54);
                if (pCabecera.Importe_Percepcion != new Decimal(0))
                {
                    PdfPCell cell21 = new PdfPCell(new Phrase(" ", font3));
                    cell21.Colspan = 3;
                    cell21.Border = 0;
                    pdfPtable3.AddCell(cell21);
                    PdfPCell cell22 = new PdfPCell(new Phrase("COMPROBANTE DE PERCEPCION - VENTA INTERNA", font3));
                    cell22.Colspan = 3;
                    cell22.Border = 15;
                    pdfPtable3.AddCell(cell22);
                }
                PdfPCell cell55 = new PdfPCell(new Phrase(" ", font3));
                cell55.Colspan = 3;
                cell55.Border = 0;
                pdfPtable3.AddCell(cell55);
                PdfPCell cell56 = new PdfPCell(new Phrase("Código Hash", font3));
                cell56.Colspan = 3;
                cell56.Border = 15;
                pdfPtable3.AddCell(cell56);
                PdfPCell cell57 = new PdfPCell(new Phrase(pDigestValue, font3));
                cell57.Colspan = 3;
                cell57.Border = 14;
                cell57.PaddingLeft = 10f;
                pdfPtable3.AddCell(cell57);
                PdfPCell cell58 = new PdfPCell(new Phrase(" ", font3));
                cell58.Colspan = 3;
                cell58.Border = 0;
                pdfPtable3.AddCell(cell58);
                PdfPCell cell59 = new PdfPCell(new Phrase(" ", font3));
                cell59.Colspan = 7;
                cell59.Border = 0;
                pdfPtable3.AddCell(cell59);
                string empty = string.Empty;
                string str1 = pCabecera.NroDoc_Emisor + "|" + pCabecera.Codigo_Documento + "|" + pCabecera.Serie_Documento + "|" + pCabecera.Numero_Documento + "|" + (object)pCabecera.Importe_IGV;
                string[] strArray1 = new string[10];
                strArray1[0] = str1;
                strArray1[1] = "|";
                string[] strArray2 = strArray1;
                num3 = pCabecera.Importe_Total;
                string str2 = num3.ToString();
                strArray2[2] = str2;
                strArray1[3] = "|";
                strArray1[4] = pCabecera.Fecha_Emision.ToString("dd-MM-yyyy");
                strArray1[5] = "|";
                strArray1[6] = pCabecera.TipoDoc_Receptor;
                strArray1[7] = "|";
                strArray1[8] = pCabecera.NroDoc_Receptor;
                strArray1[9] = "|";
                iTextSharp.text.Image image = GenerarArchivo.RetornarCodigoQR(string.Concat(strArray1));
                image.SetAbsolutePosition(0.0f, 0.0f);
                iTextSharp.text.Rectangle pageSize = instance1.PageSize;
                PdfTemplate template = new PdfContentByte(instance1).CreateTemplate(400f, 100f);
                template.AddImage(image);
                BaseFont font4 = BaseFont.CreateFont("Helvetica", "Cp1250", true);
                PdfContentByte pdfContentByte = new PdfContentByte(instance1);
                PdfContentByte directContent = instance1.DirectContent;
                directContent.BeginText();
                directContent.SetFontAndSize(font4, 6.5f);
                directContent.ShowTextAligned(0, "Representación gráfica del documento electrónico, este puede ser consultado en " + this.LINK_DESCARGA_ARCHIVOS, 30f, 45f, 0.0f);
                directContent.EndText();
                directContent.BeginText();
                directContent.SetFontAndSize(font4, 6.5f);
                directContent.ShowTextAligned(0, "Autorizado mediante Resolución N°." + this.NRO_RESOLUCION + "/SUNAT.", 30f, 35f, 0.0f);
                directContent.EndText();
                directContent.AddTemplate(template, 25f, 55f);
                directContent.Stroke();
                document.Add((IElement)pdfPtable1);
                document.Add((IElement)pdfPtable2);
                document.Add((IElement)pdfPtable3);
                document.Close();
                byte[]
        array = memoryStream.ToArray();
                System.IO.File.WriteAllBytes(pFileName, array);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraPDFTicketFactura(ComprobanteCabecera pCabecera, string pMoneda, string pDigestValue, string pSignature, string pFileName)
        {
            try
            {
                string appSetting = ConfigurationManager.AppSettings["LOGO_EMPRESA"];
                if (pCabecera == null)
                    return;
                Document document = new Document(new iTextSharp.text.Rectangle(220f, (490f + (pCabecera.LstComprobanteDetalle.Count * 7))), 1f, 1f, 1f, 1f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance1 = PdfWriter.GetInstance(document, (Stream)memoryStream);
                iTextSharp.text.Font font = FontFactory.GetFont("Verdana", 7f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                document.Open();
                PdfPTable pdfPtable1 = new PdfPTable(1);
                pdfPtable1.HorizontalAlignment = 0;
                pdfPtable1.WidthPercentage = 100f;
                pdfPtable1.DefaultCell.Border = 0;
                PdfPTable table1 = new PdfPTable(1);
                table1.HorizontalAlignment = 0;
                table1.DefaultCell.Border = 0;
                iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance(appSetting);
                instance2.ScalePercent(6f);
                PdfPCell cell1 = new PdfPCell(instance2);
                cell1.Border = 0;
                cell1.HorizontalAlignment = 1;
                table1.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase(pCabecera.RSocial_Emisor, font));
                cell2.PaddingTop = 5f;
                cell2.Border = 0;
                cell2.HorizontalAlignment = 1;
                table1.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("R.U.C. N° " + pCabecera.NroDoc_Emisor, font));
                cell3.Border = 0;
                cell3.HorizontalAlignment = 1;
                table1.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase(pCabecera.Direccion_Emisor, font));
                cell4.Border = 0;
                cell4.HorizontalAlignment = 1;
                table1.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(pCabecera.Dist_Emisor + " - " + pCabecera.Prov_Emisor + " - " + pCabecera.Dpto_Emisor, font));
                cell5.Border = 0;
                cell5.HorizontalAlignment = 1;
                table1.AddCell(cell5);
                PdfPCell cell6 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell6.Border = 0;
                cell6.HorizontalAlignment = 1;
                table1.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("FACTURA DE VENTA ELECTRONICA", font));
                cell7.Border = 0;
                cell7.HorizontalAlignment = 1;
                table1.AddCell(cell7);
                PdfPCell cell8 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell8.Border = 0;
                cell8.HorizontalAlignment = 1;
                table1.AddCell(cell8);
                PdfPCell cell9 = new PdfPCell(new Phrase(pCabecera.Serie_Documento + " - " + pCabecera.Numero_Documento, font));
                cell9.Border = 0;
                cell9.HorizontalAlignment = 1;
                table1.AddCell(cell9);
                PdfPCell cell10 = new PdfPCell(new Phrase("Señor(es) : " + pCabecera.RSocial_Receptor, font));
                cell10.Border = 0;
                cell10.HorizontalAlignment = 0;
                table1.AddCell(cell10);
                PdfPCell cell11 = new PdfPCell(new Phrase("Dirección : " + pCabecera.Direccion_Receptor, font));
                cell11.Border = 0;
                cell11.HorizontalAlignment = 0;
                table1.AddCell(cell11);
                PdfPCell cell12 = new PdfPCell(new Phrase("R.U.C. N° : " + pCabecera.NroDoc_Receptor, font));
                cell12.Border = 0;
                cell12.HorizontalAlignment = 0;
                table1.AddCell(cell12);
                PdfPCell cell13 = new PdfPCell(new Phrase("Fecha de Emisión: " + Convert.ToDateTime(pCabecera.Fecha_Emision).ToString("dd/MM/yyyy") + " " + pCabecera.Hora_Emision, font));
                cell13.Border = 0;
                cell13.HorizontalAlignment = 0;
                table1.AddCell(cell13);
                PdfPCell cell14 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell14.PaddingBottom = 0;
                cell14.Border = 0;
                cell14.HorizontalAlignment = 1;
                table1.AddCell(cell14);
                PdfPTable table2 = new PdfPTable(4);
                table2.HorizontalAlignment = 0;
                table2.WidthPercentage = 100f;
                table2.SetWidths(new float[4] { 30f, 120f, 50f, 50f });
                PdfPCell cell15 = new PdfPCell(new Phrase("CANT", font));
                cell15.PaddingTop = 0;
                cell15.PaddingBottom = 0;
                cell15.HorizontalAlignment = 0;
                cell15.Border = 0;
                table2.AddCell(cell15);
                PdfPCell cell16 = new PdfPCell(new Phrase("DESCRIPCION", font));
                cell16.PaddingTop = 0;
                cell16.PaddingBottom = 0;
                cell16.HorizontalAlignment = 0;
                cell16.Border = 0;
                table2.AddCell(cell16);
                PdfPCell cell17 = new PdfPCell(new Phrase("P.UNI.", font));
                cell17.PaddingTop = 0;
                cell17.PaddingBottom = 0;
                cell17.HorizontalAlignment = 2;
                cell17.Border = 0;
                table2.AddCell(cell17);
                PdfPCell cell18 = new PdfPCell(new Phrase("TOTAL", font));
                cell18.PaddingTop = 0;
                cell18.PaddingBottom = 0;
                cell18.HorizontalAlignment = 2;
                cell18.Border = 0;
                table2.AddCell(cell18);
                table1.AddCell(table2);
                PdfPCell cell27 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell27.PaddingTop = 0;
                cell27.Border = 0;
                cell27.HorizontalAlignment = 1;
                table1.AddCell(cell27);
                PdfPTable table3 = new PdfPTable(4);
                table3.HorizontalAlignment = 0;
                table3.WidthPercentage = 100f;
                table3.SetWidths(new float[4] { 30f, 120f, 50f, 50f });
                List<ComprobanteDetalle> comprobanteDetalle = pCabecera.LstComprobanteDetalle;
                int count = comprobanteDetalle.Count;
                int num1 = 30;
                int num2 = num1 - 1;
                for (int index = 0; index < count; ++index)
                {
                    PdfPCell cell19 = new PdfPCell(new Phrase(comprobanteDetalle[index].Cantidad.ToString(), font));
                    cell19.PaddingTop = 2;
                    cell19.PaddingBottom = 2;
                    cell19.Border = 0;
                    cell19.HorizontalAlignment = 0;
                    table3.AddCell(cell19);
                    PdfPCell cell20 = new PdfPCell(new Phrase(comprobanteDetalle[index].Descripcion_Articulo, font));
                    cell20.PaddingTop = 2;
                    cell20.PaddingBottom = 2;
                    cell20.Border = 0;
                    cell20.HorizontalAlignment = 0;
                    table3.AddCell(cell20);
                    PdfPCell cell21 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Precio_Unitario_SinIGV.ToString("#0.00"), font));
                    cell21.PaddingTop = 2;
                    cell21.PaddingBottom = 2;
                    cell21.Border = 0;
                    cell21.HorizontalAlignment = 2;
                    table3.AddCell(cell21);
                    PdfPCell cell22 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Importe_SubTotal.ToString("#,##0.00"), font));
                    cell22.PaddingTop = 2;
                    cell22.PaddingBottom = 2;
                    cell22.Border = 0;
                    cell22.HorizontalAlignment = 2;
                    table3.AddCell(cell22);
                }
                table1.AddCell(table3);
                PdfPTable pdfPtable4 = new PdfPTable(3);
                pdfPtable4.HorizontalAlignment = 0;
                pdfPtable4.WidthPercentage = 100f;
                pdfPtable4.SetWidths(new float[3] { 150f, 20f, 100f });
                PdfPCell cell28 = new PdfPCell(new Phrase("Operación Gravada", font));
                cell28.Border = 0;
                pdfPtable4.AddCell(cell28);
                PdfPCell cell29 = new PdfPCell(new Phrase(pMoneda, font));
                cell29.Border = 0;
                pdfPtable4.AddCell(cell29);
                PdfPCell cell30 = new PdfPCell(new Phrase(pCabecera.Importe_Gravado.ToString("#,##0.00"), font));
                cell30.Border = 0;
                cell30.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell30);
                PdfPCell cell31 = new PdfPCell(new Phrase("Operación Exonerada", font));
                cell31.Border = 0;
                pdfPtable4.AddCell(cell31);
                PdfPCell cell32 = new PdfPCell(new Phrase(pMoneda, font));
                cell32.Border = 0;
                pdfPtable4.AddCell(cell32);
                PdfPCell cell33 = new PdfPCell(new Phrase(pCabecera.Importe_Exonerado.ToString("#,##0.00"), font));
                cell33.Border = 0;
                cell33.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell33);
                PdfPCell cell34 = new PdfPCell(new Phrase("Operación Inafecta", font));
                cell34.Border = 0;
                pdfPtable4.AddCell(cell34);
                PdfPCell cell35 = new PdfPCell(new Phrase(pMoneda, font));
                cell35.Border = 0;
                pdfPtable4.AddCell(cell35);
                PdfPCell cell36 = new PdfPCell(new Phrase(pCabecera.Importe_Inafecto.ToString("#,##0.00"), font));
                cell36.Border = 0;
                cell36.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell36);
                PdfPCell cell37 = new PdfPCell(new Phrase("Operación Gratuita", font));
                cell37.Border = 0;
                pdfPtable4.AddCell(cell37);
                PdfPCell cell38 = new PdfPCell(new Phrase(pMoneda, font));
                cell38.Border = 0;
                pdfPtable4.AddCell(cell38);
                PdfPCell cell39 = new PdfPCell(new Phrase(pCabecera.Importe_Gratuito.ToString("#,##0.00"), font));
                cell39.Border = 0;
                cell39.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell39);
                //PdfPCell cell40 = new PdfPCell(new Phrase("Anticipos", font2));
                //cell40.Border = 0;
                //pdfPtable4.AddCell(cell40);
                //PdfPCell cell41 = new PdfPCell(new Phrase(pMoneda, font2));
                //cell41.Border = 0;
                //pdfPtable4.AddCell(cell41);
                //PdfPCell cell42 = new PdfPCell(new Phrase(pCabecera.Importe_Anticipos.ToString("#,##0.00"), font2));
                //cell42.Border = 0;
                //cell42.HorizontalAlignment = 2;
                //pdfPtable4.AddCell(cell42);
                //PdfPCell cell43 = new PdfPCell(new Phrase("Total Descuento", font2));
                //cell43.Border = 0;
                //pdfPtable4.AddCell(cell43);
                //PdfPCell cell44 = new PdfPCell(new Phrase(pMoneda, font2));
                //cell44.Border = 0;
                //pdfPtable4.AddCell(cell44);
                //PdfPCell cell45 = new PdfPCell(new Phrase(pCabecera.Importe_DctoGlobal.ToString("#,##0.00"), font2));
                //cell45.Border = 0;
                //cell45.HorizontalAlignment = 2;
                //pdfPtable4.AddCell(cell45);
                PdfPCell cell46 = new PdfPCell(new Phrase("I.G.V. (" + this.IGV + "%)", font));
                cell46.Border = 0;
                pdfPtable4.AddCell(cell46);
                PdfPCell cell47 = new PdfPCell(new Phrase(pMoneda, font));
                cell47.Border = 0;
                pdfPtable4.AddCell(cell47);
                PdfPCell cell48 = new PdfPCell(new Phrase(pCabecera.Importe_IGV.ToString("#,##0.00"), font));
                cell48.Border = 0;
                cell48.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell48);
                if (pCabecera.Importe_Percepcion == new Decimal(0))
                {
                    PdfPCell cell21 = new PdfPCell(new Phrase("Importe Total", font));
                    cell21.Border = 0;
                    pdfPtable4.AddCell(cell21);
                    PdfPCell cell22 = new PdfPCell(new Phrase(pMoneda, font));
                    cell22.Border = 0;
                    pdfPtable4.AddCell(cell22);
                    PdfPCell cell23 = new PdfPCell(new Phrase(pCabecera.Importe_Total.ToString("#,##0.00"), font));
                    cell23.Border = 0;
                    cell23.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell23);
                }
                else
                {
                    PdfPCell cell21 = new PdfPCell(new Phrase("Total a Pagar", font));
                    cell21.Border = 0;
                    pdfPtable4.AddCell(cell21);
                    PdfPCell cell22 = new PdfPCell(new Phrase(pMoneda, font));
                    cell22.Border = 0;
                    pdfPtable4.AddCell(cell22);
                    PdfPCell cell23 = new PdfPCell(new Phrase(pCabecera.Importe_Total.ToString("#,##0.00"), font));
                    cell23.Border = 0;
                    cell23.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell23);
                    PdfPCell cell24 = new PdfPCell(new Phrase("Percepción", font));
                    cell24.Border = 0;
                    pdfPtable4.AddCell(cell24);
                    PdfPCell cell25 = new PdfPCell(new Phrase(pMoneda, font));
                    cell25.Border = 0;
                    pdfPtable4.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase(pCabecera.Importe_Percepcion.ToString("#,##0.00"), font));
                    cell26.Border = 0;
                    cell26.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell26);
                    PdfPCell cell107 = new PdfPCell(new Phrase("Importe Total", font));
                    cell107.Border = 0;
                    pdfPtable4.AddCell(cell107);
                    PdfPCell cell49 = new PdfPCell(new Phrase(pMoneda, font));
                    cell49.Border = 0;
                    pdfPtable4.AddCell(cell49);
                    PdfPCell cell50 = new PdfPCell(new Phrase(pCabecera.Importe_Cobrado.ToString("#,##0.00"), font));
                    cell50.Border = 0;
                    cell50.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell50);
                }
                table1.AddCell(pdfPtable4);
                PdfPTable pdfPtable5 = new PdfPTable(2);
                pdfPtable5.HorizontalAlignment = 0;
                pdfPtable5.WidthPercentage = 100f;
                pdfPtable5.SetWidths(new float[2] { 30f, 200f });
                PdfPCell cell51 = new PdfPCell(new Phrase("SON: ", font));
                cell51.HorizontalAlignment = 0;
                cell51.Border = 0;
                pdfPtable5.AddCell(cell51);
                PdfPCell cell53 = new PdfPCell(new Phrase(pCabecera.Texto_Importe_Total, font));
                cell53.HorizontalAlignment = 0;
                cell53.Border = 0;
                pdfPtable5.AddCell(cell53);
                table1.AddCell(pdfPtable5);
                PdfPCell cell210 = new PdfPCell(new Phrase("Representación gráfica del documento electrónico," + Environment.NewLine + "puede ser consultado en la siguiente página: " + Environment.NewLine + this.LINK_DESCARGA_ARCHIVOS, font));
                cell210.Border = 0;
                cell210.HorizontalAlignment = 1;
                table1.AddCell(cell210);
                PdfPCell cell211 = new PdfPCell(new Phrase("GRACIAS POR SU PREFERENCIA", font));
                cell211.Border = 0;
                cell211.HorizontalAlignment = 1;
                table1.AddCell(cell211);
                string[] strArray1 = new string[10];
                strArray1[0] = pCabecera.NroDoc_Emisor + "|" + pCabecera.Codigo_Documento + "|" + pCabecera.Serie_Documento + "|" + pCabecera.Numero_Documento + "|" + (object)pCabecera.Importe_IGV;
                strArray1[1] = "|";
                strArray1[2] = pCabecera.Importe_Total.ToString();
                strArray1[3] = "|";
                strArray1[4] = pCabecera.Fecha_Emision.ToString("dd-MM-yyyy");
                strArray1[5] = "|";
                strArray1[6] = pCabecera.TipoDoc_Receptor;
                strArray1[7] = "|";
                strArray1[8] = pCabecera.NroDoc_Receptor;
                strArray1[9] = "|";
                iTextSharp.text.Image image = GenerarArchivo.RetornarCodigoQR(string.Concat(strArray1));
                image.SetAbsolutePosition(0.0f, 0.0f);
                iTextSharp.text.Rectangle pageSize = instance1.PageSize;
                PdfTemplate template = new PdfContentByte(instance1).CreateTemplate(400f, 100f);
                template.AddImage(image);
                pdfPtable1.AddCell(table1);
                PdfContentByte directContent = instance1.DirectContent;
                directContent.BeginText();
                directContent.AddTemplate(template, 75f, 5f);
                directContent.EndText();
                directContent.Stroke();
                document.Add((IElement)pdfPtable1);
                document.Close();
                byte[] array = memoryStream.ToArray();
                System.IO.File.WriteAllBytes(pFileName, array);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraPDFA4Boleta(ComprobanteCabecera pCabecera, string pMoneda, string pDigestValue, string pSignature, string pFileName)
        {
            try
            {
                PdfPCell pdfPcell = new PdfPCell();
                string appSetting = ConfigurationManager.AppSettings["LOGO_EMPRESA"];
                if (pCabecera == null)
                    return;
                Document document = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance1 = PdfWriter.GetInstance(document, (Stream)memoryStream);
                iTextSharp.text.Font font1 = FontFactory.GetFont("Verdana", 12f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font2 = FontFactory.GetFont("Verdana", 10f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font3 = FontFactory.GetFont("Verdana", 6.5f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                BaseColor baseColor = new BaseColor(ColorTranslator.FromHtml("#EBEBEB"));
                document.Open();
                PdfPTable pdfPtable1 = new PdfPTable(3);
                pdfPtable1.HorizontalAlignment = 0;
                pdfPtable1.WidthPercentage = 100f;
                pdfPtable1.DefaultCell.Border = 0;
                PdfPTable table1 = new PdfPTable(1);
                table1.HorizontalAlignment = 0;
                table1.DefaultCell.Border = 0;
                iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance(appSetting);
                instance2.ScalePercent(30f);
                PdfPCell cell1 = new PdfPCell(instance2);
                cell1.Border = 0;
                cell1.HorizontalAlignment = 0;
                table1.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("", font2)); //pCabecera.RSocial_Emisor
                cell2.PaddingTop = 5f;
                cell2.Border = 0;
                cell2.HorizontalAlignment = 0;
                table1.AddCell(cell2);
                pdfPtable1.AddCell(table1);
                PdfPTable table2 = new PdfPTable(1);
                table2.HorizontalAlignment = 1;
                table2.DefaultCell.Border = 0;
                PdfPCell cell3 = new PdfPCell(new Phrase("Oficina Principal", font3));
                cell3.PaddingTop = 20f;
                cell3.Border = 0;
                cell3.HorizontalAlignment = 1;
                table2.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase(pCabecera.Direccion_Emisor, font3));
                cell4.Border = 0;
                cell4.HorizontalAlignment = 1;
                table2.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(pCabecera.Dist_Emisor + " - " + pCabecera.Prov_Emisor + " - " + pCabecera.Dpto_Emisor, font3));
                cell5.Border = 0;
                cell5.HorizontalAlignment = 1;
                table2.AddCell(cell5);
                pdfPtable1.AddCell(table2);
                PdfPTable table3 = new PdfPTable(1);
                table3.HorizontalAlignment = 1;
                PdfPCell cell6 = new PdfPCell(new Phrase("R.U.C. N° " + pCabecera.NroDoc_Emisor, font1));
                cell6.PaddingTop = 10f;
                cell6.Border = 13;
                cell6.HorizontalAlignment = 1;
                table3.AddCell(cell6);
                if (pCabecera.Codigo_Documento == "03")
                    cell6 = new PdfPCell(new Phrase("BOLETA DE VENTA ELECTRONICA", font1));
                else if (pCabecera.Codigo_Documento == "07")
                    cell6 = new PdfPCell(new Phrase("NOTA DE CREDITO ELECTRONICA", font1));
                else if (pCabecera.Codigo_Documento == "08")
                    cell6 = new PdfPCell(new Phrase("NOTA DE DEBITO ELECTRONICA", font1));
                cell6.PaddingTop = 5f;
                cell6.Border = 12;
                cell6.HorizontalAlignment = 1;
                table3.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase(pCabecera.Serie_Documento + " - " + pCabecera.Numero_Documento, font1));
                cell7.PaddingTop = 5f;
                cell7.Border = 12;
                cell7.HorizontalAlignment = 1;
                table3.AddCell(cell7);
                PdfPCell cell8 = new PdfPCell(new Phrase(" "));
                cell8.PaddingTop = 5f;
                cell8.Border = 14;
                cell8.HorizontalAlignment = 1;
                table3.AddCell(cell8);
                pdfPtable1.AddCell(table3);
                PdfPTable pdfPtable2 = new PdfPTable(4);
                pdfPtable2.HorizontalAlignment = 0;
                pdfPtable2.WidthPercentage = 100f;
                pdfPtable2.SpacingBefore = 5f;
                pdfPtable2.SetWidths(new float[4]
                {
                    90f,
                    90f,
                    90f,
                    90f
                });
                PdfPCell cell9 = new PdfPCell(new Phrase("Señor(es) : " + pCabecera.RSocial_Receptor, font3));
                cell9.Colspan = 4;
                cell9.Border = 13;
                cell9.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell9);
                PdfPCell cell10 = new PdfPCell(new Phrase("Dirección : " + pCabecera.Direccion_Receptor, font3));
                cell10.Colspan = 4;
                cell10.PaddingTop = 5f;
                cell10.Border = 12;
                cell10.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell10);
                PdfPCell cell11 = new PdfPCell(new Phrase("D.N.I. N° : " + pCabecera.NroDoc_Receptor, font3));
                cell11.Colspan = 3;
                cell11.PaddingTop = 5f;
                cell11.PaddingBottom = 10f;
                cell11.Border = 6;
                cell11.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell11);
                PdfPCell cell12 = new PdfPCell(new Phrase("Fecha de Emisión: " + Convert.ToDateTime(pCabecera.Fecha_Emision).ToString("dd/MM/yyyy"), font3));
                cell12.PaddingTop = 5f;
                cell12.PaddingBottom = 10f;
                cell12.Border = 10;
                cell12.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell12);
                if (pCabecera.Codigo_Documento != "03")
                {
                    PdfPCell cell13 = new PdfPCell(new Phrase("DOCUMENTO QUE MODIFICA", font3));
                    cell13.Colspan = 2;
                    cell13.Border = 5;
                    cell13.HorizontalAlignment = 0;
                    pdfPtable2.AddCell(cell13);
                    PdfPCell cell14 = new PdfPCell(new Phrase("MOTIVO" + (pCabecera.Codigo_Documento_Ref == "03" ? pCabecera.Documento_Ref : ""), font3));
                    cell14.Colspan = 2;
                    cell14.PaddingTop = 5f;
                    cell14.Border = 8;
                    cell14.HorizontalAlignment = 0;
                    pdfPtable2.AddCell(cell14);
                    PdfPCell cell15 = new PdfPCell(new Phrase("Boleta de Venta N°: " + pCabecera.Documento_Ref, font3));
                    cell15.Colspan = 2;
                    cell15.PaddingTop = 5f;
                    cell15.Border = 6;
                    cell15.HorizontalAlignment = 0;
                    pdfPtable2.AddCell(cell15);
                    PdfPCell cell16 = new PdfPCell(new Phrase(pCabecera.Descripcion_Motivo_Ref, font3));
                    cell16.Colspan = 2;
                    cell16.PaddingTop = 5f;
                    cell16.Border = 10;
                    cell16.HorizontalAlignment = 0;
                    pdfPtable2.AddCell(cell16);
                }
                PdfPTable pdfPtable3 = new PdfPTable(7);
                pdfPtable3.HorizontalAlignment = 0;
                pdfPtable3.WidthPercentage = 100f;
                pdfPtable3.SpacingBefore = 5f;
                pdfPtable3.SetWidths(new float[7]
                {
                    15f,
                    50f,
                    230f,
                    30f,
                    50f,
                    50f,
                    50f
                });
                PdfPCell cell17 = new PdfPCell(new Phrase("N°", font3));
                cell17.BackgroundColor = baseColor;
                cell17.HorizontalAlignment = 1;
                cell17.PaddingTop = 5f;
                cell17.PaddingBottom = 5f;
                cell17.Border = 15;
                pdfPtable3.AddCell(cell17);
                PdfPCell cell18 = new PdfPCell(new Phrase("CODIGO", font3));
                cell18.BackgroundColor = baseColor;
                cell18.HorizontalAlignment = 1;
                cell18.PaddingTop = 5f;
                cell18.PaddingBottom = 5f;
                cell18.Border = 15;
                pdfPtable3.AddCell(cell18);
                PdfPCell cell19 = new PdfPCell(new Phrase("DESCRIPCION", font3));
                cell19.BackgroundColor = baseColor;
                cell19.HorizontalAlignment = 1;
                cell19.PaddingTop = 5f;
                cell19.PaddingBottom = 5f;
                cell19.Border = 15;
                pdfPtable3.AddCell(cell19);
                PdfPCell cell20 = new PdfPCell(new Phrase("U.M.", font3));
                cell20.BackgroundColor = baseColor;
                cell20.HorizontalAlignment = 1;
                cell20.PaddingTop = 5f;
                cell20.PaddingBottom = 5f;
                cell20.Border = 15;
                pdfPtable3.AddCell(cell20);
                PdfPCell cell21 = new PdfPCell(new Phrase("CANTIDAD", font3));
                cell21.BackgroundColor = baseColor;
                cell21.HorizontalAlignment = 1;
                cell21.PaddingTop = 5f;
                cell21.PaddingBottom = 5f;
                cell21.Border = 15;
                pdfPtable3.AddCell(cell21);
                PdfPCell cell22 = new PdfPCell(new Phrase("PRECIO UNIT.", font3));
                cell22.BackgroundColor = baseColor;
                cell22.HorizontalAlignment = 1;
                cell22.PaddingTop = 5f;
                cell22.PaddingBottom = 5f;
                cell22.Border = 15;
                pdfPtable3.AddCell(cell22);
                PdfPCell cell23 = new PdfPCell(new Phrase("TOTAL", font3));
                cell23.BackgroundColor = baseColor;
                cell23.HorizontalAlignment = 1;
                cell23.PaddingTop = 5f;
                cell23.PaddingBottom = 5f;
                cell23.Border = 15;
                pdfPtable3.AddCell(cell23);
                List<ComprobanteDetalle> comprobanteDetalle = pCabecera.LstComprobanteDetalle;
                int count = comprobanteDetalle.Count;
                int num1 = 30;
                int num2 = num1 - 1;
                for (int index = 0; index < num1; ++index)
                {
                    if (index < count)
                    {
                        PdfPCell cell13 = new PdfPCell(new Phrase(comprobanteDetalle[index].NroItem, font3));
                        cell13.Border = 14;
                        cell13.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell13);
                        PdfPCell cell14 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Codigo_Articulo, font3));
                        cell14.Border = 14;
                        cell14.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell14);
                        PdfPCell cell15 = new PdfPCell(new Phrase(comprobanteDetalle[index].Descripcion_Articulo, font3));
                        cell15.Border = 14;
                        cell15.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell15);
                        PdfPCell cell16 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Codigo_Unidad, font3));
                        cell16.Border = 14;
                        cell16.HorizontalAlignment = 1;
                        pdfPtable3.AddCell(cell16);
                        PdfPCell cell24 = new PdfPCell(new Phrase(comprobanteDetalle[index].Cantidad.ToString(), font3));
                        cell24.Border = 14;
                        cell24.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell24);
                        PdfPCell cell25 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Precio_Unitario_ConIGV.ToString("#0.00"), font3));
                        cell25.Border = 14;
                        cell25.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell25);
                        PdfPCell cell26 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Importe_SubTotal.ToString("#,##0.00"), font3));
                        cell26.Border = 14;
                        cell26.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell26);
                    }
                    else
                    {
                        PdfPCell cell13 = new PdfPCell(new Phrase(" ", font3));
                        cell13.Border = num2 == index ? 14 : 12;
                        cell13.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell13);
                        PdfPCell cell14 = new PdfPCell(new Phrase(" ", font3));
                        cell14.Border = num2 == index ? 14 : 12;
                        cell14.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell14);
                        PdfPCell cell15 = new PdfPCell(new Phrase(" ", font3));
                        cell15.Border = num2 == index ? 14 : 12;
                        cell15.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell15);
                        PdfPCell cell16 = new PdfPCell(new Phrase(" ", font3));
                        cell16.Border = num2 == index ? 14 : 12;
                        cell16.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell16);
                        PdfPCell cell24 = new PdfPCell(new Phrase(" ", font3));
                        cell24.Border = num2 == index ? 14 : 12;
                        cell24.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell24);
                        PdfPCell cell25 = new PdfPCell(new Phrase(" ", font3));
                        cell25.Border = num2 == index ? 14 : 12;
                        cell25.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell25);
                        PdfPCell cell26 = new PdfPCell(new Phrase(" ", font3));
                        cell26.Border = num2 == index ? 14 : 12;
                        cell26.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell26);
                    }
                }
                PdfPTable pdfPtable4 = new PdfPTable(3);
                pdfPtable4.HorizontalAlignment = 0;
                pdfPtable4.WidthPercentage = 100f;
                pdfPtable4.SetWidths(new float[3] { 150f, 20f, 100f });
                PdfPCell cell27 = new PdfPCell(new Phrase("Sub Total", font3));
                cell27.Border = 0;
                cell27.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell27);
                PdfPCell cell28 = new PdfPCell(new Phrase(pMoneda, font3));
                cell28.Border = 0;
                pdfPtable4.AddCell(cell28);
                PdfPCell cell29 = new PdfPCell(new Phrase(pCabecera.Importe_SubTotal.ToString("#,##0.00"), font3));
                cell29.Border = 0;
                cell29.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell29);
                PdfPCell cell30 = new PdfPCell(new Phrase("Anticipos", font3));
                cell30.Border = 0;
                cell30.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell30);
                PdfPCell cell31 = new PdfPCell(new Phrase(pMoneda, font3));
                cell31.Border = 0;
                pdfPtable4.AddCell(cell31);
                PdfPCell cell32 = new PdfPCell(new Phrase(pCabecera.Importe_Anticipos.ToString("#,##0.00"), font3));
                cell32.Border = 0;
                cell32.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell32);
                PdfPCell cell33 = new PdfPCell(new Phrase("Total Descuento", font3));
                cell33.Border = 0;
                cell33.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell33);
                PdfPCell cell34 = new PdfPCell(new Phrase(pMoneda, font3));
                cell34.Border = 0;
                pdfPtable4.AddCell(cell34);
                PdfPCell cell35 = new PdfPCell(new Phrase(pCabecera.Importe_DctoGlobal.ToString("#,##0.00"), font3));
                cell35.Border = 0;
                cell35.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell35);
                PdfPCell cell36 = new PdfPCell(new Phrase("Importe Total", font3));
                cell36.Border = 0;
                cell36.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell36);
                PdfPCell cell37 = new PdfPCell(new Phrase(pMoneda, font3));
                cell37.Border = 0;
                pdfPtable4.AddCell(cell37);
                PdfPCell cell38 = new PdfPCell(new Phrase(pCabecera.Importe_Total.ToString("#,##0.00"), font3));
                cell38.Border = 0;
                cell38.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell38);
                PdfPCell cell39 = new PdfPCell(new Phrase("SON:", font3));
                cell39.Colspan = 3;
                cell39.Border = 14;
                pdfPtable3.AddCell(cell39);
                PdfPCell cell40 = new PdfPCell(new Phrase(" ", font3));
                cell40.Colspan = 4;
                cell40.Border = 0;
                pdfPtable3.AddCell(cell40);
                PdfPCell cell41 = new PdfPCell(new Phrase(pCabecera.Texto_Importe_Total, font3));
                cell41.Colspan = 3;
                cell41.PaddingLeft = 10f;
                cell41.PaddingBottom = 40f;
                cell41.Border = 14;
                pdfPtable3.AddCell(cell41);
                PdfPCell cell42 = new PdfPCell(new Phrase(" ", font3));
                cell42.Colspan = 4;
                cell42.Rowspan = 9;
                cell42.Border = 0;
                cell42.AddElement((IElement)pdfPtable4);
                pdfPtable3.AddCell(cell42);
                PdfPCell cell43 = new PdfPCell(new Phrase(" ", font3));
                cell43.Colspan = 3;
                cell43.Border = 0;
                pdfPtable3.AddCell(cell43);
                PdfPCell cell44 = new PdfPCell(new Phrase("Código Hash", font3));
                cell44.Colspan = 3;
                cell44.Border = 15;
                pdfPtable3.AddCell(cell44);
                PdfPCell cell45 = new PdfPCell(new Phrase(pDigestValue, font3));
                cell45.Colspan = 3;
                cell45.Border = 14;
                cell45.PaddingLeft = 10f;
                pdfPtable3.AddCell(cell45);
                PdfPCell cell46 = new PdfPCell(new Phrase(" ", font3));
                cell46.Colspan = 3;
                cell46.Border = 0;
                pdfPtable3.AddCell(cell46);
                PdfPCell cell47 = new PdfPCell(new Phrase(" ", font3));
                cell47.Colspan = 7;
                cell47.Border = 0;
                pdfPtable3.AddCell(cell47);
                string empty = string.Empty;
                iTextSharp.text.Image image = GenerarArchivo.RetornarCodigoQR(pCabecera.NroDoc_Emisor + "|" + pCabecera.Codigo_Documento + "|" + pCabecera.Serie_Documento + "|" + pCabecera.Numero_Documento + "|" + pCabecera.Importe_Total.ToString() + "|" + pCabecera.Fecha_Emision.ToString("DD-MM-YY") + "|");
                image.SetAbsolutePosition(0.0f, 0.0f);
                iTextSharp.text.Rectangle pageSize = instance1.PageSize;
                PdfTemplate template = new PdfContentByte(instance1).CreateTemplate(400f, 100f);
                template.AddImage(image);
                BaseFont font4 = BaseFont.CreateFont("Helvetica", "Cp1250", true);
                PdfContentByte pdfContentByte = new PdfContentByte(instance1);
                PdfContentByte directContent = instance1.DirectContent;
                directContent.BeginText();
                directContent.SetFontAndSize(font4, 6.5f);
                directContent.ShowTextAligned(0, "Representación gráfica del documento electrónico, este puede ser consultado en " + this.LINK_DESCARGA_ARCHIVOS, 30f, 45f, 0.0f);
                directContent.EndText();
                directContent.BeginText();
                directContent.SetFontAndSize(font4, 6.5f);
                directContent.ShowTextAligned(0, "Autorizado mediante Resolución N°." + this.NRO_RESOLUCION + "/SUNAT.", 30f, 35f, 0.0f);
                directContent.EndText();
                directContent.AddTemplate(template, 25f, 55f);
                directContent.Stroke();
                document.Add((IElement)pdfPtable1);
                document.Add((IElement)pdfPtable2);
                document.Add((IElement)pdfPtable3);
                document.Close();
                byte[] array = memoryStream.ToArray();
                System.IO.File.WriteAllBytes(pFileName, array);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraPDFTicketBoleta(ComprobanteCabecera pCabecera, string pMoneda, string pDigestValue, string pSignature, string pFileName)
        {
            try
            {
                string appSetting = ConfigurationManager.AppSettings["LOGO_EMPRESA"];
                if (pCabecera == null)
                    return;
                Document document = new Document(new iTextSharp.text.Rectangle(220f, (440f + (pCabecera.LstComprobanteDetalle.Count * 7))), 1f, 1f, 1f, 1f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance1 = PdfWriter.GetInstance(document, (Stream)memoryStream);
                iTextSharp.text.Font font = FontFactory.GetFont("Verdana", 7f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                document.Open();
                PdfPTable pdfPtable1 = new PdfPTable(1);
                pdfPtable1.HorizontalAlignment = 0;
                pdfPtable1.WidthPercentage = 100f;
                pdfPtable1.DefaultCell.Border = 0;
                PdfPTable table1 = new PdfPTable(1);
                table1.HorizontalAlignment = 0;
                table1.DefaultCell.Border = 0;
                iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance(appSetting);
                instance2.ScalePercent(6f);
                PdfPCell cell1 = new PdfPCell(instance2);
                cell1.Border = 0;
                cell1.HorizontalAlignment = 1;
                table1.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase(pCabecera.RSocial_Emisor, font));
                cell2.PaddingTop = 5f;
                cell2.Border = 0;
                cell2.HorizontalAlignment = 1;
                table1.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("R.U.C. N° " + pCabecera.NroDoc_Emisor, font));
                cell3.Border = 0;
                cell3.HorizontalAlignment = 1;
                table1.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase(pCabecera.Direccion_Emisor, font));
                cell4.Border = 0;
                cell4.HorizontalAlignment = 1;
                table1.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(pCabecera.Dist_Emisor + " - " + pCabecera.Prov_Emisor + " - " + pCabecera.Dpto_Emisor, font));
                cell5.Border = 0;
                cell5.HorizontalAlignment = 1;
                table1.AddCell(cell5);
                PdfPCell cell6 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell6.Border = 0;
                cell6.HorizontalAlignment = 1;
                table1.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("BOLETA DE VENTA ELECTRONICA", font));
                cell7.Border = 0;
                cell7.HorizontalAlignment = 1;
                table1.AddCell(cell7);
                PdfPCell cell8 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell8.Border = 0;
                cell8.HorizontalAlignment = 1;
                table1.AddCell(cell8);
                PdfPCell cell9 = new PdfPCell(new Phrase(pCabecera.Serie_Documento + " - " + pCabecera.Numero_Documento, font));
                cell9.Border = 0;
                cell9.HorizontalAlignment = 1;
                table1.AddCell(cell9);
                PdfPCell cell10 = new PdfPCell(new Phrase("Señor(es) : " + pCabecera.RSocial_Receptor, font));
                cell10.Border = 0;
                cell10.HorizontalAlignment = 0;
                table1.AddCell(cell10);
                PdfPCell cell11 = new PdfPCell(new Phrase("Dirección : " + pCabecera.Direccion_Receptor, font));
                cell11.Border = 0;
                cell11.HorizontalAlignment = 0;
                table1.AddCell(cell11);
                PdfPCell cell12 = new PdfPCell(new Phrase("D.N.I. N° : " + pCabecera.NroDoc_Receptor, font));
                cell12.Border = 0;
                cell12.HorizontalAlignment = 0;
                table1.AddCell(cell12);
                PdfPCell cell13 = new PdfPCell(new Phrase("Fecha de Emisión: " + Convert.ToDateTime(pCabecera.Fecha_Emision).ToString("dd/MM/yyyy") + " " + pCabecera.Hora_Emision, font));
                cell13.Border = 0;
                cell13.HorizontalAlignment = 0;
                table1.AddCell(cell13);
                PdfPCell cell14 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell14.PaddingBottom = 0;
                cell14.Border = 0;
                cell14.HorizontalAlignment = 1;
                table1.AddCell(cell14);
                PdfPTable table2 = new PdfPTable(4);
                table2.HorizontalAlignment = 0;
                table2.WidthPercentage = 100f;
                table2.SetWidths(new float[4] { 30f, 120f, 50f, 50f });
                PdfPCell cell15 = new PdfPCell(new Phrase("CANT", font));
                cell15.PaddingTop = 0;
                cell15.PaddingBottom = 0;
                cell15.HorizontalAlignment = 0;
                cell15.Border = 0;
                table2.AddCell(cell15);
                PdfPCell cell16 = new PdfPCell(new Phrase("DESCRIPCION", font));
                cell16.PaddingTop = 0;
                cell16.PaddingBottom = 0;
                cell16.HorizontalAlignment = 0;
                cell16.Border = 0;
                table2.AddCell(cell16);
                PdfPCell cell17 = new PdfPCell(new Phrase("P.UNI.", font));
                cell17.PaddingTop = 0;
                cell17.PaddingBottom = 0;
                cell17.HorizontalAlignment = 2;
                cell17.Border = 0;
                table2.AddCell(cell17);
                PdfPCell cell18 = new PdfPCell(new Phrase("TOTAL", font));
                cell18.PaddingTop = 0;
                cell18.PaddingBottom = 0;
                cell18.HorizontalAlignment = 2;
                cell18.Border = 0;
                table2.AddCell(cell18);
                table1.AddCell(table2);
                PdfPCell cell27 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell27.PaddingTop = 0;
                cell27.Border = 0;
                cell27.HorizontalAlignment = 1;
                table1.AddCell(cell27);
                PdfPTable table3 = new PdfPTable(4);
                table3.HorizontalAlignment = 0;
                table3.WidthPercentage = 100f;
                table3.SetWidths(new float[4] { 30f, 120f, 50f, 50f });
                List<ComprobanteDetalle> comprobanteDetalle = pCabecera.LstComprobanteDetalle;
                int count = comprobanteDetalle.Count;
                int num1 = 30;
                int num2 = num1 - 1;
                for (int index = 0; index < count; ++index)
                {
                    PdfPCell cell19 = new PdfPCell(new Phrase(comprobanteDetalle[index].Cantidad.ToString(), font));
                    cell19.PaddingTop = 2;
                    cell19.PaddingBottom = 2;
                    cell19.Border = 0;
                    cell19.HorizontalAlignment = 0;
                    table3.AddCell(cell19);
                    PdfPCell cell20 = new PdfPCell(new Phrase(comprobanteDetalle[index].Descripcion_Articulo, font));
                    cell20.PaddingTop = 2;
                    cell20.PaddingBottom = 2;
                    cell20.Border = 0;
                    cell20.HorizontalAlignment = 0;
                    table3.AddCell(cell20);
                    PdfPCell cell21 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Precio_Unitario_ConIGV.ToString("#0.00"), font));
                    cell21.PaddingTop = 2;
                    cell21.PaddingBottom = 2;
                    cell21.Border = 0;
                    cell21.HorizontalAlignment = 2;
                    table3.AddCell(cell21);
                    PdfPCell cell22 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Importe_Total.ToString("#,##0.00"), font));
                    cell22.PaddingTop = 2;
                    cell22.PaddingBottom = 2;
                    cell22.Border = 0;
                    cell22.HorizontalAlignment = 2;
                    table3.AddCell(cell22);
                }
                table1.AddCell(table3);
                PdfPTable pdfPtable4 = new PdfPTable(3);
                pdfPtable4.HorizontalAlignment = 0;
                pdfPtable4.WidthPercentage = 100f;
                pdfPtable4.SetWidths(new float[3] { 150f, 20f, 100f });
                //PdfPCell cell127 = new PdfPCell(new Phrase("Sub Total", font));
                //cell127.Border = 0;
                //pdfPtable4.AddCell(cell127);
                //PdfPCell cell28 = new PdfPCell(new Phrase(pMoneda, font));
                //cell28.Border = 0;
                //pdfPtable4.AddCell(cell28);
                //PdfPCell cell29 = new PdfPCell(new Phrase(pCabecera.Importe_SubTotal.ToString("#,##0.00"), font));
                //cell29.Border = 0;
                //cell29.HorizontalAlignment = 2;
                //pdfPtable4.AddCell(cell29);
                //PdfPCell cell30 = new PdfPCell(new Phrase("Anticipos", font));
                //cell30.Border = 0;
                //pdfPtable4.AddCell(cell30);
                //PdfPCell cell31 = new PdfPCell(new Phrase(pMoneda, font));
                //cell31.Border = 0;
                //pdfPtable4.AddCell(cell31);
                //PdfPCell cell32 = new PdfPCell(new Phrase(pCabecera.Importe_Anticipos.ToString("#,##0.00"), font));
                //cell32.Border = 0;
                //cell32.HorizontalAlignment = 2;
                //pdfPtable4.AddCell(cell32);
                PdfPCell cell33 = new PdfPCell(new Phrase("Total Descuento", font));
                cell33.Border = 0;
                pdfPtable4.AddCell(cell33);
                PdfPCell cell34 = new PdfPCell(new Phrase(pMoneda, font));
                cell34.Border = 0;
                pdfPtable4.AddCell(cell34);
                PdfPCell cell35 = new PdfPCell(new Phrase(pCabecera.Importe_DctoGlobal.ToString("#,##0.00"), font));
                cell35.Border = 0;
                cell35.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell35);
                PdfPCell cell36 = new PdfPCell(new Phrase("Importe Total", font));
                cell36.Border = 0;
                pdfPtable4.AddCell(cell36);
                PdfPCell cell37 = new PdfPCell(new Phrase(pMoneda, font));
                cell37.Border = 0;
                pdfPtable4.AddCell(cell37);
                PdfPCell cell38 = new PdfPCell(new Phrase(pCabecera.Importe_Total.ToString("#,##0.00"), font));
                cell38.Border = 0;
                cell38.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell38);
                table1.AddCell(pdfPtable4);
                PdfPTable pdfPtable5 = new PdfPTable(2);
                pdfPtable5.HorizontalAlignment = 0;
                pdfPtable5.WidthPercentage = 100f;
                pdfPtable5.SetWidths(new float[2] { 30f, 200f });
                PdfPCell cell51 = new PdfPCell(new Phrase("SON: ", font));
                cell51.HorizontalAlignment = 0;
                cell51.Border = 0;
                pdfPtable5.AddCell(cell51);
                PdfPCell cell53 = new PdfPCell(new Phrase(pCabecera.Texto_Importe_Total, font));
                cell53.HorizontalAlignment = 0;
                cell53.Border = 0;
                pdfPtable5.AddCell(cell53);
                table1.AddCell(pdfPtable5);
                PdfPCell cell210 = new PdfPCell(new Phrase("Representación gráfica del documento electrónico," + Environment.NewLine + "puede ser consultado en la siguiente página: " + Environment.NewLine + this.LINK_DESCARGA_ARCHIVOS, font));
                cell210.Border = 0;
                cell210.HorizontalAlignment = 1;
                table1.AddCell(cell210);
                PdfPCell cell211 = new PdfPCell(new Phrase("GRACIAS POR SU PREFERENCIA", font));
                cell211.Border = 0;
                cell211.HorizontalAlignment = 1;
                table1.AddCell(cell211);
                iTextSharp.text.Image image = GenerarArchivo.RetornarCodigoQR(pCabecera.NroDoc_Emisor + "|" + pCabecera.Codigo_Documento + "|" + pCabecera.Serie_Documento + "|" + pCabecera.Numero_Documento + "|" + pCabecera.Importe_Total.ToString() + "|" + pCabecera.Fecha_Emision.ToString("DD-MM-YY") + "|");
                image.SetAbsolutePosition(0.0f, 0.0f);
                iTextSharp.text.Rectangle pageSize = instance1.PageSize;
                PdfTemplate template = new PdfContentByte(instance1).CreateTemplate(400f, 100f);
                template.AddImage(image);
                pdfPtable1.AddCell(table1);
                PdfContentByte directContent = instance1.DirectContent;
                directContent.BeginText();
                directContent.AddTemplate(template, 75f, 5f);
                directContent.EndText();
                directContent.Stroke();
                document.Add((IElement)pdfPtable1);
                document.Close();
                byte[] array = memoryStream.ToArray();
                System.IO.File.WriteAllBytes(pFileName, array);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraPDFA4NCredito(ComprobanteCabecera pCabecera, string pMoneda, string pDigestValue, string pSignature, string pFileName)
        {
            try
            {
                PdfPCell pdfPcell = new PdfPCell();
                string appSetting = ConfigurationManager.AppSettings["LOGO_EMPRESA"];
                if (pCabecera == null)
                    return;
                Document document = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance1 = PdfWriter.GetInstance(document, (Stream)memoryStream);
                iTextSharp.text.Font font1 = FontFactory.GetFont("Verdana", 12f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font2 = FontFactory.GetFont("Verdana", 10f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font3 = FontFactory.GetFont("Verdana", 6.3f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                BaseColor baseColor = new BaseColor(ColorTranslator.FromHtml("#EBEBEB"));
                document.Open();
                PdfPTable pdfPtable1 = new PdfPTable(3);
                pdfPtable1.HorizontalAlignment = 0;
                pdfPtable1.WidthPercentage = 100f;
                pdfPtable1.DefaultCell.Border = 0;
                PdfPTable table1 = new PdfPTable(1);
                table1.HorizontalAlignment = 0;
                table1.DefaultCell.Border = 0;
                iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance(appSetting);
                instance2.ScalePercent(30f);
                PdfPCell cell1 = new PdfPCell(instance2);
                cell1.Border = 0;
                cell1.HorizontalAlignment = 0;
                table1.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("", font2)); //pCabecera.RSocial_Emisor
                cell2.PaddingTop = 5f;
                cell2.Border = 0;
                cell2.HorizontalAlignment = 0;
                table1.AddCell(cell2);
                pdfPtable1.AddCell(table1);
                PdfPTable table2 = new PdfPTable(1);
                table2.HorizontalAlignment = 1;
                table2.DefaultCell.Border = 0;
                PdfPCell cell3 = new PdfPCell(new Phrase("Oficina Principal", font3));
                cell3.PaddingTop = 20f;
                cell3.Border = 0;
                cell3.HorizontalAlignment = 1;
                table2.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase(pCabecera.Direccion_Emisor, font3));
                cell4.Border = 0;
                cell4.HorizontalAlignment = 1;
                table2.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(pCabecera.Dist_Emisor + " - " + pCabecera.Prov_Emisor + " - " + pCabecera.Dpto_Emisor, font3));
                cell5.Border = 0;
                cell5.HorizontalAlignment = 1;
                table2.AddCell(cell5);
                pdfPtable1.AddCell(table2);
                PdfPTable table3 = new PdfPTable(1);
                table3.HorizontalAlignment = 1;
                PdfPCell cell6 = new PdfPCell(new Phrase("R.U.C. N° " + pCabecera.NroDoc_Emisor, font1));
                cell6.PaddingTop = 10f;
                cell6.Border = 13;
                cell6.HorizontalAlignment = 1;
                table3.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("NOTA DE CREDITO ELECTRONICA", font1));
                cell7.PaddingTop = 5f;
                cell7.Border = 12;
                cell7.HorizontalAlignment = 1;
                table3.AddCell(cell7);
                PdfPCell cell8 = new PdfPCell(new Phrase(pCabecera.Serie_Documento + " - " + pCabecera.Numero_Documento, font1));
                cell8.PaddingTop = 5f;
                cell8.Border = 12;
                cell8.HorizontalAlignment = 1;
                table3.AddCell(cell8);
                PdfPCell cell9 = new PdfPCell(new Phrase(" "));
                cell9.PaddingTop = 5f;
                cell9.Border = 14;
                cell9.HorizontalAlignment = 1;
                table3.AddCell(cell9);
                pdfPtable1.AddCell(table3);
                PdfPTable pdfPtable2 = new PdfPTable(4);
                pdfPtable2.HorizontalAlignment = 0;
                pdfPtable2.WidthPercentage = 100f;
                pdfPtable2.SpacingBefore = 5f;
                pdfPtable2.SetWidths(new float[4]
                {
                    90f,
                    90f,
                    90f,
                    90f
                });
                PdfPCell cell10 = new PdfPCell(new Phrase("Señor(es) : " + pCabecera.RSocial_Receptor, font3));
                cell10.Colspan = 4;
                cell10.Border = 13;
                cell10.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell10);
                PdfPCell cell11 = new PdfPCell(new Phrase("Dirección : " + pCabecera.Direccion_Receptor, font3));
                cell11.Colspan = 4;
                cell11.PaddingTop = 5f;
                cell11.Border = 12;
                cell11.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell11);
                PdfPCell cell12 = new PdfPCell(new Phrase("R.U.C. N° : " + pCabecera.NroDoc_Receptor, font3));
                cell12.Colspan = 3;
                cell12.PaddingTop = 5f;
                cell12.PaddingBottom = 10f;
                cell12.Border = 6;
                cell12.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell12);
                PdfPCell cell13 = new PdfPCell(new Phrase("Fecha de Emisión: " + Convert.ToDateTime(pCabecera.Fecha_Emision).ToString("dd/MM/yyyy"), font3));
                cell13.PaddingTop = 5f;
                cell13.PaddingBottom = 10f;
                cell13.Border = 10;
                cell13.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell13);
                PdfPCell cell14 = new PdfPCell(new Phrase("DOCUMENTO QUE MODIFICA", font3));
                cell14.Colspan = 2;
                cell14.Border = 5;
                cell14.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell14);
                PdfPCell cell15 = new PdfPCell(new Phrase("MOTIVO" + (pCabecera.Codigo_Documento_Ref == "03" ? pCabecera.Documento_Ref : ""), font3));
                cell15.Colspan = 2;
                cell15.PaddingTop = 5f;
                cell15.Border = 8;
                cell15.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell15);
                PdfPCell cell16 = new PdfPCell(new Phrase("Factura N°: " + pCabecera.Documento_Ref, font3));
                cell16.Colspan = 2;
                cell16.PaddingTop = 5f;
                cell16.Border = 6;
                cell16.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell16);
                PdfPCell cell17 = new PdfPCell(new Phrase(pCabecera.Descripcion_Motivo_Ref, font3));
                cell17.Colspan = 2;
                cell17.PaddingTop = 5f;
                cell17.Border = 10;
                cell17.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell17);
                PdfPTable pdfPtable3 = new PdfPTable(7);
                pdfPtable3.HorizontalAlignment = 0;
                pdfPtable3.WidthPercentage = 100f;
                pdfPtable3.SpacingBefore = 5f;
                pdfPtable3.SetWidths(new float[7]
                {
                    15f,
                    50f,
                    230f,
                    30f,
                    50f,
                    50f,
                    50f
                });
                PdfPCell cell18 = new PdfPCell(new Phrase("N°", font3));
                cell18.BackgroundColor = baseColor;
                cell18.HorizontalAlignment = 1;
                cell18.PaddingTop = 5f;
                cell18.PaddingBottom = 5f;
                cell18.Border = 15;
                pdfPtable3.AddCell(cell18);
                PdfPCell cell19 = new PdfPCell(new Phrase("CODIGO", font3));
                cell19.BackgroundColor = baseColor;
                cell19.HorizontalAlignment = 1;
                cell19.PaddingTop = 5f;
                cell19.PaddingBottom = 5f;
                cell19.Border = 15;
                pdfPtable3.AddCell(cell19);
                PdfPCell cell20 = new PdfPCell(new Phrase("DESCRIPCION", font3));
                cell20.BackgroundColor = baseColor;
                cell20.HorizontalAlignment = 1;
                cell20.PaddingTop = 5f;
                cell20.PaddingBottom = 5f;
                cell20.Border = 15;
                pdfPtable3.AddCell(cell20);
                PdfPCell cell21 = new PdfPCell(new Phrase("U.M.", font3));
                cell21.BackgroundColor = baseColor;
                cell21.HorizontalAlignment = 1;
                cell21.PaddingTop = 5f;
                cell21.PaddingBottom = 5f;
                cell21.Border = 15;
                pdfPtable3.AddCell(cell21);
                PdfPCell cell22 = new PdfPCell(new Phrase("CANTIDAD", font3));
                cell22.BackgroundColor = baseColor;
                cell22.HorizontalAlignment = 1;
                cell22.PaddingTop = 5f;
                cell22.PaddingBottom = 5f;
                cell22.Border = 15;
                pdfPtable3.AddCell(cell22);
                PdfPCell cell23 = new PdfPCell(new Phrase("PRECIO UNIT.", font3));
                cell23.BackgroundColor = baseColor;
                cell23.HorizontalAlignment = 1;
                cell23.PaddingTop = 5f;
                cell23.PaddingBottom = 5f;
                cell23.Border = 15;
                pdfPtable3.AddCell(cell23);
                PdfPCell cell24 = new PdfPCell(new Phrase("TOTAL", font3));
                cell24.BackgroundColor = baseColor;
                cell24.HorizontalAlignment = 1;
                cell24.PaddingTop = 5f;
                cell24.PaddingBottom = 5f;
                cell24.Border = 15;
                pdfPtable3.AddCell(cell24);
                List<ComprobanteDetalle> comprobanteDetalle = pCabecera.LstComprobanteDetalle;
                int count = comprobanteDetalle.Count;
                int num1 = 30;
                int num2 = num1 - 1;
                Decimal num3;
                for (int index = 0; index < num1; ++index)
                {
                    if (index < count)
                    {
                        PdfPCell cell25 = new PdfPCell(new Phrase(comprobanteDetalle[index].NroItem, font3));
                        cell25.Border = 14;
                        cell25.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell25);
                        PdfPCell cell26 = new PdfPCell(new Phrase(comprobanteDetalle[index].Codigo_Articulo, font3));
                        cell26.Border = 14;
                        cell26.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell26);
                        PdfPCell cell27 = new PdfPCell(new Phrase(comprobanteDetalle[index].Descripcion_Articulo, font3));
                        cell27.Border = 14;
                        cell27.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell27);
                        PdfPCell cell28 = new PdfPCell(new Phrase(comprobanteDetalle[index].Codigo_Unidad, font3));
                        cell28.Border = 14;
                        cell28.HorizontalAlignment = 1;
                        pdfPtable3.AddCell(cell28);
                        num3 = comprobanteDetalle[index].Cantidad;
                        PdfPCell cell29 = new PdfPCell(new Phrase(num3.ToString(), font3));
                        cell29.Border = 14;
                        cell29.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell29);
                        num3 = comprobanteDetalle[index].Precio_Unitario_SinIGV;
                        PdfPCell cell30 = new PdfPCell(new Phrase(num3.ToString("#0.00"), font3));
                        cell30.Border = 14;
                        cell30.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell30);
                        num3 = comprobanteDetalle[index].Importe_SubTotal;
                        PdfPCell cell31 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                        cell31.Border = 14;
                        cell31.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell31);
                    }
                    else
                    {
                        PdfPCell cell25 = new PdfPCell(new Phrase(" ", font3));
                        cell25.Border = num2 == index ? 14 : 12;
                        cell25.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell25);
                        PdfPCell cell26 = new PdfPCell(new Phrase(" ", font3));
                        cell26.Border = num2 == index ? 14 : 12;
                        cell26.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell26);
                        PdfPCell cell27 = new PdfPCell(new Phrase(" ", font3));
                        cell27.Border = num2 == index ? 14 : 12;
                        cell27.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell27);
                        PdfPCell cell28 = new PdfPCell(new Phrase(" ", font3));
                        cell28.Border = num2 == index ? 14 : 12;
                        cell28.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell28);
                        PdfPCell cell29 = new PdfPCell(new Phrase(" ", font3));
                        cell29.Border = num2 == index ? 14 : 12;
                        cell29.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell29);
                        PdfPCell cell30 = new PdfPCell(new Phrase(" ", font3));
                        cell30.Border = num2 == index ? 14 : 12;
                        cell30.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell30);
                        PdfPCell cell31 = new PdfPCell(new Phrase(" ", font3));
                        cell31.Border = num2 == index ? 14 : 12;
                        cell31.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell31);
                    }
                }
                PdfPTable pdfPtable4 = new PdfPTable(3);
                pdfPtable4.HorizontalAlignment = 0;
                pdfPtable4.WidthPercentage = 100f;
                pdfPtable4.SetWidths(new float[3] { 150f, 20f, 100f });
                PdfPCell cell32 = new PdfPCell(new Phrase("Operación Gravada", font3));
                cell32.Border = 0;
                cell32.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell32);
                PdfPCell cell33 = new PdfPCell(new Phrase(pMoneda, font3));
                cell33.Border = 0;
                pdfPtable4.AddCell(cell33);
                num3 = pCabecera.Importe_Gravado;
                PdfPCell cell34 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell34.Border = 0;
                cell34.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell34);
                PdfPCell cell35 = new PdfPCell(new Phrase("Operación Exonerada", font3));
                cell35.Border = 0;
                cell35.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell35);
                PdfPCell cell36 = new PdfPCell(new Phrase(pMoneda, font3));
                cell36.Border = 0;
                pdfPtable4.AddCell(cell36);
                num3 = pCabecera.Importe_Exonerado;
                PdfPCell cell37 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell37.Border = 0;
                cell37.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell37);
                PdfPCell cell38 = new PdfPCell(new Phrase("Operación Inafecta", font3));
                cell38.Border = 0;
                cell38.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell38);
                PdfPCell cell39 = new PdfPCell(new Phrase(pMoneda, font3));
                cell39.Border = 0;
                pdfPtable4.AddCell(cell39);
                num3 = pCabecera.Importe_Inafecto;
                PdfPCell cell40 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell40.Border = 0;
                cell40.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell40);
                PdfPCell cell41 = new PdfPCell(new Phrase("Operación Gratuita", font3));
                cell41.Border = 0;
                cell41.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell41);
                PdfPCell cell42 = new PdfPCell(new Phrase(pMoneda, font3));
                cell42.Border = 0;
                pdfPtable4.AddCell(cell42);
                num3 = pCabecera.Importe_Gratuito;
                PdfPCell cell43 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell43.Border = 0;
                cell43.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell43);
                PdfPCell cell44 = new PdfPCell(new Phrase("Total Descuento", font3));
                cell44.Border = 0;
                cell44.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell44);
                PdfPCell cell45 = new PdfPCell(new Phrase(pMoneda, font3));
                cell45.Border = 0;
                pdfPtable4.AddCell(cell45);
                num3 = pCabecera.Importe_DctoGlobal;
                PdfPCell cell46 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell46.Border = 0;
                cell46.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell46);
                PdfPCell cell47 = new PdfPCell(new Phrase("I.G.V. (" + this.IGV + "%)", font3));
                cell47.Border = 0;
                cell47.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell47);
                PdfPCell cell48 = new PdfPCell(new Phrase(pMoneda, font3));
                cell48.Border = 0;
                pdfPtable4.AddCell(cell48);
                num3 = pCabecera.Importe_IGV;
                PdfPCell cell49 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell49.Border = 0;
                cell49.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell49);
                if (pCabecera.Importe_Percepcion == new Decimal(0))
                {
                    PdfPCell cell25 = new PdfPCell(new Phrase("Importe Total", font3));
                    cell25.Border = 0;
                    cell25.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell26.Border = 0;
                    pdfPtable4.AddCell(cell26);
                    num3 = pCabecera.Importe_Total;
                    PdfPCell cell27 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell27.Border = 0;
                    cell27.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell27);
                }
                else
                {
                    PdfPCell cell25 = new PdfPCell(new Phrase("Total a Pagar", font3));
                    cell25.Border = 0;
                    cell25.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell26.Border = 0;
                    pdfPtable4.AddCell(cell26);
                    num3 = pCabecera.Importe_Total;
                    PdfPCell cell27 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell27.Border = 0;
                    cell27.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell27);
                    PdfPCell cell28 = new PdfPCell(new Phrase("Percepción", font3));
                    cell28.Border = 0;
                    cell28.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell28);
                    PdfPCell cell29 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell29.Border = 0;
                    pdfPtable4.AddCell(cell29);
                    num3 = pCabecera.Importe_Percepcion;
                    PdfPCell cell30 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell30.Border = 0;
                    cell30.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell30);
                    PdfPCell cell31 = new PdfPCell(new Phrase("Importe Total", font3));
                    cell31.Border = 0;
                    cell31.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell31);
                    PdfPCell cell50 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell50.Border = 0;
                    pdfPtable4.AddCell(cell50);
                    num3 = pCabecera.Importe_Cobrado;
                    PdfPCell cell51 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell51.Border = 0;
                    cell51.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell51);
                }
                PdfPCell cell52 = new PdfPCell(new Phrase("SON:", font3));
                cell52.Colspan = 3;
                cell52.Border = 14;
                pdfPtable3.AddCell(cell52);
                PdfPCell cell53 = new PdfPCell(new Phrase(" ", font3));
                cell53.Colspan = 4;
                cell53.Border = 0;
                pdfPtable3.AddCell(cell53);
                PdfPCell cell54 = new PdfPCell(new Phrase(pCabecera.Texto_Importe_Total, font3));
                cell54.Colspan = 3;
                cell54.PaddingLeft = 10f;
                cell54.PaddingBottom = 40f;
                cell54.Border = 14;
                pdfPtable3.AddCell(cell54);
                PdfPCell cell55 = new PdfPCell(new Phrase(" ", font3));
                cell55.Colspan = 4;
                cell55.Rowspan = 9;
                cell55.Border = 0;
                cell55.AddElement((IElement)pdfPtable4);
                pdfPtable3.AddCell(cell55);
                int num4 = 85;
                if (pCabecera.Importe_Percepcion != new Decimal(0))
                {
                    num4 = 65;
                    PdfPCell cell25 = new PdfPCell(new Phrase(" ", font3));
                    cell25.Colspan = 3;
                    cell25.Border = 0;
                    pdfPtable3.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase("COMPROBANTE DE PERCEPCION - VENTA INTERNA", font3));
                    cell26.Colspan = 3;
                    cell26.Border = 15;
                    pdfPtable3.AddCell(cell26);
                }
                PdfPCell cell56 = new PdfPCell(new Phrase(" ", font3));
                cell56.Colspan = 3;
                cell56.Border = 0;
                pdfPtable3.AddCell(cell56);
                PdfPCell cell57 = new PdfPCell(new Phrase("Código Hash", font3));
                cell57.Colspan = 3;
                cell57.Border = 15;
                pdfPtable3.AddCell(cell57);
                PdfPCell cell58 = new PdfPCell(new Phrase(pDigestValue, font3));
                cell58.Colspan = 3;
                cell58.Border = 14;
                cell58.PaddingLeft = 10f;
                pdfPtable3.AddCell(cell58);
                PdfPCell cell59 = new PdfPCell(new Phrase(" ", font3));
                cell59.Colspan = 3;
                cell59.Border = 0;
                pdfPtable3.AddCell(cell59);
                PdfPCell cell60 = new PdfPCell(new Phrase(" ", font3));
                cell60.Colspan = 7;
                cell60.Border = 0;
                pdfPtable3.AddCell(cell60);
                string empty = string.Empty;
                string[] strArray1 = new string[6]
                {
                    pCabecera.NroDoc_Emisor + "|" + pCabecera.Codigo_Documento + "|" + pCabecera.Serie_Documento + "|" + pCabecera.Numero_Documento, "|", null, null, null, null
                };
                string[] strArray2 = strArray1;
                num3 = pCabecera.Importe_Total;
                string str = num3.ToString();
                strArray2[2] = str;
                strArray1[3] = "|";
                strArray1[4] = pCabecera.Fecha_Emision.ToString("DD-MM-YY");
                strArray1[5] = "|";
                iTextSharp.text.Image image = GenerarArchivo.RetornarCodigoQR(string.Concat(strArray1));
                image.SetAbsolutePosition(0.0f, 0.0f);
                iTextSharp.text.Rectangle pageSize = instance1.PageSize;
                PdfTemplate template = new PdfContentByte(instance1).CreateTemplate(400f, 100f);
                template.AddImage(image);
                BaseFont font4 = BaseFont.CreateFont("Helvetica", "Cp1250", true);
                PdfContentByte pdfContentByte = new PdfContentByte(instance1);
                PdfContentByte directContent = instance1.DirectContent;
                directContent.BeginText();
                directContent.SetFontAndSize(font4, 6.5f);
                directContent.ShowTextAligned(0, "Representación gráfica del documento electrónico, este puede ser consultado en " + this.LINK_DESCARGA_ARCHIVOS, 30f, 45f, 0.0f);
                directContent.EndText();
                directContent.BeginText();
                directContent.SetFontAndSize(font4, 6.5f);
                directContent.ShowTextAligned(0, "Autorizado mediante Resolución N°." + this.NRO_RESOLUCION + "/SUNAT.", 30f, 35f, 0.0f);
                directContent.EndText();
                directContent.AddTemplate(template, 25f, 55f);
                directContent.Stroke();
                document.Add((IElement)pdfPtable1);
                document.Add((IElement)pdfPtable2);
                document.Add((IElement)pdfPtable3);
                document.Close();
                byte[] array = memoryStream.ToArray();
                System.IO.File.WriteAllBytes(pFileName, array);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraPDFTicketNCredito(ComprobanteCabecera pCabecera, string pMoneda, string pDigestValue, string pSignature, string pFileName)
        {
            try
            {
                string appSetting = ConfigurationManager.AppSettings["LOGO_EMPRESA"];
                if (pCabecera == null)
                    return;
                Document document = new Document(new iTextSharp.text.Rectangle(226f, (490f + (pCabecera.LstComprobanteDetalle.Count * 7))), 5f, 5f, 5f, 5f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance1 = PdfWriter.GetInstance(document, (Stream)memoryStream);
                iTextSharp.text.Font font = FontFactory.GetFont("Courier", 7f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                document.Open();
                PdfPTable pdfPtable1 = new PdfPTable(1);
                pdfPtable1.HorizontalAlignment = 0;
                pdfPtable1.WidthPercentage = 100f;
                pdfPtable1.DefaultCell.Border = 0;
                PdfPTable table1 = new PdfPTable(1);
                table1.HorizontalAlignment = 0;
                table1.DefaultCell.Border = 0;
                iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance(appSetting);
                instance2.ScalePercent(30f);
                PdfPCell cell1 = new PdfPCell(instance2);
                cell1.Border = 0;
                cell1.HorizontalAlignment = 1;
                table1.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase(pCabecera.RSocial_Emisor, font));
                cell2.PaddingTop = 5f;
                cell2.Border = 0;
                cell2.HorizontalAlignment = 1;
                table1.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("R.U.C. N° " + pCabecera.NroDoc_Emisor, font));
                cell3.Border = 0;
                cell3.HorizontalAlignment = 1;
                table1.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase(pCabecera.Direccion_Emisor, font));
                cell4.Border = 0;
                cell4.HorizontalAlignment = 1;
                table1.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(pCabecera.Dist_Emisor + " - " + pCabecera.Prov_Emisor + " - " + pCabecera.Dpto_Emisor, font));
                cell5.Border = 0;
                cell5.HorizontalAlignment = 1;
                table1.AddCell(cell5);
                PdfPCell cell6 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell6.Border = 0;
                cell6.HorizontalAlignment = 1;
                table1.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("NOTA DE CREDITO ELECTRONICA", font));
                cell7.Border = 0;
                cell7.HorizontalAlignment = 1;
                table1.AddCell(cell7);
                PdfPCell cell8 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell8.Border = 0;
                cell8.HorizontalAlignment = 1;
                table1.AddCell(cell8);
                PdfPCell cell9 = new PdfPCell(new Phrase(pCabecera.Serie_Documento + " - " + pCabecera.Numero_Documento, font));
                cell9.Border = 0;
                cell9.HorizontalAlignment = 1;
                table1.AddCell(cell9);
                PdfPCell cell10 = new PdfPCell(new Phrase("Señor(es) : " + pCabecera.RSocial_Receptor, font));
                cell10.Border = 0;
                cell10.HorizontalAlignment = 0;
                table1.AddCell(cell10);
                PdfPCell cell11 = new PdfPCell(new Phrase("Dirección : " + pCabecera.Direccion_Receptor, font));
                cell11.Border = 0;
                cell11.HorizontalAlignment = 0;
                table1.AddCell(cell11);
                PdfPCell cell12 = new PdfPCell(new Phrase("R.U.C. N° : " + pCabecera.NroDoc_Receptor, font));
                cell12.Border = 0;
                cell12.HorizontalAlignment = 0;
                table1.AddCell(cell12);
                PdfPCell cell13 = new PdfPCell(new Phrase("Fecha de Emisión: " + Convert.ToDateTime(pCabecera.Fecha_Emision).ToString("dd/MM/yyyy") + " " + pCabecera.Hora_Emision, font));
                cell13.Border = 0;
                cell13.HorizontalAlignment = 0;
                table1.AddCell(cell13);
                PdfPCell cell14 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell14.PaddingBottom = 0;
                cell14.Border = 0;
                cell14.HorizontalAlignment = 1;
                table1.AddCell(cell14);
                PdfPCell cell112 = new PdfPCell(new Phrase("DOCUMENTO QUE MODIFICA", font));
                cell112.Border = 0;
                cell112.HorizontalAlignment = 0;
                table1.AddCell(cell112);
                PdfPCell cell113 = new PdfPCell(new Phrase("Factura N°: " + pCabecera.Documento_Ref, font));
                cell113.Border = 0;
                cell113.HorizontalAlignment = 0;
                table1.AddCell(cell113);
                PdfPCell cell114 = new PdfPCell(new Phrase("Motivo    : " + pCabecera.Descripcion_Motivo_Ref, font));
                cell114.Border = 0;
                cell114.HorizontalAlignment = 0;
                table1.AddCell(cell114);
                PdfPCell cell115 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell115.PaddingBottom = 0;
                cell115.Border = 0;
                cell115.HorizontalAlignment = 1;
                table1.AddCell(cell115);
                PdfPTable table2 = new PdfPTable(4);
                table2.HorizontalAlignment = 0;
                table2.WidthPercentage = 100f;
                table2.SetWidths(new float[4] { 30f, 120f, 50f, 50f });
                PdfPCell cell15 = new PdfPCell(new Phrase("CANT", font));
                cell15.PaddingTop = 0;
                cell15.PaddingBottom = 0;
                cell15.HorizontalAlignment = 0;
                cell15.Border = 0;
                table2.AddCell(cell15);
                PdfPCell cell16 = new PdfPCell(new Phrase("DESCRIPCION", font));
                cell16.PaddingTop = 0;
                cell16.PaddingBottom = 0;
                cell16.HorizontalAlignment = 0;
                cell16.Border = 0;
                table2.AddCell(cell16);
                PdfPCell cell17 = new PdfPCell(new Phrase("P.UNI.", font));
                cell17.PaddingTop = 0;
                cell17.PaddingBottom = 0;
                cell17.HorizontalAlignment = 2;
                cell17.Border = 0;
                table2.AddCell(cell17);
                PdfPCell cell18 = new PdfPCell(new Phrase("TOTAL", font));
                cell18.PaddingTop = 0;
                cell18.PaddingBottom = 0;
                cell18.HorizontalAlignment = 2;
                cell18.Border = 0;
                table2.AddCell(cell18);
                table1.AddCell(table2);
                PdfPCell cell247 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell247.PaddingTop = 0;
                cell247.Border = 0;
                cell247.HorizontalAlignment = 1;
                table1.AddCell(cell247);
                PdfPTable table3 = new PdfPTable(4);
                table3.HorizontalAlignment = 0;
                table3.WidthPercentage = 100f;
                table3.SetWidths(new float[4] { 30f, 120f, 50f, 50f });
                List<ComprobanteDetalle> comprobanteDetalle = pCabecera.LstComprobanteDetalle;
                int count = comprobanteDetalle.Count;
                int num1 = 30;
                int num2 = num1 - 1;
                for (int index = 0; index < count; ++index)
                {
                    PdfPCell cell19 = new PdfPCell(new Phrase(comprobanteDetalle[index].Cantidad.ToString(), font));
                    cell19.PaddingTop = 0;
                    cell19.PaddingBottom = 0;
                    cell19.Border = 0;
                    cell19.HorizontalAlignment = 0;
                    table3.AddCell(cell19);
                    PdfPCell cell20 = new PdfPCell(new Phrase(comprobanteDetalle[index].Descripcion_Articulo, font));
                    cell20.PaddingTop = 0;
                    cell20.PaddingBottom = 0;
                    cell20.Border = 0;
                    cell20.HorizontalAlignment = 0;
                    table3.AddCell(cell20);
                    PdfPCell cell21 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Precio_Unitario_SinIGV.ToString("#0.00"), font));
                    cell21.PaddingTop = 0;
                    cell21.PaddingBottom = 0;
                    cell21.Border = 0;
                    cell21.HorizontalAlignment = 2;
                    table3.AddCell(cell21);
                    PdfPCell cell22 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Importe_SubTotal.ToString("#,##0.00"), font));
                    cell22.PaddingTop = 0;
                    cell22.PaddingBottom = 0;
                    cell22.Border = 0;
                    cell22.HorizontalAlignment = 2;
                    table3.AddCell(cell22);
                }
                table1.AddCell(table3);
                PdfPTable pdfPtable4 = new PdfPTable(3);
                pdfPtable4.HorizontalAlignment = 0;
                pdfPtable4.WidthPercentage = 100f;
                pdfPtable4.SetWidths(new float[3] { 150f, 20f, 100f });
                PdfPCell cell32 = new PdfPCell(new Phrase("Operación Gravada", font));
                cell32.Border = 0;
                pdfPtable4.AddCell(cell32);
                PdfPCell cell33 = new PdfPCell(new Phrase(pMoneda, font));
                cell33.Border = 0;
                pdfPtable4.AddCell(cell33);
                PdfPCell cell34 = new PdfPCell(new Phrase(pCabecera.Importe_Gravado.ToString("#,##0.00"), font));
                cell34.Border = 0;
                cell34.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell34);
                PdfPCell cell35 = new PdfPCell(new Phrase("Operación Exonerada", font));
                cell35.Border = 0;
                pdfPtable4.AddCell(cell35);
                PdfPCell cell36 = new PdfPCell(new Phrase(pMoneda, font));
                cell36.Border = 0;
                pdfPtable4.AddCell(cell36);
                PdfPCell cell37 = new PdfPCell(new Phrase(pCabecera.Importe_Exonerado.ToString("#,##0.00"), font));
                cell37.Border = 0;
                cell37.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell37);
                PdfPCell cell38 = new PdfPCell(new Phrase("Operación Inafecta", font));
                cell38.Border = 0;
                pdfPtable4.AddCell(cell38);
                PdfPCell cell39 = new PdfPCell(new Phrase(pMoneda, font));
                cell39.Border = 0;
                pdfPtable4.AddCell(cell39);
                PdfPCell cell40 = new PdfPCell(new Phrase(pCabecera.Importe_Inafecto.ToString("#,##0.00"), font));
                cell40.Border = 0;
                cell40.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell40);
                PdfPCell cell41 = new PdfPCell(new Phrase("Operación Gratuita", font));
                cell41.Border = 0;
                pdfPtable4.AddCell(cell41);
                PdfPCell cell42 = new PdfPCell(new Phrase(pMoneda, font));
                cell42.Border = 0;
                pdfPtable4.AddCell(cell42);
                PdfPCell cell43 = new PdfPCell(new Phrase(pCabecera.Importe_Gratuito.ToString("#,##0.00"), font));
                cell43.Border = 0;
                cell43.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell43);
                PdfPCell cell44 = new PdfPCell(new Phrase("Total Descuento", font));
                cell44.Border = 0;
                pdfPtable4.AddCell(cell44);
                PdfPCell cell45 = new PdfPCell(new Phrase(pMoneda, font));
                cell45.Border = 0;
                pdfPtable4.AddCell(cell45);
                PdfPCell cell46 = new PdfPCell(new Phrase(pCabecera.Importe_DctoGlobal.ToString("#,##0.00"), font));
                cell46.Border = 0;
                cell46.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell46);
                PdfPCell cell47 = new PdfPCell(new Phrase("I.G.V. (" + this.IGV + "%)", font));
                cell47.Border = 0;
                pdfPtable4.AddCell(cell47);
                PdfPCell cell48 = new PdfPCell(new Phrase(pMoneda, font));
                cell48.Border = 0;
                pdfPtable4.AddCell(cell48);
                PdfPCell cell49 = new PdfPCell(new Phrase(pCabecera.Importe_IGV.ToString("#,##0.00"), font));
                cell49.Border = 0;
                cell49.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell49);
                if (pCabecera.Importe_Percepcion == new Decimal(0))
                {
                    PdfPCell cell25 = new PdfPCell(new Phrase("Importe Total", font));
                    cell25.Border = 0;
                    pdfPtable4.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase(pMoneda, font));
                    cell26.Border = 0;
                    pdfPtable4.AddCell(cell26);
                    PdfPCell cell27 = new PdfPCell(new Phrase(pCabecera.Importe_Total.ToString("#,##0.00"), font));
                    cell27.Border = 0;
                    cell27.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell27);
                }
                else
                {
                    PdfPCell cell25 = new PdfPCell(new Phrase("Total a Pagar", font));
                    cell25.Border = 0;
                    cell25.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase(pMoneda, font));
                    cell26.Border = 0;
                    pdfPtable4.AddCell(cell26);
                    PdfPCell cell27 = new PdfPCell(new Phrase(pCabecera.Importe_Total.ToString("#,##0.00"), font));
                    cell27.Border = 0;
                    cell27.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell27);
                    PdfPCell cell28 = new PdfPCell(new Phrase("Percepción", font));
                    cell28.Border = 0;
                    cell28.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell28);
                    PdfPCell cell29 = new PdfPCell(new Phrase(pMoneda, font));
                    cell29.Border = 0;
                    pdfPtable4.AddCell(cell29);
                    PdfPCell cell30 = new PdfPCell(new Phrase(pCabecera.Importe_Percepcion.ToString("#,##0.00"), font));
                    cell30.Border = 0;
                    cell30.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell30);
                    PdfPCell cell31 = new PdfPCell(new Phrase("Importe Total", font));
                    cell31.Border = 0;
                    cell31.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell31);
                    PdfPCell cell50 = new PdfPCell(new Phrase(pMoneda, font));
                    cell50.Border = 0;
                    pdfPtable4.AddCell(cell50);
                    PdfPCell cell51 = new PdfPCell(new Phrase(pCabecera.Importe_Cobrado.ToString("#,##0.00"), font));
                    cell51.Border = 0;
                    cell51.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell51);
                }
                table1.AddCell(pdfPtable4);
                PdfPTable pdfPtable5 = new PdfPTable(2);
                pdfPtable5.HorizontalAlignment = 0;
                pdfPtable5.WidthPercentage = 100f;
                pdfPtable5.SetWidths(new float[2] { 30f, 200f });
                PdfPCell cell551 = new PdfPCell(new Phrase("SON: ", font));
                cell551.HorizontalAlignment = 0;
                cell551.Border = 0;
                pdfPtable5.AddCell(cell551);
                PdfPCell cell53 = new PdfPCell(new Phrase(pCabecera.Texto_Importe_Total, font));
                cell53.HorizontalAlignment = 0;
                cell53.Border = 0;
                pdfPtable5.AddCell(cell53);
                table1.AddCell(pdfPtable5);
                PdfPCell cell210 = new PdfPCell(new Phrase("Representación gráfica del documento electrónico," + Environment.NewLine + "puede ser consultado en la siguiente página: " + Environment.NewLine + this.LINK_DESCARGA_ARCHIVOS, font));
                cell210.Border = 0;
                cell210.HorizontalAlignment = 1;
                table1.AddCell(cell210);
                PdfPCell cell211 = new PdfPCell(new Phrase("GRACIAS POR SU PREFERENCIA", font));
                cell211.Border = 0;
                cell211.HorizontalAlignment = 1;
                table1.AddCell(cell211);
                string[] strArray1 = new string[6] { pCabecera.NroDoc_Emisor + "|" + pCabecera.Codigo_Documento + "|" + pCabecera.Serie_Documento + "|" + pCabecera.Numero_Documento, "|", null, null, null, null };
                string[] strArray2 = strArray1;
                string str = pCabecera.Importe_Total.ToString();
                strArray2[2] = str;
                strArray1[3] = "|";
                strArray1[4] = pCabecera.Fecha_Emision.ToString("DD-MM-YY");
                strArray1[5] = "|";
                iTextSharp.text.Image image = GenerarArchivo.RetornarCodigoQR(string.Concat(strArray1));
                image.SetAbsolutePosition(0.0f, 0.0f);
                iTextSharp.text.Rectangle pageSize = instance1.PageSize;
                PdfTemplate template = new PdfContentByte(instance1).CreateTemplate(400f, 100f);
                template.AddImage(image);
                pdfPtable1.AddCell(table1);
                PdfContentByte directContent = instance1.DirectContent;
                directContent.BeginText();
                directContent.AddTemplate(template, 75f, 5f);
                directContent.EndText();
                directContent.Stroke();
                document.Add((IElement)pdfPtable1);
                document.Close();
                byte[] array = memoryStream.ToArray();
                System.IO.File.WriteAllBytes(pFileName, array);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraPDFA4NDebito(ComprobanteCabecera pCabecera, string pMoneda, string pDigestValue, string pSignature, string pFileName)
        {
            try
            {
                PdfPCell pdfPcell = new PdfPCell();
                string appSetting = ConfigurationManager.AppSettings["LOGO_EMPRESA"];
                if (pCabecera == null)
                    return;
                Document document = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance1 = PdfWriter.GetInstance(document, (Stream)memoryStream);
                iTextSharp.text.Font font1 = FontFactory.GetFont("Verdana", 12f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font2 = FontFactory.GetFont("Verdana", 10f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font3 = FontFactory.GetFont("Verdana", 6.3f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                BaseColor baseColor = new BaseColor(ColorTranslator.FromHtml("#EBEBEB"));
                document.Open();
                PdfPTable pdfPtable1 = new PdfPTable(3);
                pdfPtable1.HorizontalAlignment = 0;
                pdfPtable1.WidthPercentage = 100f;
                pdfPtable1.DefaultCell.Border = 0;
                PdfPTable table1 = new PdfPTable(1);
                table1.HorizontalAlignment = 0;
                table1.DefaultCell.Border = 0;
                iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance(appSetting);
                instance2.ScalePercent(30f);
                PdfPCell cell1 = new PdfPCell(instance2);
                cell1.Border = 0;
                cell1.HorizontalAlignment = 0;
                table1.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("", font2)); //pCabecera.RSocial_Emisor
                cell2.PaddingTop = 5f;
                cell2.Border = 0;
                cell2.HorizontalAlignment = 0;
                table1.AddCell(cell2);
                pdfPtable1.AddCell(table1);
                PdfPTable table2 = new PdfPTable(1);
                table2.HorizontalAlignment = 1;
                table2.DefaultCell.Border = 0;
                PdfPCell cell3 = new PdfPCell(new Phrase("Oficina Principal", font3));
                cell3.PaddingTop = 20f;
                cell3.Border = 0;
                cell3.HorizontalAlignment = 1;
                table2.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase(pCabecera.Direccion_Emisor, font3));
                cell4.Border = 0;
                cell4.HorizontalAlignment = 1;
                table2.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(pCabecera.Dist_Emisor + " - " + pCabecera.Prov_Emisor + " - " + pCabecera.Dpto_Emisor, font3));
                cell5.Border = 0;
                cell5.HorizontalAlignment = 1;
                table2.AddCell(cell5);
                pdfPtable1.AddCell(table2);
                PdfPTable table3 = new PdfPTable(1);
                table3.HorizontalAlignment = 1;
                PdfPCell cell6 = new PdfPCell(new Phrase("R.U.C. N° " + pCabecera.NroDoc_Emisor, font1));
                cell6.PaddingTop = 10f;
                cell6.Border = 13;
                cell6.HorizontalAlignment = 1;
                table3.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("NOTA DE DEBITO ELECTRONICA", font1));
                cell7.PaddingTop = 5f;
                cell7.Border = 12;
                cell7.HorizontalAlignment = 1;
                table3.AddCell(cell7);
                PdfPCell cell8 = new PdfPCell(new Phrase(pCabecera.Serie_Documento + " - " + pCabecera.Numero_Documento, font1));
                cell8.PaddingTop = 5f;
                cell8.Border = 12;
                cell8.HorizontalAlignment = 1;
                table3.AddCell(cell8);
                PdfPCell cell9 = new PdfPCell(new Phrase(" "));
                cell9.PaddingTop = 5f;
                cell9.Border = 14;
                cell9.HorizontalAlignment = 1;
                table3.AddCell(cell9);
                pdfPtable1.AddCell(table3);
                PdfPTable pdfPtable2 = new PdfPTable(4);
                pdfPtable2.HorizontalAlignment = 0;
                pdfPtable2.WidthPercentage = 100f;
                pdfPtable2.SpacingBefore = 5f;
                pdfPtable2.SetWidths(new float[4]
                {
                    90f,
                    90f,
                    90f,
                    90f
                });
                PdfPCell cell10 = new PdfPCell(new Phrase("Señor(es) : " + pCabecera.RSocial_Receptor, font3));
                cell10.Colspan = 4;
                cell10.Border = 13;
                cell10.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell10);
                PdfPCell cell11 = new PdfPCell(new Phrase("Dirección : " + pCabecera.Direccion_Receptor, font3));
                cell11.Colspan = 4;
                cell11.PaddingTop = 5f;
                cell11.Border = 12;
                cell11.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell11);
                PdfPCell cell12 = new PdfPCell(new Phrase("R.U.C. N° : " + pCabecera.NroDoc_Receptor, font3));
                cell12.Colspan = 3;
                cell12.PaddingTop = 5f;
                cell12.PaddingBottom = 10f;
                cell12.Border = 6;
                cell12.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell12);
                PdfPCell cell13 = new PdfPCell(new Phrase("Fecha de Emisión: " + Convert.ToDateTime(pCabecera.Fecha_Emision).ToString("dd/MM/yyyy"), font3));
                cell13.PaddingTop = 5f;
                cell13.PaddingBottom = 10f;
                cell13.Border = 10;
                cell13.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell13);
                PdfPCell cell14 = new PdfPCell(new Phrase("DOCUMENTO QUE MODIFICA", font3));
                cell14.Colspan = 2;
                cell14.Border = 5;
                cell14.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell14);
                PdfPCell cell15 = new PdfPCell(new Phrase("MOTIVO" + (pCabecera.Codigo_Documento_Ref == "03" ? pCabecera.Documento_Ref : ""), font3));
                cell15.Colspan = 2;
                cell15.PaddingTop = 5f;
                cell15.Border = 8;
                cell15.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell15);
                PdfPCell cell16 = new PdfPCell(new Phrase("Factura N°: " + pCabecera.Documento_Ref, font3));
                cell16.Colspan = 2;
                cell16.PaddingTop = 5f;
                cell16.Border = 6;
                cell16.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell16);
                PdfPCell cell17 = new PdfPCell(new Phrase(pCabecera.Descripcion_Motivo_Ref, font3));
                cell17.Colspan = 2;
                cell17.PaddingTop = 5f;
                cell17.Border = 10;
                cell17.HorizontalAlignment = 0;
                pdfPtable2.AddCell(cell17);
                PdfPTable pdfPtable3 = new PdfPTable(7);
                pdfPtable3.HorizontalAlignment = 0;
                pdfPtable3.WidthPercentage = 100f;
                pdfPtable3.SpacingBefore = 5f;
                pdfPtable3.SetWidths(new float[7]
                {
                    15f,
                    50f,
                    230f,
                    30f,
                    50f,
                    50f,
                    50f
                });
                PdfPCell cell18 = new PdfPCell(new Phrase("N°", font3));
                cell18.BackgroundColor = baseColor;
                cell18.HorizontalAlignment = 1;
                cell18.PaddingTop = 5f;
                cell18.PaddingBottom = 5f;
                cell18.Border = 15;
                pdfPtable3.AddCell(cell18);
                PdfPCell cell19 = new PdfPCell(new Phrase("CODIGO", font3));
                cell19.BackgroundColor = baseColor;
                cell19.HorizontalAlignment = 1;
                cell19.PaddingTop = 5f;
                cell19.PaddingBottom = 5f;
                cell19.Border = 15;
                pdfPtable3.AddCell(cell19);
                PdfPCell cell20 = new PdfPCell(new Phrase("DESCRIPCION", font3));
                cell20.BackgroundColor = baseColor;
                cell20.HorizontalAlignment = 1;
                cell20.PaddingTop = 5f;
                cell20.PaddingBottom = 5f;
                cell20.Border = 15;
                pdfPtable3.AddCell(cell20);
                PdfPCell cell21 = new PdfPCell(new Phrase("U.M.", font3));
                cell21.BackgroundColor = baseColor;
                cell21.HorizontalAlignment = 1;
                cell21.PaddingTop = 5f;
                cell21.PaddingBottom = 5f;
                cell21.Border = 15;
                pdfPtable3.AddCell(cell21);
                PdfPCell cell22 = new PdfPCell(new Phrase("CANTIDAD", font3));
                cell22.BackgroundColor = baseColor;
                cell22.HorizontalAlignment = 1;
                cell22.PaddingTop = 5f;
                cell22.PaddingBottom = 5f;
                cell22.Border = 15;
                pdfPtable3.AddCell(cell22);
                PdfPCell cell23 = new PdfPCell(new Phrase("PRECIO UNIT.", font3));
                cell23.BackgroundColor = baseColor;
                cell23.HorizontalAlignment = 1;
                cell23.PaddingTop = 5f;
                cell23.PaddingBottom = 5f;
                cell23.Border = 15;
                pdfPtable3.AddCell(cell23);
                PdfPCell cell24 = new PdfPCell(new Phrase("TOTAL", font3));
                cell24.BackgroundColor = baseColor;
                cell24.HorizontalAlignment = 1;
                cell24.PaddingTop = 5f;
                cell24.PaddingBottom = 5f;
                cell24.Border = 15;
                pdfPtable3.AddCell(cell24);
                List<ComprobanteDetalle> comprobanteDetalle = pCabecera.LstComprobanteDetalle;
                int count = comprobanteDetalle.Count;
                int num1 = 30;
                int num2 = num1 - 1;
                Decimal num3;
                for (int index = 0; index < num1; ++index)
                {
                    if (index < count)
                    {
                        PdfPCell cell25 = new PdfPCell(new Phrase(comprobanteDetalle[index].NroItem, font3));
                        cell25.Border = 14;
                        cell25.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell25);
                        PdfPCell cell26 = new PdfPCell(new Phrase(comprobanteDetalle[index].Codigo_Articulo, font3));
                        cell26.Border = 14;
                        cell26.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell26);
                        PdfPCell cell27 = new PdfPCell(new Phrase(comprobanteDetalle[index].Descripcion_Articulo, font3));
                        cell27.Border = 14;
                        cell27.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell27);
                        PdfPCell cell28 = new PdfPCell(new Phrase(comprobanteDetalle[index].Codigo_Unidad, font3));
                        cell28.Border = 14;
                        cell28.HorizontalAlignment = 1;
                        pdfPtable3.AddCell(cell28);
                        num3 = comprobanteDetalle[index].Cantidad;
                        PdfPCell cell29 = new PdfPCell(new Phrase(num3.ToString(), font3));
                        cell29.Border = 14;
                        cell29.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell29);
                        num3 = comprobanteDetalle[index].Precio_Unitario_SinIGV;
                        PdfPCell cell30 = new PdfPCell(new Phrase(num3.ToString("#0.00"), font3));
                        cell30.Border = 14;
                        cell30.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell30);
                        num3 = comprobanteDetalle[index].Importe_SubTotal;
                        PdfPCell cell31 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                        cell31.Border = 14;
                        cell31.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell31);
                    }
                    else
                    {
                        PdfPCell cell25 = new PdfPCell(new Phrase(" ", font3));
                        cell25.Border = num2 == index ? 14 : 12;
                        cell25.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell25);
                        PdfPCell cell26 = new PdfPCell(new Phrase(" ", font3));
                        cell26.Border = num2 == index ? 14 : 12;
                        cell26.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell26);
                        PdfPCell cell27 = new PdfPCell(new Phrase(" ", font3));
                        cell27.Border = num2 == index ? 14 : 12;
                        cell27.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell27);
                        PdfPCell cell28 = new PdfPCell(new Phrase(" ", font3));
                        cell28.Border = num2 == index ? 14 : 12;
                        cell28.HorizontalAlignment = 0;
                        pdfPtable3.AddCell(cell28);
                        PdfPCell cell29 = new PdfPCell(new Phrase(" ", font3));
                        cell29.Border = num2 == index ? 14 : 12;
                        cell29.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell29);
                        PdfPCell cell30 = new PdfPCell(new Phrase(" ", font3));
                        cell30.Border = num2 == index ? 14 : 12;
                        cell30.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell30);
                        PdfPCell cell31 = new PdfPCell(new Phrase(" ", font3));
                        cell31.Border = num2 == index ? 14 : 12;
                        cell31.HorizontalAlignment = 2;
                        pdfPtable3.AddCell(cell31);
                    }
                }
                PdfPTable pdfPtable4 = new PdfPTable(3);
                pdfPtable4.HorizontalAlignment = 0;
                pdfPtable4.WidthPercentage = 100f;
                pdfPtable4.SetWidths(new float[3] { 150f, 20f, 100f });
                PdfPCell cell32 = new PdfPCell(new Phrase("Operación Gravada", font3));
                cell32.Border = 0;
                cell32.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell32);
                PdfPCell cell33 = new PdfPCell(new Phrase(pMoneda, font3));
                cell33.Border = 0;
                pdfPtable4.AddCell(cell33);
                num3 = pCabecera.Importe_Gravado;
                PdfPCell cell34 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell34.Border = 0;
                cell34.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell34);
                PdfPCell cell35 = new PdfPCell(new Phrase("Operación Exonerada", font3));
                cell35.Border = 0;
                cell35.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell35);
                PdfPCell cell36 = new PdfPCell(new Phrase(pMoneda, font3));
                cell36.Border = 0;
                pdfPtable4.AddCell(cell36);
                num3 = pCabecera.Importe_Exonerado;
                PdfPCell cell37 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell37.Border = 0;
                cell37.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell37);
                PdfPCell cell38 = new PdfPCell(new Phrase("Operación Inafecta", font3));
                cell38.Border = 0;
                cell38.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell38);
                PdfPCell cell39 = new PdfPCell(new Phrase(pMoneda, font3));
                cell39.Border = 0;
                pdfPtable4.AddCell(cell39);
                num3 = pCabecera.Importe_Inafecto;
                PdfPCell cell40 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell40.Border = 0;
                cell40.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell40);
                PdfPCell cell41 = new PdfPCell(new Phrase("Operación Gratuita", font3));
                cell41.Border = 0;
                cell41.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell41);
                PdfPCell cell42 = new PdfPCell(new Phrase(pMoneda, font3));
                cell42.Border = 0;
                pdfPtable4.AddCell(cell42);
                num3 = pCabecera.Importe_Gratuito;
                PdfPCell cell43 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell43.Border = 0;
                cell43.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell43);
                PdfPCell cell44 = new PdfPCell(new Phrase("Total Descuento", font3));
                cell44.Border = 0;
                cell44.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell44);
                PdfPCell cell45 = new PdfPCell(new Phrase(pMoneda, font3));
                cell45.Border = 0;
                pdfPtable4.AddCell(cell45);
                num3 = pCabecera.Importe_DctoGlobal;
                PdfPCell cell46 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell46.Border = 0;
                cell46.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell46);
                PdfPCell cell47 = new PdfPCell(new Phrase("I.G.V. (" + this.IGV + "%)", font3));
                cell47.Border = 0;
                cell47.PaddingLeft = 10f;
                pdfPtable4.AddCell(cell47);
                PdfPCell cell48 = new PdfPCell(new Phrase(pMoneda, font3));
                cell48.Border = 0;
                pdfPtable4.AddCell(cell48);
                num3 = pCabecera.Importe_IGV;
                PdfPCell cell49 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                cell49.Border = 0;
                cell49.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell49);
                if (pCabecera.Importe_Percepcion == new Decimal(0))
                {
                    PdfPCell cell25 = new PdfPCell(new Phrase("Importe Total", font3));
                    cell25.Border = 0;
                    cell25.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell26.Border = 0;
                    pdfPtable4.AddCell(cell26);
                    num3 = pCabecera.Importe_Total;
                    PdfPCell cell27 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell27.Border = 0;
                    cell27.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell27);
                }
                else
                {
                    PdfPCell cell25 = new PdfPCell(new Phrase("Total a Pagar", font3));
                    cell25.Border = 0;
                    cell25.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell26.Border = 0;
                    pdfPtable4.AddCell(cell26);
                    num3 = pCabecera.Importe_Total;
                    PdfPCell cell27 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell27.Border = 0;
                    cell27.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell27);
                    PdfPCell cell28 = new PdfPCell(new Phrase("Percepción", font3));
                    cell28.Border = 0;
                    cell28.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell28);
                    PdfPCell cell29 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell29.Border = 0;
                    pdfPtable4.AddCell(cell29);
                    num3 = pCabecera.Importe_Percepcion;
                    PdfPCell cell30 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell30.Border = 0;
                    cell30.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell30);
                    PdfPCell cell31 = new PdfPCell(new Phrase("Importe Total", font3));
                    cell31.Border = 0;
                    cell31.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell31);
                    PdfPCell cell50 = new PdfPCell(new Phrase(pMoneda, font3));
                    cell50.Border = 0;
                    pdfPtable4.AddCell(cell50);
                    num3 = pCabecera.Importe_Cobrado;
                    PdfPCell cell51 = new PdfPCell(new Phrase(num3.ToString("#,##0.00"), font3));
                    cell51.Border = 0;
                    cell51.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell51);
                }
                PdfPCell cell52 = new PdfPCell(new Phrase("SON:", font3));
                cell52.Colspan = 3;
                cell52.Border = 14;
                pdfPtable3.AddCell(cell52);
                PdfPCell cell53 = new PdfPCell(new Phrase(" ", font3));
                cell53.Colspan = 4;
                cell53.Border = 0;
                pdfPtable3.AddCell(cell53);
                PdfPCell cell54 = new PdfPCell(new Phrase(pCabecera.Texto_Importe_Total, font3));
                cell54.Colspan = 3;
                cell54.PaddingLeft = 10f;
                cell54.PaddingBottom = 40f;
                cell54.Border = 14;
                pdfPtable3.AddCell(cell54);
                PdfPCell cell55 = new PdfPCell(new Phrase(" ", font3));
                cell55.Colspan = 4;
                cell55.Rowspan = 9;
                cell55.Border = 0;
                cell55.AddElement((IElement)pdfPtable4);
                pdfPtable3.AddCell(cell55);
                int num4 = 85;
                if (pCabecera.Importe_Percepcion != new Decimal(0))
                {
                    num4 = 65;
                    PdfPCell cell25 = new PdfPCell(new Phrase(" ", font3));
                    cell25.Colspan = 3;
                    cell25.Border = 0;
                    pdfPtable3.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase("COMPROBANTE DE PERCEPCION - VENTA INTERNA", font3));
                    cell26.Colspan = 3;
                    cell26.Border = 15;
                    pdfPtable3.AddCell(cell26);
                }
                PdfPCell cell56 = new PdfPCell(new Phrase(" ", font3));
                cell56.Colspan = 3;
                cell56.Border = 0;
                pdfPtable3.AddCell(cell56);
                PdfPCell cell57 = new PdfPCell(new Phrase("Código Hash", font3));
                cell57.Colspan = 3;
                cell57.Border = 15;
                pdfPtable3.AddCell(cell57);
                PdfPCell cell58 = new PdfPCell(new Phrase(pDigestValue, font3));
                cell58.Colspan = 3;
                cell58.Border = 14;
                cell58.PaddingLeft = 10f;
                pdfPtable3.AddCell(cell58);
                PdfPCell cell59 = new PdfPCell(new Phrase(" ", font3));
                cell59.Colspan = 3;
                cell59.Border = 0;
                pdfPtable3.AddCell(cell59);
                PdfPCell cell60 = new PdfPCell(new Phrase(" ", font3));
                cell60.Colspan = 7;
                cell60.Border = 0;
                pdfPtable3.AddCell(cell60);
                string empty = string.Empty;
                string[] strArray1 = new string[6]
                {
                    pCabecera.NroDoc_Emisor + "|" + pCabecera.Codigo_Documento + "|" + pCabecera.Serie_Documento + "|" + pCabecera.Numero_Documento, "|", null, null, null, null
                };
                string[] strArray2 = strArray1;
                num3 = pCabecera.Importe_Total;
                string str = num3.ToString();
                strArray2[2] = str;
                strArray1[3] = "|";
                strArray1[4] = pCabecera.Fecha_Emision.ToString("DD-MM-YY");
                strArray1[5] = "|";
                iTextSharp.text.Image image = GenerarArchivo.RetornarCodigoQR(string.Concat(strArray1));
                image.SetAbsolutePosition(0.0f, 0.0f);
                iTextSharp.text.Rectangle pageSize = instance1.PageSize;
                PdfTemplate template = new PdfContentByte(instance1).CreateTemplate(400f, 100f);
                template.AddImage(image);
                BaseFont font4 = BaseFont.CreateFont("Helvetica", "Cp1250", true);
                PdfContentByte pdfContentByte = new PdfContentByte(instance1);
                PdfContentByte directContent = instance1.DirectContent;
                directContent.BeginText();
                directContent.SetFontAndSize(font4, 6.5f);
                directContent.ShowTextAligned(0, "Representación gráfica del documento electrónico, este puede ser consultado en " + this.LINK_DESCARGA_ARCHIVOS, 30f, 45f, 0.0f);
                directContent.EndText();
                directContent.BeginText();
                directContent.SetFontAndSize(font4, 6.5f);
                directContent.ShowTextAligned(0, "Autorizado mediante Resolución N°." + this.NRO_RESOLUCION + "/SUNAT.", 30f, 35f, 0.0f);
                directContent.EndText();
                directContent.AddTemplate(template, 25f, 55f);
                directContent.Stroke();
                document.Add((IElement)pdfPtable1);
                document.Add((IElement)pdfPtable2);
                document.Add((IElement)pdfPtable3);
                document.Close();
                byte[] array = memoryStream.ToArray();
                System.IO.File.WriteAllBytes(pFileName, array);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneraPDFTicketNDebito(ComprobanteCabecera pCabecera, string pMoneda, string pDigestValue, string pSignature, string pFileName)
        {
            try
            {
                string appSetting = ConfigurationManager.AppSettings["LOGO_EMPRESA"];
                if (pCabecera == null)
                    return;
                Document document = new Document(new iTextSharp.text.Rectangle(226f, (490f + (pCabecera.LstComprobanteDetalle.Count * 7))), 5f, 5f, 5f, 5f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance1 = PdfWriter.GetInstance(document, (Stream)memoryStream);
                iTextSharp.text.Font font = FontFactory.GetFont("Courier", 7f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                document.Open();
                PdfPTable pdfPtable1 = new PdfPTable(1);
                pdfPtable1.HorizontalAlignment = 0;
                pdfPtable1.WidthPercentage = 100f;
                pdfPtable1.DefaultCell.Border = 0;
                PdfPTable table1 = new PdfPTable(1);
                table1.HorizontalAlignment = 0;
                table1.DefaultCell.Border = 0;
                iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance(appSetting);
                instance2.ScalePercent(30f);
                PdfPCell cell1 = new PdfPCell(instance2);
                cell1.Border = 0;
                cell1.HorizontalAlignment = 1;
                table1.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase(pCabecera.RSocial_Emisor, font));
                cell2.PaddingTop = 5f;
                cell2.Border = 0;
                cell2.HorizontalAlignment = 1;
                table1.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("R.U.C. N° " + pCabecera.NroDoc_Emisor, font));
                cell3.Border = 0;
                cell3.HorizontalAlignment = 1;
                table1.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase(pCabecera.Direccion_Emisor, font));
                cell4.Border = 0;
                cell4.HorizontalAlignment = 1;
                table1.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(pCabecera.Dist_Emisor + " - " + pCabecera.Prov_Emisor + " - " + pCabecera.Dpto_Emisor, font));
                cell5.Border = 0;
                cell5.HorizontalAlignment = 1;
                table1.AddCell(cell5);
                PdfPCell cell6 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell6.Border = 0;
                cell6.HorizontalAlignment = 1;
                table1.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("NOTA DE DEBITO ELECTRONICA", font));
                cell7.Border = 0;
                cell7.HorizontalAlignment = 1;
                table1.AddCell(cell7);
                PdfPCell cell8 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell8.Border = 0;
                cell8.HorizontalAlignment = 1;
                table1.AddCell(cell8);
                PdfPCell cell9 = new PdfPCell(new Phrase(pCabecera.Serie_Documento + " - " + pCabecera.Numero_Documento, font));
                cell9.Border = 0;
                cell9.HorizontalAlignment = 1;
                table1.AddCell(cell9);
                PdfPCell cell10 = new PdfPCell(new Phrase("Señor(es) : " + pCabecera.RSocial_Receptor, font));
                cell10.Border = 0;
                cell10.HorizontalAlignment = 0;
                table1.AddCell(cell10);
                PdfPCell cell11 = new PdfPCell(new Phrase("Dirección : " + pCabecera.Direccion_Receptor, font));
                cell11.Border = 0;
                cell11.HorizontalAlignment = 0;
                table1.AddCell(cell11);
                PdfPCell cell12 = new PdfPCell(new Phrase("R.U.C. N° : " + pCabecera.NroDoc_Receptor, font));
                cell12.Border = 0;
                cell12.HorizontalAlignment = 0;
                table1.AddCell(cell12);
                PdfPCell cell13 = new PdfPCell(new Phrase("Fecha de Emisión: " + Convert.ToDateTime(pCabecera.Fecha_Emision).ToString("dd/MM/yyyy") + " " + pCabecera.Hora_Emision, font));
                cell13.Border = 0;
                cell13.HorizontalAlignment = 0;
                table1.AddCell(cell13);
                PdfPCell cell14 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell14.PaddingBottom = 0;
                cell14.Border = 0;
                cell14.HorizontalAlignment = 1;
                table1.AddCell(cell14);
                PdfPCell cell112 = new PdfPCell(new Phrase("DOCUMENTO QUE MODIFICA", font));
                cell112.Border = 0;
                cell112.HorizontalAlignment = 0;
                table1.AddCell(cell112);
                PdfPCell cell113 = new PdfPCell(new Phrase("Factura N°: " + pCabecera.Documento_Ref, font));
                cell113.Border = 0;
                cell113.HorizontalAlignment = 0;
                table1.AddCell(cell113);
                PdfPCell cell114 = new PdfPCell(new Phrase("Motivo    : " + pCabecera.Descripcion_Motivo_Ref, font));
                cell114.Border = 0;
                cell114.HorizontalAlignment = 0;
                table1.AddCell(cell114);
                PdfPCell cell115 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell115.PaddingBottom = 0;
                cell115.Border = 0;
                cell115.HorizontalAlignment = 1;
                table1.AddCell(cell115);
                PdfPTable table2 = new PdfPTable(4);
                table2.HorizontalAlignment = 0;
                table2.WidthPercentage = 100f;
                table2.SetWidths(new float[4] { 30f, 120f, 50f, 50f });
                PdfPCell cell15 = new PdfPCell(new Phrase("CANT", font));
                cell15.PaddingTop = 0;
                cell15.PaddingBottom = 0;
                cell15.HorizontalAlignment = 0;
                cell15.Border = 0;
                table2.AddCell(cell15);
                PdfPCell cell16 = new PdfPCell(new Phrase("DESCRIPCION", font));
                cell16.PaddingTop = 0;
                cell16.PaddingBottom = 0;
                cell16.HorizontalAlignment = 0;
                cell16.Border = 0;
                table2.AddCell(cell16);
                PdfPCell cell17 = new PdfPCell(new Phrase("P.UNI.", font));
                cell17.PaddingTop = 0;
                cell17.PaddingBottom = 0;
                cell17.HorizontalAlignment = 2;
                cell17.Border = 0;
                table2.AddCell(cell17);
                PdfPCell cell18 = new PdfPCell(new Phrase("TOTAL", font));
                cell18.PaddingTop = 0;
                cell18.PaddingBottom = 0;
                cell18.HorizontalAlignment = 2;
                cell18.Border = 0;
                table2.AddCell(cell18);
                table1.AddCell(table2);
                PdfPCell cell247 = new PdfPCell(new Phrase("-------------------------------------------------", font));
                cell247.PaddingTop = 0;
                cell247.Border = 0;
                cell247.HorizontalAlignment = 1;
                table1.AddCell(cell247);
                PdfPTable table3 = new PdfPTable(4);
                table3.HorizontalAlignment = 0;
                table3.WidthPercentage = 100f;
                table3.SetWidths(new float[4] { 30f, 120f, 50f, 50f });
                List<ComprobanteDetalle> comprobanteDetalle = pCabecera.LstComprobanteDetalle;
                int count = comprobanteDetalle.Count;
                int num1 = 30;
                int num2 = num1 - 1;
                for (int index = 0; index < count; ++index)
                {
                    PdfPCell cell19 = new PdfPCell(new Phrase(comprobanteDetalle[index].Cantidad.ToString(), font));
                    cell19.PaddingTop = 0;
                    cell19.PaddingBottom = 0;
                    cell19.Border = 0;
                    cell19.HorizontalAlignment = 0;
                    table3.AddCell(cell19);
                    PdfPCell cell20 = new PdfPCell(new Phrase(comprobanteDetalle[index].Descripcion_Articulo, font));
                    cell20.PaddingTop = 0;
                    cell20.PaddingBottom = 0;
                    cell20.Border = 0;
                    cell20.HorizontalAlignment = 0;
                    table3.AddCell(cell20);
                    PdfPCell cell21 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Precio_Unitario_SinIGV.ToString("#0.00"), font));
                    cell21.PaddingTop = 0;
                    cell21.PaddingBottom = 0;
                    cell21.Border = 0;
                    cell21.HorizontalAlignment = 2;
                    table3.AddCell(cell21);
                    PdfPCell cell22 = new PdfPCell(new Phrase(comprobanteDetalle[index].EsAnticipo ? "-" : comprobanteDetalle[index].Importe_SubTotal.ToString("#,##0.00"), font));
                    cell22.PaddingTop = 0;
                    cell22.PaddingBottom = 0;
                    cell22.Border = 0;
                    cell22.HorizontalAlignment = 2;
                    table3.AddCell(cell22);
                }
                table1.AddCell(table3);
                PdfPTable pdfPtable4 = new PdfPTable(3);
                pdfPtable4.HorizontalAlignment = 0;
                pdfPtable4.WidthPercentage = 100f;
                pdfPtable4.SetWidths(new float[3] { 150f, 20f, 100f });
                PdfPCell cell32 = new PdfPCell(new Phrase("Operación Gravada", font));
                cell32.Border = 0;
                pdfPtable4.AddCell(cell32);
                PdfPCell cell33 = new PdfPCell(new Phrase(pMoneda, font));
                cell33.Border = 0;
                pdfPtable4.AddCell(cell33);
                PdfPCell cell34 = new PdfPCell(new Phrase(pCabecera.Importe_Gravado.ToString("#,##0.00"), font));
                cell34.Border = 0;
                cell34.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell34);
                PdfPCell cell35 = new PdfPCell(new Phrase("Operación Exonerada", font));
                cell35.Border = 0;
                pdfPtable4.AddCell(cell35);
                PdfPCell cell36 = new PdfPCell(new Phrase(pMoneda, font));
                cell36.Border = 0;
                pdfPtable4.AddCell(cell36);
                PdfPCell cell37 = new PdfPCell(new Phrase(pCabecera.Importe_Exonerado.ToString("#,##0.00"), font));
                cell37.Border = 0;
                cell37.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell37);
                PdfPCell cell38 = new PdfPCell(new Phrase("Operación Inafecta", font));
                cell38.Border = 0;
                pdfPtable4.AddCell(cell38);
                PdfPCell cell39 = new PdfPCell(new Phrase(pMoneda, font));
                cell39.Border = 0;
                pdfPtable4.AddCell(cell39);
                PdfPCell cell40 = new PdfPCell(new Phrase(pCabecera.Importe_Inafecto.ToString("#,##0.00"), font));
                cell40.Border = 0;
                cell40.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell40);
                PdfPCell cell41 = new PdfPCell(new Phrase("Operación Gratuita", font));
                cell41.Border = 0;
                pdfPtable4.AddCell(cell41);
                PdfPCell cell42 = new PdfPCell(new Phrase(pMoneda, font));
                cell42.Border = 0;
                pdfPtable4.AddCell(cell42);
                PdfPCell cell43 = new PdfPCell(new Phrase(pCabecera.Importe_Gratuito.ToString("#,##0.00"), font));
                cell43.Border = 0;
                cell43.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell43);
                PdfPCell cell44 = new PdfPCell(new Phrase("Total Descuento", font));
                cell44.Border = 0;
                pdfPtable4.AddCell(cell44);
                PdfPCell cell45 = new PdfPCell(new Phrase(pMoneda, font));
                cell45.Border = 0;
                pdfPtable4.AddCell(cell45);
                PdfPCell cell46 = new PdfPCell(new Phrase(pCabecera.Importe_DctoGlobal.ToString("#,##0.00"), font));
                cell46.Border = 0;
                cell46.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell46);
                PdfPCell cell47 = new PdfPCell(new Phrase("I.G.V. (" + this.IGV + "%)", font));
                cell47.Border = 0;
                pdfPtable4.AddCell(cell47);
                PdfPCell cell48 = new PdfPCell(new Phrase(pMoneda, font));
                cell48.Border = 0;
                pdfPtable4.AddCell(cell48);
                PdfPCell cell49 = new PdfPCell(new Phrase(pCabecera.Importe_IGV.ToString("#,##0.00"), font));
                cell49.Border = 0;
                cell49.HorizontalAlignment = 2;
                pdfPtable4.AddCell(cell49);
                if (pCabecera.Importe_Percepcion == new Decimal(0))
                {
                    PdfPCell cell25 = new PdfPCell(new Phrase("Importe Total", font));
                    cell25.Border = 0;
                    pdfPtable4.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase(pMoneda, font));
                    cell26.Border = 0;
                    pdfPtable4.AddCell(cell26);
                    PdfPCell cell27 = new PdfPCell(new Phrase(pCabecera.Importe_Total.ToString("#,##0.00"), font));
                    cell27.Border = 0;
                    cell27.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell27);
                }
                else
                {
                    PdfPCell cell25 = new PdfPCell(new Phrase("Total a Pagar", font));
                    cell25.Border = 0;
                    cell25.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell25);
                    PdfPCell cell26 = new PdfPCell(new Phrase(pMoneda, font));
                    cell26.Border = 0;
                    pdfPtable4.AddCell(cell26);
                    PdfPCell cell27 = new PdfPCell(new Phrase(pCabecera.Importe_Total.ToString("#,##0.00"), font));
                    cell27.Border = 0;
                    cell27.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell27);
                    PdfPCell cell28 = new PdfPCell(new Phrase("Percepción", font));
                    cell28.Border = 0;
                    cell28.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell28);
                    PdfPCell cell29 = new PdfPCell(new Phrase(pMoneda, font));
                    cell29.Border = 0;
                    pdfPtable4.AddCell(cell29);
                    PdfPCell cell30 = new PdfPCell(new Phrase(pCabecera.Importe_Percepcion.ToString("#,##0.00"), font));
                    cell30.Border = 0;
                    cell30.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell30);
                    PdfPCell cell31 = new PdfPCell(new Phrase("Importe Total", font));
                    cell31.Border = 0;
                    cell31.PaddingLeft = 10f;
                    pdfPtable4.AddCell(cell31);
                    PdfPCell cell50 = new PdfPCell(new Phrase(pMoneda, font));
                    cell50.Border = 0;
                    pdfPtable4.AddCell(cell50);
                    PdfPCell cell51 = new PdfPCell(new Phrase(pCabecera.Importe_Cobrado.ToString("#,##0.00"), font));
                    cell51.Border = 0;
                    cell51.HorizontalAlignment = 2;
                    pdfPtable4.AddCell(cell51);
                }
                table1.AddCell(pdfPtable4);
                PdfPTable pdfPtable5 = new PdfPTable(2);
                pdfPtable5.HorizontalAlignment = 0;
                pdfPtable5.WidthPercentage = 100f;
                pdfPtable5.SetWidths(new float[2] { 30f, 200f });
                PdfPCell cell551 = new PdfPCell(new Phrase("SON: ", font));
                cell551.HorizontalAlignment = 0;
                cell551.Border = 0;
                pdfPtable5.AddCell(cell551);
                PdfPCell cell53 = new PdfPCell(new Phrase(pCabecera.Texto_Importe_Total, font));
                cell53.HorizontalAlignment = 0;
                cell53.Border = 0;
                pdfPtable5.AddCell(cell53);
                table1.AddCell(pdfPtable5);
                PdfPCell cell210 = new PdfPCell(new Phrase("Representación gráfica del documento electrónico," + Environment.NewLine + "puede ser consultado en la siguiente página: " + Environment.NewLine + this.LINK_DESCARGA_ARCHIVOS, font));
                cell210.Border = 0;
                cell210.HorizontalAlignment = 1;
                table1.AddCell(cell210);
                PdfPCell cell211 = new PdfPCell(new Phrase("GRACIAS POR SU PREFERENCIA", font));
                cell211.Border = 0;
                cell211.HorizontalAlignment = 1;
                table1.AddCell(cell211);
                string[] strArray1 = new string[6] { pCabecera.NroDoc_Emisor + "|" + pCabecera.Codigo_Documento + "|" + pCabecera.Serie_Documento + "|" + pCabecera.Numero_Documento, "|", null, null, null, null };
                string[] strArray2 = strArray1;
                string str = pCabecera.Importe_Total.ToString();
                strArray2[2] = str;
                strArray1[3] = "|";
                strArray1[4] = pCabecera.Fecha_Emision.ToString("DD-MM-YY");
                strArray1[5] = "|";
                iTextSharp.text.Image image = GenerarArchivo.RetornarCodigoQR(string.Concat(strArray1));
                image.SetAbsolutePosition(0.0f, 0.0f);
                iTextSharp.text.Rectangle pageSize = instance1.PageSize;
                PdfTemplate template = new PdfContentByte(instance1).CreateTemplate(400f, 100f);
                template.AddImage(image);
                pdfPtable1.AddCell(table1);
                PdfContentByte directContent = instance1.DirectContent;
                directContent.BeginText();
                directContent.AddTemplate(template, 75f, 5f);
                directContent.EndText();
                directContent.Stroke();
                document.Add((IElement)pdfPtable1);
                document.Close();
                byte[] array = memoryStream.ToArray();
                System.IO.File.WriteAllBytes(pFileName, array);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GeneraPDFA4GuiaRemision(GuiaRemisionCabecera pCabecera, RespuestaSunat pRespuesta)
        {
            try
            {
                if (pCabecera == null)
                    return;
                string str_pdf = pCabecera.NroDoc_Emisor + "-" + pCabecera.Tipo_Documento + "-" + pCabecera.Serie_Documento + "-" + pCabecera.Numero_Documento + ".pdf";
                pRespuesta.RutaPDF = this.RUTA_GUIAREMISION + str_pdf;
                PdfPCell cell = new PdfPCell();
                string str = ConfigurationManager.AppSettings["LOGO_EMPRESA"];
                Document document = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                MemoryStream stream = new MemoryStream();
                PdfWriter instance = PdfWriter.GetInstance(document, stream);
                iTextSharp.text.Font font = FontFactory.GetFont("Verdana", 12f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font2 = FontFactory.GetFont("Verdana", 10f, 1, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font3 = FontFactory.GetFont("Verdana", 6.3f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font3_tel_email = FontFactory.GetFont("Verdana", 7.3f, 0, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font_datos_empresa_direccion = FontFactory.GetFont("Verdana", 7.6f, iTextSharp.text.Font.BOLD, new BaseColor(ColorTranslator.FromHtml("#000000")));
                iTextSharp.text.Font font_datos_empresa_web = FontFactory.GetFont("Verdana", 7.6f, iTextSharp.text.Font.BOLD, new BaseColor(ColorTranslator.FromHtml("#0a4f8a")));
                iTextSharp.text.Font font3_bold = FontFactory.GetFont("Verdana", 6.5f, iTextSharp.text.Font.BOLD, new BaseColor(ColorTranslator.FromHtml("#000000")));
                BaseColor color = new BaseColor(ColorTranslator.FromHtml("#EBEBEB"));
                document.Open();
                #region [table - cabecera / diseño]
                PdfPTable pdfPtable1 = new PdfPTable(3);
                pdfPtable1.HorizontalAlignment = 0;
                pdfPtable1.WidthPercentage = 100f;
                pdfPtable1.DefaultCell.Border = 0;
                PdfPTable table1 = new PdfPTable(1);
                table1.HorizontalAlignment = 0;
                table1.DefaultCell.Border = 0;
                iTextSharp.text.Image instance2 = iTextSharp.text.Image.GetInstance(str);
                instance2.ScalePercent(30f);
                PdfPCell cell1 = new PdfPCell(instance2);
                cell1.Border = 0;
                cell1.HorizontalAlignment = 0;
                table1.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("", font2)); //pCabecera.RSocial_Emisor
                cell2.PaddingTop = 5f;
                cell2.Border = 0;
                cell2.HorizontalAlignment = 0;
                table1.AddCell(cell2);
                pdfPtable1.AddCell(table1);
                PdfPTable table2 = new PdfPTable(1);
                table2.HorizontalAlignment = 1;
                table2.DefaultCell.Border = 0;
                PdfPCell cell3 = new PdfPCell(new Phrase("Oficina Principal", font3));
                cell3.PaddingTop = 20f;
                cell3.Border = 0;
                cell3.HorizontalAlignment = 1;
                table2.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase(pCabecera.Direccion_Emisor, font3));
                cell4.Border = 0;
                cell4.HorizontalAlignment = 1;
                table2.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase(pCabecera.Dist_Emisor + " - " + pCabecera.Prov_Emisor + " - " + pCabecera.Dpto_Emisor, font3));
                cell5.Border = 0;
                cell5.HorizontalAlignment = 1;
                table2.AddCell(cell5);
                pdfPtable1.AddCell(table2);
                PdfPTable table3 = new PdfPTable(1);
                table3.HorizontalAlignment = 1;
                PdfPCell cell6 = new PdfPCell(new Phrase("R.U.C. N° " + pCabecera.NroDoc_Emisor, font));
                cell6.PaddingTop = 10f;
                cell6.Border = 13;
                cell6.HorizontalAlignment = 1;
                table3.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("GUIA DE REMISION ELECTRONICA - REMITENTE", font));
                cell7.PaddingTop = 5f;
                cell7.Border = 12;
                cell7.HorizontalAlignment = 1;
                table3.AddCell(cell7);
                PdfPCell cell8 = new PdfPCell(new Phrase(pCabecera.Serie_Documento + " - " + pCabecera.Numero_Documento, font));
                cell8.PaddingTop = 5f;
                cell8.Border = 12;
                cell8.HorizontalAlignment = 1;
                table3.AddCell(cell8);
                PdfPCell cell9 = new PdfPCell(new Phrase(" "));
                cell9.PaddingTop = 5f;
                cell9.Border = 14;
                cell9.HorizontalAlignment = 1;
                table3.AddCell(cell9);
                pdfPtable1.AddCell(table3);
                #endregion
                #region [table5 - cabecera]
                PdfPTable table5 = new PdfPTable(6);
                table5.HorizontalAlignment = 0;
                table5.WidthPercentage = 100f;
                table5.SpacingBefore = 5f;
                table5.SetWidths(new float[] { 90f, 90f, 90f, 45f, 90f, 90f });
                cell = new PdfPCell(new Phrase("Destinatario", font3_bold));
                cell.Border = 5;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + pCabecera.RSocial_Destino, font3));
                cell.Colspan = 5;
                cell.Border = 9;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase("Dirección", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = 4;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + pCabecera.Direccion_Destino, font3));
                cell.Colspan = 5;
                cell.PaddingTop = 5f;
                cell.Border = 8;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase("R.U.C. N°", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = 4;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + pCabecera.NroDoc_Destino, font3));
                cell.Colspan = 5;
                cell.PaddingTop = 5f;
                cell.Border = 8;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase("Pto. Partida", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = 4;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + pCabecera.Direccion_Partida, font3));
                cell.Colspan = 5;
                cell.PaddingTop = 5f;
                cell.Border = 8;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase("Pto. LLegada", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = 4;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + pCabecera.Direccion_Llegada, font3));
                cell.Colspan = 5;
                cell.PaddingTop = 5f;
                cell.Border = 8;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase("Fecha Emisión", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = 4;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + Convert.ToDateTime(pCabecera.Fecha_Emision).ToString("dd/MM/yyyy"), font3));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase("Fecha Partida", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + Convert.ToDateTime(pCabecera.Fecha_Inicio_Traslado).ToString("dd/MM/yyyy"), font3));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = 8;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase("Motivo del Traslado", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = 6;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + pCabecera.Motivo_Traslado + " - " + pCabecera.Descripcion_Motivo_Traslado, font3));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = 2;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase("Modalidad", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = 2;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + pCabecera.Descripcion_Modalidad_Transporte, font3));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = 10;
                cell.HorizontalAlignment = 0;
                table5.AddCell(cell);
                #endregion
                #region [table6 - detalle]
                PdfPTable table6 = new PdfPTable(6);
                table6.HorizontalAlignment = 0;
                table6.WidthPercentage = 100f;
                table6.SpacingBefore = 5f;
                table6.SetWidths(new float[] { 15f, 50f, 230f, 30f, 50f, 50f });
                cell = new PdfPCell(new Phrase("IT", font3));
                cell.BackgroundColor = color;
                cell.HorizontalAlignment = 1;
                cell.PaddingTop = 5f;
                cell.PaddingBottom = 5f;
                cell.Border = 15;
                table6.AddCell(cell);
                cell = new PdfPCell(new Phrase("CODIGO", font3));
                cell.BackgroundColor = color;
                cell.HorizontalAlignment = 1;
                cell.PaddingTop = 5f;
                cell.PaddingBottom = 5f;
                cell.Border = 15;
                table6.AddCell(cell);
                cell = new PdfPCell(new Phrase("DESCRIPCION", font3));
                cell.BackgroundColor = color;
                cell.HorizontalAlignment = 1;
                cell.PaddingTop = 5f;
                cell.PaddingBottom = 5f;
                cell.Border = 15;
                table6.AddCell(cell);
                cell = new PdfPCell(new Phrase("U.M.", font3));
                cell.BackgroundColor = color;
                cell.HorizontalAlignment = 1;
                cell.PaddingTop = 5f;
                cell.PaddingBottom = 5f;
                cell.Border = 15;
                table6.AddCell(cell);
                cell = new PdfPCell(new Phrase("UND", font3));
                cell.BackgroundColor = color;
                cell.HorizontalAlignment = 1;
                cell.PaddingTop = 5f;
                cell.PaddingBottom = 5f;
                cell.Border = 15;
                table6.AddCell(cell);
                cell = new PdfPCell(new Phrase("PESO" + Environment.NewLine + "DESPACHO", font3));
                cell.BackgroundColor = color;
                cell.HorizontalAlignment = 1;
                cell.PaddingTop = 5f;
                cell.PaddingBottom = 5f;
                cell.Border = 15;
                table6.AddCell(cell);
                List<GuiaRemisionDetalle> lstComprobanteDetalle = pCabecera.LstGuiaDetalle;
                int count = lstComprobanteDetalle.Count;
                int num2 = 25;
                int num3 = num2 - 1;
                for (int i = 0; i < num2; i++)
                {
                    if (i < count)
                    {
                        cell = new PdfPCell(new Phrase(lstComprobanteDetalle[i].NroItem, font3));
                        cell.Border = 14;
                        cell.HorizontalAlignment = 1;
                        table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(lstComprobanteDetalle[i].Codigo_Articulo, font3));
                        cell.Border = 14;
                        cell.HorizontalAlignment = 1;
                        table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(lstComprobanteDetalle[i].Descripcion_Articulo, font3));
                        cell.Border = 14;
                        cell.HorizontalAlignment = 0;
                        table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(lstComprobanteDetalle[i].Codigo_Unidad, font3));
                        cell.Border = 14;
                        cell.HorizontalAlignment = 1;
                        table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(lstComprobanteDetalle[i].Descripcion_Unidad, font3));
                        cell.Border = 14;
                        cell.HorizontalAlignment = 1;
                        table6.AddCell(cell);
                        //cell = new PdfPCell(new Phrase("", font3));
                        //cell.Border = 14;
                        //cell.HorizontalAlignment = 2;
                        //table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(lstComprobanteDetalle[i].Cantidad.ToString("#,##0.00"), font3));
                        cell.Border = 14;
                        cell.HorizontalAlignment = 2;
                        table6.AddCell(cell);
                    }
                    else
                    {
                        cell = new PdfPCell(new Phrase(" ", font3));
                        cell.Border = ((num3 == i) ? 14 : 12);
                        cell.HorizontalAlignment = 0;
                        table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(" ", font3));
                        cell.Border = ((num3 == i) ? 14 : 12);
                        cell.HorizontalAlignment = 0;
                        table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(" ", font3));
                        cell.Border = ((num3 == i) ? 14 : 12);
                        cell.HorizontalAlignment = 2;
                        table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(" ", font3));
                        cell.Border = ((num3 == i) ? 14 : 12);
                        cell.HorizontalAlignment = 0;
                        table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(" ", font3));
                        cell.Border = ((num3 == i) ? 14 : 12);
                        cell.HorizontalAlignment = 2;
                        table6.AddCell(cell);
                        cell = new PdfPCell(new Phrase(" ", font3));
                        cell.Border = ((num3 == i) ? 14 : 12);
                        cell.HorizontalAlignment = 2;
                        table6.AddCell(cell);
                    }
                }

                cell = new PdfPCell(new Phrase("Código Hash :", font3));
                cell.Colspan = 2;
                cell.Border = 15;
                table6.AddCell(cell);
                cell = new PdfPCell(new Phrase(pRespuesta.DigestValue, font3));
                cell.Colspan = 4;
                cell.Border = 14;
                cell.PaddingLeft = 10f;
                table6.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.Colspan = 7;
                cell.Border = 0;
                table6.AddCell(cell);
                #endregion
                #region [table7 - datos del transportista]
                PdfPTable table7 = new PdfPTable(11);
                table7.HorizontalAlignment = 0;
                table7.WidthPercentage = 100f;
                table7.SpacingBefore = 5f;
                table7.SetWidths(new float[] { 110f, 90f, 90f, 90f, 90f, 65f, 90f, 90f, 90f, 90f, 90f });
                cell = new PdfPCell(new Phrase("TRANSPORTISTA", font3_bold));
                cell.Colspan = 2;
                cell.Border = 5;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + pCabecera.RSocial_Transportista, font3));
                cell.Colspan = 6;
                cell.Border = 9;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.Colspan = 3;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("R.U.C.", font3_bold));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = 4;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + pCabecera.NroDoc_Transportista, font3));
                cell.Colspan = 6;
                cell.PaddingTop = 5f;
                cell.Border = 8;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.Colspan = 3;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("CHOFER", font3_bold));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = 4;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(": JUAN SANCHEZ PEREZ", font3));
                cell.Colspan = 3;
                cell.PaddingTop = 5f;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("BREVETE", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + "LICENCIA 123", font3));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = 8;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.Colspan = 3;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("MARCA UNIDAD TRANSPORTE", font3_bold));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = 4;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(": -", font3));
                cell.Colspan = 3;
                cell.PaddingTop = 5f;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("PLACA", font3_bold));
                cell.PaddingTop = 5f;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + "HML-258", font3));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = 8;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.Colspan = 3;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("CONSTANCIA DE INSCRIPCION", font3_bold));
                cell.Colspan = 2;
                cell.PaddingTop = 5f;
                cell.Border = 6;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(": " + "159753258369", font3));
                cell.Colspan = 6;
                cell.PaddingTop = 5f;
                cell.Border = 10;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("RECIBI CONFORME" + Environment.NewLine + "CLIENTE", font3));
                cell.Colspan = 2;
                cell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                cell.HorizontalAlignment = 1;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.PaddingTop = 40f;
                cell.Colspan = 11;
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("VENTAS", font3));
                cell.Colspan = 2;
                cell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                cell.HorizontalAlignment = 1;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("RECIBI CONFORME" + Environment.NewLine + "TRANSPORTISTA", font3));
                cell.Colspan = 2;
                cell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                cell.HorizontalAlignment = 1;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("ALMACEN", font3));
                cell.Colspan = 2;
                cell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                cell.HorizontalAlignment = 1;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", font3));
                cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cell.HorizontalAlignment = 0;
                table7.AddCell(cell);
                cell = new PdfPCell(new Phrase("VIGILANCIA", font3));
                cell.Colspan = 2;
                cell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                cell.HorizontalAlignment = 1;
                table7.AddCell(cell);
                #endregion
                string str4 = string.Empty;
                str4 = pCabecera.NroDoc_Emisor + "|" + pCabecera.Tipo_Documento + "|" + pCabecera.Serie_Documento + "|" + pCabecera.Numero_Documento;
                iTextSharp.text.Image image2 = RetornarCodigoQR(str4 + "|" + pCabecera.Fecha_Emision.ToString("DD-MM-YY") + "|");
                image2.SetAbsolutePosition(0f, 0f);
                iTextSharp.text.Rectangle rectangle = instance.PageSize;
                PdfContentByte num5 = new PdfContentByte(instance);
                PdfTemplate template = num5.CreateTemplate(400f, 100f);
                template.AddImage(image2);
                BaseFont font4 = BaseFont.CreateFont("Helvetica", "Cp1250", true);
                num5 = new PdfContentByte(instance);
                num5 = instance.DirectContent;
                num5.BeginText();
                num5.SetFontAndSize(font4, 6.5f);
                num5.ShowTextAligned(1, "Representación gráfica del documento electrónico, este puede ser consultado en " + this.LINK_DESCARGA_ARCHIVOS, rectangle.Width / 2f, 45f, 0f);
                num5.EndText();
                num5.BeginText();
                num5.SetFontAndSize(font4, 6.5f);
                num5.ShowTextAligned(1, "Autorizado mediante Resolución N°." + this.NRO_RESOLUCION + "/SUNAT.", rectangle.Width / 2f, 35f, 0f);
                num5.EndText();
                num5.AddTemplate(template, (rectangle.Width / 2f) - (image2.Width / 2f), 55f);
                num5.Stroke();
                document.Add(pdfPtable1);
                document.Add(table5);
                document.Add(table6);
                document.Add(table7);
                document.Close();
                byte[] bytes = stream.ToArray();
                File.WriteAllBytes(pRespuesta.RutaPDF, bytes);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static iTextSharp.text.Image RetornarCodigoQR(string pData)
        {
            IDictionary<EncodeHintType, object> hints = (IDictionary<EncodeHintType, object>)new Dictionary<EncodeHintType, object>();
            hints.Add(EncodeHintType.ERROR_CORRECTION, (object)ErrorCorrectionLevel.Q);
            iTextSharp.text.Image image = new BarcodeQRCode(pData, 2, 2, hints).GetImage();
            image.ScaleAbsolute(80f, 80f);

            return image;
        }

        private void Comprimir(string pRutaZIP, string pRutaXML)
        {
            try
            {
                using (ZipFile zipFile = new ZipFile(pRutaZIP))
                {
                    zipFile.AddFile(pRutaXML, "");
                    zipFile.Save();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Descomprimir(string pRutaZIP, string pRutaXML)
        {
            int intentos = 1; bool error = true;

            while (error)
            {
                try
                {
                    hpLog.generarLog("intento "+intentos+": Read route File " + pRutaZIP);
                    System.Threading.Thread.Sleep(1000);
                    using (ZipFile zipFile = ZipFile.Read(pRutaZIP))
                    {
                        foreach (ZipEntry zipEntry in zipFile)
                            zipEntry.Extract(pRutaXML);
                    }
                    error = false;
                }
                catch (ZipException ex)
                {
                    intentos++;
                    if (intentos > 3) throw ex;
                }
                catch (Exception ex1)
                {
                    throw ex1;
                }
            }
        }

        public void CopiarXMLAServidorFTP(string pArchivo, ServidorFTP pServidorFTP)
        {
            try
            {
                if (!System.IO.File.Exists(pArchivo))
                    throw new Exception("El archivo no se encuentra en la siguiente ruta: " + pArchivo);

                FileInfo fileInfo = new FileInfo(pArchivo);
                FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(pServidorFTP.RutaCarpeta + fileInfo.Name));
                ftpWebRequest.Credentials = (ICredentials)new NetworkCredential(pServidorFTP.Usuario, pServidorFTP.Contrasena);
                ftpWebRequest.KeepAlive = false;
                ftpWebRequest.Method = "STOR";
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.ContentLength = fileInfo.Length;

                int count1 = 2048;
                byte[] buffer = new byte[count1];

                using (FileStream fileStream = fileInfo.OpenRead())
                {
                    Stream requestStream = ftpWebRequest.GetRequestStream();

                    for (int count2 = fileStream.Read(buffer, 0, count1); count2 != 0; count2 = fileStream.Read(buffer, 0, count1))
                        requestStream.Write(buffer, 0, count2);

                    requestStream.Close();
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EnviarCorreo(Correo pCorreo)
        {
            try
            {
                MailMessage message = new MailMessage();

                foreach (string addresses in pCorreo.LstEnviarA)
                    message.To.Add(addresses);

                if (pCorreo.LstCopiarA != null && pCorreo.LstCopiarA.Count > 0)
                {
                    foreach (string addresses in pCorreo.LstCopiarA)
                        message.CC.Add(addresses);
                }

                message.From = new MailAddress(pCorreo.Email, pCorreo.Asunto, Encoding.UTF8);
                message.Subject = pCorreo.Asunto;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = pCorreo.Mensaje;
                message.BodyEncoding = Encoding.UTF8;

                if (pCorreo.LstAdjuntos != null && pCorreo.LstAdjuntos.Count > 0)
                {
                    foreach (Attachment lstAdjunto in pCorreo.LstAdjuntos)
                        message.Attachments.Add(lstAdjunto);
                }

                message.IsBodyHtml = true;

                new SmtpClient(pCorreo.Servidor)
                {
                    Credentials = ((ICredentialsByHost)new NetworkCredential(pCorreo.Usuario, pCorreo.Contrasena)),
                    Host = pCorreo.Servidor
                }.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidarRutas(string pRucEmisor)
        {
            try
            {
                string appSetting = ConfigurationManager.AppSettings["CAR-DOCUMENTOS"];

                string str = pRucEmisor;
                if (!Directory.Exists(appSetting))
                    throw new Exception("La carpeta principal de documentos no se ubica en la siguiente ruta: " + appSetting);

                foreach (string oLstCarpeta in this.oLstCarpetas)
                {
                    string path = appSetting + str + (object)Path.DirectorySeparatorChar + oLstCarpeta + (object)Path.DirectorySeparatorChar;
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    switch (oLstCarpeta)
                    {
                        case "FACTURA":
                            this.RUTA_FACTURA = path;
                            break;
                        case "BOLETA":
                            this.RUTA_BOLETA = path;
                            break;
                        case "NOTACREDITO":
                            this.RUTA_NOTACREDITO = path;
                            break;
                        case "NOTADEBITO":
                            this.RUTA_NOTADEBITO = path;
                            break;
                        case "COMUNICACIONBAJA":
                            this.RUTA_COMUNICACIONBAJA = path;
                            break;
                        case "RESUMENDIARIO":
                            this.RUTA_RESUMENDIARIO = path;
                            break;
                        case "GUIAREMISION":
                            this.RUTA_GUIAREMISION = path;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
