using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio.Repositorio
{
    public class PeriodoBL
    {
        private PeriodoDAO objDao = new PeriodoDAO();

        public List<PeriodoData> ListPeriodoPago(Session_Movi session, string filtroPeriodo, int filtroActivo, int filtroSituacion, string filtrojer_ini, string filtrojer_fin, int intIdPlanilla, int intIdUO, ref string strMsjUsuario)
        {
            List<PeriodoData> lista = new List<PeriodoData>();

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListPeriodoPago(session, filtroPeriodo, filtroActivo, filtroSituacion, filtrojer_ini, filtrojer_fin, intIdPlanilla, intIdUO, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListPeriodoPago] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListPeriodoPago)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: Exception");
                throw new Exception("Error General (ListPeriodoPago)");
            }
            return lista;
        }

        public bool EliminarPeriodo(Session_Movi session, int intIdPeriodo, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool estado = false;

                estado = objDao.EliminarPeriodo(session, intIdPeriodo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarPeriodo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return estado;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarPeriodo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: Exception");
                throw new Exception("Error General (EliminarPeriodo)");
            }
        }

        public Periodo ObtenerPeriodoPorsuPK(Session_Movi session, int intIdPeriodo, ref string strMsjUsuario)
        {
            Periodo obj = new Periodo();
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                bool estado = false;

                obj = objDao.ObtenerPeriodoPorsuPK(session, intIdPeriodo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerPeriodoPorsuPK] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerPeriodoPorsuPK)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: Exception");
                throw new Exception("Error General (ObtenerPeriodoPorsuPK)");
            }
            return obj;
        }

        public int IUperiodo(Session_Movi session, Periodo periodo, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            int codID = 0;

            try
            {
                codID = objDao.IUperiodo(session, periodo, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUperiodo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUperiodo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PeriodoBL.cs: Exception");
                throw new Exception("Error General (IUperiodo)");
            }
            return codID;
        }

    }

}
