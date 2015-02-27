using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Contacto
    {
        public Contacto() { }

        public Contacto(int intCodigo, string vchNombreApellido, string vchEmail, string vchTelefono, string txtMensaje,DateTime dtmFechaCreacion) 
        {
            this.intCodigo = intCodigo;
            this.vchNombreApellido = vchNombreApellido;
            this.vchEmail = vchEmail;
            this.vchTelefono = vchTelefono;
            this.txtMensaje = txtMensaje;
            this.dtmFechaCreacion = dtmFechaCreacion;
        }

        private int _intCodigo;
        public int intCodigo
        {
            get { return _intCodigo; }
            set { _intCodigo = value; }
        }

        private string _vchNombreApellido;
        public string vchNombreApellido
        {
            get { return _vchNombreApellido; }
            set { _vchNombreApellido = value; }
        }

        private string _vchEmail;
        public string vchEmail
        {
            get { return _vchEmail; }
            set { _vchEmail = value; }
        }

        private string _vchTelefono;
        public string vchTelefono
        {
            get { return _vchTelefono; }
            set { _vchTelefono = value; }
        }

        private string _txtMensaje;
        public string txtMensaje
        {
            get { return _txtMensaje; }
            set { _txtMensaje = value; }
        }

        private DateTime _dtmFechaCreacion;
        public DateTime dtmFechaCreacion
        {
            get { return _dtmFechaCreacion; }
            set { _dtmFechaCreacion = value; }
        }

    }
}
