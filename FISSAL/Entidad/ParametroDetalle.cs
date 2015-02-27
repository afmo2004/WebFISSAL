using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class ParametroDetalle
    {
        public ParametroDetalle() { }

        public ParametroDetalle(int intCodigo, int intCodigoParametro, string vchDescripcion, string vchValor, string chrEstado) 
        {
            this.intCodigo = intCodigo;
            this.intCodigoParametro = intCodigoParametro;
            this.vchDescripcion = vchDescripcion;
            this.vchValor = vchValor;
            this.chrEstado = chrEstado;
        }

        private int _intCodigo;

        public int intCodigo
        {
            get { return _intCodigo; }
            set { _intCodigo = value; }
        }
        private int _intCodigoParametro;

        public int intCodigoParametro
        {
            get { return _intCodigoParametro; }
            set { _intCodigoParametro = value; }
        }
        private string _vchDescripcion;

        public string vchDescripcion
        {
            get { return _vchDescripcion; }
            set { _vchDescripcion = value; }
        }
        private string _vchValor;

        public string vchValor
        {
            get { return _vchValor; }
            set { _vchValor = value; }
        }
        private string _chrEstado;

        public string chrEstado
        {
            get { return _chrEstado; }
            set { _chrEstado = value; }
        }
    }
}
