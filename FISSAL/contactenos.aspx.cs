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

namespace FISSAL
{
    public partial class contactenos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Contáctenos | FISSAL";
        }

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
            string subject = "CONTACTENOS";
            string body = "De: " + txtNombres.Text + "\n";
            body += "Correo: " + txtEmail.Text + "\n";
            body += "Asunto: CONTACTENOS" + "\n";
            body += "Mensaje: \n" + txtMensaje.Text + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = AppConfig.EmailHost();
                smtp.Port = AppConfig.EmailHostPort();
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            
            //INSERTAR EN TABLA
            ContactoNegocio obj = new ContactoNegocio();
            Contacto contacto = new Contacto();
            contacto.intCodigo = 0;
            contacto.vchNombreApellido = txtNombres.Text;
            contacto.vchEmail = txtEmail.Text;
            contacto.vchTelefono = txtCelular.Text;
            contacto.txtMensaje = txtMensaje.Text;
            
            obj.InsertarContactenos(contacto);

            // Passing values to smtp object
            //smtp.Send(fromAddress, toAddress, subject, body);
        }

    }
}