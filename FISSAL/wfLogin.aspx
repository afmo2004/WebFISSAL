<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfLogin.aspx.cs" Inherits="FISSAL.wfLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso Panel de Control - FISSAL</title>
    <link href="css/styleAdmin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center;">
        <div style="width: 300px; margin-left: auto; margin-right:auto;margin-top:260px;border:2px solid #808080;padding:10px;">
            <div style="padding-bottom:10px;">
                <img src="images/fissal_iso.png" alt="FISSAL" />
            </div>
            <asp:Login ID="loginSistema" runat="server" 
                FailureText="Error al ingresar al sistema. Intentar de nuevo" 
                LoginButtonText="Ingresar" 
                PasswordRequiredErrorMessage="Password es requerido." 
                TitleText="Ingreso al Panel de Control" UserNameLabelText="Usuario:" 
                UserNameRequiredErrorMessage="Usuario es requerido." 
                onauthenticate="ValidarUsuario" Width="300px" CssClass="login">
            </asp:Login>
        </div>
    </div>
    </form>
</body>
</html>
