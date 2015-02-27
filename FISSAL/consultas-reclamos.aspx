<%@ Page Title="" Language="C#" MasterPageFile="~/mpHome2.Master" UICulture="es-PE" Culture="es-PE" AutoEventWireup="true" CodeBehind="consultas-reclamos.aspx.cs" Inherits="FISSAL.consultas_reclamos" %>

<script runat="server">

    protected void ddlAsegurado_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAsegurado.SelectedIndex == 1)

            txtJustificacion.Enabled = true;
        else
        {
            txtJustificacion.Text = "";
            txtJustificacion.Enabled = false;
            
        }
    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor-desarrollo-noticia">
        <div class="header-notvid-desarrollo-noticias">
        	<ul>
              <li>Consultas y reclamos</li>
            </ul>
      	</div>
        <div class="body-bloque-consultas">
            <div style="float:left; margin-right:15px;">
                <img src="images/1396945737_exclamation-circle-frame_basic_red.png" width="48" height="48" />
            </div>
            <div>
                Con la finalidad de mejorar la calidad de nuestros servicios, FISSAL pone a su disposición el <strong>Formulario de Consultas, Reclamos y Sugerencias</strong>. Su opinión es importante para nosotros, gracias por permitirnos mejorar.
            </div>
            <p></p>
            <h2>Seleccione su opción:</h2>
            <asp:DropDownList ID="ddlOpcion" runat="server" Width="140px">
            </asp:DropDownList>
            <p></p>
            <fieldset>
                <legend>DATOS DEL REPRESENTANTE</legend>
                <div class="divContacto">
                <ul>
                    <li>
                        <div class="reclamos">
                            <div class="reclamos-left">
                                Tipo de documento:
                            </div>
                            <div class="reclamos-right">
                                <asp:DropDownList ID="ddlDocumento" runat="server" Width="140px">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="reclamos">
                            <div class="reclamos-left">
                                Nro.Documento(*):
                            </div>
                        </div>
                        <div class="reclamos-right">
                            <asp:TextBox ID="txtDocumento" runat="server" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" 
                                ErrorMessage="Ingrese documento" Text="(*)" 
                                ControlToValidate="txtDocumento" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    <li>
                        <div class="reclamos">
                            <div class="reclamos-left">
                                Apellido Paterno(*):
                            </div>
                            <div class="reclamos-right">
                                <asp:TextBox ID="txtApPaterno" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvApPaterno" runat="server" 
                                    ErrorMessage="Ingrese apellido paterno" Text="(*)" 
                                    ControlToValidate="txtApPaterno" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="reclamos">
                            <div class="reclamos-left">
                                Apellido Materno(*):
                            </div>
                            <div class="reclamos-right">
                                <asp:TextBox ID="txtApMaterno" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvApMaterno" runat="server" 
                                    ErrorMessage=" Ingrese apellido materno" Text="(*)" 
                                    ControlToValidate="txtApMaterno" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="reclamos">
                            <div class="reclamos-left">
                                Nombres(*):
                                                </div>
                            <div class="reclamos-right">
                                <asp:TextBox ID="txtNombres" runat="server" Width="380px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNombres" runat="server" 
                                    ErrorMessage="Ingrese nombres" Text="(*)" ControlToValidate="txtNombres" 
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </li>
                </ul>
                </div>
            </fieldset>
            <p></p>
            <fieldset>
                <legend>DATOS DEL ASEGURADO</legend>
                <div class="divContacto">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <ul>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            ¿Eres asegurado del SIS?
                        </div>
                        <div class="reclamos-right">
                            <asp:DropDownList ID="ddlAsegurado" runat="server" Width="140px" 
                                onselectedindexchanged="ddlAsegurado_SelectedIndexChanged" 
                                AutoPostBack="True">
                                <asp:ListItem Value="1">SI</asp:ListItem>
                                <asp:ListItem Value="0">NO</asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Si es <strong>NO</strong>, Especifique
                        </div>
                        <div class="reclamos-right">
                            <asp:TextBox ID="txtJustificacion" runat="server" Width="400" Height="150" 
                                TextMode="MultiLine" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Nombres y Apellidos(*)
                        </div>
                        <div class="reclamos-right">
                            <asp:TextBox ID="txtNombreApellidos" runat="server" Width="400"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvApellidosNombres" runat="server" ErrorMessage="Ingrese nombres y apellidos" Text="(*)" ControlToValidate="txtNombreApellidos" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Diagnóstico
                        </div>
                        <div class="reclamos-right">
                            <asp:DropDownList ID="ddlTipoDiagnostico" runat="server" Width="200px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Teléfono y/o Celular (*)
                        </div>
                        <div class="reclamos-right">
                            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtTelefono" runat="server" ErrorMessage="Ingrese número telefónico" Text="(*)" ControlToValidate="txtTelefono" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Correo Electrónico (*)
                        </div>
                        <div class="reclamos-right">
                            <asp:TextBox ID="txtEmail" runat="server" Width="400px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtEmail" runat="server" ErrorMessage="Ingrese Email" Text="(*)" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Departamento
                        </div>
                        <div class="reclamos-right">
                            <asp:DropDownList ID="ddlDepartamento" runat="server" Width="200" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <h2></h2>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Provincia
                        </div>
                        <div class="reclamos-right">
                            <asp:DropDownList ID="ddlProvincia" runat="server" Width="200" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                    </asp:DropDownList>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Distrito
                        </div>
                        <div class="reclamos-right">
                            <asp:DropDownList ID="ddlDistrito" runat="server" Width="200">
                            </asp:DropDownList>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Dirección (*)
                        </div>
                        <div class="reclamos-right">
                            <asp:TextBox ID="txtDireccion" runat="server" Width="400px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtDireccion" runat="server" ErrorMessage="Ingrese la dirección" Text="(*)" ControlToValidate="txtDireccion" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Detalle su Requerimiento(*)
                        </div>
                        <div class="reclamos-right">
                            <asp:TextBox ID="txtMensaje" runat="server" Width="400" Height="300" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMensaje" runat="server" ErrorMessage="Ingrese requerimiento" Text="(*)" ControlToValidate="txtMensaje" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
      </div>
     </fieldset>


<!-- INGRESO DE UBIGEO -->
            <p></p>
           <fieldset>
             <legend>DATOS DEL ESTABLECIMIENTO DE SALUD</legend>
                <div class="divContacto">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                   <ul>
                    <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            DeparT. Establecimiento
                        </div>
                        <div class="reclamos-right">
                            <asp:DropDownList ID="ddlDepartamentoIPRES" runat="server" Width="200" AutoPostBack="True" OnSelectedIndexChanged="ddlDepartamentoIPRES_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Prov. Establecimiento
                        </div>
                        <div class="reclamos-right">
                            <asp:DropDownList ID="ddlProvinciaIPRES" runat="server" Width="200" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaIPRES_SelectedIndexChanged">
                    </asp:DropDownList>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Dist. Establecimiento
                        </div>
                        <div class="reclamos-right">
                            <asp:DropDownList ID="ddlDistritoIPRES" runat="server" Width="200">
                            </asp:DropDownList>
                        </div>
                    </div>
                </li>

<!-- FIN UBIGEO -->

                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Establecimiento de Salud(*)
                        </div>
                        <div class="reclamos-right">
                            <asp:TextBox ID="txtEstablecimiento" runat="server" Width="400"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEstablecimiento" runat="server" ErrorMessage="Ingrese establecimiento" Text="(*)" ControlToValidate="txtEstablecimiento" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlEstablecimiento" runat="server" AutoPostBack="True" Height="21px" OnSelectedIndexChanged="ddlEstablecimiento_SelectedIndexChanged" Width="438px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                            Fecha de ocurrencia(*)
                        </div>
                        <div class="reclamos-right">
                            <asp:TextBox ID="txtFechaOcurrencia" runat="server" Width="150"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtFechaOcurrencia_CalendarExtender" runat="server" TargetControlID="txtFechaOcurrencia" Format="dd/MM/yyyy">
                            </ajaxToolkit:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ErrorMessage="Ingrese fecha de ocurrencia" Text="*" ControlToValidate="txtFechaOcurrencia"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="reclamos">
                        <div class="reclamos-left">
                        </div>
                        <div class="reclamos-right">
                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="submit" Width="100" OnClick="btnEnviar_Click" />
                        </div>
                    </div>
                </li>
                <li>
                    <p>
                        <asp:Label ID="DisplayMessage" runat="server" Visible="false" />
                    </p>  
                </li>
            </ul>
            </ContentTemplate>
        </asp:UpdatePanel>
      </div>
    </fieldset>
            <asp:ValidationSummary ID="vsErrores" runat="server" ShowMessageBox="True" ShowSummary="False" />
        </div>
    </div>
</asp:Content>
