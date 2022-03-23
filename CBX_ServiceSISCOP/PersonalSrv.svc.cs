using Dominio.Entidades;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PersonalSrv" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PersonalSrv.svc o PersonalSrv.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PersonalSrv : IPersonalSrv
    {

        #region Pagina Principal - Dashboard
        //5.1
        public List<TSPTAASISTENCIA> ListarAsistenciaDiaria(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarAsistenciaDiaria(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.2
        public List<DiaAusen> ListarDiasAusencia(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarDiasAusencia(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.3
        public List<HomeCabe> ListarCabeceras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarCabeceras(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.4
        public List<HorasDesc> ListarHorasDescontadas(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarHorasDescontadas(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.5
        public List<HorasDesc> ListarHorasExtras(Session_Movi objSession, int intIdPersonal, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarHorasExtras(objSession, intIdPersonal, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }

        #endregion

        #region Empleado
        //5.6
        public List<TGPER_CON_DET> ListaAsusencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListaAsusencias(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, fechaInicio, fechaFin, ref strMsjUsuario);
        }
        //5.7
        public List<TGPER_CON_DET> ListaAsistencias(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListaAsistencias(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, fechaInicio, fechaFin, ref strMsjUsuario);
        }
        //5.8
        public List<TGPER_RESP> ListaPersonalResponsabilidad(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string fechaInicio, string fechaFin, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListaPersonalResponsabilidad(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, fechaInicio, fechaFin, ref strMsjUsuario);
        }
        //5.9
        public List<PersonalData> ListarPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, int intIdUniOrg, string strfilter, string dttfiltrofch1, string dttfiltrofch2, int BitFecha, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarPersonal(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, intIdUniOrg, strfilter, dttfiltrofch1, dttfiltrofch2, BitFecha, ref strMsjUsuario);
        }
        //5.10
        public List<TGTipoEN> ListarCombos(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarCombos(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsjUsuario);
        }
        //5.11
        public List<TGTipoEN> ListarComboJerar(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarComboJerar(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsjUsuario);
        }
        //5.12
        public List<Personal> ObtenerEmpleadoPorsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {
            return new EmpladoBL().ObtenerEmpleadoPorsuPK(intIdSesion,intIdMenu,intIdSoft,intIdPersonal, ref strMsjUsuario);
        }
        //5.13
        public List<ValidarIdentidad_ENT> ValidarDocIdentidad(int intIdSesion, int intIdMenu, int intIdSoft, int intIdTipDoc, string strNumDoc, ref string strMsjUsuario)
        {
            return new EmpladoBL().ValidarDocIdentidad(intIdSesion, intIdMenu,intIdSoft, intIdTipDoc, strNumDoc,ref strMsjUsuario);
        }
        //5.14
        public Dictionary<string, string> ReenviarCorreo(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {
            return new EmpladoBL().ReenviarCorreo(objSession, intIdPersonal, ref strMsjUsuario);
        }
        //5.15
        public string ActivarUsuario(Session_Movi objSession, int intIdPersonal, ref string strMsjUsuario)
        {
            return new EmpladoBL().ActivarUsuario(objSession, intIdPersonal, ref strMsjUsuario);
        }
        //5.16
        public string ValidarEmail(Session_Movi objSession, string numDoc, string correo, ref string strMsjUsuario)
        {
            return new EmpladoBL().ValidarEmail(objSession, numDoc, correo, ref strMsjUsuario);
        }
        //5.17
        public bool EliminarEmpleado(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdPersonal, ref string strMsjUsuario)
        {
            return new EmpladoBL().EliminarEmpleado(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdPersonal, ref  strMsjUsuario);
        }
        //5.18
        public bool ActualizarEmpleado(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos, int intIdUsuario, int intIdUsuarModif, ref string strMsjUsuario)
        {
            return new EmpladoBL().ActualizarEmpleado_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaDetallesCorreos, listaDetallesTelefonos, intIdUsuario, intIdUsuarModif, ref strMsjUsuario);
            //return new EmpladoBL().ActualizarEmpleado(intIdSesion, intIdMenu, intIdSoft, objDatos, listaDetallesCorreos, listaDetallesTelefonos, intIdUsuario, intIdUsuarModif, ref strMsjUsuario);
        }
        //5.19 - Modificando Método 16.04.2021
        public bool RegistrarOActualizarEmpleado(long intIdSesion, int intIdMenu, int intIdSoft, Personal objDatos, MarcaDni ObjMarcaConDni, List<TGPERCORRDET> listaDetallesCorreos, List<TGPERTELEFDET> listaDetallesTelefonos, 
            List<TGPERRESPDET> listaDetallesResponsabilidad, List<TGPERMARCDET> listaDetallesMarcadores, List<TGPERCOOR> listaCoor, int intIdUsuario, int intIdUsuarModif, bool activaUsuario, bool desactivaUsuario, bool activarAdmin,
            int intTipoOperacion, ref string strMsjUsuario)
        {
            return new EmpladoBL().RegistrarOActualizarEmpleado_T(intIdSesion, intIdMenu, intIdSoft, objDatos, ObjMarcaConDni, listaDetallesCorreos, listaDetallesTelefonos, 
                listaDetallesResponsabilidad, listaDetallesMarcadores, listaCoor, intIdUsuario, intIdUsuarModif, activaUsuario, desactivaUsuario, activarAdmin, intTipoOperacion, ref strMsjUsuario);
            //return new EmpladoBL().RegistrarOActualizarEmpleado(intIdSesion, intIdMenu, intIdSoft, objDatos, ObjMarcaConDni, listaDetallesCorreos, listaDetallesTelefonos,
                //listaDetallesResponsabilidad, listaDetallesMarcadores, listaCoor, intIdUsuario, intIdUsuarModif, activaUsuario, desactivaUsuario, activarAdmin, intTipoOperacion, ref strMsjUsuario);
        }
        //5.20
        public List<TGPERMARCDET> ListarMarcadoresPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPerMarc, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarMarcadoresPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPerMarc, ref strMsjUsuario);
        }
        //5.21
        public List<TGPERCORRDET> ListarCorreosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarCorreosPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref strMsjUsuario);
        }
        //5.22
        public List<TGPERTELEFDET> ListarTelefonosPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarTelefonosPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref strMsjUsuario);
        }
        //5.23
        public List<TGPERCOOR> listarCoordenadas(int intIdPersonal, ref string strMsjUsuario)
        {
            return new EmpladoBL().listarCoordenadas(intIdPersonal, ref strMsjUsuario);
        }
        //5.24
        public List<TGPERRESPDET> ListarResponsabilidadPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarResponsabilidadPersonal(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref strMsjUsuario);
        }

        //5.31
        public List<CombosGlobal> ListarComboGeneral(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            return new GlobalBL().ListarComboGeneral(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, strGrupo, strSubGrupo, ref strMsjUsuario);
        }
        //5.32
        public List<CamposAdicionalesGlobal> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strNoEntidad, ref string strMsjUsuario)
        {
            return new GlobalBL().ListarCamposAdicionales(intIdSesion, intIdMenu, intIdSoft, strNoEntidad, ref strMsjUsuario);
        }
        //5.88 añadido 26.05.2021
        public List<CombosGlobal> ListarComboGeneral_FiltroPerson(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intIdFiltroGrupo, int intIdFiltroPerson, string strGrupo, string strSubGrupo, ref string strMsjUsuario)
        {
            return new GlobalBL().ListarComboGeneral_FiltroPerson(intIdSesion, intIdMenu, intIdSoft, strEntidad, intIdFiltroGrupo, intIdFiltroPerson, strGrupo, strSubGrupo, ref strMsjUsuario);
        }
        #endregion Empleado

        #region MiFicha
        //2.1
        public List<TSPTAASISTENCIA> ObtenerAsistenciaXFecha(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            return new EmpladoBL().ObtenerAsistenciaXFecha(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, filtrojer_ini, filtrojer_fin, ref strMsjUsuario);
        }
        #endregion

        #region MarcaEmpleadoDni
        //5.25
        public List<MarcaDni> ObtenerEmpleadoConMarcaDNI(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPersonal, ref string strMsjUsuario)
        {
            return new EmpladoBL().ObtenerEmpleadoConMarcaDNI(intIdSesion, intIdMenu, intIdSoft, intIdPersonal, ref strMsjUsuario);
        }
        #endregion

        #region Empleado Masivo
        //5.33
        public List<EmpleadoMasivo> ListGrupoLiquidacion(Session_Movi session, EmpleadoMasivo lista, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListGrupoLiquidacion(session, lista, ref strMsjUsuario);
        }
        //5.34
        public List<EmpleadoMasivo> ImportMasivoEmpleado(Session_Movi session, string nombreExcel, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario)
        {
            return new EmpladoBL().ImportMasivoEmpleado(session, nombreExcel, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref strMsjUsuario);
        }
        //5.35
        public List<EmpleadoMasivo> GuardarMasivoEmpleado(Session_Movi session, int idProceso, string nombreExcel, string RutaMasivoEmpleado, ref string strMsjUsuario)
        {
            return new EmpladoBL().GuardarMasivoEmpleado(session, idProceso, nombreExcel, RutaMasivoEmpleado, ref strMsjUsuario);
        }

        #endregion

        #region CambioDI
        //5.38
        public ValidarIdentidad_DI ValidarDocCambioIdentidad(Session_Movi objSession, int intIdTipDoc, string strNumDoc, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ValidarDocCambioIdentidad(objSession, intIdTipDoc, strNumDoc, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.39
        public List<CambioDI> ListarCambioDI(Session_Movi objSession, string buscarId, int empresaId, string filtrojer_ini, string filtrojer_fin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarCambioDI(objSession, buscarId, empresaId, filtrojer_ini, filtrojer_fin, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.40
        public int ActualizarCambioDI(Session_Movi objSession, PersonalCDI personalCDI, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ActualizarCambioDI(objSession, personalCDI, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        #endregion

        #region Papeleta - Permisos - Ausentismos
        //5.50
        public List<Ausentismos> ListarAusentismoDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarAusentismoDet(objSession, intIdPerHor, filtrojer_ini, filtrojer_fin, ref strMsjUsuario);
        }
        //5.51
        public List<string> EliminarAusentismo(Session_Movi objSession, int intIdPerCon, ref string strMsjUsuario)
        {
            return new EmpladoBL().EliminarAusentismo(objSession, intIdPerCon, ref strMsjUsuario);
        }
        //5.52
        public Ausentismo ObtenerAusentismoPorPK(Session_Movi objSession, int intId, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ObtenerAusentismoPorPK(objSession, intId, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.53
        public int UAusentismos(Session_Movi objSession, Ausentismo objDatos, bool flgDESM, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().UAusentismos(objSession, objDatos, flgDESM, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.54
        public List<int> IAusentismos(Session_Movi objSessio, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().IAusentismos(objSessio, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.55
        public int EAusentismos(Session_Movi objSessio, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().EAusentismos(objSessio, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.56
        public List<EmpleadoObs> PreIAusentismos(Session_Movi objSession, Ausentismo objDatos, List<int> listPersonal, bool flgDESM, string dttFechaIni, string dttFechaFin, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().PreIAusentismos(objSession, objDatos, listPersonal, flgDESM, dttFechaIni, dttFechaFin, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.57
        public int RegistrarDocumentos(string Archivo, string ruta, List<int> listPapeletas, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().RegistrarDocumentos(Archivo, ruta, listPapeletas, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.58
        public int RegistrarDocumentosEdit(string Archivo, string ruta, int intIdPapeleta, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().RegistrarDocumentosEdit(Archivo, ruta, intIdPapeleta, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.59
        public List<string> ComprobarDocumentos(Session_Movi objSession, int intIdPapeleta, List<string> listPapeletas, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().ComprobarDocumentos(objSession, intIdPapeleta, listPapeletas, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.60
        public bool GetHabGeo(ref string strMsjUsuario)
        {
            return new EmpladoBL().GetHabGeo(ref strMsjUsuario);
        }

        #endregion

        #region Asig. Horarios
        //5.67
        public List<AsigHorarioData> ListarAsigHor(Session_Movi objSession, int intActivoFilter, string strfilter, int IntIdEmp, string dttfiltrofch1, string dttfiltrofch2, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarAsigHor(objSession, intActivoFilter, strfilter, IntIdEmp, dttfiltrofch1, dttfiltrofch2, ref strMsjUsuario);
        }
        //5.68
        public List<AsigHorario> ListarAsigHorDet(Session_Movi objSession, int intIdPerHor, string filtrojer_ini, string filtrojer_fin, ref string strMsjUsuario)
        {
            return new EmpladoBL().ListarAsigHorDet(objSession, intIdPerHor, filtrojer_ini, filtrojer_fin, ref strMsjUsuario);
        }
        //5.69
        public bool EliminarAsigHor(Session_Movi objSession, int intIdPerHor, ref string strMsjUsuario)
        {
            return new EmpladoBL().EliminarAsigHor(objSession, intIdPerHor, ref strMsjUsuario);
        }
        //5.70
        public int IUAsigHor(Session_Movi objSession, int intIdPerHor, int intIdHorario, DateTime dttFecAsig, ref string strMsjUsuario)
        {
            return new EmpladoBL().IUAsigHor(objSession, intIdPerHor, intIdHorario, dttFecAsig, ref strMsjUsuario);
        }
        //5.71
        public List<EmpleadoObs> IUREGAsigHor(Session_Movi objSession, List<TT_TGPERS_HORARIO_DET> listaDetalleHorAsigEmp, int intIdHorario, DateTime dttFecAsig, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().IUREGAsigHor(objSession, listaDetalleHorAsigEmp, intIdHorario, dttFecAsig, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }
        //5.72
        public List<int> IUREGAsigHorPost(Session_Movi objSession, string intIdProceso, ref int intResult, ref string strMsjDB, ref string strMsjUsuario)
        {
            return new EmpladoBL().IUREGAsigHorPost(objSession, intIdProceso, ref intResult, ref strMsjDB, ref strMsjUsuario);
        }

        #endregion

        //5.74
        public List<MaestroCaracteres> MaestroMaxCaracteres(string strTableName)
        {
            return new GlobalBL().MaestroMaxCaracteres(strTableName);
        }


        #region TOMA_CONSUMO 
        //4.52
        public bool UTomaMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Marcador objDatos, ref string strMsjUsuario)
        {
            return new MarcadorBL().UTomaMarcador(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //5.75 - web socket (OBTENER ULTIMO REGISTRO)
        public List<Consumo> ObtenerRegistroConsumo(Session_Movi objSession, int IntIdAsistencia, ref string strMsjUsuario)
        {
            return new ConsumoBL().ObtenerRegistroConsumo(objSession, IntIdAsistencia, ref strMsjUsuario);
        }
        //5.76
        public bool RegistrarConsumo(Session_Movi objSession, int intTipoOperacion, Consumo objDatos, bool bitTodosTS, ref string strMsjUsuario, ref int intValida)
        {
            return new ConsumoBL().RegistrarConsumo(objSession, intTipoOperacion, objDatos, bitTodosTS, ref strMsjUsuario, ref intValida);
        }
        //5.77
        public bool AnularServicioRegistrado(Session_Movi objSession, int intIdAsistencia, int intIdServicio, ref string strMsjUsuario, ref int intValida)
        {
            return new ConsumoBL().AnularServicioRegistrado(objSession, intIdAsistencia, intIdServicio, ref strMsjUsuario, ref intValida);
        }
        //5.78
        public List<Consumo> ListarConsumo(Session_Movi objSession, ref string strMsjUsuario)
        {
            return new ConsumoBL().ListarConsumo(objSession, ref strMsjUsuario);
        }
        //5.79
        public List<TGREGLANEG_SERV_DET> ListarReglaNegocioServicio(Session_Movi objSession, int intIdAsistencia, ref string strMsjUsuario)
        {
            return new ConsumoBL().ListarReglaNegocioServicio(objSession, intIdAsistencia, ref strMsjUsuario);
        }
        //5.80
        public List<TGREGLANEG_SERV_DET> ListarServicioComplementario(Session_Movi objSession, int intIdAsistencia, ref string strMsjUsuario)
        {
            return new ConsumoBL().ListarServicioComplementario(objSession, intIdAsistencia, ref strMsjUsuario);
        }
        //5.81
        public bool RegistrarMarcaConDni(Session_Movi objSession, int intTipoOperacion, ComedorMarcaConDni objDatos, ref string strMsjUsuario, ref int idAsistencia, ref int idConsumoAuto)
        {
            return new ConsumoBL().RegistrarMarcaConDni(objSession, intTipoOperacion, objDatos, ref strMsjUsuario, ref idAsistencia, ref idConsumoAuto);
        }


        #endregion TOMA_CONSUMO

        #region GESTION_DE_CONSUMOS
        //5.83
        public List<Consumo> ListarGestionConsumo(Session_Movi objSession, string dttFiltroFchI, string dttFiltroFchF, string strDescripcion, int intConsumido, int intTipoServ, int intTipoMenu, int IntIdEmp, int intIdMarcador, ref string strMsjUsuario)
        {
            return new GestionConsumoBL().ListarGestionConsumo(objSession, dttFiltroFchI, dttFiltroFchF, strDescripcion, intConsumido, intTipoServ, intTipoMenu, IntIdEmp, intIdMarcador, ref strMsjUsuario);
        }
        //5.84
        public bool UpdateGestionConsumo(Session_Movi objSession, int intTipoOperacion, Consumo objDatos, ref string strMsjUsuario)
        {
            return new GestionConsumoBL().UpdateGestionConsumo(objSession, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //5.85
        public bool UpdateGestionMasivoConsumo(Session_Movi objSession, int intTipoOperacion, List<int> listPersonal, /*Consumo objDatos,*/ ref string strMsjUsuario)
        {
            return new GestionConsumoBL().UpdateGestionMasivoConsumo(objSession, intTipoOperacion, listPersonal, /*objDatos,*/ ref strMsjUsuario);
        }
        //5.86
        public List<Consumo> ListarConsumosXid(Session_Movi objSession, int intId, ref string strMsjUsuario)
        {
            return new GestionConsumoBL().ListarConsumosXid(objSession, intId, ref strMsjUsuario);
        }
        //5.87
        public bool UpdateGC(Session_Movi objSession, int intTipoOperacion, List<Consumo> listaConsumoSelects, int bitFlConsumido, int evento, ref string strMsjUsuario)
        {
            return new GestionConsumoBL().UpdateGC(objSession, intTipoOperacion, listaConsumoSelects, bitFlConsumido, evento, ref strMsjUsuario);
        }
        #endregion GESTION_DE_CONSUMOS



        #region Permiso Masivo
        //07.10.2021
        public List<PermisoMasivo> ImportMasivoPermiso(Session_Movi session, string nombreExcel, int idProceso, int cboPlantilla, int cboFormato, bool checkActualizar, string rutaDirectorioExcel, ref string strMsjUsuario)
        {
            return new EmpladoBL().ImportMasivoPermiso(session, nombreExcel, idProceso, cboPlantilla, cboFormato, checkActualizar, rutaDirectorioExcel, ref strMsjUsuario);
        }
        public List<PermisoMasivo> GuardarMasivoPermiso(Session_Movi session, int idProceso, string nombreExcel, string RutaMasivoEmpleado, ref string strMsjUsuario)
        {
            return new EmpladoBL().GuardarMasivoPermiso(session, idProceso, nombreExcel, RutaMasivoEmpleado, ref strMsjUsuario);
        }
        #endregion


    }
}
