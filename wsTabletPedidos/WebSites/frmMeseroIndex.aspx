<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMeseroIndex.aspx.cs" Inherits="WebSites.frmMeseroIndex" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Modulo Ventas | Autenticación</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Asegúrate de que la ruta sea correcta -->
    <link rel="stylesheet" type="text/css" href="css/loginmeseros.css">
    <style>
       /* General Styles */
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: Arial, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            background-color: #0b6ec1;
            padding: 10px;
        }

        .login-container {
            width: 100%;
            max-width: 500px; /* Aumenté el ancho máximo */
            padding: 30px; /* Aumenté el padding */
            background-color: #ffffff;
            border-radius: 15px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        .logo-section {
            text-align: center;
            margin-bottom: 30px; /* Aumenté el espacio debajo del logo */
        }

        #imagen-logo-inicio {
            width: 150px; /* Aumenté el tamaño del logo */
            height: 110px; /* Aumenté el tamaño del logo */
            /*border-radius: 50%;*/
            /*border: 2px solid silver;*/
            margin-top: 10px;
        }

        .input-section {
            margin-bottom: 25px; /* Aumenté el espaciado entre los campos */
        }

        .input-codigo {
            width: 100%;
            padding: 18px;  /*Aumenté el padding */
            font-size: 1.2rem;  /*Aumenté el tamaño de la fuente */
            border: 1px solid #ccc;
            border-radius: 10px;
            text-align: center;
        }

        .input-codigo:focus {
            outline: none; /* Elimina el borde azul de enfoque */
        }

        .mensaje-error {
            color: red;
            font-weight: bold;
            margin-top: 10px;
            text-align: center;
            display: none; /* Se mostrará solo si hay un error */
        }

        .buttons-grid {
            display: grid;
            grid-template-columns: repeat(3, 1fr); /* Tres columnas */
            gap: 10px;
            margin-bottom: 20px;
        }

        .buttons-grid button {
            font-weight: 700; /* Hace los números más gruesos */
            font-size: 1.5em; /* Aumenta el tamaño de los números */
        }

        .btn-ce {
            background-color: #f0aea7;
            border: 1px solid #c0c0c0;
            cursor: pointer;
            font-size: 1.2rem;
            padding: 15px;
            text-align: center;
            border-radius: 8px;
            transition: background-color 0.3s ease;
        }
        .btn_ingresar_no_tablet .btn-operacion.btn-backspace {
                background-color: #8bd17c;
        }
        button {
            padding: 18px; /* Aumenté el padding */
            font-size: 1.5rem; /* Aumenté el tamaño de la fuente */
            border: none;
            border-radius: 8px;
            background-color: #f0f0f0;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-ce:hover {
            background-color: #ffbbbb;
        }

        button:hover {
            background-color: #e0e0e0;
        }

        .btn-clear {
            background-color: #ffdddd;
        }

        .btn-clear:hover {
            background-color: #ffbbbb;
        }

        .btn-action {
            background-color: #d0eaff;
        }

        .btn-action:hover {
            background-color: #a3d1ff;
        }

        /* Botones de operación */
        .btn_ingresar_no_tablet {
            display: flex;
            flex-direction: column;
            gap: 15px; /*Aumenté el espacio entre los botones */
        }

        .btn_operacion {
            width: 100%;
            padding: 18px; /*Aumenté el padding */
            font-size: 1.2rem; /*Aumenté el tamaño de la fuente */
            background-color: #dfeaff;
            border-radius: 10px;
            border: 1px solid #c0c0c0;
        }

        .btn_operacion:hover {
            background-color: #b0d8ff;
        }

        @media (max-width: 768px) {
            button {
                font-size: 1.3rem; /*Aumenté el tamaño de los botones en tabletas */
                padding: 12px; /*Aumenté el padding de los botones */
            }

            #imagen-logo-inicio {
                width: 80px; /*Aumenté el tamaño del logo */
                height: 80px; /*Aumenté el tamaño del logo */
            }

            .input-codigo {
                font-size: 1rem; /*Aumenté el tamaño de la fuente*/
                padding: 15px; /*Aumenté el padding*/
            }
            .buttons-grid {
                grid-template-columns: repeat(3, 1fr); /*Tres columnas en tablets*/
            }
        }

        @media (max-width: 480px) {
            button {
                font-size: 1rem; /*Aumenté el tamaño de los botones */
                padding: 10px; /*Aumenté el padding de los botones */
            }

            .input-codigo {
                font-size: 1rem; /* Aumenté el tamaño de la fuente */
                padding: 14px; /* Aumenté el padding */
            }

            #imagen-logo-inicio {
                width: 70px; /* Aumenté el tamaño del logo */
                height: 70px; /* Aumenté el tamaño del logo */
            }
             .buttons-grid {
                grid-template-columns: repeat(3, 1fr); /* Tres columnas en pantallas pequeñas */
            }          
        }
        .active {
    transform: scale(0.5); /* Hace que el botón se vea presionado */
    background-color: #0056b3; /* Color más oscuro temporalmente */
}
    </style>
</head>
<body>
    <form id="form1" runat="server" class="login-container">
        <div class="logo-section">
            <img id="imagen-logo-inicio" src="images/logoMesas.png" alt="Logo">
        </div>
        <div class="input-section">
            <asp:TextBox ID="txtCodigo" runat="server" MaxLength="4" AutoPostBack="True" OnTextChanged="txtCodigo_TextChanged" placeholder="Ingresa código" class="input-codigo" oninput="enmascarar()"></asp:TextBox>
            <asp:Label ID="lblResultado" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtCodigoReal" runat="server" style="display:none" ></asp:TextBox>
        </div>
        <div class="buttons-grid">
            <button type="button" class="btn-numero" onclick="ingresarNumero(1)">1</button>
            <button type="button" class="btn-numero" onclick="ingresarNumero(2)">2</button>
            <button type="button" class="btn-numero" onclick="ingresarNumero(3)">3</button>
            <button type="button" class="btn-numero" onclick="ingresarNumero(4)">4</button>
            <button type="button" class="btn-numero" onclick="ingresarNumero(5)">5</button>
            <button type="button" class="btn-numero" onclick="ingresarNumero(6)">6</button>
            <button type="button" class="btn-numero" onclick="ingresarNumero(7)">7</button>
            <button type="button" class="btn-numero" onclick="ingresarNumero(8)">8</button>
            <button type="button" class="btn-numero" onclick="ingresarNumero(9)">9</button>
            <button type="button" class="btn-numero" onclick="ingresarNumero(0)">0</button>
            <button type="button" class="btn-operacion btn-ce" onclick="clearText()" style="grid-column: span 2;">CE</button> <!-- Botón CE que ocupa dos columnas -->
        </div>
        <div class="btn_ingresar_no_tablet">
            <button type="button" class="btn btn-operacion btn-backspace" onclick="borrar()">Borrar</button>
            <%--<button type="button" class="btn btn-operacion btn-cancelar" onclick="cancelar()">Cancelar</button>--%>
        </div>
    </form>

    <script>
        window.onload = function () {
            if (performance.navigation.type === 2) {  // Detecta si se navegó hacia atrás
                clearLoginData();
            }
        };

        function clearLoginData() {
            const input = document.getElementById('<%= txtCodigo.ClientID %>');
            const hidden = document.getElementById('<%= txtCodigoReal.ClientID %>');

            if (input && hidden) {
                input.value = '';  // Borra el campo visible
                hidden.value = '';  // Borra el campo oculto
            }

            sessionStorage.clear();  // Borra datos en sesión
            localStorage.clear();    // Borra datos almacenados en localStorage
        }

        document.addEventListener("DOMContentLoaded", function () {
            document.addEventListener("keydown", function (event) {
                // Verifica si la tecla presionada es un número (0-9)
                if (event.key >= "0" && event.key <= "9") {
                    ingresarNumero(event.key);
                }
            });
        });

        function ingresarNumero(numero) {
            var input = document.getElementById('<%= txtCodigo.ClientID %>');
            var real = document.getElementById('<%= txtCodigoReal.ClientID %>');

            // Agrega el número si no excede el límite
            if (real.value.length < 4) {
                real.value += numero; // Guarda el número real
                enmascarar(); //Muestra directamente "•"
                __doPostBack('<%= txtCodigo.ClientID %>', '');  // Forzar postback
            }
        }

        function borrar() {
            const input = document.getElementById('<%= txtCodigo.ClientID %>');
            const real = document.getElementById('<%= txtCodigoReal.ClientID %>');

            // Si hay caracteres, eliminar el último
            if (real.value.length > 0) {
                real.value = real.value.slice(0, -1);
                input.value = real.value.replace(/./g, '•'); // Mantiene enmascarado
            }

            // Si todo se borró, limpiar completamente
            if (real.value.length === 0) {
                real.value = "";
                input.value = "";
        
                // OPCIONAL: Forzar reset en el servidor con AJAX si es necesario
                resetearEstadoServidor();
            }
        }

        // Función opcional para forzar el reset en el servidor
        function resetearEstadoServidor() {
            __doPostBack('<%= txtCodigo.ClientID %>', 'reset'); // Enviar un evento al servidor
        }

        <%--function cancelar() {
            const input = document.getElementById('<%= txtCodigo.ClientID %>');
            input.value = '';
        }--%>

        function clearText() {
            const input = document.getElementById('<%= txtCodigo.ClientID %>');
            const hidden = document.getElementById('<%= txtCodigoReal.ClientID %>');

            hidden.value = '';  // Borra el código almacenado en memoria
            input.value = '';   // Borra la representación visual
        }

        function enmascarar() {
            var input = document.getElementById('<%= txtCodigo.ClientID %>');
            var real = document.getElementById('<%= txtCodigoReal.ClientID %>');

            // Asegurar que solo se ingresen números en el campo real
            real.value = real.value.replace(/\D/g, '');

            // Mantener enmascarado el campo visible con "•"
            input.value = real.value.replace(/./g, '•');
        }
    </script>
</body>
</html>
