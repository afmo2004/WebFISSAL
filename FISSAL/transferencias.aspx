<%@ Page Title="" Language="C#" MasterPageFile="~/mpHome2.Master" AutoEventWireup="true" CodeBehind="transferencias.aspx.cs" Inherits="FISSAL.transferencias" %>

<%@ Register src="uc/ucBeneficiarios2.ascx" tagname="ucBeneficiarios2" tagprefix="uc2" %>
<%@ Register src="uc/ucCobertura2.ascx" tagname="ucCobertura2" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor-desarrollo-noticia">
        <div class="header-notvid-desarrollo-noticias">
        	<ul>
              <li>Transferencias</li>
            </ul>
      	</div>

        <div class="body-bloque-desarrollo-noticia">
            
            <div style="border:1px solid #dadada; margin:15px;"></div>

            <div class="header-notvid-desarrollo-noticias">
        	    <ul>
                    <li>También te puede interesar:</li>
                </ul>
      	    </div>

            <div class="interes">
                <div class="lateral-interes"> 
                    <uc2:ucBeneficiarios2 ID="ucBeneficiarios21" runat="server" />
                </div>
                <div class="principal-interes">
                    <uc1:ucCobertura2 ID="ucCobertura21" runat="server" />
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </div>
</asp:Content>
