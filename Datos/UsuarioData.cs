using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Common;
using System.Data;
using FISSAL.Entidad;

namespace FISSAL.Datos
{
    public class UsuarioData
    {
        public UsuarioData()
        { }

        public List<Usuario> ListarUsuarios(string pstrBusqueda)
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            string StoredProcedure = "UsuarioListar";

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
                    param.ParameterName = "vchNombreUsuario";
                    param.Value = pstrBusqueda;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Usuario usuario = new Usuario(
                                (int)dr["intCodigoUsuario"],
                                (string)dr["vchLogin"],
                                (string)dr["vchPassword"],
                                (string)dr["vchNombreUsuario"],
                                (int)dr["intPerfil"],
                                (string)dr["chrEstado"]);
                            lstUsuarios.Add(usuario);
                        }
                    }
                    con.Close();
                }
            }
            return lstUsuarios;
        }

        public Usuario ListaUsuarioxLogin(string pstrLogin)
        {
            Usuario usuario = new Usuario();
            string StoredProcedure = "UsuarioxLogin";

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
                    param.Value = pstrLogin;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario(
                                (int)dr["intCodigoUsuario"],
                                (string)dr["vchLogin"],
                                (string)dr["vchPassword"],
                                (string)dr["vchNombreUsuario"],
                                (int)dr["intPerfil"],
                                (string)dr["chrEstado"]);
                        }
                    }
                    con.Close();
                }
            }
            return usuario;
        }

        public Usuario ListaUsuarioxLoginPassword(string pstrLogin, string pstrPassword)
        {
            Usuario usuario = new Usuario();
            string StoredProcedure = "UsuarioxLoginPassword";

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
                    param.Value = pstrLogin;
                    cmd.Parameters.Add(param);

                    param = cmd.CreateParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "vchPassword";
                    param.Value = pstrPassword;
                    cmd.Parameters.Add(param);

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario(
                                (int)dr["intCodigoUsuario"],
                                (string)dr["vchLogin"],
                                (string)dr["vchPassword"],
                                (string)dr["vchNombreUsuario"],
                                (int)dr["intPerfil"],
                                (string)dr["chrEstado"]);
                        }
                    }
                    con.Close();
                }
            }
            return usuario;
        }

        public int ActualizarUsuario(Usuario usuario)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = usuario.intCodigoUsuario;
            param.ParameterName = "intCodigoUsuario";
            parametros.Add(param);

            DbParameter paramLogin = BaseData.DbProvider.CreateParameter();
            paramLogin.Value = usuario.vchLogin;
            paramLogin.ParameterName = "vchLogin";
            parametros.Add(paramLogin);

            DbParameter paramPassword = BaseData.DbProvider.CreateParameter();
            paramPassword.Value = usuario.vchPassword;
            paramPassword.ParameterName = "vchPassword";
            parametros.Add(paramPassword);

            DbParameter paramNombre = BaseData.DbProvider.CreateParameter();
            paramNombre.Value = usuario.vchNombreUsuario;
            paramNombre.ParameterName = "vchNombreUsuario";
            parametros.Add(paramNombre);

            DbParameter paramPerfil = BaseData.DbProvider.CreateParameter();
            paramPerfil.Value = usuario.intPerfil;
            paramPerfil.ParameterName = "intPerfil";
            parametros.Add(paramPerfil);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = usuario.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            return BaseData.ejecutaNonQuery("UsuarioActualizar", parametros);
        }
    }
}
