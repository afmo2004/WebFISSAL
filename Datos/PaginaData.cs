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
    public class PaginaData
    {
        public Pagina ListarPaginaxID(int intPagina)
        {
            Pagina pagina = new Pagina();
            string StoredProcedure = "PaginaListarxID";

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
                    param.ParameterName = "intPagina";
                    param.Value = intPagina;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            pagina = new Pagina(
                                (int)dr["intPagina"],
                                (string)dr["vchNombrePagina"],
                                (string)dr["vchPagina"],
                                (string)dr["txtLead"],
                                (string)dr["txtContenido"],
                                (string)dr["chrEstado"]);
                        }
                    }
                    con.Close();
                }
            }
            return pagina;
        }

        public List<Pagina> ListarPaginas()
        {
            List<Pagina> lstControles = new List<Pagina>();
            string StoredProcedure = "PaginaListar";
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
                            Pagina control = new Pagina(
                                (int)dr["intPagina"],
                                (string)dr["vchNombrePagina"],
                                (string)dr["vchPagina"],
                                (string)dr["txtLead"],
                                (string)dr["txtContenido"],
                                (string)dr["chrEstado"]);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public int ActualizarPagina(Pagina pagina)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = pagina.intPagina;
            param.ParameterName = "intPagina";
            parametros.Add(param);

            DbParameter paramNombrePagina = BaseData.DbProvider.CreateParameter();
            paramNombrePagina.Value = pagina.vchNombrePagina;
            paramNombrePagina.ParameterName = "vchNombrePagina";
            parametros.Add(paramNombrePagina);

            DbParameter paramPagina = BaseData.DbProvider.CreateParameter();
            paramPagina.Value = pagina.vchPagina;
            paramPagina.ParameterName = "vchPagina";
            parametros.Add(paramPagina);

            DbParameter paramLead = BaseData.DbProvider.CreateParameter();
            paramLead.Value = pagina.txtLead;
            paramLead.ParameterName = "txtLead";
            parametros.Add(paramLead);

            DbParameter paramContenido = BaseData.DbProvider.CreateParameter();
            paramContenido.Value = pagina.txtContenido;
            paramContenido.ParameterName = "txtContenido";
            parametros.Add(paramContenido);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = pagina.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = pagina.vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = pagina.vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            return BaseData.ejecutaNonQuery("PaginaActualizar", parametros);
        }
    }
}
