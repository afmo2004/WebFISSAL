<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfNormasLegalesLista.aspx.cs" Inherits="FISSAL.wfNormasLegalesLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:GridView ID="gvNormasLegalesLista" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvNormasLegalesLista_PageIndexChanging" OnSelectedIndexChanged="gvNormasLegalesLista_SelectedIndexChanged" PageSize="20">
                        <Columns>
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intCodigo" HeaderText="CÓDIGO" ItemStyle-Width="80px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="intAnio" HeaderText="AÑO" ItemStyle-Width="80px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="chrTipo" HeaderText="TIPO" ItemStyle-Width="60px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="vchTitulo" HeaderText="TÍTULO" ItemStyle-Width="350px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="vchArchivo" HeaderText="ARCHIVO" ItemStyle-Width="180px"></asp:BoundField>
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
                    <tr><td>Año</td><td>
                        <asp:DropDownList ID="ddlAnio" CssClass="combo" runat="server" Width="80">
                        </asp:DropDownList>
                        </td></tr>
                    <tr><td>Tipo</td><td>
                        <asp:DropDownList ID="ddlTipo" runat="server">
                            <asp:ListItem Value="1" Text="Resolución Jefatural"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Resolución Ministerial"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Leyes"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Decretos Supremos"></asp:ListItem>
                            <asp:ListItem Value="5" Text="Normas de Interés"></asp:ListItem>
                       </asp:DropDownList>
                    </td></tr>
                    <tr><td>Título</td><td>
                        <asp:TextBox ID="txtTitulo" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ErrorMessage="Ingrese perfil" Text="*" ControlToValidate="txtTitulo"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td>Descripción</td><td>
                        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Width="500px" Height="150"></asp:TextBox>
                    </td></tr>
                    <tr><td>Archivo</td><td>
                        <asp:FileUpload ID="fuArchivo" runat="server" />
                        <asp:Label ID="lblArchivo" runat="server" Text=""></asp:Label>
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
