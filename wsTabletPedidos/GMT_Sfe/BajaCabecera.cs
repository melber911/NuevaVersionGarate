using System;
using System.Collections.Generic;

namespace GMT_Sfe
{
  public class BajaCabecera
  {
    public string TipoDoc_Emisor { get; set; }

    public string NroDoc_Emisor { get; set; }

    public string RSocial_Emisor { get; set; }

    public string NombreCorto_Emisor { get; set; }

    public DateTime Fecha_Emision { get; set; }

    public string Identificador { get; set; }

    public string Ticket { get; set; }

    public DateTime Fecha_Baja { get; set; }

    public List<BajaDetalle> LstBajaDetalle { get; set; }
  }
}
