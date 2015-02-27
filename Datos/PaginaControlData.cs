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
    public class PaginaControlData
    {
        public List<PaginaControl> ListarControlesxPagina(int intPagina)
        {
            List<PaginaControl> lstControles = new List<PaginaControl>();
            string StoredProcedure = "PaginaControlListarxPagina";
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
                    param.ParameterName = "intPagina";
                    param.Value = intPagina;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            PaginaControl control = new PaginaControl(
                                (int)dr["intPagina"],
                                (int)dr["intCodigoControl"],
                                (int)dr["intOrden"]);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }
    }
}
