using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio.Entidades;
using Dominio.Entidades.Sistema;
using Dominio.Repositorio;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ProcesoSrv" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ProcesoSrv.svc o ProcesoSrv.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ProcesoSrv : IProcesoSrv
    {

        #region Periodo de Pago

        List<PeriodoData> IProcesoSrv.ListPeriodoPago(Session_Movi session, string filtroPeriodo, int filtroActivo, int filtroSituacion, string filtrojer_ini, string filtrojer_fin, int intIdPlanilla, int intIdUO, ref string strMsjUsuario)
        {
            return new PeriodoBL().ListPeriodoPago(session, filtroPeriodo, filtroActivo, filtroSituacion, filtrojer_ini, filtrojer_fin, intIdPlanilla, intIdUO, ref strMsjUsuario);
        }

        bool IProcesoSrv.EliminarPeriodo(Session_Movi session, int intIdPeriodo, ref string strMsjUsuario)
        {
            return new PeriodoBL().EliminarPeriodo(session, intIdPeriodo, ref strMsjUsuario);
        }

        Periodo IProcesoSrv.ObtenerPeriodoPorsuPK(Session_Movi session, int intIdPeriodo, ref string strMsjUsuario)
        {
            return new PeriodoBL().ObtenerPeriodoPorsuPK(session, intIdPeriodo, ref strMsjUsuario);
        }

        int IProcesoSrv.IUperiodo(Session_Movi session, Periodo periodo, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new PeriodoBL().IUperiodo(session, periodo, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }

        #endregion

        #region Grupo Liquidacion

        List<GrupoLiquidacionData> IProcesoSrv.ListGrupoLiquidacion(Session_Movi session, int filtroUniOrg, int filtroPlanilla, string filtroGrupoLiquidacion, int filtroActivo, int filtroPeriodo, ref string strMsjUsuario)
        {
            return new GrupoLiquidacionBL().ListGrupoLiquidacion(session, filtroUniOrg, filtroPlanilla, filtroGrupoLiquidacion, filtroActivo, filtroPeriodo, ref strMsjUsuario);
        }

        bool IProcesoSrv.EliminarGrupoLiquidacion(Session_Movi session, int intIdGrupoLiquidacion, ref string strMsjUsuario)
        {
            return new GrupoLiquidacionBL().EliminarGrupoLiquidacion(session, intIdGrupoLiquidacion, ref strMsjUsuario);
        }

        GrupoLiquidacion IProcesoSrv.ObtenerGrupoLiquidacionPorsuPK(Session_Movi session, int intIdGrupoLiquidacion, ref string strMsjUsuario)
        {
            return new GrupoLiquidacionBL().ObtenerGrupoLiquidacionPorsuPK(session, intIdGrupoLiquidacion, ref strMsjUsuario);
        }

        int IProcesoSrv.IUGrupoLiq(Session_Movi session, GrupoLiquidacion grupoLiquidacion, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new GrupoLiquidacionBL().IUGrupoLiquidacion(session, grupoLiquidacion, intTipoOperacion, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }

        #endregion

        #region Calculo Manual
        //6.12
        List<GrupoLiquidacion> IProcesoSrv.ListarGrupoLiqxPeriodo(Session_Movi session, List<int> listaPeriodo, ref string strMsjUsuario)
        {
            return new CalculoManualBL().ListarGrupoLiqxPeriodo(session, listaPeriodo, ref strMsjUsuario);
        }
        //6.13
        public List<Planilla> ListarCampoPlanillaAbierta(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            return new CalculoManualBL().ListarCampoPlanillaAbierta(intIdSesion, intIdMenu, intIdSoft, ref strMsjUsuario);
        }
        //6.14
        public List<Periodo> ListarCampoPeriodoxPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPlanilla, ref string strMsjUsuario)
        {
            return new CalculoManualBL().ListarCampoPeriodoxPlanilla(intIdSesion, intIdMenu, intIdSoft, intIdPlanilla, ref strMsjUsuario);
        }
        //6.15
        public List<CalculoPersonal> GetListarPersonal(Session_Movi session, int intIdPlanilla, string strFiltroCalculo, List<int> listaGrupoLiq, ref string strMsjUsuario)
        {
            return new CalculoManualBL().GetListarPersonal(session, intIdPlanilla, strFiltroCalculo, listaGrupoLiq, ref strMsjUsuario);
        }
        //6.16
        public int Calcular(Session_Movi session, int intIdPeriodos, List<int> listPersonal, int intIdPlanilla, int intIdProc)
        {
            return new CalculoManualBL().Calcular(session, intIdPeriodos, listPersonal, intIdPlanilla, intIdProc);
        }
        //6.17
        public List<Periodo> getPeriodoxPlanilla(Session_Movi session, int intIdPlanilla, bool bitCerrado, ref string strMsjUsuario)
        {
            return new CalculoManualBL().getPeriodoxPlanilla(session, intIdPlanilla, bitCerrado, ref strMsjUsuario);
        }
        //6.18
        public int updatePeriodo(Session_Movi session, List<int> listPeriodos, bool bitCerrado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new CalculoManualBL().updatePeriodo(session, listPeriodos, bitCerrado, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //6.19
        public List<CalculoPersonal> GuardarCalculo(Session_Movi session, int intIdProceso, string strFiltroCalculo, int intIdPlanilla, List<int> listaGrupoLiq, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new CalculoManualBL().GuardarCalculo(session, intIdProceso, strFiltroCalculo, intIdPlanilla, listaGrupoLiq, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //6.20
        public int LimpiarTemporal(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new CalculoManualBL().LimpiarTemporal(session, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //6.21
        public List<CalculoPersonal> getPersonalCalculo(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new CalculoManualBL().getPersonalCalculo(session, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //6.22
        public List<CalculoPersonal> getPersonalNoProc(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new CalculoManualBL().getPersonalNoProc(session, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //6.23
        public List<CalculoPersonal> getExportEmpleados(Session_Movi session, List<int> list, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new CalculoManualBL().getExportEmpleados(session, list, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //6.24
        public int validarPeriodo(Session_Movi session, List<int> list)
        {
            return new CalculoManualBL().validarPeriodo(session, list);
        }

        #endregion

    }
}
