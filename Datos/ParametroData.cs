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
    public class ParametroData
    {
        public List<Parametro> ListarParametro()
        {
            List<Parametro> lista = new List<Parametro>();
            string StoredProcedure = "ParametroListar";
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
                            Parametro control = new Parametro(
                                (int)dr["intCodigo"],
                                (string)dr["vchNombre"]);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public Parametro ListarParametroxID(int intCodigo)
        {
            Parametro registro = new Parametro();
            string StoredProcedure = "ParametroListarxID";
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
                            registro = new Parametro(
                                (int)dr["intCodigo"],
                                (string)dr["vchNombre"]);
                        }
                    }
                    con.Close();
                }
            }
            return registro;
        }

        public int ActualizarParametro(Parametro registro)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = registro.intCodigo;
            param.ParameterName = "intCodigo";
            parametros.Add(param);

            DbParameter paramNombre = BaseData.DbProvider.CreateParameter();
            paramNombre.Value = registro.vchNombre;
            paramNombre.ParameterName = "vchNombre";
            parametros.Add(paramNombre);

            return BaseData.ejecutaNonQuery("ParametroActualizar", parametros);
        }
    }
}
