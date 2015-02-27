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
    public class ParametroDetalleData
    {
        public ParametroDetalle ListarParametroDetallexID(int intCodigo)
        {
            ParametroDetalle detalle = new ParametroDetalle();
            string StoredProcedure = "ParametroDetalleListarxID";
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
                    param.ParameterName = "intCodigo";
                    param.Value = intCodigo;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int intCodigoParametro = Int32.Parse(dr["intCodigoParametro"].ToString());
                            string strDescripcion = dr["vchDescripcion"].ToString();
                            string strValor = dr["vchValor"].ToString();
                            string strEstado = dr["chrEstado"].ToString();
                            detalle = new ParametroDetalle(intCodigo, intCodigoParametro, strDescripcion, strValor, strEstado);
                        }
                    }
                    con.Close();
                }
            }
            return detalle;
        }

        public List<ParametroDetalle> ListarParametroDetalle(int intCodigoParametro, bool bOrdenAscendente)
        {
            List<ParametroDetalle> lista = new List<ParametroDetalle>();
            string StoredProcedure = "ParametroDetalleListarxParametro";
            if (!bOrdenAscendente)
                StoredProcedure = "ParametroDetalleListarxParametroReciente";
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
                    param.ParameterName = "intCodigoParametro";
                    param.Value = intCodigoParametro;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int intCodigo = Int32.Parse(dr["intCodigo"].ToString());
                            string strDescripcion = dr["vchDescripcion"].ToString();
                            string strValor = dr["vchValor"].ToString();
                            string strEstado = dr["chrEstado"].ToString();
                            ParametroDetalle disa = new ParametroDetalle(intCodigo, intCodigoParametro, strDescripcion, strValor, strEstado);
                            lista.Add(disa);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public int ActualizarParametroDetalle(ParametroDetalle registro)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = registro.intCodigo;
            param.ParameterName = "intCodigo";
            parametros.Add(param);

            DbParameter param1 = BaseData.DbProvider.CreateParameter();
            param1.Value = registro.intCodigoParametro;
            param1.ParameterName = "intCodigoParametro";
            parametros.Add(param1);

            DbParameter paramNombre = BaseData.DbProvider.CreateParameter();
            paramNombre.Value = registro.vchDescripcion;
            paramNombre.ParameterName = "vchDescripcion";
            parametros.Add(paramNombre);

            DbParameter paramValor = BaseData.DbProvider.CreateParameter();
            paramValor.Value = registro.vchValor;
            paramValor.ParameterName = "vchValor";
            parametros.Add(paramValor);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = registro.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            return BaseData.ejecutaNonQuery("ParametroDetalleActualizar", parametros);
        }
    }
}
