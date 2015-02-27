<%@ Page Title="" Language="C#" MasterPageFile="~/mpHome2.Master" AutoEventWireup="true" CodeBehind="contactenos.aspx.cs" Inherits="FISSAL.contactenos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenedor-contactenos">
        <div class="header-notvid-desarrollo-noticias">
            <ul>
                <li>Contáctenos</li>
            </ul>
        </div>
        <div class="body-bloque-consultas">
            <fieldset>
                <legend>INGRESE DATOS</legend>
                <div class="divContacto">
                <ul>
                    <li>
                        <div class="contactenos">
                            <div class="contactenos-left">
                                Nombres:
                            </div>
                            <div class="contactenos-right">
                                <asp:TextBox ID="txtNombres" runat="server" Width="400px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNombres" runat="server" ErrorMessage="Ingrese nombres" Text="*" ControlToValidate="txtNombres"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="contactenos">
                            <div class="contactenos-left">
                                Email:
                            </div>
                            <div class="contactenos-right">
                                <asp:TextBox ID="txtEmail" runat="server" Width="400px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Ingrese email" Text="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Ingrese email válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="contactenos">
                            <div class="contactenos-left">
                                Celular:
                            </div>
                            <div class="contactenos-right">
                                <asp:TextBox ID="txtCelular" runat="server" Width="400px"></asp:TextBox>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="contactenos">
                            <div class="contactenos-left">
                                Mensaje:
                            </div>
                            <div class="contactenos-right">
                                <asp:TextBox ID="txtMensaje" runat="server" Width="400" Height="300" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMensaje" runat="server" ErrorMessage="Ingrese mensaje" Text="*" ControlToValidate="txtMensaje"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="contactenos">
                            <div class="contactenos-left">
                            </div>
                            <div class="contactenos-right">
                                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="submit" Width="100" OnClick="btnEnviar_Click" />
                            </div>
                            <div class="clear"></div>
                        </div>
                    </li>
                    <li>
                        <asp:ValidationSummary ID="vsErrores" runat="server" ShowMessageBox="True" ShowSummary="False" />
                        <p>
                            <asp:Label ID="DisplayMessage" runat="server" Visible="false" />
                        </p>  
                    </li>
                </ul>
                </div>
            </fieldset>
            <div class="estamos">
                <p></p>
                <h2>Estamos en:</h2>
                <p>Dirección : Calle Ugarte y Moscoso 450 Dpto. 501, San Isidro - Lima Perú. Referencia, a dos cuadras del cruce de Salaverry con Javier Prado</p>
                <p>Teléfonos : (511) 628-7092 / (511) 628-7093</p>
                <p>Correo electrónico:   fissal@sis.gob.pe</p>
            </div>
            <div class="mapa">
                <h2>Ubícanos en el mapa</h2>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3901.188399699656!2d-77.05773305000004!3d-12.099251299999983!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x9105c9b31d5fae25%3A0xd7f15200a3278a23!2sCalle+M.Ugarte+y+Moscoso!5e0!3m2!1ses!2s!4v1395285580334" width="700" height="450" frameborder="0" style="border:0"></iframe>
            </div>
        </div>
    </div>
</asp:Content>
