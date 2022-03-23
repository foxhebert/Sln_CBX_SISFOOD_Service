using Dominio.Entidades;
using Dominio.Entidades.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISiscopWeb" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IConfiguracionSrv
    {

        #region Mant. Jerarquía Organizacional
            //1.1
            [OperationContract]
            List<JerarquiaOrg> ListarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, string strfilter, int intActivoFilter, ref string strMsjUsuario);
            //1.2
            [OperationContract]
            List<JerarquiaOrg> ListarJerarquíaSuperior_xNivel(long intIdSesion, int intIdMenu, int intIdSoft, int intNivelJer,ref string strMsjUsuario);
            //1.3
            [OperationContract]
            List<int> ListarNivelJerarquico(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);
            //1.4
            [OperationContract]
            List<DetalleJerarquiaOrg> ConsultarDetalleJerarquia_xCod(long intIdSesion, int intIdMenu, int intIdSoft, string strCoIntJO, ref string strMsjUsuario);
            //1.5
            [OperationContract]
            int GetNumJeraquia(ref string strMsjUsuario);
            //1.6
            [OperationContract]
            JerarquiaOrg ConsultarJerarquiaOrg_xId(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdJerOrg,ref string strMsjUsuario);
            //1.7
            [OperationContract]
            bool IUJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intTipoOperacion,JerarquiaOrg objDatos, List<DetalleJerarquiaOrg> detalle, ref string strMsjUsuario);
            //1.8
            [OperationContract]
            bool EliminarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int IntIdJerOrg, ref string strMsjUsuario);

        #endregion Mant. Jerarquía Organizacional

        #region Mant. Unidad Organizacional - Combo Jerarquía
            //1.10
            [OperationContract]//corrección y ordenamiento del 12.03.2021
            List<JerarquiaOrg> ListarCampoJerarquía(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);

        #endregion Mant. Unidad Organizacional - Combo Jerarquía

        #region Campos Adicionales
            //1.11
            [OperationContract]
            List<CamposAdicionales> ListarCamposAdicionales(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, ref string strMsjUsuario);
            //1.12
            [OperationContract]
            List<Entidade> ListaraEntidades(long intIdSesion, int intIdMenu, int intIdSoft, ref string strMsjUsuario);

        #endregion Campos Adicionales

        #region Mant. Tipos del Mant. de Servicio
            //1.13
            [OperationContract]//AÑADIDO 12.03.2021
            List<TGTipo> ListarTGTipo(Session_Movi objSession, string strGrupo, string strSubGrupo, int IntIdTipo, ref string strMsjUsuario);
            //1.14
            [OperationContract]
            bool IUTGTipo(Session_Movi objSession, int intTipoOperacion, TGTipo objDatos, ref string strMsjUsuario);
            //1.15
            [OperationContract]
            bool EliminarTGTipo(Session_Movi objSession, int IntIdTipo, ref string strMsjUsuario);

        #endregion Mant. Tipos del Mant. de Servicio

        #region Mant. Configuración
            //1.16
            [OperationContract]
            List<TSConfi> ListarConfig(Session_Movi objSession, string strCoConfi, ref string strMsjUsuario);
            //1.17
            [OperationContract]
            bool ActualizarConfig(Session_Movi objSession, List<TSConfi> detalleConfig, ref string strMsjUsuario);
        #endregion Mant. Configuración



        #region Depurar
        ////1.7 - depurar
        //[OperationContract]
        //bool InsertarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, JerarquiaOrg objDatos, List<DetalleJerarquiaOrg> detalle, ref string strMsjUsuario);
        //[OperationContract]
        //bool ActualizarJerarquiaOrg(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, JerarquiaOrg objDatos, List<DetalleJerarquiaOrg> detalle, ref string strMsjUsuario);
        ////1.9
        #endregion Depurar

        //Pruebas 13.04.2021
        [OperationContract]
        EN_TMEncuesta Datos_EnviarRespuesta_Encuesta_JSql(string JSON);
    }
}
