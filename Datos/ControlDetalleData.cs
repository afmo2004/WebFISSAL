using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using FISSAL.Entidad;

namespace FISSAL.Datos
{
    public class ControlDetalleData
    {
        public List<ControlDetalle> ListarxControlID(int intCodigoControl)
        {
            List<ControlDetalle> lista = new List<ControlDetalle>();

            string StoredProcedure = "ControlDetallexControlID";

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
                    param.ParameterName = "intCodigoControl";
                    param.Value = intCodigoControl;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int pintControlDetalle = (int)dr["intControlDetalle"];
                            int pintCodigoControl = (int)dr["intCodigoControl"];
                            int pintOrden = (int)dr["intOrden"];
                            string pvchNombre = (string)dr["vchNombre"];
                            string pvchTexto = (string)dr["vchTexto"];
                            string pvchImagen = (string)dr["vchImagen"];
                            string pvchURL = (string)dr["vchURL"];
                            string ptxtScript = (string)dr["txtScript"];
                            string pchrTipo = (string)dr["chrTipo"];
                            string pchrEstado = (string)dr["chrEstado"];
                            DateTime pdtmFechaCreacion = (DateTime)dr["dtmFechaCreacion"];
                            string pvchUsuarioCreacion = (string)dr["vchUsuarioCreacion"];
                            DateTime pdtmFechaModificacion = new DateTime();
                            if (!(dr["dtmFechaModificacion"] is System.DBNull))
                                pdtmFechaModificacion = (DateTime)dr["dtmFechaModificacion"];
                            string pvchUsuarioModificacion = "";
                            if (!(dr["vchUsuarioModificacion"] is System.DBNull))
                                pvchUsuarioModificacion = (string)dr["vchUsuarioModificacion"];
                            string pvchImagenHover = "";
                            if (!(dr["vchImagenHover"] is System.DBNull))
                                pvchImagenHover = (string)dr["vchImagenHover"];

                            ControlDetalle controlDetalle = new ControlDetalle(
                                pintControlDetalle,
                                pintCodigoControl,
                                pintOrden,
                                pvchNombre,
                                pvchTexto,
                                pvchImagen,
                                pvchURL,
                                ptxtScript,
                                pchrTipo,
                                pchrEstado,
                                pvchUsuarioCreacion,
                                pvchUsuarioModificacion,
                                pvchImagenHover);
                            lista.Add(controlDetalle);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public ControlDetalle ListaControlDetallexID(int pintControlDetalle)
        {
            ControlDetalle detalle = new ControlDetalle();
            string StoredProcedure = "ControlDetalleListarxID";

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
                    param.ParameterName = "intControlDetalle";
                    param.Value = pintControlDetalle;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int pintCodigoControl = (int)dr["intCodigoControl"];
                            int pintOrden = (int)dr["intOrden"];
                            string pvchNombre = (string)dr["vchNombre"];
                            string pvchTexto = (string)dr["vchTexto"];
                            string pvchImagen = (string)dr["vchImagen"];
                            string pvchURL = (string)dr["vchURL"];
                            string ptxtScript = (string)dr["txtScript"];
                            string pchrTipo = (string)dr["chrTipo"];
                            string pchrEstado = (string)dr["chrEstado"];
                            DateTime pdtmFechaCreacion = (DateTime)dr["dtmFechaCreacion"];
                            string pvchUsuarioCreacion = (string)dr["vchUsuarioCreacion"];
                            DateTime pdtmFechaModificacion = new DateTime();
                            if (!(dr["dtmFechaModificacion"] is System.DBNull))
                                pdtmFechaModificacion = (DateTime)dr["dtmFechaModificacion"];
                            string pvchUsuarioModificacion = "";
                            if (!(dr["vchUsuarioModificacion"] is System.DBNull))
                                pvchUsuarioModificacion = (string)dr["vchUsuarioModificacion"];
                            string pvchImagenHover = "";
                            if (!(dr["vchImagenHover"] is System.DBNull))
                                pvchImagenHover = (string)dr["vchImagenHover"];

                            detalle = new ControlDetalle(
                                pintControlDetalle,
                                pintCodigoControl,
                                pintOrden,
                                pvchNombre,
                                pvchTexto,
                                pvchImagen,
                                pvchURL,
                                ptxtScript,
                                pchrTipo,
                                pchrEstado,
                                pvchUsuarioCreacion,
                                pvchUsuarioModificacion,
                                pvchImagenHover);
                        }
                    }
                    con.Close();
                }
            }
            return detalle;
        }

        public int ActualizarControlDetalle(int pintControlDetalle, int pintOrden, string pvchUsuarioModificacion)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = pintControlDetalle;
            param.ParameterName = "intControlDetalle";
            parametros.Add(param);

            DbParameter paramOrden = BaseData.DbProvider.CreateParameter();
            paramOrden.Value = pintOrden;
            paramOrden.ParameterName = "intOrden";
            parametros.Add(paramOrden);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = pvchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            return BaseData.ejecutaNonQuery("ControlDetalleActualizarOrden", parametros);
        }

        public int ActualizarControlDetalle(ControlDetalle controlDetalle)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = controlDetalle.intControlDetalle;
            param.ParameterName = "intControlDetalle";
            parametros.Add(param);

            DbParameter paramCodigo = BaseData.DbProvider.CreateParameter();
            paramCodigo.Value = controlDetalle.intCodigoControl;
            paramCodigo.ParameterName = "intCodigoControl";
            parametros.Add(paramCodigo);

            DbParameter paramOrden = BaseData.DbProvider.CreateParameter();
            paramOrden.Value = controlDetalle.intOrden;
            paramOrden.ParameterName = "intOrden";
            parametros.Add(paramOrden);

            DbParameter paramNombre = BaseData.DbProvider.CreateParameter();
            paramNombre.Value = controlDetalle.vchNombre;
            paramNombre.ParameterName = "vchNombre";
            parametros.Add(paramNombre);

            DbParameter paramTexto = BaseData.DbProvider.CreateParameter();
            paramTexto.Value = controlDetalle.vchTexto;
            paramTexto.ParameterName = "vchTexto";
            parametros.Add(paramTexto);

            DbParameter paramImagen = BaseData.DbProvider.CreateParameter();
            paramImagen.Value = controlDetalle.vchImagen;
            paramImagen.ParameterName = "vchImagen";
            parametros.Add(paramImagen);

            DbParameter paramURL = BaseData.DbProvider.CreateParameter();
            paramURL.Value = controlDetalle.vchURL;
            paramURL.ParameterName = "vchURL";
            parametros.Add(paramURL);

            DbParameter paramScript = BaseData.DbProvider.CreateParameter();
            paramScript.Value = controlDetalle.txtScript;
            paramScript.ParameterName = "txtScript";
            parametros.Add(paramScript);

            DbParameter paramTipo = BaseData.DbProvider.CreateParameter();
            paramTipo.Value = controlDetalle.chrTipo;
            paramTipo.ParameterName = "chrTipo";
            parametros.Add(paramTipo);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = controlDetalle.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = controlDetalle.vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = controlDetalle.vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            DbParameter paramImagenHover = BaseData.DbProvider.CreateParameter();
            paramImagenHover.Value = controlDetalle.vchImagenHover;
            paramImagenHover.ParameterName = "vchImagenHover";
            parametros.Add(paramImagenHover);

            return BaseData.ejecutaNonQuery("ControlDetalleActualizar", parametros);
        }
    }
}
