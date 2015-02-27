using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FISSAL.Entidad
{
    public class Opcion
    {
        public Opcion() { }

        public Opcion(int intCodigoOpcion, string vchNombreOpcion, string vchPagina, int intNivel,
            int intOrden, int intCodigoOpcionPadre, string chrEstado) 
        {
            this.intCodigoOpcion = intCodigoOpcion;
            this.vchNombreOpcion = vchNombreOpcion;
            this.vchPagina = vchPagina;
            this.intNivel = intNivel;
            this.intOrden = intOrden;
            this.intCodigoOpcionPadre = intCodigoOpcionPadre;
            this.chrEstado = chrEstado;
        }

        public Opcion(int intCodigoOpcion, string vchNombreOpcion, string vchPagina, int intNivel,
            int intOrden, int intCodigoOpcionPadre, string chrEstado,string vchLogin)
        {
            this.intCodigoOpcion = intCodigoOpcion;
            this.vchNombreOpcion = vchNombreOpcion;
            this.vchPagina = vchPagina;
            this.intNivel = intNivel;
            this.intOrden = intOrden;
            this.intCodigoOpcionPadre = intCodigoOpcionPadre;
            this.chrEstado = chrEstado;
            this.vchLogin = vchLogin;
        }

        private int _intCodigoOpcion;

        public int intCodigoOpcion
        {
            get { return _intCodigoOpcion; }
            set { _intCodigoOpcion = value; }
        }
        private string _vchNombreOpcion;

        public string vchNombreOpcion
        {
            get { return _vchNombreOpcion; }
            set { _vchNombreOpcion = value; }
        }
        private string _vchPagina;

        public string vchPagina
        {
            get { return _vchPagina; }
            set { _vchPagina = value; }
        }
        private int _intNivel;

        public int intNivel
        {
            get { return _intNivel; }
            set { _intNivel = value; }
        }
        private int _intOrden;

        public int intOrden
        {
            get { return _intOrden; }
            set { _intOrden = value; }
        }
        private int _intCodigoOpcionPadre;

        public int intCodigoOpcionPadre
        {
            get { return _intCodigoOpcionPadre; }
            set { _intCodigoOpcionPadre = value; }
        }
        private string _chrEstado;

        public string chrEstado
        {
            get { return _chrEstado; }
            set { _chrEstado = value; }
        }

        private string _vchLogin;

        public string vchLogin
        {
            get { return _vchLogin; }
            set { _vchLogin = value; }
        }

    }
}
