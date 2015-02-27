using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Sugerencia
    {
        public Sugerencia() { }

        public Sugerencia(int intCodigo, int intTipo, string chrTipoDocumento, string vchNumeroDocumento,
                        string vchApellidoPaterno, string vchApellidoMaterno, string vchNombres,
                        string chrAsegurado, string txtEspecificacion, string vchNombreAsegurado,
                        string chrTipoDiagnostico, string vchTelefono,string vchCorreo,
                        string vchUbigeo, string vchDireccion, string txtDescripcion,
                        string vchEstablecimiento,DateTime dtmFechaOcurrencia) 
        {
            this.intCodigo = intCodigo;
            this.intTipo = intTipo;
            this.chrTipoDocumento = chrTipoDocumento;
            this.vchNumeroDocumento = vchNumeroDocumento;
            this.vchApellidoPaterno = vchApellidoPaterno;
            this.vchApellidoMaterno = vchApellidoMaterno;
            this.vchNombres = vchNombres;
            this.chrAsegurado = chrAsegurado;
            this.txtEspecificacion = txtEspecificacion;
            this.vchNombreAsegurado = vchNombreAsegurado;
            this.chrTipoDiagnostico = chrTipoDiagnostico;
            this.vchTelefono = vchTelefono;
            this.vchCorreo = vchCorreo;
            this.vchUbigeo = vchUbigeo;
            this.vchDireccion = vchDireccion;
            this.txtDescripcion = txtDescripcion;
            this.vchEstablecimiento = vchEstablecimiento;
            this.dtmFechaOcurrencia = dtmFechaOcurrencia;
        }

        private int _intCodigo;

        public int intCodigo
        {
            get { return _intCodigo; }
            set { _intCodigo = value; }
        }
        private int _intTipo;

        public int intTipo
        {
            get { return _intTipo; }
            set { _intTipo = value; }
        }
        private string _chrTipoDocumento;

        public string chrTipoDocumento
        {
            get { return _chrTipoDocumento; }
            set { _chrTipoDocumento = value; }
        }
        private string _vchNumeroDocumento;

        public string vchNumeroDocumento
        {
            get { return _vchNumeroDocumento; }
            set { _vchNumeroDocumento = value; }
        }
        private string _vchApellidoPaterno;

        public string vchApellidoPaterno
        {
            get { return _vchApellidoPaterno; }
            set { _vchApellidoPaterno = value; }
        }
        private string _vchApellidoMaterno;

        public string vchApellidoMaterno
        {
            get { return _vchApellidoMaterno; }
            set { _vchApellidoMaterno = value; }
        }
        private string _vchNombres;

        public string vchNombres
        {
            get { return _vchNombres; }
            set { _vchNombres = value; }
        }
        private string _chrAsegurado;

        public string chrAsegurado
        {
            get { return _chrAsegurado; }
            set { _chrAsegurado = value; }
        }
        private string _txtEspecificacion;

        public string txtEspecificacion
        {
            get { return _txtEspecificacion; }
            set { _txtEspecificacion = value; }
        }
        private string _vchNombreAsegurado;

        public string vchNombreAsegurado
        {
            get { return _vchNombreAsegurado; }
            set { _vchNombreAsegurado = value; }
        }
        private string _chrTipoDiagnostico;

        public string chrTipoDiagnostico
        {
            get { return _chrTipoDiagnostico; }
            set { _chrTipoDiagnostico = value; }
        }
        private string _vchTelefono;

        public string vchTelefono
        {
            get { return _vchTelefono; }
            set { _vchTelefono = value; }
        }
        private string _vchCorreo;

        public string vchCorreo
        {
            get { return _vchCorreo; }
            set { _vchCorreo = value; }
        }
        private string _vchUbigeo;

        public string vchUbigeo
        {
            get { return _vchUbigeo; }
            set { _vchUbigeo = value; }
        }
        private string _vchDireccion;

        public string vchDireccion
        {
            get { return _vchDireccion; }
            set { _vchDireccion = value; }
        }
        private string _txtDescripcion;

        public string txtDescripcion
        {
            get { return _txtDescripcion; }
            set { _txtDescripcion = value; }
        }
        private string _vchEstablecimiento;

        public string vchEstablecimiento
        {
            get { return _vchEstablecimiento; }
            set { _vchEstablecimiento = value; }
        }
        private DateTime _dtmFechaOcurrencia;

        public DateTime dtmFechaOcurrencia
        {
            get { return _dtmFechaOcurrencia; }
            set { _dtmFechaOcurrencia = value; }
        }
        private DateTime _dtmFechaCreacion;

        public DateTime dtmFechaCreacion
        {
            get { return _dtmFechaCreacion; }
            set { _dtmFechaCreacion = value; }
        }
    }
}
