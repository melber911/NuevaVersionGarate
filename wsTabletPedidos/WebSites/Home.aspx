<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebSites.Home" %>
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
    <script type="text/javascript">
        window.addEventListener("load", function () {
            llamarServidor();
        });

        function llamarServidor() {
            fetch("./ProcesoSunat.ashx") // Usa "./" para asegurar que busca en el mismo directorio
                .then(response => {
                    if (!response.ok) throw new Error("Error HTTP: " + response.status);
                    return response.json();
                })
                .then(data => console.log(data))
                .catch(error => console.error("Error:", error));
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    </form>
</asp:Content>
