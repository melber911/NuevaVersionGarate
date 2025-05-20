using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bussinessLayer;
using Common;

namespace WebSites
{
    public partial class DailySalesReport : System.Web.UI.Page
    {
        protected Report report = new Report();       
        protected void Page_Load(object sender, EventArgs e)
        {
            //report = (Report)Session["ReportData"];
            clsProducto lobjProducto = new clsProducto();
            clsSucursal sucu = new clsSucursal();
            var obj = sucu.obtenerEmpresa();
            byte[] imageData = (byte[])obj.Rows[0]["logo"];

            if (imageData != null)
            {
                string base64String = Convert.ToBase64String(imageData);
                imgLogo.ImageUrl = "data:image/png;base64," + base64String;
                imgLogo.ImageUrl = "data:image/png;base64," + base64String;
                imgLogo.Visible = true;
            }
            DataTable dtResponse = lobjProducto.obtenerReporteCajaGlobal(int.Parse( Request.QueryString["cajaID"].ToString()));
                report.RazonSocial = dtResponse.Rows[0]["RazonSocial"].ToString().ToUpper();
                report.RUC = dtResponse.Rows[0]["RUC"].ToString();
            report.Direccion = dtResponse.Rows[0]["Direccion"].ToString().ToUpper();
            report.Cajero = dtResponse.Rows[0]["usuarioAperturaCaja"].ToString().ToUpper();

            report.VentaEfectivo = decimal.Parse(dtResponse.Rows[0]["TotalVentaEfectivo"].ToString()) - decimal.Parse(dtResponse.Rows[0]["VueltoEfectivo"].ToString());
            report.VentaTarjeta = decimal.Parse(dtResponse.Rows[0]["TotalVentaVisa"].ToString()) - decimal.Parse(dtResponse.Rows[0]["VueltoTarjeta"].ToString());
            report.VentaDeposito = decimal.Parse(dtResponse.Rows[0]["TotalVentaYape"].ToString()) - decimal.Parse(dtResponse.Rows[0]["VueltoDeposito"].ToString());
            report.TotalVenta = report.VentaEfectivo + report.VentaTarjeta + report.VentaDeposito;

            report.OtrosIngresosEfectivo = decimal.Parse(dtResponse.Rows[0]["OtrosIngresosTotalEfect"].ToString());
            report.OtrosIngresosTarjeta = decimal.Parse(dtResponse.Rows[0]["OtrosIngresosTotalTarj"].ToString());
            report.OtrosIngresosDeposito = decimal.Parse(dtResponse.Rows[0]["OtrosIngresosTotalDep"].ToString());
            report.TotalOtrosIngresos = report.OtrosIngresosEfectivo + report.OtrosIngresosTarjeta + report.OtrosIngresosDeposito;

            report.Invitacion = decimal.Parse(dtResponse.Rows[0]["EfectivoInvitacion"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["TarjetaInvitacion"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["DepositoInvitacion"].ToString());
            report.GastosMotorizado = decimal.Parse(dtResponse.Rows[0]["EfectivoGastoMotorizado"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["TarjetaGastoMotorizado"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["DepositoGastoMotorizado"].ToString());
            report.ComisionTarjeta = decimal.Parse(dtResponse.Rows[0]["EfectivoComisionTarjeta"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["TarjetaComisionTarjeta"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["DepositoComisionTarjeta"].ToString());
            report.OtrosGastos = decimal.Parse(dtResponse.Rows[0]["EfectivoOtrosGastos"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["TarjetaOtrosGastos"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["DepositoOtrosGastos"].ToString());
            report.vuelto = decimal.Parse(dtResponse.Rows[0]["VueltoEfectivo"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["VueltoDeposito"].ToString()) +
                               decimal.Parse(dtResponse.Rows[0]["VueltoTarjeta"].ToString());

            report.TotalIngresos = report.TotalVenta + report.TotalOtrosIngresos
                - report.Invitacion - report.GastosMotorizado - report.ComisionTarjeta - report.OtrosGastos;

            //Datos Cajera
            report.CajeraSoles = decimal.Parse(dtResponse.Rows[0]["totalEfectivoCajera"].ToString());
            report.CajeraTarjeta = decimal.Parse(dtResponse.Rows[0]["totalTarjetaCajera"].ToString());
            report.CajeraDeposito = decimal.Parse(dtResponse.Rows[0]["totalDepositoCajera"].ToString());
            

            report.TotalCobrado = report.CajeraSoles+ report.CajeraTarjeta+ report.CajeraDeposito;

            report.Diferencia = report.TotalIngresos - report.TotalCobrado;


            //Datos informativos
            report.CajaInicial = decimal.Parse(dtResponse.Rows[0]["CajaInicial"].ToString());
            report.CajaActualSistema = decimal.Parse(dtResponse.Rows[0]["CajaActualSistema"].ToString());
            report.CajaActualCajera = decimal.Parse(dtResponse.Rows[0]["CajaActualCajera"].ToString());
            report.CajaActualDiferencia = decimal.Parse(dtResponse.Rows[0]["CajaActualSistema"].ToString()) -
                                           decimal.Parse(dtResponse.Rows[0]["CajaActualCajera"].ToString());
        }
    }
}