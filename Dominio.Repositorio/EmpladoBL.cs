using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Configuration;
using ExcelDataReader;
using System.Globalization;

namespace Dominio.Repositorio
{
    public class EmpladoBL
    {
        private EmpleadoDAO objDao = new EmpleadoDAO();
        private UsuarioDAO objUsuario = new UsuarioDAO();


        #region Pagina Principal - Dashboard
        //5.1
        public List<TSPTAASISTENCIA> ListarAsistenciaDiaria(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<TSPTAASISTENCIA> listObj = new List<TSPTAASISTENCIA>();

            try
            {
                listObj = objDao.ListarAsistenciaDiaria(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarAsistenciaDiaria] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarAsistenciaDiaria)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarAsistenciaDiaria)");
            }
            return listObj;
        }
        //5.2
        public List<DiaAusen> ListarDiasAusencia(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<DiaAusen> listObj = new List<DiaAusen>();
            try
            {
                listObj = objDao.ListarDiasAusencia(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarDiasAusencia] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarDiasAusencia)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarDiasAusencia)");
            }
            return listObj;
        }
        //5.3
        public List<HomeCabe> ListarCabeceras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HomeCabe> listObj = new List<HomeCabe>();
            try
            {
                listObj = objDao.ListarCabeceras(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCabeceras] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCabeceras)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarCabeceras)");
            }
            return listObj;
        }
        //5.4
        public List<HorasDesc> ListarHorasDescontadas(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HorasDesc> listObj = new List<HorasDesc>();
            try
            {
                listObj = objDao.ListarHorasDescontadas(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarHorasDescontadas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarHorasDescontadas)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarHorasDescontadas)");
            }
            return listObj;
        }
        //5.5
        public List<HorasDesc> ListarHorasExtras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<HorasDesc> listObj = new List<HorasDesc>();
            try
            {
                listObj = objDao.ListarHorasExtras(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarHorasExtras] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarHorasExtras)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarHorasExtras)");
            }
            return listObj;
        }

        #endregion

        #region Empleado
        //5.6
        public List<TGPER_CON_DET> ListaAsusencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario)
        {
            List<TGPER_CON_DET> lista = new List<TGPER_CON_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListaAsusencias(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListaAsusencias] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListaAsusencias)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListaAsusencias)");
            }
            return lista;
        }
        //5.7
        public List<TGPER_CON_DET> ListaAsistencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario)
        {
            List<TGPER_CON_DET> lista = new List<TGPER_CON_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListaAsistencias(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListaAsistencias] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListaAsistencias)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListaAsistencias)");
            }
            return lista;
        }
        //5.8
        public List<TGPER_RESP> ListaPersonalResponsabilidad(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario)
        {
            List<TGPER_RESP> lista = new List<TGPER_RESP>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListaPersonalResponsabilidad(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, fechaInicio, fechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListaPersonalResponsabilidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListaPersonalResponsabilidad)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListaPersonalResponsabilidad)");
            }
            return lista;
        }
        //5.9
        public List<PersonalData> ListarPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, int intIdUniOrg, string strfilter, string dttfiltrofch1, string dttfiltrofch2, int BitFecha, ref string strMsjUsuario)//modificado
        {
            List<PersonalData> lista = new List<PersonalData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarPersonal(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, intIdUniOrg, strfilter, dttfiltrofch1, dttfiltrofch2, BitFecha, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarPersonal)");
            }
            return lista;
        }
        //5.10 - 6.6
        public List<TGTipoEN> ListarCombos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCombos(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCombos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCombos)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarCombos)");
            }
            return lista;
        }
        //5.11
        public List<TGTipoEN> ListarComboJerar(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            List<TGTipoEN> lista = new List<TGTipoEN>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarComboJerar(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarComboJerar] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarComboJerar)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarComboJerar)");
            }
            return lista;
        }
        //5.12
        public List<Personal> ObtenerEmpleadoPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {
            List<Personal> lista = new List<Personal>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerEmpleadoPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerEmpleadoPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerEmpleadoPorsuPK)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ObtenerEmpleadoPorsuPK)");
            }
            return lista;
        }
        //5.13
        public List<ValidarIdentidad_ENT> ValidarDocIdentidad(int intIdSesion, int intIdMenu, int intIdSoft, int intIdTipDoc, string strNumDoc, ref string strMsjUsuario)
        {

            List<ValidarIdentidad_ENT> lista = new List<ValidarIdentidad_ENT>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ValidarDocIdentidad(intIdSesion, intIdMenu, intIdSoft, intIdTipDoc, strNumDoc, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ValidarDocIdentidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ValidarDocIdentidad)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ValidarDocIdentidad)");
            }
            return lista;

          
        }
        //5.14
        public Dictionary<string, string> ReenviarCorreo(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {

            Dictionary<string, string> obj = new Dictionary<string, string>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                Personal empleado = new Personal();
                empleado = objDao.ObtenerEmpleadoPorsuPK(objSession.intIdSesion, objSession.intIdMenu, objSession.intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario).First();
                if (!empleado.bitActivarUsuario)
                {
                    obj.Add("activo", "no");
                }
                else
                {
                    obj.Add("activo", "si");

                    //Codificar contraseña actual para validacion
                    byte[] byt = System.Text.Encoding.UTF8.GetBytes("@" + empleado.strApePaterno.Substring(0, 1).ToUpper() + empleado.strApePaterno.Substring(1).ToLower() + empleado.strNumDoc.Trim());
                    string contrasena = Convert.ToBase64String(byt);

                    Dictionary<string, string> objeto = new Dictionary<string, string>();
                    objeto = objDao.ActivarUsuario(objSession, intIdPersonal, contrasena, ref intResult, ref strMsjDB, ref strMsjUsuario);

                    if (objeto.Count == 0)
                    {
                        obj.Add("mensaje", "No cuenta con correo");

                        return obj;
                    }
                    CorreoEmp objCor = new CorreoEmp();
                    objCor.intIdPersonal = intIdPersonal;
                    objCor.strNomCompleto = objeto["nombres"];
                    objCor.strCorreo = objeto["correo"];
                    objCor.strNumDocNue = objeto["numeroDoc"];

                    reenviarCorreoEmpleado(objSession, objCor, 2, false, objeto["contraOut"], ref intResult, ref strMsjDB, ref strMsjUsuario);
                    obj.Add("mensaje", strMsjUsuario);
                }


                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ReenviarCorreo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ReenviarCorreo)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ReenviarCorreo)");
            }
            return obj;
        }
        //5.15
        public string ActivarUsuario(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {
            string salida = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                Personal empleado = new Personal();
                empleado = objDao.ObtenerEmpleadoPorsuPK(objSession.intIdSesion, objSession.intIdMenu, objSession.intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario).First();
                //Codificar contraseña actual para validacion
                byte[] byt = System.Text.Encoding.UTF8.GetBytes("@" + empleado.strApePaterno.Substring(0, 1).ToUpper() + empleado.strApePaterno.Substring(1).ToLower() + empleado.strNumDoc.Trim());
                string contrasena = Convert.ToBase64String(byt);

                Dictionary<string, string> objeto = new Dictionary<string, string>();
                objeto = objDao.ActivarUsuario(objSession, intIdPersonal, contrasena, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (objeto.Count == 0)
                {
                    salida = "Se activo el usuario, Pero no cuenta con correo";
                    return salida;
                }

                CorreoEmp obj = new CorreoEmp();
                obj.intIdPersonal = intIdPersonal;
                obj.strNomCompleto = objeto["nombres"];
                obj.strCorreo = objeto["correo"];
                obj.strNumDocNue = objeto["numeroDoc"];

                reenviarCorreoEmpleado(objSession, obj, 2, false, objeto["contraOut"], ref intResult, ref strMsjDB, ref strMsjUsuario);
                salida = strMsjUsuario;

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActivarUsuario] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActivarUsuario)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ActivarUsuario)");
            }
            return salida;
        }
        //5.16
        public string ValidarEmail(Session_Movi objSession, string numDoc, string correo, ref string strMsjUsuario)
        {
            string salida = "";
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                salida = objDao.ValidarEmail(objSession, numDoc, correo, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (!salida.Equals("no"))
                {
                    CorreoEmp obj = new CorreoEmp();
                    obj.intIdPersonal = Int32.Parse(salida);
                    obj.strCorreo = correo;
                    
                    enviarCorreoValidacion(objSession, obj, ref intResult, ref strMsjDB, ref strMsjUsuario);
                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ValidarEmail] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ValidarEmail)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ValidarEmail)");
            }
            return salida;
        }
        //5.17
        public bool EliminarEmpleado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdPersonal, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool tudobem = false;

                tudobem = objDao.EliminarEmpleado(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarEmpleado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarEmpleado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (EliminarEmpleado)");
            }
        }
        //5.18
        public bool ActualizarEmpleado_T(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos, int intIdUsuario, int intIdUsuarModif, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";

                intResult = objDao.UEmpleado_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaDetallesCorreos, listaDetallesTelefonos, intIdUsuario, intIdUsuarModif, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarEmpleado_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[ActualizarEmpleado_T] => Respuesta del Procedimiento : " + Msj);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                else
                {
                    tudobem = true;
                }
                return tudobem;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ActualizarEmpleado_T)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarEmpleado_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ActualizarEmpleado_T)");
            }
        }
        //5.19
        public bool RegistrarOActualizarEmpleado_T(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, MarcaDni ObjMarcaConDni, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos,
            List<TGPERRESPDET> listaDetallesResponsabilidad, List<TGPERMARCDET> listaDetallesMarcadores, List<TGPERCOOR> listaCoor, int intIdUsuario, int intIdUsuarModif, bool activaUsuario, bool desactivaUsuario, bool activarAdmin,
            int intTipoOperacion, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";
                int idPersonal = 0;

                Session_Movi objSession = new Session_Movi();
                objSession.intIdMenu = intIdMenu;
                objSession.intIdSesion = (int)intIdSesion;
                objSession.intIdSoft = intIdSoft;
                objSession.intIdUsuario = 1;

                CorreoEmp obj = new CorreoEmp();
                obj.strNomCompleto = objDatos.strNombres;
                obj.strCorreo = listaDetallesCorreos.Find(x => x.bitFlPrincipal == true).strCorreo;
                obj.strNumDocNue = objDatos.strNumDoc;

                idPersonal = objDao.IUEmpleado_T(intIdSesion, intIdMenu, intIdSoft, objDatos, ObjMarcaConDni, listaDetallesCorreos, listaDetallesTelefonos, listaDetallesResponsabilidad, listaDetallesMarcadores, listaCoor, intIdUsuario, intIdUsuarModif, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (idPersonal > 0 && intResult > 0)
                {
                    if (activaUsuario || desactivaUsuario) //RHGM
                    {
                        obj.intIdPersonal = idPersonal;
                        enviarCorreoEmpleado(objSession, obj, intTipoOperacion, desactivaUsuario, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    }
                    if (!activaUsuario && activarAdmin)
                    {
                        obj.intIdPersonal = idPersonal;
                        enviarCorreoActivarAdmin(objSession, obj, intTipoOperacion, desactivaUsuario, "", ref intResult, ref strMsjDB, ref strMsjUsuario);
                    }
                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RegistrarOActualizarEmpleado_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[RegistrarOActualizarEmpleado_T] => Respuesta de la clase de Datos: " + Msj);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                else if(intResult == 3)
                {
                    //strMsjUsuario = "El Empleado se ha insertado, pero no se ha enviado el Activar Usuario al correo.";
                    Log.AlmacenarLogMensaje("El Empleado se ha insertado, pero no se ha enviado el Activar Usuario al correo.");
                    strMsjUsuario = "";
                    tudobem = true;
                }

                else
                {
                    tudobem = true;
                }
                return tudobem;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (RegistrarOActualizarEmpleado_T)");
            //}//Comentado 21.04.2021 solicitado por ER
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RegistrarOActualizarEmpleado_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (RegistrarOActualizarEmpleado_T)");
            }
        }
        //5.20
        public List<TGPERMARCDET> ListarMarcadoresPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPerMarc, ref string strMsjUsuario)
        {

            List<TGPERMARCDET> lista = new List<TGPERMARCDET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarMarcadoresPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPerMarc, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarMarcadoresPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarMarcadoresPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarMarcadoresPersonal)");
            }
            return lista;


        }
        //5.21
        public List<TGPERCORRDET> ListarCorreosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {

            List<TGPERCORRDET> lista = new List<TGPERCORRDET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCorreosPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCorreosPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCorreosPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarCorreosPersonal)");
            }
            return lista;


        }
        //5.22
        public List<TGPERTELEFDET> ListarTelefonosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {

            List<TGPERTELEFDET> lista = new List<TGPERTELEFDET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTelefonosPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTelefonosPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTelefonosPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarTelefonosPersonal)");
            }
            return lista;


        }
        //5.23
        public List<TGPERCOOR> listarCoordenadas(int intIdPersonal, ref string strMsjUsuario)
        {
            List<TGPERCOOR> lista = new List<TGPERCOOR>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.listarCoordenadas(intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[listarCoordenadas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (listarCoordenadas)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (listarCoordenadas)");
            }
            return lista;
        }
        //5.24
        public List<TGPERRESPDET> ListarResponsabilidadPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {

            List<TGPERRESPDET> lista = new List<TGPERRESPDET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarResponsabilidadPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[.ListarResponsabilidadPersonal] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (.ListarResponsabilidadPersonal)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (.ListarResponsabilidadPersonal)");
            }
            return lista;


        }

        #endregion Empleado

        #region MiFicha
        //2.1
        public List<TSPTAASISTENCIA> ObtenerAsistenciaXFecha(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            List<TSPTAASISTENCIA> lista = new List<TSPTAASISTENCIA>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerAsistenciaXFecha(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerAsistenciaXFecha] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerAsistenciaXFecha)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ObtenerAsistenciaXFecha)");
            }
            return lista;
        }
        #endregion

        #region MarcaEmpleadoDni
        //5.25
        public List<MarcaDni> ObtenerEmpleadoConMarcaDNI(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {
            List<MarcaDni> lista = new List<MarcaDni>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerEmpleadoConMarcaDNI(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerEmpleadoConMarcaDNI] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerEmpleadoConMarcaDNI)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ObtenerEmpleadoConMarcaDNI)");
            }
            return lista;
        }

        #endregion MarcaEmpleadoDni

        #region Empleado Masivo
        //5.33
        public List<EmpleadoMasivo> ListGrupoLiquidacion(Session_Movi session, EmpleadoMasivo lista, ref string strMsjUsuario)
        {
            List<EmpleadoMasivo> listObj = new List<EmpleadoMasivo>();

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                listObj = objDao.ListGrupoLiquidacion(session, lista, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListGrupoLiquidacion] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListGrupoLiquidacion)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListGrupoLiquidacion)");
            }
            return listObj;
        }
        //5.34
        public List<EmpleadoMasivo> ImportMasivoEmpleado(Session_Movi session, string nombreExcel, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario)
        {
            List<EmpleadoMasivo> listObj = new List<EmpleadoMasivo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                string RutaMasivoEmpleado = rutaDirectorioExcel;
                bool existe = VerificarRuta(RutaMasivoEmpleado);

                int validarExcel = 0;

                if (existe == true)
                {
                    if (File.Exists(RutaMasivoEmpleado + "\\" + nombreExcel))
                    {  
                        //DataTable dt = ReadExcelMasivoEmpleado(nombreExcel, idProceso, RutaMasivoEmpleado, "empleado");
                        DataTable dt = ReadArchivoExcel(nombreExcel, idProceso, RutaMasivoEmpleado, "empleado", ref validarExcel);
                        if( validarExcel == 0 )
                        listObj = objDao.ImportMasivoEmpleado(session, dt, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        else strMsjDB = "Seleccione el Archivo para Importar Empleados.";
                    }
                    else
                    {
                        Log.AlmacenarLogMensaje("El excel importado no existe en el Servidor " + nombreExcel);
                        strMsjDB = "Vuelva a seleccionar el archivo a importar e inténtelo nuevamente.";
                    }
                }
                else
                {
                    Log.AlmacenarLogMensaje("Corrija la Ruta de Importación Masiva de Empleados (rutaEmpleadoMasivo del webconfig): " + RutaMasivoEmpleado);
                    strMsjDB = "La Ruta del Directorio de Importación Masiva configurado en el Servidor no Existe.";
                }


                if (intResult == 0) //&& validarExcel == 0
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ImportMasivoEmpleado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ImportMasivoEmpleado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ImportMasivoEmpleado)");
            }
            return listObj;
        }
        //5.35
        public List<EmpleadoMasivo> GuardarMasivoEmpleado(Session_Movi session, int idProceso, string nombreExcel, string RutaMasivoEmpleado, ref string strMsjUsuario)
        {
            List<EmpleadoMasivo> lista = new List<EmpleadoMasivo>();

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.GuardarMasivoEmpleado(session, idProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (File.Exists(RutaMasivoEmpleado + "\\" + nombreExcel))
                {
                    if (intResult == 1)
                    {
                        //eliminar el archivo excel
                        File.Delete(RutaMasivoEmpleado + "\\" + nombreExcel);
                    }
                }
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GuardarMasivoEmpleado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GuardarMasivoEmpleado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (GuardarMasivoEmpleado)");
            }
            return lista;
        }
        //5.36 //En desuso Existe otro Genaral de nombre "ReadArchivoExcel" COMENTAR
        public DataTable ReadExcelMasivoEmpleado(string nombreExcel, int idProceso, string RutaMasivoEmpleado, string tipoDoc)
        {
            string urlRuta = RutaMasivoEmpleado + "\\" + nombreExcel;
            DataTable tbImport = new DataTable();
            try
            {
                string strExt = urlRuta.Substring(urlRuta.LastIndexOf("."));
                FileStream stream = File.Open(urlRuta, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader;

                if (strExt == ".xls")
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                else
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                DataSet ds = new DataSet();
                ds = excelReader.AsDataSet(conf);
                stream.Close();
                if (tipoDoc == "empleado")
                {
                    DataTable dtEmpleados = ds.Tables[0]; //Hoja1 es el arreglo 0
                    tbImport = LlenarTableMasivoEmpleado(dtEmpleados, idProceso);
                }
                if (tipoDoc == "permiso") //añadido para Permiso Masivo
                {
                    DataTable dtPermisos = ds.Tables[0];//Hoja1 es el arreglo 0
                    tbImport = LlenarTableMasivoPermiso(dtPermisos, idProceso);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tbImport;
        }
        //5.37
        private DataTable LlenarTableMasivoEmpleado(DataTable dt, int idProceso)
        {
            DataTable table = new DataTable();
            table.Columns.Add("FILA", typeof(string));
            table.Columns.Add("COD_EMP", typeof(string));
            table.Columns.Add("COD_EMP_RUC", typeof(string));
            table.Columns.Add("COD_EMP_DSC", typeof(string));
            table.Columns.Add("COD_LOC", typeof(string));
            table.Columns.Add("COD_LOC_DSC", typeof(string));
            table.Columns.Add("COD_GER", typeof(string));
            table.Columns.Add("COD_GER_DSC", typeof(string));
            table.Columns.Add("COD_ARE", typeof(string));
            table.Columns.Add("COD_ARE_DSC", typeof(string));
            table.Columns.Add("COD_PL", typeof(string));
            table.Columns.Add("COD_PL_DSC", typeof(string));
            table.Columns.Add("COD_CG", typeof(string));
            table.Columns.Add("COD_CG_DSC", typeof(string));
            table.Columns.Add("COD_CT", typeof(string));
            table.Columns.Add("COD_CT_DSC", typeof(string));
            table.Columns.Add("COD_GR", typeof(string));
            table.Columns.Add("COD_GR_DSC", typeof(string));
            table.Columns.Add("COD_TP", typeof(string));
            table.Columns.Add("COD_TP_DSC", typeof(string));
            table.Columns.Add("COD_CC", typeof(string));
            table.Columns.Add("COD_CC_DSC", typeof(string));
            table.Columns.Add("COD_FIS", typeof(string));
            table.Columns.Add("COD_RES", typeof(string));
            table.Columns.Add("COD_EXT", typeof(string));
            table.Columns.Add("COD_TD", typeof(string));
            table.Columns.Add("NUMDOC", typeof(string));
            table.Columns.Add("APEPAT", typeof(string));
            table.Columns.Add("APEMAT", typeof(string));
            table.Columns.Add("NOMBRES", typeof(string));
            table.Columns.Add("FECNAC", typeof(string));
            table.Columns.Add("GENERO", typeof(string));
            table.Columns.Add("FOTOCHECK", typeof(string));
            table.Columns.Add("FECADM", typeof(string));
            table.Columns.Add("ESTADO", typeof(string));
            table.Columns.Add("COD_REG", typeof(string));
            table.Columns.Add("COD_HOR", typeof(string));
            table.Columns.Add("COD_RES_IM", typeof(string));
            table.Columns.Add("COD_RES_CT", typeof(string));
            table.Columns.Add("CORREOP", typeof(string));
            table.Columns.Add("CUENTA_US", typeof(string));
            table.Columns.Add("CUENTA_PF", typeof(string));
            table.Columns.Add("COD_VIA", typeof(string));
            table.Columns.Add("DIRECCION", typeof(string));
            table.Columns.Add("COD_UBI", typeof(string));
            table.Columns.Add("CODPENSIONISTA", typeof(string));
            table.Columns.Add("CODSALUD", typeof(string));
            table.Columns.Add("TELEFONOP", typeof(string));
            table.Columns.Add("CONTRATOI", typeof(string));
            table.Columns.Add("FECCESE", typeof(string));
            table.Columns.Add("COD_CESE", typeof(string));
            table.Columns.Add("COD_GLIQ", typeof(string));
            table.Columns.Add("COORDENADA", typeof(string));
            table.Columns.Add("DIRCOORDENADA", typeof(string));
            table.Columns.Add("INTIDPROCESO", typeof(int));
            table.Columns.Add("OBSERVACION", typeof(string));
            table.Columns.Add("FLAGOBSERVADO", typeof(bool));
            table.Columns.Add("PASSWORD", typeof(string)); // 16.04.2021

            int contador = 1;
            foreach (DataRow row in dt.Rows)
            {
                DataRow rows = table.NewRow();

                //Codificar contraseña actual para validacion

                rows["FILA"] = contador;
                rows["COD_EMP"] = row[0];
                rows["COD_EMP_RUC"] = row[1];
                rows["COD_EMP_DSC"] = row[2];
                rows["COD_LOC"] = row[3];
                rows["COD_LOC_DSC"] = row[4];
                rows["COD_GER"] = row[5];
                rows["COD_GER_DSC"] = row[6];
                rows["COD_ARE"] = row[7];
                rows["COD_ARE_DSC"] = row[8];
                rows["COD_PL"] = row[9];
                rows["COD_PL_DSC"] = row[10];
                rows["COD_CG"] = row[11];
                rows["COD_CG_DSC"] = row[12];
                rows["COD_CT"] = row[13];
                rows["COD_CT_DSC"] = row[14];
                rows["COD_GR"] = row[15];
                rows["COD_GR_DSC"] = row[16];
                rows["COD_TP"] = row[17];
                rows["COD_TP_DSC"] = row[18];
                rows["COD_CC"] = row[19];
                rows["COD_CC_DSC"] = row[20];
                rows["COD_FIS"] = row[21];
                rows["COD_RES"] = row[22];
                rows["COD_EXT"] = row[23];
                rows["COD_TD"] = row[24];

                string Num_ = row[25].ToString();// 16.04.2021
                string Ape_ = row[26].ToString();// 16.04.2021
                string Pass_ = "@" + Ape_.Substring(0, 1).ToUpper() + Ape_.Substring(1).ToLower() + Num_.Trim();// 16.04.2021
                string strcontraseña2 = objUsuario.EncriptarPassword(Pass_);//encapsulado 15.04.2021 ES

                rows["NUMDOC"] = row[25];
                rows["APEPAT"] = row[26];
                rows["APEMAT"] = row[27];
                rows["NOMBRES"] = row[28];
                rows["FECNAC"] = row[29];
                rows["GENERO"] = row[30];
                rows["FOTOCHECK"] = row[31];
                rows["FECADM"] = row[32];
                rows["ESTADO"] = row[33];
                rows["COD_REG"] = row[34];
                rows["COD_HOR"] = row[35];
                rows["COD_RES_IM"] = row[36];
                rows["COD_RES_CT"] = row[37];
                rows["CORREOP"] = row[38];
                rows["CUENTA_US"] = row[39];
                rows["CUENTA_PF"] = row[40];
                rows["COD_VIA"] = row[41];
                rows["DIRECCION"] = row[42];
                rows["COD_UBI"] = row[43];
                rows["CODPENSIONISTA"] = row[44];
                rows["CODSALUD"] = row[45];
                rows["TELEFONOP"] = row[46];
                rows["CONTRATOI"] = row[47];
                rows["FECCESE"] = row[48];
                rows["COD_CESE"] = row[49];
                rows["COD_GLIQ"] = row[50];
                rows["COORDENADA"] = row[51];
                rows["DIRCOORDENADA"] = row[52];
                rows["INTIDPROCESO"] = idProceso;
                rows["OBSERVACION"] = "";
                rows["FLAGOBSERVADO"] = false;

                rows["PASSWORD"] = strcontraseña2;//16.04.2021

                table.Rows.Add(rows);
                contador++;
            }
            return table;
        }
        //5.73
        private bool VerificarRuta(string ruta)
        {
            bool si = false;
            if (System.IO.Directory.Exists(ruta))
            {
                si = true;
            }
            else
            {
                si = false;
            }
            return si;
        }
        #endregion

        #region CambioDI
        //5.38
        public ValidarIdentidad_DI ValidarDocCambioIdentidad(Session_Movi objSession, int intIdTipDoc, string strNumDoc, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            ValidarIdentidad_DI obj = new ValidarIdentidad_DI();

            try
            {
                obj = objDao.ValidarDocCambioIdentidad(objSession, intIdTipDoc, strNumDoc, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ValidarDocCambioIdentidad] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ValidarDocCambioIdentidad)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ValidarDocCambioIdentidad)");
            }
            return obj;
        }
        //5.39
        public List<CambioDI> ListarCambioDI(Session_Movi objSession, string buscarId, int empresaId, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<CambioDI> listObj = new List<CambioDI>();

            try
            {
                listObj = objDao.ListarCambioDI(objSession, buscarId, empresaId, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCambioDI] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCambioDI)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarCambioDI)");
            }
            return listObj;
        }
        //5.40
        public int ActualizarCambioDI(Session_Movi objSession, PersonalCDI personalCDI, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int intID = 0;

            try
            {
                objDao.ActualizarCambioDI(objSession, personalCDI, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 1)
                {
                    intID = 1;
                    CorreoEmp obj = objDao.GetCorreo(personalCDI.intIdPerso, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    if (obj.strCorreo != null)
                    {
                        obj.intIdPersonal = personalCDI.intIdPerso;
                        enviarCorreo(objSession, obj, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    }
                    else
                    {
                        intResult = 2;
                        strMsjUsuario = "No se envió el correo debido a que el usuario no cuenta con un correo registrado";
                    }
                }

                if (intResult == 0 || intResult > 1)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ActualizarCambioDI] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ActualizarCambioDI)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ActualizarCambioDI)");
            }
            return intID;
        }
        //5.41
        private StringBuilder htmlMessageBody(CorreoEmp obj, string filtro, string adicional = "")
        {
            StringBuilder strB = new StringBuilder();

            int intResult = 0;
            string strMsjDB = "";
            string strMsjUsuario = "";

            if (filtro == "REENVIO" && adicional != "")
            {
                byte[] b = Convert.FromBase64String(adicional);
                adicional = System.Text.Encoding.UTF8.GetString(b);
            }

            TEXTOCORREO objTexto = objDao.GetTextoCorreo(filtro, obj.intIdPersonal, 0, false, adicional, ref intResult, ref strMsjDB, ref strMsjUsuario);

            strB.AppendLine("<html>");
            strB.AppendLine("<body>");
            strB.AppendLine("<img src=cid:logo />");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine("<span style='font-size: large;'>" + objTexto.saludo + "</span>");
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            if (!objTexto.texto1.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto1);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto2.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto2);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto3.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto3);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto4.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto4);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto5.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto5);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine(objTexto.despedida);
            strB.AppendLine("</div>");

            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("</div>");
            if (!objTexto.pie1.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie1);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.pie2.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie2);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.pie3.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie3);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            strB.AppendLine("</div>");
            strB.AppendLine("</body>");
            strB.AppendLine("</html>");

            return strB;
        }
        //5.42
        private StringBuilder htmlMessageBodyEmpleado(CorreoEmp obj, int intFiltro, bool desactivaUsuario)
        {
            StringBuilder strB = new StringBuilder();

            int intResult = 0;
            string strMsjDB = "";
            string strMsjUsuario = "";
            TEXTOCORREO objTexto = objDao.GetTextoCorreo("EMPLEADO", obj.intIdPersonal, intFiltro, desactivaUsuario, "", ref intResult, ref strMsjDB, ref strMsjUsuario);

            strB.AppendLine("<html>");
            strB.AppendLine("<body>");
            strB.AppendLine("<img src=cid:logo />");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine("<span style='font-size: large;'>" + objTexto.saludo + "</span>");
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            if (!objTexto.texto1.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto1);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto2.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto2);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto3.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto3);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto4.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto4);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.texto5.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.texto5);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            strB.AppendLine("</div>");
            strB.AppendLine("<br>");
            strB.AppendLine("<div>");
            strB.AppendLine(objTexto.despedida);
            strB.AppendLine("</div>");

            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("<br>");
            strB.AppendLine("</div>");
            if (!objTexto.pie1.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie1);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.pie2.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie2);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            if (!objTexto.pie3.Equals(""))
            {
                strB.AppendLine("<span>");
                strB.AppendLine(objTexto.pie3);
                strB.AppendLine("</span>");
                strB.AppendLine("<br>");
            }
            strB.AppendLine("</div>");
            strB.AppendLine("</body>");
            strB.AppendLine("</html>");

            return strB; //devuelve el cuerpo del correo, el HTML
        }
        //5.43
        private void enviarCorreo(Session_Movi objSession, CorreoEmp obj, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBody(obj, "CAMBIODI");

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                msg.Subject = "Cambio de Usuario del Sistema de Control de Personal (SISCOP)";

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.Port = Int32.Parse(puerto);
                smtp.EnableSsl = auth;
                smtp.UseDefaultCredentials = true;
                //usuario y clave
                smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                smtp.Send(msg);

                intResult = 1;
                strMsjUsuario = "El documento de identidad fue cambiado satisfactoriamente (correo enviado).";
            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                //throw new Exception("Error General (EnviarCorreo)");
            }
        }
        //5.44
        private int enviarCorreoEmpleado(Session_Movi objSession, CorreoEmp obj, int intTipoOperacion, bool desactivaUsuario, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host     = lsCorreoDatos[0].strhost;            //smtp.gmail.com
            string puerto   = lsCorreoDatos[0].strpuerto;          //45    ----> tiene que ser 587
            string ccorreo  = lsCorreoDatos[0].strccorreo;         //"sisfoodweb@gmail.com"
            string cpass    = lsCorreoDatos[0].strcpass;           //"Sisfood2022"
            string cde      = lsCorreoDatos[0].strremitente;       //"Sisfood Web - RR.HH."
            bool   auth     = lsCorreoDatos[0].bitAutentificacion; //true

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBodyEmpleado(obj, intTipoOperacion, desactivaUsuario);

                

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.To.Add(new MailAddress("ereyes@tecflex.com"));
                //msg.CC.Add(new MailAddress("esuyon@tecflex.com"));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                //ccorreo = "sisactivofijo@gmail.com";
                msg.From = new MailAddress(ccorreo);

                if (desactivaUsuario)
                {
                    //Titulo
                    msg.Subject = "Desactivación de Usuario";
                }
                else
                {
                    //Titulo
                    msg.Subject = "Activación de Usuario";
                }


                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);//("45") 
                    smtp.EnableSsl = auth;  //true
                    smtp.UseDefaultCredentials = true;
                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass); //("sisfoodweb@gmail.com", "Sisfood2022")
                    //smtp.Credentials = new NetworkCredential("sisactivofijo@gmail.com", "Admin123*");

                    smtp.Send(msg);
                }

                intResult = 1;
                if (intTipoOperacion == 1)
                {
                    strMsjUsuario = "Se Activó el usuario satisfactoriamente (correo enviado).";
                }
                else
                {
                    if (desactivaUsuario)
                    {
                        strMsjUsuario = "Se inactivó el usuario satisfactoriamente (correo enviado).";
                    }
                    else
                    {
                        strMsjUsuario = "Se reactivó el usuario satisfactoriamente (correo enviado).";
                    }
                }

            }

            catch (Exception ex)
            {
                intResult = 3;  //RHGM 16.11.2021  //Excepcion de no envio de correo
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                Log.AlmacenarLogMensaje("Método => [enviarCorreoEmpleado] => " + " El error se ha presentado en : smtp.Send(msg) ");

                //throw new Exception("Error General (EnviarCorreo)");
            }
            return intResult;
        }
        //5.45
        private int enviarCorreoActivarAdmin(Session_Movi objSession, CorreoEmp obj, int intTipoOperacion, bool desactivaUsuario, string strAdicional, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBody(obj, "ACTIVARADMIN", strAdicional);

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                msg.Subject = "Cambio de Rol";

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);
                    smtp.EnableSsl = auth;
                    smtp.UseDefaultCredentials = true;
                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                    smtp.Send(msg);
                }

                intResult = 1;
                strMsjUsuario = "Se cambió el rol de usuario satisfactoriamente (correo enviado).";

            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo Cambio de Rol";
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                //throw new Exception("Error General (EnviarCorreo)");
            }
            return intResult;
        }
        //5.46
        private int reenviarCorreoEmpleado(Session_Movi objSession, CorreoEmp obj, int intTipoOperacion, bool desactivaUsuario, string strAdicional, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBody(obj, "REENVIO", strAdicional);

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.To.Add(new MailAddress("ereyes@tecflex.com"));
                //msg.CC.Add(new MailAddress("esuyon@tecflex.com"));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                msg.Subject = "Re: Credenciales de usuario";

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);
                    smtp.EnableSsl = auth;
                    smtp.UseDefaultCredentials = true;
                    //var t = smtp.Timeout;//1000000 X DEFAULT
                    //smtp.Timeout = 999999999; //PRUEBAS 
                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                    smtp.Send(msg);
                }

                intResult = 1;
                strMsjUsuario = "Se envió el correo con credenciales.";

            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo";
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                //throw new Exception("Error General (EnviarCorreo)");
            }
            return intResult;
        }
        //5.47
        private int enviarCorreoValidacion(Session_Movi objSession, CorreoEmp obj, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EnCorreo> lsCorreoDatos = objDao.obtenerDatosCorreo(objSession, ref intResult, ref strMsjDB, ref strMsjUsuario);
            string host = lsCorreoDatos[0].strhost;
            string puerto = lsCorreoDatos[0].strpuerto;
            string ccorreo = lsCorreoDatos[0].strccorreo;
            string cpass = lsCorreoDatos[0].strcpass;
            string cde = lsCorreoDatos[0].strremitente;
            bool auth = lsCorreoDatos[0].bitAutentificacion;

            MailMessage msg = new MailMessage();

            try
            {

                // Create file attachment
                Attachment ImageAttachment = new Attachment(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\DirLogos\\logo.png");
                // Set the ContentId of the attachment, used in body HTML
                ImageAttachment.ContentId = "logo";
                msg.Attachments.Add(ImageAttachment);

                StringBuilder datos = htmlMessageBody(obj, "VALIDACION");

                //receptores
                msg.To.Add(new MailAddress(obj.strCorreo));
                //msg.To.Add(new MailAddress("ereyes@tecflex.com"));
                //msg.CC.Add(new MailAddress("esuyon@tecflex.com"));
                //msg.CC.Add(new MailAddress("programador04@tecflex.com"));

                //Remitente
                msg.From = new MailAddress(ccorreo);

                //Titulo
                msg.Subject = "Restablecimiento de contraseña";

                //Cuerpo de correo
                msg.Body = datos.ToString();

                msg.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = Int32.Parse(puerto);
                    smtp.EnableSsl = auth;
                    smtp.UseDefaultCredentials = true;
                    //usuario y clave
                    smtp.Credentials = new NetworkCredential(ccorreo, cpass);

                    smtp.Send(msg);
                }

                intResult = 1;
                strMsjUsuario = "Se envió el correo de restablecimiento de contraseña.";
            }

            catch (Exception ex)
            {
                intResult = 3;
                strMsjUsuario = "Ocurrió un error al enviar el correo de restablecimiento";
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                //throw new Exception("Error General (EnviarCorreo)");
            }
            return intResult;
        }
        #endregion

        #region Papeleta - Permisos - Ausentismos
        //5.50
        public List<Ausentismos> ListarAusentismoDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            List<Ausentismos> lista = new List<Ausentismos>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarAusentismoDet(objSession, intIdPerHor, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarAusentismoDet] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarAusentismoDet)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarAusentismoDet)");
            }
            return lista;
        }
        //5.51
        public List<string> EliminarAusentismo(Session_Movi objSession, int intIdPerCon, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                List<string> listRutaDoc = new List<string>();
                listRutaDoc = objDao.EliminarAusentismo(objSession, intIdPerCon, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarAusentismo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return listRutaDoc;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarAusentismo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (EliminarAusentismo)");
            }
        }
        //5.52
        public Ausentismo ObtenerAusentismoPorPK(Session_Movi objSession, int intId, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            Ausentismo obj = new Ausentismo();
            try
            {
                obj = objDao.ObtenerAusentismoPorPK(objSession, intId, ref intResult, ref strMsjDB, ref strMsjUsuario);
                obj.listDocumentos = objDao.ObtenerDocumentosAusentismo(objSession, intId, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerAusentismoPorPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerAusentismoPorPK)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ObtenerAusentismoPorPK)");
            }
            return obj;
        }
        //5.53
        public int UAusentismos(Session_Movi objSession, Ausentismo objDatos, bool flgDESM, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                int result = 0;

                result = objDao.UAusentismos(objSession, objDatos, flgDESM, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[UAusentismos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }

                return result;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (UAusentismos)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (UAusentismos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (UAusentismos)");
            }
        }
        //5.54
        public List<int> IAusentismos(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                List<int> listPapeletas = new List<int>();

                listPapeletas = objDao.IAusentismos(objSession, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IAusentismos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return listPapeletas;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IAusentismos)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IAusentismos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (IAusentismos)");
            }
        }
        //5.55
        public int EAusentismos(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                int id = 0;

                id = objDao.EAusentismos(objSession, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EAusentismos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return id;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (EAusentismos)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EAusentismos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (EAusentismos)");
            }
        }
        //5.56
        public List<EmpleadoObs> PreIAusentismos(Session_Movi objSession, Ausentismo objDatos, List<int> listPersonal, bool flgDESM, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                List<EmpleadoObs> listPersonalObs = new List<EmpleadoObs>();

                DataTable tb = SerealizeDetalleEmpleado(listPersonal);
                listPersonalObs = objDao.PreIAusentismos(objSession, objDatos, flgDESM, dttFechaIni, dttFechaFin, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[PreIAusentismos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return listPersonalObs;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (PreIAusentismos)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (PreIAusentismos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (PreIAusentismos)");
            }
        }
        //5.57
        public int RegistrarDocumentos(string Archivo, string ruta, List<int> listPapeletas, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                int intId = 0;

                DataTable tb = SerealizeDetallePapeleta(listPapeletas);
                intId = objDao.RegistrarDocumentos(Archivo, ruta, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RegistrarDocumentos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }

                return intId;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (RegistrarDocumentos)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RegistrarDocumentos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (RegistrarDocumentos)");
            }
        }
        //5.58
        public int RegistrarDocumentosEdit(string Archivo, string ruta, int intIdPapeleta, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                int intID = 0;
                objDao.RegistrarDocumentosEdit(Archivo, ruta, intIdPapeleta, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[RegistrarDocumentosEdit] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return intID;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
            //    throw new Exception("Ocurrió un error de Transacción (RegistrarDocumentos)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (RegistrarDocumentosEdit)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (RegistrarDocumentosEdit)");
            }
        }
        //5.59
        public List<string> ComprobarDocumentos(Session_Movi objSession, int intIdPapeleta, List<string> listPapeletas, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<string> listEliminados = new List<string>();
            try
            {
                DataTable tb = SerealizeDetalleNomDocumento(listPapeletas);
                listEliminados = objDao.ComprobarDocumentos(objSession, intIdPapeleta, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ComprobarDocumentos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (ComprobarDocumentos)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ComprobarDocumentos)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ComprobarDocumentos)");
            }
            return listEliminados;
        }
        //5.60
        public bool GetHabGeo(ref string strMsjUsuario)
        {
            try
            {
                bool estado = false;
                int intResult = 0;
                string strMsjDB = "";

                estado = objDao.GetHabGeo(ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GetHabGeo] => Respuesta del Procedimiento : " + strMsjDB);
                    }

                }
                return estado;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GetHabGeo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (GetHabGeo)");
            }

        }
        //5.61
        private DataTable SerealizeDetalleUsuarioPerfil(List<TT_TGPERS_HORARIO_DET> listaDetalleHorAsigEmp, int intIdHorario, DateTime dttFecAsig)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPersonal", typeof(int));
            table.Columns.Add("intIdSoftw", typeof(int));
            table.Columns.Add("intIdHorario", typeof(int));
            table.Columns.Add("dttFecAsig", typeof(DateTime));
            table.Columns.Add("bitFlEliminado", typeof(bool));
            table.Columns.Add("IntIdUsuarReg", typeof(int));
            table.Columns.Add("dttFeRegistro", typeof(DateTime));



            foreach (var item in listaDetalleHorAsigEmp)
            {
                DataRow rows = table.NewRow();
                rows["intIdPersonal"] = item.intIdPerHorario;
                rows["intIdSoftw"] = item.intIdSoftw;
                rows["intIdHorario"] = intIdHorario;
                rows["dttFecAsig"] = dttFecAsig;
                rows["bitFlEliminado"] = item.bitFlEliminado;
                rows["IntIdUsuarReg"] = item.IntIdUsuarReg;
                if (item.dttFeRegistro == null)
                {
                    rows["dttFeRegistro"] = DBNull.Value;
                }
                else
                {
                    rows["dttFeRegistro"] = item.dttFeRegistro;
                }


                table.Rows.Add(rows);
            }

            return table;
        }
        //5.62
        private DataTable SerealizeDetalleEmpleado(List<int> listaEmpleado)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPersonal", typeof(int));

            foreach (var item in listaEmpleado)
            {
                DataRow rows = table.NewRow();
                rows["intIdPersonal"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }
        //5.63
        private DataTable SerealizeDetallePapeleta(List<int> listaEmpleado)
        {
            DataTable table = new DataTable();
            table.Columns.Add("intIdPerConcepto", typeof(int));

            foreach (var item in listaEmpleado)
            {
                DataRow rows = table.NewRow();
                rows["intIdPerConcepto"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }
        //5.64
        private DataTable SerealizeDetalleNomDocumento(List<string> listDocumento)
        {
            DataTable table = new DataTable();
            table.Columns.Add("strNomDocumento", typeof(string));

            foreach (var item in listDocumento)
            {
                DataRow rows = table.NewRow();
                rows["strNomDocumento"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }
        //5.65
        private DataTable SerealizeRuta(List<string> listRuta)
        {
            DataTable table = new DataTable();
            table.Columns.Add("strRuta", typeof(string));

            foreach (var item in listRuta)
            {
                DataRow rows = table.NewRow();
                rows["strRuta"] = item;
                table.Rows.Add(rows);
            }

            return table;
        }
        #endregion

        #region Asig. Horarios
        //5.67
        public List<AsigHorarioData> ListarAsigHor(Session_Movi objSession, int intActivoFilter, string strfilter, int IntIdEmp, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario)
        {
            List<AsigHorarioData> lista = new List<AsigHorarioData>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarAsigHor(objSession, intActivoFilter, strfilter, IntIdEmp, dttfiltrofch1, dttfiltrofch2, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarAsigHor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarAsigHor)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarAsigHor)");
            }
            return lista;
        }
        //5.68
        public List<AsigHorario> ListarAsigHorDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {

            List<AsigHorario> lista = new List<AsigHorario>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarAsigHorDet(objSession, intIdPerHor, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarAsigHorDet] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarAsigHorDet)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ListarAsigHorDet)");
            }
            return lista;
        }
        //5.69
        public bool EliminarAsigHor(Session_Movi objSession, int intIdPerHor, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarAsigHor(objSession, intIdPerHor, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarAsigHor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarAsigHor)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (EliminarAsigHor)");
            }
        }
        //5.70
        public int IUAsigHor(Session_Movi objSession, int intIdPerHor, int intIdHorario, DateTime dttFecAsig, ref string strMsjUsuario)
        {
            try
            {


                int intResult = 0;
                string strMsjDB = "";

                // using (TransactionScope scope = new TransactionScope())
                //{



                int idUnid = objDao.IUAsigHor(objSession, intIdPerHor, intIdHorario, dttFecAsig, ref intResult, ref strMsjDB, ref strMsjUsuario);



                //  scope.Complete();
                // }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUAsigHor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                else
                {

                    idUnid = 0;
                }


                return idUnid;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUAsigHor)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUAsigHor)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (IUAsigHor)");
            }
        }
        //5.71
        public List<EmpleadoObs> IUREGAsigHor(Session_Movi objSession, List<TT_TGPERS_HORARIO_DET> listaDetalleHorAsigEmp, int intIdHorario, DateTime dttFecAsig, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            List<EmpleadoObs> lista = new List<EmpleadoObs>();
            try
            {
                DataTable tb = SerealizeDetalleUsuarioPerfil(listaDetalleHorAsigEmp, intIdHorario, dttFecAsig);
                lista = objDao.IUREGAsigHor(objSession, tb, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUREGAsigHor] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUREGAsigHor)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUREGAsigHor)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (IUREGAsigHor)");
            }
            return lista;
        }
        //5.72
        public List<int> IUREGAsigHorPost(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            try
            {
                List<int> listHorarios = new List<int>();

                listHorarios = objDao.IUREGAsigHorPost(objSession, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUREGAsigHorPost] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
                return listHorarios;
            }
            //catch (TransactionAbortedException ex)
            //{
            //    Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
            //    throw new Exception("Ocurrió un error de Transacción (IUREGAsigHorPost)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUREGAsigHorPost)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (IUREGAsigHorPost)");
            }
        }

        #endregion

        #region Permiso Masivo
        //07.10.2021
        public List<PermisoMasivo> ImportMasivoPermiso(Session_Movi session, string nombreExcel, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario)

        {
            List<PermisoMasivo> listObj = new List<PermisoMasivo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                string RutaMasivoEmpleado = rutaDirectorioExcel;
                bool existe = VerificarRuta(RutaMasivoEmpleado);

                int validarExcel = 0;

                if (existe == true)
                {
                    if (File.Exists(RutaMasivoEmpleado + "\\" + nombreExcel))
                    {


                        //DataTable dt = ReadExcelMasivoEmpleado(nombreExcel, idProceso, RutaMasivoEmpleado, "permiso");
                        DataTable dt = ReadArchivoExcel(nombreExcel, idProceso, RutaMasivoEmpleado, "permiso", ref validarExcel);
                        if (validarExcel == 0 )
                            listObj = objDao.ImportMasivoPermiso(session, dt, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        else strMsjDB = "Seleccione el Archivo para Importar Permisos.";

                        /*
                        //DataTable dt = ReadExcelImportMasivo(nombreExcel, idProceso, RutaMasivoEmpleado, "permiso"); ReadArchivoExcel
                        DataTable dt = ReadArchivoExcel(nombreExcel, idProceso, RutaMasivoEmpleado, "permiso"); 
                     
                      */

                    }
                    else
                    {
                        Log.AlmacenarLogMensaje("El excel importado no existe en el Servidor " + nombreExcel);
                        strMsjDB = "Vuelva a seleccionar el archivo a importar e inténtelo nuevamente.";
                    }
                }
                else
                {
                    Log.AlmacenarLogMensaje("Corrija la Ruta de Importación Masiva de Empleados (rutaEmpleadoMasivo del webconfig): " + RutaMasivoEmpleado);
                    strMsjDB = "La Ruta del Directorio de Importación Masiva configurado en el Servidor no Existe.";
                }

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ImportMasivoPermiso] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (ImportMasivoEmpleado)");
            }
            return listObj;
        }
        public List<PermisoMasivo> GuardarMasivoPermiso(Session_Movi session, int idProceso, string nombreExcel, string RutaMasivoEmpleado, ref string strMsjUsuario)
        {
            List<PermisoMasivo> lista = new List<PermisoMasivo>();

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.GuardarMasivoPermiso(session, idProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (File.Exists(RutaMasivoEmpleado + "\\" + nombreExcel))
                {
                    if (intResult == 1)
                    {
                        //eliminar el archivo excel
                        File.Delete(RutaMasivoEmpleado + "\\" + nombreExcel);
                    }
                }
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[GuardarMasivoPermiso] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (GuardarMasivoPermiso)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
                throw new Exception("Error General (GuardarMasivoPermiso)");
            }
            return lista;
        }

        private DataTable LlenarTableMasivoPermiso(DataTable dt, int idProceso)
        {
            DataTable table = new DataTable();
            table.Columns.Add("FILA", typeof(string));
            table.Columns.Add("COD_EMP", typeof(string));
            table.Columns.Add("COD_JUSTI", typeof(string));
            table.Columns.Add("FECHAINICIO", typeof(string));
            table.Columns.Add("FECHAFIN", typeof(string));
            table.Columns.Add("HORAINICIO", typeof(string));
            table.Columns.Add("HORAFIN", typeof(string));
            table.Columns.Add("CAMBIODIA", typeof(string));//AÑADIDO 25.10.2021
            table.Columns.Add("COMENTARIO", typeof(string));

            table.Columns.Add("INTIDPROCESO", typeof(int));
            table.Columns.Add("OBSERVACION", typeof(string));
            table.Columns.Add("FLAGOBSERVADO", typeof(bool));

            int contador = 1;
            foreach (DataRow row in dt.Rows)
            {
                DataRow rows = table.NewRow();
                rows["FILA"] = contador;
                rows["COD_EMP"] = row[0];
                rows["COD_JUSTI"] = row[1];
                if (!row[2].ToString().Contains("/"))
                {
                    double a = Convert.ToDouble(row[2].ToString());
                    //string Ad = DateTime.FromOADate(a).ToShortDateString();
                    string Ad = DateTime.FromOADate(a).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    rows["FECHAINICIO"] = Ad;
                }
                else
                {
                    rows["FECHAINICIO"] = row[2];
                }
                if (!row[3].ToString().Contains("/"))
                {
                    double a = Convert.ToDouble(row[3].ToString());
                    //El valor numérico se calcula con formato mm/dd/aaaa por eso debo revertir
                    string Ad = DateTime.FromOADate(a).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);//.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    rows["FECHAFIN"] = Ad;
                }
                else
                {
                    rows["FECHAFIN"] = row[3];
                }
                rows["HORAINICIO"] = row[4];
                rows["HORAFIN"] = row[5];
                rows["CAMBIODIA"] = row[6];
                rows["COMENTARIO"] = row[7];
                rows["INTIDPROCESO"] = idProceso;
                rows["OBSERVACION"] = "";
                rows["FLAGOBSERVADO"] = false;

                table.Rows.Add(rows);
                contador++;
            }
            return table;
        }
        #endregion



        //5.36 Modificado para Permiso y empleado 
        public DataTable ReadArchivoExcel(string nombreExcel, int idProceso, string RutaMasivoEmpleado, string tipoDoc, ref int validarExcel) //ReadExcelImportMasivo
        {
            string urlRuta = RutaMasivoEmpleado + "\\" + nombreExcel;
            DataTable tbImport = new DataTable();
            try
            {
                string strExt = urlRuta.Substring(urlRuta.LastIndexOf("."));
                FileStream stream = File.Open(urlRuta, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader;

                if (strExt == ".xls")
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                else
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                DataSet ds = new DataSet();
                ds = excelReader.AsDataSet(conf);
                stream.Close();

                //DATATABLE PARA VALIDAR EL DOCUMENTO CORRECTO CON EL SELECCIONADO AL CARGAR 
                DataTable dtValidar = ds.Tables[0];
                int cantComlumnas = dtValidar.Columns.Count;
                string strNomColumna = dtValidar.Columns[1].ColumnName;
                


                if (tipoDoc == "empleado" && cantComlumnas == 53 && (strNomColumna == "RUC_EMPRESA" || strNomColumna == "COD_EMP_RUC"))
                {
                    DataTable dtEmpleados = ds.Tables[0]; //Hoja1 es el arreglo 0
                    tbImport = LlenarTableMasivoEmpleado(dtEmpleados, idProceso);
                }
                else if (tipoDoc == "permiso" && cantComlumnas == 8 && strNomColumna == "COD_JUSTI") //añadido para Permiso Masivo
                {
                    DataTable dtPermisos = ds.Tables[0];//Hoja1 es el arreglo 0
                    tbImport = LlenarTableMasivoPermiso(dtPermisos, idProceso); 
                }
                else
                {

                    //Cuando el archivo cargado no coincide con el tipo de Iportacion seleccionado en el combo
                    validarExcel = 1 ;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tbImport;
        }


        ////5.34
        //public List<EmpleadoMasivo> ImportMasivoEmpleado(Session_Movi session, string nombreExcel, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario)
        //{
        //    List<EmpleadoMasivo> listObj = new List<EmpleadoMasivo>();
        //    try
        //    {
        //        int intResult = 0;
        //        string strMsjDB = "";
        //        string RutaMasivoEmpleado = rutaDirectorioExcel;
        //        bool existe = VerificarRuta(RutaMasivoEmpleado);

        //        if (existe == true)
        //        {
        //            if (File.Exists(RutaMasivoEmpleado + "\\" + nombreExcel))
        //            {
        //                DataTable dt = ReadExcelImportMasivo(nombreExcel, idProceso, RutaMasivoEmpleado, "empleado"); //modificado 07.10.2021 por Cambio para Permiso
        //                listObj = objDao.ImportMasivoEmpleado(session, dt, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref intResult, ref strMsjDB, ref strMsjUsuario);
        //            }
        //            else
        //            {
        //                Log.AlmacenarLogMensaje("El excel importado no existe en el Servidor " + nombreExcel);
        //                strMsjDB = "Vuelva a seleccionar el archivo a importar e inténtelo nuevamente.";
        //            }
        //        }
        //        else
        //        {
        //            Log.AlmacenarLogMensaje("Corrija la Ruta de Importación Masiva de Empleados (rutaEmpleadoMasivo del webconfig): " + RutaMasivoEmpleado);
        //            strMsjDB = "La Ruta del Directorio de Importación Masiva configurado en el Servidor no Existe.";
        //        }

        //        if (intResult == 0)
        //        {
        //            if (!strMsjDB.Equals(""))
        //            {
        //                Log.AlmacenarLogMensaje("[ImportMasivoEmpleado] => Respuesta del Procedimiento : " + strMsjDB);
        //                if (strMsjUsuario.Equals(""))
        //                    strMsjUsuario = strMsjDB;
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.AlmacenarLogError(ex, "EmpladoBL.cs: Exception");
        //        throw new Exception("Error General (ImportMasivoEmpleado)");
        //    }
        //    return listObj;
        //}









    }
}
