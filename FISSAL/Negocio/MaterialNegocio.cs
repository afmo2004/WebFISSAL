using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISSAL.Datos;
using FISSAL.Entidad;

namespace FISSAL.Negocio
{
    public class MaterialNegocio
    {
        public List<Material> ListarMaterial()
        {
            MaterialData control = new MaterialData();
            return control.ListarMaterial();
        }

        public List<Material> ListarMaterialActivo()
        {
            MaterialData control = new MaterialData();
            return control.ListarMaterialActivo();
        }

        public Material ListarMaterialxId(int pintCodigo)
        {
            MaterialData control = new MaterialData();
            return control.ListarMaterialxId(pintCodigo);
        }
        public int ActualizarMaterial(Material material)
        {
            MaterialData control = new MaterialData();
            return control.ActualizarMaterial(material);
        }
    }
}
