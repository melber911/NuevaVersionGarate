<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmListadoPagadosSUNAT" CodeBehind="frmListadoPagadosSUNAT.aspx.cs" %>

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
                        <li class="breadcrumb-item active" aria-current="page">Lista SUNAT</li>
                    </ol>
                </nav>
                <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
                    <div class="row">
                        <div class="col-md-12">
                            <h2>Estado envió de Comprobantes</h2>
                        </div>
                    </div>
                </div>
                <div class="table-responsive shadow-lg bg-body rounded">
                    <asp:GridView ID="gdListadoPedidos" runat="server" CssClass="table table-sm table-hover table-bordered mb-0" AutoGenerateColumns="false"
                        OnRowCommand="gdListadoPedidos_RowCommand" OnRowDataBound="gdListadoPedidos_RowDataBound"
                        ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron comprobantes SUNAT"
                        PagerStyle-CssClass="pager" AllowSorting="true" AllowPaging="true" PageSize="10" OnPageIndexChanging="gdListadoPedidos_PageIndexChanging">
                        <HeaderStyle CssClass="thead-dark" />
                        <Columns>
                            <asp:TemplateField HeaderText=""
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="ibtBuscar" ToolTip="Detalle"
                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex + "|" + Eval("ordenID") + "|" + Eval("ordenSalon") + "|" + Eval("ordenMesa") + "|" + Eval("vchEstado") + "|" + Eval("comprobanteNumDocu")%>'
                                        CommandName="Detalle">
                                <i style="color: #17a2b8;" class="fa fa-search"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="comprobanteNumDocu"
                                HeaderText="Comprobante"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="comprobanteTipDocu"
                                HeaderText="Tipo"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ordenUser"
                                HeaderText="Usuario"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="vchEstado"
                                HeaderText="Estado"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="vchMensaje"
                                HeaderText="Mensaje"
                                ItemStyle-CssClass="text-break align-middle"
                                ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                        <PagerStyle />
                        <PagerSettings PageButtonCount="4" FirstPageText="Primero" LastPageText="Ultimo" Mode="NumericFirstLast" />
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


    </form>
</asp:Content>
