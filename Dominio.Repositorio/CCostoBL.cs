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
    public class CCostoBL
    {

        private CCostoDAO objDao = new CCostoDAO();

        public List<CCosto> ListarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<CCosto> lista = new List<CCosto>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCCosto(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCCosto] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCCosto)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (ListarCCosto)");
            }
            return lista;
        }

        public bool IUCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, CCosto objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                //using (TransactionScope scope = new TransactionScope())
                //{
                int idUnid = objDao.IUCCosto(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //scope.Complete();
                //}

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarCCosto] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "CCostoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (InsertarCCosto_IU01)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (InsertarCCosto_IU01)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (InsertarCCosto_IU01)");
            }
        }

        public bool EliminarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdCCosto, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarCCosto(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, IntIdCCosto, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarCCosto] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarCCosto)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (EliminarCCosto)");
            }
        }

        public List<CCosto> ConsultarDetalleCCostoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdCCosto, ref string strMsjUsuario)
        {
            List<CCosto> lista = new List<CCosto>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleCCostoxCod(intIdSesion, intIdMenu, intIdSoft, IntIdCCosto, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleCCostoxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleCCostoxCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CCostoBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleCCostoxCod)");
            }
            return lista;
        }

    }
}

