<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin2.Master" UICulture="es-PE" Culture="es-PE" AutoEventWireup="true" CodeBehind="wfMaterialLista.aspx.cs" Inherits="FISSAL.wfMaterialLista" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:GridView ID="gvMaterialLista" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvMaterialLista_PageIndexChanging" OnSelectedIndexChanged="gvMaterialLista_SelectedIndexChanged" PageSize="20" OnRowDataBound="gvMaterialLista_RowDataBound">
                        <Columns>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intMaterial" HeaderText="CÓDIGO" ItemStyle-Width="80px">
                            <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="FECHA PUB.">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaPublicacion" runat="server" Text='<%# Bind("dtmFechaPublicacion") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="120px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="vchTitulo" HeaderText="TÍTULO" ItemStyle-Width="250px" ReadOnly="True">
                            <ItemStyle Width="250px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="vchDescripcion" HeaderText="DESCRIPCIÓN" ItemStyle-Width="500px" ReadOnly="True">
                            <ItemStyle Width="500px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="chrEstado" HeaderText="ESTADO" ItemStyle-Width="80px" ReadOnly="True">
                            <ItemStyle Width="80px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td></tr>
            </table>
        </asp:View>
        <asp:View ID="vwEdicion" runat="server">
            <table style="text-align:left;">
                <tr><td>
                <table style="text-align:left;">
                    <tr><td>Código</td><td>
                        <asp:Label ID="lblCodigo" runat="server" Text="0"></asp:Label></td></tr>
                    <tr><td>Título</td><td>
                        <asp:TextBox ID="txtTitulo" runat="server" Width="300px" CssClass="textoObligatorio"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Ingrese título" Text="*" ControlToValidate="txtTitulo"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td>Descripción</td><td>
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="500px"></asp:TextBox></td></tr>
                    <tr><td>Tipo</td><td>
                        <asp:DropDownList ID="ddlTipo" runat="server" Width="150">
                        </asp:DropDownList>
                    </td></tr>
                    <tr><td>Imagen</td><td>
                        <asp:FileUpload ID="fuImagen" runat="server" />[<asp:Label ID="lblImagen" runat="server"></asp:Label>][304px ancho y 208px alto]
                    </td></tr>
                    <tr><td>Archivo</td><td>
                        <asp:FileUpload ID="fuArchivo" runat="server" />[<asp:Label ID="lblArchivo" runat="server"></asp:Label>]
                    </td></tr>
                    <tr><td>Fecha Pub.</td><td>
                        <telerik:RadDatePicker ID="rdpFechaPublicacion" CssClass="textoObligatorio" Runat="server">
                        </telerik:RadDatePicker>
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
