<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin2.Master" AutoEventWireup="true" CodeBehind="wfPaginaLista.aspx.cs" Inherits="FISSAL.wfPaginaLista" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:GridView ID="gvPaginaLista" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvPaginaLista_PageIndexChanging" OnSelectedIndexChanged="gvPaginaLista_SelectedIndexChanged" PageSize="20" OnRowDataBound="gvPaginaLista_RowDataBound">
                        <Columns>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intPagina" HeaderText="CÓDIGO" ItemStyle-Width="80px">
                            <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="vchNombrePagina" HeaderText="TÍTULO" ItemStyle-Width="500px" ReadOnly="True">
                            <ItemStyle Width="500px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="vchPagina" HeaderText="PÁGINA" ItemStyle-Width="500px" ReadOnly="True">
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
                        <tr><td>Codigo</td><td>
                        <asp:Label ID="lblCodigo" runat="server" Text="0"></asp:Label></td></tr>
                        <tr><td>Nombre Página</td><td>
                        <asp:TextBox ID="txtNombrePagina" runat="server" Width="650" Text="" CssClass="textoObligatorio"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ErrorMessage="Ingrese nombre página" Text="*" ControlToValidate="txtNombrePagina"></asp:RequiredFieldValidator>
                        </td></tr>
                        <tr><td>Página asociada</td><td>
                        <asp:TextBox ID="txtPagina" runat="server" Width="650" Text=""></asp:TextBox></td></tr>
                        <tr><td>Lead</td><td style="text-align:left">
                            <telerik:RadEditor ID="txtLead" CssClass="editorHTML" Width="650" Height="200" runat="server">
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
                        <tr><td>Contenido</td><td style="text-align:left">
                            <telerik:RadEditor ID="txtContenido" CssClass="editorHTML" Width="650" runat="server">
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
                    </table>
                </td></tr>
                <tr><td>
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
                </td></tr>
                <tr><td>
                    <asp:ValidationSummary ID="vsErrores" runat="server" ShowMessageBox="True" ShowSummary="False" />
                </td></tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
