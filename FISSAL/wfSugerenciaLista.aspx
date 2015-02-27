<%@ Page Title="" Language="C#" MasterPageFile="~/mpAdmin.Master" AutoEventWireup="true" CodeBehind="wfSugerenciaLista.aspx.cs" Inherits="FISSAL.wfSugerenciaLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mvwPrincipal" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwGrilla" runat="server">
            <asp:GridView ID="gvSugerenciaLista" runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="rounded-corner" PageSize="20" OnSelectedIndexChanged="gvSugerenciaLista_SelectedIndexChanged" OnPageIndexChanging="gvSugerenciaLista_PageIndexChanging" OnRowDataBound="gvSugerenciaLista_RowDataBound">
                <Columns>
                    <asp:TemplateField ShowHeader="false" ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:ImageButton id="imgEditar" runat="server" CausesValidation="false" ImageUrl="~/images/Grilla.Flecha.gif" CommandName="Select"></asp:ImageButton>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField ReadOnly="True" DataField="intCodigo" HeaderText="CÓDIGO" ItemStyle-Width="80px">
                    <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="FECHA OCU.">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("dtmFechaOcurrencia") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="vchNombreAsegurado" HeaderText="PACIENTE" ItemStyle-Width="200px" ReadOnly="True">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="vchTelefono" HeaderText="TELEFONO" ItemStyle-Width="100px" ReadOnly="True">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="vchCorreo" HeaderText="EMAIL" ItemStyle-Width="200px" ReadOnly="True">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="vwEdicion" runat="server">
            <asp:Button ID="btnCancelar" runat="server" Text="Regresar a Listado" OnClick="btnCancelar_Click" CausesValidation="False" />
            <fieldset style="width:700px;">
                <legend>DATOS DEL REPRESENTANTE</legend>
                <table style="text-align:left;">
                    <tr><td>Codigo</td><td>
                        <asp:Label ID="lblCodigo" runat="server" Text="0"></asp:Label></td></tr>
                    <tr><td>Tipo</td><td>
                        <asp:DropDownList ID="ddlTipo" Enabled="false" runat="server" Width="200px"></asp:DropDownList>
                        </td></tr>
                    <tr><td>Tipo Doc.</td><td>
                        <asp:DropDownList ID="ddlTipoDocumento" Enabled="false" runat="server" Width="200px"></asp:DropDownList>
                        </td></tr>
                    <tr><td>Documento</td><td>
                        <asp:TextBox ID="txtNumeroDocumento" ReadOnly="true" runat="server" Width="150px"></asp:TextBox>
                        </td></tr>
                    <tr><td>Ap. Paterno</td><td>
                        <asp:TextBox ID="txtApPaterno" ReadOnly="true" runat="server" Width="200px"></asp:TextBox>
                        </td></tr>
                    <tr><td>Ap. Materno</td><td>
                        <asp:TextBox ID="txtApMaterno" ReadOnly="true" runat="server" Width="200px"></asp:TextBox>
                        </td></tr>
                    <tr><td>Nombres</td><td>
                        <asp:TextBox ID="txtNombres" ReadOnly="true" runat="server" Width="200px"></asp:TextBox>
                        </td></tr>
                    
                
                </table>
            </fieldset>
            <fieldset style="width:700px;">
                <legend>DATOS DEL ASEGURADO</legend>
                <table style="text-align:left;">
                    <tr><td>¿Asegurado al SIS?</td><td>
                        <asp:DropDownList ID="ddlAsegurado" Enabled="false" runat="server" Width="140px">
                            <asp:ListItem Value="1">SI</asp:ListItem>
                            <asp:ListItem Value="0">NO</asp:ListItem>
                        </asp:DropDownList>
                    </td></tr>
                    <tr><td>Justificación</td><td>
                        <asp:TextBox ID="txtJustificacion" ReadOnly="true" runat="server" Width="400" Height="150" TextMode="MultiLine"></asp:TextBox>
                    </td></tr>
                    <tr><td>Paciente</td><td>
                        <asp:TextBox ID="txtPaciente" ReadOnly="true" runat="server" Width="400"></asp:TextBox>
                    </td></tr>
                    <tr><td>Diagnóstico</td><td>
                        <asp:DropDownList ID="ddlTipoDiagnostico" Enabled="false" runat="server" Width="200px"></asp:DropDownList>
                    </td></tr>
                    <tr><td>Teléfono</td><td>
                        <asp:TextBox ID="txtTelefono" ReadOnly="true" runat="server" Width="200"></asp:TextBox>
                    </td></tr>
                    <tr><td>Email</td><td>
                        <asp:TextBox ID="txtEmail" ReadOnly="true" runat="server" Width="400"></asp:TextBox>
                    </td></tr>
                    <tr><td>Ubigeo</td><td>
                        <asp:TextBox ID="txtUbigeo" ReadOnly="true" runat="server" Width="200"></asp:TextBox>
                    </td></tr>
                    <tr><td>Dirección</td><td>
                        <asp:TextBox ID="txtDireccion" ReadOnly="true" runat="server" Width="400"></asp:TextBox>
                    </td></tr>
                    <tr><td>Mensaje</td><td>
                        <asp:TextBox ID="txtMensaje" ReadOnly="true" runat="server" Width="400" TextMode="MultiLine" Height="150"></asp:TextBox>
                    </td></tr>
                    <tr><td>Establecimiento Salud</td><td>
                        <asp:TextBox ID="txtEstablecimiento" ReadOnly="true" runat="server" Width="400"></asp:TextBox>
                    </td></tr>
                    <tr><td>Fecha Ocurrencia</td><td>
                        <asp:TextBox ID="txtFechaOcurrencia" ReadOnly="true" runat="server" Width="100"></asp:TextBox>
                    </td></tr>
                </table>
            </fieldset>
        </asp:View>
    </asp:MultiView>
</asp:Content>
