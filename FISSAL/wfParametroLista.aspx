<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfParametroLista.aspx.cs" Inherits="FISSAL.wfParametroLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:GridView ID="gvParametroLista" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" OnSelectedIndexChanged="gvParametroLista_SelectedIndexChanged" OnRowCommand="gvParametroLista_RowCommand">
                        <Columns>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intCodigo" HeaderText="CÓDIGO" ItemStyle-Width="80px">
                            <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="vchNombre" HeaderText="NOMBRE" ItemStyle-Width="500px" ReadOnly="True">
                            <ItemStyle Width="500px" />
                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="true" HeaderText="DETALLE">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgDetalle" runat="server" CausesValidation="false" ImageUrl="~/images/edit.png" CommandName="Detalle" CommandArgument='<%#Eval("intCodigo") %>'></asp:ImageButton>
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
                    <tr><td>Código</td><td>
                        <asp:Label ID="lblCodigo" runat="server" Text="0"></asp:Label></td></tr>
                    <tr><td>Nombre</td><td>
                        <asp:TextBox ID="txtNombre" runat="server" Width="300px" CssClass="textoObligatorio"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Ingrese nombre" Text="*" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                        </td></tr>
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
        <asp:View ID="vwGrillaDetalle" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevoDetalle" runat="server" Text="Nuevo" OnClick="btnNuevoDetalle_Click" />
                    <asp:Button ID="btnCancelar1" runat="server" Text="Cancelar" CausesValidation="False" OnClick="btnCancelar1_Click" />
                    <asp:TextBox ID="txtParametroID" runat="server" ReadOnly="true" Width="80"></asp:TextBox>
                </td></tr>
                <tr><td>
                    <asp:GridView ID="gvParametroDetalleLista" runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="rounded-corner" OnSelectedIndexChanged="gvParametroDetalleLista_SelectedIndexChanged" PageSize="20" OnRowCommand="gvParametroDetalleLista_RowCommand">
                        <Columns>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intCodigo" HeaderText="CÓDIGO" ItemStyle-Width="80px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="vchDescripcion" HeaderText="DESCRIPCION" ItemStyle-Width="250px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="vchValor" HeaderText="VALOR" ItemStyle-Width="100px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="chrEstado" HeaderText="ESTADO" ItemStyle-Width="60px"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td></tr>
            </table>
        </asp:View>
        <asp:View ID="vwEdicionDetalle" runat="server">
            <table style="text-align:left;">
                <tr><td>
                    <table style="text-align:left;">
                        <tr><td>Código</td><td>
                            <asp:Label ID="lblCodigoDetalle" runat="server" Text="0"></asp:Label></td></tr>
                        <tr><td>Descripcion</td><td>
                            <asp:TextBox ID="txtDescripcionDetalle" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese descripción" Text="*" ControlToValidate="txtDescripcionDetalle"></asp:RequiredFieldValidator>
                            </td></tr>
                        <tr><td>Valor</td><td>
                            <asp:TextBox ID="txtValorDetalle" runat="server" Width="300px"></asp:TextBox></td></tr>
                        <tr><td>Estado</td><td>
                            <asp:CheckBox ID="chkEstadoDetalle" runat="server" /></td></tr>
                    </table>
                </td></tr>
                <tr><td>
                    <asp:Button ID="btnActualizarDetalle" runat="server" Text="Actualizar" OnClick="btnActualizarDetalle_Click" />
                    <asp:Button ID="btnCancelarDetalle" runat="server" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarDetalle_Click" />
                </td></tr>
                <tr><td>
                </td></tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
