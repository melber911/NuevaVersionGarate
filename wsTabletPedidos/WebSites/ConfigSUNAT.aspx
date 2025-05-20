<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="ConfigSUNAT.aspx.cs" Inherits="WebSites.ConfigSUNAT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
                    <div class="row mb-5">
                        <div class="col-md-6">
                            <h2>Datos Facturación Electronica SUNAT</h2>
                        </div>
                        <div class="col-md-6 d-flex justify-content-end align-items-center">
                            <asp:LinkButton OnClick="btnguardar_Click" type="button" runat="server" ID="btnguardar" class="btn btn-success mr-1" style="border-radius: 15px;">
                                <i class="fa fa-save"></i>
                                Guardar
                            </asp:LinkButton>
                            <asp:LinkButton OnClick="btncancelar_Click" type="button" runat="server" ID="btncancelar" class="btn btn-danger mr-1" style="border-radius: 15px;">
                                <i class="fa fa-close "></i>
                                Cancelar
                            </asp:LinkButton>
                            <asp:LinkButton OnClick="btnActualizar_Click" ID="btnActualizar" type="button" runat="server" class="btn btn-info mr-1" style="border-radius: 15px;">
                                <i class="fa fa-edit align-middle"></i>
                                Modificar
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="form-row mb-1">
                        <div class="col-md-4">
                            <label class="font-weight-bold">Razon Social</label>
                            <input runat="server" id="txtRazonSocial" class="form-control form-control-sm" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label class="font-weight-bold">Número Documento</label>
                            <input runat="server" id="txtNumeroDocumento" class="form-control form-control-sm" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label class="font-weight-bold">Dirección</label>
                            <input  runat="server" id="txtDireccion" class="form-control form-control-sm" type="text" />
                        </div>
                    </div>
                    <div class="form-row mb-1">
                        <div class="col-md-4">
                            <label class="font-weight-bold">Departamento</label>
                            <input runat="server" id="txtDepartamento" class="form-control form-control-sm" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label class="font-weight-bold">Provincia</label>
                            <input runat="server" id="txtProvincia" class="form-control form-control-sm" type="text" />
                        </div>
                        <div class="col-md-4">
                            <label class="font-weight-bold">Distrito</label>
                            <input runat="server" id="txtDistrito" class="form-control form-control-sm" type="text" />
                        </div>
                    </div>
                    <div class="form-row mb-1">
                        <div class="col-md-4">
                            <label class="font-weight-bold">Cuenta Sunat</label>
                            <div class="row">
                                <div class="col-6 pr-1">
                                    <input runat="server" id="txtUsuario" class="form-control form-control-sm" type="text" placeholder="Usuario"/>
                                </div>
                                <div class="col-6 pl-1">
                                    <input runat="server" id="txtContrasena" class="form-control form-control-sm" type="text" placeholder="Contraseña"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <label class="font-weight-bold">Certificado Sunat</label>
                            <div class="row">
                                <div class="col-4 pr-1">
                                    <input runat="server" id="txtCertificadoContraseña" class="form-control form-control-sm" type="text" placeholder="Contraseña"/>
                                </div>
                                <div class="col-8 pl-1">
                                    <input runat="server" id="txtRutaCertificado" class="form-control form-control-sm" type="text" placeholder="Ruta"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</asp:Content>
