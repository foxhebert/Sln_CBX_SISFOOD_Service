﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.SqlServer
{
    public class CCostoDAO : Conexion
    {
        public List<CCosto> ListarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CCosto> lista = new List<CCosto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCCOSTO_Q02", cn);//TSP_TGCCOSTO_Q04
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intActivoFilter", intActivoFilter);
                param.Add("@strfilter", strfilter);
                param.Add("@intfiltrojer", intfiltrojer);
                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CCosto obj = new CCosto();
                    Estado objEstado = new Estado();
                    obj.strCoCCosto = reader.GetString(0);
                    obj.strDesCCosto = reader.GetString(1);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);
                    objEstado.strEstadoActivo = reader.GetString(5);
                    obj.IntIdCCosto = reader.GetInt32(6);
                    obj.intIdTipFisc = reader.GetInt32(7);
                    obj.strCeCoCampo1 = reader.GetString(8);
                    obj.strCeCoCampo2 = reader.GetString(9);
                    obj.strCeCoCampo3 = reader.GetString(10);
                    obj.strCeCoCampo4 = reader.GetString(11);
                    obj.strCeCoCampo5 = reader.GetString(12);
                    obj.IntIdUniOrg = reader.GetInt32(13);

                    obj.FlActivo = objEstado;
                    lista.Add(obj);

                }
                reader.Close();

                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();

            }
            return lista;
        }

        public int IUCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, CCosto objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int IntIdCCostoOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCCOSTO_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada

                param.Add("@strCoCCosto", objDatos.strCoCCosto);
                param.Add("@strDesCCosto", objDatos.strDesCCosto);
                param.Add("@intIdTipFisc", objDatos.intIdTipFisc);
                param.Add("@IntIdUniOrg", objDatos.IntIdUniOrg);
                param.Add("@strCeCoCampo1", objDatos.strCeCoCampo1);
                param.Add("@strCeCoCampo2", objDatos.strCeCoCampo2);
                param.Add("@strCeCoCampo3", objDatos.strCeCoCampo3);
                param.Add("@strCeCoCampo4", objDatos.strCeCoCampo4);
                param.Add("@strCeCoCampo5", objDatos.strCeCoCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                if (intTipoOperacion == 1)
                {
                    param.Add("@IntIdCCosto", 0);
                }
                else
                {
                    param.Add("@IntIdCCosto", objDatos.IntIdCCosto);
                }
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                IntIdCCostoOut = Convert.ToInt32(cmd.Parameters["@IntIdCCosto"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return IntIdCCostoOut;
        }

        public bool EliminarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdCCosto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCCOSTO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@IntIdCCosto", IntIdCCosto);
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

        public List<CCosto> ConsultarDetalleCCostoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdCCosto, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CCosto> listDetCar = new List<CCosto>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGCCOSTO_Q01", cn);//TSP_TGCCOSTO_Q08
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@IntIdCCosto", IntIdCCosto);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        CCosto obj = new CCosto();
                        obj.IntIdCCosto = reader.GetInt32(0);
                        obj.strCoCCosto = reader.GetString(1);
                        obj.strDesCCosto = reader.GetString(2);
                        obj.IntIdUniOrg = reader.GetInt32(3);
                        obj.IntIdCCosto = reader.GetInt32(4);
                        obj.intIdTipFisc = reader.GetInt32(5);
                        obj.strCeCoCampo1 = reader.GetString(6);
                        obj.strCeCoCampo2 = reader.GetString(7);
                        obj.strCeCoCampo3 = reader.GetString(8);
                        obj.strCeCoCampo4 = reader.GetString(9);
                        obj.strCeCoCampo5 = reader.GetString(10);
                        listDetCar.Add(obj);
                    }

                }


                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }

    }
}

