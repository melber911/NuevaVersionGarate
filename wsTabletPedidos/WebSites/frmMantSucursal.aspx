<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="frmMantSucursal.aspx.cs" Inherits="WebSites.frmMantSucursal" %>

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
        function addLeadingZeros(input) {
            // Obtén el valor actual del input
            let value = input.value.trim();

            // Asegúrate de que el valor tenga 3 caracteres, rellenando con ceros a la izquierda
            if (value.length > 0 && value.length < 3) {
                input.value = value.padStart(3, '0');
            }
        }
        function validateInput(input) {
            // Asegúrate de que el valor no sea menor que 1
            if (input.value < 1) {
                input.value = 1; // Establece el valor mínimo permitido
            }

            // Limita la longitud del número a 10 dígitos
            if (input.value.length > 10) {
                input.value = input.value.slice(0, 10);
            }

            // Asegúrate de que solo se ingresen números
            input.value = input.value.replace(/[^0-9]/g, ''); // Elimina todo lo que no sea un número

            // Si se intenta agregar un valor no numérico, se reemplaza con una cadena vacía
            if (isNaN(input.value)) {
                input.value = ''; // Resetea el valor si no es un número
            }
        }
        function validateNumberInput(input) {
            // Elimina cualquier carácter que no sea un número
            input.value = input.value.replace(/[^0-9]/g, '');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
                    <div class="row mb-4">
                        <div class="col-md-6">
                            <h2>Listado de Sucursales</h2>
                        </div>
                        <div class="col-md-6 d-flex justify-content-end">
                            <button title="Agregar Categoria" type="button" class="btn btn-info mr-1" style="border-radius: 15px;" data-toggle="modal" data-target="#mymodal">
                                <i class="fa fa-plus-circle"></i>
                                Agregar
                            </button>
                        </div>
                    </div>
                </div>
                <div class="table-responsive shadow-lg bg-body rounded">
                    <asp:GridView runat="server" ID="gvSucursales" ShowHeaderWhenEmpty="true" EmptyDataText="Sin registro"
                        CssClass="table table-sm table-hover table-bordered mb-0" PagerStyle-CssClass="pager"
                        AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="5"
                        OnRowCommand="gvSucursales_RowCommand" OnPageIndexChanging="gvSucursales_PageIndexChanging">
                        <HeaderStyle CssClass="thead-dark" />
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="id" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Nombre Local" DataField="nombreLocal" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Direccion" DataField="direccion" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="Estado" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%#  Eval("estado").ToString() == "1" ?
                                        "<span class='label label-sm label-success'> ACTIVADO</span>" :
                                        "<span class='label label-sm label-danger'> DESACTIVADO</span>"%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Opc." ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server"  CssClass="btn"
                                        ToolTip="Editar"
                                        CommandArgument='<%# Eval("id")%>'
                                        CommandName="editar"><i class="fa fa-edit"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="mymodal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel3" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" >Agregar Sucursal</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtnombre.ClientID %>">Nombre del local<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtnombre" maxlength="50" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label>Estado<b>(*)</b></label>
                                        <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                            <input runat="server" class="custom-control-input" type="checkbox" id="ChkEstado" checked />
                                            <label class="custom-control-label" for="<%=ChkEstado.ClientID %>">Activo</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-12 mb-4">
                                        <label for="<%=txtdireccion.ClientID %>">Direccion<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtdireccion" maxlength="100" />
                                    </div>

                                </div>
                                <div class="table-responsive shadow-lg bg-body rounded">
                                    <asp:GridView runat="server" ID="GVDoc" ShowHeaderWhenEmpty="true" EmptyDataText="Sin registro"
                                        CssClass="table table-sm table-hover table-bordered mb-0" 
                                        AutoGenerateColumns="false" 
                                        >
                                        <HeaderStyle CssClass="thead-dark" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="#" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"  HeaderText="Tipo Documento" DataField="tipoDocumento" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small" HeaderText="Serie"   ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="d-flex align-items-center ">
                                                        <label id="lblserie" class="form-control-label mr-2 mb-0 " runat="server">
                                                            <%# Eval("serie") %>
                                                        </label>
                                                        <input id="txtSerie" oninput="validateNumberInput(this)" maxlength="3" onblur="addLeadingZeros(this)" class="form-control form-control-sm" runat="server" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"  HeaderText="Correlativo" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <input id="txtCorrelativo" type="text" value="1" maxlength="10" class="form-control form-control-sm" oninput="validateInput(this)"  runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"  HeaderText="Declara?" DataField="declara" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                                        </Columns>
                                        </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="BtnGuardar" CssClass="btn btn-success" runat="server" OnClick="BtnGuardar_Click" Style="border-radius: 15px;">
                                            <i class="fa fa-save"  ></i>
                                            Guardar 
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div id="mymodal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel3" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" >Modificar Sucursal</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtEnombre.ClientID %>">Nombre del local<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtEnombre" maxlength="50" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label>Estado<b>(*)</b></label>
                                        <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                            <input runat="server" class="custom-control-input" type="checkbox" id="ChkEestado" checked />
                                            <label class="custom-control-label" for="<%=ChkEestado.ClientID %>">Activo</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-12 mb-4">
                                        <label for="<%=txtEdireccion.ClientID %>">Direccion<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtEdireccion" maxlength="100" />
                                    </div>
                                </div>
                                <div class="table-responsive shadow-lg bg-body rounded">
                                    <asp:GridView runat="server" ID="GVEDIT" ShowHeaderWhenEmpty="true" EmptyDataText="Sin registro"
                                        CssClass="table table-sm table-hover table-bordered mb-0" 
                                        AutoGenerateColumns="false" 
                                        >
                                        <HeaderStyle CssClass="thead-dark" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="#" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"  HeaderText="Tipo Documento" DataField="correlaTipDoc" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small" HeaderText="Serie"   ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                        <input id="txtSerie1"  maxlength="4" value='<%# Eval("correlaSerie") %>' class="form-control form-control-sm" runat="server" />

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Font-Size="Small" HeaderStyle-Font-Size="Small"  HeaderText="Correlativo" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <input value='<%# Eval("correlaNumSec") %>' id="txtCorrelativo1" type="text"  maxlength="10" class="form-control form-control-sm" oninput="validateInput(this)"  runat="server"/>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="btnActualizar" CssClass="btn btn-success" runat="server" OnClick="btnActualizar_Click" Style="border-radius: 15px;">
                                            <i class="fa fa-save"  ></i>
                                            Guardar 
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField runat="server" ID="hfidE" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</asp:Content>
