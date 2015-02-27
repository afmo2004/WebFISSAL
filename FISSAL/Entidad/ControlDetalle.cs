using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class ControlDetalle
    {
        public ControlDetalle() { }

        public ControlDetalle(int intControlDetalle, int intCodigoControl, int intOrden, string vchNombre, 
            string vchTexto,string vchImagen, string vchURL, string txtScript, 
            string chrTipo, string chrEstado, string vchUsuarioCreacion, string vchUsuarioModificacion,
            string vchImagenHover)
        {
            this.intControlDetalle = intControlDetalle;
            this.intCodigoControl = intCodigoControl;
            this.intOrden = intOrden;
            this.vchNombre = vchNombre;
            this.vchTexto = vchTexto;
            this.vchImagen = vchImagen;
            this.vchURL = vchURL;
            this.txtScript = txtScript;
            this.chrTipo = chrTipo;
            this.chrEstado = chrEstado;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
            this.vchUsuarioModificacion = vchUsuarioModificacion;
            this.vchImagenHover = vchImagenHover;
        }

        private int _intControlDetalle;

        public int intControlDetalle
        {
            get { return _intControlDetalle; }
            set { _intControlDetalle = value; }
        }
        private int _intCodigoControl;

        public int intCodigoControl
        {
            get { return _intCodigoControl; }
            set { _intCodigoControl = value; }
        }
        private int _intOrden;

        public int intOrden
        {
            get { return _intOrden; }
            set { _intOrden = value; }
        }
        private string _vchNombre;

        public string vchNombre
        {
            get { return _vchNombre; }
            set { _vchNombre = value; }
        }

        private string _vchTexto;

        public string vchTexto
        {
            get { return _vchTexto; }
            set { _vchTexto = value; }
        }
        private string _vchImagen;

        public string vchImagen
        {
            get { return _vchImagen; }
            set { _vchImagen = value; }
        }
        private string _vchURL;

        public string vchURL
        {
            get { return _vchURL; }
            set { _vchURL = value; }
        }
        private string _txtScript;

        public string txtScript
        {
            get { return _txtScript; }
            set { _txtScript = value; }
        }
        private string _chrTipo;

        public string chrTipo
        {
            get { return _chrTipo; }
            set { _chrTipo = value; }
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

        private string _vchImagenHover;

        public string vchImagenHover
        {
            get { return _vchImagenHover; }
            set { _vchImagenHover = value; }
        }


    }
}
