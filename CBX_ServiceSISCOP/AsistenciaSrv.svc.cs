using Dominio.Entidades;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AsistenciaSrv" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AsistenciaSrv.svc o AsistenciaSrv.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AsistenciaSrv : IAsistenciaSrv
    {
        // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AsistenciaSrv" en el código, en svc y en el archivo de configuración a la vez.

        //2.27
        public List<CamposAdicionales2> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, ref string strMsjUsuario)
        {
            return new VariableBL().ListarCamposAdicionales(intIdSesion, intIdMenu, intIdSoft, strEntidad, ref strMsjUsuario);
        }

        #region Mant. Feriado
        //2.2
        public List<Feriado> ListarFeriados(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, string intfiltrojer1, string intfiltrojer2, ref string strMsjUsuario)
        {
            return new FeriadoBL().ListarFeriados(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer1, intfiltrojer2, ref strMsjUsuario);
        }
        //2.3
        public bool EliminarFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdFeriado, ref string strMsjUsuario)
        {
            return new FeriadoBL().EliminarFeriado(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdFeriado, ref strMsjUsuario);
        }
        //2.4
        public bool IUFeriado(long intIdSesion, int intIdMenu, int intIdSoft, Feriado objDatos, List<TGFER_UNIORG_DET> listaOrgxFer, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            return new FeriadoBL().IUFeriado_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaOrgxFer, intIdUsuario, intTipoOperacion, ref strMsjUsuario);
        }
        //2.5
        public List<Feriado> ObtenerRegistroFeriado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref string strMsjUsuario)
        {
            return new FeriadoBL().ObtenerRegistroFeriado(intIdSesion, intIdMenu, intIdSoft, intIdFeriado, ref strMsjUsuario);
        }
        //2.6
        public List<TGFER_UNIORG_DET> ObtenerRegistroReglaDetalleDeOrgixFer(long intIdSesion, int intIdMenu, int intIdSoft, int intIdFeriado, ref string strMsjUsuario)
        {
            return new FeriadoBL().ObtenerRegistroReglaDetalleDeOrgixFer(intIdSesion, intIdMenu, intIdSoft, intIdFeriado, ref strMsjUsuario);
        }
        #endregion Mant. Feriado

        #region Mant. Horario
        //2.10
        public List<HorarioData> ListarHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new HorarioBL().ListarHorario(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }
        //2.11
        public bool IUHorario(long intIdSesion, int intIdMenu, int intIdSoft, Horario objDatos, List<HorJor> listaHorariosJor, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            return new HorarioBL().IUHorario_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaHorariosJor, intIdUsuario, intTipoOperacion, ref strMsjUsuario);
        }
        //2.12
        public bool EliminarHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdHorario, ref string strMsjUsuario)
        {
            return new HorarioBL().EliminarHorario(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdHorario, ref strMsjUsuario);
        }
        //2.13
        public List<Horario> ObtenerHorarioPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdHorario, ref string strMsjUsuario)
        {
            return new HorarioBL().ObtenerHorarioPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdHorario, ref strMsjUsuario);
        }
        //2.14
        public List<HorJor> ObtenerHORXJORPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdHorario, ref string strMsjUsuario)
        {
            return new HorarioBL().ObtenerHORXJORPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdHorario, ref strMsjUsuario);
        }
        //2.15
        public List<JornadaxHorario> ListarJornadaHorario(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new JornadaDiariaBL().ListarJornadaHorario(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }

        #endregion Mant. Horario

        #region Mant. Variable

        //2.18
        public List<TGTipoEN> ListarTipoUM(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            return new VariableBL().ListarTipoUM(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsjUsuario);
        }
        //2.19
        public List<VariableData> ListarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new VariableBL().ListarConcepto(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }
        //2.23
        public List<Jornada> ListarHorarioEspecifico(long intIdSesion, int intIdMenu, int intIdSoft, int IdVar, ref string strMsjUsuario)
        {
            return new VariableBL().ListarHorarioEspecifico(intIdSesion, intIdMenu, intIdSoft, IdVar, ref strMsjUsuario);
        }
        //2.24
        public List<Concepto> ListarHorasExtras(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            return new VariableBL().ListarHorasExtras(intIdSesion, intIdMenu, intIdSoft, ref strMsjUsuario);
        }
        //2.25
        public bool EliminarConcepto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdConcepto, ref string strMsjUsuario)
        {
            return new VariableBL().EliminarConcepto(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdConcepto, ref strMsjUsuario);
        }
        //2.26
        public bool IUVariable(long intIdSesion, int intIdMenu, int intIdSoft, Concepto objDatos, List<Concepto> listaConcepto, List<TGJOR_BON_DET> listaDetaBoni, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            return new VariableBL().IUVariable_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaConcepto, listaDetaBoni, intIdUsuario, intTipoOperacion, ref strMsjUsuario);
        }
        //2.28
        public List<Concepto> ObtenerConceptoPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdConcepto, ref string strMsjUsuario)
        {
            return new VariableBL().ObtenerConceptoPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdConcepto, ref strMsjUsuario);
        }
        //2.29
        public List<Concepto> ListarPrioritariosdeHorasExtras(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            return new VariableBL().ListarPrioritariosdeHorasExtras(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsjUsuario);
        }
        //2.30
        public List<Concepto> ListarHorarioEspecificos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intId, int intUso, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            return new VariableBL().ListarHorarioEspecificos(intIdSesion, intIdMenu, intIdSoft, strEntidad, intId, intUso, strGrupo, strSubGrupo, ref strMsjUsuario);
        }

        #endregion Mant. Variable

        #region Comedor

        #region Servicio
        //2.33
        public List<TCSERVICIO> ListarServicios(Session_Movi objSession, int intActivoFilter, string strfilter, int intTipoSerivicio, int intTipoMenu, int intClase, int intUso, ref string strMsjUsuario)
        {
            return new ServicioBL().ListarServicios(objSession, intActivoFilter, strfilter, intTipoSerivicio, intTipoMenu, intClase, intUso, ref strMsjUsuario);
        }
        //2.34
        public bool IUServicio(Session_Movi objSession, int intTipoOperacion, TCSERVICIO objDatos, ref string strMsjUsuario)
        {
            return new ServicioBL().IUServicio(objSession, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //2.35
        public bool EliminarServicio(Session_Movi objSession, int intIdServicio, ref string strMsjUsuario)
        {
            return new ServicioBL().EliminarServicio(objSession, intIdServicio, ref strMsjUsuario);
        }
        //2.36
        public List<TCSERVICIO> ObtenerRegistrodeServicio(Session_Movi objSession, int intIdServicio, ref string strMsjUsuario)
        {
            return new ServicioBL().ObtenerRegistrodeServicio(objSession, intIdServicio, ref strMsjUsuario);
        }

        #endregion Servicio

        #region Mant. Regla Comedor

        //2.37 --modificado 23.09.2021
        public List<ReglaNegocio> ListarRegNegCom(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new RegNegComedorBL().ListarRegNegCom(intIdSesion, intIdMenu, intIdSoft, intActivoFilter,strfilter, intfiltrojer, ref strMsjUsuario);
        }
        //2.38
        public bool IUNegocioCom_T(Session_Movi objSession, int intTipoOperacion, ReglaNegocio objDatos, List<TGREGNEG_DET> listaReglaNegDet, List<TGREGLANEG_SUBSIDIO_DET> listaDetSubsi, List<TGREGLANEG_SERV_DET> listaDetServ, ref string strMsjUsuario)
        {
            return new RegNegComedorBL().IUNegocioCom_T(objSession, intTipoOperacion, objDatos, listaReglaNegDet, listaDetSubsi, listaDetServ, ref strMsjUsuario);
        }
        //2.39
        public bool EliminarReglaNegocioCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {
            return new RegNegComedorBL().EliminarReglaNegocioCom(objSession, intIdReglaNeg, ref strMsjUsuario);
        }
        //2.40
        public List<ReglaNegocio> ObtenerRegistroReglaNegocioCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {
            return new RegNegComedorBL().ObtenerRegistroReglaNegocioCom(objSession, intIdReglaNeg, ref strMsjUsuario);
        }
        //2.41
        public List<TGREGNEG_DET> ObtenerRegistroReglaNegocioDetCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {
            return new RegNegComedorBL().ObtenerRegistroReglaNegocioDetCom(objSession, intIdReglaNeg, ref strMsjUsuario);
        }
        //2.42
        public List<TGREGLANEG_SUBSIDIO_DET> ObtenerRegistroReglaNedocioSubsiCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {
            return new RegNegComedorBL().ObtenerRegistroReglaNedocioSubsiCom(objSession, intIdReglaNeg, ref strMsjUsuario);
        }
        //2.43
        public List<TGREGLANEG_SERV_DET> ObtenerRegistroReglaNedocioServCom(Session_Movi objSession, int intIdReglaNeg, ref string strMsjUsuario)
        {
            return new RegNegComedorBL().ObtenerRegistroReglaNedocioServCom(objSession, intIdReglaNeg, ref strMsjUsuario);
        }

        #endregion Mant. Regla Comedor

        #endregion Comedor

        #region ASISTENCIA

        #region Mant. Regla de Negocio
        //2.54
        public List<ReglaNegocio> ListarReglaNegocio(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new ReglaNegocioBL().ListarReglaNegocio(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }
        //2.55
        public bool IUNegocio(long intIdSesion, int intIdMenu, int intIdSoft, ReglaNegocio objDatos, List<TGREGNEG_DET> listaReglaNegDet, List<TGREG_NEG_CONFIG_HORAS> listaReglaNegHEDet, int intTipoOperacion, int intIdUsuario, ref string strMsjUsuario)
        {
            return new ReglaNegocioBL().IUNegocio_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaReglaNegDet, listaReglaNegHEDet, intTipoOperacion, intIdUsuario, ref strMsjUsuario);
        }
        //2.56
        public bool EliminmarReglaNegocio(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdReglaNeg, ref string strMsjUsuario)
        {
            return new ReglaNegocioBL().EliminmarReglaNegocio(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdReglaNeg, ref strMsjUsuario);
        }
        //2.57
        public List<TGREGNEG_DET> ObtenerRegistroReglaNedocio(long intIdSesion, int intIdMenu, int intIdSoft, int intIdReglaNeg, ref string strMsjUsuario)
        {
            return new ReglaNegocioBL().ObtenerRegistroReglaNedocio(intIdSesion, intIdMenu, intIdSoft, intIdReglaNeg, ref strMsjUsuario);
        }
        //2.58
        public List<TGREG_NEG_CONFIG_HORAS> ObtenerRegistroReglaDetalleDeNedocioHE(long intIdSesion, int intIdMenu, int intIdSoft, int intIdReglaNeg, ref string strMsjUsuario)
        {
            return new ReglaNegocioBL().ObtenerRegistroReglaDetalleDeNedocioHE(intIdSesion, intIdMenu, intIdSoft, intIdReglaNeg, ref strMsjUsuario);
        }


        #endregion Mant. Regla de Negocio

        #region Mant. Jornada Diaria
        //2.61
        public List<JornadaData> ListarJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, int filtroTipoServ, ref string strMsjUsuario)
        {
            return new JornadaDiariaBL().ListarJornada(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, filtroTipoServ, ref strMsjUsuario);
        }
        //2.62
        public bool EliminmarJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdJornada, ref string strMsjUsuario)
        {
            return new JornadaDiariaBL().EliminmarJornada(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdJornada, ref strMsjUsuario);
        }
        //2.63
        public bool IUJornada(long intIdSesion, int intIdMenu, int intIdSoft, int intTipoOperacion, Jornada objDatos, List<Intervalos> listaIntervalos, int intIdUsuario, ref string strMsjUsuario)
        {
            return new JornadaDiariaBL().IUJornada_T(intIdSesion, intIdMenu, intIdSoft, intTipoOperacion, objDatos, listaIntervalos, intIdUsuario, ref strMsjUsuario);
        }
        //2.64
        public List<Jornada> ObtenerJornadaPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJornada, ref string strMsjUsuario)
        {
            return new JornadaDiariaBL().ObtenerJornadaPorsuPK(intIdSesion, intIdMenu, intIdSoft, intIdJornada, ref strMsjUsuario);
        }
        //2.65
        public List<Intervalos> ListarIntervalos(long intIdSesion, int intIdMenu, int intIdSoft, int intfiltrojer, ref string strMsjUsuario)
        {
            return new JornadaDiariaBL().ListarIntervalos(intIdSesion, intIdMenu, intIdSoft, intfiltrojer, ref strMsjUsuario);
        }

        #endregion Mant. Jornada Diaria

        #region Marca Manual
        //2.67
        public List<AsigHorarioData> GetEmpleados(Session_Movi objSession, int intActivoFilter, string strfilter, int IntIdEmp, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario)
        {
            return new MarcaManualBL().GetEmpleados(objSession, intActivoFilter, strfilter, IntIdEmp, dttfiltrofch1, dttfiltrofch2, ref strMsjUsuario);
        }
        //2.68
        public List<AsistenciaData> GetAsistencias(Session_Movi objSession, int intIdPersonal, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario)
        {
            return new MarcaManualBL().GetAsistencias(objSession, intIdPersonal, dttfiltrofch1, dttfiltrofch2, ref strMsjUsuario);
        }
        //2.69
        public bool EliminarMarca(Session_Movi objSession, long intIdAsistencia, ref string strMsjUsuario)
        {
            return new MarcaManualBL().EliminarMarca(objSession, intIdAsistencia, ref strMsjUsuario);
        }
        //2.70
        public List<Dictionary<string, string>> Guardar(Session_Movi objSession, Asistencia objAsistencia, List<Dictionary<string, string>> listaFechas, ref string strMsjUsuario)
        {
            return new MarcaManualBL().Guardar(objSession, objAsistencia, listaFechas, ref strMsjUsuario);
        }
        //2.71
        public Dictionary<string, string> GetMarcasHorario(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {
            return new MarcaManualBL().GetMarcasHorario(objSession, intIdPersonal, ref strMsjUsuario);
        }
        //2.72
        public Asistencia getAsistenciaXID(Session_Movi objSession, int intIdAsistencia, ref string strMsjUsuario)
        {
            return new MarcaManualBL().getAsistenciaXID(objSession, intIdAsistencia, ref strMsjUsuario);
        }
        //2.73
        public bool ActualizarMarca(Session_Movi objSession, Asistencia objAsistencia, ref string strMsjUsuario)
        {
            return new MarcaManualBL().ActualizarMarca(objSession, objAsistencia, ref strMsjUsuario);
        }
        //2.74
        public Dictionary<string, string> GetUltimaMarca(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {
            return new MarcaManualBL().GetUltimaMarca(objSession, intIdPersonal, ref strMsjUsuario);
        }

        #endregion Marca Manual

        #endregion ASISTENCIA

    }
}
