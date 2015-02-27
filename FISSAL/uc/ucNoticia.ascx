<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNoticia.ascx.cs" Inherits="FISSAL.uc.ucNoticia" %>
<div class='<%: estiloCabeceraControl %>'>
    <h4><a href="seccion_noticias.html">NOTICIAS</a></h4>
</div>

<div class="body-bloque">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Repeater ID="rpNoticia" runat="server" OnItemDataBound="rpNoticia_ItemDataBound">
        <ItemTemplate>
            <asp:Literal ID="litTitulo" runat="server"></asp:Literal>
            <br /><asp:Literal ID="litImagen" runat="server"></asp:Literal>
            <br /><br />
            <asp:Literal ID="litLead" runat="server"></asp:Literal>
        </ItemTemplate>
        </asp:Repeater>
        <div class="buttons">
            <asp:DataList id="dlPaging" runat="server" RepeatDirection="Horizontal" HorizontalAlign="Right" OnItemCommand="dlPaging_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>' CssClass="botonNoticiaLink" CommandName="lnkbtnPaging"></asp:LinkButton>
                </ItemTemplate>
                <SelectedItemStyle CssClass="botonNoticiaPaginadoSeleccion" />
            </asp:DataList>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</div>

<div class='<%: estiloFooterControl %>'>
    <a href="notas.aspx"><img src="images/vermasnot.png" /></a>
</div>




