﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SqlServer
{
    public class ReportesDAO : Conexion

    {
        //7.1
        public List<Planilla> ListarCampoPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUniOrg, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREPORTES_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUniOrg", intIdUniOrg);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Planilla obj = new Planilla();
                        obj.intIdPlanilla = reader.GetInt32(0);
                        obj.strDesPlani = reader.GetString(1);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.2
        public List<TGTipoEN> ListarCampoFizcalizacion(long intIdSesion, int intIdMenu, int intIdSoft, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREPORTES_Q02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TGTipoEN obj = new TGTipoEN();
                        obj.intidTipo = reader.GetInt32(0);
                        obj.strDeTipo= reader.GetString(1);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.3
        public List<Reporte> ConsultaReporte(Session_Movi session, int cboUniOrg, string filtroCalculo, int cboPlanilla, int cboCategoria, bool cesado, int estado, DataTable tb, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Reporte> lista = new List<Reporte>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREPORTES_Q03", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intIdUniOrg", cboUniOrg);
                param.Add("@filtroCalculo", filtroCalculo);
                param.Add("@intIdPlanilla", cboPlanilla);
                param.Add("@intIdCategoria", cboCategoria);
                param.Add("@cesado", cesado);
                param.Add("@estado", estado);
                param.Add("@TT_GRUPOLIQ", tb);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Reporte obj = new Reporte();
                        obj.intIdPersonal = reader.GetInt32(0);
                        obj.strFotocheck = reader.GetString(1);
                        obj.strNomCompleto = reader.GetString(2);
                        obj.strNumDoc = reader.GetString(3);
                        obj.strCoReg = reader.GetString(4);
                        obj.strDesPlani = reader.GetString(5);
                        obj.strDesUniOrg = reader.GetString(6);
                        obj.strDesFis = reader.GetString(7);
                        obj.strDesGrupoLiq = reader.GetString(8);
                        obj.dttFecCese = reader.GetString(9);
                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.4
        public List<ReporteOficial> ReporteOficial(Session_Movi session, DataTable tb , bool marca, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReporteOficial> lista = new List<ReporteOficial>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_OFICIAL", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@marca", marca);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);
                param.Add("@TT_Empleados", tb);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteOficial obj = new ReporteOficial();
                        obj.IdPersonal = reader.GetInt32(0);
                        //obj.Cod_Personal = reader.GetString(1);
                        obj.Persona = reader.GetString(1);
                        obj.Documento = reader.GetString(2);
                        //obj.IdEmpresa = reader.GetInt32(4);
                        obj.Dsc_Empresa = reader.GetString(3);
                        obj.Ruc = reader.GetString(4);
                        obj.Fecha = reader.GetDateTime(5);
                        obj.HorarioEntrada = reader.GetInt32(6);
                        obj.HorarioSalida = reader.GetInt32(7);
                        obj.HoraEntrada = reader.GetInt32(8);
                        obj.HoraSalida = reader.GetInt32(9);
                        obj.HTrabajo = reader.GetInt32(10);
                        obj.HoraExtra = reader.GetInt32(11);
                        obj.NumMarcas = reader.GetInt32(12);
                        obj.DFalta = reader.GetInt32(13);
                        obj.DFeriado = reader.GetInt32(14);
                        //obj.DTrabajado = reader.GetInt32(17);
                        //obj.HEFED = reader.GetInt32(18);
                        obj.HJustificado = reader.GetInt32(15);
                        obj.DJustificado = reader.GetInt32(16);
                        obj.HJustDescrip = reader.GetString(17);
                        //obj.IdArea = reader.GetInt32(22);
                        //if (!reader.IsDBNull(23))
                        //{
                        //    obj.IdGrupo = reader.GetInt32(23);
                        //}
                        //if (!reader.IsDBNull(24))
                        //{
                        //    obj.IdCategoria = reader.GetInt32(24);
                        //}
                        //obj.IdCargo = reader.GetInt32(25);
                        //obj.IdPlanilla = reader.GetInt32(26);
                        obj.Compensado = reader.GetInt32(18);
                        //obj.IdLocal = reader.GetInt32(28);
                        //obj.Dsc_Local = reader.GetString(29);
                        //if (!reader.IsDBNull(30))
                        //{
                        //    obj.Direccion = reader.GetString(30);
                        //}
                        //obj.TiempoRefrig = reader.GetInt32(31);
                        obj.Flg_CargoConfianza = reader.GetInt32(19);
                        //obj.Dsc_Cargo = reader.GetString(33);
                        //obj.Cod_Planilla = reader.GetString(34);
                        //obj.Fec_Ingreso = reader.GetDateTime(35);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.5
        public List<ReporteDiario> ReporteDiario(Session_Movi session, DataTable tb, bool marca, int estado, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReporteDiario> lista = new List<ReporteDiario>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_DIARIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@marca", marca);
                param.Add("@estado", estado);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);
                param.Add("@TT_Empleados", tb);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteDiario obj = new ReporteDiario();
                        obj.IdPersonal = reader.GetInt32(0);
                        obj.Cod_Personal = reader.GetString(1);
                        obj.Persona = reader.GetString(2);
                        obj.IdEmpresa = reader.GetInt32(3);
                        obj.Cod_Empresa = reader.GetString(4);
                        obj.Dsc_Empresa = reader.GetString(5);
                        obj.Ruc = reader.GetString(6);
                        obj.IdArea = reader.GetInt32(7);
                        obj.Cod_Area = reader.GetString(8);
                        obj.Dsc_Area = reader.GetString(9);
                        obj.IdGrupo = reader.GetInt32(10);
                        obj.Cod_Grupo = reader.GetString(11);
                        obj.Dsc_Grupo = reader.GetString(12);
                        obj.IdLocal = reader.GetInt32(13);
                        obj.Cod_Local = reader.GetString(14);
                        obj.Dsc_Local = reader.GetString(15);
                        obj.IdCategoria = reader.GetInt32(16);
                        obj.Cod_Categoria = reader.GetString(17);
                        obj.Dsc_Categoria = reader.GetString(18);
                        obj.Fecha = reader.GetDateTime(19);
                        obj.HEntrada = reader.GetInt32(20);
                        obj.HSalida = reader.GetInt32(21);
                        obj.HoraEntrada = reader.GetInt32(22);
                        obj.HoraSalida = reader.GetInt32(23);
                        obj.HTRAB = reader.GetInt32(24);
                        obj.HTEFE = reader.GetInt32(25);
                        obj.HTRABN = reader.GetInt32(26);
                        obj.HES25 = reader.GetInt32(27);
                        obj.HES35 = reader.GetInt32(28);
                        obj.HEN25 = reader.GetInt32(29);
                        obj.HEN35 = reader.GetInt32(30);
                        obj.HED25 = reader.GetInt32(31);
                        obj.HED35 = reader.GetInt32(32);
                        obj.HEDN = reader.GetInt32(33);
                        obj.HTFEDOM = reader.GetInt32(34);
                        obj.HE60 = reader.GetInt32(35);
                        obj.HE100 = reader.GetInt32(36);
                        obj.HEFD = reader.GetInt32(37);
                        obj.NumMarcas = reader.GetInt32(38);
                        obj.DFalta = reader.GetInt32(39);
                        obj.DMedico = reader.GetInt32(40);
                        obj.TIngreso = reader.GetInt32(41);
                        obj.TRefrigerio = reader.GetInt32(42);
                        obj.HFerDescanso = reader.GetInt32(43);
                        obj.DVacaciones = reader.GetInt32(44);
                        obj.DFeriado = reader.GetInt32(45);
                        obj.DTrabajado = reader.GetInt32(46);
                        obj.HJustificado = reader.GetInt32(47);
                        obj.DJustificado = reader.GetInt32(48);
                        obj.HAdicional = reader.GetInt32(49);
                        obj.IdPlanilla = reader.GetInt32(50);
                        obj.IdCargo = reader.GetInt32(51);
                        obj.Sueldo = reader.GetInt32(52);
                        obj.AsignacionFamiliar = reader.GetInt32(53);
                        obj.NDocumento = reader.GetString(54);
                        obj.Compensado = reader.GetInt32(55);
                        obj.PermisoNoRecuperado = reader.GetInt32(56);
                        obj.HFUERA = reader.GetInt32(57);
                        obj.ETOLS = reader.GetInt32(58);
                        obj.Activo = reader.GetBoolean(59);
                        obj.Flg_CargoConfianza = reader.GetInt32(60);
                        obj.HJustDescrip = reader.GetString(61);
                        obj.HEDD = reader.GetInt32(62);
                        obj.HEFD = reader.GetInt32(63);
                        obj.HEFN = reader.GetInt32(64);
                        obj.HEDP = reader.GetInt32(65);
                        obj.HTDIU = reader.GetInt32(66);
                        obj.HTNOC = reader.GetInt32(67);
                        obj.HTDOM = reader.GetInt32(68);
                        obj.TotalHT = reader.GetInt32(69);
                        obj.HTotales = reader.GetInt32(70);
                        obj.HExtrasTotales = reader.GetInt32(71);
                        obj.NSEMANA = reader.GetInt32(72);
                        obj.NDIA = reader.GetInt32(73);
                        obj.HFER = reader.GetInt32(74);
                        obj.BNLC = reader.GetInt32(75);
                        obj.DCH = reader.GetInt32(76);
                        obj.DSH = reader.GetInt32(77);
                        obj.HCH = reader.GetInt32(78);
                        obj.HSH = reader.GetInt32(79);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.6
        public List<ReporteResumenTotal> ReporteResumenTotal(Session_Movi session, DataTable tb, int intPeriodo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReporteResumenTotal> lista = new List<ReporteResumenTotal>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_RESUMEN_TOTAL", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intPeriodo", intPeriodo);
                param.Add("@TT_Empleados", tb);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteResumenTotal obj = new ReporteResumenTotal();

                        obj.Cod_Personal = reader.GetString(0);
                        obj.Persona = reader.GetString(1);
                        obj.IdEmpresa = reader.GetInt32(3);
                        obj.Cod_Empresa = reader.GetString(4);
                        obj.Dsc_Empresa = reader.GetString(5);
                        obj.Ruc = reader.GetString(6);
                        obj.HTrabajo = reader.GetInt32(7);
                        obj.HFuera = reader.GetInt32(8);
                        obj.HTardanza = reader.GetInt32(9);
                        obj.HAdicionales = reader.GetInt32(10);
                        obj.HTardanzaRefrig = reader.GetInt32(11);
                        obj.DFalta = reader.GetInt32(12);
                        obj.DAsistencia = reader.GetInt32(13);
                        obj.ETOLS = reader.GetInt32(14);
                        obj.PNR = reader.GetInt32(15);
                        obj.IdPlanilla = reader.GetInt32(16);
                        obj.Cod_Planilla = reader.GetString(17);
                        obj.Dsc_Planilla = reader.GetString(18);
                        obj.IdPeriodo = reader.GetInt32(19);
                        obj.Dsc_Periodo = reader.GetString(20);
                        obj.idPersonal = reader.GetInt32(21);
                        obj.IdArea = reader.GetInt32(22);
                        obj.IdLocal = reader.GetInt32(23);
                        obj.IdGrupo = reader.GetInt32(24);
                        obj.IdCategoria = reader.GetInt32(25);
                        obj.IdCargo = reader.GetInt32(26);
                        obj.Sueldo = reader.GetInt32(27);
                        obj.AsignacionFamiliar = reader.GetInt32(28);
                        obj.Cod_Area = reader.GetString(29);
                        obj.Dsc_Area = reader.GetString(30);
                        obj.Cod_Categoria = reader.GetString(31);
                        obj.Dsc_Categoria = reader.GetString(32);
                        obj.NTardanza = reader.GetInt32(33);
                        obj.DTEfectivo = reader.GetInt32(34);
                        obj.HE25 = reader.GetInt32(35);
                        obj.HE35 = reader.GetInt32(36);
                        obj.HEDOB = reader.GetInt32(37);
                        obj.HEN25 = reader.GetInt32(38);
                        obj.HEN35 = reader.GetInt32(39);
                        obj.HENDOB = reader.GetInt32(40);
                        obj.DVacaciones = reader.GetInt32(41);
                        obj.DPermiso = reader.GetInt32(42);
                        obj.DLicencia = reader.GetInt32(43);
                        obj.DDesMedico = reader.GetInt32(44);
                        obj.DSubsidio = reader.GetInt32(45);
                        obj.DSuspension = reader.GetInt32(46);
                        obj.Permiso = reader.GetInt32(47);


                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.7
        public List<ReporteFalta> ReporteFalta(Session_Movi session, DataTable tb, int intPeriodo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReporteFalta> lista = new List<ReporteFalta>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_FALTA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intPeriodo", intPeriodo);
                param.Add("@TT_Empleados", tb);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteFalta obj = new ReporteFalta();
                        obj.IdPersonal = reader.GetInt32(0);
                        obj.Cod_Personal = reader.GetString(1);
                        obj.Persona = reader.GetString(2);
                        obj.Documento = reader.GetString(3);
                        obj.IdEmpresa = reader.GetInt32(4);
                        obj.Cod_Empresa = reader.GetString(5);
                        obj.Dsc_Empresa = reader.GetString(6);
                        obj.Ruc = reader.GetString(7);
                        obj.IdArea = reader.GetInt32(8);
                        obj.IdCategoria = reader.GetInt32(9);
                        obj.IdGrupo = reader.GetInt32(10);
                        obj.IdLocal = reader.GetInt32(11);
                        obj.IdPlanilla = reader.GetInt32(12);
                        obj.IdCargo = reader.GetInt32(13);
                        obj.IdPeriodo = reader.GetInt32(14);
                        obj.Dsc_Periodo = reader.GetString(15);
                        obj.nDFalta = reader.GetInt32(16);
                        obj.Cod_Area = reader.GetString(17);
                        obj.Dsc_Area = reader.GetString(18);
                        obj.Dsc_Categoria = reader.GetString(19);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.8
        public List<ReportePuntualidad> ReportePuntualidad(Session_Movi session, DataTable tb, int intPeriodo, int tipo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReportePuntualidad> lista = new List<ReportePuntualidad>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_PUNTUALIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intPeriodo", intPeriodo);
                param.Add("@tipo", tipo);
                param.Add("@TT_Empleados", tb);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReportePuntualidad obj = new ReportePuntualidad();
                        if (tipo == 1)
                        {
                            obj.IdPersonal = reader.GetInt32(0);
                            obj.Cod_Personal = reader.GetString(1);
                            obj.Persona = reader.GetString(2);
                            obj.Documento = reader.GetString(3);
                            obj.IdEmpresa = reader.GetInt32(4);
                            obj.Cod_Empresa = reader.GetString(5);
                            obj.Dsc_Empresa = reader.GetString(6);
                            obj.Ruc = reader.GetString(7);
                            obj.IdArea = reader.GetInt32(8);
                            obj.IdCategoria = reader.GetInt32(9);
                            obj.IdGrupo = reader.GetInt32(10);
                            obj.IdLocal = reader.GetInt32(11);
                            obj.IdPlanilla = reader.GetInt32(12);
                            obj.IdCargo = reader.GetInt32(13);
                            obj.IdPeriodo = reader.GetInt32(14);
                            obj.Dsc_Periodo = reader.GetString(15);
                            obj.Tiempo = reader.GetInt32(16);
                            obj.Cod_Area = reader.GetString(17);
                            obj.Dsc_Area = reader.GetString(18);
                        }
                        else if(tipo == 2)
                        {
                            obj.VALOR = reader.GetString(0);
                            obj.Total = reader.GetInt32(1);
                        }
                        
                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.9
        public List<ReporteTardanza> ReporteTardanza(Session_Movi session, DataTable tb, int intPeriodo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReporteTardanza> lista = new List<ReporteTardanza>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_TARDANZA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intPeriodo", intPeriodo);
                param.Add("@TT_Empleados", tb);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteTardanza obj = new ReporteTardanza();
                        obj.IdPersonal = reader.GetInt32(0);
                        obj.Cod_Personal = reader.GetString(1);
                        obj.Persona = reader.GetString(2);
                        obj.Documento = reader.GetString(3);
                        obj.IdEmpresa = reader.GetInt32(4);
                        obj.Cod_Empresa = reader.GetString(5);
                        obj.Dsc_Empresa = reader.GetString(6);
                        obj.Ruc = reader.GetString(7);
                        obj.IdArea = reader.GetInt32(8);
                        obj.IdCategoria = reader.GetInt32(9);
                        obj.IdGrupo = reader.GetInt32(10);
                        obj.IdLocal = reader.GetInt32(11);
                        obj.IdPlanilla = reader.GetInt32(12);
                        obj.IdCargo = reader.GetInt32(13);
                        obj.IdPeriodo = reader.GetInt32(14);
                        obj.Dsc_Periodo = reader.GetString(15);
                        obj.Tiempo = reader.GetInt32(16);
                        obj.Cod_Area = reader.GetString(17);
                        obj.Dsc_Area = reader.GetString(18);
                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.10
        public List<ReporteRecordGeneral> ReporteRecordGeneral(Session_Movi session, DataTable tb, int intPeriodo, int tipo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReporteRecordGeneral> lista = new List<ReporteRecordGeneral>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_RECORD_GENERAL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intPeriodo", intPeriodo);
                param.Add("@tipo", tipo);
                param.Add("@TT_Empleados", tb);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteRecordGeneral obj = new ReporteRecordGeneral();
                        if (tipo == 1)
                        {
                            obj.IdPersonal = reader.GetInt32(0);
                            obj.Cod_Personal = reader.GetString(1);
                            obj.Persona = reader.GetString(2);
                            obj.Documento = reader.GetString(3);
                            obj.IdEmpresa = reader.GetInt32(4);
                            obj.Cod_Empresa = reader.GetString(5);
                            obj.Dsc_Empresa = reader.GetString(6);
                            obj.Ruc = reader.GetString(7);
                            obj.IdArea = reader.GetInt32(8);
                            obj.IdCategoria = reader.GetInt32(9);
                            obj.IdGrupo = reader.GetInt32(10);
                            obj.IdLocal = reader.GetInt32(11);
                            obj.IdPlanilla = reader.GetInt32(12);
                            obj.IdCargo = reader.GetInt32(13);
                            obj.IdPeriodo = reader.GetInt32(14);
                            obj.Dsc_Periodo = reader.GetString(15);
                            obj.Cod_Area = reader.GetString(16);
                            obj.Dsc_Area = reader.GetString(17);
                            obj.Dsc_Categ = reader.GetString(18);
                            obj.Dsc_Local = reader.GetString(19);
                            obj.Tiempo = reader.GetInt32(20);
                            obj.nDFalta = reader.GetInt32(21);
                            obj.Tipo_reporte = reader.GetString(22);
                        }
                        else if(tipo == 2)
                        {
                            obj.VALOR = reader.GetString(0);
                            obj.Total = reader.GetInt32(1);
                        }
                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.11
        public List<ReporteAusencia> ReporteAusencia(Session_Movi session, DataTable tb, DataTable tb2, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReporteAusencia> lista = new List<ReporteAusencia>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_AUSENCIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@TT_Empleados", tb);
                param.Add("@TT_Conceptos", tb2);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteAusencia obj = new ReporteAusencia();
                        obj.Cod_Personal = reader.GetString(0);
                        obj.Persona = reader.GetString(1);
                        obj.Documento = reader.GetString(2);
                        obj.IdEmpresa = reader.GetInt32(3);
                        obj.Cod_Empresa = reader.GetString(4);
                        obj.Dsc_Empresa = reader.GetString(5);
                        obj.Ruc = reader.GetString(6);
                        obj.Cod_Concepto = reader.GetString(7);
                        obj.Concepto = reader.GetString(8);
                        obj.Unidad_Tiempo = reader.GetString(9);
                        obj.Fecha = reader.GetDateTime(10);
                        obj.Tiempo = reader.GetInt32(11);
                        obj.HTiempo = reader.GetString(12);
                        obj.IdPersonal = reader.GetInt32(13);
                        obj.IdCategoria = reader.GetInt32(14);
                        obj.IdArea = reader.GetInt32(15);
                        obj.IdLocal = reader.GetInt32(16);
                        obj.IdGrupo = reader.GetInt32(17);
                        obj.IdPlanilla = reader.GetInt32(18);
                        obj.IdCargo = reader.GetInt32(19);
                        obj.Observacion = reader.GetString(20);
                        obj.Cod_Area = reader.GetString(21);
                        obj.Dsc_Area = reader.GetString(22);
                        obj.Dsc_Categoria = reader.GetString(23);
                        obj.NDocumento = reader.GetString(24);
                        obj.Cod_Cargo = reader.GetString(25);
                        obj.Dsc_Cargo = reader.GetString(26);
                        obj.Cod_Grupo = reader.GetString(27);
                        obj.Dsc_Grupo = reader.GetString(28);
                        obj.ACTIVO = reader.GetBoolean(29);
                        obj.IDCONCEPTO = reader.GetInt32(30);
                        obj.MINUTOS = reader.GetInt32(31);
                        obj.Horario = reader.GetString(32);
                        obj.TiempoMaximo = reader.GetInt32(33);
                        obj.TipoConcepto = reader.GetString(34);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.12
        public List<ReporteAsistencia> ReporteAsistencia(Session_Movi session, DataTable tb, int intMarcador, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReporteAsistencia> lista = new List<ReporteAsistencia>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_ASISTENCIA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@TT_Empleados", tb);
                param.Add("@intidMarcador", intMarcador);
                param.Add("@filtroFer_ini", filtrojer_ini);
                param.Add("@filtroFer_fin", filtrojer_fin);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteAsistencia obj = new ReporteAsistencia();
                        obj.Dsc_Empresa = reader.GetString(0);
                        obj.Ruc = reader.GetString(1);
                        obj.Cod_Personal = reader.GetString(2);
                        obj.Persona = reader.GetString(3);
                        obj.Dsc_Local = reader.GetString(4);
                        obj.Direccion = reader.GetString(5);
                        obj.Documento = reader.GetString(6);
                        obj.fecha = reader.GetDateTime(7);
                        obj.Cod_Area = reader.GetString(8);
                        obj.Dsc_Area = reader.GetString(9);
                        obj.Dia = reader.GetString(10);
                        obj.Marca1 = reader.GetString(11);
                        obj.Marca2 = reader.GetString(12);
                        obj.Marca3 = reader.GetString(13);
                        obj.Marca4 = reader.GetString(14);
                        obj.Marca5 = reader.GetString(15);
                        obj.Marca6 = reader.GetString(16);
                        obj.Marca7 = reader.GetString(17);
                        obj.Marca8 = reader.GetString(18);
                        obj.Horario = reader.GetString(19);
                        obj.no_fiscalizado = reader.GetString(20);
                        obj.Dsc_Marcador = reader.GetString(21);
                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.13
        public List<ReporteM> GetReportes(Session_Movi session, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<ReporteM> lista = new List<ReporteM>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGREPORTES_Q04", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//21.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var strPadre = "";
                    ReporteM padre = new ReporteM(); ;
                    while (reader.Read())
                    {
                        if (strPadre == "")
                        {
                            strPadre = reader.GetString(1);
                            padre = new ReporteM();
                            List<ReporteM> listaMenuHijo = new List<ReporteM>();
                            padre.ListHijos = listaMenuHijo;
                            padre.intIdReporte = reader.GetInt32(0);
                            padre.strCoReporte = reader.GetString(1);
                            padre.strDesReporte = reader.GetString(2);
                            padre.intOrden = reader.GetInt32(3);
                        }
                        else if (strPadre != reader.GetString(1))
                        {
                            //se agrega el menu a la lista antes de crear otro
                            lista.Add(padre);

                            strPadre = reader.GetString(1);
                            padre = new ReporteM();
                            List<ReporteM> listaMenuHijo = new List<ReporteM>();
                            padre.ListHijos = listaMenuHijo;
                            padre.intIdReporte = reader.GetInt32(0);
                            padre.strCoReporte = reader.GetString(1);
                            padre.strDesReporte = reader.GetString(2);
                            padre.intOrden = reader.GetInt32(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            ReporteM obj = new ReporteM();
                            obj.intIdReporte = reader.GetInt32(4);
                            obj.strCoReporte = reader.GetString(5);
                            obj.strDesReporte = reader.GetString(6);
                            obj.strCoPadre = reader.GetString(7);
                            obj.intOrden = reader.GetInt32(8);

                            padre.ListHijos.Add(obj);
                        }
                    }
                    lista.Add(padre);
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }

        #region COMEDOR

        //7.14 - HG 05.03.21 - Añadido
        public List<ReporteDiarioComedor> ReporteDiarioComedor(Session_Movi session, DataTable tb, bool bitCosto, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido)
        {
            List<ReporteDiarioComedor> lista = new List<ReporteDiarioComedor>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_DIARIO_COMEDOR", cn);//TSP_REPORTE_DIARIO
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@bitCosto", bitCosto);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);
                param.Add("@TT_Empleados", tb);

                param.Add("@intIdTipServ", intIdTipServ);
                param.Add("@intIdTipMen", intIdTipMen);
                param.Add("@intIdMarcador", intIdMarcador);
                param.Add("@bitAtendido", bitAtendido);//añadido 24.09.2021

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ReporteDiarioComedor obj = new ReporteDiarioComedor();

                        obj.IdPersonal = reader.GetInt32(0);
                        obj.Cod_Personal = reader.GetString(1);
                        obj.Persona = reader.GetString(2);
                        obj.Fotochek = reader.GetString(3);
                        obj.Dsc_Empresa = reader.GetString(4);
                        obj.Ruc = reader.GetString(5);
                        obj.rHora = reader.GetDateTime(6);
                        obj.sDesServicio = reader.GetString(7);
                        obj.NumConsumos = reader.GetInt32(8);
                        obj.dcCosto = reader.GetDecimal(9);
                        obj.Moneda = reader.GetString(10);
                        obj.DTTFecha = reader.GetDateTime(11);//añadido 11.03.2021
                        obj.dcSubsidiado = reader.GetDecimal(12); //añadido 11.03.2021

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.15 - HG 08.03.21 - Añadido
        public List<ReporteTotalComedor> ReporteTotalComedor(Session_Movi session, DataTable tb, int intPeriodo, bool bitCosto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido)
        {
            List<ReporteTotalComedor> lista = new List<ReporteTotalComedor>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_TOTAL_COMEDOR", cn);//TSP_REPORTE_RESUMEN_TOTAL
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intPeriodo", intPeriodo);
                param.Add("@bitCosto", bitCosto);
                param.Add("@TT_Empleados", tb);
                param.Add("@intIdTipServ", intIdTipServ);
                param.Add("@intIdTipMen", intIdTipMen);
                param.Add("@intIdMarcador", intIdMarcador);
                param.Add("@bitAtendido", bitAtendido);//añadido 24.09.2021

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteTotalComedor obj = new ReporteTotalComedor();

                        obj.IdPersonal = reader.GetInt32(0);
                        obj.Cod_Personal = reader.GetString(1);
                        obj.Persona = reader.GetString(2);
                        obj.Fotochek = reader.GetString(3);
                        obj.Dsc_Empresa = reader.GetString(4);
                        obj.Ruc = reader.GetString(5);
                        obj.sDesServicio = reader.GetString(6);
                        obj.NumConsumos = reader.GetInt32(7);
                        obj.PrecioUnitario = reader.GetDecimal(8);
                        obj.dcCosto = reader.GetDecimal(9);
                        obj.Moneda = reader.GetString(10);
                        obj.dcSubsidiado = reader.GetDecimal(11); //añadido 11.03.2021

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.16 - 16.03.2021
        public List<ReporteDiarioConcesionaria> ReporteDiarioConcesionaria(Session_Movi session, DataTable tb, int idConcesionaria, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido)
        {
            List<ReporteDiarioConcesionaria> lista = new List<ReporteDiarioConcesionaria>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_DIARIO_CONCESIONARIA", cn);//TSP_REPORTE_DIARIO
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intIdConcesionaria", idConcesionaria);
                param.Add("@filtrojer_ini", filtrojer_ini);
                param.Add("@filtrojer_fin", filtrojer_fin);
                param.Add("@TT_Empleados", tb);

                param.Add("@intIdTipServ", intIdTipServ);
                param.Add("@intIdTipMen", intIdTipMen);
                param.Add("@intIdMarcador", intIdMarcador);
                param.Add("@bitAtendido", bitAtendido);//añadido 24.09.2021

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ReporteDiarioConcesionaria obj = new ReporteDiarioConcesionaria();

                        obj.Ruc_Concesionaria = reader.GetString(0);
                        obj.Dsc_Concesionaria = reader.GetString(1);
                        obj.PersonaConcesionaria = reader.GetString(2);
                        obj.Doc_PersonaConcesionaria = reader.GetString(3);

                        obj.IdPersonal = reader.GetInt32(4);
                        obj.Cod_Personal = reader.GetString(5);
                        obj.Persona = reader.GetString(6);
                        obj.Fotochek = reader.GetString(7);
                        obj.Dsc_Empresa = reader.GetString(8);
                        obj.Ruc = reader.GetString(9);
                        obj.rHora = reader.GetDateTime(10);
                        obj.sDesServicio = reader.GetString(11);
                        obj.NumConsumos = reader.GetInt32(12);
                        obj.dcCosto = reader.GetDecimal(13);
                        obj.Moneda = reader.GetString(14);
                        obj.DTTFecha = reader.GetDateTime(15);
                        obj.dcSubsidiado = reader.GetDecimal(16);
                        obj.dcTotal = reader.GetDecimal(17);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        //7.17
        public List<ReporteTotalConcesionaria> ReporteTotalConcesionaria(Session_Movi session, DataTable tb, int intPeriodo, int idConcesionaria, ref int intResult, ref string strMsjDB, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido)
        {
            List<ReporteTotalConcesionaria> lista = new List<ReporteTotalConcesionaria>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_REPORTE_TOTAL_CONCESIONARIA", cn);//TSP_REPORTE_RESUMEN_TOTAL
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", session.intIdSesion);
                param.Add("@intIdMenu", session.intIdMenu);
                param.Add("@intIdSoft", session.intIdSoft);

                param.Add("@intPeriodo", intPeriodo);
                param.Add("@intIdConcesionaria", idConcesionaria);
                param.Add("@TT_Empleados", tb);
                param.Add("@intIdTipServ", intIdTipServ);
                param.Add("@intIdTipMen", intIdTipMen);
                param.Add("@intIdMarcador", intIdMarcador);
                param.Add("@bitAtendido", bitAtendido);//añadido 24.09.2021

                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReporteTotalConcesionaria obj = new ReporteTotalConcesionaria();

                        obj.Ruc_Concesionaria = reader.GetString(0);
                        obj.Dsc_Concesionaria = reader.GetString(1);
                        obj.PersonaConcesionaria = reader.GetString(2);
                        obj.Doc_PersonaConcesionaria = reader.GetString(3);

                        obj.IdPersonal = reader.GetInt32(4);
                        obj.Cod_Personal = reader.GetString(5);
                        obj.Persona = reader.GetString(6);
                        obj.Fotochek = reader.GetString(7);
                        obj.Dsc_Empresa = reader.GetString(8);
                        obj.Ruc = reader.GetString(9);
                        obj.sDesServicio = reader.GetString(10);
                        obj.NumConsumos = reader.GetInt32(11);
                        obj.dcCosto = reader.GetDecimal(12);
                        obj.Moneda = reader.GetString(13);
                        obj.dcSubsidiado = reader.GetDecimal(14);
                        obj.dcTotal = reader.GetDecimal(15);

                        lista.Add(obj);

                    }
                    reader.Close();
                }

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;

        }
        #endregion COMEDOR

    }
}
