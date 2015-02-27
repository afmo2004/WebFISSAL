<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfUsuarioLista.aspx.cs" Inherits="FISSAL.wfUsuarioLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:GridView ID="gvUsuarioLista" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvUsuarioLista_PageIndexChanging" OnSelectedIndexChanged="gvUsuarioLista_SelectedIndexChanged" PageSize="20">
                        <Columns>
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="vchLogin" HeaderText="USUARIO" ItemStyle-Width="100px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="vchNombreUsuario" HeaderText="NOMBRE" ItemStyle-Width="250px"></asp:BoundField>
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
                    <tr><td>Usuario</td><td>
                        <asp:TextBox ID="txtUsuario" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Ingrese usuario" Text="*" ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td>Password</td><td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Ingrese Password" Text="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td>Nombre</td><td>
                        <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Ingrese Nombre" Text="*" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td>Perfil</td><td>
                        <asp:DropDownList ID="ddlPerfil" runat="server" Width="200px"></asp:DropDownList></td></tr>
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
