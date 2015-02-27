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
    public class VideoData
    {
        public List<Video> ListarVideoUltimos()
        {
            List<Video> lista = new List<Video>();
            string StoredProcedure = "VideoListarUltimos";
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
                            Video control = new Video(
                                (int)dr["intVideo"],
                                (string)dr["vchTitulo"],
                                (string)dr["txtLead"],
                                (string)dr["txtScript"],
                                (string)dr["vchURL"],
                                (DateTime)dr["dtmFechaPublicacion"],
                                (string)dr["chrEstado"]);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public Video ListaVideoxID(int pintVideoID)
        {
            Video video = new Video();
            string StoredProcedure = "VideoListarxID";

            using (DbConnection con = BaseData.DbProvider.CreateConnection())
            {
                con.ConnectionString = BaseData.CadenaConexion;
                using (DbCommand cmd = BaseData.DbProvider.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "intVideo";
                    param.Value = pintVideoID;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string txtLead = "";
                            if (!(dr["txtLead"] is System.DBNull))
                                txtLead = (string)dr["txtLead"];

                            string txtScript = "";
                            if (!(dr["txtScript"] is System.DBNull))
                                txtScript = (string)dr["txtScript"];

                            string vchURL = "";
                            if (!(dr["vchURL"] is System.DBNull))
                                vchURL = (string)dr["vchURL"];

                            video = new Video(
                                (int)dr["intVideo"],
                                (string)dr["vchTitulo"],
                                txtLead,
                                txtScript,
                                vchURL,
                                (DateTime)dr["dtmFechaPublicacion"],
                                (string)dr["chrEstado"]);
                        }
                    }
                    con.Close();
                }
            }
            return video;
        }

        public int ActualizarVideo(Video video)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = video.intVideo;
            param.ParameterName = "intVideo";
            parametros.Add(param);

            DbParameter paramTitulo = BaseData.DbProvider.CreateParameter();
            paramTitulo.Value = video.vchTitulo;
            paramTitulo.ParameterName = "vchTitulo";
            parametros.Add(paramTitulo);

            DbParameter paramDescripcion = BaseData.DbProvider.CreateParameter();
            paramDescripcion.Value = video.txtLead;
            paramDescripcion.ParameterName = "txtLead";
            parametros.Add(paramDescripcion);

            DbParameter paramScript = BaseData.DbProvider.CreateParameter();
            paramScript.Value = video.txtScript;
            paramScript.ParameterName = "txtScript";
            parametros.Add(paramScript);

            DbParameter paramURL = BaseData.DbProvider.CreateParameter();
            paramURL.Value = video.vchURL;
            paramURL.ParameterName = "vchURL";
            parametros.Add(paramURL);

            DbParameter paramFecha = BaseData.DbProvider.CreateParameter();
            paramFecha.Value = video.dtmFechaPublicacion;
            paramFecha.ParameterName = "dtmFechaPublicacion";
            parametros.Add(paramFecha);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = video.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = video.vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = video.vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            return BaseData.ejecutaNonQuery("VideoActualizar", parametros);
        }
    }
}
