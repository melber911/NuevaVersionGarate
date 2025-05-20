<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmCategorizarProductos" Codebehind="frmCategorizarProductos.aspx.cs" %>

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
    <style>

        .label{display:inline;padding:.2em .6em .3em;font-size:75%;font-weight:700;line-height:1;color:#fff;text-align:center;white-space:nowrap;vertical-align:baseline;border-radius:.25em}a.label:focus,a.label:hover{color:#fff;text-decoration:none;cursor:pointer}.label:empty{display:none}.btn .label{position:relative;top:-1px}.label-default{background-color:#777}.label-default[href]:focus,.label-default[href]:hover{background-color:#5e5e5e}.label-primary{background-color:#337ab7}.label-primary[href]:focus,.label-primary[href]:hover{background-color:#286090}.label-success{background-color:#5cb85c}.label-success[href]:focus,.label-success[href]:hover{background-color:#449d44}.label-info{background-color:#5bc0de}.label-info[href]:focus,.label-info[href]:hover{background-color:#31b0d5}.label-warning{background-color:#f0ad4e}.label-warning[href]:focus,.label-warning[href]:hover{background-color:#ec971f}.label-danger{background-color:#d9534f}.label-danger[href]:focus,.label-danger[href]:hover{background-color:#c9302c}.badge{display:inline-block;min-width:10px;padding:3px 7px;font-size:12px;font-weight:700;line-height:1;color:#fff;text-align:center;white-space:nowrap;vertical-align:middle;background-color:#777;border-radius:10px}.badge:empty{display:none}.btn .badge{position:relative;top:-1px}.btn-group-xs>.btn .badge,.btn-xs .badge{top:0;padding:1px 5px}a.badge:focus,a.badge:hover{color:#fff;text-decoration:none;cursor:pointer}
        .mydatagrid {
            border: solid 2px black;
            min-width: 80%;
        }

        .header {
            background-color: #000;
            font-family: Arial;
            color: White;
            height: 25px;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
        }

            .rows:hover {
                background-color: #5badff;
                color: #fff;
            }

        .mydatagrid a /** FOR THE PAGING ICONS  **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/ {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #fff;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .pager {
            background-color: #5badff;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }

        .mydatagrid td {
            padding: 5px;
        }

        .mydatagrid th {
            padding: 5px;
        }
        .auto-style4 {
            width: 214px;
            height: 34px;
        }
        .auto-style5 {
            width: 22px;
            height: 34px;
        }
        .auto-style6 {
            height: 34px;
        }
        .auto-style7 {
            height: 34px;
            width: 178px;
        }
        .auto-style8 {
            width: 91px;
        }
        .auto-style9 {
            height: 34px;
            width: 96px;
        }
        .auto-style10 {
            width: 96px;
        }
        .auto-style11 {
            width: 347px;
        }
        .auto-style12 {
            width: 411px;
        }

    </style>
    <script>
        function cargarTablaGrupoProd() {
            var nombFiltro = $("#NombreProductoFiltro").val();
            $.ajax({
                type: "POST",
                url: 'frmCategorizarProductos/BuscarGrupos',
                data: '{nombFiltro: ' + JSON.stringify(nombFiltro) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    document.getElementById("bodytbProducto").innerHTML = resultado.d;
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    toastr.error(error.Message, 'Error');
                }
            });
        };

        function cargarTablaProductosSinGrupo() {
            var nombFiltro = $("#nombreProd").val();
            $.ajax({
                type: "POST",
                url: 'frmCategorizarProductos/BuscarProductos',
                data: '{nombFiltro: ' + JSON.stringify(nombFiltro) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    document.getElementById("TbProductosSinGrupo").innerHTML = resultado.d;
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    toastr.error(error.Message, 'Error');
                }
            });
        };

        function cargarTablaProductosSinGrupo1() {
            var nombFiltro = $("#nombreProd1").val();
            $.ajax({
                type: "POST",
                url: 'frmCategorizarProductos/BuscarProductos1',
                data: '{nombFiltro: ' + JSON.stringify(nombFiltro) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    document.getElementById("TbProductosSinGrupo1").innerHTML = resultado.d;
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    toastr.error(error.Message, 'Error');
                }
            });
        };

        function agregarProducto(index) {
            var table = document.getElementById('TbProductosSinGrupo');
            var idProducto = table.rows[index].cells[0].innerText;
            var nombreProducto = table.rows[index].cells[2].innerText;
            var rows = "";

            if (validarTable()) {
                if (validarSiExisteProducto(idProducto)) {
                    toastr.error('El producto ya se encuentra agregado');
                } else {
                    rows += "<tr id='trProductosParaGrupoTb" + idProducto + "'>";
                    rows += "<th scope='row' hidden='hidden'>" + idProducto + "</th>";
                    rows += "<td>" + nombreProducto + "</td>";
                    rows += "<td><input type='checkbox' disabled></td>";
                    rows += "<td>" + "<span onclick='EliminarProducto(" + idProducto + ")' class='fa fa-minus' style='font-size:30px; cursor: pointer;color:Red' title='Eliminar Producto'></span>" + "</td>";
                    rows += "</tr>";
                    $('#TbProductosParaGrupo').append(rows);
                }
            } else {
                rows += "<tr id='trProductosParaGrupoTb" + idProducto + "'>";
                rows += "<th scope='row' hidden='hidden'>" + idProducto + "</th>";
                rows += "<td>" + nombreProducto + "</td>";
                rows += "<td><input type='checkbox'checked disabled></td>";
                rows += "<td>" + "<span onclick='EliminarProducto(" + idProducto + ")' class='fa fa-minus' style='font-size:30px; cursor: pointer;color:Red' title='Eliminar Producto'></span>" + "</td>";
                rows += "</tr>";
                document.getElementById("TbProductosParaGrupo").innerHTML = rows;
            }

        };

        function agregarProducto1(index) {
            var table = document.getElementById('TbProductosSinGrupo1');
            var idProducto = table.rows[index].cells[0].innerText;
            var nombreProducto = table.rows[index].cells[2].innerText;
            var rows = "";

            if (validarSiExisteProducto1(idProducto)) {
                toastr.error('El producto ya se encuentra agregado');
            } else {
                rows += "<tr id='trProductosParaGrupoTbJ" + idProducto + "'>";
                rows += "<th scope='row' hidden='hidden'>" + idProducto + "</th>";
                rows += "<td>" + nombreProducto + "</td>";
                rows += "<td><input type='checkbox' id='chck" + idProducto + "' disabled></td>";
                rows += "<td>" + "<span onclick='EliminarProducto1(" + idProducto + ")' class='fa fa-minus' style='font-size:30px; cursor: pointer;color:Red' title='Eliminar Producto'></span>" + "</td>";
                rows += "<th scope='row' hidden='hidden'>" + 0 + "</th>";
                rows += "</tr>";
                $('#TbProductosParaGrupo1').append(rows);
            }

        };

        function validarTable() {
            var validadorPrimeraFila = document.getElementById('TbProductosParaGrupo').rows[0].innerText;
            if (validadorPrimeraFila.indexOf("Agregue productos.") != -1) {
                return false;
            }
            return true;
        };

        function validarSiExisteProducto(IdProducto) {
            for (var i = 0; i < document.getElementById('TbProductosParaGrupo').rows.length; i++) {
                if (document.getElementById('TbProductosParaGrupo').rows[i].cells[0].innerText == IdProducto) {
                    return true;
                }
            }
            return false;
        };

        function validarSiExisteProducto1(IdProducto) {
            for (var i = 0; i < document.getElementById('TbProductosParaGrupo1').rows.length; i++) {
                if (document.getElementById('TbProductosParaGrupo1').rows[i].cells[0].innerText == IdProducto) {
                    return true;
                }
            }
            return false;
        };

        function EliminarProducto(idProducto) {
            $("#trProductosParaGrupoTb" + idProducto).remove();
            var table = document.getElementById('TbProductosParaGrupo').rows.length;
            if (table == 0) {
                var rows = "";
                rows += '<tr>';
                rows += '<td colspan="3">Agregue productos.</td>';
                rows += '</tr>'
                document.getElementById("TbProductosParaGrupo").innerHTML = rows;
            }

            toastr.success('Se eliminó el producto con éxito', 'Bien');
        };

        function EliminarProducto1(idProducto) {
            var idProdAgrup = $("#trProductosParaGrupoTbJ" + idProducto)[0].cells[4].textContent;
            if (idProdAgrup == "0") {
                $("#trProductosParaGrupoTbJ" + idProducto).remove();
                var table = document.getElementById('TbProductosParaGrupo1').rows.length;
                toastr.success('Se eliminó el producto con éxito', 'Bien');
            } else {
                if (document.getElementById('chck' + idProducto).checked) {
                    toastr.error('El producto es principal, y no se puede eliminar', 'Error');
                } else {
                    swal({
                        title: "Eliminar Producto",
                        text: "¿Está seguro que desea Eliminar el producto del grupo?",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonClass: "btn-danger",
                        confirmButtonText: "Eliminar",
                        cancelButtonText: "Cancelar"
                    },
                        function (isConfirm) {
                            if (isConfirm) {
                                swal.close()
                                mostrarLoader();
                                var usu = {};
                                usu.IdUsuario = idUsuario;
                                $.ajax({
                                    type: "POST",
                                    url: 'frmCategorizarProductos/EliminarProductoDeGrupo',
                                    data: '{idProdAgrup: ' + JSON.stringify(idProdAgrup) + '}',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    async: true,
                                    success: function (resultado) {
                                        if (resultado.d == "0") {
                                            $("#trProductosParaGrupoTbJ" + idProducto).remove();
                                            toastr.success('Se eliminó el producto con éxito', 'Bien');
                                        }
                                        else {
                                            toastr.error('Ocurrió un error al realizar la eliminación, por favor pruebe otra vez', 'Error');
                                        }
                                    },
                                    error: function () {
                                        toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
                                        ocultarLoader();
                                    }
                                });
                            }
                        }
                    );
                }

            }
        };

        function NuevoGrupo() {
            document.getElementById("DivPrincipalAgrup").style.display = 'none';
            document.getElementById("DivNuevoGrupoProd").style.display = 'block';
            document.getElementById("DivEditarGrupoProd").style.display = 'none';
        };

        function guardarNuevoGrupo() {
            var table = document.getElementById('TbProductosParaGrupo');
            var idProductoPrincipal = table.rows[0].cells[0].innerText;
            var datos = "";

            for (var i = 0; i < table.rows.length; i++) {
                var idProducto = table.rows[i].cells[0].innerText;
                if (datos == "") {
                    datos += idProducto;
                } else {
                    datos += ";" + idProducto;
                }
            }

            $.ajax({
                type: "POST",
                url: 'frmCategorizarProductos/GuardarGrupo',
                data: '{datos: ' + JSON.stringify(datos) + ', idProductoPrincipal: ' + JSON.stringify(idProductoPrincipal) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    if (resultado.d == '0') {
                        toastr.success('Se realizó el registro con éxito');
                        document.getElementById("DivPrincipalAgrup").style.display = 'block';
                        document.getElementById("DivNuevoGrupoProd").style.display = 'none';
                        document.getElementById("DivEditarGrupoProd").style.display = 'none';
                        var rows = "";
                        var rows2 = "";
                        rows += '<tr>';
                        rows += '<td colspan="3">Agregue productos.</td>';
                        rows += '</tr>'
                        document.getElementById("TbProductosParaGrupo").innerHTML = rows;
                        rows2 += '<tr>';
                        rows2 += '<td colspan="3">Realice una búsqueda.</td>';
                        rows2 += '</tr>'
                        document.getElementById("TbProductosSinGrupo").innerHTML = rows2;

                        cargarTablaGrupoProd();
                    } else {
                        toastr.error('Error al realizar el registro, Intente otra vez.');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    toastr.error(error.Message, 'Error');
                }
            });

        };

        function getDetalleGrupo(idProductoPrincipal) {
            document.getElementById("DivPrincipalAgrup").style.display = 'none';
            document.getElementById("DivNuevoGrupoProd").style.display = 'none';
            document.getElementById("DivEditarGrupoProd").style.display = 'block';
            $.ajax({
                type: "POST",
                url: 'frmCategorizarProductos/GesProductosAgrupadosById',
                data: '{idproducto: ' + JSON.stringify(idProductoPrincipal) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    document.getElementById("TbProductosParaGrupo1").innerHTML = resultado.d;
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    toastr.error(error.Message, 'Error');
                }
            });
        };

        function regresar() {
            document.getElementById("DivPrincipalAgrup").style.display = 'block';
            document.getElementById("DivNuevoGrupoProd").style.display = 'none';
            document.getElementById("DivEditarGrupoProd").style.display = 'none';
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
      <div class="container" id="DivPrincipalAgrup">
        <div class="container">
            <div class="panel panel-grey">
                <div class="row" id="newbotton">
                    <div class="col-sm-6 col-md-8">Listado de Productos Agrupados</div>
                    <div class="col-sm-4 col-md-4">
                        <button type="button" class="btn btn-danger btn-sm btn-block" data-toggle="modal" onclick="NuevoGrupo()">
                            Nuevo
                        </button>
                    </div>
                </div>
                <div class="panel-body">

                    <div class="form-group row" style="margin-left:0px; margin-right:0px;">
                        <input id="NombreProductoFiltro" name="NombreProductoFiltro" type="text" placeholder="Buscar Productos" class="busqueda col-md-4 col-sm-4" />
                        <button type="button" onclick="cargarTablaGrupoProd()" class="btn btn-primary botonbusqueda">
                            Buscar Grupos
                        </button>
                    </div>

                    <table id="tbProducto" class="table table-hover table-bordered">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Producto Principal</th>
                                <th>Fecha Creacion</th>
                                <th>Estado</th>
                                <th>Acción</th>
                            </tr>
                        </thead>
                        <tbody id="bodytbProducto">
                            <tr>
                                <td colspan="5">Seleccione filtros para realizar una búsqueda</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
       </div>
    </form>
    <div class="container" id="DivNuevoGrupoProd" style="display:none">
        <div class="row" style="padding-bottom: 20px;">
            <div class="col-4">
               <button type="button" onclick="regresar()" class="btn btn-danger">Regresar
                  <i class="fa fa-undo"></i>
               </button>
                <button type="button" onclick="guardarNuevoGrupo()" class="btn btn-success">Guardar
                  <i class="fa fa-save"></i>
               </button>
            </div>
        </div>
        <div></div>
        <div></div>
        <div class="panel panel-grey">
            <div class="row">
                <div class="col-6" style="overflow-y: scroll; height: 520px;">
                    <div class="form-group">
                        <div id="alert2" class="alert alert-warning" role="alert">El primer producto agregado será el principal.</div>
                        <div id="alert" class="alert alert-success" role="alert">Listado Productos en Grupo</div>
                        <table class="table">
                            <thead class="thead-dark">
                            <tr>
                                <th scope="col"  hidden="hidden">Id. Producto</th>
                                <th scope="col" >Producto</th>
                                <th scope="col" >Flag</th>
                                <th scope="col" >Acción</th>
                            </tr>
                            </thead>
                            <tbody id="TbProductosParaGrupo" >
                            <tr>
                                <td colspan="3">Agregue productos.</td>
                            </tr>
                            </tbody>
                        </table>
                   </div>
                </div>
                <div class="col-6" style="overflow-y: scroll; height: 520px;">
                    <div class="form-group">
                        <div id="alertMesa" class="alert alert-success" role="alert">Listado Productos a Agregar</div>
                        <div class="form-group row" style="margin-left:0px; margin-right:0px;">
                        <input id="nombreProd" name="nombreProd" type="text" placeholder="Buscar Productos" class="busqueda col-md-4 col-sm-4" />
                        <button type="button" onclick="cargarTablaProductosSinGrupo()" class="btn btn-primary botonbusqueda">
                            Buscar Productos
                        </button>
                        </div>
                        <table class="table">
                            <thead class="thead-dark">
                            <tr>
                                <th scope="col"  hidden="hidden">Id. Producto</th>
                                <th scope="col" >Categoria</th>
                                <th scope="col" >Producto</th>
                                <th scope="col" >Acción</th>
                            </tr>
                            </thead>
                            <tbody id="TbProductosSinGrupo" >
                            <tr>
                                <td colspan="3">Realice una búsqueda.</td>
                            </tr>
                            </tbody>
                        </table>
                   </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container" id="DivEditarGrupoProd" style="display:none">
        <div class="row" style="padding-bottom: 20px;">
            <div class="col-4">
               <button type="button" onclick="regresar()" class="btn btn-danger">Regresar
                  <i class="fa fa-undo"></i>
               </button>
                <button type="button" onclick="guardarEditarGrupo()" class="btn btn-success">Guardar
                  <i class="fa fa-save"></i>
               </button>
            </div>
        </div>
        <div></div>
        <div></div>
        <div class="panel panel-grey">
            <div class="row">
                <div class="col-6" style="overflow-y: scroll; height: 520px;">
                    <div class="form-group">
                        <div id="alert3" class="alert alert-warning" role="alert">El primer producto agregado será el principal.</div>
                        <div id="aler4" class="alert alert-success" role="alert">Listado Productos en Grupo</div>
                        <table class="table">
                            <thead class="thead-dark">
                            <tr>
                                <th scope="col"  hidden="hidden">Id. Producto</th>
                                <th scope="col" >Producto</th>
                                <th scope="col" >Flag</th>
                                <th scope="col" >Acción</th>
                                <th scope="col"  hidden="hidden">Id. ProductoAgrup</th>
                            </tr>
                            </thead>
                            <tbody id="TbProductosParaGrupo1" >
                            <tr>
                                <td colspan="3">Agregue productos.</td>
                            </tr>
                            </tbody>
                        </table>
                   </div>
                </div>
                <div class="col-6" style="overflow-y: scroll; height: 520px;">
                    <div class="form-group">
                        <div id="alertMesa5" class="alert alert-success" role="alert">Listado Productos a Agregar</div>
                        <div class="form-group row" style="margin-left:0px; margin-right:0px;">
                        <input id="nombreProd1" name="nombreProd" type="text" placeholder="Buscar Productos" class="busqueda col-md-4 col-sm-4" />
                        <button type="button" onclick="cargarTablaProductosSinGrupo1()" class="btn btn-primary botonbusqueda">
                            Buscar Productos
                        </button>
                        </div>
                        <table class="table">
                            <thead class="thead-dark">
                            <tr>
                                <th scope="col"  hidden="hidden">Id. Producto</th>
                                <th scope="col" >Categoria</th>
                                <th scope="col" >Producto</th>
                                <th scope="col" >Acción</th>
                            </tr>
                            </thead>
                            <tbody id="TbProductosSinGrupo1" >
                            <tr>
                                <td colspan="3">Realice una búsqueda.</td>
                            </tr>
                            </tbody>
                        </table>
                   </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>