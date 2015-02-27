<%@ Page Title="" Language="C#" MasterPageFile="~/mpHome2.Master" AutoEventWireup="true" CodeBehind="normas-legales.aspx.cs" Inherits="FISSAL.normas_legales" %>

<%@ Register src="uc/ucBeneficiarios2.ascx" tagname="ucBeneficiarios2" tagprefix="uc2" %>
<%@ Register src="uc/ucCobertura2.ascx" tagname="ucCobertura2" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor-desarrollo-noticia">
        <div class="header-notvid-desarrollo-noticias">
        	<ul>
              <li>Normas Legales</li>
            </ul>
      	</div>

        <div class="body-bloque-desarrollo-noticia">
            
            <div class="atencion">
                <div class="admiracion">
                <img src="images/1396945737_exclamation-circle-frame_basic_red.png" width="48" height="48" />
                </div>
                <div class="texto">
                Filtre la información necesario seleccionando la fecha y el tipo de resolución o norma legal que desea descargar.
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="fua">
                <div class="fua-left">
                 Año: <asp:DropDownList ID="ddlAnio" CssClass="combo" runat="server" Width="80">
                      </asp:DropDownList>
                </div>
                <div class="fua-right">
                 Tipo: <asp:DropDownList ID="ddlTipo" CssClass="combo" runat="server" Width="220">
                       </asp:DropDownList>
                </div>
                <div class="clear"></div>
            </div>
            <div class="boton-consulta">
                <asp:Button ID="btnBuscar" Text="Consultar" runat="server" OnClick="btnBuscar_Click" />
            </div>
                <p></p>
                <asp:GridView ID="gvNormasLegales" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" OnRowDataBound="gvNormasLegales_RowDataBound">
                    <Columns>
                        <asp:TemplateField ShowHeader="true" HeaderText="TÍTULO">
                            <ItemTemplate>
                                <asp:Literal ID="litTitulo" runat="server"></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ReadOnly="True" DataField="vchDescripcion" HeaderText="DESCRIPCIÓN" ItemStyle-Width="400px">
                        <ItemStyle Width="400px" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="true" HeaderText="DESCARGA">
                            <ItemTemplate>
                                <asp:Literal id="litDescarga" runat="server"></asp:Literal>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
            </ContentTemplate>
            </asp:UpdatePanel>
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
