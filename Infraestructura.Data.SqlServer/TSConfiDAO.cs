using Dominio.Entidades;
using Dominio.Entidades.Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Infraestructura.Data.SqlServer
{
    
   public class TSConfiDAO:Conexion
    {
        //8.5
        public TSConfi ConsultarTSConfi_xCod(long intIdSesion,int intIdMenu,int intIdSoft,string strCoConfi, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            TSConfi objConfi = null;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCONFI_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strCoConfi", strCoConfi);
                //salida
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    objConfi = new TSConfi();
                    objConfi.intIdConfi = reader.GetInt32(0);
                    objConfi.strCoConfi = reader.GetString(1);
                    objConfi.strDesConfi = reader.GetString(2);
                    objConfi.strValorConfi = reader.GetString(3);
                    objConfi.strPosibValor = reader.GetString(4);
                }
                reader.Close();
                
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return objConfi;
        }

        //1.16: listar Configuraciones para mostrarse en la ventana de Configuración.
        public List<TSConfi> ListarConfig(Session_Movi objSession, string strCoConfi, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSConfi> listaConf= new List<TSConfi>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCONFI_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@strCoConfi", strCoConfi);
                //salida
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TSConfi obj = new TSConfi();

                        obj.intIdConfi = reader.GetInt32(0);
                        obj.strCoConfi = reader.GetString(1);
                        obj.strValorConfi = reader.GetString(2);
                        obj.tipoControl = reader.GetString(3);
                        obj.bitFlActivo = reader.GetBoolean(4);

                        listaConf.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listaConf;
        }

        //1.17: Actualizar configuraciones de la ventana de Configuración.
        public bool UpdateDetalleConfig(Session_Movi objSession, DataTable tt_config, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool tudobem = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCONFI_U01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@TT_TSCONFI", tt_config);
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                tudobem = true;
            }
            return tudobem;
        }


        //CAMBIOS AÑADIDOS JULIO - ESUYON
        #region CAMBIOSJULIO
        public List<TSConfi> ListarCliWeb(ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSConfi> listaConf = new List<TSConfi>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCLI_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                //salida
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TSConfi obj = new TSConfi();
                        obj.strValorConfi = reader.GetString(0);
                        listaConf.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listaConf;
        }

        public bool ICliWeb(string IPCli, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool tudobem = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCLI_I00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//añadido 15.04.2021 ES
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@IPCli", IPCli);
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                tudobem = true;
            }
            return tudobem;
        }

        #endregion CAMBIOSJULIO


        //método de prueba 13.04.2021
        public EN_TMEncuesta Datos_EnviarRespuesta_Encuesta_JSql(string JSON)
        {
            EN_TMEncuesta obj = new EN_TMEncuesta();
            string strRespuesta = "";
            //int IDTEMP = 0;
            try
            {
                var deserealize = new JavaScriptSerializer();
                List<EN_TMEncuesta> listaBoletos = deserealize.Deserialize<List<EN_TMEncuesta>>(JSON);
                EN_TMEncuesta objBol = null;

                DataTable dt = new DataTable();
                dt.Columns.Add("ID_ENCUESTA_PREGUNTA_OPCION_RESPUESTA", typeof(string));
                dt.Columns.Add("ID_ENCUESTA_PREGUNTA", typeof(string));
                dt.Columns.Add("NOM_ENCUESTA_PREGUNTA_OPCION", typeof(string));
                //IDTEMP = Convert.ToInt32(DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second);

                using (SqlConnection cn = new SqlConnection(cadCnx))
                {
                    cn.Open();
                    using (SqlTransaction trans = cn.BeginTransaction())
                    {
                        try
                        {
                            for (int i = 0; i < listaBoletos.Count; i++)
                            {
                                objBol = new EN_TMEncuesta();
                                objBol = listaBoletos[i];

                                DataRow rows = dt.NewRow();
                                rows[0] = objBol.ID_ENCUESTA_PREGUNTA_OPCION_RESPUESTA;
                                rows[1] = objBol.ID_ENCUESTA_PREGUNTA;
                                rows[2] = objBol.NOM_ENCUESTA_PREGUNTA_OPCION;
                                SqlDataReader reader;
                                using (SqlCommand cmd = new SqlCommand("USP_TECFLEX_ENCUESTA_PREGUNTA_OPCION_RESPUESTA_REGISTRAR", cn))
                                {
                                    cmd.Transaction = trans;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("ID_ENCUESTA_PREGUNTA_OPCION_RESPUESTA", SqlDbType.Int).Value = int.Parse(objBol.ID_ENCUESTA_PREGUNTA_OPCION_RESPUESTA);
                                    cmd.Parameters.Add("ID_ENCUESTA_PREGUNTA", SqlDbType.TinyInt).Value = int.Parse(objBol.ID_ENCUESTA_PREGUNTA);
                                    cmd.Parameters.Add("NOM_ENCUESTA_PREGUNTA_OPCION", SqlDbType.VarChar).Value = objBol.NOM_ENCUESTA_PREGUNTA_OPCION;

                                    reader = cmd.ExecuteReader();
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            obj.IND_OPERACION = reader.GetInt32(0);
                                            obj.FEC_ENCUESTA_COMPLETADA = reader.GetString(1);
                                        }
                                        cmd.Dispose();
                                    }
                                    reader.Close();
                                }
                                //cn.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                        trans.Commit();
                    }
                    cn.Close();
                }
            }
            catch (System.Exception ex)
            {
                strRespuesta = "No se pudo completar la insercion de las respuestas: " + ex.Message;
                //if (Context.Trace.IsEnabled)
                //    Context.Trace.Warn("Método Datos_EnviarRespuesta_Encuesta_JSql", strRespuesta);

                //throw new SoapException(strRespuesta, SoapException.ClientFaultCode);
            }
            return obj;
        }





    }
}
