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
    public class PerfilOpcionData
    {
        public PerfilOpcion ListaControlxID(int pintCodigoPerfil, int pintCodigoOpcion)
        {
            PerfilOpcion control = new PerfilOpcion();
            string StoredProcedure = "PerfilOpcionListarxID";

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
                    param.ParameterName = "intCodigoPerfil";
                    param.Value = pintCodigoPerfil;
                    cmd.Parameters.Add(param);

                    DbParameter paramOpcion = cmd.CreateParameter();
                    paramOpcion.DbType = DbType.Int32;
                    paramOpcion.ParameterName = "intCodigoOpcion";
                    paramOpcion.Value = pintCodigoOpcion;
                    cmd.Parameters.Add(paramOpcion);

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            control = new PerfilOpcion(
                                (int)dr["intCodigoPerfil"],
                                (int)dr["intCodigoOpcion"]);
                        }
                    }
                    con.Close();
                }
            }
            return control;
        }

        public int ActualizarPerfilOpcion(PerfilOpcion perfilOpcion)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = perfilOpcion.intCodigoPerfil;
            param.ParameterName = "intCodigoPerfil";
            parametros.Add(param);

            DbParameter paramOpcion = BaseData.DbProvider.CreateParameter();
            paramOpcion.Value = perfilOpcion.intCodigoOpcion;
            paramOpcion.ParameterName = "intCodigoOpcion";
            parametros.Add(paramOpcion);


            return BaseData.ejecutaNonQuery("PerfilOpcionActualizar", parametros);
        }

        public int EliminarPerfilOpcion(PerfilOpcion perfilOpcion)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = perfilOpcion.intCodigoPerfil;
            param.ParameterName = "intCodigoPerfil";
            parametros.Add(param);

            DbParameter paramOpcion = BaseData.DbProvider.CreateParameter();
            paramOpcion.Value = perfilOpcion.intCodigoOpcion;
            paramOpcion.ParameterName = "intCodigoOpcion";
            parametros.Add(paramOpcion);


            return BaseData.ejecutaNonQuery("PerfilOpcionEliminar", parametros);
        }
    }
}
