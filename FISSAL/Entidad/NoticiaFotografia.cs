using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class NoticiaFotografia
    {
        public NoticiaFotografia() { }

        public NoticiaFotografia(int intNoticia, int intFotografia, string vchUsuarioCreacion) 
        {
            this.intNoticia = intNoticia;
            this.intFotografia = intFotografia;
            this.vchUsuarioCreacion = vchUsuarioCreacion;
        }
        private int _intNoticia;

        public int intNoticia
        {
            get { return _intNoticia; }
            set { _intNoticia = value; }
        }
        private int _intFotografia;

        public int intFotografia
        {
            get { return _intFotografia; }
            set { _intFotografia = value; }
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
    }
}
