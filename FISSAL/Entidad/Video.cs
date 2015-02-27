using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Video
    {
        public Video() { }

        public Video(int intVideo, string vchTitulo, string txtLead, string txtScript,
                     string vchURL, DateTime dtmFechaPublicacion, string chrEstado)
        {
            this.intVideo = intVideo;
            this.vchTitulo = vchTitulo;
            this.txtLead = txtLead;
            this.txtScript = txtScript;
            this.vchURL = vchURL;
            this.dtmFechaPublicacion = dtmFechaPublicacion;
            this.chrEstado = chrEstado;
        }

        public Video(int intVideo, string vchTitulo, string txtLead, string txtScript,
                     string vchURL, DateTime dtmFechaPublicacion, string chrEstado,
                    string vchUsuarioCreacion, string vchUsuarioModificacion)
        {
            this.intVideo = intVideo;
            this.vchTitulo = vchTitulo;
            this.txtLead = txtLead;
            this.txtScript = txtScript;
            this.vchURL = vchURL;
            this.dtmFechaPublicacion = dtmFechaPublicacion;
            this.chrEstado = chrEstado;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
            this.vchUsuarioModificacion = vchUsuarioModificacion;
        }


        private int _intVideo;

        public int intVideo
        {
            get { return _intVideo; }
            set { _intVideo = value; }
        }
        private string _vchTitulo;

        public string vchTitulo
        {
            get { return _vchTitulo; }
            set { _vchTitulo = value; }
        }
        private string _txtLead;

        public string txtLead
        {
            get { return _txtLead; }
            set { _txtLead = value; }
        }
        private string _txtScript;

        public string txtScript
        {
            get { return _txtScript; }
            set { _txtScript = value; }
        }
        private string _vchURL;

        public string vchURL
        {
            get { return _vchURL; }
            set { _vchURL = value; }
        }

        private DateTime _dtmFechaPublicacion;

        public DateTime dtmFechaPublicacion
        {
            get { return _dtmFechaPublicacion; }
            set { _dtmFechaPublicacion = value; }
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
    }
}
