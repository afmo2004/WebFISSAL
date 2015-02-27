using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using FISSAL.Entidad;

namespace FISSAL.Datos
{
    public class UnidadEjecutoraData
    {
        public List<UnidadEjecutora> ListarUnidadEjecutora(int intDisaId)
        {
            List<UnidadEjecutora> lista = new List<UnidadEjecutora>();
            string StoredProcedure = "UnidadEjecutoraListar";
            using (DbConnection con = BaseData.DbProvider.CreateConnection())
            {
                con.ConnectionString = BaseData.CadenaConexion;
                using (DbCommand cmd = BaseData.DbProvider.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.Int32;
                    param.ParameterName = "disaId";
                    param.Value = intDisaId;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string strUnidadEjecutora = dr["unidadEjecutoraId"].ToString();
                            int intUnidadEjecutora = Int32.Parse(strUnidadEjecutora);
                            string strDescripcion = strUnidadEjecutora + " - " + dr["descripcion"].ToString();
                            UnidadEjecutora unidad = new UnidadEjecutora(
                                intUnidadEjecutora,
                                strDescripcion);
                            lista.Add(unidad);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }
    }
}
