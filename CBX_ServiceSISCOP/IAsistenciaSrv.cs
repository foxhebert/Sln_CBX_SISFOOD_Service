using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio.Entidades;


namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAsistenciaSrv" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAsistenciaSrv
    {
        //2.27 --Pendiente Eliminar tras depuración de WebSite
        [OperationContract]
        List<CamposAdicionales2> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, ref string strMsjUsuario);

        #region Feriado
        //2.2
        [OperationContract]
        List<Feriado> ListarFeriados(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, string intfiltrojer1, string intfiltrojer2, ref string strMsjUsuario);
        //2.3
        [OperationContract]
        bool EliminarFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdFeriado, ref string strMsjUsuario);
        //2.4
        [OperationContract]
        bool IUFeriado(long intIdSesion, int intIdMenu, int intIdSoft, Feriado objDatos, List<TGFER_UNIORG_DET> listaOrgxFer, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario);
        //2.5
        [OperationContract]
        List<Feriado> ObtenerRegistroFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref string strMsjUsuario);
        //2.6
        [OperationContract]
        List<TGFER_UNIORG_DET> ObtenerRegistroReglaDetalleDeOrgixFer(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref string strMsjUsuario);
        #endregion Feriado

        #region Horario
        //2.10
        [OperationContract]
        List<HorarioData> ListarHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);
        //2.11
        [OperationContract]
        bool IUHorario(long intIdSesion, int intIdMenu, int intIdSoft, Horario objDatos, List<HorJor> listaHorariosJor, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario);
        //2.12
        [OperationContract]
        bool EliminarHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdHorario, ref string strMsjUsuario);
        //2.13
        [OperationContract]
        List<Horario> ObtenerHorarioPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdHorario, ref string strMsjUsuario);
        //2.14
        [OperationContract]
        List<HorJor> ObtenerHORXJORPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdHorario, ref string strMsjUsuario);
        //2.15
        [OperationContract]
        List<JornadaxHorario> ListarJornadaHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);

        #endregion Horario


        #region Variable
        //2.18
        [OperationContract]
        List<TGTipoEN> ListarTipoUM(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario);
        //2.19
        [OperationContract]
        List<VariableData> ListarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);
        //2.23
        [OperationContract]
        List<Jornada> ListarHorarioEspecifico(long intIdSesion, int intIdMenu, int intIdSoft, int IdVar, ref string strMsjUsuario);
        //2.24
        [OperationContract]
        List<Concepto> ListarHorasExtras(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);
        //2.25
        [OperationContract]
        bool EliminarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdConcepto, ref string strMsjUsuario);
        //2.26
        [OperationContract]
        bool IUVariable(long intIdSesion, int intIdMenu, int intIdSoft, Concepto objDatos, List<Concepto> listaConcepto, List<TGJOR_BON_DET> listaDetaBoni, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario);
        //2.28
        [OperationContract]
        List<Concepto> ObtenerConceptoPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdConcepto, ref string strMsjUsuario);
        //2.29
        [OperationContract]
        List<Concepto> ListarPrioritariosdeHorasExtras(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario);
        //2.30
        [OperationContract]
        List<Concepto> ListarHorarioEspecificos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intId, int intUso, string strGrupo, string strSubGrupo, ref string strMsjUsuario);

        #endregion Variable

        #region COMEDOR

        #region Servicio
        //2.33
        [OperationContract]
        List<TCSERVICIO> ListarServicios(Session_Movi objSession, int intActivoFilter, string strfilter, int intTipoSerivicio, int intTipoMenu, int intClase, int intUso, ref string strMsjUsuario);
        //2.34
        [OperationContract]
        bool IUServicio(Session_Movi objSession, int intTipoOperacion, TCSERVICIO objDatos, ref string strMsjUsuario);
        //2.35
        [OperationContract]
        bool EliminarServicio(Session_Movi objSession, int intIdServicio, ref string strMsjUsuario);
        //2.36
        [OperationContract]
        List<TCSERVICIO> ObtenerRegistrodeServicio(Session_Movi objSession, int intIdServicio, ref string strMsjUsuario);

        #endregion Servicio

        #region Regla de Negocio Comedor
        //2.37--modificado 23.09.2021
        [OperationContract]
        List<ReglaNegocio> ListarRegNegCom(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);
        //2.38
        [OperationContract]
        bool IUNegocioCom_T(Session_Movi objSession, int intTipoOperacion, ReglaNegocio objDatos, List<TGREGNEG_DET> listaReglaNegDet, List<TGREGLANEG_SUBSIDIO_DET> listaDetSubsi, List<TGREGLANEG_SERV_DET> listaDetServ, ref string strMsjUsuario);
        //2.39
        [OperationContract]
        bool EliminarReglaNegocioCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario);
        //2.40
        [OperationContract]
        List<ReglaNegocio> ObtenerRegistroReglaNegocioCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario);
        //2.41
        [OperationContract]
        List<TGREGNEG_DET> ObtenerRegistroReglaNegocioDetCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario);
        //2.42
        [OperationContract]
        List<TGREGLANEG_SUBSIDIO_DET> ObtenerRegistroReglaNedocioSubsiCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario);
        //2.43
        [OperationContract]
        List<TGREGLANEG_SERV_DET> ObtenerRegistroReglaNedocioServCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario);

        #endregion Regla de Negocio Comedor

        #endregion COMEDOR

        #region ASISTENCIA

        #region Regla de Negocio Asistencia
        //2.54
        [OperationContract]
        List<ReglaNegocio> ListarReglaNegocio(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);
        //2.55
        [OperationContract]
        bool IUNegocio(long intIdSesion, int intIdMenu, int intIdSoft, ReglaNegocio objDatos, List<TGREGNEG_DET> listaReglaNegDet, List<TGREG_NEG_CONFIG_HORAS> listaReglaNegHEDet, int intTipoOperacion, int intIdUsuario, ref string strMsjUsuario);
        //2.56
        [OperationContract]
        bool EliminmarReglaNegocio(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdReglaNeg, ref string strMsjUsuario);
        //2.57
        [OperationContract]
        List<TGREGNEG_DET> ObtenerRegistroReglaNedocio(long intIdSesion, int intIdMenu, int intIdSoft, int intIdReglaNeg, ref string strMsjUsuario);
        //2.58
        [OperationContract]
        List<TGREG_NEG_CONFIG_HORAS> ObtenerRegistroReglaDetalleDeNedocioHE(long intIdSesion, int intIdMenu, int intIdSoft, int intIdReglaNeg, ref string strMsjUsuario);

        #endregion Regla de Negocio Asistencia

        #region Jornada Diaria Asistencia
        //2.61
        [OperationContract]
        List<JornadaData> ListarJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, int filtroTipoServ, ref string strMsjUsuario);
        //2.62
        [OperationContract]
        bool EliminmarJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdJornada, ref string strMsjUsuario);
        //2.63
        [OperationContract]
        bool IUJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intTipoOperacion, Jornada objDatos, List<Intervalos> listaIntervalos, int intIdUsuario, ref string strMsjUsuario);
        //2.64
        [OperationContract]
        List<Jornada> ObtenerJornadaPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJornada, ref string strMsjUsuario);
        //2.65
        [OperationContract]
        List<Intervalos> ListarIntervalos(long intIdSesion, int intIdMenu, int intIdSoft, int intfiltrojer, ref string strMsjUsuario);

        #endregion Jornada Diaria Asistencia

        #region Marca Manual
        //2.67
        [OperationContract]
        List<AsigHorarioData> GetEmpleados(Session_Movi objSession, int intActivoFilter, string strfilter, int IntIdEmp, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario);
        //2.68
        [OperationContract]
        List<AsistenciaData> GetAsistencias(Session_Movi objSession, int intIdPersonal, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario);
        //2.69
        [OperationContract]
        bool EliminarMarca(Session_Movi objSession, long intIdAsistencia, ref string strMsjUsuario);
        //2.70
        [OperationContract]
        List<Dictionary<string, string>> Guardar(Session_Movi objSession, Asistencia objAsistencia, List<Dictionary<string, string>> listaFechas, ref string strMsjUsuario);
        //2.71
        [OperationContract]
        Dictionary<string, string> GetMarcasHorario(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario);
        //2.72
        [OperationContract]
        Asistencia getAsistenciaXID(Session_Movi objSession, int intIdAsistencia, ref string strMsjUsuario);
        //2.73
        [OperationContract]
        bool ActualizarMarca(Session_Movi objSession, Asistencia objAsistencia, ref string strMsjUsuario);
        //2.74
        [OperationContract]
        Dictionary<string, string> GetUltimaMarca(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario);

        #endregion Marca Manual

        #endregion ASISTENCIA

    }
}
