using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Noticia
    {
        public Noticia() { }

        public Noticia(int intCodigo, DateTime dtmFechaPublicacion, string vchVolada, string vchTitulo,
                        string vchBajada, string vchFechado, string vchCredito, string txtLead,
                        string txtContenido, string chrEstado)
        {
            this.intCodigo = intCodigo;
            this.dtmFechaPublicacion = dtmFechaPublicacion;
            this.vchVolada = vchVolada;
            this.vchTitulo = vchTitulo;
            this.vchBajada = vchBajada;
            this.vchFechado = vchFechado;
            this.vchCredito = vchCredito;
            this.txtLead = txtLead;
            this.txtContenido = txtContenido;
            this.chrEstado = chrEstado;
        }

        public Noticia(int intCodigo, DateTime dtmFechaPublicacion, string vchVolada, string vchTitulo,
                        string vchBajada, string vchFechado, string vchCredito, string txtLead,
                        string txtContenido, string chrEstado, string vchURL)
        {
            this.intCodigo = intCodigo;
            this.dtmFechaPublicacion = dtmFechaPublicacion;
            this.vchVolada = vchVolada;
            this.vchTitulo = vchTitulo;
            this.vchBajada = vchBajada;
            this.vchFechado = vchFechado;
            this.vchCredito = vchCredito;
            this.txtLead = txtLead;
            this.txtContenido = txtContenido;
            this.chrEstado = chrEstado;
            this.vchURL = vchURL;
        }

        public Noticia(int intCodigo, DateTime dtmFechaPublicacion, string vchVolada, string vchTitulo,
                        string vchBajada, string vchFechado, string vchCredito, string txtLead,
                        string txtContenido, string chrEstado, string vchUsuarioCreacion, string vchUsuarioModificacion)
        {
            this.intCodigo = intCodigo;
            this.dtmFechaPublicacion = dtmFechaPublicacion;
            this.vchVolada = vchVolada;
            this.vchTitulo = vchTitulo;
            this.vchBajada = vchBajada;
            this.vchFechado = vchFechado;
            this.vchCredito = vchCredito;
            this.txtLead = txtLead;
            this.txtContenido = txtContenido;
            this.chrEstado = chrEstado;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
            this.vchUsuarioModificacion = vchUsuarioModificacion;
        }
        public Noticia(int intCodigo, DateTime dtmFechaPublicacion, string vchVolada, string vchTitulo,
                        string vchBajada, string vchFechado, string vchCredito, string txtLead,
                        string txtContenido, string chrEstado, string vchUsuarioCreacion, string vchUsuarioModificacion,
                        string vchURL)
        {
            this.intCodigo = intCodigo;
            this.dtmFechaPublicacion = dtmFechaPublicacion;
            this.vchVolada = vchVolada;
            this.vchTitulo = vchTitulo;
            this.vchBajada = vchBajada;
            this.vchFechado = vchFechado;
            this.vchCredito = vchCredito;
            this.txtLead = txtLead;
            this.txtContenido = txtContenido;
            this.chrEstado = chrEstado;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
            this.vchUsuarioModificacion = vchUsuarioModificacion;
            this.vchURL = vchURL;
        }
        private int _intCodigo;

        public int intCodigo
        {
            get { return _intCodigo; }
            set { _intCodigo = value; }
        }
        private DateTime _dtmFechaPublicacion;

        public DateTime dtmFechaPublicacion
        {
            get { return _dtmFechaPublicacion; }
            set { _dtmFechaPublicacion = value; }
        }
        private string _vchVolada;

        public string vchVolada
        {
            get { return _vchVolada; }
            set { _vchVolada = value; }
        }
        private string _vchTitulo;

        public string vchTitulo
        {
            get { return _vchTitulo; }
            set { _vchTitulo = value; }
        }
        private string _vchBajada;

        public string vchBajada
        {
            get { return _vchBajada; }
            set { _vchBajada = value; }
        }
        private string _vchFechado;

        public string vchFechado
        {
            get { return _vchFechado; }
            set { _vchFechado = value; }
        }
        private string _vchCredito;

        public string vchCredito
        {
            get { return _vchCredito; }
            set { _vchCredito = value; }
        }
        private string _txtLead;

        public string txtLead
        {
            get { return _txtLead; }
            set { _txtLead = value; }
        }
        private string _txtContenido;

        public string txtContenido
        {
            get { return _txtContenido; }
            set { _txtContenido = value; }
        }
        private string _chrEstado;

        public string chrEstado
        {
            get { return _chrEstado; }
            set { _chrEstado = value; }
        }
        private DateTime _dtmFechaCreacion;

        public DateTime dtmFechaCreacion
        {
            get { return _dtmFechaCreacion; }
            set { _dtmFechaCreacion = value; }
        }
        private string _vchUsuarioCreacion;

        public string vchUsuarioCreacion
        {
            get { return _vchUsuarioCreacion; }
            set { _vchUsuarioCreacion = value; }
        }
        private DateTime _dtmFechaModificacion;

        public DateTime dtmFechaModificacion
        {
            get { return _dtmFechaModificacion; }
            set { _dtmFechaModificacion = value; }
        }
        private string _vchUsuarioModificacion;

        public string vchUsuarioModificacion
        {
            get { return _vchUsuarioModificacion; }
            set { _vchUsuarioModificacion = value; }
        }
        private string _vchURL;

        public string vchURL
        {
            get { return _vchURL; }
            set { _vchURL = value; }
        }

    }
}
