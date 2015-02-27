using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class NormasLegales
    {
        public NormasLegales() { }

        public NormasLegales(int intCodigo, int intAnio, string vchTitulo, string vchDescripcion,
            string vchArchivo, string chrEstado, string chrTipo) 
        {
            this.intCodigo = intCodigo;
            this.intAnio = intAnio;
            this.vchTitulo = vchTitulo;
            this.vchDescripcion = vchDescripcion;
            this.vchArchivo = vchArchivo;
            this.chrEstado = chrEstado;
            this.chrTipo = chrTipo;
        }

        public NormasLegales(int intCodigo, int intAnio, string vchTitulo, string vchDescripcion,
            string vchArchivo, string chrEstado, string chrTipo, string vchUsuarioCreacion, string vchUsuarioModificacion)
        {
            this.intCodigo = intCodigo;
            this.intAnio = intAnio;
            this.vchTitulo = vchTitulo;
            this.vchDescripcion = vchDescripcion;
            this.vchArchivo = vchArchivo;
            this.chrEstado = chrEstado;
            this.chrTipo = chrTipo;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
            this.vchUsuarioModificacion = vchUsuarioModificacion;
        }

        private int _intCodigo;

        public int intCodigo
        {
            get { return _intCodigo; }
            set { _intCodigo = value; }
        }
        private int _intAnio;

        public int intAnio
        {
            get { return _intAnio; }
            set { _intAnio = value; }
        }
        private string _vchTitulo;

        public string vchTitulo
        {
            get { return _vchTitulo; }
            set { _vchTitulo = value; }
        }
        private string _vchDescripcion;

        public string vchDescripcion
        {
            get { return _vchDescripcion; }
            set { _vchDescripcion = value; }
        }
        private string _vchArchivo;

        public string vchArchivo
        {
            get { return _vchArchivo; }
            set { _vchArchivo = value; }
        }
        private string _chrEstado;

        public string chrEstado
        {
            get { return _chrEstado; }
            set { _chrEstado = value; }
        }
        private string _chrTipo;

        public string chrTipo
        {
            get { return _chrTipo; }
            set { _chrTipo = value; }
        }

        private DateTime _dtmFechaPublicacion;

        public DateTime dtmFechaPublicacion
        {
            get { return _dtmFechaPublicacion; }
            set { _dtmFechaPublicacion = value; }
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
