using System;
using System.Collections.Generic;

namespace GMT_Sfe
{
    public class ComprobanteCabecera
    {
        public string TipoDoc_Emisor { get; set; }

        public string NroDoc_Emisor { get; set; }

        public string RSocial_Emisor { get; set; }

        public string Codigo_Domicilio_Emisor { get; set; }

        public string NombreCorto_Emisor { get; set; }

        public string Direccion_Emisor { get; set; }

        public string Dpto_Emisor { get; set; }

        public string Prov_Emisor { get; set; }

        public string Dist_Emisor { get; set; }

        public string CodPais_Emisor { get; set; }

        public string TipoDoc_Receptor { get; set; }

        public string NroDoc_Receptor { get; set; }

        public string RSocial_Receptor { get; set; }

        public string Direccion_Receptor { get; set; }

        public string Telefono_Receptor { get; set; }

        public string Codigo_Documento { get; set; }

        public string Serie_Documento { get; set; }

        public string Numero_Documento { get; set; }

        public DateTime Fecha_Emision { get; set; }

        public string Hora_Emision { get; set; }

        public DateTime? Fecha_Vencimiento { get; set; }

        public string Codigo_Moneda { get; set; }

        public string Sigla_Moneda { get; set; }

        public string Tipo_Venta { get; set; }

        public Decimal Porcentaje_Detraccion { get; set; }

        public string Codigo_Detraccion { get; set; }

        public Decimal Importe_Detraccion { get; set; }

        public string NroCuenta_Detraccion { get; set; }

        public Decimal Importe_SubTotal { get; set; }

        public Decimal Importe_Descuento { get; set; }

        public Decimal Importe_DctoGlobal
        {
            get
            {
                return new Decimal(0);
            }
        }

        public Decimal Importe_ValorVenta { get; set; }

        public Decimal Importe_Gravado { get; set; }

        public Decimal Importe_Exonerado { get; set; }

        public Decimal Importe_Inafecto { get; set; }

        public Decimal Importe_Gratuito { get; set; }

        public Decimal PorcentajeIGV { get; set; }

        public Decimal PorcentajeDctoGlobal
        {
            get
            {
                return new Decimal(0);
            }
        }

        public Decimal Importe_IGV { get; set; }

        public Decimal Importe_ISC { get; set; }

        public Decimal Importe_Base_ISC { get; set; }

        public Decimal Importe_Total { get; set; }

        public Decimal Importe_OtrosCargos { get; set; }

        public Decimal Importe_OtrosTributos { get; set; }

        public Decimal Importe_Base_OtrosTributos { get; set; }

        public Decimal Importe_Percepcion { get; set; }

        public string Codigo_Percepcion { get; set; }

        public Decimal Porcentaje_Percepcion { get; set; }

        public Decimal Base_Percepcion { get; set; }

        public Decimal Importe_Cobrado { get; set; }

        public Decimal Importe_Anticipos { get; set; }

        public string Texto_Importe_Total { get; set; }

        public string Codigo_Documento_Ref { get; set; }

        public string Documento_Ref { get; set; }

        public DateTime? Fecha_Documento_Ref { get; set; }

        public string Codigo_Motivo_Ref { get; set; }

        public string Descripcion_Motivo_Ref { get; set; }

        public string Email_Receptor { get; set; }

        public string Email_Emisor { get; set; }

        public bool EsAnticipo { get; set; }

        public List<ComprobanteDetalle> LstComprobanteDetalle { get; set; }

        public List<FacturaGuias> LstGuias { get; set; }

        public List<FacturaFormaPago> LstFormaPago { get; set; }
    }
}
