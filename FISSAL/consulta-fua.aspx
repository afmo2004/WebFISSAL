<%@ Page Title="" Language="C#" MasterPageFile="~/MPHome.Master" UICulture="es-PE" Culture="es-PE" AutoEventWireup="true" CodeBehind="consulta-fua.aspx.cs" Inherits="FISSAL.consulta_fua" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="text-align:left;">
            <asp:Button ID="btnExportar" Text="Exportar" runat="server" OnClick="btnExportar_Click" />
        </div>
        <asp:GridView ID="gvTransferenciaFUA" runat="server" CssClass="rounded-corner-FUA" AutoGenerateColumns="False" OnRowDataBound="gvTransferenciaFUA_RowDataBound">
                <Columns>
                    <asp:BoundField ReadOnly="True" DataField="CodigoEESS" HeaderText="Código EESS" />
                    <asp:BoundField ReadOnly="True" DataField="NombreEESS" HeaderText="EESS" ItemStyle-Width="200px" />
                    <asp:BoundField ReadOnly="True" DataField="Categoria" HeaderText="Categoría" />
                    <asp:BoundField ReadOnly="True" DataField="Servicio" HeaderText="Servicio" ItemStyle-Width="20px" />
                    <asp:BoundField ReadOnly="True" DataField="Fua" HeaderText="FUA" ItemStyle-Width="120px" />
                    <asp:BoundField ReadOnly="True" DataField="idnumreg" HeaderText="Id Atención" />
                    <asp:TemplateField HeaderText="Fecha AT.">
                        <ItemTemplate>
                            <asp:Label ID="lblFechaAtencion" runat="server" Text='<%# Bind("fechaatencion") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:BoundField ReadOnly="True" DataField="valor_neto_fissal" HeaderText="Valor Neto" DataFormatString="{0:F4}" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField ReadOnly="True" DataField="valor_servicio_fissal" HeaderText="Valor Servicio" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField ReadOnly="True" DataField="valorconsumo_fissal" HeaderText="Valor Consumo" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField ReadOnly="True" DataField="valor_bruto_fissal" HeaderText="Valor Bruto" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField ReadOnly="True" DataField="ValorNeto_Medicamentos_FISSAL" HeaderText="Valor Neto Med" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField ReadOnly="True" DataField="ValorNeto_Insumos_FISSAL" HeaderText="Valor Neto Ins" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField ReadOnly="True" DataField="ValorNeto_procedimientos_FISSAL" HeaderText="Valor Neto Proc" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField ReadOnly="True" DataField="Diagnostico" HeaderText="Cod Diagn." />
                    <asp:BoundField ReadOnly="True" DataField="DiagnosticoDescripcion" HeaderText="Diagnóstico" ItemStyle-Width="200px" />
                    <asp:BoundField ReadOnly="True" DataField="ProgramaId" HeaderText="Prog. Id" />
                    <asp:BoundField ReadOnly="True" DataField="DescripcionPrograma" HeaderText="Programa" ItemStyle-Width="250px" />
                    <asp:BoundField ReadOnly="True" DataField="ProductoId" HeaderText="Producto Id" />
                    <asp:BoundField ReadOnly="True" DataField="DescripcionProducto" HeaderText="Producto" ItemStyle-Width="250px" />
                    <asp:BoundField ReadOnly="True" DataField="ActividadId" HeaderText="Actividad Id" />
                    <asp:BoundField ReadOnly="True" DataField="PeriodoTransferencia" HeaderText="Período" />
                    <asp:BoundField ReadOnly="True" DataField="Rj" HeaderText="RJ" />
                </Columns>
            </asp:GridView>
</asp:Content>
