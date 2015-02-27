using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;


namespace FISSAL.Datos
{
    public class BaseData
    {

       

        public static string CadenaConexion
        {
            get { return ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString; }
        }

        public static string Provider
        {
            get { return ConfigurationManager.ConnectionStrings["CadenaConexion"].ProviderName; }
        }

        public static DbProviderFactory DbProvider
        {
            get
            {
                return DbProviderFactories.GetFactory(Provider);
            }
        }

        public static int ejecutaNonQuery(string StoredProcedure, List<DbParameter> parametros)
        {
            int Id = 0;
            try
            {
                using (DbConnection con = DbProvider.CreateConnection())
                {
                    con.ConnectionString = CadenaConexion;

                    using (DbCommand cmd = DbProvider.CreateCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (DbParameter param in parametros)
                            cmd.Parameters.Add(param);
                        con.Open();
                        Id = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // conecction.close();
            }
            return Id;
        }

        public static int ejecutaEscalar(string StoredProcedure, List<DbParameter> parametros)
        {
            int Id = 0;
            try
            {
                using (DbConnection con = DbProvider.CreateConnection())
                {
                    con.ConnectionString = CadenaConexion;

                    using (DbCommand cmd = DbProvider.CreateCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (DbParameter param in parametros)
                            cmd.Parameters.Add(param);
                        con.Open();
                        Id = (int)cmd.ExecuteScalar();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                // conecction.close();
            }
            return Id;
        }
 
    }



}
