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
    public class ContactoData
    {
        public List<Contacto> ListarContactenos()
        {
            List<Contacto> lista = new List<Contacto>();
            string StoredProcedure = "ContactoListar";
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
                            Contacto control = new Contacto(
                                (int)dr["intCodigo"],
                                (string)dr["vchNombreApellido"],
                                (string)dr["vchEmail"],
                                (string)dr["vchTelefono"],
                                (string)dr["txtMensaje"],
                                (DateTime)dr["dtmFechaCreacion"]);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public Contacto ListarContactenosxID(Int32 intCodigo)
        {
            Contacto registro = new Contacto();
            string StoredProcedure = "ContactoListarxID";
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
                        while (dr.Read())
                        {
                            registro = new Contacto(
                                (int)dr["intCodigo"],
                                (string)dr["vchNombreApellido"],
                                (string)dr["vchEmail"],
                                (string)dr["vchTelefono"],
                                (string)dr["txtMensaje"],
                                (DateTime)dr["dtmFechaCreacion"]);
                        }
                    }
                    con.Close();
                }
            }
            return registro;
        }

        public int InsertarContactenos(Contacto tabla)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param1 = BaseData.DbProvider.CreateParameter();
            param1.Value = tabla.intCodigo;
            param1.ParameterName = "intCodigo";
            parametros.Add(param1);

            DbParameter param2 = BaseData.DbProvider.CreateParameter();
            param2.Value = tabla.vchNombreApellido;
            param2.ParameterName = "vchNombreApellido";
            parametros.Add(param2);


            DbParameter param3 = BaseData.DbProvider.CreateParameter();
            param3.Value = tabla.vchEmail;
            param3.ParameterName = "vchEmail";
            parametros.Add(param3);

            DbParameter param4 = BaseData.DbProvider.CreateParameter();
            param4.Value = tabla.vchTelefono;
            param4.ParameterName = "vchTelefono";
            parametros.Add(param4);

            DbParameter param5 = BaseData.DbProvider.CreateParameter();
            param5.Value = tabla.txtMensaje;
            param5.ParameterName = "txtMensaje";
            parametros.Add(param5);

            return BaseData.ejecutaNonQuery("ContactoInsertar", parametros);
        }
    }
}
