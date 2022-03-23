using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infraestructura.Data.SqlServer
{
    public class EmpleadoDAO : Conexion
    {
        private UsuarioDAO objUsuario = new UsuarioDAO();

        #region Pagina Principal
        //5.1
        public List<TSPTAASISTENCIA> ListarAsistenciaDiaria(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSPTAASISTENCIA> listobj = new List<TSPTAASISTENCIA>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_Q02", cn);//TSP_DASHBOARD_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", Convert.ToString(dttFechaIni));
                param.Add("@filtrojer_fin", Convert.ToString(dttFechaFin));
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TSPTAASISTENCIA obj = new TSPTAASISTENCIA();

                        obj.anio = reader.GetInt32(0);
                        obj.mes = reader.GetInt32(1);
                        obj.asistencia = reader.GetInt32(2);
                        obj.faltas = reader.GetInt32(3);

                        listobj.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        //5.2
        public List<DiaAusen> ListarDiasAusencia(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<DiaAusen> listobj = new List<DiaAusen>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_DASHBOARD_Q02", cn);//
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", Convert.ToString(dttFechaIni));
                param.Add("@filtrojer_fin", Convert.ToString(dttFechaFin));
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DiaAusen obj = new DiaAusen();

                        obj.intIdConcepto = reader.GetInt32(0);
                        obj.strCoConcepto = reader.GetString(1);
                        obj.strDesConcepto = reader.GetString(2);
                        obj.intTotalDias = reader.GetInt32(3);

                        listobj.Add(obj);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        //5.3
        public List<HomeCabe> ListarCabeceras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HomeCabe> listobj = new List<HomeCabe>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_DASHBOARD_Q03", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", Convert.ToString(dttFechaIni));
                param.Add("@filtrojer_fin", Convert.ToString(dttFechaFin));
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HomeCabe obj = new HomeCabe();

                        obj.icon = reader.GetString(0);
                        obj.titulo = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                        {
                            obj.valor = reader.GetString(2);
                        }
                        obj.pie = reader.GetString(3);

                        listobj.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        //5.4
        public List<HorasDesc> ListarHorasDescontadas(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HorasDesc> listobj = new List<HorasDesc>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_DASHBOARD_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", Convert.ToString(dttFechaIni));
                param.Add("@filtrojer_fin", Convert.ToString(dttFechaFin));
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HorasDesc obj = new HorasDesc();

                        obj.intIdConcepto = reader.GetInt32(0);
                        obj.strCoConcepto = reader.GetString(1);
                        obj.strDesConcepto = reader.GetString(2);
                        obj.intTotalHrs = reader.GetInt32(3);
                        obj.strTotalHrs = reader.GetString(4);
                        listobj.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        //5.5
        public List<HorasDesc> ListarHorasExtras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HorasDesc> listobj = new List<HorasDesc>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_DASHBOARD_Q05", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", Convert.ToString(dttFechaIni));
                param.Add("@filtrojer_fin", Convert.ToString(dttFechaFin));
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HorasDesc obj = new HorasDesc();

                        obj.intIdConcepto = reader.GetInt32(0);
                        obj.strCoConcepto = reader.GetString(1);
                        obj.strDesConcepto = reader.GetString(2);
                        obj.intTotalHrs = reader.GetInt32(3);
                        obj.strTotalHrs = reader.GetString(4);

                        listobj.Add(obj);
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }

        #endregion

        #region Empleado
        //5.6
        public List<TGPER_CON_DET> ListaAsusencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGPER_CON_DET> lista = new List<TGPER_CON_DET>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", fechaInicio);
                param.Add("@filtrojer_fin", fechaFin);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TGPER_CON_DET obj = new TGPER_CON_DET();

                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.intIdConcepto = reader.GetInt32(1);
                    obj.strCoConcepto = reader.GetString(2);
                    obj.strDesConcepto = reader.GetString(3);
                    obj.strDeTipo = reader.GetString(4);
                    obj.strCoTipo = reader.GetString(5);
                    obj.intTotalDias = reader.GetInt32(6);
                    obj.intTotalHoras = reader.GetDecimal(7);
                    obj.intTope = reader.GetInt32(8);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.7
        public List<TGPER_CON_DET> ListaAsistencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGPER_CON_DET> lista = new List<TGPER_CON_DET>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_Q03", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", fechaInicio);
                param.Add("@filtrojer_fin", fechaFin);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TGPER_CON_DET obj = new TGPER_CON_DET();

                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.intIdConcepto = reader.GetInt32(1);
                    obj.strCoConcepto = reader.GetString(2);
                    obj.strDesConcepto = reader.GetString(3);
                    obj.strDeTipo = reader.GetString(4);
                    obj.strCoTipo = reader.GetString(5);
                    obj.intTotalDias = reader.GetInt32(6);
                    obj.intTotalHoras = reader.GetInt32(7);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.8
        public List<TGPER_RESP> ListaPersonalResponsabilidad(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGPER_RESP> lista = new List<TGPER_RESP>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_RESP_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", Convert.ToString(fechaInicio));
                param.Add("@filtrojer_fin", Convert.ToString(fechaFin));

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TGPER_RESP obj = new TGPER_RESP();

                    obj.intIdPerRespDet = reader.GetInt32(0);
                    obj.intIdPersonal = reader.GetInt32(1);
                    obj.strCoPersonal = reader.GetString(2);
                    obj.strNombresComp = reader.GetString(3);
                    obj.intIdTipoResp = reader.GetInt32(4);
                    obj.strDeTipo = reader.GetString(5);
                    obj.strDesCargo = reader.GetString(6);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.9
        public List<PersonalData> ListarPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, int intIdUniOrg, string strfilter, string dttfiltrofch1, string dttfiltrofch2, int BitFecha, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)//modificado
        {
            List<PersonalData> lista = new List<PersonalData>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERSONAL_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);


                param.Add("@intActivo", intActivoFilter);
                param.Add("@intIdUniOrg", intIdUniOrg);
                param.Add("@strfiltro", strfilter);
                param.Add("@dttfiltrofch1", Convert.ToString(dttfiltrofch1));
                param.Add("@dttfiltrofch2", Convert.ToString(dttfiltrofch2));
                param.Add("@bitFecha", BitFecha); //añadido 22.07.2021
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PersonalData obj = new PersonalData();

                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.strCoPersonal = reader.GetString(1);
                    obj.strNumDoc = reader.GetString(2);
                    obj.strNombres = reader.GetString(3);
                    obj.dttFecAdmin = Convert.ToString(reader.GetString(4));
                    obj.bitEspecifica_DESC = reader.GetString(5);


                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.10
        public List<TGTipoEN> ListarCombos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@strEntidad", strEntidad);
                param.Add("@intIdFiltroGrupo", intIdFiltroGrupo);

                param.Add("@strGrupo", strGrupo);
                param.Add("@strSubGrupo", strSubGrupo);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TGTipoEN obj = new TGTipoEN();

                    obj.intidTipo = reader.GetInt32(0);
                    obj.strDeTipo = reader.GetString(1);

                    if (strEntidad == "TGCONCEPTO" && strGrupo == "AUSENTISMO" && strSubGrupo == "AUSENTISMO")
                    {
                        obj.strCoTipo = reader.GetString(2);
                        obj.bitFlActivo = reader.GetBoolean(3);
                    }
                    else if (strEntidad == "TGREPORTE" && strGrupo == "TGREPORTE")
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    else if ((strEntidad == "TGPERIODO" && strGrupo == "TGPERIODOXANIO") || (strEntidad == "TGPERIODO" && strGrupo == "TGPERIODOXPLANILLA"))
                    {
                        obj.strextra1 = reader.GetString(2);
                        obj.strextra2 = reader.GetString(3);
                    }
                    else if (strEntidad == "TGUNIDORG" && strGrupo == "JERAR" && strSubGrupo == "REPORTE")
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    else if (strEntidad == "TGTIPO" && strGrupo == "TGTIPOMARCA")
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    //HGM Añadido para Mant. Perfil sin el vue - Cargado de menus Editar Perfil 09.08.21
                    else if (strEntidad == "TGPERFIL_MENU_SIN_VUE" && strGrupo == "CHECK_SIN_VUE")
                    {
                        obj.strCoMenuRela = reader.GetString(2);
                    }
                    else if (strEntidad == "TGVAC" && strGrupo == "FILTROS" && strSubGrupo == "PERIODO")
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    else if (strEntidad == "TGVAC" && strGrupo == "NUEVOANIO" && strSubGrupo == "PERIODO")
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    else if (strEntidad == "TGTIPO" && strGrupo == "CAL" && strSubGrupo == "HOR")//AÑADIDO 03.09.2021
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    else if (strEntidad == "TGTIPO" && strGrupo == "CAL" && strSubGrupo == "TURN")//AÑADIDO 03.09.2021
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    else if (strEntidad == "TGTIPO" && strGrupo == "CAL" && strSubGrupo == "REF")//AÑADIDO 03.09.2021
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    else if (strEntidad == "TGCONCEPTO" && strGrupo == "REPORTE" && strSubGrupo == "REPORTES")//añadido 09.09.2021
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    else if (strEntidad == "TGCONCEPTO" && strGrupo == "FER" && strSubGrupo == "FER")//añadido 21.09.2021
                    {
                        obj.strextra1 = reader.GetString(2);
                    }
                    lista.Add(obj);

                }

                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.11
        public List<TGTipoEN> ListarComboJerar(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@strEntidad", strEntidad);
                param.Add("@intIdFiltroGrupo", intIdFiltroGrupo);

                param.Add("@strGrupo", strGrupo);
                param.Add("@strSubGrupo", strSubGrupo);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();




                while (reader.Read())
                {
                    TGTipoEN obj = new TGTipoEN();

                    obj.intidTipo = reader.GetInt32(0);
                    obj.strDeTipo = reader.GetString(1);
                    obj.strextra1 = reader.GetString(2);
                    obj.strextra2 = reader.GetString(3);
                    lista.Add(obj);

                }



                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.12
        public List<Personal> ObtenerEmpleadoPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Personal> listDetCar = new List<Personal>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERSONAL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Personal obj = new Personal();
                        obj.intIdPersonal = reader.GetInt32(0);
                        obj.strCoPersonal = reader.GetString(1);
                        obj.strNumRegis = reader.GetString(2);
                        obj.strFotocheck = reader.GetString(3);
                        obj.intIdTipDoc = reader.GetInt32(4);
                        obj.strTipoDoc = reader.GetString(5);
                        obj.strNumDoc = reader.GetString(6);
                        obj.strNombres = reader.GetString(7);
                        obj.strApeMaterno = reader.GetString(9);
                        obj.strApePaterno = reader.GetString(8);
                        obj.dttFecNacim = reader.GetString(11);
                        obj.bitflSexo = reader.GetBoolean(12);
                        if (!reader.IsDBNull(14))
                        {
                            obj.intIdTipoVia = reader.GetInt32(14);
                        }
                        obj.strDireccion = reader.GetString(15);
                        if (!reader.IsDBNull(16))
                        {
                            obj.intIdUbigeo = reader.GetInt32(16);
                        }
                        if (!reader.IsDBNull(17))
                        {
                            obj.imgFoto = reader.GetString(17);
                        }
                        obj.intIdUniOrg = reader.GetInt32(18);
                        obj.intIdPlanilla = reader.GetInt32(19);
                        obj.intIdCargo = reader.GetInt32(20);
                        obj.intIdCateg = reader.GetInt32(21);
                        obj.intIdTiPers = reader.GetInt32(22);
                        obj.intIdGrupo = reader.GetInt32(23);
                        obj.intIdCCosto = reader.GetInt32(24);
                        obj.intIdTipFisc = reader.GetInt32(25);
                        obj.intIdTipoResp = reader.GetInt32(26);
                        obj.bitContratoInd = reader.GetBoolean(27);
                        obj.dttFecAdmin = reader.GetString(28);
                        obj.dttFecCese = reader.GetString(29);
                        obj.intIdMotiCese = reader.GetInt32(30);
                        obj.intIdGrupoLiq = reader.GetInt32(31);
                        obj.bitFlSubsidio = reader.GetBoolean(32);
                        obj.bitFlLinCred = reader.GetBoolean(33);
                        obj.strPersoCampo1 = reader.GetString(34);
                        obj.strPersoCampo2 = reader.GetString(35);
                        obj.strPersoCampo3 = reader.GetString(36);
                        obj.strPersoCampo4 = reader.GetString(37);
                        obj.strPersoCampo5 = reader.GetString(38);
                        obj.bitFlActivo = reader.GetBoolean(39);
                        if (!reader.IsDBNull(41))
                        {
                            obj.intIdUbigSup = reader.GetInt32(41);
                        }
                        if (!reader.IsDBNull(46))
                        {
                            obj.intIdUbiSupReg = reader.GetInt32(46);
                        }
                        if (!reader.IsDBNull(47))
                        {
                            obj.intIdUbiReg = reader.GetInt32(47);
                        }
                        if (!reader.IsDBNull(48))
                        {
                            obj.intIdUbiSupPais = reader.GetInt32(48);
                        }
                        if (!reader.IsDBNull(49))
                        {
                            obj.intIdUbiPais = reader.GetInt32(49);
                        }
                        if (!reader.IsDBNull(50))
                        {
                            obj.intIdJerOrg = reader.GetInt32(50);
                        }
                        if (!reader.IsDBNull(51))
                        {
                            obj.strDescripcion = reader.GetString(51);
                        }
                        if (!reader.IsDBNull(52))
                        {
                            obj.strCodExterior = reader.GetString(52);
                        }
                        if (!reader.IsDBNull(53))
                        {
                            obj.strCodPensionista = reader.GetString(53);
                        }
                        if (!reader.IsDBNull(54))
                        {
                            obj.strCodSalud = reader.GetString(54);
                        }
                        if (!reader.IsDBNull(55))
                        {
                            obj.bitSubsidioAlimentacion = reader.GetBoolean(55);
                        }
                        if (!reader.IsDBNull(56))
                        {
                            obj.bitLineaCredito = reader.GetBoolean(56);
                        }
                        if (!reader.IsDBNull(57))
                        {
                            obj.intIdReglaNeg = reader.GetInt32(57);
                        }
                        if (!reader.IsDBNull(58))
                        {
                            obj.intIdHorario = reader.GetInt32(58);
                        }
                        if (!reader.IsDBNull(59))
                        {
                            obj.bitActivarUsuario = reader.GetBoolean(59);
                        }
                        obj.strCabe = reader.GetString(60);
                        obj.strDeta = reader.GetString(61);
                        obj.strDesCargo = reader.GetString(62);
                        if (!reader.IsDBNull(63))
                        {
                            obj.strDirUbi = reader.GetString(63);
                        }
                        obj.intIdUniOrgSup = reader.GetInt32(64);
                        obj.intIdLocal = reader.GetInt32(65);
                        obj.strDir = reader.GetString(66);
                        if (!reader.IsDBNull(67))
                        {
                            obj.bitPerfilAdmin = reader.GetBoolean(67);
                        }
                        if (!reader.IsDBNull(68))
                        {
                            obj.intIdPerfil = reader.GetInt32(68);
                        }
                        if (!reader.IsDBNull(69))
                        {
                            obj.bitFlfotomovil = reader.GetBoolean(69);
                        }
                        if (!reader.IsDBNull(70))//añadido 16.08.2021
                        {
                            obj.bitGestionVac = reader.GetBoolean(70);
                        }
                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }
        //5.13
        public List<ValidarIdentidad_ENT> ValidarDocIdentidad(int intIdSesion, int intIdMenu, int intIdSoft, int intIdTipDoc, string strNumDoc, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            //int intIdExiste = 0;
            List<ValidarIdentidad_ENT> lista = new List<ValidarIdentidad_ENT>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TMPERSONAL_Q11", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada

                //Parámetros de Salida
                param.Add("@intIdTipDoc", intIdTipDoc);
                param.Add("@strNumDoc", strNumDoc);
                param.Add("@Existe", 0);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ValidarIdentidad_ENT obj = new ValidarIdentidad_ENT();
                        obj.intExiste = reader.GetInt32(0);
                        obj.strCodPersonal = reader.GetString(1);
                        obj.strNumRegist = reader.GetString(2);
                        obj.intTipoDoc = reader.GetInt32(3);
                        obj.strNumDoc = reader.GetString(4);
                        obj.strObservacion = reader.GetString(5);
                        obj.intIdPersonal = reader.GetInt32(6);

                        lista.Add(obj);
                    }

                }

                int result = cmd.ExecuteNonQuery();
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //5.15
        public Dictionary<string, string> ActivarUsuario(Session_Movi objSession, int intIdPersonal, string contrasena, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            Dictionary<string, string> objeto = new Dictionary<string, string>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_ACTIVAR_USUARIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@contrasena", contrasena);

                param.Add("@intIdUsuario", objSession.intIdUsuario);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    objeto.Add("nombres", reader.GetString(0));
                    objeto.Add("correo", reader.GetString(1));
                    objeto.Add("numeroDoc", reader.GetString(2));
                    objeto.Add("contraOut", reader.GetString(3));
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return objeto;
        }
        //5.16
        public string ValidarEmail(Session_Movi objSession, string numDoc, string correo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            string salida = "";

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_VALIDAR_EMAIL", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);

                param.Add("@numDoc", numDoc);
                param.Add("@correo", correo);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                salida = cmd.ExecuteScalar().ToString();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return salida;
        }
        //5.17
        public bool EliminarEmpleado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERSONAL_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);

                param.Add("@intIdPersonal", intIdPersonal);

                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                exito = Transaction(cn, cmd);

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            
            return exito;
        }
        //5.19 - Método personalizado para COMEDOR
        public int IUEmpleado_T(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, MarcaDni ObjMarcaConDni, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos,
            List<TGPERRESPDET> listaDetallesResponsabilidad, List<TGPERMARCDET> listaDetallesMarcadores, List<TGPERCOOR> listaCoor, int intIdUsuario, int intIdUsuarModif, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {
            int intIdOut = 0;
            int Rpta_SP = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(cadCnx))
                {
                    cn.Open();
                    using (SqlTransaction trans = cn.BeginTransaction())
                    {
                        try
                        {
                            //Codificar contraseña actual para validacion
                            string Pass_ = "@" + objDatos.strApePaterno.Substring(0, 1).ToUpper() + objDatos.strApePaterno.Substring(1).ToLower() + objDatos.strNumDoc.Trim();
                            string strcontraseña2 = objUsuario.EncriptarPassword(Pass_);//encapsulado 15.04.2021 ES

                            SqlCommand cmd = new SqlCommand("TSP_TGPERSONAL_IU01", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);
                            if (intTipoOperacion == 1)
                            {
                                param.Add("@intIdPersonal", 0); 
                            }
                            else
                            {
                                param.Add("@intIdPersonal", objDatos.intIdPersonal);
                            }
                            param.Add("@strCoPersonal", objDatos.strCoPersonal);
                            param.Add("@strNumRegis", objDatos.strNumRegis);
                            param.Add("@strFotocheck", objDatos.strFotocheck);
                            param.Add("@tinIdTipDoc", objDatos.intIdTipDoc);
                            param.Add("@strNumDoc", objDatos.strNumDoc);
                            param.Add("@strNombres", objDatos.strNombres);
                            param.Add("@strApePaterno", objDatos.strApePaterno);
                            param.Add("@strApeMaterno", objDatos.strApeMaterno);
                            param.Add("@dttFecNacim", objDatos.dttFecNacim);
                            param.Add("@bitflSexo", objDatos.bitflSexo);
                            param.Add("@intIdTipoVia", (object)objDatos.intIdTipoVia ?? DBNull.Value);
                            param.Add("@strDireccion", (object)objDatos.strDireccion ?? DBNull.Value);
                            param.Add("@intIdUbigeo", (object)objDatos.intIdUbigeo ?? DBNull.Value);
                            param.Add("@imgFoto", (object)objDatos.imgFoto ?? DBNull.Value);
                            param.Add("@intIdUniOrg", (object)objDatos.intIdUniOrg ?? DBNull.Value);
                            param.Add("@intIdPlanilla", (object)objDatos.intIdPlanilla ?? DBNull.Value);
                            param.Add("@intIdCargo", (object)objDatos.intIdCargo ?? DBNull.Value);
                            param.Add("@intIdCateg", (object)objDatos.intIdCateg ?? DBNull.Value);
                            param.Add("@intIdTiPers", (object)objDatos.intIdTiPers ?? DBNull.Value);
                            param.Add("@intIdGrupo", (object)objDatos.intIdGrupo ?? DBNull.Value);
                            param.Add("@intIdCCosto", (object)objDatos.intIdCCosto ?? DBNull.Value);
                            param.Add("@intIdTipFisc", (object)objDatos.intIdTipFisc ?? DBNull.Value);
                            param.Add("@intIdTipoResp", (object)objDatos.intIdTipoResp ?? DBNull.Value);
                            param.Add("@bitContratoInd", (object)objDatos.bitContratoInd ?? DBNull.Value);
                            param.Add("@dttFecAdmin", (object)objDatos.dttFecAdmin ?? DBNull.Value);
                            param.Add("@dttFecCese", (object)objDatos.dttFecCese ?? DBNull.Value);
                            if (objDatos.intIdMotiCese == 0)
                            {
                                param.Add("@intIdMotiCese", DBNull.Value);
                            }
                            else
                            {
                                param.Add("@intIdMotiCese", (object)objDatos.intIdMotiCese ?? DBNull.Value);
                            }
                            param.Add("@intIdGrupoLiq", (object)objDatos.intIdGrupoLiq ?? DBNull.Value);
                            param.Add("@bitFlSubsidio", (object)objDatos.bitFlSubsidio ?? DBNull.Value);
                            param.Add("@bitFlLinCred", (object)objDatos.bitFlLinCred ?? DBNull.Value);
                            param.Add("@strPersoCampo1", (object)objDatos.strPersoCampo1 ?? DBNull.Value);
                            param.Add("@strPersoCampo2", (object)objDatos.strPersoCampo2 ?? DBNull.Value);
                            param.Add("@strPersoCampo3", (object)objDatos.strPersoCampo3 ?? DBNull.Value);
                            param.Add("@strPersoCampo4", (object)objDatos.strPersoCampo4 ?? DBNull.Value);
                            param.Add("@strPersoCampo5", (object)objDatos.strPersoCampo5 ?? DBNull.Value);
                            param.Add("@bitFlActivo", objDatos.bitFlActivo);
                            param.Add("@intIdUsuario", intIdUsuario);
                            param.Add("@strCodExterior", (object)objDatos.strCodExterior ?? DBNull.Value);
                            param.Add("@strCodPensionista", (object)objDatos.strCodPensionista ?? DBNull.Value);
                            param.Add("@strCodSalud", (object)objDatos.strCodSalud ?? DBNull.Value);
                            param.Add("@bitSubsidioAlimentacion", (object)objDatos.bitSubsidioAlimentacion ?? DBNull.Value);
                            param.Add("@bitLineaCredito", (object)objDatos.bitLineaCredito ?? DBNull.Value);
                            param.Add("@intIdReglaNeg", (object)objDatos.intIdReglaNeg ?? DBNull.Value);
                            param.Add("@intIdHorario", (object)objDatos.intIdHorario ?? DBNull.Value);
                            param.Add("@bitActivarUsuario", (object)objDatos.bitActivarUsuario ?? DBNull.Value);
                            param.Add("@strCoPassword", strcontraseña2);
                            param.Add("@intIdUniOrgSup", (object)objDatos.intIdUniOrgSup ?? DBNull.Value);
                            param.Add("@intIdLocal", (object)objDatos.intIdLocal ?? DBNull.Value);
                            param.Add("@bitPerfilAdmin", (object)objDatos.bitPerfilAdmin ?? DBNull.Value);
                            param.Add("@intIdPerfil", (object)objDatos.intIdPerfil ?? DBNull.Value);
                            param.Add("@bitFlfotomovil", (object)objDatos.bitFlfotomovil ?? DBNull.Value);
                            param.Add("@bitFlGestionVac", (object)objDatos.bitGestionVac ?? DBNull.Value);//añadido 16.08.2021
                            param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                            //Parámetros de Salida
                            param.Add("@intResult", 0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");

                            AsignarParametros(cmd, param);
                            cmd.ExecuteNonQuery();         //

                            intIdOut = Convert.ToInt32(cmd.Parameters["@intIdPersonal"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            if (intIdOut > 0 && intResult > 0)
                            {
                                //----- Marca Con DNI ------------------------------------------------
                                SqlCommand cmd0 = new SqlCommand("TSP_TGPER_MARCA_DNI_IU01", cn);
                                cmd0.Transaction = trans;
                                cmd0.CommandType = CommandType.StoredProcedure;
                                cmd0.CommandTimeout = timeSQL;
                                Dictionary<string, object> param0 = new Dictionary<string, object>();
                                param0.Add("@intIdSesion", intIdSesion);
                                param0.Add("@intIdMenu", intIdMenu);
                                param0.Add("@intIdSoft", intIdSoft);
                                param0.Add("@intIdPersonal", intIdOut); //De donde??
                                param0.Add("@dttFeIni", (object)ObjMarcaConDni.dttFechaInicioVegencia ?? DBNull.Value);
                                param0.Add("@dttFeFin", (object)ObjMarcaConDni.dttFechaFinVegencia ?? DBNull.Value);
                                param0.Add("@bitHabilitar", ObjMarcaConDni.bitHabilitarMarcaDNI);
                                param0.Add("@bitHabilitaSupervisor", ObjMarcaConDni.bitHabilitarSupervisorCom);
                                param0.Add("@intIdUsuario", intIdUsuario);
                                intResult = 0;
                                param0.Add("@intResult", intResult);
                                param0.Add("@strMsjDB", "");
                                param0.Add("@strMsjUsuario", "");

                                AsignarParametros(cmd0, param0);
                                cmd0.ExecuteNonQuery();

                                intResult = Convert.ToInt32(cmd0.Parameters["@intResult"].Value.ToString());
                                strMsjDB = cmd0.Parameters["@strMsjDB"].Value.ToString();
                                strMsjUsuario = cmd0.Parameters["@strMsjUsuario"].Value.ToString();

                                if (intIdOut > 0 && intResult > 0)
                                {
                                    //----- TABLA 1: detalle de Correos ------------------------------------------------
                                    DataTable tb1 = SerealizeDetallePersonalCorreo(listaDetallesCorreos, intIdOut);

                                    SqlCommand cmd1 = new SqlCommand("TSP_TGPER_CORR_DET_IU02", cn);
                                    cmd1.Transaction = trans;
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.CommandTimeout = timeSQL;
                                    Dictionary<string, object> param1 = new Dictionary<string, object>();
                                    param1.Add("@intIdSesion", intIdSesion);
                                    param1.Add("@intIdMenu", intIdMenu);
                                    param1.Add("@intIdSoft", intIdSoft);
                                    param1.Add("@tt_TGPER_CORR_DET", tb1);
                                    param1.Add("@intIdUsuario", intIdUsuario);
                                    intResult = 0;
                                    param1.Add("@intResult", intResult);
                                    param1.Add("@strMsjDB", "");
                                    param1.Add("@strMsjUsuario", "");

                                    AsignarParametros(cmd1, param1);
                                    cmd1.ExecuteNonQuery();
                                    intResult = Convert.ToInt32(cmd1.Parameters["@intResult"].Value.ToString());
                                    strMsjDB = cmd1.Parameters["@strMsjDB"].Value.ToString();
                                    strMsjUsuario = cmd1.Parameters["@strMsjUsuario"].Value.ToString();

                                    if (intIdOut > 0 && intResult > 0)
                                    {        
                                        //intResult = 0;
                                        //----- TABLA 2: detalle de Telefonos ------------------------------------------------
                                        DataTable tb2 = SerealizeDetallePersonalTelefono(listaDetallesTelefonos, intIdOut);

                                        SqlCommand cmd2 = new SqlCommand("TSP_TGPER_TELEF_DET_IU02", cn);
                                        cmd2.Transaction = trans;
                                        cmd2.CommandType = CommandType.StoredProcedure;
                                        cmd2.CommandTimeout = timeSQL;
                                        Dictionary<string, object> param2 = new Dictionary<string, object>();
                                        param2.Add("@intIdSesion", intIdSesion);
                                        param2.Add("@intIdMenu", intIdMenu);
                                        param2.Add("@intIdSoft", intIdSoft);
                                        param2.Add("@tt_TGPER_TELEF_DET", tb2);
                                        param2.Add("@intIdUsuario", intIdUsuario);                            
                                        param2.Add("@intIdPersonal", intIdOut);//Añadido HGM 04.11.2021
                                        intResult = 0;
                                        param2.Add("@intResult", intResult);
                                        param2.Add("@strMsjDB", "");
                                        param2.Add("@strMsjUsuario", "");
                                

                                        AsignarParametros(cmd2, param2);
                                        cmd2.ExecuteNonQuery();
                                        intResult = Convert.ToInt32(cmd2.Parameters["@intResult"].Value.ToString());
                                        strMsjDB = cmd2.Parameters["@strMsjDB"].Value.ToString();
                                        strMsjUsuario = cmd2.Parameters["@strMsjUsuario"].Value.ToString();

                                        if (intIdOut > 0 && intResult > 0)
                                        {
                                            //----- TABLA 3: detalle de Marcadores ------------------------------------------------
                                            DataTable tb3 = SerealizeDetallePersonalMarcadores(listaDetallesMarcadores, intIdOut, intIdSoft);

                                            SqlCommand cmd3 = new SqlCommand("TSP_TGPER_MARC_DET_IU02", cn);
                                            cmd3.Transaction = trans;
                                            cmd3.CommandType = CommandType.StoredProcedure;
                                            cmd3.CommandTimeout = timeSQL;
                                            Dictionary<string, object> param3 = new Dictionary<string, object>();
                                            param3.Add("@intIdSesion", intIdSesion);
                                            param3.Add("@intIdMenu", intIdMenu);
                                            param3.Add("@intIdSoft", intIdSoft);
                                            param3.Add("@tt_TGPER_MARC_DET", tb3);
                                            param3.Add("@intIdUsuario", intIdUsuario);
                                            intResult = 0;
                                            param3.Add("@intResult", intResult);
                                            param3.Add("@strMsjDB", "");
                                            param3.Add("@strMsjUsuario", "");

                                            AsignarParametros(cmd3, param3);
                                            cmd3.ExecuteNonQuery();
                                            intResult = Convert.ToInt32(cmd3.Parameters["@intResult"].Value.ToString());
                                            strMsjDB = cmd3.Parameters["@strMsjDB"].Value.ToString();
                                            strMsjUsuario = cmd3.Parameters["@strMsjUsuario"].Value.ToString();

                                            if (intIdOut > 0 && intResult > 0)
                                            {
                                                //----- TABLA 4: detalle de Responsabilidad ------------------------------------------------
                                                DataTable tb4 = SerealizeDetallePersonalResponsabilidad(listaDetallesResponsabilidad, intIdOut);

                                                SqlCommand cmd4 = new SqlCommand("TSP_TGPER_RESP_DET_IU02", cn);
                                                cmd4.Transaction = trans;
                                                cmd4.CommandType = CommandType.StoredProcedure;
                                                cmd4.CommandTimeout = timeSQL;
                                                Dictionary<string, object> param4 = new Dictionary<string, object>();
                                                param4.Add("@intIdSesion", intIdSesion);
                                                param4.Add("@intIdMenu", intIdMenu);
                                                param4.Add("@intIdSoft", intIdSoft);
                                                param4.Add("@tt_TGPER_RESP_DET", tb4);
                                                param4.Add("@intIdUsuario", intIdUsuario);
                                                intResult = 0;
                                                param4.Add("@intResult", intResult);
                                                param4.Add("@strMsjDB", "");
                                                param4.Add("@strMsjUsuario", "");

                                                AsignarParametros(cmd4, param4);
                                                cmd4.ExecuteNonQuery();
                                                intResult = Convert.ToInt32(cmd4.Parameters["@intResult"].Value.ToString());
                                                strMsjDB = cmd4.Parameters["@strMsjDB"].Value.ToString();
                                                strMsjUsuario = cmd4.Parameters["@strMsjUsuario"].Value.ToString();

                                                if (intIdOut > 0 && intResult > 0)
                                                {
                                                    //----- TABLA 5: detalle de Coordenadas ------------------------------------------------
                                                    DataTable tb5 = SerealizeDetallePersonalCoordenadas(listaCoor, intIdOut);

                                                    SqlCommand cmd5 = new SqlCommand("TSP_TGPER_COOR_DET_IU01", cn);
                                                    cmd5.Transaction = trans;
                                                    cmd5.CommandType = CommandType.StoredProcedure;
                                                    cmd5.CommandTimeout = timeSQL;
                                                    Dictionary<string, object> param5 = new Dictionary<string, object>();
                                                    param5.Add("@intIdSesion", intIdSesion);
                                                    param5.Add("@intIdMenu", intIdMenu);
                                                    param5.Add("@intIdSoft", intIdSoft);
                                                    param5.Add("@TT_TGPER_COOR_DET", tb5);
                                                    param5.Add("@intIdUsuario", intIdUsuario);
                                                    intResult = 0;
                                                    param5.Add("@intResult", intResult);
                                                    param5.Add("@strMsjDB", "");
                                                    param5.Add("@strMsjUsuario", "");

                                                    AsignarParametros(cmd5, param5);
                                                    cmd5.ExecuteNonQuery();
                                                    intResult = Convert.ToInt32(cmd5.Parameters["@intResult"].Value.ToString());
                                                    strMsjDB = cmd5.Parameters["@strMsjDB"].Value.ToString();
                                                    strMsjUsuario = cmd5.Parameters["@strMsjUsuario"].Value.ToString();

                                                    if (intResult == 0)
                                                    {
                                                        trans.Rollback();//añadido 14.04.2021
                                                        if (intTipoOperacion == 1)
                                                        {
                                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGPER_COOR_DET_IU01";
                                                        }
                                                        else
                                                        {
                                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPER_COOR_DET_IU01";
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                                    {
                                                        trans.Rollback();//añadido 14.04.2021
                                                        if (intTipoOperacion == 1)
                                                        {
                                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGPER_RESP_DET_IU02";
                                                        }
                                                        else
                                                        {
                                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPER_RESP_DET_IU02";
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                                {
                                                    trans.Rollback();//añadido 14.04.2021
                                                    if (intTipoOperacion == 1)
                                                    {
                                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGPER_MARC_DET_IU02";
                                                    }
                                                    else
                                                    {
                                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPER_MARC_DET_IU02";
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            trans.Rollback();//añadido 14.04.2021
                                            if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                            {
                                                
                                                if (intTipoOperacion == 1)
                                                {
                                                    Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGPER_TELEF_DET_IU02";
                                                }
                                                else
                                                {
                                                    Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPER_TELEF_DET_IU02";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        trans.Rollback();//añadido 14.04.2021
                                        if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                        {
                                            
                                            if (intTipoOperacion == 1)
                                            {
                                                Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGPER_CORR_DET_IU02";
                                            }
                                            else
                                            {
                                                Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPER_CORR_DET_IU02";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    trans.Rollback();//añadido 14.04.2021
                                    if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                    {
                                        
                                        if (intTipoOperacion == 1)
                                        {
                                            Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGPER_MARCA_DNI_IU01";
                                        }
                                        else
                                        {
                                            Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPER_MARCA_DNI_IU01";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                trans.Rollback();//añadido 14.04.2021
                                if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                {
                                    
                                    if (intTipoOperacion == 1)
                                    {
                                        Msj = "No se pudo completar la inserción, debido al Resultado del SP: TSP_TGPERSONAL_IU01";
                                    }
                                    else
                                    {
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPERSONAL_IU01";
                                    }
                                }
                            }
                            Rpta_SP = intResult;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            intResult = 0;//añadido 19.08.2021
                            throw ex;
                        }

                        //Solo si todos los SP salen 1, se hace commit
                        if (Rpta_SP > 0 && strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                            if (intTipoOperacion == 1)
                            {
                                Msj = "No se pudo completar la inserción.";
                            }
                            else
                            {
                                Msj = "No se pudo completar la actualización.";
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (System.Exception ex)
            {
                if (intTipoOperacion == 1)
                {
                    strMsjDB = "No se pudo completar la inserción, debido al siguiente error: " + ex.Message;
                    Msj = "No se pudo completar la inserción, revisar los logs del Servicio.";
                }
                else
                {
                    strMsjDB = "No se pudo completar la actualización, debido al siguiente error: " + ex.Message;
                    Msj = "No se pudo completar la actualización, revisar los logs del Servicio.";
                }
                
            }
            //return Rpta_SP;//devuelve 1 = ok / 0 = error
            return intIdOut;
        }
        //5.20
        public List<TGPERMARCDET> ListarMarcadoresPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPerMarc, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGPERMARCDET> lista = new List<TGPERMARCDET>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_MARC_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdPerMarc", intIdPerMarc);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TGPERMARCDET obj = new TGPERMARCDET();

                    obj.intIdPerMarc = reader.GetInt32(0);
                    obj.intIdPersonal = reader.GetInt32(1);
                    obj.intIdSoft = reader.GetInt32(2);
                    obj.intIdMarcador = reader.GetInt32(3);
                    obj.strDesMarcador = reader.GetString(4);
                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //5.21
        public List<TGPERCORRDET> ListarCorreosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGPERCORRDET> lista = new List<TGPERCORRDET>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CORR_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TGPERCORRDET obj = new TGPERCORRDET();

                    obj.intIdPerCorr = reader.GetInt32(0);
                    obj.intIdPersonal = reader.GetInt32(1);
                    obj.strCorreo = reader.GetString(2);
                    obj.bitFlPrincipal = reader.GetBoolean(3);
                    obj.intIdUsuarReg = reader.GetInt32(4);
                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //5.22
        public List<TGPERTELEFDET> ListarTelefonosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGPERTELEFDET> lista = new List<TGPERTELEFDET>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_TELEF_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TGPERTELEFDET obj = new TGPERTELEFDET();

                    obj.intIdPerTele = reader.GetInt32(0);
                    obj.intIdPersonal = reader.GetInt32(1);
                    obj.strNumero = reader.GetString(2);
                    obj.bitFlPrincipal = reader.GetBoolean(3);
                    obj.strAnexo = reader.GetString(4);
                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //5.23
        public List<TGPERRESPDET> ListarResponsabilidadPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGPERRESPDET> lista = new List<TGPERRESPDET>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_RESP_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TGPERRESPDET obj = new TGPERRESPDET();

                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.intIdPerResp = reader.GetInt32(1);
                    obj.intIdTipoResp = reader.GetInt32(2);
                    obj.strResponsable = reader.GetString(3);
                    obj.bitVigente = reader.GetBoolean(4);
                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //5.24
        public List<TGPERCOOR> listarCoordenadas(int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGPERCOOR> lista = new List<TGPERCOOR>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TGLISTCOORD_MOVIL_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TGPERCOOR obj = new TGPERCOOR();
                    obj.intIdPersonal = reader.GetInt32(0);
                    obj.strCoord = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        obj.strDireccionCoord = reader.GetString(2);
                    }
                    obj.bitFlGeoArea = reader.GetBoolean(3);
                    obj.intIdGeoArea = reader.GetInt32(4);

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.26
        private DataTable SerealizeDetallePersonalCorreo(List<TGPERCORRDET> listaDetallesPersonalCorreo, int idPersonal)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPerCorr", typeof(int));
            table.Columns.Add("intIdPersonal", typeof(int));
            table.Columns.Add("strCorreo", typeof(string));
            table.Columns.Add("intIdDomCor", typeof(int));
            table.Columns.Add("bitFlPrincipal", typeof(bool));
            table.Columns.Add("bitTipoCorreo", typeof(bool));

            foreach (var item in listaDetallesPersonalCorreo)
            {
                DataRow rows = table.NewRow();
                rows["intIdPerCorr"] = item.intIdPerCorr;
                rows["intIdPersonal"] = idPersonal;
                rows["strCorreo"] = item.strCorreo;
                rows["intIdDomCor"] = 1;
                rows["bitFlPrincipal"] = item.bitFlPrincipal;
                rows["bitTipoCorreo"] = false;

                table.Rows.Add(rows);
            }
            return table;
        }
        //5.27
        private DataTable SerealizeDetallePersonalTelefono(List<TGPERTELEFDET> listaDetallesPersonalTelefono, int idPersonal)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPerTele", typeof(int));
            table.Columns.Add("intIdPersonal", typeof(int));
            table.Columns.Add("strNumero", typeof(string));
            table.Columns.Add("tinTipoNum", typeof(int));
            table.Columns.Add("bitFlPrincipal", typeof(bool));
            table.Columns.Add("bitTipoTelf", typeof(bool));
            table.Columns.Add("strAnexo", typeof(string));

            foreach (var item in listaDetallesPersonalTelefono)
            {
                DataRow rows = table.NewRow();
                rows["intIdPerTele"] = item.intIdPerTele;
                rows["intIdPersonal"] = idPersonal;
                rows["strNumero"] = item.strNumero;
                rows["tinTipoNum"] = 1;
                rows["bitFlPrincipal"] = item.bitFlPrincipal;
                rows["bitTipoTelf"] = false;
                rows["strAnexo"] = " ";

                table.Rows.Add(rows);
            }
            return table;
        }
        //5.28
        private DataTable SerealizeDetallePersonalMarcadores(List<TGPERMARCDET> listaDetallesPersonalMarcadores, int idPersonal, int intIdSoft)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPerMarc", typeof(int));
            table.Columns.Add("intIdPersonal", typeof(int));
            table.Columns.Add("intIdSoft", typeof(int));
            table.Columns.Add("intIdMarcador", typeof(int));
            table.Columns.Add("dttFecAsig", typeof(string));

            foreach (var item in listaDetallesPersonalMarcadores)
            {
                DataRow rows = table.NewRow();
                rows["intIdPerMarc"] = item.intIdPerMarc;
                rows["intIdPersonal"] = idPersonal;
                rows["intIdSoft"] = intIdSoft;
                rows["intIdMarcador"] = item.intIdMarcador;
                rows["dttFecAsig"] = item.dttFecAsig;

                table.Rows.Add(rows);
            }
            return table;
        }
        //5.29
        private DataTable SerealizeDetallePersonalResponsabilidad(List<TGPERRESPDET> listaDetallesPersonalResponsabilidad, int idPersonal)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPerRespDet", typeof(int));
            table.Columns.Add("intIdPersonal", typeof(int));
            table.Columns.Add("intIdPerResp", typeof(int));
            table.Columns.Add("intIdTipoResp", typeof(int));
            table.Columns.Add("bitVigente", typeof(bool));

            foreach (var item in listaDetallesPersonalResponsabilidad)
            {
                DataRow rows = table.NewRow();
                rows["intIdPerRespDet"] = item.intIdPerRespDet;
                rows["intIdPersonal"] = idPersonal;
                rows["intIdPerResp"] = item.intIdPerResp;
                rows["intIdTipoResp"] = item.intIdTipoResp;
                rows["bitVigente"] = item.bitVigente;

                table.Rows.Add(rows);
            }
            return table;
        }
        //5.30
        private DataTable SerealizeDetallePersonalCoordenadas(List<TGPERCOOR> listaCoor, int idPersonal)
        {
            DataTable table = new DataTable();

            //table.Columns.Add("intIdPerCoor", typeof(int));
            table.Columns.Add("intIdPersonal", typeof(int));
            table.Columns.Add("strCoord", typeof(string));
            table.Columns.Add("strDireccionCoord", typeof(string));
            table.Columns.Add("bitFlGeoArea", typeof(bool));
            table.Columns.Add("intIdGeoArea", typeof(int));

            foreach (var item in listaCoor)
            {
                DataRow rows = table.NewRow();
                //rows["intIdPerCoord"] = item.intIdPerCoord;
                rows["intIdPersonal"] = idPersonal;
                rows["strCoord"] = item.strCoord;
                rows["strDireccionCoord"] = item.strDireccionCoord;
                rows["bitFlGeoArea"] = item.bitFlGeoArea;
                rows["intIdGeoArea"] = item.intIdGeoArea;

                table.Rows.Add(rows);
            }

            return table;
        }

        #endregion Empleado

        #region MiFicha
        //2.1
        public List<TSPTAASISTENCIA> ObtenerAsistenciaXFecha(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSPTAASISTENCIA> lista = new List<TSPTAASISTENCIA>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TSPTAASISTENCIA obj = new TSPTAASISTENCIA();

                    obj.anio = reader.GetInt32(0);
                    obj.mes = reader.GetInt32(1);
                    obj.asistencia = reader.GetInt32(2);
                    obj.faltas = reader.GetInt32(3);

                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.18
        public int UEmpleado_T(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos, int intIdUsuario, int intIdUsuarModif, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, ref string Msj)
        {
            int intIdOut = 0;
            int Rpta_SP = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(cadCnx))
                {
                    cn.Open();
                    using (SqlTransaction trans = cn.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmd = new SqlCommand("TSP_TGPERSONAL_U001", cn);
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = timeSQL;
                            Dictionary<string, object> param = new Dictionary<string, object>();
                            param.Add("@intIdSesion", intIdSesion);
                            param.Add("@intIdMenu", intIdMenu);
                            param.Add("@intIdSoft", intIdSoft);
                            param.Add("@intIdPersonal", objDatos.intIdPersonal);
                            param.Add("@dttFecNacim", objDatos.dttFecNacim);
                            param.Add("@intIdTipoVia", (object)objDatos.intIdTipoVia ?? DBNull.Value);
                            param.Add("@strDireccion", (object)objDatos.strDireccion ?? DBNull.Value);
                            param.Add("@intIdUbigeo", (object)objDatos.intIdUbigeo ?? DBNull.Value);
                            param.Add("@intIdUsuario", intIdUsuario);
                            //Parámetros de Salida
                            param.Add("@intResult", 0);
                            param.Add("@strMsjDB", "");
                            param.Add("@strMsjUsuario", "");

                            AsignarParametros(cmd, param);
                            cmd.ExecuteNonQuery();

                            intIdOut = Convert.ToInt32(cmd.Parameters["@intIdPersonal"].Value.ToString());
                            intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                            strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                            strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

                            if (intIdOut > 0 && intResult > 0)
                            {
                                //-----TABLA 1: detalle de Correos------------------------------------------------
                                DataTable tb1 = SerealizeDetallePersonalCorreo(listaDetallesCorreos, intIdOut);

                                SqlCommand cmd1 = new SqlCommand("TSP_TGPER_CORR_DET_IU02", cn);
                                cmd1.Transaction = trans;
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = timeSQL;
                                Dictionary<string, object> param1 = new Dictionary<string, object>();
                                param1.Add("@intIdSesion", intIdSesion);
                                param1.Add("@intIdMenu", intIdMenu);
                                param1.Add("@intIdSoft", intIdSoft);
                                param1.Add("@tt_TGPER_CORR_DET", tb1);
                                param1.Add("@intIdUsuario", intIdUsuario);

                                param1.Add("@intResult", 0);
                                param1.Add("@strMsjDB", "");
                                param1.Add("@strMsjUsuario", "");

                                AsignarParametros(cmd1, param1);
                                cmd1.ExecuteNonQuery();
                                intResult = Convert.ToInt32(cmd1.Parameters["@intResult"].Value.ToString());
                                strMsjDB = cmd1.Parameters["@strMsjDB"].Value.ToString();
                                strMsjUsuario = cmd1.Parameters["@strMsjUsuario"].Value.ToString();

                                if (intIdOut > 0 && intResult > 0)
                                {
                                    //-----TABLA 2: detalle de Telefonos------------------------------------------------
                                    DataTable tb2 = SerealizeDetallePersonalTelefono(listaDetallesTelefonos, intIdOut);

                                    SqlCommand cmd2 = new SqlCommand("TSP_TGPER_TELEF_DET_IU02", cn);
                                    cmd2.Transaction = trans;
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.CommandTimeout = timeSQL;
                                    Dictionary<string, object> param2 = new Dictionary<string, object>();
                                    param2.Add("@intIdSesion", intIdSesion);
                                    param2.Add("@intIdMenu", intIdMenu);
                                    param2.Add("@intIdSoft", intIdSoft);
                                    param2.Add("@tt_TGPER_TELEF_DET", tb2);
                                    param2.Add("@intIdUsuario", intIdUsuario);

                                    param2.Add("@intResult", 0);
                                    param2.Add("@strMsjDB", "");
                                    param2.Add("@strMsjUsuario", "");

                                    AsignarParametros(cmd2, param2);
                                    cmd2.ExecuteNonQuery();
                                    intResult = Convert.ToInt32(cmd2.Parameters["@intResult"].Value.ToString());
                                    strMsjDB = cmd2.Parameters["@strMsjDB"].Value.ToString();
                                    strMsjUsuario = cmd2.Parameters["@strMsjUsuario"].Value.ToString();

                                    if (intResult == 0)
                                    {
                                        trans.Rollback();//añadido 14.04.2021
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPER_TELEF_DET_IU02";
                                    }
                                }
                                else
                                {
                                    if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                    {
                                        trans.Rollback();//añadido 14.04.2021
                                        Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPER_MARCA_DNI_IU01";
                                    }
                                }
                            }
                            else
                            {
                                if (!strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                                {
                                    trans.Rollback();//añadido 14.04.2021
                                    Msj = "No se pudo completar la actualización, debido al Resultado del SP: TSP_TGPERSONAL_IU01";
                                }
                            }
                            Rpta_SP = intResult;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }

                        //Solo si todos los SP salen 1, se hace commit
                        if (Rpta_SP > 0 && strMsjDB.Equals("") && strMsjUsuario.Equals(""))
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                            Msj = "No se pudo completar la actualización.";
                        }
                    }
                    cn.Close();
                }
            }
            catch (System.Exception ex)
            {
                strMsjDB = "No se pudo completar la actualización, debido al siguiente error: " + ex.Message;
                Msj = "No se pudo completar la actualización, revisar los logs del Servicio.";
                //Log.AlmacenarLogMensaje(": " + strMsjDB);
         
            }
            return Rpta_SP;//devuelve 1 = ok / 0 = error
        }

        #endregion

        #region MarcaEmpleadoDni
        //5.25
        public List<MarcaDni> ObtenerEmpleadoConMarcaDNI(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<MarcaDni> listDetDni = new List<MarcaDni>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_MARCA_DNI_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdPersonal", intIdPersonal);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        MarcaDni obj = new MarcaDni();

                        obj.bitHabilitarMarcaDNI = reader.GetBoolean(0);
                        obj.dttFechaInicioVegencia = reader.GetString(1);
                        obj.dttFechaFinVegencia = reader.GetString(2);
                        obj.bitHabilitarSupervisorCom = reader.GetBoolean(3);

                        listDetDni.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetDni;
        }
        #endregion

        #region Empleado Masivo
        //3.33
        public List<EmpleadoMasivo> ListGrupoLiquidacion(Session_Movi session, EmpleadoMasivo lista, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EmpleadoMasivo> listobj = new List<EmpleadoMasivo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_MASIVO_EMPLEADO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("COD_EMP", lista.COD_EMP);
                param.Add("COD_EMP_RUC", lista.COD_EMP_RUC);
                param.Add("COD_EMP_DSC", lista.COD_EMP_DSC);
                param.Add("COD_LOC", lista.COD_LOC);
                param.Add("COD_LOC_DSC", lista.COD_LOC_DSC);
                param.Add("COD_GER", lista.COD_GER);
                param.Add("COD_GER_DSC", lista.COD_GER_DSC);
                param.Add("COD_ARE", lista.COD_ARE);
                param.Add("COD_ARE_DSC", lista.COD_ARE_DSC);
                param.Add("COD_PL", lista.COD_PL);
                param.Add("COD_PL_DSC", lista.COD_PL_DSC);
                param.Add("COD_CG", lista.COD_CG);
                param.Add("COD_CG_DSC", lista.COD_CG_DSC);
                param.Add("COD_CT", lista.COD_CT);
                param.Add("COD_CT_DSC", lista.COD_CT_DSC);
                param.Add("COD_GR", lista.COD_GR);
                param.Add("COD_GR_DSC", lista.COD_GR_DSC);
                param.Add("COD_TP", lista.COD_TP);
                param.Add("COD_TP_DSC", lista.COD_TP_DSC);
                param.Add("COD_CC", lista.COD_CC);
                param.Add("COD_CC_DSC", lista.COD_CC_DSC);
                param.Add("COD_FIS", lista.COD_FIS);
                param.Add("COD_RES", lista.COD_RES);
                param.Add("COD_EXT", lista.COD_EXT);
                param.Add("COD_TD", lista.COD_TD);
                param.Add("NUMDOC", lista.NUMDOC);
                param.Add("APEPAT", lista.APEPAT);
                param.Add("APEMAT", lista.APEMAT);
                param.Add("NOMBRES", lista.NOMBRES);
                param.Add("FECNAC", lista.FECNAC);
                param.Add("GENERO", lista.GENERO);
                param.Add("FOTOCHECK", lista.FOTOCHECK);
                param.Add("FECADM", lista.FECADM);
                param.Add("ESTADO", lista.ESTADO);
                param.Add("COD_REG", lista.COD_REG);
                param.Add("COD_HOR", lista.COD_HOR);
                param.Add("COD_RES_IM", lista.COD_RES_IM);
                param.Add("COD_RES_CT", lista.COD_RES_CT);
                param.Add("CORREOP", lista.CORREOP);
                param.Add("CUENTA_US", lista.CUENTA_US);
                param.Add("CUENTA_PF", lista.CUENTA_PF);
                param.Add("COD_VIA", lista.COD_VIA);
                param.Add("DIRECCION", lista.DIRECCION);
                param.Add("COD_UBI", lista.COD_UBI);
                param.Add("CODPENSIONISTA", lista.CODPENSIONISTA);
                param.Add("CODSALUD", lista.CODSALUD);
                param.Add("TELEFONOP", lista.TELEFONOP);
                param.Add("CONTRATOI", lista.CONTRATOI);
                param.Add("FECCESE", lista.FECCESE);
                param.Add("COD_CESE", lista.COD_CESE);
                param.Add("COD_GLIQ", lista.COD_GLIQ);
                param.Add("COORDENADA", lista.COORDENADA);
                param.Add("DIRCOORDENADA", lista.DIRCOORDENADA);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmpleadoMasivo obj = new EmpleadoMasivo();



                        listobj.Add(obj);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        //3.34
        public List<EmpleadoMasivo> ImportMasivoEmpleado(Session_Movi session, DataTable tb, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EmpleadoMasivo> listobj = new List<EmpleadoMasivo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_MASIVO_EMPLEADO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@TT_MASIVO_EMPLEADO", tb);
                param.Add("@idProceso", idProceso);
                param.Add("@cboPlantilla", cboPlantilla);
                param.Add("@cboFormato", cboFormato);
                param.Add("@checkActualizar", checkActualizar);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmpleadoMasivo obj = new EmpleadoMasivo();

                        if (!reader.IsDBNull(0))
                        {
                            obj.COD_EMP = reader.GetString(0);
                        }
                        if (!reader.IsDBNull(1))
                        {
                            obj.COD_EMP_RUC = reader.GetString(1);
                        }
                        if (!reader.IsDBNull(2))
                        {
                            obj.COD_EMP_DSC = reader.GetString(2);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            obj.COD_LOC = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            obj.COD_LOC_DSC = reader.GetString(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            obj.COD_GER = reader.GetString(5);
                        }
                        if (!reader.IsDBNull(6))
                        {
                            obj.COD_GER_DSC = reader.GetString(6);
                        }
                        if (!reader.IsDBNull(7))
                        {
                            obj.COD_ARE = reader.GetString(7);
                        }
                        if (!reader.IsDBNull(8))
                        {
                            obj.COD_ARE_DSC = reader.GetString(8);
                        }
                        if (!reader.IsDBNull(9))
                        {
                            obj.COD_PL = reader.GetString(9);
                        }
                        if (!reader.IsDBNull(10))
                        {
                            obj.COD_PL_DSC = reader.GetString(10);
                        }
                        if (!reader.IsDBNull(11))
                        {
                            obj.COD_CG = reader.GetString(11);
                        }
                        if (!reader.IsDBNull(12))
                        {
                            obj.COD_CG_DSC = reader.GetString(12);
                        }
                        if (!reader.IsDBNull(13))
                        {
                            obj.COD_CT = reader.GetString(13);
                        }
                        if (!reader.IsDBNull(14))
                        {
                            obj.COD_CT_DSC = reader.GetString(14);
                        }
                        if (!reader.IsDBNull(15))
                        {
                            obj.COD_GR = reader.GetString(15);
                        }
                        if (!reader.IsDBNull(16))
                        {
                            obj.COD_GR_DSC = reader.GetString(16);
                        }
                        if (!reader.IsDBNull(17))
                        {
                            obj.COD_TP = reader.GetString(17);
                        }
                        if (!reader.IsDBNull(18))
                        {
                            obj.COD_TP_DSC = reader.GetString(18);
                        }
                        if (!reader.IsDBNull(19))
                        {
                            obj.COD_CC = reader.GetString(19);
                        }
                        if (!reader.IsDBNull(20))
                        {
                            obj.COD_CC_DSC = reader.GetString(20);
                        }
                        if (!reader.IsDBNull(21))
                        {
                            obj.COD_FIS = reader.GetString(21);
                        }
                        if (!reader.IsDBNull(22))
                        {
                            obj.COD_RES = reader.GetString(22);
                        }
                        if (!reader.IsDBNull(23))
                        {
                            obj.COD_EXT = reader.GetString(23);
                        }
                        if (!reader.IsDBNull(24))
                        {
                            obj.COD_TD = reader.GetString(24);
                        }
                        if (!reader.IsDBNull(25))
                        {
                            obj.NUMDOC = reader.GetString(25);
                        }
                        if (!reader.IsDBNull(26))
                        {
                            obj.APEPAT = reader.GetString(26);
                        }
                        if (!reader.IsDBNull(27))
                        {
                            obj.APEMAT = reader.GetString(27);
                        }
                        if (!reader.IsDBNull(28))
                        {
                            obj.NOMBRES = reader.GetString(28);
                        }
                        if (!reader.IsDBNull(29))
                        {
                            obj.FECNAC = reader.GetString(29);
                        }
                        if (!reader.IsDBNull(30))
                        {
                            obj.GENERO = reader.GetString(30);
                        }
                        if (!reader.IsDBNull(31))
                        {
                            obj.FOTOCHECK = reader.GetString(31);
                        }
                        if (!reader.IsDBNull(32))
                        {
                            obj.FECADM = reader.GetString(32);
                        }
                        if (!reader.IsDBNull(33))
                        {
                            obj.ESTADO = reader.GetString(33);
                        }
                        if (!reader.IsDBNull(34))
                        {
                            obj.COD_REG = reader.GetString(34);
                        }
                        if (!reader.IsDBNull(35))
                        {
                            obj.COD_HOR = reader.GetString(35);
                        }
                        if (!reader.IsDBNull(36))
                        {
                            obj.COD_RES_IM = reader.GetString(36);
                        }
                        if (!reader.IsDBNull(37))
                        {
                            obj.COD_RES_CT = reader.GetString(37);
                        }
                        if (!reader.IsDBNull(38))
                        {
                            obj.CORREOP = reader.GetString(38);
                        }
                        if (!reader.IsDBNull(39))
                        {
                            obj.CUENTA_US = reader.GetString(39);
                        }
                        if (!reader.IsDBNull(40))
                        {
                            obj.CUENTA_PF = reader.GetString(40);
                        }
                        if (!reader.IsDBNull(41))
                        {
                            obj.COD_VIA = reader.GetString(41);
                        }
                        if (!reader.IsDBNull(42))
                        {
                            obj.DIRECCION = reader.GetString(42);
                        }
                        if (!reader.IsDBNull(43))
                        {
                            obj.COD_UBI = reader.GetString(43);
                        }
                        if (!reader.IsDBNull(44))
                        {
                            obj.CODPENSIONISTA = reader.GetString(44);
                        }
                        if (!reader.IsDBNull(45))
                        {
                            obj.CODSALUD = reader.GetString(45);
                        }
                        if (!reader.IsDBNull(46))
                        {
                            obj.TELEFONOP = reader.GetString(46);
                        }
                        if (!reader.IsDBNull(47))
                        {
                            obj.CONTRATOI = reader.GetString(47);
                        }
                        if (!reader.IsDBNull(48))
                        {
                            obj.FECCESE = reader.GetString(48);
                        }
                        if (!reader.IsDBNull(49))
                        {
                            obj.COD_CESE = reader.GetString(49);
                        }
                        if (!reader.IsDBNull(50))
                        {
                            obj.COD_GLIQ = reader.GetString(50);
                        }
                        if (!reader.IsDBNull(51))
                        {
                            obj.COORDENADA = reader.GetString(51);
                        }
                        if (!reader.IsDBNull(52))
                        {
                            obj.DIRCOORDENADA = reader.GetString(52);
                        }
                        if (!reader.IsDBNull(53))
                        {
                            obj.INTIDPROCESO = reader.GetInt32(53);
                        }
                        if (!reader.IsDBNull(54))
                        {
                            obj.OBSERVACION = reader.GetString(54);
                        }
                        if (!reader.IsDBNull(55))
                        {
                            obj.FLAGOBSERVADO = reader.GetBoolean(55);
                        }

                        listobj.Add(obj);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        //3.35
        public List<EmpleadoMasivo> GuardarMasivoEmpleado(Session_Movi session, int idProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EmpleadoMasivo> listobj = new List<EmpleadoMasivo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_MASIVO_EMPLEADO_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);
                param.Add("@intIdUsuario", session.intIdUsuario);

                param.Add("@idProceso", idProceso);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmpleadoMasivo obj = new EmpleadoMasivo();

                        //if (!reader.IsDBNull(0))
                        //{
                        obj.COD_EMP = reader.GetString(0);
                        //}
                        //if (!reader.IsDBNull(1))
                        //{
                        obj.COD_EMP_RUC = reader.GetString(1);
                        //}
                        //if (!reader.IsDBNull(2))
                        //{
                        obj.COD_EMP_DSC = reader.GetString(2);
                        //}
                        //if (!reader.IsDBNull(3))
                        //{
                        obj.COD_LOC = reader.GetString(3);
                        //}
                        //if (!reader.IsDBNull(4))
                        //{
                        obj.COD_LOC_DSC = reader.GetString(4);
                        //}
                        //if (!reader.IsDBNull(5))
                        //{
                        obj.COD_GER = reader.GetString(5);
                        //}
                        //if (!reader.IsDBNull(6))
                        //{
                        obj.COD_GER_DSC = reader.GetString(6);
                        //}
                        //if (!reader.IsDBNull(7))
                        //{
                        obj.COD_ARE = reader.GetString(7);
                        //}
                        //if (!reader.IsDBNull(8))
                        //{
                        obj.COD_ARE_DSC = reader.GetString(8);
                        //}
                        //if (!reader.IsDBNull(9))
                        //{
                        obj.COD_PL = reader.GetString(9);
                        //}
                        //if (!reader.IsDBNull(10))
                        //{
                        obj.COD_PL_DSC = reader.GetString(10);
                        //}
                        //if (!reader.IsDBNull(11))
                        //{
                        obj.COD_CG = reader.GetString(11);
                        //}
                        //if (!reader.IsDBNull(12))
                        //{
                        obj.COD_CG_DSC = reader.GetString(12);
                        //}
                        //if (!reader.IsDBNull(13))
                        //{
                        obj.COD_CT = reader.GetString(13);
                        //}
                        //if (!reader.IsDBNull(14))
                        //{
                        obj.COD_CT_DSC = reader.GetString(14);
                        //}
                        //if (!reader.IsDBNull(15))
                        //{
                        obj.COD_GR = reader.GetString(15);
                        //}
                        //if (!reader.IsDBNull(16))
                        //{
                        obj.COD_GR_DSC = reader.GetString(16);
                        //}
                        //if (!reader.IsDBNull(17))
                        //{
                        obj.COD_TP = reader.GetString(17);
                        //}
                        //if (!reader.IsDBNull(18))
                        //{
                        obj.COD_TP_DSC = reader.GetString(18);
                        //}
                        //if (!reader.IsDBNull(19))
                        //{
                        obj.COD_CC = reader.GetString(19);
                        //}
                        //if (!reader.IsDBNull(20))
                        //{
                        obj.COD_CC_DSC = reader.GetString(20);
                        //}
                        //if (!reader.IsDBNull(21))
                        //{
                        obj.COD_FIS = reader.GetString(21);
                        //}
                        //if (!reader.IsDBNull(22))
                        //{
                        obj.COD_RES = reader.GetString(22);
                        //}
                        //if (!reader.IsDBNull(23))
                        //{
                        obj.COD_EXT = reader.GetString(23);
                        //}
                        //if (!reader.IsDBNull(24))
                        //{
                        obj.COD_TD = reader.GetString(24);
                        //}
                        //if (!reader.IsDBNull(25))
                        //{
                        obj.NUMDOC = reader.GetString(25);
                        //}
                        //if (!reader.IsDBNull(26))
                        //{
                        obj.APEPAT = reader.GetString(26);
                        //}
                        //if (!reader.IsDBNull(27))
                        //{
                        obj.APEMAT = reader.GetString(27);
                        //}
                        //if (!reader.IsDBNull(28))
                        //{
                        obj.NOMBRES = reader.GetString(28);
                        //}
                        //if (!reader.IsDBNull(29))
                        //{
                        obj.FECNAC = reader.GetString(29);
                        //}
                        //if (!reader.IsDBNull(30))
                        //{
                        obj.GENERO = reader.GetString(30);
                        //}
                        //if (!reader.IsDBNull(31))
                        //{
                        obj.FOTOCHECK = reader.GetString(31);
                        //}
                        //if (!reader.IsDBNull(32))
                        //{
                        obj.FECADM = reader.GetString(32);
                        //}
                        //if (!reader.IsDBNull(33))
                        //{
                        obj.ESTADO = reader.GetString(33);
                        //}
                        //if (!reader.IsDBNull(34))
                        //{
                        obj.COD_REG = reader.GetString(34);
                        //}
                        //if (!reader.IsDBNull(35))
                        //{
                        obj.COD_HOR = reader.GetString(35);
                        //}
                        //if (!reader.IsDBNull(36))
                        //{
                        obj.COD_RES_IM = reader.GetString(36);
                        //}
                        //if (!reader.IsDBNull(37))
                        //{
                        obj.COD_RES_CT = reader.GetString(37);
                        //}
                        //if (!reader.IsDBNull(38))
                        //{
                        obj.CORREOP = reader.GetString(38);
                        //}
                        //if (!reader.IsDBNull(39))
                        //{
                        obj.CUENTA_US = reader.GetString(39);
                        //}
                        //if (!reader.IsDBNull(40))
                        //{
                        obj.CUENTA_PF = reader.GetString(40);
                        //}
                        //if (!reader.IsDBNull(41))
                        //{
                        obj.COD_VIA = reader.GetString(41);
                        //}
                        //if (!reader.IsDBNull(42))
                        //{
                        obj.DIRECCION = reader.GetString(42);
                        //}
                        //if (!reader.IsDBNull(43))
                        //{
                        obj.COD_UBI = reader.GetString(43);
                        //}
                        //if (!reader.IsDBNull(44))
                        //{
                        obj.CODPENSIONISTA = reader.GetString(44);
                        //}
                        //if (!reader.IsDBNull(45))
                        //{
                        obj.CODSALUD = reader.GetString(45);
                        //}
                        //if (!reader.IsDBNull(46))
                        //{
                        obj.TELEFONOP = reader.GetString(46);
                        //}
                        //if (!reader.IsDBNull(47))
                        //{
                        obj.CONTRATOI = reader.GetString(47);
                        //}
                        //if (!reader.IsDBNull(48))
                        //{
                        obj.FECCESE = reader.GetString(48);
                        //}
                        //if (!reader.IsDBNull(49))
                        //{
                        obj.COD_CESE = reader.GetString(49);
                        //}
                        //if (!reader.IsDBNull(50))
                        //{
                        obj.COD_GLIQ = reader.GetString(50);
                        //}
                        //if (!reader.IsDBNull(51))
                        //{
                        obj.COORDENADA = reader.GetString(51);
                        //}
                        //if (!reader.IsDBNull(52))
                        //{
                        obj.DIRCOORDENADA = reader.GetString(52);
                        //}
                        //if (!reader.IsDBNull(53))
                        //{
                        obj.INTIDPROCESO = reader.GetInt32(53);
                        //}
                        //if (!reader.IsDBNull(54))
                        //{
                        obj.OBSERVACION = reader.GetString(54);
                        //}
                        //if (!reader.IsDBNull(55))
                        //{
                        obj.FLAGOBSERVADO = reader.GetBoolean(55);
                        //}
                        //if (!reader.IsDBNull(56))
                        //{
                        obj.ESTADO_FINAL = reader.GetInt32(56);
                        //}

                        listobj.Add(obj);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }

        #endregion

        #region CambioDI
        //5.38
        public ValidarIdentidad_DI ValidarDocCambioIdentidad(Session_Movi objSession, int intIdTipDoc, string strNumDoc, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            ValidarIdentidad_DI obj = new ValidarIdentidad_DI();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_TGCAMBIODOC_Q02", cn); //TSP_TMPERSONAL_Q12
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                //Parámetros de Salida
                param.Add("@intIdTipDoc", intIdTipDoc);
                param.Add("@strNumDoc", strNumDoc);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.intIdPersonal = reader.GetInt32(0);
                        obj.strApellidos = reader.GetString(1);
                        obj.strNombres = reader.GetString(2);
                        obj.strCoPersonal = reader.GetString(3);
                        obj.strNumRegis = reader.GetString(4);
                        obj.strFotocheck = reader.GetString(5);
                        obj.strUniOrg = reader.GetString(6);
                        if (reader.IsDBNull(7))
                        {
                            obj.dttFecNacim = null;
                        }
                        else
                        {
                            obj.dttFecNacim = reader.GetString(7);
                        }
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return obj;
        }
        //5.39
        public List<CambioDI> ListarCambioDI(Session_Movi objSession, string buscarId, int empresaId, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CambioDI> listobj = new List<CambioDI>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_TGCAMBIODOC_Q01", cn);//TSP_TMCAMBIO_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@buscarId", buscarId);
                param.Add("@empresaId", empresaId);
                param.Add("@filtrojer_ini", Convert.ToString(filtrojer_ini));
                param.Add("@filtrojer_fin", Convert.ToString(filtrojer_fin));

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CambioDI obj = new CambioDI();

                        obj.strNumDocAnt = reader.GetString(0);
                        obj.strNumDocNew = reader.GetString(1);
                        obj.strNomCompleto = reader.GetString(2);
                        obj.strNomUsuarReg = reader.GetString(3);
                        obj.dttFeRegistro = reader.GetString(4);
                        obj.strUniOrg = reader.GetString(5);

                        listobj.Add(obj);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        //5.40
        public CorreoEmp ActualizarCambioDI(Session_Movi objSession, PersonalCDI personalCDI, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            CorreoEmp obj = new CorreoEmp();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_TGCAMBIODOC_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);

                //-------------------------
                param.Add("@intIdPerso", personalCDI.intIdPerso);
                param.Add("@intIdTipDocAnt", personalCDI.intIdTipDocAnt);
                param.Add("@strNumDocAnt", personalCDI.strNumDocAnt);
                param.Add("@intIdTipDocNue", personalCDI.intIdTipDocNue);
                param.Add("@strNumDocNue", personalCDI.strNumDocNue);
                param.Add("@strFechaNac", personalCDI.strFechaNac);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.strNomCompleto = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                        {
                            obj.strCorreo = reader.GetString(1);
                        }
                        obj.strNumDocNue = reader.GetString(2);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return obj;
        }
        //5.48
        public List<EnCorreo> obtenerDatosCorreo(Session_Movi objSession, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> listobj = new List<EnCorreo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_TSCONFIGCORREOS_Q01", cn);//TS_TSCONFIGCORREOS_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EnCorreo obj = new EnCorreo();

                        obj.strhost = reader.GetString(0);
                        obj.strpuerto = reader.GetString(1);
                        obj.bitAutentificacion = reader.GetBoolean(2);
                        obj.strccorreo = reader.GetString(3);
                        obj.strcpass = reader.GetString(4);
                        obj.strremitente = reader.GetString(6);

                        listobj.Add(obj);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        //5.49
        public CorreoEmp GetCorreo(int intIdPersonal, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            CorreoEmp obj = new CorreoEmp();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_GETCORREO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdPersonal", intIdPersonal);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obj.strNomCompleto = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                    {
                        obj.strCorreo = reader.GetString(1);
                    }
                    obj.strNumDocNue = reader.GetString(2);
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return obj;
        }

        #endregion

        #region Papeleta - Permisos - Ausentismos
        //5.50
        public List<Ausentismos> ListarAusentismoDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Ausentismos> lista = new List<Ausentismos>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intIdPerCon", intIdPerHor);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ausentismos obj = new Ausentismos();

                    obj.intIdPerConcepto = reader.GetInt32(0);
                    obj.strCoConcepto = reader.GetString(1);
                    obj.strDesConcepto = reader.GetString(2);
                    obj.dttFecha = reader.GetString(3);
                    obj.strDeTipo = reader.GetString(4);
                    obj.intIdConcepto = reader.GetInt32(5);


                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.51
        public List<string> EliminarAusentismo(Session_Movi objSession, int intIdPerCon, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<string> listRutaDoc = new List<string>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_D04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@intIdPerCon", intIdPerCon);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listRutaDoc.Add(reader.GetString(0));
                    }

                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listRutaDoc;
        }
        //5.52
        public Ausentismo ObtenerAusentismoPorPK(Session_Movi objSession, int intId, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Ausentismo> lista = new List<Ausentismo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intId", intId);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ausentismo obj = new Ausentismo();
                        obj.intIdPerConcepto = reader.GetInt32(0);
                        obj.intIdPersonal = reader.GetInt32(1);
                        obj.intIdConcepto = reader.GetInt32(2);
                        obj.dttFecha = reader.GetString(3);
                        obj.timeHoraIni = reader.GetString(4);
                        obj.timeHoraFin = reader.GetString(5);
                        obj.tinDiaPertenen = reader.GetInt32(6);
                        obj.strObservacion = reader.GetString(7);
                        obj.bitEspeciValor = reader.GetBoolean(8);
                        obj.strCITT = reader.GetString(9);
                        obj.strNoInstitucion = reader.GetString(10);
                        obj.strNoDoctor = reader.GetString(11);
                        obj.IntIdTipoDoc = reader.GetInt32(12);
                        obj.bitFlCompensable = reader.GetBoolean(13);
                        obj.bitSustentado = reader.GetBoolean(14);
                        obj.strintTipoUM = reader.GetString(15);
                        if (!reader.IsDBNull(16))
                        {
                            obj.IntIdCCosto = reader.GetInt32(16);
                        }
                        obj.bitDiaSgtIni = reader.GetBoolean(17);
                        obj.bitDiaSgtFin = reader.GetBoolean(18);
                        lista.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return lista.First();
        }
        //5.52-B
        public List<Documento> ObtenerDocumentosAusentismo(Session_Movi objSession, int intId, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Documento> listDocs = new List<Documento>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_Q05", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intId", intId);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Documento obj = new Documento();

                        obj.intIdPerConcepto = reader.GetInt32(0);
                        obj.strRutaDocumento = reader.GetString(1);
                        obj.strNomDocumento = reader.GetString(2);

                        listDocs.Add(obj);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDocs;
        }
        //5.53
        public int UAusentismos(Session_Movi objSession, Ausentismo objDatos, bool flgDESM, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int result = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_U01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                //parametros de entrada
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);

                param.Add("@intId", objDatos.intIdPerConcepto);
                param.Add("@intIdPersonal", objDatos.intIdPersonal);
                param.Add("@intIdConcepto", objDatos.intIdConcepto);
                param.Add("@intIdCCosto", objDatos.IntIdCCosto);
                param.Add("@dfechaAsigEdit", objDatos.dttFecha);
                param.Add("@horainicio", objDatos.timeHoraIni);
                param.Add("@horaFin", objDatos.timeHoraFin);
                param.Add("@observaciones", objDatos.strObservacion);
                param.Add("@tinDiaPertenen", objDatos.tinDiaPertenen);
                param.Add("@bitFlCompensable", objDatos.bitFlCompensable);
                param.Add("@bitEspeciValor", objDatos.bitEspeciValor);
                param.Add("@IntIdTipoDoc", objDatos.IntIdTipoDoc);
                param.Add("@strCITT", objDatos.strCITT);
                param.Add("@strNoInstitucion", objDatos.strNoInstitucion);
                param.Add("@strNoDoctor", objDatos.strNoDoctor);
                param.Add("@bitSustentado", objDatos.bitSustentado);
                param.Add("@flgDESM", flgDESM);
                param.Add("@bitDiaSgtIni", objDatos.bitDiaSgtIni);
                param.Add("@bitDiaSgtFin", objDatos.bitDiaSgtFin);


                //Parámetros de Salida

                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                result = cmd.ExecuteNonQuery();
                // intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@intIdPerHor"].Value.ToString());
                //outputs
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return result;

        }
        //5.54
        public List<int> IAusentismos(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<int> listPapeletas = new List<int>();//cambiar lista
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                //parametros de entrada
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);

                param.Add("@intIdProceso", intIdProceso);

                //Parámetros de Salida

                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listPapeletas.Add(reader.GetInt32(0));
                    }

                }


                // intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@intIdPerHor"].Value.ToString());
                //outputs
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listPapeletas;

        }
        //5.55
        public int EAusentismos(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int id = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_E01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                //parametros de entrada
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);

                param.Add("@intIdProceso", intIdProceso);

                //Parámetros de Salida

                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                id = (int)cmd.ExecuteNonQuery();

                // intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@intIdPerHor"].Value.ToString());
                //outputs
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return id;

        }
        //5.56
        public List<EmpleadoObs> PreIAusentismos(Session_Movi objSession, Ausentismo objDatos, bool flgDESM, string dttFechaIni, string dttFechaFin, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EmpleadoObs> listDeObs = new List<EmpleadoObs>();//cambiar lista
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_V02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                //parametros de entrada
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);

                param.Add("@intId", objDatos.intIdPerConcepto);
                param.Add("@intIdConcepto", objDatos.intIdConcepto);
                param.Add("@intIdCCosto", objDatos.IntIdCCosto);
                param.Add("@dttFechaIni", dttFechaIni);
                param.Add("@dttFechaFin", dttFechaFin);
                param.Add("@flgDESM", flgDESM);
                param.Add("@horainicio", objDatos.timeHoraIni);
                param.Add("@horaFin", objDatos.timeHoraFin);
                param.Add("@observaciones", objDatos.strObservacion);
                param.Add("@tinDiaPertenen", objDatos.tinDiaPertenen);
                param.Add("@bitFlCompensable", objDatos.bitFlCompensable);
                param.Add("@bitEspeciValor", objDatos.bitEspeciValor);
                param.Add("@IntIdTipoDoc", objDatos.IntIdTipoDoc);
                param.Add("@strCITT", objDatos.strCITT);
                param.Add("@strNoInstitucion", objDatos.strNoInstitucion);
                param.Add("@strNoDoctor", objDatos.strNoDoctor);
                param.Add("@bitSustentado", objDatos.bitSustentado);
                param.Add("@bitDiaSgtIni", objDatos.bitDiaSgtIni);
                param.Add("@bitDiaSgtFin", objDatos.bitDiaSgtFin);
                param.Add("@TT_Empleados", tb);

                //Parámetros de Salida

                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                //nomCompleto = (string)cmd.ExecuteScalar();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmpleadoObs obj = new EmpleadoObs(); //cambiar el obj.

                        obj.intCodigo = reader.GetInt32(0);

                        if (reader.FieldCount == 4)
                        {
                            obj.strCodEmpleado = reader.GetString(1);
                            obj.strNomCompleto = reader.GetString(2);
                            obj.strObservacion = reader.GetString(3);
                        }

                        listDeObs.Add(obj);
                    }

                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listDeObs;

        }
        //5.57
        public int RegistrarDocumentos(string Archivo, string ruta, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int id = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_I02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@pathTotal", Archivo);
                param.Add("@Directorio", ruta); //añadido 13.09.2021
                param.Add("@TT_PAPELETAS", tb);
                //Parámetros de Salida

                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                id = (int)cmd.ExecuteNonQuery();

                // intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@intIdPerHor"].Value.ToString());
                //outputs
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return id;

        }
        //5.58
        public int RegistrarDocumentosEdit(string Archivo, string ruta, int intIdPapeleta, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int id = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_I03", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdPapeleta", intIdPapeleta);
                param.Add("@pathTotal", Archivo);
                param.Add("@Directorio", ruta); //añadido 13.09.2021

                //Parámetros de Salida

                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                id = (int)cmd.ExecuteNonQuery();

                // intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@intIdPerHor"].Value.ToString());
                //outputs
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return id;

        }
        //5.59
        public List<string> ComprobarDocumentos(Session_Movi objSession, int intIdPapeleta, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            List<string> listEliminados = new List<string>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_I04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdPapeleta", intIdPapeleta);
                param.Add("@TT_DOCUMENTOS", tb);

                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listEliminados.Add(reader.GetString(0));
                }

                // intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@intIdPerHor"].Value.ToString());
                //outputs
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listEliminados;

        }
        //5.60
        public bool GetHabGeo(ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool estado = false;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCONFIG_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                estado = cmd.ExecuteScalar().ToString().Equals("1") ? true : false;

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }

            return estado;
        }
        //5.66
        public TEXTOCORREO GetTextoCorreo(string strFiltro, int intIdPersonal, int intFiltro, bool boolFiltro, string adicional, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            TEXTOCORREO obj = new TEXTOCORREO();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCORREOMENSAJE_Q01", cn);//TS_TSCORREOMENSAJE_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@strFiltro", strFiltro);
                param.Add("@intIdPersonal", intIdPersonal);
                param.Add("@intFiltro", intFiltro);
                param.Add("@boolFiltro", boolFiltro);
                param.Add("@adicional", adicional);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obj.saludo = reader.GetString(0);
                    obj.despedida = reader.GetString(1);
                    obj.texto1 = reader.GetString(2);
                    obj.texto2 = reader.GetString(3);
                    obj.texto3 = reader.GetString(4);
                    obj.texto4 = reader.GetString(5);
                    obj.texto5 = reader.GetString(6);
                    obj.pie1 = reader.GetString(7);
                    obj.pie2 = reader.GetString(8);
                    obj.pie3 = reader.GetString(9);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }

            return obj;
        }
        //añadido 01.07.2021
        public TEXTOCORREO GetTextoCorreoObj(string strFiltro, CorreoEmp obj_, int intFiltro, bool boolFiltro, string adicional, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            TEXTOCORREO obj = new TEXTOCORREO();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TSCORREOMENSAJE_Q01", cn);//TS_TSCORREOMENSAJE_Q01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                param.Add("@strFiltro", strFiltro);
                param.Add("@intIdPersonal", obj_.intIdPersonal);
                //añadidos 01.07.2021
                param.Add("@strCampo1", obj_.strOC);
                param.Add("@strCampo2", obj_.strRUC);
                param.Add("@strCampo3", obj_.strCadena);
                param.Add("@strCampo4", obj_.strCadena2);//añadido 06.07.2021
                //--------------------
                param.Add("@intFiltro", intFiltro);
                param.Add("@boolFiltro", boolFiltro);
                param.Add("@adicional", adicional);

                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obj.saludo = reader.GetString(0);
                    obj.despedida = reader.GetString(1);
                    obj.texto1 = reader.GetString(2);
                    obj.texto2 = reader.GetString(3);
                    obj.texto3 = reader.GetString(4);
                    obj.texto4 = reader.GetString(5);
                    obj.texto5 = reader.GetString(6);
                    obj.pie1 = reader.GetString(7);
                    obj.pie2 = reader.GetString(8);
                    obj.pie3 = reader.GetString(9);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }

            return obj;
        }

        #endregion

        #region Asig. Horario
        //5.67
        public List<AsigHorarioData> ListarAsigHor(Session_Movi objSession, int intActivoFilter, string strfilter, int IntIdEmp, string dttfiltrofch1, string dttfiltrofch2, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<AsigHorarioData> lista = new List<AsigHorarioData>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERS_HORARIO_DET_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intActivo", intActivoFilter);
                param.Add("@strfilter", strfilter);
                param.Add("@intIdEmp", IntIdEmp);
                param.Add("@dttfiltrofch1", Convert.ToString(dttfiltrofch1));
                param.Add("@dttfiltrofch2", Convert.ToString(dttfiltrofch2));
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AsigHorarioData obj = new AsigHorarioData();

                    obj.intIdPerHorario = reader.GetInt32(0);
                    obj.strCoPersonal = reader.GetString(1);
                    obj.strNombres = reader.GetString(2);
                    obj.strNumDoc = reader.GetString(3);
                    obj.dttFechAsig = reader.GetString(4);
                    obj.strDesEmp = reader.GetString(5);
                    obj.strEstado = reader.GetString(6);
                    if (!reader.IsDBNull(8))
                    {
                        obj.intUniOrg = reader.GetInt32(8);
                    }
                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return lista;
        }
        //5.68
        public List<AsigHorario> ListarAsigHorDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<AsigHorario> lista = new List<AsigHorario>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERS_HORARIO_DET_Q03", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);

                param.Add("@intIdPerHor", intIdPerHor);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AsigHorario obj = new AsigHorario();

                    obj.intIdPerHorario = reader.GetInt32(0);
                    obj.strCoHorario = reader.GetString(1);
                    obj.strDescHorario = reader.GetString(2);
                    obj.dttFechAsig = reader.GetString(3);
                    obj.intIdHorario = reader.GetInt32(4);
                    obj.bitPrincipal = reader.GetBoolean(5); //añadido 26.08.2021

                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }
        //5.69
        public bool EliminarAsigHor(Session_Movi objSession, int intIdPerHor, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERS_HORARIO_DET_D04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@intIdPerHor", intIdPerHor);
                //Parámetros de Salida                              
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                exito = Transaction(cn, cmd);

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return exito;
        }
        //5.70
        public int IUAsigHor(Session_Movi objSession, int intIdPerHor, int intIdHorario, DateTime dttFecAsig, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdEmpresaOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERS_HORARIO_DET_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);//parametros de entrada
                param.Add("@intIdHorario", intIdHorario);
                param.Add("@dttFecAsig", dttFecAsig);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                //Parámetros de Salida
                param.Add("@intIdPerHor", intIdPerHor);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdEmpresaOut = Convert.ToInt32(cmd.Parameters["@intIdPerHor"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdEmpresaOut;
        }
        //5.71
        public List<EmpleadoObs> IUREGAsigHor(Session_Movi objSession, DataTable TT_TGPERS_HORARIO_DET, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EmpleadoObs> lista = new List<EmpleadoObs>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERS_HORARIO_DET_IU02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@tt_TGPERS_HORARIO_DET", TT_TGPERS_HORARIO_DET);
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmpleadoObs obj = new EmpleadoObs();
                    obj.intCodigo = reader.GetInt32(0);
                    if (reader.FieldCount == 4)
                    {
                        obj.strCodEmpleado = reader.GetString(1);
                        obj.strNomCompleto = reader.GetString(2);
                        obj.strObservacion = reader.GetString(3);
                    }
                    lista.Add(obj);
                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return lista;
        }
        //5.72
        public List<int> IUREGAsigHorPost(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<int> listHorarios = new List<int>();//cambiar lista
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERS_HORARIO_DET_I01", cn);//TSP_TGPER_HORARIO_DET_I01
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                //parametros de entrada
                param.Add("@intIdSesion", objSession.intIdSesion);
                param.Add("@intIdMenu", objSession.intIdMenu);
                param.Add("@intIdSoft", objSession.intIdSoft);
                param.Add("@intIdUsuario", objSession.intIdUsuario);
                param.Add("@intIdProceso", intIdProceso);
                //Parámetros de Salida
                param.Add("@intResult", 1);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listHorarios.Add(reader.GetInt32(0));
                    }
                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listHorarios;
        }

        #endregion


        #region Permiso Masivo
        //07.10.2021
        public List<PermisoMasivo> ImportMasivoPermiso(Session_Movi session, DataTable tb, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<PermisoMasivo> listobj = new List<PermisoMasivo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_MASIVO_PERMISO_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@TT_MASIVO_PERMISO", tb);
                param.Add("@idProceso", idProceso);
                param.Add("@cboPlantilla", cboPlantilla);
                param.Add("@cboFormato", cboFormato);
                param.Add("@checkActualizar", checkActualizar);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PermisoMasivo obj = new PermisoMasivo();
                        if (!reader.IsDBNull(0))
                        {
                            obj.EMPRESA = reader.GetString(0);
                        }
                        if (!reader.IsDBNull(1))
                        {
                            obj.COD_EMP = reader.GetString(1);
                        }
                        if (!reader.IsDBNull(2))
                        {
                            obj.NOMBRES = reader.GetString(2);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            obj.COD_JUSTI = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            obj.DSCPERMISO = reader.GetString(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            obj.FECHAINICIO = reader.GetString(5);
                        }
                        if (!reader.IsDBNull(6))
                        {
                            obj.FECHAFIN = reader.GetString(6);
                        }
                        if (!reader.IsDBNull(7))
                        {
                            obj.HORAINICIO = reader.GetString(7);
                        }
                        if (!reader.IsDBNull(8))
                        {
                            obj.HORAFIN = reader.GetString(8);
                        }
                        if (!reader.IsDBNull(9)) //añadido 25.10.2021
                        {
                            obj.CAMBIODIA = reader.GetString(9);
                        }
                        if (!reader.IsDBNull(10))
                        {
                            obj.COMENTARIO = reader.GetString(10);
                        }
                        if (!reader.IsDBNull(11))
                        {
                            obj.INTIDPROCESO = reader.GetInt32(11);
                        }
                        if (!reader.IsDBNull(12))
                        {
                            obj.OBSERVACION = reader.GetString(12);
                        }
                        if (!reader.IsDBNull(13))
                        {
                            obj.FLAGOBSERVADO = reader.GetBoolean(13);
                        }
                        if (!reader.IsDBNull(14)) //25.10.2021
                        {
                            obj.NDIAS = reader.GetInt32(14);
                        }

                        listobj.Add(obj);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        public List<PermisoMasivo> GuardarMasivoPermiso(Session_Movi session, int idProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<PermisoMasivo> listobj = new List<PermisoMasivo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {

                SqlCommand cmd = new SqlCommand("TSP_MASIVO_PERMISO_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);
                param.Add("@intIdUsuario", session.intIdUsuario);

                param.Add("@idProceso", idProceso);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PermisoMasivo obj = new PermisoMasivo();

                        obj.EMPRESA = reader.GetString(0);
                        obj.COD_EMP = reader.GetString(1);
                        obj.NOMBRES = reader.GetString(2);
                        obj.COD_JUSTI = reader.GetString(3);
                        obj.DSCPERMISO = reader.GetString(4);
                        obj.FECHAINICIO = reader.GetString(5);
                        obj.FECHAFIN = reader.GetString(6);
                        obj.HORAINICIO = reader.GetString(7);
                        obj.HORAFIN = reader.GetString(8);
                        obj.CAMBIODIA = reader.GetString(9); //AÑADIDO 25.10.2021
                        obj.COMENTARIO = reader.GetString(10);
                        obj.INTIDPROCESO = reader.GetInt32(11);
                        obj.OBSERVACION = reader.GetString(12);
                        obj.FLAGOBSERVADO = reader.GetBoolean(13);
                        obj.ESTADO_FINAL = reader.GetInt32(14);
                        obj.NDIAS = reader.GetInt32(15);//25.10.2021
                        listobj.Add(obj);
                    }
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return listobj;
        }
        #endregion





    }
}
