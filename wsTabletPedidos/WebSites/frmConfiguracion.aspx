<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" 
    CodeBehind="frmConfiguracion.aspx.cs" Inherits="WebSites.frmConfiguracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .logo-preview {
            max-height: 150px;
            max-width: 100%;
            border: 1px solid #ddd;
            padding: 5px;
            margin-top: 10px;
        }
        #imageModal .modal-dialog {
            max-width: 80%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container mb-4 pb-3 pt-3 shadow bg-body rounded">
                    <div class="form-row mb-1">
                        <div class="col-md-6">
                            <label class="font-weight-bold">Logo de la Empresa</label>
                            <div class="form-group form-group-sm">
                                <div class="custom-file">
                                    <asp:FileUpload ID="fuLogo" runat="server" CssClass="custom-file-input form-control-sm" 
                                        onchange="previewLogo(this);" />
                                    <label class="custom-file-label col-form-label-sm" for="fuLogo" data-browse="Seleccionar...">
                                        Seleccionar archivo (PNG/JPG)
                                    </label>
                                </div>
                                <small class="form-text text-muted">Tamaño recomendado: 300x300 px</small>
                                <asp:Button ID="btnSubirLogo" runat="server" Text="Subir Logo" 
                                    CssClass="btn btn-primary mt-2" OnClick="btnSubirLogo_Click" />
                            </div>
                            
                            <div class="mt-3">
                                <asp:Image Style="display:none;" ID="imgLogoPreview" runat="server" CssClass="logo-preview" 
                                    Visible="false" />
                                <button type="button" class="btn btn-info mt-2" data-toggle="modal" data-target="#imageModal"
                                    id="btnVerLogo" runat="server" visible="false">
                                    Ver Logo Completo
                                </button>
                            </div>
                            
                           
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mt-4">
                             <asp:Label ID="lblMensaje" runat="server" CssClass="mt-2 d-block" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
                
                <!-- Modal para ver el logo completo -->
                <div class="modal fade" id="imageModal" tabindex="-1" aria-labelledby="imageModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-dialog-centered modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="imageModalLabel">Logo de la Empresa</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body text-center">
                                <asp:Image ID="imgLogoModal" runat="server" CssClass="img-fluid" />
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubirLogo" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
    
    <script>
        function previewLogo(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    // Mostrar previsualización
                    var imgPreview = document.getElementById('<%= imgLogoPreview.ClientID %>');
                    imgPreview.src = e.target.result;
                    imgPreview.style.display = 'block';

                    // Actualizar también la imagen del modal
                    document.getElementById('<%= imgLogoModal.ClientID %>').src = e.target.result;
                    
                    // Mostrar botón de ver logo
                    document.getElementById('<%= btnVerLogo.ClientID %>').style.display = 'block';
                }
                reader.readAsDataURL(input.files[0]);

                // Mostrar nombre del archivo
                var fileName = input.files[0].name;
                var label = input.nextElementSibling;
                label.innerText = fileName;
            }
        }
    </script>
</asp:Content>