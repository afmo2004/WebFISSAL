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
    public class MaterialData
    {
        public Material ListarMaterialxId(int pintCodigo)
        {
            Material material = new Material();
            string StoredProcedure = "MaterialListarxId";
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
                    param.ParameterName = "intMaterial";
                    param.Value = pintCodigo;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            material = new Material(
                                (int)dr["intMaterial"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchDescripcion"],
                                (int)dr["intTipo"],
                                (string)dr["vchImagen"],
                                (string)dr["vchArchivo"],
                                (string)dr["chrEstado"],
                                (DateTime)dr["dtmFechaPublicacion"]);
                        }
                    }
                    con.Close();
                }
            }
            return material;
        }

        public List<Material> ListarMaterial()
        {
            List<Material> lstControles = new List<Material>();
            string StoredProcedure = "MaterialListar";
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
                            Material control = new Material(
                                (int)dr["intMaterial"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchDescripcion"],
                                (int)dr["intTipo"],
                                (string)dr["vchImagen"],
                                (string)dr["vchArchivo"],
                                (string)dr["chrEstado"],
                                (DateTime)dr["dtmFechaPublicacion"]);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public List<Material> ListarMaterialActivo()
        {
            List<Material> lstControles = new List<Material>();
            string StoredProcedure = "MaterialListar";
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
                            Material control = new Material(
                                (int)dr["intMaterial"],
                                (string)dr["vchTitulo"],
                                (string)dr["vchDescripcion"],
                                (int)dr["intTipo"],
                                (string)dr["vchImagen"],
                                (string)dr["vchArchivo"],
                                (string)dr["chrEstado"],
                                (DateTime)dr["dtmFechaPublicacion"]);
                            if (control.chrEstado.Equals("1"))
                                lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public int ActualizarMaterial(Material material)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = material.intMaterial;
            param.Direction = ParameterDirection.InputOutput;
            param.ParameterName = "intMaterial";
            parametros.Add(param);

            DbParameter paramTitulo = BaseData.DbProvider.CreateParameter();
            paramTitulo.Value = material.vchTitulo;
            paramTitulo.ParameterName = "vchTitulo";
            parametros.Add(paramTitulo);

            DbParameter paramDescripcion = BaseData.DbProvider.CreateParameter();
            paramDescripcion.Value = material.vchDescripcion;
            paramDescripcion.ParameterName = "vchDescripcion";
            parametros.Add(paramDescripcion);

            DbParameter paramTipo = BaseData.DbProvider.CreateParameter();
            paramTipo.Value = material.intTipo;
            paramTipo.ParameterName = "intTipo";
            parametros.Add(paramTipo);

            DbParameter paramImagen = BaseData.DbProvider.CreateParameter();
            paramImagen.Value = material.vchImagen;
            paramImagen.ParameterName = "vchImagen";
            parametros.Add(paramImagen);

            DbParameter paramArchivo = BaseData.DbProvider.CreateParameter();
            paramArchivo.Value = material.vchArchivo;
            paramArchivo.ParameterName = "vchArchivo";
            parametros.Add(paramArchivo);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = material.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramFecha = BaseData.DbProvider.CreateParameter();
            paramFecha.Value = material.dtmFechaPublicacion;
            paramFecha.ParameterName = "dtmFechaPublicacion";
            parametros.Add(paramFecha);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = material.vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = material.vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            return BaseData.ejecutaEscalar("MaterialActualizar", parametros);
        }
    }
}
