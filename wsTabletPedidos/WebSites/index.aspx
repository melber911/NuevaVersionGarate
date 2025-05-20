<%@ Page Language="C#" AutoEventWireup="true" Inherits="index" CodeBehind="index.aspx.cs" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>MVARest | Autenticación</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/LogoGaucho.jpg" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="vendor/toastr/toastr.css" />
    <link rel="stylesheet" href="vendor/sweetalert/sweetalert.min.css" />


    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
    <!--===============================================================================================-->

     <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>

    <script src="vendor/toastr/toastr.min.js"></script>
    <script src="vendor/sweetalert/sweetalert.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    

</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form class="login100-form validate-form" runat="server" id="form1">
                            <div class="text-center mb-5 h5 font-weight-bold">
                                Iniciar Sesión
                            </div>
                            <p class="text-center font-weight-bold h1 mb-5">
                                <asp:Image CssClass="rounded-circle" ID="imgLogo" runat="server" ImageUrl="~/images/LogoGaucho.jpg" Width="80px" Height="80px" />MVARest
                            </p>

                            <div class="wrap-input100 validate-input" data-validate="Seleccionar sucursal">
                                <label for="<%=Ddlsede.ClientID %>">Sucursal</label>
                                <asp:DropDownList AutoPostBack="true" runat="server" ID="Ddlsede" CssClass="form-control js-example-basic-single" OnSelectedIndexChanged="Ddlsede_SelectedIndexChanged">
                                    <asp:ListItem Text="Seleccione.." Value="-1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div id="divUser" runat="server" style="display: none;" class="wrap-input100 validate-input" data-validate="Ingresar usuario">
                                <input class="input100" type="text" name="Usuario" id="txtUsuario" autocomplete="off" runat="server">
                                <span class="focus-input100" data-placeholder="Usuario*"></span>
                            </div>

                            <div id="divPass" runat="server" style="display: none;" class="wrap-input100 validate-input" data-validate="Ingresar password">
                                <span class="btn-show-pass">
                                    <i style="font-size: 1.73em;" class="zmdi zmdi-eye"></i>
                                </span>
                                <input class="input100" type="password" name="pass" id="txtPass" autocomplete="new-password" runat="server">
                                <span class="focus-input100" data-placeholder="Contraseña*"></span>
                            </div>

                            <div id="divBtnLogin" runat="server" style="display: none;" class="container-login100-form-btn">
                                <div class="wrap-login100-form-btn">
                                    <div class="login100-form-bgbtn"></div>
                                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="login100-form-btn" Style="background-color: #6d7fcc" OnClick="btnIngresar_Click" />
                                </div>
                            </div>
                </form>
            </div>
        </div>
    </div>

    <script src="js/main.js"></script>
</body>
</html>
