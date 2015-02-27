<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfFotografiaLista.aspx.cs" Inherits="FISSAL.wfFotografiaLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:DataList ID="dlFoto" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnItemDataBound="dlFoto_ItemDataBound" OnItemCommand="dlFoto_ItemCommand">
                        <ItemTemplate>
                            <div style="width:auto">
                                <asp:ImageButton ID="imgEditar" runat="server" CommandName="editar" Width="200" />
                            </div>    
                            <div style="width:auto">
                                <asp:ImageButton ID="imgEliminar" ImageUrl="~/images/Grilla_Eliminar.gif" runat="server" OnClientClick="return confirm('¿Está seguro que desea eliminar la foto?');" CommandName="eliminar" />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </td></tr>
                <tr><td><asp:Label ID="lblErrores" runat="server" ForeColor="Red"></asp:Label></td></tr>
            </table>
        </asp:View>
        <asp:View ID="vwEdicion" runat="server">
            <table style="text-align:left;">
                <tr><td>
                <table style="text-align:left;">
                    <tr><td>Codigo</td><td>
                        <asp:Label ID="lblCodigo" runat="server" Text="0"></asp:Label></td></tr>
                    <tr><td>Leyenda</td><td>
                        <asp:TextBox ID="txtLeyenda" runat="server" Width="500px" CssClass="textoObligatorio"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Ingrese leyenda" Text="*" ControlToValidate="txtLeyenda"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td>Imagen</td><td>
                        <asp:FileUpload ID="fuImagen" runat="server" />
                        [<asp:Label ID="lblImagen" runat="server" Text="0"></asp:Label>]<br />[686px ancho y 388px alto]
                        </td></tr>
                    <tr><td></td><td><asp:Literal ID="litImagen" runat="server"></asp:Literal>
                        </td></tr>
                    <tr><td>Estado</td><td>
                        <asp:CheckBox ID="chkEstado" runat="server" /></td></tr>
                </table>
                </td></tr>
                <tr><td>
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
                </td></tr>
                <tr><td><asp:ValidationSummary ID="vsErrores" runat="server" ShowMessageBox="True" ShowSummary="False" />
                    </td></tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
