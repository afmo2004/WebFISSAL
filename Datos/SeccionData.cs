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
    public class SeccionData
    {
        public List<Seccion> ListarSeccion()
        {
            List<Seccion> lstControles = new List<Seccion>();
            string StoredProcedure = "SeccionListar";
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
                            Seccion seccion = new Seccion(
                                (int)dr["intSeccion"],
                                (string)dr["vchNombreSeccion"]);
                            lstControles.Add(seccion);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }
    }
}
