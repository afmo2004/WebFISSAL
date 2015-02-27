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
    public class NoticiaData
    {
        public Noticia ListarNoticiaxID(int intCodigo)
        {
            Noticia nota = new Noticia();
            string StoredProcedure = "NoticiaListarxID";

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
                        if (dr.Read())
                        {
                            string vchURL = "";
                            if (!(dr["vchURL"] is System.DBNull))
                                vchURL = (string)dr["vchURL"];
                            nota = new Noticia(
                                (int)dr["intCodigo"],
                                (DateTime)dr["dtmFechaPublicacion"],
                                (string)dr["vchVolada"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchBajada"],
                                (string)dr["vchFechado"],
                                (string)dr["vchCredito"],
                                (string)dr["txtLead"],
                                (string)dr["txtContenido"],
                                (string)dr["chrEstado"],
                                vchURL);
                        }
                    }
                }
            }
            return nota;
        }

        public List<Noticia> ListarNoticias()
        {
            List<Noticia> lista = new List<Noticia>();
            string StoredProcedure = "NoticiaListar";
            int intContador = 0;
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
                            intContador++;
                            string vchURL = "";
                            if (!(dr["vchURL"] is System.DBNull))
                                vchURL = (string)dr["vchURL"];
                            Noticia control = new Noticia(
                                (int)dr["intCodigo"],
                                (DateTime)dr["dtmFechaPublicacion"],
                                (string)dr["vchVolada"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchBajada"],
                                (string)dr["vchFechado"],
                                (string)dr["vchCredito"],
                                (string)dr["txtLead"],
                                (string)dr["txtContenido"],
                                (string)dr["chrEstado"],
                                vchURL);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public List<Noticia> ListarNoticiaHome()
        {
            List<Noticia> lista = new List<Noticia>();
            string StoredProcedure = "NoticiaListarHome";
            int intContador = 0;
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
                            intContador++;
                            string vchURL = "";
                            if (!(dr["vchURL"] is System.DBNull))
                                vchURL = (string)dr["vchURL"];
                            Noticia control = new Noticia(
                                (int)dr["intCodigo"],
                                (DateTime)dr["dtmFechaPublicacion"],
                                (string)dr["vchVolada"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchBajada"],
                                (string)dr["vchFechado"],
                                (string)dr["vchCredito"],
                                (string)dr["txtLead"],
                                (string)dr["txtContenido"],
                                (string)dr["chrEstado"],
                                vchURL);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public List<Noticia> ListarNoticiaUltimos(int intCantidad)
        {
            List<Noticia> lista = new List<Noticia>();
            string StoredProcedure = "NoticiaListarUltimos";
            int intContador = 0;
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
                            intContador++;
                            string vchURL = "";
                            if (!(dr["vchURL"] is System.DBNull))
                                vchURL = (string)dr["vchURL"];
                            Noticia control = new Noticia(
                                (int)dr["intCodigo"],
                                (DateTime)dr["dtmFechaPublicacion"],
                                (string)dr["vchVolada"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchBajada"],
                                (string)dr["vchFechado"],
                                (string)dr["vchCredito"],
                                (string)dr["txtLead"],
                                (string)dr["txtContenido"],
                                (string)dr["chrEstado"],
                                vchURL);
                            lista.Add(control);
                            if (intContador == intCantidad)
                                break;
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public List<Noticia> ListarNoticiaPortadaSeccion()
        {
            List<Noticia> lista = new List<Noticia>();
            string StoredProcedure = "NoticiaListarUltimosTop";
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
                            string vchURL = "";
                            if (!(dr["vchURL"] is System.DBNull))
                                vchURL = (string)dr["vchURL"];
                            Noticia control = new Noticia(
                                (int)dr["intCodigo"],
                                (DateTime)dr["dtmFechaPublicacion"],
                                (string)dr["vchVolada"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchBajada"],
                                (string)dr["vchFechado"],
                                (string)dr["vchCredito"],
                                (string)dr["txtLead"],
                                (string)dr["txtContenido"],
                                (string)dr["chrEstado"],
                                vchURL);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public List<Noticia> ListarNoticiaSeccion()
        {
            List<Noticia> lista = new List<Noticia>();
            string StoredProcedure = "NoticiaListarSeccion";
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
                            string vchURL = "";
                            if (!(dr["vchURL"] is System.DBNull))
                                vchURL = (string)dr["vchURL"];
                            Noticia control = new Noticia(
                                (int)dr["intCodigo"],
                                (DateTime)dr["dtmFechaPublicacion"],
                                (string)dr["vchVolada"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchBajada"],
                                (string)dr["vchFechado"],
                                (string)dr["vchCredito"],
                                (string)dr["txtLead"],
                                (string)dr["txtContenido"],
                                (string)dr["chrEstado"],
                                vchURL);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public List<Noticia> ListarNoticiaSeccionActivo()
        {
            List<Noticia> lista = new List<Noticia>();
            string StoredProcedure = "NoticiaListarSeccion";
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
                            string vchURL = "";
                            if (!(dr["vchURL"] is System.DBNull))
                                vchURL = (string)dr["vchURL"];
                            Noticia control = new Noticia(
                                (int)dr["intCodigo"],
                                (DateTime)dr["dtmFechaPublicacion"],
                                (string)dr["vchVolada"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchBajada"],
                                (string)dr["vchFechado"],
                                (string)dr["vchCredito"],
                                (string)dr["txtLead"],
                                (string)dr["txtContenido"],
                                (string)dr["chrEstado"],
                                vchURL);
                            if (control.chrEstado.Equals("1"))
                                lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public int ActualizarNoticia(Noticia noticia)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = noticia.intCodigo;
            param.ParameterName = "intCodigo";
            parametros.Add(param);

            DbParameter paramFecha = BaseData.DbProvider.CreateParameter();
            paramFecha.Value = noticia.dtmFechaPublicacion;
            paramFecha.ParameterName = "dtmFechaPublicacion";
            parametros.Add(paramFecha);

            DbParameter paramNombre = BaseData.DbProvider.CreateParameter();
            paramNombre.Value = noticia.vchVolada;
            paramNombre.ParameterName = "vchVolada";
            parametros.Add(paramNombre);

            DbParameter paramControl = BaseData.DbProvider.CreateParameter();
            paramControl.Value = noticia.vchTitulo;
            paramControl.ParameterName = "vchTitulo";
            parametros.Add(paramControl);

            DbParameter paramTipo = BaseData.DbProvider.CreateParameter();
            paramTipo.Value = noticia.vchBajada;
            paramTipo.ParameterName = "vchBajada";
            parametros.Add(paramTipo);

            DbParameter paramFechado = BaseData.DbProvider.CreateParameter();
            paramFechado.Value = noticia.vchFechado;
            paramFechado.ParameterName = "vchFechado";
            parametros.Add(paramFechado);

            DbParameter paramCredito = BaseData.DbProvider.CreateParameter();
            paramCredito.Value = noticia.vchCredito;
            paramCredito.ParameterName = "vchCredito";
            parametros.Add(paramCredito);

            DbParameter paramLead = BaseData.DbProvider.CreateParameter();
            paramLead.Value = noticia.txtLead;
            paramLead.ParameterName = "txtLead";
            parametros.Add(paramLead);

            DbParameter paramContenido = BaseData.DbProvider.CreateParameter();
            paramContenido.Value = noticia.txtContenido;
            paramContenido.ParameterName = "txtContenido";
            parametros.Add(paramContenido);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = noticia.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = noticia.vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = noticia.vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            DbParameter paramURL = BaseData.DbProvider.CreateParameter();
            paramURL.Value = noticia.vchURL;
            paramURL.ParameterName = "vchURL";
            parametros.Add(paramURL);

            return BaseData.ejecutaNonQuery("NoticiaActualizar", parametros);
        }

        public int InsertarNoticia(Noticia noticia)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = noticia.intCodigo;
            param.ParameterName = "intCodigo";
            param.Direction = ParameterDirection.InputOutput;
            parametros.Add(param);

            DbParameter paramFecha = BaseData.DbProvider.CreateParameter();
            paramFecha.Value = noticia.dtmFechaPublicacion;
            paramFecha.ParameterName = "dtmFechaPublicacion";
            parametros.Add(paramFecha);

            DbParameter paramNombre = BaseData.DbProvider.CreateParameter();
            paramNombre.Value = noticia.vchVolada;
            paramNombre.ParameterName = "vchVolada";
            parametros.Add(paramNombre);

            DbParameter paramControl = BaseData.DbProvider.CreateParameter();
            paramControl.Value = noticia.vchTitulo;
            paramControl.ParameterName = "vchTitulo";
            parametros.Add(paramControl);

            DbParameter paramTipo = BaseData.DbProvider.CreateParameter();
            paramTipo.Value = noticia.vchBajada;
            paramTipo.ParameterName = "vchBajada";
            parametros.Add(paramTipo);

            DbParameter paramFechado = BaseData.DbProvider.CreateParameter();
            paramFechado.Value = noticia.vchFechado;
            paramFechado.ParameterName = "vchFechado";
            parametros.Add(paramFechado);

            DbParameter paramCredito = BaseData.DbProvider.CreateParameter();
            paramCredito.Value = noticia.vchCredito;
            paramCredito.ParameterName = "vchCredito";
            parametros.Add(paramCredito);

            DbParameter paramLead = BaseData.DbProvider.CreateParameter();
            paramLead.Value = noticia.txtLead;
            paramLead.ParameterName = "txtLead";
            parametros.Add(paramLead);

            DbParameter paramContenido = BaseData.DbProvider.CreateParameter();
            paramContenido.Value = noticia.txtContenido;
            paramContenido.ParameterName = "txtContenido";
            parametros.Add(paramContenido);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = noticia.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = noticia.vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = noticia.vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            DbParameter paramURL = BaseData.DbProvider.CreateParameter();
            paramURL.Value = noticia.vchURL;
            paramURL.ParameterName = "vchURL";
            parametros.Add(paramURL);

            noticia.intCodigo = BaseData.ejecutaEscalar("NoticiaInsertar", parametros);

            return noticia.intCodigo;
        }
    }
}
