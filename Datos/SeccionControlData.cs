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
    public class SeccionControlData
    {
        public List<SeccionControl> ListarControlesxSeccion(int intSeccion, string chrUbicacion)
        {
            List<SeccionControl> lstControles = new List<SeccionControl>();
            string StoredProcedure = "SeccionControlListarxSeccion";
            using (DbConnection con = BaseData.DbProvider.CreateConnection())
            {
                con.ConnectionString = BaseData.CadenaConexion;
                using (DbCommand cmd = BaseData.DbProvider.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter param1 = cmd.CreateParameter();
                    param1.DbType = DbType.Int32;
                    param1.ParameterName = "intSeccion";
                    param1.Value = intSeccion;
                    cmd.Parameters.Add(param1);

                    DbParameter param2 = cmd.CreateParameter();
                    param2.DbType = DbType.String;
                    param2.ParameterName = "chrUbicacion";
                    param2.Value = chrUbicacion;
                    cmd.Parameters.Add(param2);

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SeccionControl control = new SeccionControl(
                                (int)dr["intSeccion"],
                                (int)dr["intCodigoControl"],
                                (int)dr["intOrden"],
                                (string)dr["chrUbicacion"]);
                            lstControles.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lstControles;
        }

        public int ActualizarControlSeccion(SeccionControl seccionControl)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param1 = BaseData.DbProvider.CreateParameter();
            param1.Value = seccionControl.intSeccion;
            param1.ParameterName = "intSeccion";
            parametros.Add(param1);

            DbParameter param2 = BaseData.DbProvider.CreateParameter();
            param2.Value = seccionControl.intCodigoControl;
            param2.ParameterName = "intCodigoControl";
            parametros.Add(param2);

            DbParameter param3 = BaseData.DbProvider.CreateParameter();
            param3.Value = seccionControl.intOrden;
            param3.ParameterName = "intOrden";
            parametros.Add(param3);

            DbParameter param4 = BaseData.DbProvider.CreateParameter();
            param4.Value = seccionControl.chrUbicacion;
            param4.ParameterName = "chrUbicacion";
            parametros.Add(param4);

            return BaseData.ejecutaNonQuery("SeccionControlActualizar", parametros);
        }

        public int ActualizarControlSeccionOrden(SeccionControl seccionControl)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param1 = BaseData.DbProvider.CreateParameter();
            param1.Value = seccionControl.intSeccion;
            param1.ParameterName = "intSeccion";
            parametros.Add(param1);

            DbParameter param2 = BaseData.DbProvider.CreateParameter();
            param2.Value = seccionControl.intCodigoControl;
            param2.ParameterName = "intCodigoControl";
            parametros.Add(param2);

            DbParameter param3 = BaseData.DbProvider.CreateParameter();
            param3.Value = seccionControl.intOrden;
            param3.ParameterName = "intOrden";
            parametros.Add(param3);

            return BaseData.ejecutaNonQuery("SeccionControlActualizarOrden", parametros);
        }

        public int EliminarControlSeccion(SeccionControl seccionControl)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param1 = BaseData.DbProvider.CreateParameter();
            param1.Value = seccionControl.intSeccion;
            param1.ParameterName = "intSeccion";
            parametros.Add(param1);

            DbParameter param2 = BaseData.DbProvider.CreateParameter();
            param2.Value = seccionControl.intCodigoControl;
            param2.ParameterName = "intCodigoControl";
            parametros.Add(param2);

            return BaseData.ejecutaNonQuery("SeccionControlEliminar", parametros);
        }
    }
}
