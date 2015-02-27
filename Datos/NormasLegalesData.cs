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
    public class NormasLegalesData
    {
        public NormasLegales ListarNormasxID(int pintNormaID)
        {
            NormasLegales normaLegal = new NormasLegales();
            string StoredProcedure = "NormasLegalesListarxID";
            using (DbConnection con = BaseData.DbProvider.CreateConnection())
            {
                con.ConnectionString = BaseData.CadenaConexion;
                using (DbCommand cmd = BaseData.DbProvider.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbParameter paramAnio = cmd.CreateParameter();
                    paramAnio.DbType = DbType.Int32;
                    paramAnio.ParameterName = "intCodigo";
                    paramAnio.Value = pintNormaID;
                    cmd.Parameters.Add(paramAnio);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            normaLegal = new NormasLegales(
                                (int)dr["intCodigo"],
                                (int)dr["intAnio"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchDescripcion"],
                                (string)dr["vchArchivo"],
                                (string)dr["chrEstado"],
                                (string)dr["chrTipo"]);
                        }
                    }
                    con.Close();
                }
            }
            return normaLegal;
        }

        public List<NormasLegales> ListarNormas()
        {
            List<NormasLegales> lstControles = new List<NormasLegales>();
            string StoredProcedure = "NormasLegalesListar";
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
                            NormasLegales control = new NormasLegales(
                                (int)dr["intCodigo"],
                                (int)dr["intAnio"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchDescripcion"],
                                (string)dr["vchArchivo"],
                                (string)dr["chrEstado"],
                                (string)dr["chrTipo"]);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public List<NormasLegales> ListarNormasxAnioTipo(int intAnio, string pstrTipo)
        {
            List<NormasLegales> lstControles = new List<NormasLegales>();
            string StoredProcedure = "NormasLegalesListarxAnioTipo";
            using (DbConnection con = BaseData.DbProvider.CreateConnection())
            {
                con.ConnectionString = BaseData.CadenaConexion;
                using (DbCommand cmd = BaseData.DbProvider.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbParameter paramAnio = cmd.CreateParameter();
                    paramAnio.DbType = DbType.Int32;
                    paramAnio.ParameterName = "intAnio";
                    paramAnio.Value = intAnio;
                    cmd.Parameters.Add(paramAnio);
                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "chrTipo";
                    param.Value = pstrTipo;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            NormasLegales control = new NormasLegales(
                                (int)dr["intCodigo"],
                                (int)dr["intAnio"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchDescripcion"],
                                (string)dr["vchArchivo"],
                                (string)dr["chrEstado"],
                                (string)dr["chrTipo"]);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public List<NormasLegales> ListarNormasxAnioTipoVigente(int intAnio, string pstrTipo)
        {
            List<NormasLegales> lstControles = new List<NormasLegales>();
            string StoredProcedure = "NormasLegalesListarxAnioTipoVigente";
            using (DbConnection con = BaseData.DbProvider.CreateConnection())
            {
                con.ConnectionString = BaseData.CadenaConexion;
                using (DbCommand cmd = BaseData.DbProvider.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbParameter paramAnio = cmd.CreateParameter();
                    paramAnio.DbType = DbType.Int32;
                    paramAnio.ParameterName = "intAnio";
                    paramAnio.Value = intAnio;
                    cmd.Parameters.Add(paramAnio);
                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "chrTipo";
                    param.Value = pstrTipo;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            NormasLegales control = new NormasLegales(
                                (int)dr["intCodigo"],
                                (int)dr["intAnio"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchDescripcion"],
                                (string)dr["vchArchivo"],
                                (string)dr["chrEstado"],
                                (string)dr["chrTipo"]);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public int ActualizarNormaLegal(NormasLegales entidad)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = entidad.intCodigo;
            param.ParameterName = "intCodigo";
            parametros.Add(param);

            DbParameter paramAnio = BaseData.DbProvider.CreateParameter();
            paramAnio.Value = entidad.intAnio;
            paramAnio.ParameterName = "intAnio";
            parametros.Add(paramAnio);

            DbParameter paramTitulo = BaseData.DbProvider.CreateParameter();
            paramTitulo.Value = entidad.vchTitulo;
            paramTitulo.ParameterName = "vchTitulo";
            parametros.Add(paramTitulo);

            DbParameter paramDescripcion = BaseData.DbProvider.CreateParameter();
            paramDescripcion.Value = entidad.vchDescripcion;
            paramDescripcion.ParameterName = "vchDescripcion";
            parametros.Add(paramDescripcion);

            DbParameter paramArchivo = BaseData.DbProvider.CreateParameter();
            paramArchivo.Value = entidad.vchArchivo;
            paramArchivo.ParameterName = "vchArchivo";
            parametros.Add(paramArchivo);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = entidad.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramTipo = BaseData.DbProvider.CreateParameter();
            paramTipo.Value = entidad.chrTipo;
            paramTipo.ParameterName = "chrTipo";
            parametros.Add(paramTipo);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = entidad.vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = entidad.vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            return BaseData.ejecutaNonQuery("NormasLegalesActualizar", parametros);
        }
    }
}
