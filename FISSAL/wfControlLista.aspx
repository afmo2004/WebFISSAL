<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfControlLista.aspx.cs" Inherits="FISSAL.wfControlLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="text-align:left;">
        <tr><td><asp:DropDownList ID="ddlTipoControl" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoControl_SelectedIndexChanged">
            <asp:ListItem Value="1">Cabecera Home</asp:ListItem>
            <asp:ListItem Value="2">Enlaces</asp:ListItem>
            <asp:ListItem Value="4">Material Difusión</asp:ListItem>
            </asp:DropDownList></td></tr>
    </table>
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:GridView ID="gvControlLista" runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="rounded-corner" OnPageIndexChanging="gvControlLista_PageIndexChanging" OnSelectedIndexChanged="gvControlLista_SelectedIndexChanged" PageSize="20" OnRowCommand="gvControlLista_RowCommand">
                        <Columns>
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intCodigoControl" HeaderText="CÓDIGO" ItemStyle-Width="80px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="vchNombreControl" HeaderText="NOMBRE" ItemStyle-Width="250px"></asp:BoundField>
                            <asp:TemplateField ShowHeader="true" HeaderText="DETALLE">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgDetalle" runat="server" CausesValidation="false" ImageUrl="~/images/edit.png" CommandName="Detalle" CommandArgument='<%#Eval("intCodigoControl") %>'></asp:ImageButton>
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
                    <tr><td>Nombre</td><td>
                        <asp:TextBox ID="txtNombre" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Ingrese nombre" Text="*" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td>Tipo</td><td><asp:DropDownList ID="ddlTipo" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoControl_SelectedIndexChanged">
            <asp:ListItem Value="1">Cabecera Home</asp:ListItem>
            <asp:ListItem Value="2">Enlaces</asp:ListItem>
            </asp:DropDownList></td></tr>
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
        <asp:View ID="vwGrillaDetalle" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevoDetalle" runat="server" Text="Nuevo" OnClick="btnNuevoDetalle_Click" />
                    <asp:Button ID="btnCancelar1" runat="server" Text="Cancelar" CausesValidation="False" OnClick="btnCancelar1_Click" />
                    <asp:TextBox ID="txtControlID" runat="server" ReadOnly="true" Width="80"></asp:TextBox>
                </td></tr>
                <tr><td>
                    <asp:GridView ID="gvControlDetalleLista" runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="rounded-corner" OnSelectedIndexChanged="gvControlDetalleLista_SelectedIndexChanged" PageSize="20" OnRowCommand="gvControlDetalleLista_RowCommand">
                        <Columns>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intControlDetalle" HeaderText="CÓDIGO" ItemStyle-Width="80px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="vchNombre" HeaderText="NOMBRE" ItemStyle-Width="250px"></asp:BoundField>
                            <asp:TemplateField HeaderText="ORDEN">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOrden" runat="server" Width="60" Text='<%#Eval("intOrden") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="chrEstado" HeaderText="ESTADO" ItemStyle-Width="60px"></asp:BoundField>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgGrabar" runat="server" CausesValidation="false" ImageUrl="~/images/save.gif" CommandName="GrabarOrden" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td></tr>
            </table>
        </asp:View>
        <asp:View ID="vwEdicionDetalle" runat="server">
            <table style="text-align:left;">
                <tr><td>
                    <table style="text-align:left;">
                        <tr><td>Codigo</td><td>
                            <asp:Label ID="lblCodigoDetalle" runat="server" Text="0"></asp:Label></td></tr>
                        <tr><td>Orden</td><td>
                            <asp:TextBox ID="txtOrdenDetalle" runat="server" Width="50px"></asp:TextBox></td></tr>
                        <tr><td>Nombre</td><td>
                            <asp:TextBox ID="txtNombreDetalle" runat="server" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese nombre" Text="*" ControlToValidate="txtNombreDetalle"></asp:RequiredFieldValidator>
                            </td></tr>
                        <tr><td>Texto</td><td>
                            <asp:TextBox ID="txtTextoDetalle" runat="server" Width="150px"></asp:TextBox></td></tr>
                        <tr><td>Imagen</td><td>
                            <asp:FileUpload ID="fuImagenDetalle" runat="server" />
                            <asp:Label ID="lblImagenDetalle" runat="server"></asp:Label></td></tr>
                        <tr><td>Imagen Hover</td><td>
                            <asp:FileUpload ID="fuImagenDetalleHover" runat="server" />
                            <asp:Label ID="lblImagenDetalleHover" runat="server"></asp:Label></td></tr>
                        <tr><td>URL</td><td>
                            <asp:TextBox ID="txtURLDetalle" runat="server" Width="250px"></asp:TextBox></td></tr>
                        <tr><td>Script</td><td>
                            <asp:TextBox ID="txtScriptDetalle" runat="server" Width="250px" TextMode="MultiLine" Height="150"></asp:TextBox></td></tr>
                        <tr><td>Tipo</td><td><asp:DropDownList ID="ddlTipoDetalle" runat="server" Width="250px" AutoPostBack="True">
                <asp:ListItem Value="1">Texto</asp:ListItem>
                <asp:ListItem Value="2">Imagen</asp:ListItem>
                </asp:DropDownList></td></tr>
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
