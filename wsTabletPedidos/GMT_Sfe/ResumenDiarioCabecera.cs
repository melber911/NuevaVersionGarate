using System;
using System.Collections.Generic;

namespace GMT_Sfe
{
  public class ResumenDiarioCabecera
  {
    public string TipoDoc_Emisor { get; set; }

    public string NroDoc_Emisor { get; set; }

    public string RSocial_Emisor { get; set; }

    public string NombreCorto_Emisor { get; set; }

    public string Codigo_Moneda { get; set; }

    public DateTime Fecha_Emision { get; set; }

    public string Identificador { get; set; }

    public DateTime Fecha_Resumen { get; set; }

    public List<ResumenDiarioDetalle> LstResumenDetalle { get; set; }
  }
}
