using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Pagina
    {
        public Pagina() { }

        public Pagina(int intPagina, string vchNombrePagina, string vchPagina,
            string txtLead, string txtContenido, string chrEstado,
            string vchUsuarioCreacion,
            string vchUsuarioModificacion)
        {
            this.intPagina = intPagina;
            this.vchNombrePagina = vchNombrePagina;
            this.vchPagina = vchPagina;
            this.txtLead = txtLead;
            this.txtContenido = txtContenido;
            this.chrEstado = chrEstado;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
            this.vchUsuarioModificacion = vchUsuarioModificacion;
        }

        public Pagina(int intPagina, string vchNombrePagina, string vchPagina,
            string txtLead, string txtContenido, string chrEstado)
        {
            this.intPagina = intPagina;
            this.vchNombrePagina = vchNombrePagina;
            this.vchPagina = vchPagina;
            this.txtLead = txtLead;
            this.txtContenido = txtContenido;
            this.chrEstado = chrEstado;
        }

        private int _intPagina;

        public int intPagina
        {
            get { return _intPagina; }
            set { _intPagina = value; }
        }

        private string _vchNombrePagina;

        public string vchNombrePagina
        {
            get { return _vchNombrePagina; }
            set { _vchNombrePagina = value; }
        }
        private string _vchPagina;

        public string vchPagina
        {
            get { return _vchPagina; }
            set { _vchPagina = value; }
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
    }
}
