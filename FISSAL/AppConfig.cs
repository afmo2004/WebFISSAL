using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using System.Data.SqlClient;
using System.Globalization;
using System.Collections;
using System.Data.Common;
using System.Data;

namespace FISSAL
{
    public static class AppConfig
    {
        //private static string connect = System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString;
        private static string connect = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexionFUA"].ConnectionString;
        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        public static string CadenaConexionFUA()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexionFUA"].ConnectionString != null)
            {
                strTmp = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaConexionFUA"].ConnectionString;
            }
            return strTmp;
        }

        public static string nombreAnio()
        {
            string strTmp = "";
            if (ConfigurationManager.AppSettings["AppNombreAnio"] != null)
            {
                strTmp = ConfigurationManager.AppSettings["AppNombreAnio"];
            }
            return strTmp;
        }

        public static string AppCultureInfo()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["AppCultureInfo"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["AppCultureInfo"];
            }
            return strTmp;
        }

        public static string Email()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["Email"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["Email"];
            }
            return strTmp;
        }

        public static string EmailSend()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["EmailSend"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["EmailSend"];
            }
            return strTmp;
        }

        public static string PasswordEmail()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["PasswordEmail"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["PasswordEmail"];
            }
            return strTmp;
        }
        public static string EmailHost()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["EmailHost"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["EmailHost"];
            }
            return strTmp;
        }
        public static int EmailHostPort()
        {
            int intTmp = 0;
            if (System.Configuration.ConfigurationManager.AppSettings["EmailHostPort"] != null)
            {
                intTmp = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["EmailHostPort"]);
            }
            return intTmp;
        }
        public static string VirtualPathString()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["VirtualPathString"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["VirtualPathString"];
            }
            return strTmp;
        }

        public static string PathStringUpload()
        {
            string strTmp = "";
            if (System.Configuration.ConfigurationManager.AppSettings["PathStringUpload"] != null)
            {
                strTmp = System.Configuration.ConfigurationManager.AppSettings["PathStringUpload"];
            }
            return strTmp;
        }

        //INICIO
        public static DataTable ConsultarSql(string SQLString)
        {
            if (connect == null) throw new ArgumentNullException("No se ha establecido Cadena de Conexión");
            if (SQLString == null || SQLString.Length == 0) throw new ArgumentNullException("Ingrese consulta");

            using (SqlConnection connection = new SqlConnection(connect))
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(SQLString, connection);
                    adaptador.Fill(ds, "tabla");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }

        public static DataSet ConsultarSqls(List<String> SQLStringList)
        {
            if (connect == null) throw new ArgumentNullException("No se ha establecido Cadena de Conexión");
            if (SQLStringList == null || SQLStringList.Count == 0) throw new ArgumentNullException("Ingrese consultas");
            using (SqlConnection connection = new SqlConnection(connect))
            {
                DataSet ds = new DataSet();
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        SqlDataAdapter adaptador = new SqlDataAdapter(strsql, connection);
                        adaptador.Fill(ds, "tabla" + n.ToString());
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        public static int EjecutarSql(string SQLString)
        {
            if (connect == null) throw new ArgumentNullException("No se ha establecido Cadena de Conexión");
            if (SQLString == null || SQLString.Length == 0) throw new ArgumentNullException("Ingrese consulta");

            using (SqlConnection connection = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    int affect = cmd.ExecuteNonQuery();
                    connection.Close();
                    return affect;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static int EjecutarSqls(List<String> SQLStringList)
        {
            if (connect == null) throw new ArgumentNullException("No se ha establecido Cadena de Conexión");
            if (SQLStringList == null || SQLStringList.Count == 0) throw new ArgumentNullException("Ingrese consultas");

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                SqlTransaction tx = connection.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }

        public static DataTable ConsultarProcedimiento(string spName, params object[] parameterValues)
        {
            if (connect == null) throw new ArgumentNullException("No se ha establecido Cadena de Conexión");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("Ingrese Store Procedure");

            using (SqlConnection connection = new SqlConnection(connect))
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlCommand cmd = new SqlCommand(spName, connection);
                    if ((parameterValues != null) && (parameterValues.Length > 0))
                        cmd.Parameters.AddRange(RecuperarParametros(spName, parameterValues));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "ta");
                    return ds.Tables[0];
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static List<object> EjecutarProcedimiento(string spName, params object[] parameterValues)
        {
            if (connect == null) throw new ArgumentNullException("No se ha establecido Cadena de Conexión");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("Ingrese Store Procedure");
            List<object> datos = new List<object>();
            using (SqlConnection connection = new SqlConnection(connect))
            {
                //try
                //{
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if ((parameterValues != null) && (parameterValues.Length > 0))
                {
                    SqlParameter[] parametros = RecuperarParametros(spName, parameterValues);
                    cmd.Parameters.AddRange(parametros);
                }
                connection.Open();
                int affect = cmd.ExecuteNonQuery();
                connection.Close();
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    if (cmd.Parameters[i].Direction == ParameterDirection.InputOutput || cmd.Parameters[i].Direction == ParameterDirection.Output)
                        datos.Add(cmd.Parameters[i].Value);
                }
                return datos;
                //}
                //catch
                //{
                //    return null;
                //}
            }
        }


        private static SqlParameter[] RecuperarParametros(string spName, params object[] parameterValues)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                string hashKey = connect + ":" + spName;
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlCommandBuilder.DeriveParameters(cmd);
                connection.Close();
                cmd.Parameters.RemoveAt(0);
                SqlParameter[] cachedParameters;
                cachedParameters = paramCache[hashKey] as SqlParameter[];

                if (cachedParameters == null)
                {
                    SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
                    cmd.Parameters.CopyTo(discoveredParameters, 0);
                    foreach (SqlParameter discoveredParameter in discoveredParameters)
                    {
                        discoveredParameter.Value = DBNull.Value;
                    }
                    paramCache[hashKey] = discoveredParameters;
                    cachedParameters = discoveredParameters;
                }

                SqlParameter[] clonedParameters = null;
                clonedParameters = new SqlParameter[cachedParameters.Length];
                for (int i = 0, j = cachedParameters.Length; i < j; i++)
                {
                    clonedParameters[i] = (SqlParameter)((ICloneable)cachedParameters[i]).Clone();
                }

                if (clonedParameters.Length != parameterValues.Length)
                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "Parameter count does not match Parameter Value count.", null));

                for (int i = 0, j = clonedParameters.Length; i < j; i++)
                {
                    if (parameterValues[i] is IDbDataParameter)
                    {
                        IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                        if (paramInstance.Value == null)
                            clonedParameters[i].Value = DBNull.Value;
                        else
                            clonedParameters[i].Value = paramInstance.Value;
                    }
                    else if (parameterValues[i] == null)
                        clonedParameters[i].Value = DBNull.Value;
                    else
                        clonedParameters[i].Value = parameterValues[i];
                }
                return clonedParameters;
            }
        }
        //FIN

    }
}