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
    public class ControlData
    {
        public List<Control> ListarControlxTipo(string pstrTipo)
        {
            List<Control> lstControles = new List<Control>();
            string StoredProcedure = "ControlListarxTipo";
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
                    param.ParameterName = "chrTipoControl";
                    param.Value = pstrTipo;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Control control = new Control(
                                (int)dr["intCodigoControl"],
                                (string)dr["vchNombreControl"],
                                (string)dr["vchControl"],
                                (string)dr["chrTipoControl"],
                                (string)dr["chrEstado"]);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public Control ListaControlxID(int pintCodigoControl)
        {
            Control control = new Control();
            string StoredProcedure = "ControlListarxID";

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
                    param.ParameterName = "intCodigoControl";
                    param.Value = pintCodigoControl;
                    cmd.Parameters.Add(param);
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            control = new Control(
                                (int)dr["intCodigoControl"],
                                (string)dr["vchNombreControl"],
                                (string)dr["vchControl"],
                                (string)dr["chrTipoControl"],
                                (string)dr["chrEstado"]);
                        }
                    }
                    con.Close();
                }
            }
            return control;
        }

        public int ActualizarControl(Control control)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = BaseData.DbProvider.CreateParameter();
            param.Value = control.intCodigoControl;
            param.ParameterName = "intCodigoControl";
            parametros.Add(param);

            DbParameter paramNombre = BaseData.DbProvider.CreateParameter();
            paramNombre.Value = control.vchNombreControl;
            paramNombre.ParameterName = "vchNombreControl";
            parametros.Add(paramNombre);

            DbParameter paramControl = BaseData.DbProvider.CreateParameter();
            paramControl.Value = control.vchControl;
            paramControl.ParameterName = "vchControl";
            parametros.Add(paramControl);

            DbParameter paramTipo = BaseData.DbProvider.CreateParameter();
            paramTipo.Value = control.chrTipoControl;
            paramTipo.ParameterName = "chrTipoControl";
            parametros.Add(paramTipo);

            DbParameter paramEstado = BaseData.DbProvider.CreateParameter();
            paramEstado.Value = control.chrEstado;
            paramEstado.ParameterName = "chrEstado";
            parametros.Add(paramEstado);

            DbParameter paramUsuarioCreacion = BaseData.DbProvider.CreateParameter();
            paramUsuarioCreacion.Value = control.vchUsuarioCreacion;
            paramUsuarioCreacion.ParameterName = "vchUsuarioCreacion";
            parametros.Add(paramUsuarioCreacion);

            DbParameter paramUsuarioMod = BaseData.DbProvider.CreateParameter();
            paramUsuarioMod.Value = control.vchUsuarioModificacion;
            paramUsuarioMod.ParameterName = "vchUsuarioModificacion";
            parametros.Add(paramUsuarioMod);

            return BaseData.ejecutaNonQuery("ControlActualizar", parametros);
        }
    }
}
