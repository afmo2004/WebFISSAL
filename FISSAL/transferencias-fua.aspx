<%@ Page Title="" Language="C#" MasterPageFile="~/mpHome2.Master" AutoEventWireup="true" CodeBehind="transferencias-fua.aspx.cs" Inherits="FISSAL.transferencias_fua" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor-desarrollo-noticia">
        <div class="header-notvid-desarrollo-noticias">
        	<ul>
              <li><a href="#">Transferencias FUA</a></li>
            </ul>
   	    </div>
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
        <div class="body-bloque-desarrollo-noticia">
            <h1>Transferencias por formato único de atención</h1>
            <p></p>
            <div class="fua">
           <div class="fua-left">
           AÑO: <asp:DropDownList ID="ddlAnio" CssClass="combo" runat="server">
                </asp:DropDownList>
           </div>
           <div class="fua-right">
           MES: <asp:DropDownList ID="ddlMes" CssClass="combo" runat="server">
                    <asp:ListItem Value="01" Text="Enero"></asp:ListItem>
                    <asp:ListItem Value="02" Text="Febrero"></asp:ListItem>
                    <asp:ListItem Value="03" Text="Marzo"></asp:ListItem>
                    <asp:ListItem Value="04" Text="Abril"></asp:ListItem>
                    <asp:ListItem Value="05" Text="Mayo"></asp:ListItem>
                    <asp:ListItem Value="06" Text="Junio"></asp:ListItem>
                    <asp:ListItem Value="07" Text="Julio"></asp:ListItem>
                    <asp:ListItem Value="08" Text="Agosto"></asp:ListItem>
                    <asp:ListItem Value="09" Text="Setiembre"></asp:ListItem>
                    <asp:ListItem Value="10" Text="Octubre"></asp:ListItem>
                    <asp:ListItem Value="11" Text="Noviembre"></asp:ListItem>
                    <asp:ListItem Value="12" Text="Diciembre"></asp:ListItem>
                </asp:DropDownList>
           </div>
           <div class="clear"></div>
           <p></p>
           <div class="fua">
           DISA: <asp:DropDownList ID="ddlDisa" CssClass="combo" runat="server" Width="500" OnSelectedIndexChanged="ddlDisa_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
           </div>
           </div>
            <p></p>
            <div class="fua">
                UNIDAD EJECUTORA:<br />
                <asp:DropDownList ID="ddlUnidadEjecutora" CssClass="combo" runat="server" Width="640"></asp:DropDownList>
            </div>
            
            <div class="boton-consulta">
                <asp:Button ID="btnBuscar" Text="Consultar" runat="server" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnExportar" Text="Exportar" runat="server" Visible="false" OnClick="btnExportar_Click" />
            </div>
            <p></p>
            <div style="width:680px;overflow:auto;">
            <asp:GridView ID="gvTransferenciaFUA" runat="server" CssClass="rounded-corner" AutoGenerateColumns="False" OnRowDataBound="gvTransferenciaFUA_RowDataBound">
                <Columns>
                    <asp:BoundField ReadOnly="True" DataField="CodigoEESS" HeaderText="CODIGO EESS" />
                    <asp:BoundField ReadOnly="True" DataField="NombreEESS" HeaderText="EESS" ItemStyle-Width="200px" />
                    <asp:BoundField ReadOnly="True" DataField="Categoria" HeaderText="CATEGORIA" />
                    <asp:BoundField ReadOnly="True" DataField="Servicio" HeaderText="SERVICIO" />
                    <asp:BoundField ReadOnly="True" DataField="Fua" HeaderText="FUA" />
                    <asp:BoundField ReadOnly="True" DataField="idnumreg" HeaderText="ID ATENCION" />
                    <asp:TemplateField HeaderText="FECHA AT.">
                        <ItemTemplate>
                            <asp:Label ID="lblFechaAtencion" runat="server" Text='<%# Bind("fechaatencion") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:BoundField ReadOnly="True" DataField="valor_neto_fissal" HeaderText="VALOR NETO" />
                    <asp:BoundField ReadOnly="True" DataField="valor_servicio_fissal" HeaderText="VALOR SERVICIO" />
                    <asp:BoundField ReadOnly="True" DataField="valorconsumo_fissal" HeaderText="VALOR CONSUMO" />
                    <asp:BoundField ReadOnly="True" DataField="valor_bruto_fissal" HeaderText="VALOR BRUTO" />
                    <asp:BoundField ReadOnly="True" DataField="ValorNeto_Medicamentos_FISSAL" HeaderText="VALOR NETO MED" />
                    <asp:BoundField ReadOnly="True" DataField="ValorNeto_Insumos_FISSAL" HeaderText="VALOR NETO INS" />
                    <asp:BoundField ReadOnly="True" DataField="ValorNeto_procedimientos_FISSAL" HeaderText="VALOR NETO PROC" />
                    <asp:BoundField ReadOnly="True" DataField="Diagnostico" HeaderText="COD DIAGN" />
                    <asp:BoundField ReadOnly="True" DataField="DiagnosticoDescripcion" HeaderText="DIAGNOSTICO" />
                    <asp:BoundField ReadOnly="True" DataField="ProgramaId" HeaderText="PROGRAMA ID" />
                    <asp:BoundField ReadOnly="True" DataField="DescripcionPrograma" HeaderText="PROGRAMA" ItemStyle-Width="300px" />
                    <asp:BoundField ReadOnly="True" DataField="ProductoId" HeaderText="PRODUCTO ID" />
                    <asp:BoundField ReadOnly="True" DataField="DescripcionProducto" HeaderText="PRODUCTO" ItemStyle-Width="200px" />
                    <asp:BoundField ReadOnly="True" DataField="ActividadId" HeaderText="ACTIVIDAD ID" />
                </Columns>
            </asp:GridView>
            </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
