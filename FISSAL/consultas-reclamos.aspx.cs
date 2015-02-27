using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using FISSAL.Datos;
using FISSAL.Entidad;
using FISSAL.Negocio;
using System.Windows.Forms;
//using FISSAL

namespace FISSAL
{
    public partial class consultas_reclamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Consultas y reclamos | FISSAL";
            if (!IsPostBack)
            {
                CargarCombos();
                CargarDepartamentos();
                CargarDepartamentosIPRES();
                //ddlDepartamento.SelectedIndex = 14;
                //ddlProvincia.SelectedIndex = 7;
                //ddlDistrito.SelectedIndex = 0;
            }
        }

        protected void CargarCombos()
        {
            ParametroDetalleNegocio obj = new ParametroDetalleNegocio();
            ddlOpcion.DataSource = obj.ListarParametroDetalle(3, true);
            ddlOpcion.DataTextField = "vchDescripcion";
            ddlOpcion.DataValueField = "vchValor";
            ddlOpcion.DataBind();

            ddlDocumento.DataSource = obj.ListarParametroDetalle(4, true);
            ddlDocumento.DataTextField = "vchDescripcion";
            ddlDocumento.DataValueField = "vchValor";
            ddlDocumento.DataBind();

            ddlTipoDiagnostico.DataSource = obj.ListarParametroDetalle(5, true);
            ddlTipoDiagnostico.DataTextField = "vchDescripcion";
            ddlTipoDiagnostico.DataValueField = "vchValor";
            ddlTipoDiagnostico.DataBind();
        }

        protected void CargarDepartamentos()
        {
            UbigeoNegocio obj = new UbigeoNegocio();
            List<Ubigeo> lista = obj.ListarDepartamentos();
            ddlDepartamento.DataSource = lista;
            ddlDepartamento.DataValueField = "departamentoId";
            ddlDepartamento.DataTextField = "descripcionUbigeo";
            ddlDepartamento.DataBind();

            CargarProvincias(ddlDepartamento.SelectedValue);
        }

        protected void CargarProvincias(string departamentoId)
        {
            UbigeoNegocio obj = new UbigeoNegocio();
            List<Ubigeo> lista = obj.ListarProvincias(departamentoId);
            ddlProvincia.DataSource = lista;
            ddlProvincia.DataValueField = "provinciaId";
            ddlProvincia.DataTextField = "descripcionUbigeo";
            ddlProvincia.DataBind();

            CargarDistritos(ddlDepartamento.SelectedValue, ddlProvincia.SelectedValue);

        }

        protected void CargarDistritos(string departamentoId, string provinciaId)
        {
            UbigeoNegocio obj = new UbigeoNegocio();
            List<Ubigeo> lista = obj.ListarDistritos(departamentoId, provinciaId);
            ddlDistrito.DataSource = lista;
            ddlDistrito.DataValueField = "distritoId";
            ddlDistrito.DataTextField = "descripcionUbigeo";
            ddlDistrito.DataBind();
        }

        // FUNCION PARA LLENAR LOS DATACOMBOS

        protected void CargarDepartamentosIPRES()
        {
            UbigeoNegocio obj1 = new UbigeoNegocio();
            List<Ubigeo> lista1 = obj1.ListarDepartamentos();
            ddlDepartamentoIPRES.DataSource = lista1;
            ddlDepartamentoIPRES.DataValueField = "departamentoId";
            ddlDepartamentoIPRES.DataTextField = "descripcionUbigeo";
            ddlDepartamentoIPRES.DataBind();

            CargarProvinciasIPRES(ddlDepartamentoIPRES.SelectedValue);
        }

        protected void CargarProvinciasIPRES(string departamentoId)
        {
            UbigeoNegocio obj2 = new UbigeoNegocio();
            List<Ubigeo> lista2 = obj2.ListarProvincias(departamentoId);
            ddlProvinciaIPRES.DataSource = lista2;
            ddlProvinciaIPRES.DataValueField = "provinciaId";
            ddlProvinciaIPRES.DataTextField = "descripcionUbigeo";
            ddlProvinciaIPRES.DataBind();

            CargarDistritosIPRES(ddlDepartamentoIPRES.SelectedValue, ddlProvinciaIPRES.SelectedValue);

        }

        protected void CargarDistritosIPRES(string departamentoId, string provinciaId)
        {
            UbigeoNegocio obj3 = new UbigeoNegocio();
            List<Ubigeo> lista3 = obj3.ListarDistritos(departamentoId, provinciaId);
            ddlDistritoIPRES.DataSource = lista3;
            ddlDistritoIPRES.DataValueField = "distritoId";
            ddlDistritoIPRES.DataTextField = "descripcionUbigeo";
            ddlDistritoIPRES.DataBind();

            //AppConfig.CadenaConexionFUA();
            ddlEstablecimiento.DataSource = AppConfig.ConsultarProcedimiento("sp_EstablecimientoXubigeo", ddlDepartamentoIPRES.SelectedValue, ddlProvinciaIPRES.SelectedValue, ddlDistritoIPRES.SelectedValue);
        }

        //FIN DE LLENAR DATACOMBOS



        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProvincias(ddlDepartamento.SelectedValue);
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDistritos(ddlDepartamento.SelectedValue, ddlProvincia.SelectedValue);
            //MessageBox.Show(ddlDepartamento.SelectedValue);
        }


        //COLOCADO 23/02/2015

        protected void ddlDepartamentoIPRES_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProvinciasIPRES(ddlDepartamentoIPRES.SelectedValue);
        }

        protected void ddlProvinciaIPRES_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDistritosIPRES(ddlDepartamentoIPRES.SelectedValue, ddlProvinciaIPRES.SelectedValue);
        }

        //FIN DE COLOCADO

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            SendMail();
            DisplayMessage.Text = "Mensaje enviado satisfactoriamente";
            DisplayMessage.Visible = true;
        }

        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            var fromAddress = AppConfig.Email();
            // any address where the email will be sending
            var toAddress = AppConfig.EmailSend();
            //Password of your gmail address
            var fromPassword = AppConfig.PasswordEmail();
            // Passing the values and make a email formate to display
            string subject = "CONSULTAS Y RECLAMOS";
            string body = "From: " + txtNombres.Text + "\n";
            body += "Email: " + txtEmail.Text + "\n";
            body += "Subject: " + subject + "\n";
            body += "REPRESENTANTE: \n";
            if (ddlDocumento.SelectedValue=="1")
                body += "DNI: " + txtDocumento.Text + "\n";
            else
                body += "CI: " + txtDocumento.Text + "\n";
            body += "Apellido Paterno: " + txtApPaterno.Text + " \n";
            body += "Apellido Materno: " + txtApMaterno.Text + " \n";
            body += "Nombres: " + txtNombres.Text + " \n";
            body += "ASEGURADO: \n";
            if (ddlAsegurado.SelectedValue == "1")
                body += "Asegurado al SIS: \n";
            else
            {
                body += "No está asegurado al SIS: \n";
                body += "Justificación: " + txtJustificacion.Text + " \n";
            }
            body += "Apellidos y nombres: " + txtNombreApellidos.Text + " \n";
            string strTipoDiagnostico = ddlTipoDiagnostico.SelectedValue;
            switch (strTipoDiagnostico)
            {
                case "1":
                    body += "Cáncer de mama \n";
                    break;
                case "2":
                    body += "Cáncer de estómago \n";
                    break;
                case "3":
                    body += "Cáncer de próstata \n";
                    break;
                case "4":
                    body += "Cáncer de colon \n";
                    break;
                case "5":
                    body += "Cáncer de cuello uterino \n";
                    break;
                case "6":
                    body += "Linfoma \n";
                    break;
                case "7":
                    body += "Leucemia \n";
                    break;
                case "8":
                    body += "Insuficiencia renal \n";
                    break;
            }
            body += "Teléfono y/o Celular: " + txtTelefono.Text + " \n";
            body += "Email: " + txtEmail.Text + " \n";
            body += "Ubigeo: " + ddlDepartamento.SelectedValue + ddlProvincia.SelectedValue + ddlDistrito.SelectedValue + " \n";
            body += "Dirección: " + txtDireccion.Text + " \n";
            body += "Establecimiento: " + txtEmail.Text + " \n";
            body += "Fecha ocurrencia: " + txtFechaOcurrencia.Text + " \n";
            body += "Mensaje: \n" + txtMensaje.Text + "\n";
            //INSERTAR REGISTRO TABLA
            SugerenciaNegocio obj = new SugerenciaNegocio();
            int intTipo = Int32.Parse(ddlOpcion.SelectedValue.ToString());
            string chrTipoDocumento = ddlDocumento.SelectedValue;
            string vchNumeroDocumento = txtDocumento.Text;
            string vchApellidoPaterno = txtApPaterno.Text;
            string vchApellidoMaterno = txtApMaterno.Text;
            string vchNombres = txtNombres.Text;
            string chrAsegurado = ddlAsegurado.SelectedValue;
            string vchEspecificacion = txtJustificacion.Text;
            string vchNombresApellidos = txtNombreApellidos.Text;
            string chrTipoDiagnostico = ddlTipoDiagnostico.SelectedValue;
            string vchTelefono = txtTelefono.Text;
            string vchCorreo = txtEmail.Text;
            string vchUbigeo = ddlDepartamento.SelectedValue + ddlProvincia.SelectedValue + ddlDistrito.SelectedValue;
            string vchDireccion = txtDireccion.Text;
            string vchMensaje = txtMensaje.Text;
            string vchEstablecimiento = txtEstablecimiento.Text;
            DateTime dtmFechaOcurrencia = DateTime.Parse(txtFechaOcurrencia.Text);
            Sugerencia tabla = new Sugerencia(0, intTipo, chrTipoDocumento, vchNumeroDocumento,
                vchApellidoPaterno, vchApellidoMaterno, vchNombres, chrAsegurado, vchEspecificacion,
                vchNombresApellidos, chrTipoDiagnostico, vchTelefono, vchCorreo, vchUbigeo,
                vchDireccion, vchMensaje, vchEstablecimiento, dtmFechaOcurrencia);
            obj.InsertarSugerencia(tabla);
            //// smtp settings
            //var smtp = new System.Net.Mail.SmtpClient();
            //{
            //    smtp.Host = AppConfig.EmailHost();
            //    smtp.Port = AppConfig.EmailHostPort();
            //    smtp.EnableSsl = true;
            //    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            //    smtp.Timeout = 20000;
            //}
            //// Passing values to smtp object
            //smtp.Send(fromAddress, toAddress, subject, body);
        }

        protected void ddlEstablecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvBuscarHabilitacion.DataSource = Datos.ConsultarProcedimiento("upCatastro_BuscaTipoHabilitacion", txtBuscar.Text.Trim(), "");
            //ddlEstablecimiento.DataSource = Datos.BaseData.ConsultarProcedimiento("sp_EstablecimientoXubigeo", ddlDepartamentoIPRES.SelectedValue, ddlProvinciaIPRES.SelectedValue, ddlDistritoIPRES.SelectedValue);

            //MessageBox.Show(ddlDepartamento.DataValueField);
        }
 }
}