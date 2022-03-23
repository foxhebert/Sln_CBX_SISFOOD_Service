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
    public class TipoPersonBL
    {
        private TipoPersonDAO objDao = new TipoPersonDAO();

        public List<TipoPerson> ListarTipoPerson(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<TipoPerson> lista = new List<TipoPerson>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarTipoPerson(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarTipoPerson] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarTipoPerson)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (ListarTipoPerson)");
            }
            return lista;
        }
        public bool IUTipoPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, TipoPerson objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                //using (TransactionScope scope = new TransactionScope())
                //{
                int idUnid = objDao.IUTipoPersonal(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //scope.Complete();
                //}

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUTipoPersonal] => Respuesta del Procedimiento : " + strMsjDB);
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
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (InsertarTipoPerson_IU01)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (InsertarTipoPerson_IU01)");
            }
        }

        public bool EliminarTipo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdTipo, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarTipo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdTipo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarTipo] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarTipo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (EliminmarTipo)");
            }
        }
        public List<TipoPerson> ConsultarDetalleTipoPerxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdTiPers, ref string strMsjUsuario)
        {
            List<TipoPerson> lista = new List<TipoPerson>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleTipoPerxCod(intIdSesion, intIdMenu, intIdSoft, IntIdTiPers, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleTipoPerxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleTipoPerxCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "TipoPersonBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleTipoPerxCod)");
            }
            return lista;
        }

    }

}
