using System;

namespace GMT_Sfe
{
  public class ComprobanteDetalle
  {
    public string NroItem { get; set; }

    public string Codigo_Articulo { get; set; }

    public string Codigo_Producto_Sunat { get; set; }

    public string Codigo_Unidad { get; set; }

    public string Descripcion_Articulo { get; set; }

    public Decimal Cantidad { get; set; }

    public Decimal Precio_Unitario_SinIGV { get; set; }

    public Decimal Importe_SubTotal { get; set; }

    public Decimal Importe_Descuento { get; set; }

    public Decimal Porcentaje_Descuento { get; set; }

    public Decimal Importe_ValorVenta { get; set; }

    public Decimal Importe_IGV { get; set; }

    public Decimal Importe_ISC { get; set; }

    public Decimal Porcentaje_ISC { get; set; }

    public Decimal Precio_Unitario_ConIGV { get; set; }

    public Decimal Importe_Total { get; set; }

    public string Tipo_AfeccionIGV { get; set; }

    public bool EsGravado { get; set; }

    public bool EsExonerado { get; set; }

    public bool EsInafecto { get; set; }

    public bool EsGratuito { get; set; }

    public bool EsAnticipo { get; set; }

    public string Codigo_Documento_Anticipo { get; set; }

    public string Serie_Documento_Anticipo { get; set; }

    public string Numero_Documento_Anticipo { get; set; }
  }
}
