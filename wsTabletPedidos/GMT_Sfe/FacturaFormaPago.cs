using System;

namespace GMT_Sfe
{
    public class FacturaFormaPago
    {
        public string Forma_Pago { get; set; }
        public string Codigo_Moneda { get; set; }
        public Decimal Monto_Neto { get; set; }
        public DateTime Fecha_Pago { get; set; }
    }
}
