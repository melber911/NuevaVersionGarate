<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" Inherits="frmListadoCajasAperturadas" CodeBehind="frmListadoCajasAperturadas.aspx.cs" %>

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
        .auto-style1 {
            width: 409px;
            height: 55px;
        }

        .auto-style2 {
            height: 55px;
        }

        .imgAgregar {
            border-radius: 15px;
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
    </script>
    <script>
        function confirmarGuardar() {
            swal({
                title: '¿Estás seguro?',
                text: "No podrás revertir esta acción.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sí, cerrar caja',
                cancelButtonText: 'Cancelar'
            }, function (isConfirm) {
                if (isConfirm) {
                    // Si el usuario confirma, ejecuta el evento del servidor
                    __doPostBack('<%= BtnGuardar2.UniqueID %>', '');
                }
            })
        }
        function verdetalle() {
            document.getElementById("<%=EventDetalle.ClientID%>").click();
        }
        function crearIframe() {
            // Obtener el valor de MovCajaID desde algún elemento o variable
            const movCajaID = document.getElementById("<%=hdMesaId.ClientID%>").value 

            if (movCajaID) {
                // Crear el iframe dinámicamente
                const iframe = document.createElement('iframe');
                iframe.src = `DailySalesReport?CajaId=${movCajaID}`;
                iframe.style.width = '100%';
                iframe.style.height = '500px';
                iframe.frameBorder = '0';

                // Agregar el iframe al div
                const diviframe = document.getElementById('diviframe');
                diviframe.innerHTML = ''; // Limpiar contenido previo, si es necesario
                diviframe.appendChild(iframe);
            } else {
                console.error("El valor de MovCajaID está vacío o no definido.");
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
            <div class="row mb-4">
                <div class="col-md-6">
                    <h2>Listado de Cajas Aperturadas</h2>
                </div>
                <div class="col-md-6 d-flex justify-content-end">
                    <button title="Aperturar Caja" type="button" class="btn btn-info" style="border-radius: 15px;" data-toggle="modal" data-target="#mymodal">
                        <i class="fa fa-plus-circle"></i>
                        Agregar Caja
                    </button>
                </div>
            </div>
        </div>
        <div class="table-responsive shadow-lg bg-body rounded">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron cajas aperturadas" CssClass="table table-hover table-bordered mb-0" ID="gdCajasTurno" runat="server"
                        AutoGenerateColumns="false" OnRowCommand="gdCajasTurno_RowCommand" OnRowDataBound="gdCajasTurno_RowDataBound">
                        <HeaderStyle CssClass="thead-dark" />
                        <Columns>
                            <asp:TemplateField HeaderText="#"
                                ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField
                                HeaderText="Estado"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle">
                                <ItemTemplate>
                                    <%#  Eval("cajaEstado").ToString() == "ABIERTO" ?
                                        "<span class='label label-sm label-success'>ABIERTO</span>" :
                                        "<span class='label label-sm label-danger'>CERRADO</span>"%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="cajaNombre"
                                HeaderText="Caja"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle" />
                            <asp:BoundField DataField="movTurnoId"
                                HeaderText="Turno"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle" />
                            <asp:BoundField DataField="fecApertura"
                                HeaderText="Fecha Apertura"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle" />
                            <asp:BoundField DataField="Uname"
                                HeaderText="Cajero"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle" />
                            <asp:BoundField DataField="movCajaMontoIni"
                                HeaderText="Monto Inicio"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle" />
                            <asp:BoundField DataField="movCajaUsuAper"
                                HeaderText="Usuario Apertura"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle" />
                            <asp:TemplateField HeaderText="Detalle"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="ibtDetalle" CssClass="btn"
                                        ToolTip="Detalle"
                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex + "|" + Eval("movCajaID")%>'
                                        CommandName="Detalle"><i style="color:#17a2b8;" class="fa fa-search"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Otros Ingresos"
                                ItemStyle-HorizontalAlign="Center"
                                ItemStyle-CssClass="align-middle"
                                ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton  runat="server" ID="ibtIngreso" CssClass="btn"
                                        ToolTip="Otros Ingresos"
                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex + "|" + Eval("movCajaID")%>'
                                        CommandName="Ingresos"><i  class="fa fa-list-alt "></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div id="mymodal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel3" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel3">Aperturar Caja</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=ddlCaja.ClientID %>">Caja<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="ddlCaja" CssClass="form-control">
                                            <asp:ListItem Text="Seleccione.." Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=ddlUsuario.ClientID %>">Cajero<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="ddlUsuario" CssClass="form-control">
                                            <asp:ListItem Text="Seleccione.." Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=lblFechaAper.ClientID %>">Fecha Apertura<b>(*)</b></label>
                                        <input runat="server" type="date" class="form-control" id="lblFechaAper" disabled="" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=ddlTurno.ClientID %>">Turno<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="ddlTurno" CssClass="form-control">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtMontoInicio.ClientID %>">Monto Inicio<b>(*)</b></label>
                                        <input onkeypress="return soloNumerosPunto(event)" runat="server" type="text" class="form-control" id="txtMontoInicio" />
                                    </div>
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
        <div id="mymodal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel ID="UP2" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="modal-content ">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel">Detalle Caja</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=ddlCaja2.ClientID %>">Caja<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="ddlCaja2" CssClass="form-control" Enabled="false">
                                            <asp:ListItem Text="Seleccione.." Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=ddlUsuario2.ClientID %>">Cajero<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="ddlUsuario2" CssClass="form-control">
                                            <asp:ListItem Text="Seleccione.." Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=lblFechaAper2.ClientID %>">Fecha Apertura<b>(*)</b></label>
                                        <input runat="server" type="date" class="form-control" id="lblFechaAper2" disabled="" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=ddlTurno2.ClientID %>">Turno<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="ddlTurno2" CssClass="form-control" Enabled="false">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtMontoInicio2.ClientID %>">Monto Inicio<b>(*)</b></label>
                                        <input onkeypress="return soloNumerosPunto(event)" runat="server" type="text" class="form-control" id="txtMontoInicio2" disabled="" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label>Estado<b>(*)</b></label><br />
                                        <asp:Label ID="lblEstado" runat="server" Text="" Font-Size="18px" Font-Bold="true" ForeColor="Green"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label >Total Efectivo<b>(*)</b></label>
                                        <input onkeypress="return soloNumerosPunto(event)" runat="server" type="text" class="form-control" id="txtefectivoTotal"  />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label >Total Deposito/Yape<b>(*)</b></label>
                                        <input onkeypress="return soloNumerosPunto(event)" runat="server" type="text" class="form-control" id="txtDepositoTotal"  />
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label >Total Tarjeta<b>(*)</b></label>
                                        <input onkeypress="return soloNumerosPunto(event)" runat="server" type="text" class="form-control" id="txtTarjetaTotal"  />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="btnArqueo" CssClass="btn btn-warning mr-3" runat="server" OnClick="btnArqueo_Click" Style="border-radius: 15px;">
                                            <i class="fa fa-usd"></i>
                                            Arqueo 
                                        </asp:LinkButton>
                                        <asp:LinkButton OnClientClick="confirmarGuardar(); return false;" ID="BtnGuardar2" CssClass="btn btn-success" runat="server" OnClick="BtnGuardar2_Click" Style="border-radius: 15px;">
                                            <i class="fa fa-save"></i>
                                            Cerrar Caja 
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hdMesaId" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="EventDetalle" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="modal fade" id="pdfModal" tabindex="-1" aria-labelledby="pdfModalLabel" data-backdrop="static" data-keyboard="false" aria-hidden="true">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="pdfModalLabel">Vista previa de la boleta</h5>
                            </div>
                            <div  id="diviframe" class="modal-body">
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="BtnCerrar" OnClick="BtnCerrar_Click" CssClass="btn btn-secondary" runat="server"  Style="border-radius: 15px;">
                                            Cerrar
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                    </ContentTemplate>
        </asp:UpdatePanel>
        
        <asp:Button Style="display: none;" runat="server" ID="EventDetalle" OnClick="EventDetalle_Click" />
    </form>
</asp:Content>
