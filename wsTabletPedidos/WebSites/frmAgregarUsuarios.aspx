<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="frmAgregarUsuarios.aspx.cs" Inherits="WebSites.frmAgregarUsuarios" %>

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
        a.label:focus, a.label:hover {
            color: #fff;
            text-decoration: none;
            cursor: pointer
        }

        .label:empty {
            display: none
        }

        .btn .label {
            position: relative;
            top: -1px
        }



        .badge {
            display: inline-block;
            min-width: 10px;
            padding: 3px 7px;
            font-size: 12px;
            font-weight: 700;
            line-height: 1;
            color: #fff;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            background-color: #777;
            border-radius: 10px
        }

            .badge:empty {
                display: none
            }

        .btn .badge {
            position: relative;
            top: -1px
        }

        .btn-group-xs > .btn .badge, .btn-xs .badge {
            top: 0;
            padding: 1px 5px
        }

        a.badge:focus, a.badge:hover {
            color: #fff;
            text-decoration: none;
            cursor: pointer
        }

        .mydatagrid {
            border: solid 2px black;
            min-width: 80%;
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

        .mydatagrid a /** FOR THE PAGING ICONS  **/ {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/ {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #fff;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        

        .mydatagrid td {
            padding: 5px;
        }

        .mydatagrid th {
            padding: 5px;
        }

        .auto-style4 {
            width: 214px;
            height: 34px;
        }

        .auto-style5 {
            width: 22px;
            height: 34px;
        }

        .auto-style6 {
            height: 34px;
        }

        .auto-style7 {
            height: 34px;
            width: 178px;
        }

        .auto-style8 {
            width: 91px;
        }

        .auto-style9 {
            height: 34px;
            width: 96px;
        }

        .auto-style10 {
            width: 96px;
        }

        .auto-style11 {
            width: 347px;
        }

        .auto-style12 {
            width: 411px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form name="registration" autocomplete="off" id="form1" runat="server" class="needs-validation" novalidate>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
                    <div class="form-row mb-5" id="newbotton">
                        <div class="col-md-8">
                            <h2 style="text-align: left;">Listado de Usuarios</h2>
                        </div>
                        <div class="col-md-4 d-flex justify-content-end">
                            <button id="BtnNuevo" type="button" data-target="#mymodal2" data-toggle="modal" style="border-radius: 15px;" class="btn btn-info">
                                <i class="fa fa-plus-circle"></i>
                                Agregar Usuario
                            </button>
                        </div>
                    </div>
                    <div class="form-row mb-1">
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="NombreProductoFiltroID" type="text" placeholder="Buscar usuario" class="form-control" />
                                <div class="input-group-append">
                                    <asp:Button Style="display: none;" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" Text="Buscar" CssClass="btn btn-primary" />
                                    <button type="button" class="btn btn-primary" onclick="document.getElementById('<%=btnBuscar.ClientID%>').click();"><i class="fa fa-search"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="table-responsive shadow-lg bg-body rounded">
                    <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-sm table-hover table-bordered mb-0" AutoGenerateColumns="false"
                        PagerStyle-CssClass="pager" AllowSorting="true" AllowPaging="true" PageSize="5"
                        OnPageIndexChanging="gvUsuarios_PageIndexChanging" OnRowCommand="gvUsuarios_RowCommand"
                        ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron usuarios">
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
                            <asp:BoundField HeaderText="NombreUsuario" DataField="username" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center"/>
                            <asp:TemplateField HeaderText="Nombre y apellido" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%#  Eval("nombres").ToString() +" "+ Eval("apellidos").ToString()  %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Rol" DataField="nombrerol" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="Estado" ItemStyle-CssClass="align-middle"  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%#  Eval("estado").ToString() == "1" ?
                                        "<span class='label label-sm label-success'> ACTIVADO</span>" :
                                        "<span class='label label-sm label-danger'> DESACTIVADO</span>"%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-CssClass="align-middle" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditar" runat="server" CommandName="editar" CommandArgument='<%# Eval("empid")%>'>
                                                <span class="fa fa-edit" style="font-size:25px; cursor: pointer;color:black;" title="Editar"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings PageButtonCount="4" FirstPageText="Primero" LastPageText="Ultimo" Mode="NumericFirstLast" />
                    </asp:GridView>
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
        <div class="modal fade" id="mymodal2" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel">Agregar Usuario</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtnombres.ClientID %>">Nombres<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtnombres" placeholder="Full name" maxlength="100" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtapellidos.ClientID %>">Apellidos<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtapellidos" placeholder="Full surname" maxlength="100" />
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=DdlRol.ClientID %>">Rol<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="DdlRol" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DdlRol_SelectedIndexChanged">
                                            <asp:ListItem Text="Seleccione.." Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label>Estado<b>(*)</b></label>
                                        <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                            <input runat="server" class="custom-control-input" type="checkbox" id="ChkEstado" checked />
                                            <label class="custom-control-label" for="<%=ChkEstado.ClientID %>">Activo</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtuser.ClientID %>">Nombre de Usuario<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtuser" placeholder="username" maxlength="50" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtpass.ClientID %>">Contraseña<b>(*)</b></label>
                                        <input runat="server" type="password" class="form-control" id="txtpass" placeholder="password" maxlength="50" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="BtnGuardar" OnClick="BtnGuardar_Click" CssClass="btn btn-success" runat="server" Style="border-radius: 15px;">
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

        <div id="mymodal" class="modal fade EditarUsuario-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel2" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header shadow bg-body">
                                <h4 class="modal-title" id="myLargeModalLabel2">Modificar Usuario</h4>
                                <button type="button" style="padding: 0px;" title="cerrar" class="close " data-dismiss="modal" aria-label="Close">
                                    <span style="border-radius: 0px  0px 0px 5px" class="btn btn-danger btn-lg" aria-hidden="true"><i class="fa fa-times-circle"></i></span>
                                </button>
                            </div>
                            <div class="modal-body shadow-sm bg-body">
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtnombresE.ClientID %>">Nombres<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtnombresE" placeholder="Full name" maxlength="100" />
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtapellidosE.ClientID %>">Apellidos<b>(*)</b></label>
                                        <input runat="server" type="text" class="form-control" id="txtapellidosE" placeholder="Full surname" maxlength="100" />
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=DdlRolE.ClientID %>">Rol<b>(*)</b></label>
                                        <asp:DropDownList runat="server" ID="DdlRolE" CssClass="form-control">
                                            <asp:ListItem Text="Seleccione.." Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <label>Estado<b>(*)</b></label>
                                        <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                            <input runat="server" class="custom-control-input" type="checkbox" id="ChkEstadoE" checked />
                                            <label class="custom-control-label" for="<%=ChkEstadoE.ClientID %>">Activo</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtuserE.ClientID %>">Nombre de Usuario</label>
                                        <input runat="server" type="text" class="form-control" id="txtuserE" placeholder="username" disabled />
                                    </div>
                                </div>
                                <div class="form-row">
                                    <div class="col-md-6 mb-4">
                                        <label for="<%=txtpassE.ClientID %>"><b>Contraseña:</b></label>
                                        <div class="input-group">
                                            <input runat="server" type="password" class="form-control" id="txtpassE" placeholder="password" maxlength="50" />
                                            <div class="input-group-append">
                                                <asp:LinkButton ToolTip="Cambiar contraseña" OnClientClick="this.disabled=true;" ID="btnCambPass" OnClick="btnCambPass_Click" CssClass="btn btn-primary " Style="border-radius: 0px" runat="server">
                                                    <i class="fa fa-hand-o-left"></i>
                                                    Actualizar
                                                </asp:LinkButton>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer" style="display: block;">
                                <div class="form-row">
                                    <div class="col-md-12 d-flex justify-content-end">
                                        <asp:LinkButton OnClientClick="this.disabled=true;" ID="BtnActualizar" OnClick="BtnActualizar_Click" CssClass="btn btn-success" runat="server" Style="border-radius: 15px;">
                                            <i class="fa fa-save"  ></i>
                                            Guardar 
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField runat="server" ID="hfempidE" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </form>
</asp:Content>
