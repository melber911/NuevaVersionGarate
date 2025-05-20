using System;

namespace GMT_Sfe
{
    public class ResumenDiarioDetalle
    {
        public string Codigo_Documento { get; set; }

        public string Serie_Documento { get; set; }

        public string Numero_Documento { get; set; }

        public string TipoDoc_Receptor { get; set; }

        public string NroDoc_Receptor { get; set; }

        public string Codigo_Documento_Refe { get; set; }

        public string Documento_Refe { get; set; }

        public string Estado { get; set; }

        public string Regimen_Percepcion { get; set; }

        public Decimal Tasa_Percepcion { get; set; }

        public Decimal Importe_Percepcion { get; set; }

        public Decimal Base_Percepcion { get; set; }

        public Decimal Importe_Gravado { get; set; }

        public Decimal Importe_Exonerado { get; set; }

        public Decimal Importe_Inafecto { get; set; }

        public Decimal Importe_Gratuito { get; set; }

        public Decimal Importe_OtrosCargos { get; set; }

        public Decimal Importe_IGV { get; set; }

        public Decimal Importe_ISC { get; set; }

        public Decimal Importe_OtrosTributos { get; set; }

        public Decimal Importe_Total { get; set; }
    }
}
