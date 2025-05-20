using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Report
    {
        public string ReportDate { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentTime { get; set; }
        public string RazonSocial { get; set; }
        public string RUC { get; set; }
        public string Direccion { get; set; }
        public string Cajero { get; set; }
        public string Administrador { get; set; }

        public decimal VentaEfectivo { get; set; }
        public decimal VentaTarjeta { get; set; }
        public decimal VentaDeposito { get; set; }
        public decimal TotalVenta { get; set; }

        public decimal OtrosIngresosEfectivo { get; set; }
        public decimal OtrosIngresosTarjeta { get; set; }
        public decimal OtrosIngresosDeposito { get; set; }
        public decimal TotalOtrosIngresos { get; set; }

        public decimal Invitacion { get; set; }
        public decimal GastosMotorizado { get; set; }
        public decimal ComisionTarjeta { get; set; }
        public decimal OtrosGastos { get; set; }
        public decimal vuelto { get; set; }

        public decimal CajaInicial { get; set; }
        public decimal CajaActualSistema { get; set; }
        public decimal CajaActualCajera { get; set; }
        public decimal CajaActualDiferencia{ get; set; }

        public decimal CajeraSoles { get; set; }
        public decimal CajeraDeposito { get; set; }
        public decimal CajeraTarjeta { get; set; }
        public decimal TotalCobrado { get; set; }
        public decimal Diferencia { get; set; }
        public decimal TotalIngresos { get; set; }
        

        public Report()
        {
            // Inicialización por defecto de los valores
            ReportDate = DateTime.Now.ToString("yyyy-MM-dd");
            CurrentDate = DateTime.Now.ToString("dd/MM/yy");
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            
        }
    }
}
