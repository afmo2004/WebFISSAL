using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Control
    {
        public Control() { }

        public Control(int intCodigoControl, string vchNombreControl, string vchControl, string chrTipoControl,
            string chrEstado, DateTime dtmFechaCreacion, string vchUsuarioCreacion,
            DateTime dtmFechaModificacion, string vchUsuarioModificacion)
        {
            this.intCodigoControl = intCodigoControl;
            this.vchNombreControl = vchNombreControl;
            this.vchControl = vchControl;
            this.chrTipoControl = chrTipoControl;
            this.chrEstado = chrEstado;
            this.dtmFechaCreacion = dtmFechaCreacion;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
            this.dtmFechaModificacion = dtmFechaModificacion;
            this.vchUsuarioModificacion = vchUsuarioModificacion;
        }

        public Control(int intCodigoControl, string vchNombreControl, string vchControl, string chrTipoControl,
            string chrEstado)
        {
            this.intCodigoControl = intCodigoControl;
            this.vchNombreControl = vchNombreControl;
            this.vchControl = vchControl;
            this.chrTipoControl = chrTipoControl;
            this.chrEstado = chrEstado;
        }

        public Control(int intCodigoControl, string vchNombreControl, string vchControl, string chrTipoControl,
            string chrEstado, string vchUsuarioCreacion, string vchUsuarioModificacion)
        {
            this.intCodigoControl = intCodigoControl;
            this.vchNombreControl = vchNombreControl;
            this.vchControl = vchControl;
            this.chrTipoControl = chrTipoControl;
            this.chrEstado = chrEstado;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
            this.vchUsuarioModificacion = vchUsuarioModificacion;
        }

        private int _intCodigoControl;

        public int intCodigoControl
        {
            get { return _intCodigoControl; }
            set { _intCodigoControl = value; }
        }
        private string _vchNombreControl;

        public string vchNombreControl
        {
            get { return _vchNombreControl; }
            set { _vchNombreControl = value; }
        }
        private string _vchControl;

        public string vchControl
        {
            get { return _vchControl; }
            set { _vchControl = value; }
        }
        private string _chrTipoControl;

        public string chrTipoControl
        {
            get { return _chrTipoControl; }
            set { _chrTipoControl = value; }
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
