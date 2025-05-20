<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmDetalleProducto" CodeBehind="frmDetalleProducto.aspx.cs" %>

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
        .auto-style1 {
            width: 146px;
        }

        .auto-style3 {
            width: 146px;
            height: 32px;
        }

        .auto-style4 {
            width: 39px;
        }

        .auto-style5 {
            width: 146px;
            height: 26px;
        }

        .auto-style6 {
            height: 26px;
        }
    </style>
    <script type="text/javascript">
        // Solo permite ingresar numeros.
        function soloNumeros(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        };

        function soloNumerosPunto(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key == 46 || key >= 48 && key <= 57)
        };
        function EditarIngresoStock(IdAlmacenProducto) {
            document.getElementById("txtCosto" + IdAlmacenProducto).disabled = false;
            document.getElementById("fVencimientoProd" + IdAlmacenProducto).disabled = false;
            document.getElementById("<%=txtDescripcion.ClientID%>" + IdAlmacenProducto).disabled = false;
            document.getElementById("saveEditIngStock" + IdAlmacenProducto).style.display = "block";
            document.getElementById("cancelEditIngStock" + IdAlmacenProducto).style.display = "block";
            document.getElementById("editIngStock" + IdAlmacenProducto).style.display = "none";
        };
        function CancelEdicion(IdAlmacenProducto) {
            document.getElementById("txtCosto" + IdAlmacenProducto).disabled = true;
            document.getElementById("fVencimientoProd" + IdAlmacenProducto).disabled = true;
            document.getElementById("<%=txtDescripcion.ClientID%>" + IdAlmacenProducto).disabled = true;
            document.getElementById("saveEditIngStock" + IdAlmacenProducto).style.display = "none";
            document.getElementById("cancelEditIngStock" + IdAlmacenProducto).style.display = "none";
            document.getElementById("editIngStock" + IdAlmacenProducto).style.display = "block";
            document.getElementById("<%=txtDescripcion.ClientID%>" + IdAlmacenProducto).value = "";
        };
        function GuardarEdicion(IdAlmacenProducto) {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            var descripcion = document.getElementById("<%=txtDescripcion.ClientID%>" + IdAlmacenProducto).value;
            if (descripcion == "") {
                toastr.error("Debe digitar una descipción para poder continuar", 'Error');
            } else {
                swal({
                    title: "Editar Producto",
                    text: "¿Está seguro que desea editar este registro?",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonClass: "btn-danger",
                    confirmButtonText: "Editar",
                    cancelButtonText: "Cancelar"
                },
                    function (isConfirm) {
                        if (isConfirm) {
                            swal.close()

                            var CostoProducto = document.getElementById("txtCosto" + IdAlmacenProducto).value;
                            var FechaVencimiento = document.getElementById("fVencimientoProd" + IdAlmacenProducto).value;
                            var datos = IdAlmacenProducto + ";" + CostoProducto + ";" + FechaVencimiento + ";" + descripcion;

                            $.ajax({
                                type: "POST",
                                url: 'frmDetalleProducto/EditarIngresoStock',
                                data: '{datos: ' + JSON.stringify(datos) + '}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: true,
                                success: function (resultado) {
                                    toastr.success('Se realizó la edición con éxito', 'Bien');
                                    CancelEdicion(IdAlmacenProducto);
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                                    toastr.error(error.Message, 'Error');
                                }
                            });
                        }
                    }
                );
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container pb-3 pt-3 mb-4 shadow-lg bg-body rounded">
            <div class="row mb-5 ">
                <div class="col-md-6">
                    <h2>Detalle Producto</h2>
                </div>
                <div class="col-md-6 d-flex justify-content-end">
                    <asp:LinkButton OnClientClick="this.disabled=true;"  Style="border-radius: 15px;" ID="imgVolver"  CssClass="btn btn-lg btn-warning mr-2" runat="server" OnClick="imgVolver_Click" >
                        <i class="fa fa-reply"  ></i>
                        Regresar 
                    </asp:LinkButton>
                    <asp:LinkButton OnClientClick="this.disabled=true;"  Style="border-radius: 15px;" ID="btnGuardar"  CssClass="btn btn-lg btn-success" runat="server" OnClick="btnGuardar_Click1">
                        <i class="fa fa-save"  ></i>        
                        Guardar 
                    </asp:LinkButton>
                </div>
            </div>
            <div class="form-row mb-3">
                <div class="col-md-6 mb-3">
                    <label for="<%=ddlCategoria.ClientID %>">Categoria<b>(*)</b></label>
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged1" >
                        <asp:ListItem Text="Seleccione.." Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6 mb-3">
                    <label for="<%=ddlSCategoria.ClientID %>">Sub-Categoria<b>(*)</b></label>
                    <asp:DropDownList runat="server" ID="ddlSCategoria" CssClass="form-control">
                        <asp:ListItem Text="Seleccione.." Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row mb-3">
                <div class="col-md-6 mb-3">
                    <label for="<%=txtDescripcion.ClientID %>">Descripcion<b>(*)</b></label>
                    <input runat="server" type="text" class="form-control" id="txtDescripcion" maxlength="100" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="<%=txtPrecio.ClientID %>">Precio<b>(*)</b></label>
                    <input onkeypress="return soloNumerosPunto(event)" runat="server" type="text" class="form-control" id="txtPrecio" maxlength="100" />
                </div>
            </div>
            <div class="form-row mb-3">
                <div class="col-md-6 mb-3">
                    <label for="<%=txtStockProd.ClientID %>">Stock<b>(*)</b></label>
                    <input runat="server" type="text" class="form-control" id="txtStockProd" maxlength="100" />
                </div>
                <div class="col-md-6 mb-3">
                    <label for="<%=ddlEstado.ClientID %>">Estado<b>(*)</b></label>
                    <asp:DropDownList CssClass="form-control" ID="ddlEstado" runat="server">
                        <asp:ListItem Value="ACT">ACTIVO</asp:ListItem>
                        <asp:ListItem Value="ANU">ANULADO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row mb-3">
                <div class="col-md-12 mb-3">
                    <label>Tipo<b>(*)</b></label>
                    <br/>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" runat="server" type="radio" name="inlineRadioOptions" id="rdbListTipo1" value="C" checked />
                        <label class="form-check-label" for="<%=rdbListTipo1.ClientID %>">Comer Aqui</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <input class="form-check-input" runat="server" type="radio" name="inlineRadioOptions" id="rdbListTipo2" value="L" />
                        <label class="form-check-label" for="<%=rdbListTipo2.ClientID %>">Para LLevar</label>
                    </div>
                </div>
            </div>
        </div>
        <div class="table-responsive shadow-lg bg-body rounded">
                <table class="table table-sm table-hover table-bordered mb-0">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col" hidden="hidden">ID_INGRESO_STOCK</th>
                            <th scope="col"  hidden="hidden">ID_DET_INGRESO_STOCK</th>
                            <th scope="col"  hidden="hidden">ID_ALMACEN_PRODUCTO</th>
                            <th scope="col"  hidden="hidden">ID_PRODUCTO</th>
                            <th scope="col" >COD LOTE</th>
                            <th scope="col" >STOCK</th>
                            <th scope="col"  hidden="hidden">CANTIDAD_INGRESO</th>
                            <th scope="col" >COSTO</th>
                            <th scope="col" >FECHA VENCIMIENTO</th>
                            <th scope="col" >DESCRIPCIÓN</th>
                            <th scope="col" >ACCIÓN</th>
                        </tr>
                    </thead>
                    <tbody id="bodyIngesoStock" runat="server">
                        <tr>
                            <td colspan="11">No existen Entradas para este producto</td>
                        </tr>
                    </tbody>
                </table>
            </div>
    </form>
</asp:Content>
