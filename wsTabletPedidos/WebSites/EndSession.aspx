<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="EndSession.aspx.cs" Inherits="WebSites.EndSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form2" runat="server">
        <script type="text/javascript">
            function getCookie(name) {
                const value = `; ${document.cookie}`;
                const parts = value.split(`; ${name}=`);
                return parts.length === 2 ? parts.pop().split(';').shift() : null;
            }

            const privileges = getCookie('privileges');

            swal({
                title: "Aviso",
                text: "la sesión ha expirado, redirigiendo...",
                timer: 3000,
                showConfirmButton: false
            }, function () {
                const ultimoRol = sessionStorage.getItem('privileges');
                // Redirigir después de que el SweetAlert se cierre
                if (ultimoRol === "Mesero" || ultimoRol === "Cajero") {
                    window.location.href = "frmMeseroIndex";
                }
                else {
                    window.location.href = "index";
                }
                
            });
        </script>
    </form>
</asp:Content>
