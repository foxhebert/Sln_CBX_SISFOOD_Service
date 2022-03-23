using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public class AccesoMovilBL
    {

        private AccesoMovilDAO objDao = new AccesoMovilDAO();

        public List<RstaValidPersonalEntity> ValidarPersonaAcceso(string strNumDocumento, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strTipoAcceso)
        {
            List<RstaValidPersonalEntity> lista = new List<RstaValidPersonalEntity>();
            try
            {

                lista = objDao.ValidarPersonaAcceso(strNumDocumento, dtHoraMarca, dtFechaMarca, strTerminal, strTipoAcceso);

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaInsertMarcaEntity> InsertarMarcaAcceso(string strNumDocumento, string strTipoAcceso, string dtHoraMarca, string dtFechaMarca, string strTerminal, string strFotoAcceso, string strReporte_dir, string strDireccion)
        {
            List<RstaInsertMarcaEntity> lista = new List<RstaInsertMarcaEntity>();
            try
            {

                lista = objDao.InsertarMarcaAcceso(strNumDocumento, strTipoAcceso, dtHoraMarca, dtFechaMarca, strTerminal, strFotoAcceso, strReporte_dir, strDireccion);

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }
            //28/12 11.08
            return lista;
        }

        public List<RstaInsertImgEntity> InsertarImagenAcceso(int intIdAsistencia, string strFotoAcceso)
        {
            List<RstaInsertImgEntity> lista = new List<RstaInsertImgEntity>();
            try
            {

                lista = objDao.InsertarImagenAcceso(intIdAsistencia, strFotoAcceso);

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaListMarcaEntity> ListarMarcasAcceso(string strTerminal, string strFotocheck, string strFecha)
        {
            List<RstaListMarcaEntity> lista = new List<RstaListMarcaEntity>();
            try
            {

                lista = objDao.ListarMarcasAcceso(strTerminal, strFotocheck, strFecha);

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaListaCoordEntity> ListarCoordAcceso(int intIdPersonal)
        {
            List<RstaListaCoordEntity> lista = new List<RstaListaCoordEntity>();
            try
            {

                lista = objDao.ListarCoordAcceso(intIdPersonal);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaConexion> ValidarConexionAcceso()
        {
            List<RstaConexion> lista = new List<RstaConexion>();
            try
            {

                lista = objDao.ValidarConexionAcceso();

            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        //08012021

        public List<RstaListConceptos> ListarConceptosAcceso(string strFotocheck, string strfiltro_fech, string strSerie)
        {
            List<RstaListConceptos> lista = new List<RstaListConceptos>();
            try
            {

                lista = objDao.ListarConceptosAcceso(strFotocheck, strfiltro_fech, strSerie);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaListComboConcepto> ListarComboConceptosAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            List<RstaListComboConcepto> lista = new List<RstaListComboConcepto>();
            try
            {

                lista = objDao.ListarComboConceptosAcceso(strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaListComboSustenta> ListarComboSustentaAcceso(string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo)
        {
            List<RstaListComboSustenta> lista = new List<RstaListComboSustenta>();
            try
            {

                lista = objDao.ListarComboSustentaAcceso(strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaInsertConcepto> InsertaConceptoAcceso(string strTerminal, string strFotocheck, string strDeConcepto, string strFecIni, string strFecFin,
                            string strHoraIni, string strHoraFin, string strObs, int intEspeValorada, int bitSustentado, string strCitt, string strEmitEn, string strEmitPor, int intDiaSgtIni, int intDiaSgtFin, string strNomFoto)
        {
            List<RstaInsertConcepto> lista = new List<RstaInsertConcepto>();
            try
            {

                lista = objDao.InsertaConceptoAcceso(strTerminal, strFotocheck, strDeConcepto, strFecIni, strFecFin,
                            strHoraIni, strHoraFin, strObs, intEspeValorada, bitSustentado, strCitt, strEmitEn, strEmitPor, intDiaSgtIni, intDiaSgtFin, strNomFoto);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

        public List<RstaDeleteConcepto> EliminarPapeletaAcceso(int intIdPerConcepto)
        {
            List<RstaDeleteConcepto> lista = new List<RstaDeleteConcepto>();
            try
            {

                lista = objDao.EliminarPapeletaAcceso(intIdPerConcepto);

            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "AccesoMovilBL.cs");
                throw new Exception("Ocurrió un error en BD " + ex);
            }

            return lista;
        }

    }
}
