using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using GMT_Sfe;
namespace Common.Tests
{
    [TestClass()]
    public class HelperLogTests
    {
        [TestMethod()]
        public void generarLogTest()
        {
            ConfigurationManager.AppSettings["rutalog"] = System.IO.Path.GetTempPath();
            HelperLog hp = new HelperLog();
            string mensaje = "Esto es un ejemplo para generar log en la ruta temporal ";
            hp.generarLog(mensaje);
            Assert.IsTrue(System.IO.File.Exists(hp.PathLog));
            Assert.IsTrue(System.IO.File.ReadAllText(hp.PathLog).IndexOf(mensaje) != -1 );
        }
        private string oRUC = string.Empty;
        private string oRAZONSOCIAL = string.Empty;
        private string oDIRECCION = string.Empty;
        private string oDEPARTAMENTO = string.Empty;
        private string oPROVINCIA = string.Empty;
        private string oDISTRITO = string.Empty;
        RespuestaSunat oRESPUESTA = null;
        CuentaSunat oCUENTA_SUNAT = null;
        Certificado oCERTIFICADO = null;
        [TestMethod()]
        public void ValidarCDRComprobante()
        {
            oRUC = "20601486718";
            oRAZONSOCIAL = "INVERSIONES Y NEGOCIOS GRIMALDINA & MARTIN E.I.R.L";
            oDIRECCION = "C.P. EL PEDREGAL AV. CARLOS SHUTON Mz Z1 Lote 10";
            oDEPARTAMENTO = "AREQUIPA";
            oPROVINCIA = "CAYLLOMA";
            oDISTRITO = "MAJES";

            //oCUENTA_SUNAT = new CuentaSunat() { Usuario = oRUC + "MODDATOS", Contrasena = "Grm" };
            oCUENTA_SUNAT = new CuentaSunat() { Usuario = oRUC + "GRIMALD1", Contrasena = "Liberato92" };
            oCERTIFICADO = new Certificado() { Contrasena = "Gauchoparrillero123.", Ruta = ConfigurationManager.AppSettings["CAR-CERTIFICADOS"] + oRUC + ".pfx" };
            GenerarArchivo ar = new GenerarArchivo(oRUC, oCUENTA_SUNAT, oCERTIFICADO);
            var a = ar.ValidarCDRComprobante("20601486718", "01", "F001", "3510", "C:\\Users\\braya\\Downloads\\20601486718-01-F001-00003510.xml", false);
            var b = a;
        }
    }
}