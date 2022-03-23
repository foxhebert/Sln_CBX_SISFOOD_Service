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
    public class MarcadorBL
    {
        private MarcadorDAO objDao = new MarcadorDAO();
        public List<Marcador> ListarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, ref string strMsjUsuario)
        {
            List<Marcador> lista = new List<Marcador>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarMarcador(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarMarcador] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarPlanilla)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (ListarPlanilla)");
            }
            return lista;
        }

        public bool IUMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Marcador objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                //using (TransactionScope scope = new TransactionScope())
                //{
                int idUnid = objDao.IUMarcador(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);

                //scope.Complete();
                //}

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarMarcador] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "MarcadorBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (InsertarMarcador_IU01)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (InsertarMarcador)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (InsertarMarcador)");
            }
        }

        public bool EliminarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdMarcador, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarMarcador(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdMarcador, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarMarcador] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarMarcador)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (EliminarMarcador)");
            }
        }

        public List<Marcador> ConsultarDetalleMarcadorxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdMarcador, ref string strMsjUsuario)
        {
            List<Marcador> lista = new List<Marcador>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleMarcadorxCod(intIdSesion, intIdMenu, intIdSoft, intIdMarcador, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleMarcadorxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleMarcadorxCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleMarcadorxCod)");
            }
            return lista;
        }

        //añadido 28.09.2021 - Toma de Consumo - Seleccionar marcador
        public bool UTomaMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Marcador objDatos,ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;

                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.UTomaMarcador(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[InsertarMarcador] => Respuesta del Procedimiento : " + strMsjDB);
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
            //    Log.AlmacenarLogError(ex, "MarcadorBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (InsertarMarcador_IU01)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (InsertarMarcador)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "MarcadorBL.cs: Exception");
                throw new Exception("Error General (InsertarMarcador)");
            }
        }
    }

}
