﻿using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dominio.Repositorio
{
    public class FeriadoBL
    {
        private FeriadoDAO objDao = new FeriadoDAO();

        //2.2
        public List<Feriado> ListarFeriados(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, string intfiltrojer1, string intfiltrojer2, ref string strMsjUsuario)
        {
            List<Feriado> lista = new List<Feriado>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarFeriados(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer1, intfiltrojer2, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarFeriados] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarFeriados)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ListarFeriados)");
            }
            return lista;
        }
        //2.3
        public bool EliminarFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdFeriado, ref string strMsjUsuario)
        {

            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarFeriado(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdFeriado, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminarFeriado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminarFeriado)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (EliminarFeriado)");
            }
        }
        //2.4
        public bool IUFeriado_T(long intIdSesion, int intIdMenu, int intIdSoft, Feriado objDatos, List<TGFER_UNIORG_DET> listaOrgxFer, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";
                string Msj = "";

                intResult = objDao.IUFeriado_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaOrgxFer, intIdUsuario, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario, ref Msj);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUFeriado_T] => Respuesta del Procedimiento : " + strMsjDB);
                        Log.AlmacenarLogMensaje("[IUFeriado_T] => Respuesta del Procedimiento : " + Msj);
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
            //    Log.AlmacenarLogError(ex, "FeriadoBL.cs");
            //    throw new Exception("Ocurrió un error de Transacción (IUFeriado_T)");
            //}
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (IUFeriado_T)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (IUFeriado_T)");
            }
        }
        //2.5
        public List<Feriado> ObtenerRegistroFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref string strMsjUsuario)
        {
            List<Feriado> lista = new List<Feriado>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerRegistroFeriado(intIdSesion, intIdMenu, intIdSoft, intIdFeriado, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistroFeriado] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroFeriado)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroFeriado)");
            }
            return lista;
        }
        //2.6
        public List<TGFER_UNIORG_DET> ObtenerRegistroReglaDetalleDeOrgixFer(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref string strMsjUsuario)
        {
            List<TGFER_UNIORG_DET> lista = new List<TGFER_UNIORG_DET>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ObtenerRegistroReglaDetalleDeOrgixFer(intIdSesion, intIdMenu, intIdSoft, intIdFeriado, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ObtenerRegistroReglaDetalleDeOrgixFer] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ObtenerRegistroReglaDetalleDeOrgixFer)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "FeriadoBL.cs: Exception");
                throw new Exception("Error General (ObtenerRegistroReglaDetalleDeOrgixFer)");
            }
            return lista;
        }
    }
}
