<%@ Page MasterPageFile="~/Menu.Master" Language="C#" AutoEventWireup="true" CodeBehind="frmMantSalonMesas.aspx.cs" Inherits="WebSites.MantSalonMesas" %>

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
                            <h2>Listado de salones y Mesas</h2>
                        </div>
                        <div class="col-md-6 d-flex justify-content-end">
                            <button title="Agregar Salon" type="button" class="btn btn-info mr-1" style="border-radius: 15px;" data-toggle="modal" data-target="#mymodal">
                                <i class="fa fa-plus-circle"></i>
                                Agregar
                            </button>
                        </div>
                    </div>
                </div>
                <div class="table-responsive shadow-lg bg-body rounded">
                        <asp:GridView ID="gvMesas" ShowHeaderWhenEmpty="true" EmptyDataText="Sin registro" runat="server" CssClass="table table-sm table-hover table-bordered mb-0" PagerStyle-CssClass="pager"
                            AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="5"
                            OnRowCommand="gvMesas_RowCommand" OnRowDataBound="gvMesas_RowDataBound" OnPageIndexChanging="gvMesas_PageIndexChanging">
                            <HeaderStyle CssClass="thead-dark" />
                            <Columns>
                                <asp:BoundField HeaderText="Nro Orden" 
                                    DataField="nroOrden" 
                                    ItemStyle-CssClass="align-middle" 
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Descripcion" 
                                    DataField="nombre" 
                                    ItemStyle-CssClass="align-middle" 
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Nro Mesas" 
                                    DataField="nroMesas" 
                                    ItemStyle-CssClass="align-middle" 
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField ItemStyle-CssClass="align-middle" 
                                    ItemStyle-HorizontalAlign="Center" 
                                    ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <div class="btn-group">
                                            <asp:LinkButton runat="server" ID="ibtDetalle" CssClass="btn"
                                            ToolTip="editar"
                                            CommandArgument='<%# Eval("id")%>'
                                            CommandName="editar"><i class="fa fa-edit text-secondary"></i></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn"
                                            ToolTip="eliminar"
                                            CommandArgument='<%# Eval("id")%>'
                                            CommandName="eliminar"><i  class="fa fa-trash text-danger"></i></asp:LinkButton>
                                        </div>
                                        
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
                                <h4 class="modal-title" id="myLargeModalLabel1">Agregar Salon</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtDescripcion.ClientID %>">Descripcion<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtDescripcion" placeholder="Ejemplo: Salon 1" maxlength="50" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtnromesas.ClientID %>">Cantidad de Mesas<b>(*)</b></label>
                                        <input runat="server" type="number" class="form-control" id="txtnromesas" placeholder="" />
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtorden.ClientID %>">Nro Orden<b>(*)</b></label>
                                        <input runat="server" type="number" class="form-control" id="txtorden" />
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
        <div id="mymodal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel1" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel2">Agregar Salon</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtDescripcionE.ClientID %>">Descripcion<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtDescripcionE" placeholder="Ejemplo: Salon 1" maxlength="50" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtnromesasE.ClientID %>">Cantidad de Mesas<b>(*)</b></label>
                                        <input runat="server" type="number" class="form-control" id="txtnromesasE" placeholder="" />
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtordenE.ClientID %>">Nro Orden<b>(*)</b></label>
                                        <input runat="server" type="number" class="form-control" id="txtordenE" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="BtnActualizar" OnClick="BtnActualizar_Click" CssClass="btn btn-success" runat="server" Style="border-radius: 15px;">
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
    </form>
</asp:Content>