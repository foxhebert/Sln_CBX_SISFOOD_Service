using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReportesSrv" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReportesSrv
    {
        //7.1
        [OperationContract]
        List<Planilla> ListarCampoPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUniOrg, ref string strMsjUsuario);
        //7.2
        [OperationContract]
        List<TGTipoEN> ListarCampoFizcalizacion(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);
        //7.3
        [OperationContract]
        List<Reporte> ConsultaReporte(Session_Movi session, int cboUniOrg, string filtroCalculo, int cboPlanilla, int cboCategoria, bool cesado, int estado, List<int> listGrupoLiq, ref string strMsjUsuario);
        //7.4
        [OperationContract]
        List<ReporteOficial> ReporteOficial(Session_Movi session, List<int> listEmpleados, bool marca, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario);
        //7.5
        [OperationContract]
        List<ReporteDiario> ReporteDiario(Session_Movi session, List<int> listEmpleados, bool marca, int estado, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario);
        //7.6
        [OperationContract]
        List<ReporteResumenTotal> ReporteResumenTotal(Session_Movi session, List<int> listEmpleados, int intPeriodo, ref string strMsjUsuario);
        //7.7
        [OperationContract]
        List<ReporteFalta> ReporteFalta(Session_Movi session, List<int> listEmpleados, int intPeriodo, ref string strMsjUsuario);
        //7.8
        [OperationContract]
        List<ReportePuntualidad> ReportePuntualidad(Session_Movi session, List<int> listEmpleados, int intPeriodo, int tipo, ref string strMsjUsuario);
        //7.9
        [OperationContract]
        List<ReporteTardanza> ReporteTardanza(Session_Movi session, List<int> listEmpleados, int intPeriodo, ref string strMsjUsuario);
        //7.10
        [OperationContract]
        List<ReporteRecordGeneral> ReporteRecordGeneral(Session_Movi session, List<int> listEmpleados, int intPeriodo, int tipo, ref string strMsjUsuario);
        //7.11
        [OperationContract]
        List<ReporteAusencia> ReporteAusencia(Session_Movi session, List<int> listEmpleados, List<int> listConceptos, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario);
        //7.12
        [OperationContract]
        List<ReporteAsistencia> ReporteAsistencia(Session_Movi session, List<int> listEmpleados, int intMarcador, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario);
        //7.13
        [OperationContract]
        List<ReporteM> GetReportes(Session_Movi session, ref string strMsjUsuario);


        #region ReportesComedor
        //7.14 - HG 05.03.21
        [OperationContract]
        List<ReporteDiarioComedor> ReporteDiarioComedor(Session_Movi session, List<int> listEmpleados, bool bitCosto,/* int estado, */string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido);
        //7.15 - HG 08.03.21
        [OperationContract]
        List<ReporteTotalComedor> ReporteTotalComedor(Session_Movi session, List<int> listEmpleados, int intPeriodo, bool bitCosto, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido);
        //7.16 - 16/03/2021
        [OperationContract]
        List<ReporteDiarioConcesionaria> ReporteDiarioConcesionaria(Session_Movi session, List<int> listEmpleados, int idConcesionaria, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido);
        //7.17
        [OperationContract]
        List<ReporteTotalConcesionaria> ReporteTotalConcesionaria(Session_Movi session, List<int> listEmpleados, int intPeriodo, int idConcesionaria, ref string strMsjUsuario, int intIdTipServ, int intIdTipMen, int intIdMarcador, bool bitAtendido);

        #endregion ReportesComedor

    }
}
