<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="FrmIngresoStock" CodeBehind="FrmIngresoStock.aspx.cs" %>

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
    <script>
        function AbrirModalBuscarProductos() {
            $('#modalBuscarProducto').modal('show');
        };

        function BuscarProductos() {
            var nombreProd = $("#txtNombreProducto").val();
            $.ajax({
                type: "POST",
                url: 'FrmIngresoStock.aspx/BuscarProductos',
                data: '{nombreProd: ' + JSON.stringify(nombreProd) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {

                    var rows = resultado.d;
                    if (rows === "SesionExpirada") {
                        window.location.href = "EndSession";
                    } else {
                        document.getElementById("bodyTbProductos").innerHTML = rows;
                    }
                    
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }
            });
        };

        function AgregarProducto(index) {

            //********************LÓGICA PARA OBTENER FECHA ACTUAL******************
            var fecha = new Date(); //Fecha actual
            var mes = fecha.getMonth() + 1; //obteniendo mes
            var dia = fecha.getDate(); //obteniendo dia
            var ano = fecha.getFullYear(); //obteniendo año
            if (dia < 10)
                dia = '0' + dia; //agrega cero si el menor de 10 (DIA)
            if (mes < 10)
                mes = '0' + mes //agrega cero si el menor de 10 (MES)
            //********************LÓGICA PARA OBTENER FECHA ACTUAL******************

            var table = document.getElementById('bodyTbProductos');
            var IdProducto = table.rows[index].cells[0].innerText;
            var CodProducto = table.rows[index].cells[1].innerText;
            var NombreProducto = table.rows[index].cells[2].innerText;
            var rows = "";

            rows += "<tr id='trBodyIngresarStock" + IdProducto + "'>";
            rows += "<th scope='row' hidden='hidden'>" + IdProducto + "</th>";
            rows += "<th scope='row'>" + CodProducto + "</th>";
            rows += "<td>" + NombreProducto + "</td>";
            rows += "<td>" + "<input id='fVencimientoProd" + IdProducto + "' type='date' value='" + ano + "-" + mes + "-" + dia + "'" + "</td>";
            rows += "<td>" + "<input id='txtCantProd" + IdProducto + "' type='text' value='1' onkeyup='calcularTotalKeyUp(event," + IdProducto + ")' onblur='calcularTotal(" + IdProducto + ")' " + "</td>";
            rows += "<td>" + "<input id='txtCostoProd" + IdProducto + "' type='text' value='0' onkeyup='calcularTotalKeyUp(event," + IdProducto + ")' onblur='calcularTotal(" + IdProducto + ")' " + "</td>";
            rows += "<td>" + "<span id='CostoTotal" + IdProducto + "'> S/. 0 </span>" + "</td>";
            rows += "<td>" + "<span onclick='EliminarProducto(" + IdProducto + ")' class='fa fa-trash' style='font-size:30px; cursor: pointer;color:Red' title='Eliminar Producto'></span>" + "</td>";
            rows += "</tr>";

            if (validarTableIngresoStock()) {
                if (validarSiExisteProducto(IdProducto)) {
                    toastr.error('El producto ya se encuentra agregado', 'Error');
                } else {
                    $('#bodyTbIngresoStock').append(rows);
                    toastr.success('Se agregó el producto con éxito', 'Bien');
                }
            } else {
                document.getElementById("bodyTbIngresoStock").innerHTML = rows;
                document.getElementById("btnGenerarIngreso").style.display = "block";
                toastr.success('Se agregó el producto con éxito', 'Bien');
            }
        };

        function validarTableIngresoStock() {
            var validadorPrimeraFila = document.getElementById('bodyTbIngresoStock').rows[0].innerText;

            if (validadorPrimeraFila == "Ingrese Productos para generar un nuevo ingreso.") {
                return false;
            }
            return true;
        };

        function validarSiExisteProducto(IdProducto) {
            for (var i = 0; i < document.getElementById('bodyTbIngresoStock').rows.length; i++) {
                if (document.getElementById('bodyTbIngresoStock').rows[i].cells[0].innerText == IdProducto) {
                    return true;
                }
            }
            return false;
        };

        function calcularTotalKeyUp(event, IdProducto) {
            var keycode = event.keyCode;
            if (keycode == '13') {
                var cantidad = document.getElementById('txtCantProd' + IdProducto).value;
                var costo = document.getElementById('txtCostoProd' + IdProducto).value;
                var total = cantidad * costo;
                document.getElementById('CostoTotal' + IdProducto).value = Math.round(total * 100) / 100;
                $('#CostoTotal' + IdProducto).text("S/." + Math.round(total * 100) / 100);
            }
        };

        function calcularTotal(IdProducto) {
            var cantidad = document.getElementById('txtCantProd' + IdProducto).value;
            var costo = document.getElementById('txtCostoProd' + IdProducto).value;
            var total = cantidad * costo
            document.getElementById('CostoTotal' + IdProducto).value = Math.round(total * 100) / 100;
            $('#CostoTotal' + IdProducto).text("S/." + Math.round(total * 100) / 100);
        };

        function EliminarProducto(idProducto) {
            swal({
                title: "Eliminación Producto",
                text: "¿Está seguro que desea eliminar producto?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Eliminar",
                cancelButtonText: "Cancelar"
            },
                function (isConfirm) {
                    if (isConfirm) {
                        swal.close()
                        $("#trBodyIngresarStock" + idProducto).remove();
                        var table = document.getElementById('bodyTbIngresoStock');
                        if (table.rows.length == 0) {
                            var rows = "";
                            rows += '<tr>';
                            rows += '<td colspan="8">Ingrese Productos para generar un nuevo ingreso.</td>';
                            rows += '</tr>'
                            document.getElementById("bodyTbIngresoStock").innerHTML = rows;
                            document.getElementById("btnGenerarIngreso").style.display = "none";
                        }
                        toastr.success('Se eliminó el producto con éxito', 'Bien');
                    }
                }
            );
        };

        function GenerarIngresoStock() {
            var datos = "";
            var TotalLote = 0;
            var CodLote = $("#<%=txtNumeroLote.ClientID%>").val();
            var table = document.getElementById('bodyTbIngresoStock');
            for (var i = 0; i < table.rows.length; i++) {
                var idProducto = table.rows[i].cells[0].innerText;
                var codProducto = table.rows[i].cells[1].innerText;
                var nombreProducto = table.rows[i].cells[2].innerText;
                var fVencimientoProducto = table.rows[i].cells[3].firstChild.value;
                var cantProducto = table.rows[i].cells[4].firstChild.value;
                var costoUnitarioProducto = table.rows[i].cells[5].firstChild.value;
                var Total = Math.round((cantProducto * costoUnitarioProducto) * 100) / 100;
                if (datos == "") {
                    datos += idProducto + "|" + codProducto + "|" + nombreProducto + "|" + fVencimientoProducto + "|" + cantProducto + "|" + costoUnitarioProducto + "|" + Total;
                } else {
                    datos += ";" + idProducto + "|" + codProducto + "|" + nombreProducto + "|" + fVencimientoProducto + "|" + cantProducto + "|" + costoUnitarioProducto + "|" + Total;
                }
                TotalLote = TotalLote + Total;
            }

            $.ajax({
                type: "POST",
                url: 'FrmIngresoStock.aspx/GenerarIngresoStock',
                data: '{datos: ' + JSON.stringify(datos) + ',total: ' + JSON.stringify(TotalLote) + ',CodLote : ' + JSON.stringify(CodLote) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    if (resultado.d === "SesionExpirada") {
                        
                            window.location.href = "EndSession";
                    }
                    else {
                        toastr.success('Se realizó el ingreso de stock con éxito', 'Bien');
                        setTimeout(location.reload(true), 4000);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    toastr.error(error.Message, 'Error');
                }
            });

        };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container pb-3 pt-3 mb-4 shadow-lg bg-body rounded">
            <div class="row">
                <div class="col-md-8">
                    <div class="form-group row">
                        <label id="lblNumeroLote" class="col-sm-3 col-form-label">Número Lote : </label>
                        <div class="col-sm-9">
                        <input type="text" class="form-control" runat="server" id="txtNumeroLote" readonly="true" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4 d-flex justify-content-end">
                    <%--<button type="button" class="btn btn-secondary btn-lg mr-2" >Regresar</button>--%>
                    <button type="button" style="border-radius: 15px;" class="btn btn-info " onclick="AbrirModalBuscarProductos()">
                        <i class="fa fa-plus-circle"></i>
                        Nuevo
                    </button>
                </div>
            </div>
        </div>
        <div class="table-responsive shadow-lg bg-body rounded">
            <table class="table table-sm table-hover table-bordered mb-0">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col" hidden="hidden">IdProducto</th>
                        <th scope="col">Cod. Producto</th>
                        <th scope="col">Nombre Producto</th>
                        <th scope="col">F. Vencimiento</th>
                        <th scope="col">Cantidad</th>
                        <th scope="col">Costo Unitario</th>
                        <th scope="col">Total</th>
                        <th scope="col">Acción</th>
                    </tr>
                </thead>
                <tbody id="bodyTbIngresoStock">
                    <tr>
                        <td colspan="8">Ingrese Productos para generar un nuevo ingreso.</td>
                    </tr>
                </tbody>
            </table>
            <div id="btnGenerarIngreso" style="display: none">
                <button type="button" class="btn btn-secondary btn-lg" style="float: right;" onclick="GenerarIngresoStock()">Generar Ingreso Stock</button>
            </div>
        </div>
    </form>
    <div class="modal fade" id="modalBuscarProducto" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Productos</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <div class="input-group">
                                <input id="txtNombreProducto" class="form-control" />
                                <span class="input-group-btn">
                                    <button id="buscarProductos" class="btn btn-success" type="button" onclick="BuscarProductos()">
                                        Buscar Producto
                                    </button>
                                </span>
                            </div>
                        </div>
                        <div class="form-group" style="height: 350px; overflow: scroll">
                            <div class="table-responsive shadow-lg bg-body rounded">
                                <table class="table table-sm table-hover table-bordered mb-0">
                                <thead class="thead-dark">
                                    <tr>
                                        <th scope="col" hidden="hidden">Id. Producto</th>
                                        <th scope="col" >Cod. Producto</th>
                                        <th scope="col" >Nombre Producto</th>
                                        <th scope="col" >Acción</th>
                                    </tr>
                                </thead>
                                <tbody id="bodyTbProductos">
                                    <tr>
                                        <td colspan="3">Realice una búsqueda.</td>
                                    </tr>
                                </tbody>
                            </table>
                            </div>
                            
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
