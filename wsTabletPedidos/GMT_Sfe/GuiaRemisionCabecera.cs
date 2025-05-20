using System;
using System.Collections.Generic;

namespace GMT_Sfe
{
    public class GuiaRemisionCabecera
    {
        public string TipoDoc_Emisor { get; set; }

        public string NroDoc_Emisor { get; set; }

        public string RSocial_Emisor { get; set; }

        public string Direccion_Emisor { get; set; }

        public string Dpto_Emisor { get; set; }

        public string Prov_Emisor { get; set; }

        public string Dist_Emisor { get; set; }

        public string Tipo_Documento { get; set; }

        public string Serie_Documento { get; set; }

        public string Numero_Documento { get; set; }

        public DateTime Fecha_Emision { get; set; }

        public string Hora_Emision { get; set; }

        public string Observaciones { get; set; }

        public string Tipo_Documento_Rel { get; set; }

        public string Serie_Documento_Rel { get; set; }

        public string Numero_Documento_Rel { get; set; }

        public string TipoDoc_Destino { get; set; }

        public string NroDoc_Destino { get; set; }

        public string RSocial_Destino { get; set; }

        public string Direccion_Destino { get; set; }

        public string TipoDoc_Transportista { get; set; }

        public string NroDoc_Transportista { get; set; }

        public string RSocial_Transportista { get; set; }

        public string Motivo_Traslado { get; set; }

        public string Descripcion_Motivo_Traslado  { get; set; }

        public Decimal Peso_Bruto { get; set; }

        public string Unidad_Medida_Peso_Bruto { get; set; }

        public Decimal Cantidad_Bultos { get; set; }

        public string Modalidad_Transporte { get; set; }

        public string Descripcion_Modalidad_Transporte { get; set; }

        public DateTime Fecha_Inicio_Traslado { get; set; }

        public string TipoDoc_Conductor { get; set; }

        public string NroDoc_Conductor { get; set; }

        public string Placa_Vehiculo { get; set; }

        public string Ubigeo_Llegada { get; set; }

        public string Direccion_Llegada { get; set; }

        public string Numero_Contenedor { get; set; }

        public string Ubigeo_Partida { get; set; }

        public string Direccion_Partida { get; set; }

        public string Codigo_Puerto { get; set; }

        public List<GuiaRemisionDetalle> LstGuiaDetalle { get; set; }
    }
}
