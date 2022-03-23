using Dominio.Entidades;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CBX_ServiceSISCOP
{
    /// <summary>
    /// Descripción breve de AccesoMovil
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class AccesoMovil : System.Web.Services.WebService
    {

        [WebMethod]
        public List<RstaValidPersonalEntity> ValidarPersonaAcceso(string strNumDocumento, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strTipoAcceso)
        {
            try
            {
                return new AccesoMovilBL().ValidarPersonaAcceso(strNumDocumento, dtHoraMarca, dtFechaMarca, strTerminal, strTipoAcceso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<RstaInsertMarcaEntity> InsertarMarcaAcceso(string strNumDocumento, string strTipoAcceso, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strFotoAcceso, string strReporte_dir, string strDireccion)
        {
            try
            {
                return new AccesoMovilBL().InsertarMarcaAcceso(strNumDocumento, strTipoAcceso, dtHoraMarca, dtFechaMarca, strTerminal, strFotoAcceso, strReporte_dir, strDireccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<RstaInsertImgEntity> InsertarImagenAcceso(int intIdAsistencia, string strFotoAcceso)
        {
            try
            {
                return new AccesoMovilBL().InsertarImagenAcceso(intIdAsistencia, strFotoAcceso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<RstaListMarcaEntity> ListarMarcasAcceso(string strTerminal, string strFotocheck, string strFecha)
        {
            try
            {
                return new AccesoMovilBL().ListarMarcasAcceso(strTerminal, strFotocheck, strFecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<RstaListaCoordEntity> ListarCoordAcceso(int intIdPersonal)
        {
            try
            {
                return new AccesoMovilBL().ListarCoordAcceso(intIdPersonal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string CargarImagenes(string strNomArchivo, string strBytesImagen)
        {
            //(string strNomArchivo, string strBoleto, string strBytesImagen)
            //SqlDataReader reader;

            try
            {

                //************************ GUARDAR LA IMAGEN EN LA BD
                //byte[] imgPrueba = File.ReadAllBytes(@"C:\temp\Archivos\IMG_20191202141839.jpg");
                //strNomArchivo = "01-654988_05122019.jpg";
                //strBoleto = "01-654988";

                //Conex.Open();
                //using (SqlCommand cmd = new SqlCommand("TSP_TMImagen_I001"))
                //{
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.Add("strNomImagen", SqlDbType.VarChar).Value = strNomArchivo;
                //    cmd.Parameters.Add("strNumBoleto", SqlDbType.VarChar).Value = strBoleto;
                //    cmd.Parameters.Add("strImagen", SqlDbType.Image).Value = imgPrueba;
                //    cmd.Connection = Conex;
                //    reader = cmd.ExecuteReader();
                //    cmd.Dispose();
                //    reader.Close();
                //}
                //Conex.Close();

                ////******************************* INICIO DE PRUEBA
                //Bitmap bmP = null;
                //byte[] img = File.ReadAllBytes(@"C:\temp\IncaRail.png");
                //MemoryStream msf = new MemoryStream(img);
                //bmP = new Bitmap(msf);
                //bmP.Save(@"C:\temp\Archivos\prueba.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                ////******************************* FIN DE PRUEBA
                ///********************************************************************************************************
                string strMensaje = "";
                DirectoryInfo objDirectorio = null;
                //string strRutaArchivos ="D:/Foto_pruebas/";
                string strRutaArchivos = ConfigurationManager.AppSettings["RutaArchivos"];
                objDirectorio = new DirectoryInfo(strRutaArchivos);

                //Se crea una ruta en la ruta del Web Service.
                if (!objDirectorio.Exists)
                {
                    //if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/Imagenes_Boletos/")))
                    //{
                    System.IO.Directory.CreateDirectory(strRutaArchivos);
                    //}
                    strMensaje = "La ruta '" + strRutaArchivos + "' del servidor para guardar los archivos no existe." +
                                    " Se ha creado una ruta por defecto.";
                }

                Bitmap bm = null;
                //UTF8Encoding encoding = new UTF8Encoding();
                byte[] imagen = Convert.FromBase64String(strBytesImagen); //System.Text.Encoding.UTF8.GetBytes(imagenFoto);

                //byte[] imagen = Encoding.UTF8.GetBytes(imagenFoto);
                //byte[] imagen = encoding.GetBytes(imagenFoto); //File.ReadAllBytes(strNomArchivo);

                ////UTF8Encoding enc = new UTF8Encoding();
                //// string str = encoding.get(imagenFoto);

                MemoryStream ms = new MemoryStream(imagen);
                bm = new Bitmap(ms);
                bm.Save(strRutaArchivos + strNomArchivo + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                //************************ GUARDAR LA IMAGEN EN LA BD
                //byte[] imgPrueba = File.ReadAllBytes(@"C:\temp\Archivos\IMG_20191202125442.jpg");
                //strNomArchivo = "01-654988_05122019.jpg";
                //strBoleto = "01-654988";
                ///****************SP***************************
                //Conex.Open();
                //using (SqlCommand cmd = new SqlCommand("TSP_TMImagen_I001"))
                //{
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.Add("strNomImagen", SqlDbType.VarChar).Value = strNomArchivo;
                //    cmd.Parameters.Add("strNumBoleto", SqlDbType.VarChar).Value = strBoleto;
                //    cmd.Parameters.Add("strImagen", SqlDbType.Image).Value = imagen;
                //    cmd.Connection = Conex;
                //    reader = cmd.ExecuteReader();
                //    cmd.Dispose();
                //    reader.Close();
                //}

                //Conex.Close();
                ///************************************************************
                return strMensaje;
                //****************************************************************************************
            }
            catch (Exception ex)
            {
                return ex.Message.ToString() + " - Mensaje del Web Service";
            }

        }

        [WebMethod]
        public List<RstaConexion> ValidarConexionAcceso()
        {
            try
            {
                return new AccesoMovilBL().ValidarConexionAcceso();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //08012021

        [WebMethod]
        public List<RstaListConceptos> ListarConceptosAcceso(string strFotocheck, string strfiltro_fech, string strSerie)
        {
            try
            {
                return new AccesoMovilBL().ListarConceptosAcceso(strFotocheck, strfiltro_fech, strSerie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<RstaListComboConcepto> ListarComboConceptosAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            try
            {
                return new AccesoMovilBL().ListarComboConceptosAcceso(strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<RstaListComboSustenta> ListarComboSustentaAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            try
            {
                return new AccesoMovilBL().ListarComboSustentaAcceso(strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<RstaInsertConcepto> InsertaConceptoAcceso(string strTerminal, string strFotocheck, string strDeConcepto, string strFecIni, string strFecFin,
                            string strHoraIni, string strHoraFin, string strObs, int intEspeValorada, int bitSustentado, string strCitt, string strEmitEn, string strEmitPor, int intDiaSgtIni, int intDiaSgtFin, string strNomFoto)
        {
            try
            {
                return new AccesoMovilBL().InsertaConceptoAcceso(strTerminal, strFotocheck, strDeConcepto, strFecIni, strFecFin,
                            strHoraIni, strHoraFin, strObs, intEspeValorada, bitSustentado, strCitt, strEmitEn, strEmitPor, intDiaSgtIni, intDiaSgtFin, strNomFoto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string CargarImagenesPermiso(string strNomArchivo, string strBytesImagen)
        {
            //(string strNomArchivo, string strBoleto, string strBytesImagen)
            //SqlDataReader reader;

            try
            {

                //************************ GUARDAR LA IMAGEN EN LA BD
                //byte[] imgPrueba = File.ReadAllBytes(@"C:\temp\Archivos\IMG_20191202141839.jpg");
                //strNomArchivo = "01-654988_05122019.jpg";
                //strBoleto = "01-654988";

                //Conex.Open();
                //using (SqlCommand cmd = new SqlCommand("TSP_TMImagen_I001"))
                //{
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.Add("strNomImagen", SqlDbType.VarChar).Value = strNomArchivo;
                //    cmd.Parameters.Add("strNumBoleto", SqlDbType.VarChar).Value = strBoleto;
                //    cmd.Parameters.Add("strImagen", SqlDbType.Image).Value = imgPrueba;
                //    cmd.Connection = Conex;
                //    reader = cmd.ExecuteReader();
                //    cmd.Dispose();
                //    reader.Close();
                //}
                //Conex.Close();

                ////******************************* INICIO DE PRUEBA
                //Bitmap bmP = null;
                //byte[] img = File.ReadAllBytes(@"C:\temp\IncaRail.png");
                //MemoryStream msf = new MemoryStream(img);
                //bmP = new Bitmap(msf);
                //bmP.Save(@"C:\temp\Archivos\prueba.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                ////******************************* FIN DE PRUEBA
                ///********************************************************************************************************
                string strMensaje = "";
                DirectoryInfo objDirectorio = null;
                //string strRutaArchivos ="D:/Foto_pruebas/";
                string strRutaArchivos = ConfigurationManager.AppSettings["RutaFotoPermiso"];
                objDirectorio = new DirectoryInfo(strRutaArchivos);

                //Se crea una ruta en la ruta del Web Service.
                if (!objDirectorio.Exists)
                {
                    //if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/Imagenes_Boletos/")))
                    //{
                    System.IO.Directory.CreateDirectory(strRutaArchivos);
                    //}
                    strMensaje = "La ruta '" + strRutaArchivos + "' del servidor para guardar los archivos no existe." +
                                    " Se ha creado una ruta por defecto.";
                }

                Bitmap bm = null;
                //UTF8Encoding encoding = new UTF8Encoding();
                byte[] imagen = Convert.FromBase64String(strBytesImagen); //System.Text.Encoding.UTF8.GetBytes(imagenFoto);

                //byte[] imagen = Encoding.UTF8.GetBytes(imagenFoto);
                //byte[] imagen = encoding.GetBytes(imagenFoto); //File.ReadAllBytes(strNomArchivo);

                ////UTF8Encoding enc = new UTF8Encoding();
                //// string str = encoding.get(imagenFoto);

                MemoryStream ms = new MemoryStream(imagen);
                bm = new Bitmap(ms);
                bm.Save(strRutaArchivos + strNomArchivo + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                //************************ GUARDAR LA IMAGEN EN LA BD
                //byte[] imgPrueba = File.ReadAllBytes(@"C:\temp\Archivos\IMG_20191202125442.jpg");
                //strNomArchivo = "01-654988_05122019.jpg";
                //strBoleto = "01-654988";
                ///****************SP***************************
                //Conex.Open();
                //using (SqlCommand cmd = new SqlCommand("TSP_TMImagen_I001"))
                //{
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.Add("strNomImagen", SqlDbType.VarChar).Value = strNomArchivo;
                //    cmd.Parameters.Add("strNumBoleto", SqlDbType.VarChar).Value = strBoleto;
                //    cmd.Parameters.Add("strImagen", SqlDbType.Image).Value = imagen;
                //    cmd.Connection = Conex;
                //    reader = cmd.ExecuteReader();
                //    cmd.Dispose();
                //    reader.Close();
                //}

                //Conex.Close();
                ///************************************************************
                return strMensaje;
                //****************************************************************************************
            }
            catch (Exception ex)
            {
                return ex.Message.ToString() + " - Mensaje del Web Service";
            }

        }

        [WebMethod]
        public List<RstaDeleteConcepto> EliminarPapeletaAcceso(int intIdPerConcepto)
        {
            try
            {
                return new AccesoMovilBL().EliminarPapeletaAcceso(intIdPerConcepto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
