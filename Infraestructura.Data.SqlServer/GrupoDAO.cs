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
    public class GrupoDAO : Conexion
    {

        public List<Grupo> ListarGrupos(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Grupo> lista = new List<Grupo>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGGRUPO_Q02", cn);//TSP_TGGRUPO_Q04
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
                    Grupo obj = new Grupo();
                    Estado objEstado = new Estado();
                    obj.strCoGrupo = reader.GetString(0);
                    obj.strDesGrupo = reader.GetString(1);
                    obj.strDescripcion = reader.GetString(2);
                    obj.strNomJerOrg = reader.GetString(3);
                    obj.bitFlActivo = reader.GetBoolean(4);
                    objEstado.strEstadoActivo = reader.GetString(5);
                    obj.intIdGrupo = reader.GetInt32(6);
                    obj.strGrupoCampo1 = reader.GetString(7);
                    obj.strGrupoCampo2 = reader.GetString(8);
                    obj.strGrupoCampo3 = reader.GetString(9);
                    obj.strGrupoCampo4 = reader.GetString(10);
                    obj.strGrupoCampo5 = reader.GetString(11);
                    obj.intIdUniOrg = reader.GetInt32(12);

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

        public int IUGrupo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Grupo objDatos, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {

            int intIdGrupoOut = 0;
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGGRUPO_IU01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);//parametros de entrada
                param.Add("@strCoGrupo", objDatos.strCoGrupo);
                param.Add("@strDesGrupo", objDatos.strDesGrupo);
                param.Add("@intIdUniOrg", objDatos.intIdUniOrg);
                param.Add("@strGrupoCampo1", objDatos.strGrupoCampo1);
                param.Add("@strGrupoCampo2", objDatos.strGrupoCampo2);
                param.Add("@strGrupoCampo3", objDatos.strGrupoCampo3);
                param.Add("@strGrupoCampo4", objDatos.strGrupoCampo4);
                param.Add("@strGrupoCampo5", objDatos.strGrupoCampo5);
                param.Add("@bitFlActivo", objDatos.bitFlActivo);
                param.Add("@intIdUsuario", intIdUsuario);
                param.Add("@intTipoOperacion", intTipoOperacion);//1: insert, 2: update
                if (intTipoOperacion == 1)
                {
                    param.Add("@intIdGrupo", 0);
                }
                else
                {
                    param.Add("@intIdGrupo", objDatos.intIdGrupo);
                }
                //Parámetros de Salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");
                AsignarParametros(cmd, param);
                int result = cmd.ExecuteNonQuery();
                intIdGrupoOut = Convert.ToInt32(cmd.Parameters["@intIdGrupo"].Value.ToString());
                intResult = Convert.ToInt32(cmd.Parameters["@intResult"].Value.ToString());
                strMsjDB = cmd.Parameters["@strMsjDB"].Value.ToString();
                strMsjUsuario = cmd.Parameters["@strMsjUsuario"].Value.ToString();
            }
            return intIdGrupoOut;
        }

        public bool EliminarGrup(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            bool exito = false;

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGGRUPO_D02", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdUsuario", intIdUsuario);

                param.Add("@intIdGrupo", intIdGrupo);
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

        public List<Grupo> ConsultarDetalleGrupoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdGrupo, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<Grupo> listDetCar = new List<Grupo>();
            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGGRUPO_Q01", cn);//TSP_TGGRUPO_Q07
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = timeSQL;//22.04.2021
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdSesion", intIdSesion);
                param.Add("@intIdMenu", intIdMenu);
                param.Add("@intIdSoft", intIdSoft);
                param.Add("@intIdGrupo", intIdGrupo);
                //salida
                param.Add("@intResult", 0);
                param.Add("@strMsjDB", "");
                param.Add("@strMsjUsuario", "");

                AsignarParametros(cmd, param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        Grupo obj = new Grupo();
                        obj.intIdGrupo = reader.GetInt32(0);
                        obj.strCoGrupo = reader.GetString(1);
                        obj.strDesGrupo = reader.GetString(2);
                        obj.intIdUniOrg = reader.GetInt32(3);
                        obj.strGrupoCampo1 = reader.GetString(4);
                        obj.strGrupoCampo2 = reader.GetString(5);
                        obj.strGrupoCampo3 = reader.GetString(6);
                        obj.strGrupoCampo4 = reader.GetString(7);
                        obj.strGrupoCampo5 = reader.GetString(8);
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
