<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmListadoPedidosxPagar" CodeBehind="frmListadoPedidosxPagar.aspx.cs" %>

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
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item active" aria-current="page">Lista</li>
                    </ol>
                </nav>
                <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
                    <div class="row">
                        <div class="col-md-12">
                            <h2>Listado de Pedidos Pagados</h2>
                        </div>
                    </div>
                </div>
                <div class="table-responsive shadow-lg bg-body rounded">
                    <asp:GridView ID="gdListadoPedidos" CssClass="table table-sm table-hover table-bordered mb-0" runat="server" AutoGenerateColumns="false"
                        OnRowCommand="gdListadoPedidos_RowCommand" OnRowDataBound="gdListadoPedidos_RowDataBound"
                        ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron pedidos pagados"
                        PagerStyle-CssClass="pager" AllowSorting="true" AllowPaging="true" PageSize="10" OnPageIndexChanging="gdListadoPedidos_PageIndexChanging">
                        <HeaderStyle CssClass="thead-dark" />
                        <Columns>
                            <asp:TemplateField HeaderText=""
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="ibtBuscar" ToolTip="Detalle"
                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex + "|" + Eval("ordenID") + "|" + Eval("ordenSalon") + "|" + Eval("ordenMesa") + "|" + Eval("ordenEstado") + "|" + Eval("comprobanteNumDocu")%>'
                                        CommandName="Detalle">
                                <i style="color: #17a2b8;" class="fa fa-search"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="LinkButton1" ToolTip="Detalle"
                                        CommandArgument='<%# Eval("rutaPDF")%>' 
                                        CommandName="imprimir">
                                <i  class="fa fa-print text-warning"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ordenMesa"
                                HeaderText="Mesa"
                                ItemStyle-Font-Bold="true"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-ForeColor="Red" />
                            <asp:BoundField DataField="ordenSalon"
                                HeaderText="Salon"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ordenTipo"
                                HeaderText="Tipo"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ordenID"
                                HeaderText="#Orden"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ordenUser"
                                HeaderText="Usuario"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ordenEstado"
                                HeaderText="Estado"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="comprobanteNumDocu"
                                HeaderText="Comprobante"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                        <PagerStyle />
                        <PagerSettings PageButtonCount="4" FirstPageText="Primero" LastPageText="Ultimo" Mode="NumericFirstLast" />
                    </asp:GridView>
                </div>
                <div class="modal fade" id="pdfModal" tabindex="-1" aria-labelledby="pdfModalLabel"  aria-hidden="true">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="pdfModalLabel">BOLETA</h5>
                            </div>
                            <div class="modal-body">
                                <iframe runat="server" id="ifrpdf"
                                    style="width: 100%; height: 500px;" frameborder="0"></iframe>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <button  id="BtnCerrar" data-dismiss="modal" class="btn btn-secondary" style="border-radius: 15px;">
                                            cerrar
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</asp:Content>
