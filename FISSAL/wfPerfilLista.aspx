<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfPerfilLista.aspx.cs" Inherits="FISSAL.wfPerfilLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:GridView ID="gvPerfilLista" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvPerfilLista_PageIndexChanging" OnSelectedIndexChanged="gvPerfilLista_SelectedIndexChanged" PageSize="20">
                        <Columns>
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intCodigoPerfil" HeaderText="CÓDIGO" ItemStyle-Width="80px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="vchNombrePerfil" HeaderText="NOMBRE" ItemStyle-Width="350px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="chrEstado" HeaderText="ESTADO" ItemStyle-Width="60px"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td></tr>
            </table>
        </asp:View>
        <asp:View ID="vwEdicion" runat="server">
            <table style="text-align:left;">
                <tr><td>
                <table style="text-align:left;">
                    <tr><td>Codigo</td><td>
                        <asp:Label ID="lblCodigo" runat="server" Text="0"></asp:Label></td></tr>
                    <tr><td>Perfil</td><td>
                        <asp:TextBox ID="txtPerfil" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Ingrese perfil" Text="*" ControlToValidate="txtPerfil"></asp:RequiredFieldValidator>
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
