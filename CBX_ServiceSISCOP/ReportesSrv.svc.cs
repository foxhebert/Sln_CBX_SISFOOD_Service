using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ReportesSrv" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ReportesSrv.svc o ReportesSrv.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ReportesSrv : IReportesSrv
    {
        //7.1
        public List<TGTipoEN> ListarCampoFizcalizacion(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            return new ReportesBL().ListarCampoFizcalizacion(intIdSesion,intIdMenu, intIdSoft, ref  strMsjUsuario);
        }
        //7.2
        public List<Planilla> ListarCampoPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUniOrg, ref string strMsjUsuario)
        {
            return new ReportesBL().ListarCampoPlanilla(intIdSesion, intIdMenu, intIdSoft, intIdUniOrg , ref strMsjUsuario);
        }
        //7.3
        public List<Reporte> ConsultaReporte(Session_Movi session, int cboUniOrg, string filtroCalculo, int cboPlanilla, int cboCategoria, bool cesado, int estado, List<int> listGrupoLiq, ref string strMsjUsuario)
        {
            return new ReportesBL().ConsultaReporte(session, cboUniOrg, filtroCalculo, cboPlanilla, cboCategoria, cesado, estado, listGrupoLiq, ref strMsjUsuario);
        }
        //7.4
        public List<ReporteOficial> ReporteOficial(Session_Movi session, List<int> listEmpleados, bool marca, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            return new ReportesBL().ReporteOficial(session, listEmpleados, marca, filtrojer_ini, filtrojer_fin, ref strMsjUsuario);
        }
        //7.5
        public List<ReporteDiario> ReporteDiario(Session_Movi session, List<int> listEmpleados, bool marca, int estado, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            return new ReportesBL().ReporteDiario(session, listEmpleados, marca, estado, filtrojer_ini, filtrojer_fin, ref strMsjUsuario);
        }
        //7.6
        public List<ReporteResumenTotal> ReporteResumenTotal(Session_Movi session, List<int> listEmpleados, int intPeriodo, ref string strMsjUsuario)
        {
            return new ReportesBL().ReporteResumenTotal(session, listEmpleados, intPeriodo, ref strMsjUsuario);
        }
        //7.7
        public List<ReporteFalta> ReporteFalta(Session_Movi session, List<int> listEmpleados, int intPeriodo, ref string strMsjUsuario)
        {
            return new ReportesBL().ReporteFalta(session, listEmpleados, intPeriodo, ref strMsjUsuario);
        }
        //7.8
        public List<ReportePuntualidad> ReportePuntualidad(Session_Movi session, List<int> listEmpleados, int intPeriodo, int tipo, ref string strMsjUsuario)
        {
            return new ReportesBL().ReportePuntualidad(session, listEmpleados, intPeriodo, tipo, ref strMsjUsuario);
        }
        //7.9
        public List<ReporteTardanza> ReporteTardanza(Session_Movi session, List<int> listEmpleados, int intPeriodo, ref string strMsjUsuario)
        {
            return new ReportesBL().ReporteTardanza(session, listEmpleados, intPeriodo, ref strMsjUsuario);
        }
        //7.10
        public List<ReporteRecordGeneral> ReporteRecordGeneral(Session_Movi session, List<int> listEmpleados, int intPeriodo, int tipo, ref string strMsjUsuario)
        {
            return new ReportesBL().ReporteRecordGeneral(session, listEmpleados, intPeriodo, tipo, ref strMsjUsuario);
        }
        //7.11
        public List<ReporteAusencia> ReporteAusencia(Session_Movi session, List<int> listEmpleados, List<int> listConceptos, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            return new ReportesBL().ReporteAusencia(session, listEmpleados, listConceptos, filtrojer_ini, filtrojer_fin, ref strMsjUsuario);
        }
        //7.12
        public List<ReporteAsistencia> ReporteAsistencia(Session_Movi session, List<int> listEmpleados, int intMarcador, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            return new ReportesBL().ReporteAsistencia(session, listEmpleados, intMarcador, filtrojer_ini, filtrojer_fin, ref strMsjUsuario);
        }
        //7.13
        public List<ReporteM> GetReportes(Session_Movi session, ref string strMsjUsuario)
        {
            return new ReportesBL().GetReportes(session, ref strMsjUsuario);
        }

        #region ReportesComedor

        //7.14 - HG 05.03.21
        public List<ReporteDiarioComedor> ReporteDiarioComedor(Session_Movi session, List<int> listEmpleados, bool bitCosto, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido)
        {
            return new ReportesBL().ReporteDiarioComedor(session, listEmpleados, bitCosto, filtrojer_ini, filtrojer_fin, ref strMsjUsuario, intIdTipServ, intIdTipMen, intIdMarcador, bitAtendido);
        }

        //7.15 - HG 08.03.21
        public List<ReporteTotalComedor> ReporteTotalComedor(Session_Movi session, List<int> listEmpleados, int intPeriodo, bool bitCosto, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido)
        { //ReporteResumenTotal
            return new ReportesBL().ReporteTotalComedor(session, listEmpleados, intPeriodo, bitCosto, ref strMsjUsuario, intIdTipServ, intIdTipMen, intIdMarcador, bitAtendido);
        }

        //7.16 - 16.03.2021
        public List<ReporteDiarioConcesionaria> ReporteDiarioConcesionaria(Session_Movi session, List<int> listEmpleados, int idConcesionaria, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido)
        {
            return new ReportesBL().ReporteDiarioConcesionaria(session, listEmpleados, idConcesionaria, filtrojer_ini, filtrojer_fin, ref strMsjUsuario, intIdTipServ, intIdTipMen, intIdMarcador, bitAtendido);
        }
        //7.17
        public List<ReporteTotalConcesionaria> ReporteTotalConcesionaria(Session_Movi session, List<int> listEmpleados, int intPeriodo, int idConcesionaria, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido)
        {
            return new ReportesBL().ReporteTotalConcesionaria(session, listEmpleados, intPeriodo, idConcesionaria, ref strMsjUsuario, intIdTipServ, intIdTipMen, intIdMarcador, bitAtendido);
        }

        #endregion ReportesComedor

    }
}
