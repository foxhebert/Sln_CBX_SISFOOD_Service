using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace Infraestructura.Data.SqlServer
{
    public class AccesoMovilDAO : Conexion
    {
        public List<RstaValidPersonalEntity> ValidarPersonaAcceso(string strNumDocumento, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strTipoAcceso)
        {
            List<RstaValidPersonalEntity> lista = new List<RstaValidPersonalEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPERSONAL_MOVIL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strNumDocumento", strNumDocumento);
                param.Add("@dtHoraMarca", dtHoraMarca);
                param.Add("@dtFechaMarca", dtFechaMarca);
                param.Add("@strTerminal", strTerminal);
                param.Add("@strTipoAcceso", strTipoAcceso);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaValidPersonalEntity obj = new RstaValidPersonalEntity();

                    obj.intEstado = reader.GetInt32(0);
                    obj.strMensaje = reader.GetString(1);
                    obj.strNombres = reader.GetString(2);
                    obj.strApePaterno = reader.GetString(3);
                    obj.strApeMaterno = reader.GetString(4);
                    obj.strIdPersonal = reader.GetString(5);
                    //18012021
                    obj.bitFoto = reader.GetInt32(6);

                    lista.Add(obj);

                }
                reader.Close();
            }
            return lista;
        }

        public List<RstaInsertMarcaEntity> InsertarMarcaAcceso(string strNumDocumento, string strTipoAcceso, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strFotoAcceso, string strReporte_dir, string strDireccion)
        {
            List<RstaInsertMarcaEntity> lista = new List<RstaInsertMarcaEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_MOVIL_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                //byte[] byteFoto = Encoding.ASCII.GetBytes(strFotoAcceso);
                //cmd.Parameters.Add("IMAGEN", SqlDbType.VarBinary).Value = imagen;

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strNumDocumento", strNumDocumento);
                param.Add("@strTipoAcceso", strTipoAcceso);
                param.Add("@dtHoraMarca", dtHoraMarca);
                param.Add("@dtFechaMarca", dtFechaMarca);
                param.Add("@strTerminal", strTerminal);
                param.Add("@strFotoAcceso", strFotoAcceso);
                param.Add("@strReporte_dir", strReporte_dir);
                param.Add("@strDireccion", strDireccion);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaInsertMarcaEntity obj = new RstaInsertMarcaEntity();

                    obj.strMensaje = reader.GetString(0);
                    obj.iEstado = reader.GetInt32(1);
                    obj.idAsistencia = reader.GetInt32(2);

                    lista.Add(obj);

                }
                reader.Close();
            }
            return lista;
        }

        public List<RstaInsertImgEntity> InsertarImagenAcceso(int intIdAsistencia, string strFotoAcceso)
        {
            List<RstaInsertImgEntity> lista = new List<RstaInsertImgEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TAASISTENCIA_MOVIL_U01", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                string strRutaArchivos = ConfigurationManager.AppSettings["RutaArchivos"];
                byte[] imgPrueba = File.ReadAllBytes(strRutaArchivos + strFotoAcceso + ".jpg");
                string rutaFota = strRutaArchivos + strFotoAcceso + ".jpg";

                //************
                string encoded = Convert.ToBase64String(imgPrueba);
                //************

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdAsistencia", intIdAsistencia);
                param.Add("@strFotoAcceso", imgPrueba);
                param.Add("@strRutaFoto", rutaFota);

                param.Add("@strFotoAcceso2", encoded);

                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaInsertImgEntity obj = new RstaInsertImgEntity();

                    obj.strMensaje = reader.GetString(0);
                    obj.intEstado = reader.GetInt32(1);

                    lista.Add(obj);

                }
                reader.Close();
            }
            return lista;
        }

        public List<RstaListMarcaEntity> ListarMarcasAcceso(string strTerminal, string strFotocheck, string strFecha)
        {
            List<RstaListMarcaEntity> lista = new List<RstaListMarcaEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTMARCA_MOVIL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strTerminal", strTerminal);
                param.Add("@strFotocheck", strFotocheck);
                param.Add("@fecha_filtro", strFecha);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();
                //var dataTable = new DataTable();
                //dataTable.Load(reader);

                //byte[] a = (byte[])dataTable.Rows[0]["foto"];
                ////byte[] a = Encoding.ASCII.GetBytes(dataTable.Rows[0]["foto"].ToString());

                //string strFoto = Convert.ToBase64String(a, 0, a.Length,
                //                Base64FormattingOptions.InsertLineBreaks);
                while (reader.Read())//reader.Read()
                {
                    RstaListMarcaEntity obj = new RstaListMarcaEntity();
                    // byte[] yaps = reader.GetSqlBytes(8).Buffer; ;

                    //byte[] b = source.ToArray();
                    //MemoryStream ms = new MemoryStream(b);
                    //Image img = Image.FromStream(ms);
                    //return img.Source.ToString();

                    //string stringFromSQL = "0x6100730064006600";
                    //List<byte> byteList = new List<byte>();

                    //string hexPart = reader.GetString(8).Substring(2);
                    //for (int i = 0; i < hexPart.Length / 2; i++)
                    //{
                    //    string hexNumber = hexPart.Substring(i * 2, 2);
                    //    byteList.Add((byte)Convert.ToInt32(hexNumber, 16));
                    //}

                    //byte[] original = byteList.ToArray();

                    obj.idpersonal = reader.GetString(0);
                    obj.fotocheck = reader.GetString(1);
                    obj.tipo_acceso = reader.GetString(2);
                    obj.Num_marcador = reader.GetString(3);
                    obj.hora = reader.GetString(4);
                    obj.fecha = reader.GetString(5);
                    obj.personal = reader.GetString(6);
                    obj.estado = reader.GetString(7);
                    obj.foto = reader.GetString(8);
                    //obj.foto = yaps;
                    //obj.fotoConverted = strFoto;

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public List<RstaListaCoordEntity> ListarCoordAcceso(int intIdPersonal)
        {
            List<RstaListaCoordEntity> lista = new List<RstaListaCoordEntity>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TGLISTCOORD_MOVIL_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdPersonal", intIdPersonal);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaListaCoordEntity obj = new RstaListaCoordEntity();

                    obj.idPersonal = reader.GetInt32(0);
                    obj.bitFlGeoArea = reader.GetInt32(1);
                    obj.MINI = reader.GetDecimal(2);
                    obj.MAXI = reader.GetDecimal(3);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaConexion> ValidarConexionAcceso()
        {
            List<RstaConexion> lista = new List<RstaConexion>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_VALIDAR_CONEXION_Movil", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaConexion obj = new RstaConexion();

                    obj.estado = reader.GetString(0);
                    obj.mensaje = reader.GetString(1);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        //08012021

        public List<RstaListConceptos> ListarConceptosAcceso(string strFotocheck, string strfiltro_fech, string strSerie)
        {
            List<RstaListConceptos> lista = new List<RstaListConceptos>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_Movil_Q01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strFoctocheck", strFotocheck);
                param.Add("@filtro_fech", strfiltro_fech);
                param.Add("@strSerie", strSerie);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaListConceptos obj = new RstaListConceptos();

                    obj.intIdPerConcepto = reader.GetInt32(0);
                    obj.strEmpleado = reader.GetString(1);
                    obj.strEmpleadoLista = reader.GetString(2);
                    obj.rangoHora = reader.GetString(3);
                    obj.strCoConcepto = reader.GetString(4);
                    obj.strDesConcepto = reader.GetString(5);
                    obj.dttFecha = reader.GetString(6);
                    obj.strDeTipo = reader.GetString(7);
                    obj.intIdConcepto = reader.GetInt32(8);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaListComboConcepto> ListarComboConceptosAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            List<RstaListComboConcepto> lista = new List<RstaListComboConcepto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Movil_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strEntidad", strEntidad);
                param.Add("@intIdFiltroGrupo", intIdFiltroGrupo);
                param.Add("@strGrupo", strGrupo);
                param.Add("@strSubGrupo", strSubGrupo);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaListComboConcepto obj = new RstaListComboConcepto();

                    obj.intIdConcepto = reader.GetInt32(0);
                    obj.strDesConcepto = reader.GetString(1);
                    obj.strCoTipo = reader.GetString(2);
                    obj.bitFlDescontable = reader.GetInt32(3);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaListComboSustenta> ListarComboSustentaAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            List<RstaListComboSustenta> lista = new List<RstaListComboSustenta>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGLISTAR_COMBOS_Movil_Q00", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strEntidad", strEntidad);
                param.Add("@intIdFiltroGrupo", intIdFiltroGrupo);
                param.Add("@strGrupo", strGrupo);
                param.Add("@strSubGrupo", strSubGrupo);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaListComboSustenta obj = new RstaListComboSustenta();

                    obj.intIdEntidad = reader.GetInt32(0);
                    obj.strDeEntidad = reader.GetString(1);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaInsertConcepto> InsertaConceptoAcceso(string strTerminal, string strFotocheck, string strDeConcepto, string strFecIni, string strFecFin,
                            string strHoraIni, string strHoraFin, string strObs, int intEspeValorada, int bitSustentado, string strCitt, string strEmitEn, string strEmitPor, int intDiaSgtIni, int intDiaSgtFin, string strNomFoto)
        {
            List<RstaInsertConcepto> lista = new List<RstaInsertConcepto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET__Movil_I01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                string rutaFota = "";
                if (strNomFoto != "")
                {
                    string strRutaArchivos = ConfigurationManager.AppSettings["RutaFotoPermiso"];
                    rutaFota = strRutaArchivos;
                    //string strFotoPermiso = strNomFoto + ".jpg";
                }


                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@strTerminal", strTerminal);
                param.Add("@strFotocheck", strFotocheck);
                param.Add("@strDeConcepto", strDeConcepto);
                param.Add("@strFecIni", strFecIni);
                param.Add("@strFecFin", strFecFin);
                param.Add("@strHoraIni", strHoraIni);
                param.Add("@strHoraFin", strHoraFin);
                param.Add("@strObs", strObs);
                param.Add("@intEspeValorada", intEspeValorada);
                param.Add("@bitSustentado", bitSustentado);
                param.Add("@strCitt", strCitt);
                param.Add("@strEmitEn", strEmitEn);
                param.Add("@strEmitPor", strEmitPor);
                param.Add("@intDiaSgtIni", intDiaSgtIni);
                param.Add("@intDiaSgtFin", intDiaSgtFin);
                param.Add("@strNomFoto", strNomFoto);
                param.Add("@strRutaFoto", rutaFota);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaInsertConcepto obj = new RstaInsertConcepto();

                    obj.strRespuesta = reader.GetString(0);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

        public List<RstaDeleteConcepto> EliminarPapeletaAcceso(int intIdPerConcepto)
        {
            List<RstaDeleteConcepto> lista = new List<RstaDeleteConcepto>();

            using (SqlConnection cn = new SqlConnection(cadCnx))
            {
                SqlCommand cmd = new SqlCommand("TSP_TGPER_CONCEPTO_DET_Movil_D01", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@intIdPerConcepto", intIdPerConcepto);
                AsignarParametros(cmd, param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RstaDeleteConcepto obj = new RstaDeleteConcepto();

                    obj.strRespuesta = reader.GetString(0);

                    lista.Add(obj);

                }
                reader.Close();

            }
            return lista;
        }

    }
}
