using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOrganizacionSrv" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOrganizacionSrv
    {

        #region TGUNDORG
        //4.1
        [OperationContract]
        List<Ubigeo> LlenarUbigeoInverso(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUbigeo, ref string strMsjUsuario);
        //4.2
        [OperationContract]
        List<UnidadOrgData> ListarUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, int intfiltrojer, int intActivoFilter, ref string strMsjUsuario);
        //4.3
        [OperationContract]
        List<Ubigeo> ListarDistrict(long intIdSesion, int intIdMenu, int intIdSoft, string strCoDep, string stridpaisProv, ref string strMsjUsuario);
        //4.4
        [OperationContract]
        List<Ubigeo> ListarProvincias(long intIdSesion, int intIdMenu, int intIdSoft, string stridPaisDep, string strCoDep, ref string strMsjUsuario);
        //4.5
        [OperationContract]
        List<JerarquiaOrg> ListarCampoJerarquía(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);
        //4.6
        [OperationContract]
        List<UnidadOrg> ListarCampoUnidSup(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJerOrg, ref string strMsjUsuario);
        //4.7
        [OperationContract]
        List<Personal> ListarResponsable(long intIdSesion, int intIdMenu, int intIdSoft, string strfiltroPersonal, ref string strMsjUsuario);
        //4.8
        [OperationContract]
        List<Ubigeo> ListarUbigeo(long intIdSesion, int intIdMenu, int intIdSoft, int intcodPais, ref string strMsjUsuario);
        //4.9
        [OperationContract]
        List<TGTipoEN> ListarDirecFiscal(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);
        //4.10
        [OperationContract]
        List<RepLegal> ListarRepLegal(long intIdSesion, int intIdMenu, int intIdSoft, string strfiltroPersonal, ref string strMsjUsuario);
        //4.11
        [OperationContract]
        List<Paises> ListarPaises(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);
        //4.12
        [OperationContract]
        List<JerCampDet> ListarFiltroCampJer(long intIdSesion, int intIdMenu, int intIdSoft, string filtro, ref string strMsjUsuario);
        //4.13
        [OperationContract]
        bool IUUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, UnidadOrg objDatos, ref string strMsjUsuario);
        //4.14
        [OperationContract]
        bool EliminmarUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdUniOrg, ref string strMsjUsuario);
        //4.15
        [OperationContract]
        List<UnidadOrg> ConsultarDetalleUndOrgCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUndOrg, ref string strMsjUsuario);
        //4.17
        [OperationContract]
        List<CamposAdicionales2> ListarCamposAdicionalesUO(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intidJerOrg, ref string strMsjUsuario);
        //4.18
        [OperationContract]
        List<UnidadOrg> ObtenerOrganizacionporsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdUniOrg, ref string strMsjUsuario);
        //4.19
        [OperationContract]
        List<Ubigeo> ObtenerUbigeosyListas(long intIdSesion, int intIdMenu, int intIdSoft, int intidTipo, int intidUbigeo, ref string strMsjUsuario);
        #endregion

        #region TGCARGO
        //4.20
        [OperationContract]
        List<Cargo> ListarCargos(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);
        //4.21
        [OperationContract]
        bool IUCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Cargo objDatos, ref string strMsjUsuario);
        //4.23
        [OperationContract]
        bool EliminarCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCargo, ref string strMsjUsuario);
        //4.30
        [OperationContract]
        List<Cargo> ConsultarDetalleCargoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdCargo, ref string strMsjUsuario);
        //4.31
        [OperationContract]
        List<UnidadOrg> ListarCampoUnidOrga(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJerOrg, ref string strMsjUsuario);


        //Borrar Objetos y Métodos que no se usan:
        ////bool InsertarCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, Cargo objDatos, ref string strMsjUsuario);
        ////4.22
        //[OperationContract]
        //bool ActualizarCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, Cargo objDatos, ref string strMsjUsuario);
        ////4.24
        //[OperationContract]
        //List<Cargo> ListarCargosEditar(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, ref string strMsjUsuario);
        ////4.25
        //[OperationContract]
        //List<Cargo> ListarCargosxEstado(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, ref string strMsjUsuario);
        ////4.26
        //[OperationContract]
        //List<Cargo> ListarCargosxDependencia(long intIdSesion, int intIdMenu, int intIdSoft, int intfiltrojer, ref string strMsjUsuario);
        ////4.27
        //[OperationContract]
        //List<Cargo> ListarCargosxDescripcion(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, ref string strMsjUsuario);
        ////4.28
        //[OperationContract]
        //List<CamposAdicionales2> ListarCamposAdicionalesCargos(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);
        ////4.29
        //[OperationContract]
        //List<Cargo> ObtenerValidaciones(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);
        ////4.32
        //[OperationContract]
        //List<UnidadOrg> ObtenerIDjer(long intIdSesion, int intIdMenu, int intIdSoft, int intidCargo, ref string strMsjUsuario);


        #endregion

        #region TGCATEGORIA
        //4.34
        [OperationContract]
        List<Categoria> ListarCategorias(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);
        //4.35
        [OperationContract]
        bool EliminarCategoria(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCategoria, ref string strMsjUsuario);
        //4.33
        [OperationContract]
        bool IUCategoria(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Categoria objDatos, ref string strMsjUsuario);
        //4.39
        [OperationContract]
        List<Categoria> ConsultarDetalleCategoriaxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdCateg, ref string strMsjUsuario);

        #endregion

        #region TGTIPOPERSON
        //4.40
        [OperationContract]
        List<TipoPerson> ListarTipoPerson(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);
        //4.41
        [OperationContract]
        bool IUTipoPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, TipoPerson objDatos, ref string strMsjUsuario);
        //4.42
        [OperationContract]
        bool EliminarTipo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdTipo, ref string strMsjUsuario);
        //4.46
        [OperationContract]
        List<TipoPerson> ConsultarDetalleTipoPerxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdTiPers, ref string strMsjUsuario);

        #endregion

        #region TGGRUPO
        //4.57
        [OperationContract]
        List<Grupo> ConsultarDetalleGrupoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdGrupo, ref string strMsjUsuario);
        //4.58
        [OperationContract]
        bool IUGrupo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Grupo objDatos, ref string strMsjUsuario);
        //4.59
        [OperationContract]
        List<Grupo> ListarGrupos(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);
        //4.60
        [OperationContract]
        bool EliminarGrup(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdGrupo, ref string strMsjUsuario);

        #endregion

        #region TGPLANILLA
        //4.64
        [OperationContract]
        List<Planilla> ConsultarDetallePlanillaxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPlanilla, ref string strMsjUsuario);
        //4.65
        [OperationContract]
        bool EliminarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IdPlanilla, ref string strMsjUsuario);
        //4.68
        [OperationContract]
        bool IUPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Planilla objDatos, ref string strMsjUsuario);
        //4.69
        [OperationContract]
        List<Planilla> ListarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);

        #endregion

        #region TCCOSTO
        //4.71
        [OperationContract]
        List<CCosto> ConsultarDetalleCCostoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdCCosto, ref string strMsjUsuario);
        //4.74
        [OperationContract]
        bool IUCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, CCosto objDatos, ref string strMsjUsuario);
        //4.75
        [OperationContract]
        List<CCosto> ListarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario);
        //4.78
        [OperationContract]
        bool EliminarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdCCosto, ref string strMsjUsuario);

        #endregion TCCOSTO

        #region TGMARCADOR
        //4.47
        [OperationContract]
        List<Marcador> ConsultarDetalleMarcadorxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdMarcador, ref string strMsjUsuario);
        //4.49
        [OperationContract]
        List<Marcador> ListarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, ref string strMsjUsuario);
        //4.52
        [OperationContract]
        bool IUMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Marcador objDatos, ref string strMsjUsuario);
        //4.53
        [OperationContract]
        bool EliminarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdMarcador, ref string strMsjUsuario);

        #endregion


        //4.79
        [OperationContract]
        List<CamposAdicionales2> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, ref string strMsjUsuario);
    }
}
