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
    public class FotografiaData
    {
        public Fotografia ListarFotografiaxID(int intCodigo)
        {
            Fotografia foto = new Fotografia();
            string StoredProcedure = "FotografiaListarxID";

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
                            string vchDescriptores = "";
                            if (!(dr["vchDescriptores"] is System.DBNull))
                                vchDescriptores = (string)dr["vchDescriptores"];
                            string vchCredito = "";
                            if (!(dr["vchCredito"] is System.DBNull))
                                vchCredito = (string)dr["vchCredito"];
                            string vchImagenPequena = "";
                            if (!(dr["vchImagenPequena"] is System.DBNull))
                                vchImagenPequena = (string)dr["vchImagenPequena"];
                            string vchImagenMediana = "";
                            if (!(dr["vchImagenMediana"] is System.DBNull))
                                vchImagenMediana = (string)dr["vchImagenMediana"];
                            foto = new Fotografia(
                                (int)dr["intCodigo"],
                                (string)dr["vchLeyenda"],
                                vchDescriptores,
                                vchCredito,
                                vchImagenPequena,
                                vchImagenMediana,
                                (string)dr["vchImagen"],
                                (string)dr["chrEstado"]);
                        }
                    }
                    con.Close();
                }
            }
            return foto;
        }

        public List<Fotografia> ListarFotografias()
        {
            List<Fotografia> lista = new List<Fotografia>();
            string StoredProcedure = "FotografiaListar";

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
                            int intCodigo = (int)dr["intCodigo"];
                            string vchLeyenda = (string)dr["vchLeyenda"];
                            string vchDescriptores = "";
                            if (!(dr["vchDescriptores"] is System.DBNull))
                                vchDescriptores = (string)dr["vchDescriptores"];
                            string vchCredito = "";
                            if (!(dr["vchCredito"] is System.DBNull))
                                vchCredito = (string)dr["vchCredito"];
                            string vchImagenPequena = "";
                            if (!(dr["vchImagenPequena"] is System.DBNull))
                                vchImagenPequena = (string)dr["vchImagenPequena"];
                            string vchImagenMediana = "";
                            if (!(dr["vchImagenMediana"] is System.DBNull))
                                vchImagenMediana = (string)dr["vchImagenMediana"];
                            Fotografia foto = new Fotografia(
                                    intCodigo,
                                    vchLeyenda,
                                    vchDescriptores,
                                    vchCredito,
                                    vchImagenPequena,
                                    vchImagenMediana,
                                    (string)dr["vchImagen"],
                                    (string)dr["chrEstado"]);
                            lista.Add(foto);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public int ActualizarFoto(int intCodigo, string vchLeyenda, string vchImagen, string chrEstado, string vchUsuarioCreacion, string vchUsuarioModificacion)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter paramCodigo = BaseData.DbProvider.CreateParameter();
            paramCodigo.Value = intCodigo;
            paramCodigo.ParameterName = "intCodigo";
            paramCodigo.Direction = ParameterDirection.InputOutput;
            parametros.Add(paramCodigo);

            DbParameter paramLeyenda = BaseData.DbProvider.CreateParameter();
            paramLeyenda.Value = vchLeyenda;
            paramLeyenda.ParameterName = "vchLeyenda";
            parametros.Add(paramLeyenda);

            DbParameter paramImagen = BaseData.DbProvider.CreateParameter();
            paramImagen.Value = vchImagen;
            paramImagen.ParameterName = "vchImagen";
            parametros.Add(paramImagen);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            BaseData.ejecutaNonQuery("FotografiaActualizar", parametros);

            intCodigo = int.Parse(paramCodigo.Value.ToString());

            return intCodigo;
        }

        public int InsertarFoto(int intCodigo, string vchLeyenda, string vchImagen, string chrEstado, string vchUsuarioCreacion, string vchUsuarioModificacion)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter paramCodigo = BaseData.DbProvider.CreateParameter();
            paramCodigo.Value = intCodigo;
            paramCodigo.ParameterName = "intCodigo";
            paramCodigo.Direction = ParameterDirection.InputOutput;
            parametros.Add(paramCodigo);

            DbParameter paramLeyenda = BaseData.DbProvider.CreateParameter();
            paramLeyenda.Value = vchLeyenda;
            paramLeyenda.ParameterName = "vchLeyenda";
            parametros.Add(paramLeyenda);

            DbParameter paramImagen = BaseData.DbProvider.CreateParameter();
            paramImagen.Value = vchImagen;
            paramImagen.ParameterName = "vchImagen";
            parametros.Add(paramImagen);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            intCodigo = BaseData.ejecutaEscalar("FotografiaInsertar", parametros);

            return intCodigo;
        }

        public void EliminarFoto(int intCodigo)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter paramCodigo = BaseData.DbProvider.CreateParameter();
            paramCodigo.Value = intCodigo;
            paramCodigo.ParameterName = "intCodigo";
            parametros.Add(paramCodigo);

            BaseData.ejecutaNonQuery("FotografiaEliminar", parametros);
        }
    }


}
