using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Ubigeo
    {
        public Ubigeo() { }

        public Ubigeo(int ubigeoId, string departamentoId, string provinciaId, string distritoId, string descripcionUbigeo) 
        {
            this.ubigeoId = ubigeoId;
            this.departamentoId = departamentoId;
            this.provinciaId = provinciaId;
            this.distritoId = distritoId;
            this.descripcionUbigeo = descripcionUbigeo;
        }

        private int _ubigeoId;

        public int ubigeoId
        {
            get { return _ubigeoId; }
            set { _ubigeoId = value; }
        }
        private string _departamentoId;

        public string departamentoId
        {
            get { return _departamentoId; }
            set { _departamentoId = value; }
        }
        private string _provinciaId;

        public string provinciaId
        {
            get { return _provinciaId; }
            set { _provinciaId = value; }
        }
        private string _distritoId;

        public string distritoId
        {
            get { return _distritoId; }
            set { _distritoId = value; }
        }
        private string _descripcionUbigeo;

        public string descripcionUbigeo
        {
            get { return _descripcionUbigeo; }
            set { _descripcionUbigeo = value; }
        }

    }
}
