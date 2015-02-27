<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfContactenosLista.aspx.cs" Inherits="FISSAL.wfContactenosLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <asp:GridView ID="gvContactoLista" runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="rounded-corner" PageSize="20" OnSelectedIndexChanged="gvContactoLista_SelectedIndexChanged" OnPageIndexChanging="gvContactoLista_PageIndexChanging" OnRowDataBound="gvContactoLista_RowDataBound">
                <Columns>
                    <asp:BoundField ReadOnly="True" DataField="intCodigo" HeaderText="CÓDIGO" ItemStyle-Width="60px">
                    <ItemStyle Width="60px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="FECHA">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("dtmFechaCreacion") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="vchNombreApellido" HeaderText="NOMBRES" ItemStyle-Width="150px" ReadOnly="True">
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="vchTelefono" HeaderText="TELEFONO" ItemStyle-Width="100px" ReadOnly="True">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="vchEmail" HeaderText="EMAIL" ItemStyle-Width="150px" ReadOnly="True">
                    </asp:BoundField>
                    <asp:BoundField DataField="txtMensaje" HeaderText="MENSAJE" ItemStyle-Width="400px" ReadOnly="True">
                        <ItemStyle Width="400px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="vwEdicion" runat="server">
        </asp:View>
    </asp:MultiView>
</asp:Content>
