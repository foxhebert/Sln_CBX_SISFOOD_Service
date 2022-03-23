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
    public class MarcadorDAO : Conexion
    {
        public List<Marcador> ListarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Marcador> lista = new List<Marcador>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGMARCADOR_Q02", cn);//TSP_TGMARCADOR_Q04
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);

                param.Add("@intActivoFilter", intActivoFilter);
                param.Add("@strfilter", strfilter);

                //salida
                //param.Add("@TotalRows", 0);
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Marcador obj = new Marcador();
                    UnidadOrg ObjOrg = new UnidadOrg();
                    Estado objEstado = new Estado();

                    obj.intNumMarcador = reader.GetInt32(0);
                    obj.strDesMarcador = reader.GetString(1);
                    obj.strNumIP = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);
                    objEstado.strEstadoActivo = reader.GetString(5);
                    obj.intIdMarcador = reader.GetInt32(6);
                    obj.intNumPuerto = reader.GetString(7);
                    obj.intTipoMarcad = reader.GetInt32(8);
                    obj.intTipoFunc = reader.GetInt32(9);
                    obj.strMarcadCampo1 = reader.GetString(10);
                    obj.strMarcadCampo2 = reader.GetString(11);
                    obj.strMarcadCampo3 = reader.GetString(12);
                    obj.strMarcadCampo4 = reader.GetString(13);
                    obj.strMarcadCampo5 = reader.GetString(14);
                    obj.intIdUniOrg = reader.GetInt32(15);
                    obj.bitTipoComu = reader.GetBoolean(16);
                    obj.NumIPNumPort = reader.GetString(17);


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

        public int IUMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Marcador objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdMarcadorOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGMARCADOR_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                param.Add("@intNumMarcador", objDatos.intNumMarcador);
                param.Add("@strDesMarcador", objDatos.strDesMarcador);
                param.Add("@intTipoMarcad", objDatos.intTipoMarcad);
                param.Add("@intTipoFunc", objDatos.intTipoFunc);
                param.Add("@bitTipoComu", objDatos.bitTipoComu);
                param.Add("@strNumIP", objDatos.strNumIP);
                param.Add("@intNumPuerto", objDatos.intNumPuerto);
                param.Add("@intIdUniOrg", objDatos.intIdUniOrg);
                param.Add("@strMarcadCampo1", objDatos.strMarcadCampo1);
                param.Add("@strMarcadCampo2", objDatos.strMarcadCampo2);
                param.Add("@strMarcadCampo3", objDatos.strMarcadCampo3);
                param.Add("@strMarcadCampo4", objDatos.strMarcadCampo4);
                param.Add("@strMarcadCampo5", objDatos.strMarcadCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                if (intTipoOperacion == 1)
                {
                    param.Add("@intIdMarcador", 0);
                }
                else
                {
                    param.Add("@intIdMarcador", objDatos.intIdMarcador);
                }
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdMarcadorOut = Convert.ToInt32(cmd.Parameters["@intIdMarcador"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdMarcadorOut;
        }

        public bool EliminarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdMarcador, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGMARCADOR_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intIdMarcador", intIdMarcador);
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

        public List<Marcador> ConsultarDetalleMarcadorxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdMarcador, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Marcador> listDetCar = new List<Marcador>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGMARCADOR_Q01", cn);//TSP_TGMARCADOR_Q10
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdMarcador", intIdMarcador);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UnidadOrg objOrg = new UnidadOrg();
                        Marcador obj = new Marcador();
                        obj.intIdMarcador = reader.GetInt32(0);
                        obj.intNumMarcador = reader.GetInt32(1);
                        obj.strDesMarcador = reader.GetString(2);
                        obj.intIdUniOrg = reader.GetInt32(3);
                        obj.intTipoMarcad = reader.GetInt32(4);
                        obj.intTipoFunc = reader.GetInt32(5);
                        obj.strNumIP = reader.GetString(6);
                        obj.intNumPuerto = reader.GetString(7);
                        obj.strMarcadCampo1 = reader.GetString(8);
                        obj.strMarcadCampo2 = reader.GetString(9);
                        obj.strMarcadCampo3 = reader.GetString(10);
                        obj.strMarcadCampo4 = reader.GetString(11);
                        obj.strMarcadCampo5 = reader.GetString(12);
                        obj.bitTipoComu = reader.GetBoolean(13);
                        obj.intIdEmpr = reader.GetInt32(14);//añadido 20.08.2021
                        obj.intIclokId_Wdms = reader.GetInt32(15);//añadido 20.08.2021
                        listDetCar.Add(obj);
                    }

                }
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }

            return listDetCar;
        }

        //añadido para Toma de Consumo - Seleccionar Marcador
        public int UTomaMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Marcador objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdMarcadorOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGMARCADOR_U01", cn); //creado 28.09.2021
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                param.Add("@intNumMarcador", objDatos.intNumMarcador);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                param.Add("@intIdMarcador", objDatos.intIdMarcador);
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdMarcadorOut = Convert.ToInt32(cmd.Parameters["@intIdMarcador"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdMarcadorOut;
        }

    }
}
