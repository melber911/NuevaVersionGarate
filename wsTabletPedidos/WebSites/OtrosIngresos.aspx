<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="OtrosIngresos.aspx.cs" Inherits="WebSites.OtrosIngresos" %>

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
        function egresos() {
            var valor = document.getElementById('<%= hfValor.ClientID %>');
            valor.value = '2'
            limpiarCampos();
            ocultarElemento(false)
        }
        function ingresos() {
            var valor = document.getElementById('<%= hfValor.ClientID %>');
            valor.value = '1'
            limpiarCampos();
            ocultarElemento(true)
        }
        function ocultarElemento(op) {
            var elemento = document.getElementById('colMotivo');
            if (op) {
                elemento.style.display = "none";
            } else {
                elemento.style.display = "";
            }
            var elemento2 = document.getElementById('<%= colMotivo2.ClientID %>');
            if (op) {
                elemento2.style.display = "none";
            } else {
                elemento2.style.display = "";
            }
        }
        function limpiarCampos() {
            // Obtener los elementos usando sus ClientIDs
            var ddlTipoIngreso = document.getElementById('<%= ddlTipoIngreso.ClientID %>');
            var ddlmotivo = document.getElementById('<%= ddlmotivo.ClientID %>');
            var txtprecioAdd = document.getElementById('<%= txtprecioAdd.ClientID %>');
            var txtObservacionAdd = document.getElementById('<%= txtObservacionAdd.ClientID %>');

            // Limpiar el dropdown: establecer el índice seleccionado en 0 o -1 según se desee
            if (ddlTipoIngreso) {
                ddlTipoIngreso.selectedIndex = 0; // o -1 para deseleccionar todos los items
            }
            if (ddlmotivo) {
                ddlmotivo.selectedIndex = 0;
            }

            // Limpiar el input de precio
            if (txtprecioAdd) {
                txtprecioAdd.value = '';
            }

            // Limpiar el textarea de observación
            if (txtObservacionAdd) {
                txtObservacionAdd.value = '';
            }
        }
        function editaregreso(){
            egresos();
            $('#modalEditarIngreso').modal('show')
        }
        function editaringreso(){
            ingresos();
            $('#modalEditarIngreso').modal('show')
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form autocomplete="off" id="form1" runat="server" class="needs-validation" novalidate>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container mb-4 pb-1 pt-3 shadow bg-body rounded">
            <div class="form-row mb-3" id="newbotton">
                <div class="col-md-8">
                    <h2 style="text-align: left;">Gestión de Otros Ingresos</h2>
                </div>
                <div class="col-md-4 d-flex justify-content-end">
                    <button id="btnAgregar" onclick="ingresos();" type="button" data-target="#modalNuevoIngreso" data-toggle="modal" style="border-radius: 15px;" class="btn btn-info mr-2">
                        <i class="fa fa-plus-circle"></i>
                        Ingresos
                    </button>
                    <button id="btnAgregarEgreso" onclick="egresos();" type="button" data-target="#modalNuevoIngreso" data-toggle="modal" style="border-radius: 15px;" class="btn btn-info mr-2">
                        <i class="fa fa-plus-circle"></i>
                        Egresos
                    </button>
                    <asp:LinkButton   Style="border-radius: 15px;" ID="imgVolver"  CssClass="btn btn-warning " runat="server" OnClick="imgVolver_Click" >
                        <i class="fa fa-reply"  ></i>
                        Regresar 
                    </asp:LinkButton>
                </div>
            </div>


        </div>
        <div class="row">
            <div class="col-6">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <!-- Resumen total -->
                        <div class="summary mb-2">
                            <strong style="color: green">Total Otros Ingresos:</strong>
                            <asp:Label Style="color: green" ID="lblTotalIngresos" runat="server" Text="0.00"></asp:Label>
                        </div>
                        <div class="table-responsive shadow bg-body rounded mb-4">
                            <asp:GridView ID="gvOtrosIngresos" runat="server" CssClass="table table-sm table-hover table-bordered mb-0"
                                AutoGenerateColumns="false" PagerStyle-CssClass="pager" AllowSorting="true" AllowPaging="true" PageSize="5"
                                OnPageIndexChanging="gvOtrosIngresos_PageIndexChanging" OnRowCommand="gvOtrosIngresos_RowCommand"
                                ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron Ingresos" OnRowDataBound="gvOtrosIngresos_RowDataBound">
                                <HeaderStyle CssClass="thead-dark" />
                                <Columns>
                                    <asp:BoundField DataField="tipo" HeaderText="Tipo de Ingreso" />
                                    <asp:BoundField DataField="Precio" HeaderText="Monto" />
                                    <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                                    <asp:TemplateField HeaderText="Acción">
                                        <ItemTemplate>
                                            <asp:LinkButton
                                                CommandName="eliminar" ID="btnEliminar" runat="server"
                                                CssClass="" CommandArgument='<%# Eval("otrosIngresosID") %>'>
                                        <i  class="fa fa-trash text-danger"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton CommandName="editar" ID="btnEditar" OnClick="btnEditar_Click" OnClientClick="editaringreso();" runat="server"
                                                CssClass="" CommandArgument='<%# Eval("otrosIngresosID") %>'>
                                    <i class="fa fa-edit text-secondary"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-6">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <!-- Resumen total -->
                        <div class="summary mb-2">
                            <strong style="color: red">Total Otros Egresos:</strong>
                            <asp:Label Style="color: red" ID="lblegresos" runat="server" Text="0.00"></asp:Label>
                        </div>
                        <div class="table-responsive shadow bg-body rounded">
                            <asp:GridView ID="gvOtrosEgresos" runat="server" CssClass="table table-sm table-hover table-bordered mb-0"
                                AutoGenerateColumns="false" PagerStyle-CssClass="pager" AllowSorting="true" AllowPaging="true" PageSize="5"
                                OnPageIndexChanging="gvOtrosEgresos_PageIndexChanging" OnRowCommand="gvOtrosEgresos_RowCommand"
                                OnRowDataBound="gvOtrosEgresos_RowDataBound"
                                ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron Egresos">
                                <HeaderStyle CssClass="thead-dark" />
                                <Columns>
                                    <asp:BoundField DataField="tipo" HeaderText="Tipo de Ingreso" />
                                    <asp:BoundField DataField="Precio" HeaderText="Monto" />
                                    <asp:BoundField DataField="motivo" HeaderText="Motivo" />
                                    <asp:BoundField DataField="Observacion" HeaderText="Observación" />
                                    <asp:TemplateField HeaderText="Acción">
                                        <ItemTemplate>
                                            <asp:LinkButton
                                                CommandName="eliminar" ID="btnEliminarEgreso" runat="server"
                                                CssClass="" CommandArgument='<%# Eval("otrosEgresosID") %>'>
                                        <i  class="fa fa-trash text-danger"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton CommandName="editar" ID="btnEditarEgreso" OnClick="btnEditarEgreso_Click" OnClientClick="editaregreso()" runat="server"
                                                CssClass="" CommandArgument='<%# Eval("otrosEgresosID") %>'>
                                    <i class="fa fa-edit text-secondary"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>


        <!-- Modales -->
        <div id="modalNuevoIngreso" class="modal fade" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="modal-header shadow bg-body">
                                <h5 class="modal-title">Agregar Ingresos e Egresos</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label>Tipo de Ingreso<b>*</b>:</label>
                                        <asp:DropDownList ID="ddlTipoIngreso" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label>Valor(S/.)<b>*</b>:</label>
                                        <input runat="server" type="text" class="form-control" id="txtprecioAdd" />
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div id="colMotivo" class="col-md-6 mb-4">
                                        <label>Motivo<b>*</b>:</label>
                                        <asp:DropDownList ID="ddlmotivo" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label>Observacion:</label>
                                        <textarea runat="server" maxlength="200" class="form-control" id="txtObservacionAdd"></textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnGuardarNuevo" OnClick="btnGuardarNuevo_Click" runat="server" CssClass="btn btn-primary" Text="Guardar" />
                            </div>
                            <asp:HiddenField ID="hfValor" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div id="modalEditarIngreso" class="modal fade" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <div class="modal-header shadow bg-body">
                                <h5 class="modal-title">Editar Ingreso</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label>Tipo de Ingreso<b>*</b>:</label>
                                        <asp:DropDownList ID="ddlTipoIngreso2" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label>Valor(S/.)<b>*</b>:</label>
                                        <input runat="server" type="text" class="form-control" id="txtprecioEdit" />
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div id="colMotivo2" runat="server" class="col-md-6 mb-4">
                                        <label>Motivo<b>*</b>:</label>
                                        <asp:DropDownList ID="ddlmotivo2" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label>Observacion:</label>
                                        <textarea runat="server" maxlength="200" class="form-control" id="txtObservacionEdit"></textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnGuardarEditar" OnClick="btnGuardarEditar_Click" runat="server" CssClass="btn btn-primary" Text="Guardar" />
                            </div>
                            <asp:HiddenField runat="server" ID="hfempidE" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>


    </form>

</asp:Content>
