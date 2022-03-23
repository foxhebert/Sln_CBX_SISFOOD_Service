using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProcesoSrv" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProcesoSrv
    {
        #region Periodo de Pago Depurar

        ////6.5
        //[OperationContract]
        //List<ValidacionesxLongitud> MaestroMaxCaracteres(string strMaestro);
        ////6.6
        //[OperationContract]
        //List<TGTipoEN> ListarCombos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario);
        ////6.7
        //[OperationContract]
        //List<CamposAdicionalesGlobal> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strNoEntidad, ref string strMsjUsuario);
        #endregion
        #region Periodo de Pago

        [OperationContract]
        List<PeriodoData> ListPeriodoPago(Session_Movi session, string filtroPeriodo, int filtroActivo, int filtroSituacion, string filtrojer_ini, string filtrojer_fin, int intIdPlanilla, int intIdUO, ref string strMsjUsuario);

        [OperationContract]
        bool EliminarPeriodo(Session_Movi session, int intIdPersonal, ref string strMsjUsuario);

        [OperationContract]
        Periodo ObtenerPeriodoPorsuPK(Session_Movi session, int intIdPersonal, ref string strMsjUsuario);

        [OperationContract]
        int IUperiodo(Session_Movi session, Periodo periodo, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);

        #endregion

        #region Grupo Liquidacion

        [OperationContract]
        List<GrupoLiquidacionData> ListGrupoLiquidacion(Session_Movi session, int filtroUniOrg, int filtroPlanilla, string filtroGrupoLiquidacion, int filtroActivo, int filtroPeriodo, ref string strMsjUsuario);

        [OperationContract]
        bool EliminarGrupoLiquidacion(Session_Movi session, int intIdGrupoLiquidacion, ref string strMsjUsuario);

        [OperationContract]
        GrupoLiquidacion ObtenerGrupoLiquidacionPorsuPK(Session_Movi session, int intIdGrupoLiquidacion, ref string strMsjUsuario);

        [OperationContract]
        int IUGrupoLiq(Session_Movi session, GrupoLiquidacion grupoLiquidacion, int intTipoOperacion, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);

        #endregion

        #region Calculo Manual
        //6.12
        [OperationContract]
        List<GrupoLiquidacion> ListarGrupoLiqxPeriodo(Session_Movi session, List<int> listaPeriodo, ref string strMsjUsuario);
        //6.13
        [OperationContract]
        List<Planilla> ListarCampoPlanillaAbierta(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);
        //6.14
        [OperationContract]
        List<Periodo> ListarCampoPeriodoxPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPlanilla, ref string strMsjUsuario);
        //6.15
        [OperationContract]
        List<CalculoPersonal> GetListarPersonal(Session_Movi session, int intIdPlanilla, string strFiltroCalculo, List<int> listaGrupoLiq, ref string strMsjUsuario);
        //6.16
        [OperationContract]
        int Calcular(Session_Movi session, int intIdPeriodos, List<int> listPersonal, int intIdPlanilla, int intIdProc);
        //6.17
        [OperationContract]
        List<Periodo> getPeriodoxPlanilla(Session_Movi session, int intIdPlanilla, bool bitCerrado, ref string strMsjUsuario);
        //6.18
        [OperationContract]
        int updatePeriodo(Session_Movi session, List<int> listPeriodos, bool bitCerrado, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //6.19
        [OperationContract]
        List<CalculoPersonal> GuardarCalculo(Session_Movi session, int intIdProceso, string strFiltroCalculo, int intIdPlanilla, List<int> listaGrupoLiq, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //6.20
        [OperationContract]
        int LimpiarTemporal(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //6.21
        [OperationContract]
        List<CalculoPersonal> getPersonalCalculo(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //6.22
        [OperationContract]
        List<CalculoPersonal> getPersonalNoProc(Session_Movi session, int intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //6.23
        [OperationContract]
        List<CalculoPersonal> getExportEmpleados(Session_Movi session, List<int> list, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //6.24
        [OperationContract]
        int validarPeriodo(Session_Movi session, List<int> list);
        #endregion

    }
}
