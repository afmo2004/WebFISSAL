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
    public class PerfilData
    {
        public PerfilData(){ }

        public List<Perfil> ListarPerfiles(string pstrBusqueda)
        {
            List<Perfil> lstPerfiles = new List<Perfil>();
            string StoredProcedure = "PerfilListar";

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
                    param.ParameterName = "vchNombrePerfil";
                    param.Value = pstrBusqueda;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Perfil usuario = new Perfil(
                                (int)dr["intCodigoPerfil"],
                                (string)dr["vchNombrePerfil"],
                                (string)dr["chrEstado"]);
                            lstPerfiles.Add(usuario);
                        }
                    }
                    con.Close();
                }
            }
            return lstPerfiles;
        }

        public Perfil ListaPerfilxID(int pintPerfilID)
        {
            Perfil perfil = new Perfil();
            string StoredProcedure = "PerfilListarxID";

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
                    param.ParameterName = "intCodigoPerfil";
                    param.Value = pintPerfilID;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            perfil = new Perfil(
                                (int)dr["intCodigoPerfil"],
                                (string)dr["vchNombrePerfil"],
                                (string)dr["chrEstado"]);
                        }
                    }
                    con.Close();
                }
            }
            return perfil;
        }

        public int ActualizarPerfil(Perfil perfil)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = perfil.intCodigoPerfil;
            param.ParameterName = "intCodigoPerfil";
            parametros.Add(param);

            DbParameter paramNombre = BaseData.DbProvider.CreateParameter();
            paramNombre.Value = perfil.vchNombrePerfil;
            paramNombre.ParameterName = "vchNombrePerfil";
            parametros.Add(paramNombre);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = perfil.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            return BaseData.ejecutaNonQuery("PerfilActualizar", parametros);
        }
    }
}
