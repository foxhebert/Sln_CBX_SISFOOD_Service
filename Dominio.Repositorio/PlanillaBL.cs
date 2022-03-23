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
    public class PLanillaBL
    {
        private PlanillaDAO objDao = new PlanillaDAO();

        public List<Planilla> ListarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarPlanilla(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarPlanillas] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarPlanilla)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (ListarPlanilla)");
            }
            return lista;
        }

        public bool IUPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Planilla objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.IUPlanilla(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
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
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (InsertarPlanilla_IU01)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (InsertarPlanilla_IU01)");
            }
        }

        public bool EliminarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IdPlanilla, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarPlanilla(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, IdPlanilla, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarPlanilla] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarPlanilla)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (EliminmarPlanilla)");
            }
        }

        public List<Planilla> ConsultarDetallePlanillaxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPlanilla, ref string strMsjUsuario)
        {
            List<Planilla> lista = new List<Planilla>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetallePlanillaxCod(intIdSesion, intIdMenu, intIdSoft, intIdPlanilla, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetallePlanillaxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetallePlanillaxCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "PlanillaBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetallePlanillaxCod)");
            }
            return lista;
        }

    }
}
