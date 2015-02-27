<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfUbicacionControl.aspx.cs" Inherits="FISSAL.wfUbicacionControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="text-align:left;width:400px">
        <tr><td><asp:DropDownList ID="ddlSeccion" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlSeccion_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
            <td></td>
        </tr>
        <tr>
            <td><asp:RadioButtonList ID="rblUbicacion" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblUbicacion_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="I">Izquierda</asp:ListItem>
                <asp:ListItem Value="D">Derecha</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td><asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" /></td>
        </tr>
    </table>
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwPrincipal" runat="server">
            <table style="text-align:left">
                <tr>
                <td>
                <asp:GridView ID="gvControlSeccion" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
                    CssClass="rounded-corner" PageSize="20" DataKeyNames="intCodigoControl"
                    OnRowDataBound="gvControlSeccion_RowDataBound" OnRowCommand="gvControlSeccion_RowCommand">
                    <Columns>
                        <asp:BoundField ReadOnly="True" DataField="intCodigoControl" HeaderText="CÓDIGO" ItemStyle-Width="80px"></asp:BoundField>
                        <asp:TemplateField HeaderText="NOMBRE">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Width="150"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ORDEN">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOrden" runat="server" Width="60" Text='<%#Eval("intOrden") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>
                                <asp:ImageButton id="imgGrabar" runat="server" CausesValidation="false" ImageUrl="~/images/save.gif" CommandName="GrabarOrden" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>
                                <asp:ImageButton id="imgEliminar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla_Eliminar.gif" CommandName="Eliminar" OnClientClick="return confirm('Desea eliminar registro?');" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </td></tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlControl" runat="server" Width="300px"></asp:DropDownList><asp:TextBox ID="txtOrden" runat="server" Width="50px"></asp:TextBox>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblError" runat="server"></asp:Label></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
