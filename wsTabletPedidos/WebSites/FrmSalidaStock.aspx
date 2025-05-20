<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="FrmSalidaStock" CodeBehind="FrmSalidaStock.aspx.cs" %>

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
                url: 'FrmSalidaStock.aspx/BuscarProductos',
                data: '{nombreProd: ' + JSON.stringify(nombreProd) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    if (resultado.d === "SesionExpirada") {
                        // Si la sesión ha expirado, redirigir a la página de inicio
                        window.location.href = "EndSession";
                    }
                    else {
                        var rows = resultado.d;
                        document.getElementById("bodyTbProductos").innerHTML = rows;
                    }
                    
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    
                    swal({
                        title: "Error",
                        text: error.Message,
                        timer: 3000,
                        showConfirmButton: false
                    }, function () {
                        const ultimoRol = sessionStorage.getItem('privileges');
                        // Redirigir después de que el SweetAlert se cierre
                        if (ultimoRol == "Mesero" || ultimoRol == "Cajero") {
                            window.location.href = "frmMeseroIndex";
                        }
                        else {
                            window.location.href = "index";
                        }
                    });
                }
            });
        };
        function VerDetalle(idProducto) {
            $.ajax({
                type: "POST",
                url: 'FrmSalidaStock.aspx/VerDetalle',
                data: '{idProducto: ' + JSON.stringify(idProducto) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    if (resultado.d === "SesionExpirada") {
                        // Si la sesión ha expirado, redirigir a la página de inicio
                        window.location.href = "EndSession";
                    }
                    else {
                        var rows = resultado.d;
                        document.getElementById("bodyTbProductosDetalle").innerHTML = rows;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }
            });
        };
        function AgregarProducto(index) {

            var table = document.getElementById('bodyTbProductosDetalle');
            var IdAlmProducto = table.rows[index].cells[0].innerText;
            var IdProducto = table.rows[index].cells[1].innerText;
            var NombreProducto = table.rows[index].cells[5].innerText;
            var Lote = table.rows[index].cells[2].innerText;
            var Cantidad = table.rows[index].cells[4].innerText;
            var CostoUnitario = table.rows[index].cells[6].innerText;
            var total = Cantidad * CostoUnitario;
            var rows = "";

            rows += "<tr id='trBodySalidaStock" + IdProducto + "'>";
            rows += "<th scope='row' hidden='hidden'>" + IdAlmProducto + "</th>";
            rows += "<th scope='row' hidden='hidden'>" + IdProducto + "</th>";
            rows += "<td>" + NombreProducto + "</td>";
            rows += "<td>" + Lote + "</td>";
            rows += "<td>" + "<input id='txtCantProd" + IdProducto + "' type='text' value=" + Cantidad + " onkeyup='calcularTotalKeyUp(event," + IdProducto + ")' onblur='calcularTotal(" + IdProducto + ")' " + "</td>";
            rows += "<td>" + CostoUnitario + "</td>";
            rows += "<td>" + "<span id='CostoTotal" + IdProducto + "'>" + "S/." + (Math.round(total * 100) / 100) + "</span>" + "</td>";
            rows += "<td>" + "<span onclick='EliminarProducto(" + IdProducto + ")' class='fa fa-trash' style='font-size:30px; cursor: pointer;color:Red' title='Eliminar Producto'></span>" + "</td>";
            rows += "<td hidden='hidden'>" + Cantidad + "</td>";
            rows += "</tr>";

            if (validarTableSalidaStock()) {
                if (validarSiExisteLote(Lote)) {
                    toastr.error('El Lote ya se encuentra agregado', 'Error');
                } else {
                    $('#bodyTbSalidaStock').append(rows);
                    toastr.success('Se agregó el producto con éxito', 'Bien');
                }
            } else {
                document.getElementById("bodyTbSalidaStock").innerHTML = rows;
                document.getElementById("btnGenerarSalida").style.display = "block";
                toastr.success('Se agregó el producto con éxito', 'Bien');
            }
        };
        function validarTableSalidaStock() {
            var validadorPrimeraFila = document.getElementById('bodyTbSalidaStock').rows[0].innerText;

            if (validadorPrimeraFila == "Ingrese Productos para generar una nueva Salida.") {
                return false;
            }
            return true;
        };
        function validarSiExisteLote(Lote) {
            for (var i = 0; i < document.getElementById('bodyTbSalidaStock').rows.length; i++) {
                if (document.getElementById('bodyTbSalidaStock').rows[i].cells[3].innerText == Lote) {
                    return true;
                }
            }
            return false;
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
                        $("#trBodySalidaStock" + idProducto).remove();
                        var table = document.getElementById('bodyTbSalidaStock');
                        if (table.rows.length == 0) {
                            var rows = "";
                            rows += '<tr>';
                            rows += '<td colspan="9">Ingrese Productos para generar una nueva Salida.</td>';
                            rows += '</tr>'
                            document.getElementById("bodyTbSalidaStock").innerHTML = rows;
                            document.getElementById("btnGenerarSalida").style.display = "none";
                        }
                        toastr.success('Se eliminó el producto con éxito', 'Bien');
                    }
                }
            );
        };
        function GenerarSalidaStock() {
            var datos = "";
            var TotalLote = 0;
            var CodLote = $("#<%=txtNumeroLote.ClientID%>").val();
            var table = document.getElementById('bodyTbSalidaStock');
            for (var i = 0; i < table.rows.length; i++) {
                var idAlmProducto = table.rows[i].cells[0].innerText;
                var idProducto = table.rows[i].cells[1].innerText;
                var Lote = table.rows[i].cells[3].innerText;
                var cantProducto = table.rows[i].cells[4].firstChild.value;
                var costoUnitarioProducto = table.rows[i].cells[5].innerText;

                var Total = Math.round((cantProducto * costoUnitarioProducto) * 100) / 100;
                if (datos == "") {
                    datos += idAlmProducto + "|" + idProducto + "|" + Lote + "|" + cantProducto + "|" + costoUnitarioProducto + "|" + Total;
                } else {
                    datos += ";" + idAlmProducto + "|" + idProducto + "|" + Lote + "|" + cantProducto + "|" + costoUnitarioProducto + "|" + Total;
                }
                TotalLote = TotalLote + Total;
            }

            $.ajax({
                type: "POST",
                url: 'FrmSalidaStock.aspx/GenerarSalidaStock',
                data: '{datos: ' + JSON.stringify(datos) + ',total: ' + JSON.stringify(TotalLote) + ',CodLote : ' + JSON.stringify(CodLote) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    if (resultado.d === "SesionExpirada") {
                        window.location.href = "EndSession";
                    }
                    else {
                        toastr.success('Se realizó la salida de stock con éxito', 'Bien');
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
                    <button type="button" style="border-radius: 15px;" class="btn  btn-info" onclick="AbrirModalBuscarProductos()">
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
                        <th scope="col" hidden="hidden">IdAlmProducto</th>
                        <th scope="col" hidden="hidden">IdProducto</th>
                        <th scope="col">Nombre Producto</th>
                        <th scope="col">Lote Ingreso</th>
                        <th scope="col">Cantidad</th>
                        <th scope="col">Costo Unitario</th>
                        <th scope="col">Total</th>
                        <th scope="col">Acción</th>
                        <th scope="col" hidden="hidden">Cantidad_V2</th>
                    </tr>
                </thead>
                <tbody id="bodyTbSalidaStock">
                    <tr>
                        <td colspan="9">Ingrese Productos para generar una nueva Salida.</td>
                    </tr>
                </tbody>
            </table>
            <div id="btnGenerarSalida" style="display: none">
                <button type="button" class="btn btn-secondary btn-lg" style="float: right;" onclick="GenerarSalidaStock()">Generar Salida Stock</button>
            </div>
        </div>
    </form>
    <div class="modal fade bd-example-modal-lg" id="modalBuscarProducto" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
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
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group" style="height: 350px; overflow: scroll">
                                    <div class="table-responsive shadow-lg bg-body rounded">
                                        <table class="table table-sm table-hover table-bordered mb-0">
                                            <thead class="thead-dark">
                                                <tr>
                                                    <th scope="col" hidden="hidden">Id. Producto</th>
                                                    <th scope="col" hidden="hidden">Cod. Producto</th>
                                                    <th scope="col">Nombre Producto</th>
                                                    <th scope="col">Acción</th>
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
                            </div>
                            <div class="col-6">
                                <div class="form-group" style="height: 350px; overflow: scroll">
                                    <div class="table-responsive shadow-lg bg-body rounded">
                                        <table class="table table-sm table-hover table-bordered mb-0">
                                            <thead class="thead-dark">
                                                <tr>
                                                    <th scope="col" hidden="hidden">Id. Alm. Producto</th>
                                                    <th scope="col" hidden="hidden">Id. Producto</th>
                                                    <th scope="col">Lote</th>
                                                    <th scope="col">Cant.</th>
                                                    <th scope="col">Stock.</th>
                                                    <th scope="col" hidden="hidden">Nombre Prod.</th>
                                                    <th scope="col" hidden="hidden">Costo U.</th>
                                                    <th scope="col">Acción</th>
                                                </tr>
                                            </thead>
                                            <tbody id="bodyTbProductosDetalle">
                                                <tr>
                                                    <td colspan="4">Seleccione un productos.</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="col-6">
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
