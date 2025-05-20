<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmPedidoDetalle" CodeBehind="frmPedidoDetalle.aspx.cs" %>

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
    <style>
        .btn-secondary {
            color: #fff;
            background-color: #e2c275;
            border-color: #fff;
        }

            .btn-secondary:hover, .btn.btn-secondary:focus {
                color: #fff;
                background-color: #d9af4b;
                border-color: #d9af4b;
            }

            .btn-secondary:focus, .btn-secondary.focus {
                -webkit-box-shadow: 0 0 0 0.2rem rgba(226, 194, 117,0) !important;
                box-shadow: 0 0 0 0.2rem rgba(226, 194, 117, 0) !important;
            }

            .btn-secondary.disabled, .btn-secondary:disabled {
                color: #fff;
                background-color: #e2c275;
                border-color: #e2c275;
            }

            .btn-secondary:not(:disabled):not(.disabled):active, .btn-secondary:not(:disabled):not(.disabled).active,
            .show > .btn-secondary.dropdown-toggle {
                color: #fff;
                background-color: #e2c275;
                border-color: #e2c275;
            }

                .btn-secondary:not(:disabled):not(.disabled):active:focus, .btn-secondary:not(:disabled):not(.disabled).active:focus,
                .show > .btn-secondary.dropdown-toggle:focus {
                    -webkit-box-shadow: 0 0 0 0.2rem rgba(226, 194, 117, 0.5);
                    box-shadow: 0 0 0 0.2rem rgba(226, 194, 117, 0.5);
                }

        .btn-tertiary {
            color: #fff;
            background-color: #8bbabb;
            border-color: #fff;
        }

            .btn-tertiary:hover, .btn.btn-tertiary:focus {
                color: #fff;
                background-color: #6ba7a8;
                border-color: #6ba7a8;
            }

            .btn-tertiary:focus, .btn-tertiary.focus {
                -webkit-box-shadow: 0 0 0 0.2rem rgba(139, 186, 187,0) !important;
                box-shadow: 0 0 0 0.2rem rgba(139, 186, 187, 0) !important;
            }

            .btn-tertiary.disabled, .btn-tertiary:disabled {
                color: #fff;
                background-color: #8bbabb;
                border-color: #8bbabb;
            }

            .btn-tertiary:not(:disabled):not(.disabled):active, .btn-tertiary:not(:disabled):not(.disabled).active,
            .show > .btn-tertiary.dropdown-toggle {
                color: #fff;
                background-color: #8bbabb;
                border-color: #8bbabb;
            }

                .btn-tertiary:not(:disabled):not(.disabled):active:focus, .btn-tertiary:not(:disabled):not(.disabled).active:focus,
                .show > .btn-tertiary.dropdown-toggle:focus {
                    -webkit-box-shadow: 0 0 0 0.2rem rgba(139, 186, 187, 0.5);
                    box-shadow: 0 0 0 0.2rem rgba(139, 186, 187, 0.5);
                }

        .maxh {
            max-height: 500px;
        }

        #categoria > button, #subcategoria > button {
            font-size: x-small;
        }
    </style>
    <script>
        function seleccionarCategoria(categoria) {
            document.getElementById("Hcategoria").value = categoria;
            document.getElementById("<%=EventCategoria.ClientID%>").click();
        };
        function cargarHTMLsubCateg(html) {
            document.getElementById('subcategoria').innerHTML = html;
        }
        function seleccionarSubCategoria(subcategoria) {
            document.getElementById("HSubcategoria").value = subcategoria;
            document.getElementById("<%=EventSubCategoria.ClientID%>").click();
        };
        function AgregarEvento() {
            document.getElementById("<%=EventAgregar.ClientID%>").click();
        }
        function AgregarEvento2() {
            document.getElementById("<%=EventAgregar2.ClientID%>").click();
        }
        function ComentarioEvento() {
            document.getElementById("<%=EventComentario.ClientID%>").click();

        }
        function EnviarCocina() {
            document.getElementById("<%=Enviar.ClientID%>").click();
        }
        function PreCuenta() {
            document.getElementById("<%=Precuenta.ClientID%>").click();
        }
    </script>
    <script>
        function NoHayStock() {
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error('No hay Stock en el producto', 'Error');
        };
    </script>
    <script>
        function crearIframe(vchOrdenID, vchSalon, vchNumMesa) {

                // Crear el iframe dinámicamente
                const iframe = document.createElement('iframe');
            iframe.src = `TicketPreCuenta?vchOrdenID=${vchOrdenID}&vchSalon=${vchSalon}&vchNumMesa=${vchNumMesa}`     
                iframe.style.width = '100%';
                iframe.style.height = '500px';
                iframe.frameBorder = '0';

                // Agregar el iframe al div
                const diviframe = document.getElementById('diviframe');
                diviframe.innerHTML = ''; // Limpiar contenido previo, si es necesario
                diviframe.appendChild(iframe);

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container  ">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="frmMesas">Mesas</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Detalle Pedido</li>
                        </ol>
                    </nav>
                </div>
            </div>
            <div class="row mb-4 pb-3 pt-3">
                <div class="col-md-4 overflow-auto maxh">
                    <div class="form-row mb-1">
                        <div class="col-md-12">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <button type="button" runat="server" class="btn btn-sm btn-success btn-block " style="border-radius: 15px;" onclick="EnviarCocina();">
                                        <i class="fa fa-cutlery"></i>
                                        Enviar a cocina
                                    </button>
                                    <asp:Button Style="display: none;" ID="Enviar" runat="server" OnClick="Enviar_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="form-row mb-3">
                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UP5" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                            <button runat="server" onclick="PreCuenta();" type="button" class="btn btn-sm btn-warning btn-block" style="border-radius: 15px;">
                                <i class="fa fa-usd"></i>
                                Pre-cuenta
                            </button>
                                    <asp:Button Style="display: none;" runat="server" ID="Precuenta" OnClick="Precuenta_Click" />
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UP3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <div class="row justify-content-between">
                                <div class="col-md-6">
                                    <label class="p-1 font-weight-bold">Total:</label><label runat="server" id="lblValor" class="p-1 font-weight-bold bg-primary rounded text-white">S/. 0</label>
                                </div>
                                <div class="col-md-2">
                                    <asp:ImageButton ID="imgReImprimirComanda" runat="server" ImageUrl="~/images/arqueo.png" Width="35px" Height="35px" OnClick="imgReImprimirComanda_Click" />
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="gdPedido" runat="server" CssClass="table table-sm table-hover table-bordered" AutoGenerateColumns="false" OnRowCommand="gdPedido_RowCommand" OnRowDataBound="gdPedido_RowDataBound">
                                    <RowStyle CssClass="text-lowercase" />
                                    <HeaderStyle CssClass="table-secondary" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Opciones"
                                            HeaderStyle-Font-Size="Smaller"
                                            HeaderStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <div class="btn-group">
                                                    <asp:LinkButton CssClass="mr-1" runat="server" ID="ibtMas"
                                                        ToolTip="Aumentar Item" Style="color: lawngreen;"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex + "-" + Eval("vchCodigo")%>' CommandName="Mas"><i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                                                    <asp:LinkButton CssClass="mr-1" runat="server" ID="ibtMenos"
                                                        ToolTip="Quitar Item" Style="border-radius: 20px; color: red"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex + "-" + Eval("vchCodigo")%>' CommandName="Menos"><i class="fa fa-minus-circle" aria-hidden="true"></i></asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="ibtComentario"
                                                        ToolTip="Comentario"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex + "-" + Eval("vchCodigo") %>' CommandName="Comentario"><i class="fa fa-commenting-o" aria-hidden="true"></i></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intCantidad" HeaderText="Cant"
                                            HeaderStyle-Font-Size="Smaller"
                                            ItemStyle-Font-Size="X-Small"
                                            ItemStyle-CssClass="align-middle"
                                            ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Font-Bold="true" />
                                        <asp:BoundField DataField="vchDeItem"
                                            HeaderText="Producto"
                                            HeaderStyle-Font-Size="Smaller"
                                            ItemStyle-CssClass="text-break align-middle"
                                            ItemStyle-Font-Size="X-Small" />
                                        <asp:BoundField DataField="numPrecioTot"
                                            HeaderText="Precio"
                                            HeaderStyle-Font-Size="Smaller"
                                            ItemStyle-Font-Size="X-Small"
                                            ItemStyle-CssClass="align-middle"
                                            ItemStyle-HorizontalAlign="Right" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEnviado" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="EventAgregar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-8 border-info border-left maxh overflow-auto shadow-lg bg-body" style="background-color: #e9ecef; border-radius: 20px;">
                    <div class="row mb-4 border-bottom border-info">
                        <div class="col-md-12 d-flex justify-content-center">
                            <asp:Label runat="server" CssClass="h2">Seleccionar Productos</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-7">
                            <div class="row mb-4">
                                <div class="col-md-12">
                                    <div id="categoria" class="btn-group w-100 mb-2 mb-md-0 btn-block flex-wrap text-break" role="group" aria-label="Button group with nested dropdown">
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UP1" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <div class="row mb-2">
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <label runat="server" id="NombCat" class="h2"></label>
                                        </div>
                                    </div>
                                    <div class="row mb-5">
                                        <div class="col-md-12">
                                            <div id="subcategoria" class="btn-group w-100 mb-2 mb-md-0 btn-block flex-wrap text-break" role="group" aria-label="Button group with nested dropdown">
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="EventCategoria" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-5">
                            <div class="form-row mb-1 ">
                                <div class="col-md-12">
                                    <div class="input-group">
                                        <input id="txtBusqueda" runat="server" type="text" placeholder="Buscar" class="form-control form-control-sm" />
                                        <div class="input-group-append">
                                            <asp:LinkButton runat="server" ID="btnbuscar" type="submit" class="btn btn-sm btn-primary" OnClick="btnbuscar_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UP2" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <div class="table-responsive">
                                        <asp:GridView ID="gdCartaProductos" runat="server" AutoGenerateColumns="false" OnRowCommand="gdCartaProductos_RowCommand"
                                            CssClass="table table-sm table-hover table-bordered" OnDataBound="gdCartaProductos_DataBound" ShowHeaderWhenEmpty="true" EmptyDataText="Sin registro de pedidos">
                                            <HeaderStyle CssClass="thead-dark" />
                                            <RowStyle CssClass="text-lowercase" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Opc"
                                                    HeaderStyle-Font-Size="Smaller"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="ibtAgregar" Style="border-radius: 20px;"
                                                            ToolTip="Agregar Item" CssClass="btn-sm btn-info"
                                                            CommandArgument='<%# ((GridViewRow) Container).RowIndex + "-" + Eval("vchCodigo") %>'
                                                            CommandName="Agregar"><i class="fa fa-shopping-cart" aria-hidden="true"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="vchDeItem"
                                                    HeaderText="Producto"
                                                    HeaderStyle-Font-Size="Smaller"
                                                    ItemStyle-CssClass="text-break align-middle"
                                                    ItemStyle-Font-Size="X-Small" />
                                                <asp:BoundField DataField="stock"
                                                    HeaderText="Stock"
                                                    HeaderStyle-Font-Size="Smaller"
                                                    ItemStyle-CssClass="align-middle"
                                                    ItemStyle-Font-Size="X-Small" />
                                                <asp:BoundField DataField="numPrecioUni"
                                                    HeaderText="P.U."
                                                    HeaderStyle-Font-Size="Smaller"
                                                    ItemStyle-Font-Size="X-Small"
                                                    ItemStyle-CssClass="align-middle"
                                                    ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="vchCodigo"
                                                    HeaderText="Cod. Prod"
                                                    HeaderStyle-Font-Size="Smaller"
                                                    ItemStyle-CssClass="align-middle"
                                                    ItemStyle-Font-Size="X-Small" />
                                                <asp:BoundField DataField="Categoria"
                                                    HeaderText="Categoria"
                                                    HeaderStyle-Font-Size="Smaller"
                                                    ItemStyle-CssClass="align-middle"
                                                    ItemStyle-Font-Size="X-Small" />
                                                <asp:BoundField DataField="SubCategoria"
                                                    HeaderText="SubCategoria"
                                                    HeaderStyle-Font-Size="Smaller"
                                                    ItemStyle-CssClass="align-middle"
                                                    ItemStyle-Font-Size="X-Small" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
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
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="EventSubCategoria" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnbuscar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="EventAgregar2" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="mymodal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel1" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel ID="UP4" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="myLargeModalLabel1">Agregar Comentario</h4>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>

                            <div class="modal-body">
                                <div class="form-row">
                                    <div class="col-md-12 mb-3">
                                        <label for="<%=txtObservacion.ClientID %>">Observación<b>(*)</b></label>
                                        <textarea runat="server" class="form-control" id="txtObservacion"></textarea>
                                    </div>
                                </div>
                                <div class="form-row justify-content-end">
                                    <div class="col-md-3">
                                        <asp:LinkButton ID="btnguardar" CssClass="btn btn-success" runat="server" Style="border-radius: 15px;" OnClick="btnguardar_Click1">
                                Guardar 
                                <i class="fa fa-save"  ></i>
                                        </asp:LinkButton>

                                    </div>
                                    <div class="col-md-3">
                                        <button type="button" data-dismiss="modal" class="btn btn-danger" style="border-radius: 15px;">Cancelar <i class="fa fa-times-circle"></i></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="EventComentario" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        
                        <div class="modal fade" id="pdfModal" tabindex="-1" aria-labelledby="pdfModalLabel"  data-keyboard="false" aria-hidden="true">
                    <div class="modal-dialog modal-md">
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="pdfModalLabel">Vista previa de la Pre-Cuenta</h5>
                            </div>
                            <div  id="diviframe" class="modal-body">
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <button data-dismiss="modal"  style="border-radius: 15px;" class="btn btn-secondary">
                                            Cerrar
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                         </ContentTemplate>
        </asp:UpdatePanel>
                    </div>
                </div>
                   
        <input type="hidden" id="ope" name="ope" />
        <input type="hidden" id="HSubcategoria" name="HSubcategoria" />
        <input type="hidden" id="Hcategoria" name="Hcategoria" />
        <asp:Button Style="display: none;" runat="server" ID="EventCategoria" OnClick="EventCategoria_Click" />
        <asp:Button Style="display: none;" runat="server" ID="EventSubCategoria" OnClick="EventSubCategoria_Click" />
        <asp:Button Style="display: none;" runat="server" ID="EventAgregar" />
        
        <asp:Button Style="display: none;" runat="server" ID="EventAgregar2" />
        <asp:Button Style="display: none;" runat="server" ID="EventComentario" OnClick="EventComentario_Click" />
         
    </form>
</asp:Content>
