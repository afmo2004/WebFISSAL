<%@ Page Title="" Language="C#" MasterPageFile="~/mpHome2.Master" AutoEventWireup="true" CodeBehind="noticia.aspx.cs" Inherits="FISSAL.noticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor-desarrollo-noticia">
        <div class="header-notvid-desarrollo-noticias">
        	<ul>
              <li>NOTICIA</li>
            </ul>
        </div>
        <div class="body-bloque-desarrollo-noticia">
            <asp:Literal ID="litVolada" runat="server"></asp:Literal>
            <asp:Literal ID="litTitulo" runat="server"></asp:Literal>
            <asp:Literal ID="litBajada" runat="server"></asp:Literal>
            <asp:Literal ID="litImagen" runat="server"></asp:Literal>
            <asp:Literal ID="litContenido" runat="server"></asp:Literal>
            <asp:Literal ID="litFechaPublicacion" runat="server"></asp:Literal>
        </div>
        <div class="body-bloque-desarrollo-noticia-pie">
            <a href="notas.aspx"><img src="images/archivo-notas.png" alt="Regresar a Achivo de Noticias" title="Regresar a Achivo de Noticias" /></a>
        </div>
    </div>
</asp:Content>
