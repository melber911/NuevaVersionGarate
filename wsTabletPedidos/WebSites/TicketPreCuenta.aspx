<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="TicketPreCuenta.aspx.cs" Inherits="WebSites.TicketPreCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pre-Cuenta</title>
    <link
        rel="stylesheet"
        href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <style type="text/css">
        body {
            font-family:  monospace;
            width: 80mm;
            margin: 0 auto;
            padding: 5px;
            font-size: 12px;
        }
        .ticket-container {
            width: 100%;
            max-width: 300px;
            margin: 0 auto;
        }
        

        .logo {
            width: 100%;
            max-width: 200px;
            display: block;
            margin: 0 auto 10px;
            height: auto;
        }

        .text-center {
            text-align: center;
        }

        .text-left {
            text-align: left;
        }

        .text-right {
            text-align: right;
        }

        .bold {
            font-weight: bold;
        }

        .divider {
            border-top: 1px dashed #000;
            margin: 5px 0;
        }

        .items-header {
            display: flex;
            justify-content: space-between;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .item-row {
            display: flex;
            justify-content: space-between;
            margin-bottom: 3px;
        }

        .item-name {
            width: 50%;
        }

        .item-qty {
            width: 15%;
            text-align: right;
        }

        .item-price {
            width: 20%;
            text-align: right;
        }

        .item-total {
            width: 15%;
            text-align: right;
        }

        .total-row {
            margin-top: 10px;
            font-weight: bold;
            display: flex;
            justify-content: space-between;
        }

        .footer {
            margin-top: 15px;
            text-align: center;
            font-size: 10px;
        }
        @media print {
            @page {
                size: 72mm auto;
                margin: 0;
            }
            .fixed-button {
                display: none;
            }
            .ticket-container {
            position: absolute; /* Cambia esto */
            top: 0; /* Añade esto */
            left: 0; /* Añade esto */
            padding: 2mm; /* Ajusta según necesites */
            width: 100%; 
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
    <form id="form1" runat="server">
            
        <div class="ticket-container">

            <!-- Logo del establecimiento -->
            <asp:Image ID="imgLogo" runat="server" CssClass="logo"  AlternateText="Logo" />

            <!-- Encabezado -->
            <h4 class="text-center bold">***** PRE-CUENTA *****</h4>
            <div class="divider"></div>

            <!-- Información de la orden -->
            <div class="text-left">
                <p>
                    <span class="bold"># ORDEN:</span>
                    <asp:Label ID="lblOrden" runat="server" />
                </p>
                <p>
                    <span class="bold"># SALON:</span>
                    <asp:Label ID="lblSalon" runat="server" />
                </p>
                <p>
                    <span class="bold"># MESA:</span>
                    <asp:Label ID="lblMesa" runat="server" />
                </p>
                <p>
                    <span class="bold">ATENDIO:</span>
                    <asp:Label ID="lblAtendio" runat="server" />
                </p>
                <p><span class="bold">CLIENTE:</span> PUBLICO EN GENERAL</p>
            </div>

            <!-- Fecha y hora -->
            <div style="display: flex; justify-content: space-between;">
                <span class="bold">FECHA:
                    <asp:Label ID="lblFecha" runat="server" /></span>
                <span class="bold">HORA:
                    <asp:Label ID="lblHora" runat="server" /></span>
            </div>

            <div class="divider"></div>

            <!-- Encabezado de artículos -->
            <div class="items-header">
                <div class="item-name">ARTÍCULO</div>
                <div class="item-qty">CANT</div>
                <div class="item-price">P/U</div>
                <div class="item-total">TOTAL</div>
            </div>

            <div class="divider"></div>

            <!-- Artículos -->
            <asp:Repeater ID="rptItems" runat="server">
                <ItemTemplate>
                    <div class="item-row">
                        <div class="item-name"><%# Eval("vchDeItem") %></div>
                        <div class="item-qty"><%# Eval("intCantidad") %></div>
                        <div class="item-price"><%# string.Format("{0:N2}", Eval("numPrecioUni")) %></div>
                        <div class="item-total"><%# string.Format("{0:N2}", Eval("numPrecioTot")) %></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div class="divider"></div>

            <!-- Total -->
            <div class="total-row">
                <span>TOTAL:</span>
                <span>S/.
                    <asp:Label ID="lblTotal" runat="server" /></span>
            </div>

            <!-- Pie de página -->
            <div class="footer">
                <p>¡Gracias por su preferencia!</p>
                <p><%# DateTime.Now.ToString("dd/MM/yyyy HH:mm") %></p>
            </div>
        </div>
        <div class="fixed-button">
                <button class="btn btn-primary" onclick="window.print()">Imprimir</button>
            </div>
    </form>
    <script
        src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
