﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FISSAL.index" %>

<%@ Register src="uc/ucCabecera.ascx" tagname="ucCabecera" tagprefix="uc1" %>
<%@ Register src="uc/ucPie.ascx" tagname="ucPie" tagprefix="uc2" %>
<%@ Register src="uc/ucMenu.ascx" tagname="ucMenu" tagprefix="uc3" %>
<%@ Register src="uc/ucCabeceraHome.ascx" tagname="ucCabeceraHome" tagprefix="uc4" %>
<%@ Register src="uc/ucSubmenu.ascx" tagname="ucSubmenu" tagprefix="uc5" %>
<%@ Register src="uc/ucCobertura.ascx" tagname="ucCobertura" tagprefix="uc6" %>
<%@ Register src="uc/ucBeneficiarios.ascx" tagname="ucBeneficiarios" tagprefix="uc7" %>


<%@ Register src="uc/ucNoticia.ascx" tagname="ucNoticia" tagprefix="uc8" %>
<%@ Register src="uc/ucVideo.ascx" tagname="ucVideo" tagprefix="uc9" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="images/fissal.ico" type="image/x-icon" />
    <title>FISSAL | Fondo Intangible Solidario de Salud</title>
    <link rel="stylesheet" type="text/css" href="slider/style.css" media="screen" />
	<style type="text/css">a#vlb{display:none}</style>
	<script type="text/javascript" src="slider/jquery.js"></script>
	<script type="text/javascript" src="slider/wowslider.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div id="wrap">
        <uc1:ucCabecera ID="ucCabecera1" runat="server" />
        <uc3:ucMenu ID="ucMenu1" runat="server" />
        <uc4:ucCabeceraHome ID="ucCabeceraHome1" runat="server" />
        <uc5:ucSubmenu ID="ucSubmenu1" runat="server" />
        <div id="contenedor-central">
            <div id="contenedor-notvid">
                <asp:PlaceHolder ID="phIzquierda" runat="server"></asp:PlaceHolder>
            </div>
            <div id="contenedor-enlaces">
                <asp:PlaceHolder ID="phDerecha" runat="server"></asp:PlaceHolder>
            </div>
            <div id="contenedor-info">
                <uc6:ucCobertura ID="ucCobertura1" runat="server" />
                <uc7:ucBeneficiarios ID="ucBeneficiarios1" runat="server" />
            </div>
            <div class="clear">
            </div>
        </div>
        <uc2:ucPie ID="ucPie1" runat="server" />
    </div>
    </form>
</body>
</html>
