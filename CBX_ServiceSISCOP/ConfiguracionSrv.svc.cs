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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SiscopWeb" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SiscopWeb.svc o SiscopWeb.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ConfiguracionSrv: IConfiguracionSrv
    {
        #region Mant. Jerarquía Organizacional
            //1.1
            public List<JerarquiaOrg> ListarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, int intActivoFilter, ref string strMsjUsuario)
            { 
                return new JerarquiaOrgBL().ListarJerarquiaOrg(intIdSesion, intIdMenu, intIdSoft, strfilter, intActivoFilter, ref strMsjUsuario);
            }
            //1.2
            public List<JerarquiaOrg> ListarJerarquíaSuperior_xNivel(long intIdSesion, int intIdMenu, int intIdSoft, int intNivelJer,ref string strMsjUsuario)
            {
                return new JerarquiaOrgBL().ListarJerarquíaSuperior_xNivel(intIdSesion, intIdMenu, intIdSoft, intNivelJer, ref strMsjUsuario);
            }
            //1.3
            public List<int> ListarNivelJerarquico(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
            {
                return new JerarquiaOrgBL().ListarNivelJerarquico(intIdSesion, intIdMenu, intIdSoft,ref strMsjUsuario);
            }
            //1.4
            public List<DetalleJerarquiaOrg> ConsultarDetalleJerarquia_xCod(long intIdSesion, int intIdMenu, int intIdSoft, string strCoIntJO, ref string strMsjUsuario)
            {
                return new JerarquiaOrgBL().ConsultarDetalleJerarquia_xCod(intIdSesion, intIdMenu, intIdSoft, strCoIntJO, ref strMsjUsuario);
            }
            //1.5
            public int GetNumJeraquia(ref string strMsjUsuario)
            {
                return new JerarquiaOrgBL().GetNumJeraquia(ref strMsjUsuario);
            }
            //1.6
            public JerarquiaOrg ConsultarJerarquiaOrg_xId(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdJerOrg,ref string strMsjUsuario)
            {
                return new JerarquiaOrgBL().ConsultarJerarquiaOrg_xId(intIdSesion, intIdMenu, intIdSoft, IntIdJerOrg, ref strMsjUsuario);
            }
            //1.7
            public bool IUJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion,JerarquiaOrg objDatos, List<DetalleJerarquiaOrg> detalle, ref string strMsjUsuario)
            {
                return new JerarquiaOrgBL().IUJerarquiaOrg_T(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intTipoOperacion, objDatos, detalle, ref strMsjUsuario);
            }
            //1.8
            public bool EliminarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdJerOrg, ref string strMsjUsuario)
            {
                return new JerarquiaOrgBL().EliminarJerarquiaOrg(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, IntIdJerOrg, ref strMsjUsuario);
            }
       
        #endregion Mant. Jerarquía Organizacional

        #region Mant. Unidad Organizacional - Combo Jerarquía
        //1.10
        public List<JerarquiaOrg> ListarCampoJerarquía(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            return new UnidadOrgBL().ListarCampoJerarquía(intIdSesion, intIdMenu, intIdSoft, ref strMsjUsuario);
        }
        #endregion Mant. Unidad Organizacional - Combo Jerarquía

        #region Campos Adicionales
        //1.11
        public List<CamposAdicionales> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, ref string strMsjUsuario)
        {
            return new CamposAdicionalesBL().ListarCamposAdicionales(intIdSesion, intIdMenu, intIdSoft, intActivo, ref strMsjUsuario);
        }
        //1.12
        public List<Entidade> ListaraEntidades(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario)
        {
            return new CamposAdicionalesBL().ListaraEntidades( intIdSesion,  intIdMenu,  intIdSoft, ref  strMsjUsuario);
        }
        #endregion Campos Adicionales

        #region Mant. Tipos del Mant. de Servicio
        //1.13
        public List<TGTipo> ListarTGTipo(Session_Movi objSession, string strGrupo, string strSubGrupo, int IntIdTipo, ref string strMsjUsuario)
        {
            return new GlobalBL().ListarTGTipo(objSession, strGrupo, strSubGrupo, IntIdTipo, ref strMsjUsuario);
        }
        //1.14
        public bool IUTGTipo(Session_Movi objSession, int intTipoOperacion, TGTipo objDatos, ref string strMsjUsuario)
        {
            return new GlobalBL().IUTGTipo(objSession, intTipoOperacion, objDatos, ref strMsjUsuario);
        }
        //1.15
        public bool EliminarTGTipo(Session_Movi objSession, int IntIdTipo, ref string strMsjUsuario)
        {
            return new GlobalBL().EliminarTGTipo(objSession, IntIdTipo, ref strMsjUsuario);
        }

        #endregion Mant. Tipos del Mant. de Servicio

        #region Mant. Configuración
        //1.16
        public List<TSConfi> ListarConfig(Session_Movi objSession, string strCoConfi, ref string strMsjUsuario)
        {
            return new TSConfiBL().ListarConfig(objSession, strCoConfi, ref strMsjUsuario);
        }
        //1.17
        public bool ActualizarConfig(Session_Movi objSession, List<TSConfi> detalleConfig, ref string strMsjUsuario)
        {
            return new TSConfiBL().ActualizarConfig(objSession, detalleConfig, ref strMsjUsuario);
        }
        #endregion Mant. Configuración




        #region Depurar
        ////1.7
        //public bool InsertarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, JerarquiaOrg objDatos, List<DetalleJerarquiaOrg> detalle, ref string strMsjUsuario)
        //{
        //    return new JerarquiaOrgBL().InsertarJerarquiaOrg(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, objDatos, detalle, ref strMsjUsuario);
        //}
        //public bool ActualizarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, JerarquiaOrg objDatos, List<DetalleJerarquiaOrg> detalle, ref string strMsjUsuario)
        //{
        //    return new JerarquiaOrgBL().ActualizarJerarquiaOrg(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, objDatos, detalle, ref strMsjUsuario);
        //}
        #endregion Depurar

        //método de pruebas
        public EN_TMEncuesta Datos_EnviarRespuesta_Encuesta_JSql(string JSON)
        {
            return new TSConfiBL().Datos_EnviarRespuesta_Encuesta_JSql(JSON);
        }
    }
}
