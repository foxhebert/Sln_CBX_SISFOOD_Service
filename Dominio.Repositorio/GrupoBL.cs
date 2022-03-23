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
    public class GrupoBL
    {
        private GrupoDAO objDao = new GrupoDAO();

        public List<Grupo> ListarGrupos(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Grupo> lista = new List<Grupo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarGrupos(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarGrupos] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarGrupos)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                throw new Exception("Error General (ListarGrupos)");
            }
            return lista;
        }
        public bool IUGrupo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Grupo objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                //using (TransactionScope scope = new TransactionScope())
                //{
                int idUnid = objDao.IUGrupo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //scope.Complete();
                //}

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUGrupo] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "GrupoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (InsertarGrupo_IU01)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (InsertarGrupo)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                throw new Exception("Error General (InsertarGrupo)");
            }
        }

        public bool EliminarGrup(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdGrupo, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarGrup(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarGrup] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarGrup)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                throw new Exception("Error General (EliminarGrup)");
            }
        }

        public List<Grupo> ConsultarDetalleGrupoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdGrupo, ref string strMsjUsuario)
        {
            List<Grupo> lista = new List<Grupo>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleGrupoxCod(intIdSesion, intIdMenu, intIdSoft, intIdGrupo, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleGrupoxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleGrupoxCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "GrupoBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleGrupoxCod)");
            }
            return lista;
        }

    }
}
