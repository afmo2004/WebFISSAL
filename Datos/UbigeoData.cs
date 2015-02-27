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
    public class UbigeoData
    {
        public List<Ubigeo> ListarDepartamentos()
        {
            List<Ubigeo> lstControles = new List<Ubigeo>();
            string StoredProcedure = "UbigeoListarDepartamentos";
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
                            int ubigeoId = Int32.Parse(dr["ubigeoId"].ToString());
                            string departamentoId = (string)dr["departamentoId"];
                            string provinciaId = (string)dr["provinciaId"];
                            string distritoId = (string)dr["distritoId"];
                            string descripcionUbigeo = (string)dr["descripcionUbigeo"];

                            Ubigeo control = new Ubigeo(
                                ubigeoId,
                                departamentoId,
                                provinciaId,
                                distritoId,
                                descripcionUbigeo);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public List<Ubigeo> ListarProvincias(string pstrDepartamentoId)
        {
            List<Ubigeo> lstControles = new List<Ubigeo>();
            string StoredProcedure = "UbigeoListarProvincias";
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
                    param.ParameterName = "departamentoId";
                    param.Value = pstrDepartamentoId;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int ubigeoId = Int32.Parse(dr["ubigeoId"].ToString());
                            string departamentoId = (string)dr["departamentoId"];
                            string provinciaId = (string)dr["provinciaId"];
                            string distritoId = (string)dr["distritoId"];
                            string descripcionUbigeo = (string)dr["descripcionUbigeo"];

                            Ubigeo control = new Ubigeo(
                                ubigeoId,
                                departamentoId,
                                provinciaId,
                                distritoId,
                                descripcionUbigeo);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public List<Ubigeo> ListarDistritos(string pstrDepartamentoId, string pstrProvinciaId)
        {
            List<Ubigeo> lstControles = new List<Ubigeo>();
            string StoredProcedure = "UbigeoListarDistritos";
            using (DbConnection con = BaseData.DbProvider.CreateConnection())
            {
                con.ConnectionString = BaseData.CadenaConexion;
                using (DbCommand cmd = BaseData.DbProvider.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbParameter paramDpto = cmd.CreateParameter();
                    paramDpto.DbType = DbType.String;
                    paramDpto.ParameterName = "departamentoId";
                    paramDpto.Value = pstrDepartamentoId;
                    cmd.Parameters.Add(paramDpto);
                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "provinciaId";
                    param.Value = pstrProvinciaId;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int ubigeoId = Int32.Parse(dr["ubigeoId"].ToString());
                            string departamentoId = (string)dr["departamentoId"];
                            string provinciaId = (string)dr["provinciaId"];
                            string distritoId = (string)dr["distritoId"];
                            string descripcionUbigeo = (string)dr["descripcionUbigeo"];

                            Ubigeo control = new Ubigeo(
                                ubigeoId,
                                departamentoId,
                                provinciaId,
                                distritoId,
                                descripcionUbigeo);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }
    }
}
