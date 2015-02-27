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
    public class SugerenciaData
    {
        public List<Sugerencia> ListarSugerencias()
        {
            List<Sugerencia> lista = new List<Sugerencia>();
            string StoredProcedure = "SugerenciaListar";
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
                            Sugerencia control = new Sugerencia(
                                (int)dr["intCodigo"],
                                (int)dr["intTipo"],
                                (string)dr["chrTipoDocumento"],
                                (string)dr["vchNumeroDocumento"],
                                (string)dr["vchApellidoPaterno"],
                                (string)dr["vchApellidoMaterno"],
                                (string)dr["vchNombres"],
                                (string)dr["chrAsegurado"],
                                (string)dr["txtEspecificacion"],
                                (string)dr["vchNombreAsegurado"],
                                (string)dr["chrTipoDiagnostico"],
                                (string)dr["vchTelefono"],
                                (string)dr["vchCorreo"],
                                (string)dr["vchUbigeo"],
                                (string)dr["vchDireccion"],
                                (string)dr["txtDescripcion"],
                                (string)dr["vchEstablecimiento"],
                                (DateTime)dr["dtmFechaOcurrencia"]);
                            lista.Add(control);
                        }
                    }
                    con.Close();
                }
            }
            return lista;
        }

        public Sugerencia ListarSugerenciaxID(Int32 intCodigo)
        {
            Sugerencia registro = new Sugerencia();
            string StoredProcedure = "SugerenciaListarxID";
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
                            registro = new Sugerencia(
                                (int)dr["intCodigo"],
                                (int)dr["intTipo"],
                                (string)dr["chrTipoDocumento"],
                                (string)dr["vchNumeroDocumento"],
                                (string)dr["vchApellidoPaterno"],
                                (string)dr["vchApellidoMaterno"],
                                (string)dr["vchNombres"],
                                (string)dr["chrAsegurado"],
                                (string)dr["txtEspecificacion"],
                                (string)dr["vchNombreAsegurado"],
                                (string)dr["chrTipoDiagnostico"],
                                (string)dr["vchTelefono"],
                                (string)dr["vchCorreo"],
                                (string)dr["vchUbigeo"],
                                (string)dr["vchDireccion"],
                                (string)dr["txtDescripcion"],
                                (string)dr["vchEstablecimiento"],
                                (DateTime)dr["dtmFechaOcurrencia"]);
                        }
                    }
                    con.Close();
                }
            }
            return registro;
        }

        public int InsertarSugerencia(Sugerencia tabla)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param1 = BaseData.DbProvider.CreateParameter();
            param1.Value = tabla.intCodigo;
            param1.ParameterName = "intCodigo";
            parametros.Add(param1);

            DbParameter param2 = BaseData.DbProvider.CreateParameter();
            param2.Value = tabla.intTipo;
            param2.ParameterName = "intTipo";
            parametros.Add(param2);

            DbParameter param3 = BaseData.DbProvider.CreateParameter();
            param3.Value = tabla.chrTipoDocumento;
            param3.ParameterName = "chrTipoDocumento";
            parametros.Add(param3);

            DbParameter param4 = BaseData.DbProvider.CreateParameter();
            param4.Value = tabla.vchNumeroDocumento;
            param4.ParameterName = "vchNumeroDocumento";
            parametros.Add(param4);

            DbParameter param5 = BaseData.DbProvider.CreateParameter();
            param5.Value = tabla.vchApellidoPaterno;
            param5.ParameterName = "vchApellidoPaterno";
            parametros.Add(param5);

            DbParameter param6 = BaseData.DbProvider.CreateParameter();
            param6.Value = tabla.vchApellidoMaterno;
            param6.ParameterName = "vchApellidoMaterno";
            parametros.Add(param6);

            DbParameter param7 = BaseData.DbProvider.CreateParameter();
            param7.Value = tabla.vchNombres;
            param7.ParameterName = "vchNombres";
            parametros.Add(param7);

            DbParameter param8 = BaseData.DbProvider.CreateParameter();
            param8.Value = tabla.chrAsegurado;
            param8.ParameterName = "chrAsegurado";
            parametros.Add(param8);

            DbParameter param9 = BaseData.DbProvider.CreateParameter();
            param9.Value = tabla.txtEspecificacion;
            param9.ParameterName = "txtEspecificacion";
            parametros.Add(param9);

            DbParameter param10 = BaseData.DbProvider.CreateParameter();
            param10.Value = tabla.vchNombreAsegurado;
            param10.ParameterName = "vchNombreAsegurado";
            parametros.Add(param10);

            DbParameter param11 = BaseData.DbProvider.CreateParameter();
            param11.Value = tabla.chrTipoDiagnostico;
            param11.ParameterName = "chrTipoDiagnostico";
            parametros.Add(param11);

            DbParameter param12 = BaseData.DbProvider.CreateParameter();
            param12.Value = tabla.vchTelefono;
            param12.ParameterName = "vchTelefono";
            parametros.Add(param12);

            DbParameter param13 = BaseData.DbProvider.CreateParameter();
            param13.Value = tabla.vchCorreo;
            param13.ParameterName = "vchCorreo";
            parametros.Add(param13);

            DbParameter param14 = BaseData.DbProvider.CreateParameter();
            param14.Value = tabla.vchUbigeo;
            param14.ParameterName = "vchUbigeo";
            parametros.Add(param14);

            DbParameter param15 = BaseData.DbProvider.CreateParameter();
            param15.Value = tabla.vchDireccion;
            param15.ParameterName = "vchDireccion";
            parametros.Add(param15);

            DbParameter param16 = BaseData.DbProvider.CreateParameter();
            param16.Value = tabla.txtDescripcion;
            param16.ParameterName = "txtDescripcion";
            parametros.Add(param16);

            DbParameter param17 = BaseData.DbProvider.CreateParameter();
            param17.Value = tabla.vchEstablecimiento;
            param17.ParameterName = "vchEstablecimiento";
            parametros.Add(param17);

            DbParameter param18 = BaseData.DbProvider.CreateParameter();
            param18.Value = tabla.dtmFechaOcurrencia;
            param18.ParameterName = "dtmFechaOcurrencia";
            parametros.Add(param18);

            return BaseData.ejecutaNonQuery("SugerenciaInsertar", parametros);
        }
    }
}
