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
    public class NoticiaFotografiaData
    {
        public List<NoticiaFotografia> ListarxNoticia(int intNoticiaID)
        {
            List<NoticiaFotografia> listaNoticiaFotografia = new List<NoticiaFotografia>();
            string StoredProcedure = "NoticiaFotografiaListarxNoticia";
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
                    param.ParameterName = "intNoticia";
                    param.Value = intNoticiaID;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            NoticiaFotografia control = new NoticiaFotografia(
                                (int)dr["intNoticia"],
                                (int)dr["intFotografia"],
                                (string)dr["vchUsuarioCreacion"]);
                            listaNoticiaFotografia.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return listaNoticiaFotografia;
        }

        public List<NoticiaFotografia> ListarxFoto(int intFotoID)
        {
            List<NoticiaFotografia> listaNoticiaFotografia = new List<NoticiaFotografia>();
            string StoredProcedure = "NoticiaFotografiaListarxFotografia";
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
                    param.ParameterName = "intFotografia";
                    param.Value = intFotoID;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            NoticiaFotografia control = new NoticiaFotografia(
                                (int)dr["intNoticia"],
                                (int)dr["intFotografia"],
                                (string)dr["vchUsuarioCreacion"]);
                            listaNoticiaFotografia.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return listaNoticiaFotografia;
        }

        public int InsertarNoticiaFotografia(NoticiaFotografia notaFoto)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = notaFoto.intNoticia;
            param.ParameterName = "intNoticia";
            parametros.Add(param);

            DbParameter paramFoto = BaseData.DbProvider.CreateParameter();
            paramFoto.Value = notaFoto.intFotografia;
            paramFoto.ParameterName = "intFotografia";
            parametros.Add(paramFoto);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = notaFoto.vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            return BaseData.ejecutaNonQuery("NoticiaFotografiaInsertar", parametros);
        }

        public int EliminarNoticiaFotografia(int intNoticiaId, int intFotografiaId)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = intNoticiaId;
            param.ParameterName = "intNoticia";
            parametros.Add(param);

            DbParameter paramFoto = BaseData.DbProvider.CreateParameter();
            paramFoto.Value = intFotografiaId;
            paramFoto.ParameterName = "intFotografia";
            parametros.Add(paramFoto);

            return BaseData.ejecutaNonQuery("NoticiaFotografiaEliminar", parametros);
        }
    }
}
