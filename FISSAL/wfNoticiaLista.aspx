<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin2.Master" UICulture="es-PE" Culture="es-PE" AutoEventWireup="true" CodeBehind="wfNoticiaLista.aspx.cs" Inherits="FISSAL.wfNoticiaLista" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:GridView ID="gvNoticiaLista" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvNoticiaLista_PageIndexChanging" OnSelectedIndexChanged="gvNoticiaLista_SelectedIndexChanged" PageSize="20" OnRowDataBound="gvNoticiaLista_RowDataBound">
                        <Columns>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intCodigo" HeaderText="CÓDIGO" ItemStyle-Width="80px">
                            <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="FECHA PUB.">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaPublicacion" runat="server" Text='<%# Bind("dtmFechaPublicacion") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="120px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="vchTitulo" HeaderText="TÍTULO" ItemStyle-Width="500px" ReadOnly="True">
                            <ItemStyle Width="500px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="chrEstado" HeaderText="ESTADO" ItemStyle-Width="80px" ReadOnly="True">
                            <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="FOTO">
                                <ItemTemplate>
                                    <asp:Literal ID="litImagen" runat="server"></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                        <tr><td>Fecha Pub.</td><td>
                            <telerik:RadDatePicker ID="rdpFechaPublicacion" CssClass="textoObligatorio" Runat="server">
                            </telerik:RadDatePicker>
                            <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ErrorMessage="Ingrese fecha de publicación" Text="*" ControlToValidate="rdpFechaPublicacion"></asp:RequiredFieldValidator>
                                               </td></tr>
                        <tr><td>Volada</td><td>
                        <asp:TextBox ID="txtVolada" runat="server" Width="650" Text=""></asp:TextBox>
                            </td></tr>
                        <tr><td>Titulo</td><td>
                        <asp:TextBox ID="txtTitulo" runat="server" Width="650" Text="" CssClass="textoObligatorio"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ErrorMessage="Ingrese título" Text="*" ControlToValidate="txtTitulo"></asp:RequiredFieldValidator>
                        </td></tr>
                        <tr><td>Bajada</td><td>
                        <asp:TextBox ID="txtBajada" runat="server" Width="650" Text=""></asp:TextBox></td></tr>
                        <tr><td>Lead</td><td>
                            <telerik:RadEditor ID="txtLead" Width="650" Height="200" runat="server">
                                <Tools>
                                    <telerik:EditorToolGroup>
                                        <telerik:EditorTool Name="Bold"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Italic"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Underline"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Cut"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Copy"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Paste"></telerik:EditorTool>

                                    </telerik:EditorToolGroup>
                                    <telerik:EditorToolGroup>
                                        <telerik:EditorTool Name="InsertImage"></telerik:EditorTool>
                                        <telerik:EditorTool Name="LinkManager"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Unlink"></telerik:EditorTool>
                                        <telerik:EditorTool Name="InsertOrderedList"></telerik:EditorTool>
                                        <telerik:EditorTool Name="InsertUnorderedList"></telerik:EditorTool>
                                    </telerik:EditorToolGroup>
                                </Tools>
                                <Content>
                                </Content>
                            </telerik:RadEditor>
                            <asp:RequiredFieldValidator ID="rfvLead" runat="server" ErrorMessage="Ingrese lead" Text="*" ControlToValidate="txtLead"></asp:RequiredFieldValidator>
                            </td></tr>
                        <tr><td>Contenido</td><td>
                            <telerik:RadEditor ID="txtContenido" Width="650" runat="server">
                                <Tools>
                                    <telerik:EditorToolGroup>
                                        <telerik:EditorTool Name="Bold"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Italic"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Underline"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Cut"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Copy"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Paste"></telerik:EditorTool>

                                    </telerik:EditorToolGroup>
                                    <telerik:EditorToolGroup>
                                        <telerik:EditorTool Name="InsertImage"></telerik:EditorTool>
                                        <telerik:EditorTool Name="LinkManager"></telerik:EditorTool>
                                        <telerik:EditorTool Name="Unlink"></telerik:EditorTool>
                                        <telerik:EditorTool Name="InsertOrderedList"></telerik:EditorTool>
                                        <telerik:EditorTool Name="InsertUnorderedList"></telerik:EditorTool>
                                    </telerik:EditorToolGroup>
                                </Tools>
                                <Content>
                                </Content>
                            </telerik:RadEditor>
                        </td></tr>
                        <tr><td>Estado</td><td>
                        <asp:CheckBox ID="chkEstado" runat="server" /></td></tr>
                        <tr><td>Imagen</td><td>
                        <asp:Literal ID="litImagen" runat="server"></asp:Literal><asp:Literal ID="litFotografiaId" runat="server" Visible="false"></asp:Literal>
                        <asp:Button ID="btnFoto" Text="Enlazar foto" runat="server" OnClick="btnFoto_Click" />
                            <asp:Button ID="btnEliminarFoto" Text="Eliminar foto" runat="server" Visible="false" OnClick="btnEliminarFoto_Click" /><asp:HiddenField ID="hdfFotoCodigo" Value="0" runat="server" />
                                           </td></tr>
                        <tr><td>URL</td>
                            <td><asp:TextBox ID="txtURL" runat="server" Width="650"></asp:TextBox></td>
                        </tr>
                    </table>
                </td></tr>
                <tr><td>
                    <asp:Button ID="btnNuevoDetalle" runat="server" Text="Nuevo" OnClick="btnNuevoDetalle_Click" Width="100px" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" Width="100px" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" Width="100px" />
                </td></tr>
                <tr><td>
                    <asp:ValidationSummary ID="vsErrores" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td></tr>
            </table>
        </asp:View>
        <asp:View ID="vwFoto" runat="server">
            <table style="text-align:left;">
                <tr><td>
                    <asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" CausesValidation="False" OnClick="btnCancelar2_Click" />
                    <asp:DataList ID="dlFoto" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnItemDataBound="dlFoto_ItemDataBound" OnItemCommand="dlFoto_ItemCommand">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEditar" runat="server" CommandName="enlazar" Width="200" />
                        </ItemTemplate>
                    </asp:DataList>
                </td></tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
