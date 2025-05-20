<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmDividirCuentas" CodeBehind="frmDividirCuentas.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            // Desactivar autocomplete para todos los formularios
            var forms = document.getElementsByTagName('form');
            for (var i = 0; i < forms.length; i++) {
                forms[i].setAttribute('autocomplete', 'off');
            }

            // Desactivar autocomplete solo en campos de contraseña
            var passwordFields = document.querySelectorAll('input[type="password"]');
            for (var i = 0; i < passwordFields.length; i++) {
                passwordFields[i].setAttribute('autocomplete', 'new-password');
            }
        });
    </script>
    <style type="text/css">
        html, body {
            background: none !important;
        }

        #overlay {
            position: fixed;
            z-index: 99;
            top: 0px;
            left: 0px;
            background-color: #000;
            width: 100%;
            height: 100%;
            filter: Alpha(Opacity=50);
            opacity: 0.5;
            -moz-opacity: 0.5;
        }

        #theprogress {
            background-color: #000;
            width: 120px;
            height: 24px;
            text-align: center;
            filter: Alpha(Opacity=80);
            opacity: 0.80;
            -moz-opacity: 0.80;
        }

        #modalprogress {
            position: absolute;
            top: 50%;
            left: 50%;
            margin: -11px 0 0 -55px;
            color: white;
        }

        body > #modalprogress {
            position: fixed;
        }
    </style>
    <script type="text/javascript">
        function actualizarMesas() {
            var valorCombo = document.getElementById("cboNumeroMesas").value;
            var div = "";
            for (var i = 0; i < valorCombo; i++) {
                div += "<div class='btn-group btn-group-lg'>"
                div += "<button type='button' class='btn btn-info' style='margin: 10px;' onclick='IngresarProductos(" + (i + 1) + ")'>MESA 0" + (i + 1) + "</button>"
                div += "</div>";
            }
            document.getElementById("MesasDinamicas").innerHTML = div;
            document.getElementById('TableDivision').style.display = 'none';
            document.getElementById('alertMesa').innerHTML = 'Seleccione una mesa y agregue productos';
            document.getElementById('IdMesa').innerHTML = '0';
        };
        function IngresarProductos(idMesa) {
            document.getElementById('alertMesa').innerHTML = 'Agregar productos a la Mesa 0' + idMesa;
            document.getElementById('alertMesa').style.display = 'block';
            document.getElementById('TableDivision').style.display = 'block';
            OcultarTables();
            document.getElementById('bodyTbProductos' + idMesa).style.display = 'table-row-group';
            document.getElementById('IdMesa').innerHTML = idMesa;
        };
        function OcultarTables() {
            for (var i = 0; i < 6; i++) {
                document.getElementById('bodyTbProductos' + (i + 1)).style.display = 'none';
            }
        };
        function AgregarProducto(index) {
            var IndexMesa = document.getElementById('IdMesa').innerHTML;
            if (IndexMesa != 0) {
                var table = document.getElementById('<%=bodyTbProductosPedido.ClientID%>');
                var Cantidad = table.rows[index].cells[1].innerText;
                var NombreProducto = table.rows[index].cells[2].innerText;
                var PrecioUnd = table.rows[index].cells[4].innerText;
                var PrecioT = table.rows[index].cells[3].innerText;
                var IdProducto = table.rows[index].cells[0].innerText;
                var NTotalPed = PrecioT - PrecioUnd;
                if (Cantidad != "0") {
                    $('#cboNumeroMesas').prop('disabled', true);
                    var NCantPed = parseInt(Cantidad) - 1;
                    table.rows[index].cells[1].innerText = NCantPed;
                    table.rows[index].cells[3].innerText = NTotalPed;
                    var rows = "";
                    rows += "<tr id='trBodyDivisionTb" + IdProducto + "-" + IndexMesa + "'>";
                    rows += "<th scope='row' hidden='hidden'>" + IdProducto + "</th>";
                    rows += "<td>" + 1 + "</td>";
                    rows += "<td>" + NombreProducto + "</td>";
                    rows += "<td>" + PrecioUnd + "</td>";
                    rows += "<td hidden='hidden'>" + PrecioUnd + "</td>";
                    rows += "<td>" + "<span onclick='EliminarProducto(" + '"' + IdProducto + '","' + IndexMesa + '"' + ")' class='fa fa-minus' style='font-size:30px; cursor: pointer;color:Red' title='Eliminar Producto'></span>" + "</td>";
                    rows += "</tr>";
                    if (validarTable(IndexMesa)) {
                        if (validarSiExisteProducto(IdProducto, IndexMesa)) {
                            for (var i = 0; i < document.getElementById('bodyTbProductos' + IndexMesa).rows.length; i++) {
                                if (document.getElementById('bodyTbProductos' + IndexMesa).rows[i].cells[0].innerText == IdProducto) {
                                    var cantIngresada = document.getElementById('bodyTbProductos' + IndexMesa).rows[i].cells[1].innerText;
                                    var NuevaCant = parseInt(cantIngresada) + 1;
                                    var NuevoTotal = NuevaCant * PrecioUnd;
                                    document.getElementById('bodyTbProductos' + IndexMesa).rows[i].cells[1].innerText = NuevaCant;
                                    document.getElementById('bodyTbProductos' + IndexMesa).rows[i].cells[3].innerText = (Math.round(NuevoTotal * 100) / 100);
                                }
                            }
                        } else {
                            $('#bodyTbProductos' + IndexMesa).append(rows);
                            toastr.success('Se agregó el producto con éxito', 'Bien');
                        }
                    } else {
                        document.getElementById("bodyTbProductos" + IndexMesa).innerHTML = rows;
                        toastr.success('Se agregó el producto con éxito', 'Bien');
                    }
                } else {
                    toastr.error("Ya se agregó toda la cantidad del producto");
                }
            }
            else {
                toastr.error("Debe seleccionar una mesa para agregar productos");
            }

        };
        function validarTable(IndexTable) {
            var validadorPrimeraFila = document.getElementById('bodyTbProductos' + IndexTable).rows[0].innerText;
            if (validadorPrimeraFila.indexOf("Agregue productos.") != -1) {
                return false;
            }
            return true;
        };
        function validarSiExisteProducto(IdProducto, IndexTable) {
            for (var i = 0; i < document.getElementById('bodyTbProductos' + IndexTable).rows.length; i++) {
                if (document.getElementById('bodyTbProductos' + IndexTable).rows[i].cells[0].innerText == IdProducto) {
                    return true;
                }
            }
            return false;
        };
        function EliminarProducto(idProducto, indexTable) {
            var TrDiv = $("#trBodyDivisionTb" + idProducto + "-" + indexTable);
            var TrPed = $("#TrBodyPedidoTb" + idProducto);
            var CantDivision = TrDiv[0].cells[1].innerText;
            var CantPedido = TrPed[0].cells[1].innerText;
            var CostoUnd = TrDiv[0].cells[4].innerText;
            var NCantPedido = parseInt(CantPedido) + 1;
            var NTotalPedido = NCantPedido * CostoUnd;

            TrPed[0].cells[1].innerText = NCantPedido;
            TrPed[0].cells[3].innerText = NTotalPedido;

            var NCantDivison = parseInt(CantDivision) - 1;
            var NTotalDivison = NCantDivison * CostoUnd;

            TrDiv[0].cells[1].innerText = NCantDivison;
            TrDiv[0].cells[3].innerText = NTotalDivison;

            if (NCantDivison == 0) {
                // Eliminar la fila actual
                TrDiv.remove();

                // Verificar si aún hay filas con productos en el tbody
                var tbody = document.getElementById("bodyTbProductos" + indexTable);
                var rows = tbody.getElementsByTagName("tr");
                var hasProducts = false;

                // Recorre las filas para ver si alguna tiene productos
                for (var i = 0; i < rows.length; i++) {
                    var quantityCell = rows[i].cells[1]; // Celda de cantidad
                    var quantity = parseInt(quantityCell.innerText); // Obtiene la cantidad de la celda
                    if (quantity > 0) {
                        hasProducts = true; // Hay productos
                        break;
                    }
                }

                // Si no hay productos en ninguna fila, muestra el mensaje "Agregue productos."
                if (!hasProducts) {
                    var rows = "";
                    rows += '<tr>';
                    rows += '<td colspan="5">Agregue productos.</td>';
                    rows += '</tr>';
                    tbody.innerHTML = rows;
                }
            }

            toastr.success('Se eliminó el producto con éxito', 'Bien');
        };
        function GenerarDivision() {
            var valorCombo = document.getElementById("cboNumeroMesas").value;
            var table = document.getElementById('<%=bodyTbProductosPedido.ClientID%>');
            var datos = "";

            for (var i = 0; i < table.rows.length; i++) {
                if (table.rows[i].cells[1].innerText != "0") {
                    toastr.error("Se debe dividir todo el pedido", "Error");
                    return;
                }
            }
            for (var i = 0; i < valorCombo; i++) {
                if (validarTable(i + 1) == false) {
                    toastr.error("Se debe ingresar productos a todas las mesas", "Error");
                    return;
                }
            }
            for (var i = 0; i < valorCombo; i++) {
                var Table = document.getElementById('bodyTbProductos' + (i + 1));
                for (var x = 0; x < Table.rows.length; x++) {
                    var cantidad = Table.rows[x].cells[1].innerText;
                    var idProducto = Table.rows[x].cells[0].innerText;
                    var precioUnd = Table.rows[x].cells[4].innerText;
                    if (x == 0) {
                        datos += cantidad + ";" + idProducto + ";" + precioUnd;
                    } else {
                        datos += "|" + cantidad + ";" + idProducto + ";" + precioUnd;
                    }
                }
                datos += "¬";
            }
            Dividir(datos);
        };
        function Dividir(datos) {
            var valorCombo = document.getElementById("cboNumeroMesas").value;
            $.ajax({
                type: "POST",
                url: 'frmDividirCuentas.aspx/GenerarDivision',
                data: '{datos: ' + JSON.stringify(datos) + ',numMesas: ' + JSON.stringify(valorCombo) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    toastr.success('Se realizó la división con éxito', 'Bien');
                    document.getElementById("<%=btnEnviarPagoDivision.ClientID %>").click();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    toastr.error(error.Message, 'Error');
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <% string url = "";
                                if (Request.QueryString["vchEstado"].ToString().Equals("PAGADO"))  url= "<a href='frmListadoPedidosxPagar'>Lista</a>";
                                else url= "<a href='frmListadoMesasPagar'>Pagar</a>"; %>
                            <li class="breadcrumb-item"><%= url %></li>
                            <li class="breadcrumb-item"><a href="<%="frmGenComprobPago?vchOrdenID=" + Request.QueryString["vchOrdenID"].ToString() + "&vchEstado=" + Request.QueryString["vchEstado"].ToString() + "&vchNumDocu=-" %>">Pagar Orden</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Dividir cuentas</li>
                        </ol>
                    </nav>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" >
                    <div class="container pb-3 pt-3 mb-4 shadow-lg bg-body rounded">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                        <label for="cboNumeroMesas">Seleccione cantidad de División</label>
                        <select class="form-control" id="cboNumeroMesas" onchange="actualizarMesas();">
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                            <option>6</option>
                        </select>
                    </div>
                    <div id="MesasDinamicas">
                        <div class="btn-group btn-group-lg">
                            <button type="button" class="btn btn-info" onclick="IngresarProductos(1)" style="margin: 10px;">MESA 01</button>
                        </div>
                        <div class="btn-group btn-group-lg">
                            <button type="button" class="btn btn-info" onclick="IngresarProductos(2)" style="margin: 10px;">MESA 02</button>
                        </div>
                    </div>
                    <div class="form-group" id="TableDivision" style="display: none">
                        <div class="table-responsive">
                            <table class="table">
                            <thead class="thead-dark">
                                <tr>
                                    <th scope="col" hidden="hidden">Id. Producto</th>
                                    <th scope="col">Cantidad</th>
                                    <th scope="col">Nombre</th>
                                    <th scope="col">P.Total</th>
                                    <th scope="col" hidden="hidden">P.Und</th>
                                    <th scope="col">Acción</th>
                                </tr>
                            </thead>
                            <tbody id="bodyTbProductos1" style="display: none">
                                <tr>
                                    <td colspan="5">Agregue productos.</td>
                                </tr>
                            </tbody>
                            <tbody id="bodyTbProductos2" style="display: none">
                                <tr>
                                    <td colspan="3">Agregue productos.</td>
                                </tr>
                            </tbody>
                            <tbody id="bodyTbProductos3" style="display: none">
                                <tr>
                                    <td colspan="3">Agregue productos.</td>
                                </tr>
                            </tbody>
                            <tbody id="bodyTbProductos4" style="display: none">
                                <tr>
                                    <td colspan="3">Agregue productos.</td>
                                </tr>
                            </tbody>
                            <tbody id="bodyTbProductos5" style="display: none">
                                <tr>
                                    <td colspan="3">Agregue productos.</td>
                                </tr>
                            </tbody>
                            <tbody id="bodyTbProductos6" style="display: none">
                                <tr>
                                    <td colspan="3">Agregue productos.</td>
                                </tr>
                            </tbody>
                        </table>
                        </div>
                    </div>
                            </div>
                        </div>
                    </div>
                    
                </div>
                <div class="col-md-6" >
                    <div class="container pb-3 pt-3 mb-4 shadow-lg bg-body rounded">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                        <div id="alertMesa" class="alert alert-success" role="alert">Seleccione una mesa y agregue productos</div>
                        <div id="IdMesa" class="alert alert-success" role="alert" style="display: none">0</div>
                        <div class="table-responsive">
                            <table class="table">
                            <thead class="thead-dark">
                                <tr>
                                    <th scope="col" hidden="hidden">Id. Producto</th>
                                    <th scope="col">Cantidad</th>
                                    <th scope="col">Nombre</th>
                                    <th scope="col">P.Total</th>
                                    <th scope="col" hidden="hidden">P. Unitario</th>
                                    <th scope="col">Acción</th>
                                </tr>
                            </thead>
                            <tbody id="bodyTbProductosPedido" runat="server">
                                <tr>
                                    <td colspan="3">Agregue productos.</td>
                                </tr>
                            </tbody>
                        </table>
                        </div>
                    </div>
                    <div>
                        <button style="float: right" type="button" onclick="GenerarDivision();" class="btn btn-primary">Dividir</button>
                        <asp:Button ID="btnEnviarPagoDivision" runat="server" OnClick="Unnamed1_Click" Style="display: none" />
                    </div>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </form>
</asp:Content>


