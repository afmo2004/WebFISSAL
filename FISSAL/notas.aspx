<%@ Page Title="" Language="C#" MasterPageFile="~/mpHome2.Master" AutoEventWireup="true" CodeBehind="notas.aspx.cs" Inherits="FISSAL.notas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor-desarrollo-noticia">
        <div class="header-seccion-not">
        	<ul>
              <li>Noticias</li>
          </ul>
        </div>
        <div class="body-bloque-seccion-noticia">
            <div id="lateral">
                <asp:Literal ID="litImagen1" runat="server"></asp:Literal>
                <asp:Literal ID="litTitulo1" runat="server"></asp:Literal><p></p>
                <asp:Literal ID="litLead1" runat="server"></asp:Literal>
            </div>
            <div id="principal">
                <asp:Literal ID="litImagen2" runat="server"></asp:Literal>
                <asp:Literal ID="litTitulo2" runat="server"></asp:Literal><p></p>
                <asp:Literal ID="litLead2" runat="server"></asp:Literal>
            </div>
            <div class="clear"></div>
            <div class="lineaploma"></div>
            <asp:Repeater ID="rpNoticia" runat="server" OnItemDataBound="rpNoticia_ItemDataBound">
                <ItemTemplate>
                    <div class="contenedor_noticia_seccion_previa">
                        <div class="contenedor_imagen_videorep">
                            <asp:Literal ID="litImagen" runat="server"></asp:Literal>
                        </div>
                        <div class="noticia_video_pasada">
                            <asp:Literal ID="litTitulo" runat="server"></asp:Literal>
                            <asp:Literal ID="litLead" runat="server"></asp:Literal>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="paginadorNotas">
                <asp:DataList id="dlPaging" runat="server" RepeatDirection="Horizontal" HorizontalAlign="Right" OnItemCommand="dlPaging_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>' CssClass="botonPaginadoLink" CommandName="lnkbtnPaging" Text='<%# Eval("PageText") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <SelectedItemStyle CssClass="edpBarraSeccionPaginadoSeleccion" />
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
