<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmMantProductos" CodeBehind="frmMantProductos.aspx.cs" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
                    <div class="row mb-5">
                        <div class="col-md-6">
                            <h2>Listado de Productos</h2>
                        </div>
                        <div class="col-md-6 d-flex justify-content-end">
                            <button title="Agregar Categoria" type="button" class="btn btn-info mr-1" style="border-radius: 15px;" data-toggle="modal" data-target="#mymodal">
                                <i class="fa fa-plus-circle"></i>
                                Categoría
                            </button>

                            <button title="Agregar Sub-Categoria" type="button" class="btn btn-info mr-1" style="border-radius: 15px;" data-toggle="modal" data-target="#mymodal2">
                                <i class="fa fa-plus-circle"></i>
                                Sub-Categoria
                            </button>

                            <button title="Agregar Producto" type="button" class="btn btn-info mr-1" style="border-radius: 15px;" data-toggle="modal" data-target="#mymodal3">
                                <i class="fa fa-plus-circle"></i>
                                Producto
                            </button>
                        </div>
                    </div>
                    <div class="form-row mb-1">
                        <div class="col-md-4">
                            <label for="<%=ddlCategoria.ClientID %>">Categoría:</label>
                            <asp:DropDownList runat="server" ID="ddlCategoria" AutoPostBack="true" CssClass="form-control js-example-basic-single" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label for="<%=ddlSCategoria.ClientID %>">Sub-Categoría:</label>
                            <asp:DropDownList runat="server" ID="ddlSCategoria" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlSCategoria_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label for="<%=txtBusquedaProducto.ClientID %>">Buscar:</label>
                            <div class="input-group">
                                <input runat="server" type="text" class="form-control" id="txtBusquedaProducto" placeholder="Desc. de Producto" maxlength="100" />
                                <div class="input-group-append">
                                    <asp:LinkButton ID="ibtDetalleB" CssClass="btn btn-primary" runat="server" OnClick="ibtDetalleB_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="table-responsive shadow-lg bg-body rounded">
                        <asp:GridView ID="gvProductos" ShowHeaderWhenEmpty="true" EmptyDataText="Sin registro" runat="server" CssClass="table table-sm table-hover table-bordered mb-0" PagerStyle-CssClass="pager"
                            AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="5"
                            OnRowCommand="gvProductos_RowCommand" OnRowDataBound="gvProductos_RowDataBound" OnPageIndexChanging="gvProductos_PageIndexChanging">
                            <HeaderStyle CssClass="thead-dark" />
                            <Columns>
                                <asp:TemplateField HeaderText="#" ItemStyle-Width="30px" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate >
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Cat." DataField="vchCategoria" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Sub." DataField="vchSubCategoria" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Cod." DataField="vchCodProducto" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Desc." DataField="vchDescripcion" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="P/U" DataField="vchPrecio" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderText="Estado" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%#  Eval("vchEstado").ToString() == "ACTIVO" ?
                            "<span class='label label-sm label-success'> Activado</span>" :
                            "<span class='label label-sm label-danger'> Desactivado</span>"%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="ibtDetalle" CssClass="btn"
                                            ToolTip="Detalle"
                                            CommandArgument='<%# Eval("vchCodigo")%>'
                                            CommandName="Detalle"><i style="color:#17a2b8;" class="fa fa-search"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle />
                            <PagerSettings PageButtonCount="4" FirstPageText="Primero" LastPageText="Ultimo" Mode="NumericFirstLast" />
                        </asp:GridView>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="mymodal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel1" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel1">Agregar Categoria</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-12 mb-4">
                                        <label for="<%=txtCategoria.ClientID %>">Categoria<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtCategoria" placeholder="Categoria" maxlength="100" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="BtnGuardar" OnClick="BtnGuardar_Click" CssClass="btn btn-success" runat="server" Style="border-radius: 15px;">
                                            <i class="fa fa-save"></i>
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
        <div id="mymodal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel2" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel2">Agregar SubCategoria</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>

                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=ddlCategoria2.ClientID %>">Categoria<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="ddlCategoria2" CssClass="form-control">
                                            
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtSCategoria.ClientID %>">Sub-Categoria<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtSCategoria" placeholder="Categoria" maxlength="100" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="BtnGuardar2" CssClass="btn btn-success" runat="server" OnClick="BtnGuardar2_Click" Style="border-radius: 15px;">
                                            <i class="fa fa-save"></i>
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
        <div id="mymodal3" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel3" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel3">Agregar Producto</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>

                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=ddlCategoria3.ClientID %>">Categoria<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="ddlCategoria3" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria3_SelectedIndexChanged">
                                           
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=ddlSCategoria2.ClientID %>">Sub-Categoria<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="ddlSCategoria2" CssClass="form-control">
                                            
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtDescripcion.ClientID %>">Descripcion<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtDescripcion" maxlength="100" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtPrecio.ClientID %>">Precio<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtPrecio" maxlength="100" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="BtnGuardar3" CssClass="btn btn-success" runat="server" OnClick="BtnGuardar3_Click" Style="border-radius: 15px;">
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
    </form>
</asp:Content>
