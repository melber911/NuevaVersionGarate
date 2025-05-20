<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="frmReporteProductosDetallados.aspx.cs" Inherits="WebSites.frmReporteProductosDetallados" %>

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
            width: 49px;
        }

        .auto-style2 {
            width: 23px;
        }

        .auto-style3 {
            width: 33px;
        }

        .header {
            background-color: #000;
            font-family: Arial;
            color: White;
            height: 25px;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            text-align: left;
        }

            .rows:hover {
                background-color: #5badff;
                color: #fff;
            }

        .auto-style4 {
            height: 34px;
        }

        .auto-style5 {
            width: 49px;
            height: 34px;
        }

        .pager {
            background-color: #fff;
            font-family: Arial;
            height: 30px;
            text-align: left;
            font-weight: bold;
        }

            .pager table {
                justify-content: center;
                align-items: center;
            }

        .auto-style6 {
            width: 23px;
            height: 34px;
        }

        .auto-style7 {
            width: 33px;
            height: 34px;
        }

        #overlay {
            position: fixed;
            z-index: 99;
            top: 160px;
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
    <script>
        function generar() {
            document.getElementById("<%=btnBuscar.ClientID %>").click();
        }
        function regresar() {
            document.getElementById("<%=btnRegresar.ClientID %>").click();
        }
        function descargar() {
            document.getElementById("<%=imgExcelDescarga1.ClientID %>").click();
        }
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
                        <div class="col-12">
                            <h2>Reporte de Productos Detallados</h2>
                        </div>
                    </div>
                    <div class="form-row mb-1">
                        <div class="col-md-4 mb-1">
                            <div class="input-group">
                                <span class="input-group-text">Fecha Inicio</span>
                                <div class="input-group-append">
                                    <input class="form-control" type="date" id="datepicker3" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 mb-1">
                            <div class="input-group">
                                <span class="input-group-text">Fecha Fin</span>
                                <div class="input-group-append">
                                    <input class="form-control" type="date" id="datepicker4" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 mb-1 d-flex justify-content-end">
                            <asp:Button Style="display: none;" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" Text="Generar" CssClass="btn btn-primary" />
                            <button style="border-radius: 15px;" type="button" runat="server" title="Generar" id="Bgen" onclick="generar();" class="btn btn-outline-primary mr-2">
                                <i class="fa fa-circle-o-notch" aria-hidden="true"></i>
                                Generar
                            </button>
                            <asp:Button Style="display: none;" runat="server" ID="btnRegresar" OnClick="btnRegresar_Click" Text="Regresar" CssClass="btn btn-danger" />
                            <button style="border-radius: 15px;" visible="false" title="repetir busqueda" type="button" runat="server" id="Breg" onclick="regresar();" class="btn btn-outline-danger mr-2">
                                <i class="fa fa-undo" aria-hidden="true"></i>
                                Repetir
                            </button>
                            <asp:Button Style="display: none;" runat="server" ID="imgExcelDescarga1" OnClick="imgExcelDescarga1_Click" ToolTip="Descargar en formato EXCEL" CssClass="btn btn-outline-success" />
                            <button style="border-radius: 15px;" visible="false" class="btn btn-outline-success align-middle" onclick="descargar();" title="Descargar en formato EXCEL" type="button" runat="server" id="Bdes">
                                <i class="fa fa-download" aria-hidden="true"></i>-<i class="fa fa-file-excel-o" aria-hidden="true"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="table-responsive shadow-lg bg-body rounded">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-sm table-hover table-bordered mb-0"
                        PagerStyle-CssClass="pager" PageSize="6" AllowPaging="true" OnPreRender="GridView1_PreRender"
                        OnPageIndexChanging="GridView1_PageIndexChanging" ShowHeaderWhenEmpty="true" EmptyDataText="Sin registros">
                        <HeaderStyle CssClass="thead-dark" />
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                            <asp:BoundField HeaderText="Producto Codigo" DataField="ProductoCodigo" />
                            <asp:BoundField HeaderText="Producto Nombre" DataField="ProductoNombre" />
                            <asp:BoundField HeaderText="Cantidad Vendidos" DataField="Cantidad_Vendidos" />
                            <asp:BoundField HeaderText="Precio Unitario" DataField="Precio_Unitario" />
                            <asp:BoundField HeaderText="Total Vendido" DataField="Total_Vendido" />
                        </Columns>
                        <PagerSettings PageButtonCount="4" FirstPageText="Primero" LastPageText="Ultimo" Mode="NumericFirstLast" />
                        <PagerStyle CssClass="pager"></PagerStyle>
                    </asp:GridView>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true">
                    </asp:GridView>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="imgExcelDescarga1" />
            </Triggers>
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
