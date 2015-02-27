<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfAsignarOpcion.aspx.cs" Inherits="FISSAL.wfAsignarOpcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="text-align:left;">
        <tr><td>
            <asp:DropDownList ID="ddlPerfil" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlPerfil_SelectedIndexChanged">
            </asp:DropDownList>
        </td></tr>
    </table>
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <table style="text-align:left;">
                <tr><td>
                    <asp:TreeView ID="tvwOpciones" runat="server" ShowCheckBoxes="All">
                    </asp:TreeView>
                </td></tr>
                <tr><td>
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                </td></tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
