<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmPedidoDetalleAnular" CodeBehind="frmPedidoDetalleAnular.aspx.cs" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="frmListadoMesasAnular">Anular</a></li>
                        <li class="breadcrumb-item active" aria-current="page">Anular Pedido</li>
                    </ol>
                </nav>
                <div class="container ">
                    <div class="row">
                        <div class="col-md-6 mb-4 pb-3 pt-3  shadow bg-body rounded">
                            <div class="row mb-5">
                                <div class="col-md-12">
                                    <h2>Orden #<%=Request.QueryString["vchOrdenID"].ToString() %></h2>
                                </div>
                            </div>
                            <div class="row mb-5">
                                <div class="col-md-4">
                                    <label class="h4">Motivo:</label>
                                </div>
                                <div class="col-md-8">
                                    <textarea runat="server" class="form-control" id="txtMotivo" maxlength="200"></textarea>
                                </div>
                            </div>
                            <div class="row mb-4">
                                <div class="col-md-12">
                                    <label class="p-1 h4 font-weight-bold mr-1">Total:</label><label runat="server" id="lblValor" class="p-1 font-weight-bold rounded bg-primary h4 text-white"></label>
                                </div>
                            </div>
                            <div class="row mb-4">
                                <div class="col-md-12 d-flex justify-content-end">
                                    <asp:LinkButton CssClass="btn btn-lg btn-outline-danger bt-lg" ID="btnAnular" runat="server" Visible="false" OnClick="btnAnular_Click">
                                        <i class="fa fa-times-circle" aria-hidden="true"></i>
                                        Anular
                                    </asp:LinkButton>
                                    <asp:LinkButton CssClass="btn btn-lg btn-outline-success bt-lg" ID="btnGuardarO" runat="server" OnClick="btnGuardarO_Click">
                                        <i class="fa fa-save"></i>
                                        Guardar
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 mb-4">
                            <div class="table-responsive shadow-lg bg-body rounded">
                                <asp:GridView ID="gdPedido" runat="server" AutoGenerateColumns="false" OnRowCommand="gdPedido_RowCommand" CssClass="table table-sm table-hover table-bordered mb-0">
                                    <HeaderStyle CssClass="thead-dark" />
                                    <Columns>
                                        <asp:TemplateField HeaderText=""
                                            ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" CssClass="btn-lg" ID="ibtMenos" ToolTip="Quitar Item" Style="color: red;"
                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex + "-" + Eval("vchCodigo")%>' CommandName="Menos">
                                                    <i class="fa fa-minus-circle" aria-hidden="true"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intCantidad" HeaderText="Cant."
                                            ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="vchDeItem"
                                            HeaderText="Desc." />
                                        <asp:BoundField DataField="numPrecioTot"
                                            HeaderText="P.T" />
                                    </Columns>
                                </asp:GridView>
                            </div>
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
    </form>
</asp:Content>
