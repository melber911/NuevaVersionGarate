<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailySalesReport.aspx.cs" Inherits="WebSites.DailySalesReport" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Reporte Diario de Venta</title>
    <!-- Bootstrap 5 CSS (CDN) -->
    <link
        rel="stylesheet"
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <style>
         body {
            font-family: 'Courier New', monospace;
            width: 80mm;
            margin: 0 auto;
            padding: 5px;
            font-size: 12px;
        }
        td {
  padding-top: 0 !important;
  padding-bottom: 0 !important;
}
        .border-lado{
            border-top: 1px solid #000;
            border-bottom: 1px solid #000;
        }
        .border-col-right {
            border-right: 1px solid #000;
        }

        .final-total {
            border-top: 1px solid #000;
            padding-top: 0.5rem;
            margin-top: 0.5rem;
            font-weight: bold;
            font-size: 1rem;
        }

        .section-divider {
            border-top: 1px solid #000;
            margin: 0.5rem 0;
        }
        .ticket-container {
            width: 100%;
            max-width: 300px;
            margin: 0 auto;
        }
      .logo {
    max-width: 150px; /* Ajusta según el tamaño de tu logo */
    height: auto;
    display: block;
    margin: 0 auto 5px; /* Centrado con margen inferior */
}
      .ticket-header {
    margin-bottom: 10px;
}
      .text-end .d-inline-block {
    text-align: left;
    padding: 2px 5px;
    border: 1px solid #ddd; /* Opcional: para mejor visualización */
    border-radius: 3px;
    background-color: #f8f9fa; /* Fondo claro para destacar */
}
.header-line {
    display: flex;
    align-items: center;
    margin-bottom: 10px;
}
        @media print {
            @page {
                size: 72mm auto;
                margin: 0;
            }
             .ticket-container {
            position: absolute; /* Cambia esto */
            top: 0; /* Añade esto */
            left: 0; /* Añade esto */
            padding: 2mm; /* Ajusta según necesites */
            width: 100%; 
        }
            .fixed-button {
                display: none;
            }
        }
        .fixed-button {
            position: sticky;
            bottom: 0;
            z-index: 1020;
            background: #f8f9fa;
            padding: 10px;
            text-align: center;
            border-bottom: 1px solid #ddd;
        }
    </style>

</head>
<body>
    <div class="ticket-container">

        <div class="ticket-header">
    <!-- Primera fila: Logo centrado -->
    <div class="text-center mb-2">
        <asp:Image ID="imgLogo" runat="server" CssClass="logo" ImageUrl="images/logoMesas.png" AlternateText="Logo" />
    </div>
    
    <!-- Segunda fila: Fecha y hora a la derecha -->
    <div class="text-end mb-2">
        <div class="d-inline-block text-start">
            <div><strong>Fecha:</strong> <%= report.CurrentDate %></div>
            <div><strong>Hora:</strong> <%= report.CurrentTime %></div>
        </div>
    </div>
    
    <!-- Título del reporte -->
    <div class="text-center fw-bold mb-2">
        REPORTE DIARIO DE VENTA POR CAJERO DEL DIA <%= report.ReportDate %>
    </div>
</div>
        <div class="row header-line pb-2">
            <div class="col-12">
                <div class="row mb-1">
                    <div class="col-auto fw-bold">RAZON SOCIAL :</div>
                    <div class="col"><%= report.RazonSocial %></div>
                </div>
                <div class="row mb-1">
                    <div class="col-auto fw-bold">R.U.C. :</div>
                    <div class="col"><%= report.RUC %></div>
                </div>
                <div class="row mb-1">
                    <div class="col-auto fw-bold">DIRECCION :</div>
                    <div class="col"><%= report.Direccion %></div>
                </div>
                <div class="row">
                    <div class="col-auto fw-bold">CAJERO(A) :</div>
                    <div class="col"><%= report.Cajero %></div>
                </div>
            </div>
        </div>

        <!-- Sección principal con 3 columnas -->
        <div class="row">
            <!-- Col 1: DATOS SISTEMA -->
            <div class="col-12 pe-4 mb-3">
                <h6 class="fw-bold pt-2 pb-2 mt-2 border-lado text-center">DATOS SISTEMA</h6>
                <table class="table table-borderless table-sm">
                    <tbody>
                        <tr>
                            <td >TOTAL VENTA EFECTIVO</td>
                            <td class="text-end"><%= report.VentaEfectivo %></td>
                        </tr>
                        <tr>
                            <td>TOTAL VENTA TARJETA</td>
                            <td class="text-end"><%= report.VentaTarjeta %></td>
                        </tr>
                        <tr>
                            <td>TOTAL VENTA DEPOSITO/YAPE</td>
                            <td class="text-end"><%= report.VentaDeposito %></td>
                        </tr>
                        <tr class="border-lado">
                            <td class="fw-bold pt-0 pb-0">TOTAL VENTA</td>
                            <td class="text-end fw-bold pt-0 pb-0"><%= report.TotalVenta %></td>
                        </tr>
                        <tr>
                            <td>TOTAL OTROS INGRESOS EFECTIVO</td>
                            <td class="text-end"><%= report.OtrosIngresosEfectivo %></td>
                        </tr>
                        <tr>
                            <td>TOTAL OTROS INGRESOS TARJETA</td>
                            <td class="text-end"><%= report.OtrosIngresosTarjeta %></td>
                        </tr>
                        <tr>
                            <td>TOTAL OTROS INGRESOS DEPOSITO</td>
                            <td class="text-end"><%= report.OtrosIngresosDeposito %></td>
                        </tr>
                        <tr class="border-lado">
                            <td class="fw-bold  pt-0 pb-0">TOTAL OTROS INGRESOS</td>
                            <td class="text-end fw-bold  pt-0 pb-0"><%= report.TotalOtrosIngresos %></td>
                        </tr>
                        <tr>
                            <td class="">TOTAL INVITACION</td>
                            <td class="text-end"><%= report.Invitacion %></td>
                        </tr>
                        <tr>
                            <td class="">TOTAL GASTOS MOTORIZADO</td>
                            <td class="text-end"><%= report.GastosMotorizado %></td>
                        </tr>
                        <tr>
                            <td class="">TOTAL COMISION TARJETA</td>
                            <td class="text-end"><%= report.ComisionTarjeta %></td>
                        </tr>
                        <tr>
                            <td class="">TOTAL OTROS GASTOS</td>
                            <td class="text-end"><%= report.OtrosGastos %></td>
                        </tr>
                        
                    </tbody>
                </table>
                <hr class="section-divider" />
                <div class="row">
                    <div class="col d-flex justify-content-between fw-bold">
                        <div class="me-2">TOTAL INGRESOS</div>
                        <div><%= report.TotalIngresos %></div>
                    </div>
                </div>
            </div>

            <!-- Col 2: DATOS CAJERA -->
            <div class="col-12  pe-4 mb-3">
                <h6 class="fw-bold pt-2 pb-2 mt-2 border-lado text-center">DATOS CAJERA</h6>
                <table class="table table-borderless table-sm">
                    <tbody>
                        <!-- Orden invertido: primero valor, luego descripción, para que se asemeje al diseño -->
                        <tr>
                            <td class="fw-bold">SOLES</td>
                            <td class="text-end"><%= report.CajeraSoles %></td>
                        </tr>
                        <tr>
                            <td class="fw-bold">DEPOSITO</td>
                            <td class="text-end"><%= report.CajeraDeposito %></td>
                        </tr>
                        <tr>
                            <td class="fw-bold">TARJETA</td>
                            <td class="text-end"><%= report.CajeraTarjeta %></td>
                        </tr>
                    </tbody>
                </table>


                <div class="row">
                    <div class="col d-flex justify-content-between fw-bold border-lado mb-3">
                        <span>TOTAL COBRADO</span>
                        <span><%= report.TotalCobrado %></span>
                    </div>
                    <div class="col-12 d-flex justify-content-between fw-bold border-lado mb-4">
                        <span>DIFERENCIA</span>
                        <span><%= report.Diferencia %></span>
                    </div>
                </div>
            </div>

            <!-- Col 3: DETALLE TARJETA / DETALLE DEPOSITO -->
            <div class="col-12 mb-3">
                <h6 class="fw-bold pt-2 pb-2 mt-2 border-lado text-center">DATOS INFORMATIVOS</h6>
                <table class="table table-borderless table-sm">
                    <tbody>
                        <tr>
                            <td>CAJA INICIAL</td>
                            <td class="text-end"><%= report.CajaInicial %></td>
                        </tr>
                        <tr>
                            <td>CAJA ACTUAL SISTEMA</td>
                            <td class="text-end"><%= report.CajaActualSistema %></td>
                        </tr>
                        <tr>
                            <td>CAJA ACTUAL CAJERA</td>
                            <td class="text-end"><%= report.CajaActualCajera %></td>
                        </tr>
                        <tr>
                            <td>DIFERENCIA</td>
                            <td class="text-end"><%= report.CajaActualDiferencia %></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

            <div class="fixed-button">
            <button class="btn btn-primary" onclick="window.print()">Imprimir</button>
        </div>

    </div>

    <!-- Bootstrap 5 JavaScript (CDN) - Opcional si usas componentes que requieran JS -->
    <script
        src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
