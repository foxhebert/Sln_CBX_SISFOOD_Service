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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "OrganizacionSrv" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione OrganizacionSrv.svc o OrganizacionSrv.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class OrganizacionSrv : IOrganizacionSrv
    {
        #region MANT. UND ORGANIZACIONAL
        //4.1
        public List<Ubigeo> LlenarUbigeoInverso(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUbigeo, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().LlenarUbigeoInverso(intIdSesion, intIdMenu, intIdSoft, intIdUbigeo, ref strMsjUsuario);

        }
        //4.2
        public List<JerarquiaOrg> ListarCampoJerarquía(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarCampoJerarquía(intIdSesion, intIdMenu, intIdSoft, ref strMsjUsuario);
        }
        //4.3
        public List<UnidadOrg> ListarCampoUnidSup(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJerOrg, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarCampoUnidSup(intIdSesion, intIdMenu, intIdSoft, intIdJerOrg, ref strMsjUsuario);
        }
        //4.4
        public List<Personal> ListarResponsable(long intIdSesion, int intIdMenu, int intIdSoft, string strfiltroPersonal, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarResponsable(intIdSesion, intIdMenu, intIdSoft, strfiltroPersonal, ref strMsjUsuario);
        }
        //4.5
        public List<Ubigeo> ListarUbigeo(long intIdSesion, int intIdMenu, int intIdSoft, int intcodPais, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarUbigeo(intIdSesion, intIdMenu, intIdSoft, intcodPais, ref strMsjUsuario);
        }
        //4.6
        public List<TGTipoEN> ListarDirecFiscal(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarDirecFiscal(intIdSesion, intIdMenu, intIdSoft, ref strMsjUsuario);
        }
        //4.7
        public List<RepLegal> ListarRepLegal(long intIdSesion, int intIdMenu, int intIdSoft, string strfiltroPersonal, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarRepLegal(intIdSesion, intIdMenu, intIdSoft, strfiltroPersonal, ref strMsjUsuario);
        }
        //4.8
        public List<Paises> ListarPaises(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarPaises(intIdSesion, intIdMenu, intIdSoft, ref strMsjUsuario);
        }
        //4.9
        public List<Ubigeo> ListarProvincias(long intIdSesion, int intIdMenu, int intIdSoft, string stridPaisDep, string strCoDep, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarProvincias(intIdSesion, intIdMenu, intIdSoft, stridPaisDep, strCoDep, ref strMsjUsuario);
        }
        //4.10
        public List<UnidadOrgData> ListarUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, int intfiltrojer, int intActivoFilter, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarUnidadOrg(intIdSesion, intIdMenu, intIdSoft, strfilter,intfiltrojer,intActivoFilter, ref strMsjUsuario);
        }
        //4.11
        public List<Ubigeo> ListarDistrict(long intIdSesion, int intIdMenu, int intIdSoft, string strCoDep, string stridpaisProv, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarDistrict(intIdSesion, intIdMenu, intIdSoft, strCoDep, stridpaisProv, ref strMsjUsuario);
        }
        //4.12
        public List<JerCampDet> ListarFiltroCampJer(long intIdSesion, int intIdMenu, int intIdSoft, string filtro, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarFiltroCampJer(intIdSesion, intIdMenu, intIdSoft, filtro, ref strMsjUsuario);
        }
        //4.13
        public bool IUUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, UnidadOrg objDatos, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().IUUnidadOrg_T(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //4.14
        public bool EliminmarUnidadOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdUniOrg, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().EliminmarUnidadOrg(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdUniOrg, ref strMsjUsuario);
        }
        //4.15
        public List<UnidadOrg> ConsultarDetalleUndOrgCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUndOrg, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ConsultarDetalleUndOrgCod(intIdSesion, intIdMenu, intIdSoft, intIdUndOrg, ref strMsjUsuario);
        }
        //4.17
        public List<CamposAdicionales2> ListarCamposAdicionalesUO(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, int intidJerOrg, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarCamposAdicionalesUO(intIdSesion, intIdMenu, intIdSoft, strEntidad, intidJerOrg, ref strMsjUsuario);
        }
        //4.18
        public List<UnidadOrg> ObtenerOrganizacionporsuPK(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdUniOrg, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ObtenerOrganizacionporsuPK(intIdSesion, intIdMenu, intIdSoft, IntIdUniOrg, ref strMsjUsuario);
        }
        //4.19
        public List<Ubigeo> ObtenerUbigeosyListas(long intIdSesion, int intIdMenu, int intIdSoft, int intidTipo, int intidUbigeo, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ObtenerUbigeosyListas(intIdSesion, intIdMenu, intIdSoft, intidTipo, intidUbigeo, ref strMsjUsuario);
        }
        #endregion MANT. UND ORGANIZACIONAL

        #region MANT. CARGO
        //4.20
        public List<Cargo> ListarCargos(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new CargoBL().ListarCargos(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }
        //4.21
        public bool IUCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Cargo objDatos, ref string strMsjUsuario)
        {
            return new CargoBL().IUCargo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //4.23
        public bool EliminarCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCargo, ref string strMsjUsuario)
        {
            return new CargoBL().EliminarCargo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdCargo, ref strMsjUsuario);
        }
        //4.30
        public List<Cargo> ConsultarDetalleCargoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdCargo, ref string strMsjUsuario)
        {
            return new CargoBL().ConsultarDetalleCargoxCod(intIdSesion, intIdMenu, intIdSoft, intIdCargo, ref strMsjUsuario);
        }
        //4.31
        public List<UnidadOrg> ListarCampoUnidOrga(long intIdSesion, int intIdMenu, int intIdSoft, int intIdJerOrg, ref string strMsjUsuario)
        {
            return new CargoBL().ListarCampoUnidOrga(intIdSesion, intIdMenu, intIdSoft, intIdJerOrg, ref strMsjUsuario);
        }

        //Borrar Objetos y Métodos que no se usan:
        ////4.22
        //public bool ActualizarCargo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, Cargo objDatos, ref string strMsjUsuario)
        //{
        //    return new CargoBL().ActualizarCargo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, objDatos, ref strMsjUsuario);
        //}
        ////4.29
        //public List<Cargo> ObtenerValidaciones(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        //{
        //    return new CargoBL().ObtenerValidaciones(intIdSesion, intIdMenu, intIdSoft, ref strMsjUsuario);
        //}
        ////4.24
        //public List<Cargo> ListarCargosEditar(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, ref string strMsjUsuario)
        //{
        //    return new CargoBL().ListarCargosEditar(intIdSesion, intIdMenu, intIdSoft, strfilter, ref strMsjUsuario);
        //}
        ////4.25
        //public List<Cargo> ListarCargosxEstado(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, ref string strMsjUsuario)
        //{
        //    return new CargoBL().ListarCargosxEstado(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, ref strMsjUsuario);
        //}
        ////4.26
        //public List<Cargo> ListarCargosxDependencia(long intIdSesion, int intIdMenu, int intIdSoft, int intfiltrojer, ref string strMsjUsuario)
        //{
        //    return new CargoBL().ListarCargosxDependencia(intIdSesion, intIdMenu, intIdSoft, intfiltrojer, ref strMsjUsuario);
        //}
        ////4.27
        //public List<Cargo> ListarCargosxDescripcion(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, ref string strMsjUsuario)
        //{
        //    return new CargoBL().ListarCargosxDescripcion(intIdSesion, intIdMenu, intIdSoft, strfilter, ref strMsjUsuario);
        //}
        ////4.28
        //public List<CamposAdicionales2> ListarCamposAdicionalesCargos(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        //{
        //    return new CargoBL().ListarCamposAdicionalesCargos(intIdSesion, intIdMenu, intIdSoft, ref strMsjUsuario);
        //}
        ////4.32
        //public List<UnidadOrg> ObtenerIDjer(long intIdSesion, int intIdMenu, int intIdSoft, int intidCargo, ref string strMsjUsuario)
        //{
        //    return new CargoBL().ObtenerIDjer(intIdSesion, intIdMenu, intIdSoft, intidCargo, ref strMsjUsuario);
        //}
        #endregion MANT. CARGO

        #region MANT. CATEGORIA
        //4.33
        public List<Categoria> ListarCategorias(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new CategoriaBL().ListarCategorias(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }
        //4.34
        public bool IUCategoria(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Categoria objDatos, ref string strMsjUsuario)
        {
            return new CategoriaBL().IUCategoria(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //4.35
        public bool EliminarCategoria(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdCategoria, ref string strMsjUsuario)
        {
            return new CategoriaBL().EliminarCategoria(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdCategoria, ref strMsjUsuario);
        }
        //4.39
        public List<Categoria> ConsultarDetalleCategoriaxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdCateg, ref string strMsjUsuario)
        {
            return new CategoriaBL().ConsultarDetalleCategoriaxCod(intIdSesion, intIdMenu, intIdSoft, intIdCateg, ref strMsjUsuario);
        }

        #endregion MANT. CATEGORIA

        #region MANT. TIPO PERSONAL
        //4.40
        public List<TipoPerson> ListarTipoPerson(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new TipoPersonBL().ListarTipoPerson(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }
        //4.41
        public bool IUTipoPersonal(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, TipoPerson objDatos, ref string strMsjUsuario)
        {
            return new TipoPersonBL().IUTipoPersonal(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //4.42
        public bool EliminarTipo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdTipo, ref string strMsjUsuario)
        {
            return new TipoPersonBL().EliminarTipo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdTipo, ref strMsjUsuario);
        }
        //4.46
        public List<TipoPerson> ConsultarDetalleTipoPerxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdTiPers, ref string strMsjUsuario)
        {
            return new TipoPersonBL().ConsultarDetalleTipoPerxCod(intIdSesion, intIdMenu, intIdSoft, IntIdTiPers, ref strMsjUsuario);
        }
        #endregion MANT. TIPO PERSONAL

        #region MANT. GRUPO
        //4.57
        public List<Grupo> ConsultarDetalleGrupoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdGrupo, ref string strMsjUsuario)
        {
            return new GrupoBL().ConsultarDetalleGrupoxCod(intIdSesion, intIdMenu, intIdSoft, intIdGrupo, ref strMsjUsuario);
        }
        //4.58
        public bool IUGrupo(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Grupo objDatos, ref string strMsjUsuario)
        {
            return new GrupoBL().IUGrupo(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //4.59
        public List<Grupo> ListarGrupos(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new GrupoBL().ListarGrupos(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }
        //4.60
        public bool EliminarGrup(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdGrupo, ref string strMsjUsuario)
        {
            return new GrupoBL().EliminarGrup(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdGrupo, ref strMsjUsuario);
        }

        #endregion MANT. GRUPO

        #region MANT. PLANILLA
        //4.64
        public List<Planilla> ConsultarDetallePlanillaxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdPlanilla, ref string strMsjUsuario)
        {
            return new PLanillaBL().ConsultarDetallePlanillaxCod(intIdSesion, intIdMenu, intIdSoft, intIdPlanilla, ref strMsjUsuario);
        }
        //4.65
        public bool EliminarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IdPlanilla, ref string strMsjUsuario)
        {
            return new PLanillaBL().EliminarPlanilla(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, IdPlanilla, ref strMsjUsuario);
        }
        //4.68
        public bool IUPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Planilla objDatos, ref string strMsjUsuario)
        {
            return new PLanillaBL().IUPlanilla(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //4.69
        public List<Planilla> ListarPlanilla(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new PLanillaBL().ListarPlanilla(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }

        #endregion MANT. PLANILLA

        #region MANT. COSTO
        //4.71
        public List<CCosto> ConsultarDetalleCCostoxCod(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdCCosto, ref string strMsjUsuario)
        {
            return new CCostoBL().ConsultarDetalleCCostoxCod(intIdSesion, intIdMenu, intIdSoft, IntIdCCosto, ref strMsjUsuario);
        }
        //4.74
        public bool IUCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, CCosto objDatos, ref string strMsjUsuario)
        {
            return new CCostoBL().IUCCosto(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //4.75
        public List<CCosto> ListarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, int intfiltrojer, ref string strMsjUsuario)
        {
            return new CCostoBL().ListarCCosto(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, intfiltrojer, ref strMsjUsuario);
        }
        //4.78
        public bool EliminarCCosto(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdCCosto, ref string strMsjUsuario)
        {
            return new CCostoBL().EliminarCCosto(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, IntIdCCosto, ref strMsjUsuario);
        }

        #endregion MANT. COSTO

        #region MANT. MARCADOR
        //4.47
        public List<Marcador> ConsultarDetalleMarcadorxCod(long intIdSesion, int intIdMenu, int intIdSoft, int intIdMarcador, ref string strMsjUsuario)
        {
            return new MarcadorBL().ConsultarDetalleMarcadorxCod(intIdSesion, intIdMenu, intIdSoft, intIdMarcador, ref strMsjUsuario);
        }
        //4.49
        public List<Marcador> ListarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intActivoFilter, string strfilter, ref string strMsjUsuario)
        {
            return new MarcadorBL().ListarMarcador(intIdSesion, intIdMenu, intIdSoft, intActivoFilter, strfilter, ref strMsjUsuario);
        }
        //4.52
        public bool IUMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion, Marcador objDatos, ref string strMsjUsuario)
        {
            return new MarcadorBL().IUMarcador(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //4.53
        public bool EliminarMarcador(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdMarcador, ref string strMsjUsuario)
        {
            return new MarcadorBL().EliminarMarcador(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdMarcador, ref strMsjUsuario);
        }

        #endregion MANT. MARCADOR


        //4.79
        public List<CamposAdicionales2> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, string strEntidad, ref string strMsjUsuario)
        {
            return new VariableBL().ListarCamposAdicionales(intIdSesion, intIdMenu, intIdSoft, strEntidad, ref strMsjUsuario);
        }

    }
}
