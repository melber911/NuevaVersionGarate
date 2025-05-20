<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmListadoMesasAnular" CodeBehind="frmListadoMesasAnular.aspx.cs" %>

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
        html, body {
            background: none !important;
        }

        #overlay {
            position: fixed;
            z-index: 99;
            top: 0px;
            left: 0px;
            background-color: #000;
            width: 100%;
            height: 100%;
            filter: Alpha(Opacity=50);
            opacity: 0.5;
            -moz-opacity: 0.5;
        }

        #theprogress {
            background-color: #000;
            width: 120px;
            height: 24px;
            text-align: center;
            filter: Alpha(Opacity=80);
            opacity: 0.80;
            -moz-opacity: 0.80;
        }

        #modalprogress {
            position: absolute;
            top: 50%;
            left: 50%;
            margin: -11px 0 0 -55px;
            color: white;
        }

        body > #modalprogress {
            position: fixed;
        }
        .mesa-btn {
    background-color: #008f39;
    height: 60px;
    width: 85px;
    color: white;
    font-size: 14px;
    border: none;
    border-radius: 5px;
    transition: background-color 0.3s ease;
}

.mesa-btn:hover {
    background-color: #006c2c;
}
    </style>
    <script>
        function cambiarSala(sala) {
            document.getElementById("<%=lblsala.ClientID%>").innerText = " - " + document.getElementById(sala).innerText;
        }
        function VerPedidosParaLlevar() {
            document.getElementById("<%=btnParaLLevar.ClientID %>").click();
        }
        function detalle(ordenID, ordenSalon, ordenMesa, ordenEstado) {
            $('#mymodal').modal('hide');
        }
        function clickPedido(salon, mesa) {
            var salonH = document.getElementById("<%=salon.ClientID%>");
            var mesaH = document.getElementById("<%=mesa.ClientID%>");
            salonH.value = salon;
            mesaH.value = mesa;
            document.getElementById("<%=btnMesa.ClientID%>").click();
        }
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
                        <li class="breadcrumb-item active" aria-current="page">Anular</li>
                    </ol>
                </nav>
                <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
                    <div class="row mb-4">
                        <div class="col-md-6">
                            <h2 class="h2">Mesas
                                <label id="lblsala" runat="server"></label>
                                :: Anular Orden
                            </h2>
                        </div>
                        <div class="col-md-6 d-flex justify-content-end">
                            <button type="button" onclick="this.disabled=true;VerPedidosParaLlevar()" class="btn btn-info" style="border-radius: 15px;">
                                <i class="fa fa-bar-chart" aria-hidden="true"></i>
                                Pedidos Para Llevar
                            </button>
                            <asp:Button Style="display: none;" ID="btnParaLLevar" runat="server" class="btn btn-secondary btn-lg" OnClick="btnParaLLevar_Click" />
                        </div>
                    </div>
                </div>
                <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
                    <div class="row mb-4">
                        <div class="col-md-12 d-flex justify-content-center">
                            <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                                <% 
                                    int index = 1;
                                    // Iterar a través de los datos del salón y generar las pestañas
                                    foreach (var salon in Salones) // Salones es una lista que obtienes desde tu base de datos
                                    {
                                %>
                                <li class="nav-item" role="presentation">
                                    <button
                                        onclick="cambiarSala('<%= salon.Id %>');"
                                        class="nav-link <%= index == 1 ? "active" : "" %> font-weight-bold"
                                        id="salon<%= salon.Id %>"
                                        data-toggle="pill"
                                        data-target="#pills-salon<%= salon.Id %>"
                                        type="button"
                                        role="tab"
                                        aria-controls="pills-salon<%= salon.Id %>"
                                        aria-selected="<%= salon.Id == 1 %>">
                                        <%= salon.Descripcion %>
                                    </button>
                                </li>
                                <% 
                                        index++;
                                    }
                                %>
                            </ul>
                        </div>
                    </div>
                    <div class="row ml-4 mr-4">
                        <div class="col-md-12 d-flex ">
                           <div class="tab-content" id="pills-tabContent">
                                <asp:PlaceHolder ID="TabContentPlaceholder" runat="server"></asp:PlaceHolder>
                            </div>
                            <asp:HiddenField ID="salon" runat="server" />
                            <asp:HiddenField ID="mesa" runat="server" />
                            <asp:Button ID="btnMesa" runat="server" Text="" OnClick="btnMesa_Click" Style="display: none" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div id="overlay">
                    <div id="modalprogress">
                        <div id="theprogress">
                            <img src="images/ajax-loader.gif" class="icon" width="80" height="80" />
                            <h5><span class="modal-text">Cargando... </span></h5>
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div id="mymodal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel1" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel1">Listado de Pedidos Divididos</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="container mb-4 pb-3 pt-3">
                                    <div class="row">
                                        <div class="col">
                                            <div class="table-responsive shadow-lg bg-body rounded">
                                                <asp:GridView ID="gdListadoPedidos" runat="server" CssClass="table table-hover table-sm table-bordered mb-0" AutoGenerateColumns="false"
                                                    OnRowCommand="gdListadoPedidos_RowCommand" OnRowDataBound="gdListadoPedidos_RowDataBound"
                                                    ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron pedidos para Llevar"
                                                    PagerStyle-CssClass="pager" AllowSorting="true" AllowPaging="true" PageSize="6" OnPageIndexChanging="gdListadoPedidos_PageIndexChanging">
                                                    <HeaderStyle CssClass="thead-dark" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="#"
                                                            ItemStyle-Width="20px"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ordenID"
                                                            HeaderText="#Orden"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenCliente"
                                                            HeaderText="cliente"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenMesa"
                                                            HeaderText="Mesa"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenSalon"
                                                            HeaderText="Salon"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenTipo"
                                                            HeaderText="Tipo"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenUser"
                                                            HeaderText="Usuario"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenEstado"
                                                            HeaderText="Estado"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:TemplateField HeaderText=""
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-Width="50px"
                                                            ItemStyle-CssClass="align-middle">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="ibtBuscar" ToolTip="Detalle" OnClientClick="detalle();"
                                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex + "|" + Eval("ordenID") + "|" + Eval("ordenSalon") + "|" + Eval("ordenMesa") + "|" + Eval("ordenEstado")%>'
                                                                    CommandName="Detalle">
                                                                    <i style="color: #17a2b8;" class="fa fa-search"></i>
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerSettings PageButtonCount="4" FirstPageText="Primero" LastPageText="Ultimo" Mode="NumericFirstLast" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div id="mymodal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel1" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel1">Listado de Pedidos Divididos</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="container mb-4 pb-3 pt-3">
                                    <div class="row">
                                        <div class="col">
                                            <div class="table-responsive shadow-lg bg-body rounded">
                                                <asp:GridView ID="divididos" runat="server" CssClass="table table-hover table-sm table-bordered mb-0" AutoGenerateColumns="false"
                                                    OnRowCommand="divididos_RowCommand" OnRowDataBound="divididos_RowDataBound"
                                                    ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron pedidos divididos"
                                                    PagerStyle-CssClass="pager" AllowSorting="true" AllowPaging="true" PageSize="6" OnPageIndexChanging="divididos_PageIndexChanging">
                                                    <HeaderStyle CssClass="thead-dark" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="#"
                                                            ItemStyle-Width="20px"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ordenID"
                                                            HeaderText="#Orden"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenMesa"
                                                            HeaderText="Mesa"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenSalon"
                                                            HeaderText="Salon"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenTipo"
                                                            HeaderText="Tipo"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenUser"
                                                            HeaderText="Usuario"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="ordenEstado"
                                                            HeaderText="Estado"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:BoundField DataField="comprobanteNumDocu"
                                                            HeaderText="Comprobante"
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-CssClass="align-middle" />
                                                        <asp:TemplateField HeaderText=""
                                                            ItemStyle-HorizontalAlign="Center"
                                                            ItemStyle-Width="50px"
                                                            ItemStyle-CssClass="align-middle">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="ibtBuscar" ToolTip="Detalle" OnClientClick="detalle();"
                                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex + "|" + Eval("ordenID") + "|" + Eval("ordenSalon") + "|" + Eval("ordenMesa") + "|" + Eval("ordenEstado") + "|" + Eval("comprobanteNumDocu")%>'
                                                                    CommandName="Detalle">
                                                                    <i style="color: #17a2b8;" class="fa fa-search"></i>
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerSettings PageButtonCount="4" FirstPageText="Primero" LastPageText="Ultimo" Mode="NumericFirstLast" />
                                                </asp:GridView>
                                            </div>
                                        </div>
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
