<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmGenComprobPago" CodeBehind="frmGenComprobPago.aspx.cs" %>

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
            window.showModalDialog("https://www.youtube.com");
        }

        document.addEventListener('DOMContentLoaded', function () {
            // Función para calcular totales
            window.calcularTotales = function () {
                const chkEfectivo = document.getElementById('<%=chkEfectivo.ClientID%>');
                const txtmontoEfectivo = document.getElementById('<%=txtmontoEfectivo.ClientID%>');

                const chkVisa = document.getElementById('<%=chkVisa.ClientID%>');
                const txtmontoVisa = document.getElementById('<%=txtmontoVisa.ClientID%>');

                const chkYape = document.getElementById('<%=chkYape.ClientID%>');
                const txtmontoYape = document.getElementById('<%=txtmontoYape.ClientID%>');

                const txtMontoaPagar = document.getElementById('<%=txtMontoaPagar.ClientID%>');
                const txtEfectivo = document.getElementById('<%=txtEfectivo.ClientID%>');
                const txtVuelto = document.getElementById('<%=txtVuelto.ClientID%>');

                let totalRecibido = 0;

                if (chkEfectivo && chkEfectivo.checked) {
                    totalRecibido += parseFloat(txtmontoEfectivo.value) || 0;
                }
                if (chkVisa && chkVisa.checked) {
                    totalRecibido += parseFloat(txtmontoVisa.value) || 0;
                }
                if (chkYape && chkYape.checked) {
                    totalRecibido += parseFloat(txtmontoYape.value) || 0;
                }

                if (txtEfectivo) {
                    txtEfectivo.value = totalRecibido.toFixed(2);
                }

                const montoPagar = parseFloat(txtMontoaPagar?.value) || 0;
                const vuelto = totalRecibido - montoPagar;

                if (txtVuelto) {
                    txtVuelto.value = vuelto >= 0 ? vuelto.toFixed(2) : '0.00';
                }
            };

            // Función para habilitar campos y vaciar contenido al deshabilitar
            window.habilitarEfectivo = function (checkbox) {
                const txtmontoEfectivo = document.getElementById('<%=txtmontoEfectivo.ClientID%>');
                if (txtmontoEfectivo) {
                    txtmontoEfectivo.disabled = !checkbox.checked;
                    if (!checkbox.checked) {
                        txtmontoEfectivo.value = '';
                    }
                }
                calcularTotales();
            };

            window.habilitarVisa = function (checkbox) {
                const txtmontoVisa = document.getElementById('<%=txtmontoVisa.ClientID%>');
                if (txtmontoVisa) {
                    txtmontoVisa.disabled = !checkbox.checked;
                    if (!checkbox.checked) {
                        txtmontoVisa.value = '';
                    }
                }
                calcularTotales();
            };

            window.habilitarYape = function (checkbox) {
                const txtmontoYape = document.getElementById('<%=txtmontoYape.ClientID%>');
                if (txtmontoYape) {
                    txtmontoYape.disabled = !checkbox.checked;
                    if (!checkbox.checked) {
                        txtmontoYape.value = '';
                    }
                }
                calcularTotales();
            };

            // Escuchar los cambios en los campos de texto y recalcular
            document.getElementById('<%=txtmontoEfectivo.ClientID%>')?.addEventListener('input', calcularTotales);
            document.getElementById('<%=txtmontoVisa.ClientID%>')?.addEventListener('input', calcularTotales);
            document.getElementById('<%=txtmontoYape.ClientID%>')?.addEventListener('input', calcularTotales);
            document.getElementById('<%=txtMontoaPagar.ClientID%>')?.addEventListener('input', calcularTotales);
        });


    </script>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            function inicializarEventos() {
                const txtmontoEfectivo = document.getElementById('<%=txtmontoEfectivo.ClientID%>');
                const txtmontoVisa = document.getElementById('<%=txtmontoVisa.ClientID%>');
                const txtmontoYape = document.getElementById('<%=txtmontoYape.ClientID%>');
                const txtMontoaPagar = document.getElementById('<%=txtMontoaPagar.ClientID%>');

                if (txtmontoEfectivo) {
                    txtmontoEfectivo.addEventListener('input', calcularTotales);
                }
                if (txtmontoVisa) {
                    txtmontoVisa.addEventListener('input', calcularTotales);
                }
                if (txtmontoYape) {
                    txtmontoYape.addEventListener('input', calcularTotales);
                }
                if (txtMontoaPagar) {
                    txtMontoaPagar.addEventListener('input', calcularTotales);
                }
            }

            // Registrar eventos iniciales
            inicializarEventos();

            // Re-registrar eventos después de cada postback parcial
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                inicializarEventos();
            });
        });
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
                                    <% string url = "";
                                        if (Request.QueryString["vchEstado"].ToString().Equals("PAGADO")) url = "<a href='frmListadoPedidosxPagar'>Lista</a>";
                                        else url = "<a href='frmListadoMesasPagar'>Pagar</a>"; %>
                                    <li class="breadcrumb-item"><%= url %></li>
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
                                        <label id="lblinfoDoc" visible="false" runat="server">#Documento</label>
                                    </div>
                                    <div class="col-md-6 ">
                                        <input type="text" visible="false" class="form-control form-control-sm" disabled="disabled" runat="server" id="txtNumDoc" />
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <label id="lblTipDoc" runat="server">Tipo de Documento:</label>
                                    </div>
                                    <div class="col-md-6 ">
                                        <asp:DropDownList ID="ddlComprob" runat="server" CssClass="form-control form-control-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlComprob_SelectedIndexChanged">
                                            <asp:ListItem Value="BOL">BOLETA</asp:ListItem>
                                            <asp:ListItem Value="FAC">FACTURA</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-12">
                                        <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                            <input runat="server" class="custom-control-input" type="checkbox" id="chkEnviar" checked />
                                            <label class="custom-control-label" for="<%=chkEnviar.ClientID %>">Generar Comprobante</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <label id="lblRuc" runat="server">DNI:</label>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="input-group">
                                            <input runat="server" type="text" class="form-control form-control-sm" id="txtRuc" placeholder="" maxlength="100" />
                                            <div class="input-group-append">
                                                <asp:LinkButton CssClass="btn btn-sm btn-primary" ID="imgBuscar" runat="server" OnClick="imgBuscar_Click1">
                                                    <i class="fa fa-search"></i>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <label id="lblNombre" runat="server">Nombres:</label>
                                    </div>
                                    <div class="col-md-6">
                                        <input runat="server" type="text" class="form-control form-control-sm" id="txtNombre" placeholder="" maxlength="100" />
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <label id="lblDirec" runat="server">Dirección:</label>
                                    </div>
                                    <div class="col-md-6">
                                        <input runat="server" type="text" class="form-control form-control-sm" id="txtDireccion" placeholder="" maxlength="50" />
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <label id="lblCorreo" runat="server">Correo:</label>
                                    </div>
                                    <div class="col-md-6">
                                        <input runat="server" type="text" class="form-control form-control-sm" id="txtCorreo" placeholder="" maxlength="50" />
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <label id="lblMontoxPagar" runat="server">Monto por Pagar:</label>
                                    </div>
                                    <div class="col-md-6">
                                        <input runat="server" type="text" class="form-control form-control-sm" id="txtMontoaPagar" onkeypress="return soloNumeros(event)" placeholder="" maxlength="11" />
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                            <input runat="server" class="custom-control-input" type="checkbox" id="chkEfectivo" checked
                                                onclick="habilitarEfectivo(this)" />
                                            <label class="custom-control-label" for="<%=chkEfectivo.ClientID %>">Monto Efectivo &nbsp;</label><img src="images/efectivo.png" alt="Efectivo" width="25">
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <input runat="server" type="text" class="form-control form-control-sm" id="txtmontoEfectivo"
                                            onkeypress="return soloNumerosPunto(event)"
                                            placeholder="" maxlength="11" />
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                            <input runat="server" class="custom-control-input" type="checkbox" id="chkVisa"
                                                onclick="habilitarVisa(this)" />
                                            <label class="custom-control-label" for="<%=chkVisa.ClientID %>">Monto Tarjeta &nbsp;</label><img src="images/visa.png" alt="Visa" width="25">
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <input runat="server" type="text" class="form-control form-control-sm" id="txtmontoVisa" onkeypress="return soloNumerosPunto(event)" placeholder="" maxlength="11" />

                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                            <input runat="server" class="custom-control-input" type="checkbox" id="chkYape"
                                                onclick="habilitarYape(this)" />
                                            <label class="custom-control-label" for="<%=chkYape.ClientID %>">Monto Yape/Plin &nbsp;</label><img src="images/yape.png" alt="Yape" width="25"><img src="images/Plin.png" alt="Plin" width="25">
                                        </div>
                                        
                                    </div>
                                    <div class="col-md-6">
                                        <input runat="server" type="text" class="form-control form-control-sm" id="txtmontoYape" onkeypress="return soloNumerosPunto(event)" placeholder="" maxlength="11" />
                                    </div>
                                </div>
                                <div class="form-row mb-2">
                                    <div class="col-md-6">
                                        <label id="lblMontoEfectivo" runat="server">Monto Total Recibido:</label>
                                    </div>
                                    <div class="col-md-6">
                                        <input runat="server" disabled type="text" class="form-control form-control-sm" id="txtEfectivo" onkeypress="return soloNumerosPunto(event)" placeholder="" maxlength="11" />
                                    </div>
                                </div>
                                <div class="form-row mb-5">
                                    <div class="col-md-6">
                                        <label id="lblMontoVuelto" runat="server">Vuelto:</label>
                                    </div>
                                    <div class="col-md-6">
                                        <input runat="server" type="text" class="form-control form-control-sm" disabled="disabled" id="txtVuelto" placeholder="" maxlength="100" />
                                        <asp:DropDownList ID="ddlTipoVuelto" runat="server" CssClass="form-control form-control-sm" >
                                            <asp:ListItem Value="EFECTIVO">EFECTIVO</asp:ListItem>
                                            <asp:ListItem Value="DEPOSITO">DEPOSITO/YAPE</asp:ListItem>
                                            <asp:ListItem Value="TARJETA">TARJETA</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row mb-2">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:Button ID="btnReImpresion" runat="server" Text="Re-Imprimir" Visible="false" OnClick="btnReImpresion_Click" />
                                        <asp:LinkButton CssClass="btn btn-lg btn-outline-danger mr-2" Style="border-radius: 15px;" ID="btnAnular" runat="server" Visible="false" OnClick="btnAnular_Click">
                                        <i class="fa fa-times-circle" aria-hidden="true"></i>
                                        Anular
                                        </asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-lg btn-outline-success mr-2" Style="border-radius: 15px;" ID="btnPagar" runat="server" Visible="true" OnClick="btnPagar_Click" OnClientClick="this.disabled=true;" UseSubmitBehavior="false">
                                        <i class="fa fa-money" aria-hidden="true"></i>
                                        Pagar
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnDivirCuenta" Style="border-radius: 15px;" class="btn btn-lg btn-outline-primary" runat="server" OnClick="btnDivirCuenta_Click">
                                        <i class="fa fa-scissors" aria-hidden="true"></i>
                                        Dividir Cuentas
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-6">
                            <div class="table-responsive shadow-lg bg-body rounded">
                                <asp:GridView ID="gdPedido" CssClass="table table-sm table-hover table-bordered mb-0" runat="server" AutoGenerateColumns="false" DataKeyNames="vchCodigo">
                                    <HeaderStyle CssClass="thead-dark" />
                                    <Columns>
                                        <asp:TemplateField HeaderText=""
                                            HeaderStyle-Font-Size="Small"
                                            HeaderStyle-Font-Bold="true"
                                            HeaderStyle-BackColor="#6d7fcc"
                                            ItemStyle-Width="160px">
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="ibtMenos"
                                                    Width="40px" Height="40px" ToolTip="Quitar Item"
                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex + "-" + Eval("vchCodigo")%>' CommandName="Menos"></asp:ImageButton>
                                                <asp:ImageButton runat="server" ID="ibtAnular"
                                                    Width="40px" Height="40px" ToolTip="Anular Item"
                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex + "-" + Eval("vchCodigo") %>' CommandName="Anular"></asp:ImageButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intCantidad" HeaderText="Cant."
                                            ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-CssClass="align-middle" />
                                        <asp:BoundField DataField="vchDeItem"
                                            HeaderText="Desc."
                                            ItemStyle-CssClass="text-break align-middle" />
                                        <asp:BoundField DataField="numPrecioTot"
                                            HeaderText="P.T"
                                            ItemStyle-CssClass="align-middle"
                                            ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-ForeColor="White" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="pdfModal" tabindex="-1" aria-labelledby="pdfModalLabel" data-backdrop="static" data-keyboard="false" aria-hidden="true">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="pdfModalLabel">Vista previa de la boleta</h5>
                            </div>
                            <div class="modal-body">
                                <iframe runat="server" id="ifrpdf"
                                    style="width: 100%; height: 500px;" frameborder="0"></iframe>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="BtnCerrar" CssClass="btn btn-secondary" runat="server" OnClick="BtnCerrar_Click" Style="border-radius: 15px;">
                                            
                                            cerrar
                                        </asp:LinkButton>
                                    </div>
                                </div>
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
