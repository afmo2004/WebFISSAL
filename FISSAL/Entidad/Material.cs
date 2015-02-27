using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Material
    {
        public Material() { }

        public Material(int intMaterial, string vchTitulo, string vchDescripcion, int intTipo,
                        string vchImagen, string vchArchivo, string chrEstado, DateTime dtmFechaPublicacion) 
        {
            this.intMaterial = intMaterial;
            this.vchTitulo = vchTitulo;
            this.vchDescripcion = vchDescripcion;
            this.intTipo = intTipo;
            this.vchImagen = vchImagen;
            this.vchArchivo = vchArchivo;
            this.chrEstado = chrEstado;
            this.dtmFechaPublicacion = dtmFechaPublicacion;
        }

        public Material(int intMaterial, string vchTitulo, string vchDescripcion, int intTipo,
                        string vchImagen, string vchArchivo, string chrEstado, DateTime dtmFechaPublicacion,
                        string vchUsuarioCreacion, string vchUsuarioModificacion)
        {
            this.intMaterial = intMaterial;
            this.vchTitulo = vchTitulo;
            this.vchDescripcion = vchDescripcion;
            this.intTipo = intTipo;
            this.vchImagen = vchImagen;
            this.vchArchivo = vchArchivo;
            this.chrEstado = chrEstado;
            this.dtmFechaPublicacion = dtmFechaPublicacion;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
            this.vchUsuarioModificacion = vchUsuarioModificacion;
        }

        private int _intMaterial;

        public int intMaterial
        {
            get { return _intMaterial; }
            set { _intMaterial = value; }
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
        private int _intTipo;

        public int intTipo
        {
            get { return _intTipo; }
            set { _intTipo = value; }
        }
        private string _vchImagen;

        public string vchImagen
        {
            get { return _vchImagen; }
            set { _vchImagen = value; }
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
