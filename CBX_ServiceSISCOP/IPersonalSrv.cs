using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using Dominio.Entidades;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPersonalSrv" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPersonalSrv
    {
        #region Pagina Principal - Dashboard
        //5.1
        [OperationContract]
        List<TSPTAASISTENCIA> ListarAsistenciaDiaria(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.2
        [OperationContract]
        List<DiaAusen> ListarDiasAusencia(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.3
        [OperationContract]
        List<HomeCabe> ListarCabeceras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.4
        [OperationContract]
        List<HorasDesc> ListarHorasDescontadas(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.5
        [OperationContract]
        List<HorasDesc> ListarHorasExtras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);

        #endregion

        #region Empleado
        //5.6
        [OperationContract]
        List<TGPER_CON_DET> ListaAsusencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario);
        //5.7
        [OperationContract]
        List<TGPER_CON_DET> ListaAsistencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario);
        //5.8
        [OperationContract]
        List<TGPER_RESP> ListaPersonalResponsabilidad(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario);
        //5.9
        [OperationContract]
        List<PersonalData> ListarPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, int intIdUniOrg, string strfilter, string dttfiltrofch1, string dttfiltrofch2, int BitFecha, ref string strMsjUsuario);
        //5.10
        [OperationContract]
        List<TGTipoEN> ListarCombos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario);
        //5.11
        [OperationContract]
        List<TGTipoEN> ListarComboJerar(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario);
        //5.12
        [OperationContract]
        List<Personal> ObtenerEmpleadoPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario);
        //5.13
        [OperationContract]
        List<ValidarIdentidad_ENT> ValidarDocIdentidad(int intIdSesion, int intIdMenu, int intIdSoft, int intIdTipDoc, string strNumDoc, ref string strMsjUsuario);
        //5.14
        [OperationContract]
        Dictionary<string,string> ReenviarCorreo(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario);
        //5.15
        [OperationContract]
        string ActivarUsuario(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario);
        //5.16
        [OperationContract]
        string ValidarEmail(Session_Movi objSession, string numDoc, string correo, ref string strMsjUsuario);
        //5.17
        [OperationContract]
        bool EliminarEmpleado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdPersonal, ref string strMsjUsuario);
        //5.18
        [OperationContract]
        bool ActualizarEmpleado(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos, int intIdUsuario, int intIdUsuarModif, ref string strMsjUsuario);
        //5.19 - Modificando Método 16.04.2021
        [OperationContract]
        bool RegistrarOActualizarEmpleado(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, MarcaDni ObjMarcaConDni, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos,
        List<TGPERRESPDET> listaDetallesResponsabilidad, List<TGPERMARCDET> listaDetallesMarcadores, List<TGPERCOOR> listaCoor, int intIdUsuario, int intIdUsuarModif, bool activaUsuario, bool desactivaUsuario, bool activarAdmin,
        int intTipoOperacion, ref string strMsjUsuario);
        //5.20
        [OperationContract]
        List<TGPERMARCDET> ListarMarcadoresPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPerMarc, ref string strMsjUsuario);
        //5.21
        [OperationContract]
        List<TGPERCORRDET> ListarCorreosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario);
        //5.22
        [OperationContract]
        List<TGPERTELEFDET> ListarTelefonosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario);
        //5.23
        [OperationContract]
        List<TGPERCOOR> listarCoordenadas(int intIdPersonal, ref string strMsjUsuario);
        //5.24
        [OperationContract]
        List<TGPERRESPDET> ListarResponsabilidadPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario);

        //5.31
        [OperationContract]
        List<CombosGlobal> ListarComboGeneral(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario);
        //5.32
        [OperationContract]
        List<CamposAdicionalesGlobal> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strNoEntidad, ref string strMsjUsuario);
        //5.88 añadido 26.05.2021
        [OperationContract]
        List<CombosGlobal> ListarComboGeneral_FiltroPerson(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, int intIdFiltroPerson, string strGrupo, string strSubGrupo, ref string strMsjUsuario);

        #endregion Empleado

        #region MiFicha
        //2.1
        [OperationContract]
        List<TSPTAASISTENCIA> ObtenerAsistenciaXFecha(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario);
        #endregion

        #region MarcaEmpleadoDni
        //5.25
        [OperationContract]
        List<MarcaDni> ObtenerEmpleadoConMarcaDNI(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario);
        #endregion

        #region Empleado Masivo
        //5.33
        [OperationContract]
        List<EmpleadoMasivo> ListGrupoLiquidacion(Session_Movi session, EmpleadoMasivo lista, ref string strMsjUsuario);
        //5.34
        [OperationContract]
        List<EmpleadoMasivo> ImportMasivoEmpleado(Session_Movi session, string nombreExcel, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario);
        //5.35
        [OperationContract]
        List<EmpleadoMasivo> GuardarMasivoEmpleado(Session_Movi session, int idProceso, string nombreExcel, string RutaMasivoEmpleado, ref string strMsjUsuario);

        #endregion

        #region CambioDI
        //5.38
        [OperationContract]
        ValidarIdentidad_DI ValidarDocCambioIdentidad(Session_Movi objSession, int intIdTipDoc, string strNumDoc, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.39
        [OperationContract]
        List<CambioDI> ListarCambioDI(Session_Movi objSession, string buscarId, int empresaId, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.40
        [OperationContract]
        int ActualizarCambioDI(Session_Movi objSession, PersonalCDI personalCDI, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        #endregion

        #region Papeletas - Permisos - Ausentismos
        //5.50
        [OperationContract]
        List<Ausentismos> ListarAusentismoDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario);
        //5.51
        [OperationContract]
        List<string> EliminarAusentismo(Session_Movi objSession, int intIdPerCon, ref string strMsjUsuario);
        //5.52
        [OperationContract]
        Ausentismo ObtenerAusentismoPorPK(Session_Movi objSession, int intId, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.53
        [OperationContract]
        int UAusentismos(Session_Movi objSession, Ausentismo objDatos, bool flgDESM, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.54
        [OperationContract]
        List<int> IAusentismos(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.55
        [OperationContract]
        int EAusentismos(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.56
        [OperationContract]
        List<EmpleadoObs> PreIAusentismos(Session_Movi objSession, Ausentismo objDatos, List<int> listPersonal, bool flgDESM, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.57
        [OperationContract]
        int RegistrarDocumentos(string Archivo, string ruta, List<int> listPapeletas, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.58
        [OperationContract]
        int RegistrarDocumentosEdit(string Archivo, string ruta, int intIdPapeleta, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.59
        [OperationContract]
        List<string> ComprobarDocumentos(Session_Movi objSession, int intIdPapeleta, List<string> listPapeletas, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.60
        [OperationContract]
        bool GetHabGeo(ref string strMsjUsuario);

        #endregion


        #region Asignación Horarios
        //5.67
        [OperationContract]
        List<AsigHorarioData> ListarAsigHor(Session_Movi objSession, int intActivoFilter, string strfilter, int IntIdEmp, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario);
        //5.68
        [OperationContract]
        List<AsigHorario> ListarAsigHorDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario);
        //5.69
        [OperationContract]
        bool EliminarAsigHor(Session_Movi objSession, int intIdPerHor, ref string strMsjUsuario);
        //5.70
        [OperationContract]
        int IUAsigHor(Session_Movi objSession, int intIdPerHor, int intIdHorario, DateTime dttFecAsig, ref string strMsjUsuario);
        //5.71
        [OperationContract]
        List<EmpleadoObs> IUREGAsigHor(Session_Movi objSession, List<TT_TGPERS_HORARIO_DET> listaDetalleHorAsigEmp, int intIdHorario, DateTime dttFecAsig, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        //5.72
        [OperationContract]
        List<int> IUREGAsigHorPost(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario);
        #endregion

        //5.74
        [OperationContract]
        List<MaestroCaracteres> MaestroMaxCaracteres(string strTableName);

        #region COMEDOR

        #region TOMA_DE_CONSUMO
        //4.52 --añadido 28.09.2021
        [OperationContract]
        bool UTomaMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Marcador objDatos, ref string strMsjUsuario);
        //5.75
        [OperationContract]
        List<Consumo> ObtenerRegistroConsumo(Session_Movi objSession, int IntIdAsistencia, ref string strMsjUsuario);
        //5.76
        [OperationContract]
        bool RegistrarConsumo(Session_Movi objSession, int intTipoOperacion, Consumo objDatos, bool bitTodosTS, ref string strMsjUsuario, ref int intValida);
        //5.77
        [OperationContract]
        bool AnularServicioRegistrado(Session_Movi objSession, int intIdAsistencia, int intIdServicio, ref string strMsjUsuario, ref int intValida);
        //5.78
        [OperationContract]
        List<Consumo> ListarConsumo(Session_Movi objSession, ref string strMsjUsuario);
        //5.79
        [OperationContract]
        List<TGREGLANEG_SERV_DET> ListarReglaNegocioServicio(Session_Movi objSession, int intIdAsistencia, ref string strMsjUsuario);
        //5.80
        [OperationContract]
        List<TGREGLANEG_SERV_DET> ListarServicioComplementario(Session_Movi objSession, int intIdAsistencia, ref string strMsjUsuario);
        //5.81
        [OperationContract]
        bool RegistrarMarcaConDni(Session_Movi objSession, int intTipoOperacion, ComedorMarcaConDni objDatos, ref string strMsjUsuario, ref int idAsistencia, ref int idConsumoAuto);


        #endregion TOMA_DE_CONSUMO

        #region GESTION_DE_CONSUMOS

        //5.83
        [OperationContract]
        List<Consumo> ListarGestionConsumo(Session_Movi objSession, string dttFiltroFchI, string dttFiltroFchF, string strDescripcion, int intConsumido, int intTipoServ, int intTipoMenu, int IntIdEmp, int intIdMarcador, ref string strMsjUsuario);
        //5.84
        [OperationContract]
        bool UpdateGestionConsumo(Session_Movi objSession, int intTipoOperacion, Consumo objDatos, ref string strMsjUsuario);
        //5.85
        [OperationContract]
        bool UpdateGestionMasivoConsumo(Session_Movi objSession, int intTipoOperacion, List<int> listPersonal, ref string strMsjUsuario);
        //5.86
        [OperationContract]
        List<Consumo> ListarConsumosXid(Session_Movi objSession, int intId, ref string strMsjUsuario);
        //5.87
        [OperationContract]
        bool UpdateGC(Session_Movi objSession, int intTipoOperacion, List<Consumo> listaConsumoSelects, int bitFlConsumido, int evento, ref string strMsjUsuario);

        #endregion GESTION_DE_CONSUMOS

        #endregion COMEDOR


        #region Permiso Masivo
        // 07.10.2021
        [OperationContract]
        List<PermisoMasivo> ImportMasivoPermiso(Session_Movi session, string nombreExcel, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario);
        [OperationContract]
        List<PermisoMasivo> GuardarMasivoPermiso(Session_Movi session, int idProceso, string nombreExcel, string RutaMasivoEmpleado, ref string strMsjUsuario);
        #endregion

    }
}
