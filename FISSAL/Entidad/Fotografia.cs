using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Fotografia
    {
        public Fotografia() { }

        public Fotografia(int intCodigo, string vchLeyenda, string vchDescriptores, string vchCredito,
                          string vchImagenPequena, string vchImagenMediana, string vchImagen, string chrEstado) 
        {
            this.intCodigo = intCodigo;
            this.vchLeyenda = vchLeyenda;
            this.vchDescriptores = vchDescriptores;
            this.vchCredito = vchCredito;
            this.vchImagenPequena = vchImagenPequena;
            this.vchImagenMediana = vchImagenMediana;
            this.vchImagen = vchImagen;
            this.chrEstado = chrEstado;
        }

        private int _intCodigo;

        public int intCodigo
        {
            get { return _intCodigo; }
            set { _intCodigo = value; }
        }
        private string _vchLeyenda;

        public string vchLeyenda
        {
            get { return _vchLeyenda; }
            set { _vchLeyenda = value; }
        }
        private string _vchDescriptores;

        public string vchDescriptores
        {
            get { return _vchDescriptores; }
            set { _vchDescriptores = value; }
        }
        private string _vchCredito;

        public string vchCredito
        {
            get { return _vchCredito; }
            set { _vchCredito = value; }
        }
        private string _vchImagenPequena;

        public string vchImagenPequena
        {
            get { return _vchImagenPequena; }
            set { _vchImagenPequena = value; }
        }
        private string _vchImagenMediana;

        public string vchImagenMediana
        {
            get { return _vchImagenMediana; }
            set { _vchImagenMediana = value; }
        }
        private string _vchImagen;

        public string vchImagen
        {
            get { return _vchImagen; }
            set { _vchImagen = value; }
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
