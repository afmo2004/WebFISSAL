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
    public class OpcionData
    {
        public List<Opcion> ListarOpcion()
        {
            List<Opcion> lista = new List<Opcion>();
            string StoredProcedure = "OpcionListar";
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
                            Opcion control = new Opcion(
                                (int)dr["intCodigoOpcion"],
                                (string)dr["vchNombreOpcion"],
                                (string)dr["vchPagina"],
                                (int)dr["intNivel"],
                                (int)dr["intOrden"],
                                (int)dr["intCodigoOpcionPadre"],
                                (string)dr["chrEstado"]);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public List<Opcion> ListarOpcionAsignado(string vchLogin, int intNivel, int intCodigoOpcionPadre)
        {
            List<Opcion> lista = new List<Opcion>();
            string StoredProcedure = "OpcionListarAsignado";
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
                    param.ParameterName = "vchLogin";
                    param.Value = vchLogin;
                    cmd.Parameters.Add(param);

                    DbParameter paramNivel = cmd.CreateParameter();
                    paramNivel.DbType = DbType.Int32;
                    paramNivel.ParameterName = "intNivel";
                    paramNivel.Value = intNivel;
                    cmd.Parameters.Add(paramNivel);

                    DbParameter paramPadre = cmd.CreateParameter();
                    paramPadre.DbType = DbType.Int32;
                    paramPadre.ParameterName = "intCodigoOpcionPadre";
                    paramPadre.Value = intCodigoOpcionPadre;
                    cmd.Parameters.Add(paramPadre);

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Opcion control = new Opcion(
                                (int)dr["intCodigoOpcion"],
                                (string)dr["vchNombreOpcion"],
                                (string)dr["vchPagina"],
                                (int)dr["intNivel"],
                                (int)dr["intOrden"],
                                (int)dr["intCodigoOpcionPadre"],
                                (string)dr["chrEstado"]);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public List<Opcion> ListarOpcionxNivel(int intNivel, int intCodigoOpcionPadre)
        {
            List<Opcion> lista = new List<Opcion>();
            string StoredProcedure = "OpcionListarxNivel";
            using (DbConnection con = BaseData.DbProvider.CreateConnection())
            {
                con.ConnectionString = BaseData.CadenaConexion;
                using (DbCommand cmd = BaseData.DbProvider.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramNivel = cmd.CreateParameter();
                    paramNivel.DbType = DbType.Int32;
                    paramNivel.ParameterName = "intNivel";
                    paramNivel.Value = intNivel;
                    cmd.Parameters.Add(paramNivel);

                    DbParameter paramPadre = cmd.CreateParameter();
                    paramPadre.DbType = DbType.Int32;
                    paramPadre.ParameterName = "intCodigoOpcionPadre";
                    paramPadre.Value = intCodigoOpcionPadre;
                    cmd.Parameters.Add(paramPadre);

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Opcion control = new Opcion(
                                (int)dr["intCodigoOpcion"],
                                (string)dr["vchNombreOpcion"],
                                (string)dr["vchPagina"],
                                (int)dr["intNivel"],
                                (int)dr["intOrden"],
                                (int)dr["intCodigoOpcionPadre"],
                                (string)dr["chrEstado"]);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }
    }
}
