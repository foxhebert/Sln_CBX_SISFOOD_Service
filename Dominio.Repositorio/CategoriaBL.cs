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
    public class CategoriaBL
    {
        private CategoriaDAO objDao = new CategoriaDAO();
        public List<Categoria> ListarCategorias(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ListarCategorias(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ListarCategorias] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ListarCategorias)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                throw new Exception("Error General (ListarCategorias)");
            }
            return lista;
        }

        public bool IUCategoria(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Categoria objDatos, ref string strMsjUsuario)
        {
            try
            {
                bool tudobem = false;
                int intResult = 0;
                string strMsjDB = "";

                int idUnid = objDao.IUCategoria(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref intResult, ref strMsjDB, ref strMsjUsuario);

                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[IUCategoria] => Respuesta del Procedimiento : " + strMsjDB);
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
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (InsertarCategoria)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                throw new Exception("Error General (InsertarCategoria)");
            }
        }

        public bool EliminarCategoria(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCategoria, ref string strMsjUsuario)
        {
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                bool tudobem = false;
                tudobem = objDao.EliminarCategoria(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdCategoria, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[EliminmarCategoria] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

                return tudobem;
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (EliminmarCategoria)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                throw new Exception("Error General (EliminmarCategoria)");
            }
        }

        public List<Categoria> ConsultarDetalleCategoriaxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdCateg, ref string strMsjUsuario)
        {
            List<Categoria> lista = new List<Categoria>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";

                lista = objDao.ConsultarDetalleCategoriaxCod(intIdSesion, intIdMenu, intIdSoft, intIdCateg, ref intResult, ref strMsjDB, ref strMsjUsuario);
                if (intResult == 0)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ConsultarDetalleCategoriaxCod] => Respuesta del Procedimiento : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }

                }

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ConsultarDetalleCategoriaxCod)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "CategoriaBL.cs: Exception");
                throw new Exception("Error General (ConsultarDetalleCategoriaxCod)");
            }
            return lista;

        }

    }
}
