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
    public class DisaData
    {
        public List<Disa> ListarDisa()
        {
            List<Disa> lista = new List<Disa>();
            string StoredProcedure = "DisaListar";
            using (DbConnection con = BaseData.DbProvider.CreateConnection())
            {
                con.ConnectionString = BaseData.CadenaConexion;
                using (DbCommand cmd = BaseData.DbProvider.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string strDisa = dr["disaId"].ToString();
                            int intDisa = Int32.Parse(strDisa);
                            string strDescripcion = strDisa + " - " + dr["descripcion"].ToString();
                            Disa disa = new Disa(intDisa,strDescripcion);
                            lista.Add(disa);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }
    }
}
