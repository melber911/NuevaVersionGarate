<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmGenComprobPago_v2" CodeBehind="frmGenComprobPago_v2.aspx.cs" %>

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

        .form-row:hover {
            background-color: #e9ecef;
        }
    </style>
    <script type="text/javascript">
        // Solo permite ingresar numeros.
        function soloNumeros(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        }

        function soloNumerosPunto(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key == 46 || key >= 48 && key <= 57)
        }

        function buscadorRuc() {
            var lstrRuc = document.getElementById('<%=txtRuc.ClientID%>').value;
            if (lstrRuc == "") {
                alert("Complete el campo!");
                return;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="frmListadoPagadosSUNAT">Lista SUNAT</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Pagar Orden</li>
                                </ol>
                            </nav>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="container pb-3 pt-3 mb-4 shadow-lg bg-body rounded">
                                <div class="row mb-4">
                                    <div class="col-md-12">
                                        <h2>Orden #<%=Request.QueryString["vchOrdenID"].ToString() %></h2>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblinfoDoc" runat="server" Text="#Documento:" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-md-6 ">
                                        <asp:TextBox ID="txtNumDoc" CssClass="form-control form-control-sm" runat="server" MaxLength="13" Visible="false" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblTipDoc" runat="server" Text="Tipo de Documento:"></asp:Label>
                                    </div>
                                    <div class="col-md-6 ">
                                        <asp:DropDownList ID="ddlComprob" CssClass="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlComprob_SelectedIndexChanged">
                                            <asp:ListItem Value="BOL">BOLETA</asp:ListItem>
                                            <asp:ListItem Value="FAC">FACTURA</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-12">
                                        <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                            <input runat="server" class="custom-control-input" disabled="disabled" type="checkbox" id="chkEnviar" />
                                            <label class="custom-control-label" for="<%=chkEnviar.ClientID %>">Generar Comprobante</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblRuc" runat="server" Text="DNI"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtRuc" CssClass="form-control form-control-sm" runat="server" MaxLength="11" onKeyPress="return soloNumeros(event)" autocomplete="off"></asp:TextBox>
                                            <div class="input-group-append">
                                                <asp:LinkButton CssClass="btn btn-sm btn-primary" ID="imgBuscar" runat="server" OnClick="imgBuscar_Click">
                                                    <i class="fa fa-search"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblNombre" runat="server" Text="Nombres"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtNombre" CssClass="form-control form-control-sm" runat="server" MaxLength="80" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblDirec" runat="server" Text="Dirección"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtDireccion" CssClass="form-control form-control-sm" runat="server" MaxLength="300" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblMedioPago" runat="server" Text="Medio Pago"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="ddlMedioPago" CssClass="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedioPago_SelectedIndexChanged">
                                            <asp:ListItem Value="EFECTIVO">Efectivo</asp:ListItem>
                                            <asp:ListItem Value="VISA">Visa</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblMontoxPagar" runat="server" Text="Monto por Pagar"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtMontoaPagar" CssClass="form-control form-control-sm" runat="server" MaxLength="11" Enabled="false" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblMontoEfectivo" runat="server" Text="Efectivo"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtEfectivo" CssClass="form-control form-control-sm" runat="server" MaxLength="11" onKeyPress="return soloNumerosPunto(event)" AutoPostBack="true" OnTextChanged="txtEfectivo_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-row mb-5">
                                    <div class="col-md-6">
                                        <asp:Label ID="lblMontoVuelto" runat="server" Text="Vuelto"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtVuelto" CssClass="form-control form-control-sm" runat="server" MaxLength="11" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton Style="border-radius: 15px;" CssClass="btn btn-outline-success btn-lg" ID="btnPagar" runat="server" Visible="true" OnClick="btnPagar_Click">
                                    <i class="fa fa-paper-plane" aria-hidden="true"></i>
                                    Enviar
                                        </asp:LinkButton>
                                        <asp:LinkButton Style="border-radius: 15px;" CssClass="btn btn-outline-danger btn-lg" ID="btnAnular" runat="server" Visible="false" OnClick="btnAnular_Click">
                                    <i class="fa fa-times-circle" aria-hidden="true"></i>
                                    Anular
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnReImpresion" runat="server" Text="Re-Imprimir" Visible="false" OnClick="btnReImpresion_Click">

                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="table-responsive shadow-lg bg-body rounded">
                                <asp:GridView ID="gdPedido" runat="server" CssClass="table table-sm table-hover table-bordered mb-0" AutoGenerateColumns="false" DataKeyNames="vchCodigo">
                                    <HeaderStyle CssClass="thead-dark" />
                                    <Columns>
                                        <asp:TemplateField HeaderText=""
                                            HeaderStyle-Font-Size="Small"
                                            HeaderStyle-Font-Bold="true"
                                            HeaderStyle-BackColor="#6d7fcc"
                                            ItemStyle-Width="160px">
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="ibtMenos" ImageUrl="images/menos.png"
                                                    Width="40px" Height="40px" ToolTip="Quitar Item"
                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex + "-" + Eval("vchCodigo")%>' CommandName="Menos"></asp:ImageButton>
                                                <asp:ImageButton runat="server" ID="ibtAnular" ImageUrl="images/anular.png"
                                                    Width="40px" Height="40px" ToolTip="Anular Item"
                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex + "-" + Eval("vchCodigo") %>' CommandName="Anular"></asp:ImageButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intCantidad" HeaderText="Cant."
                                            ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="vchDeItem"
                                            HeaderText="Desc." />
                                        <asp:BoundField DataField="numPrecioTot"
                                            HeaderText="P.T"
                                            ItemStyle-HorizontalAlign="Right" />
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
