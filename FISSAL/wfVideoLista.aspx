<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="wfVideoLista.aspx.cs" Inherits="FISSAL.wfVideoLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" /></td></tr>
                <tr><td>
                    <asp:GridView ID="gvVideoLista" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvVideoLista_PageIndexChanging" OnSelectedIndexChanged="gvVideoLista_SelectedIndexChanged" PageSize="20">
                        <Columns>
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="intVideo" HeaderText="CÓDIGO" ItemStyle-Width="80px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="vchTitulo" HeaderText="TITULO" ItemStyle-Width="350px"></asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="dtmFechaPublicacion" HeaderText="FECHA" ItemStyle-Width="350px"></asp:BoundField>
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
                    <tr><td>Título</td><td>
                        <asp:TextBox ID="txtTitulo" runat="server" Width="500px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Ingrese titulo" Text="*" ControlToValidate="txtTitulo"></asp:RequiredFieldValidator>
                        </td></tr>
                    <tr><td>Descripción</td><td>
                        <asp:TextBox ID="txtLead" runat="server" Height="150px" Width="500px" TextMode="MultiLine"></asp:TextBox>
                        </td></tr>
                    <tr><td>Script</td><td>
                        <asp:TextBox ID="txtScript" runat="server" Height="150px" Width="500px" TextMode="MultiLine"></asp:TextBox>
                        </td></tr>
                    <tr><td>URL</td><td>
                        <asp:TextBox ID="txtURL" runat="server" Width="500px"></asp:TextBox>
                        </td></tr>
                    <tr><td>Fecha Publicación</td><td>
                        <asp:TextBox ID="txtFechaPublicacion" runat="server" Width="200px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtFechaPublicacion_CalendarExtender" runat="server" 
                                TargetControlID="txtFechaPublicacion" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
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
