using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class ControlNegocio
    {
        public List<Control> ListarControlxTipo(string pstrTipo)
        {
            ControlData control = new ControlData();
            return control.ListarControlxTipo(pstrTipo);
        }

        public Control ListaControlxID(int pintCodigoControl)
        {
            ControlData control = new ControlData();
            return control.ListaControlxID(pintCodigoControl);
        }

        public int ActualizarControl(Control control)
        {
            ControlData controldata = new ControlData();
            return controldata.ActualizarControl(control);
        }
    }
}
