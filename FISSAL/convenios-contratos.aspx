<%@ Page Title="" Language="C#" MasterPageFile="~/mpHome2.Master" AutoEventWireup="true" CodeBehind="convenios-contratos.aspx.cs" Inherits="FISSAL.convenios_contratos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor-desarrollo-noticia">
        <div class="header-info-des">
        	<ul>
              <li><asp:Literal ID="litTitulo" runat="server"></asp:Literal></li>
          </ul>
        </div>
        <div class="body-bloque-desarrollo-noticia">
            <asp:Literal ID="litLead" runat="server"></asp:Literal>
            <asp:Literal ID="litContenido" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
