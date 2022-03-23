using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISeguridadSrv" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISeguridadSrv
    {
        //3.1
        [OperationContract]
        string wsVersion();

        #region Mant. Perfil
        //3.2
        [OperationContract]
        List<TS_PERFIL> ListarPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, ref string strMsjUsuario);
        //3.3
        [OperationContract]
        List<TS_MENU> ListarMenuSubMenus(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, ref string strMsjUsuario);
        //3.4
        [OperationContract]
        bool InsertarOrUpdatePerfil(long intIdSesion, int intIdMenu, int intIdSoft, TS_PERFIL objDatos, List<TT_TSPERFIL_MENU> listaDetallesPerfil, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario);
        //3.5
        [OperationContract]
        bool EliminarPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdPerfil, ref string strMsjUsuario);
        //3.6
        [OperationContract]
        List<TS_PERFIL> ObtenerRegistroPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdPerfil, ref string strMsjUsuario);

        #endregion Mant. Perfil

        #region Mant. Usuario
        //3.8
        [OperationContract]
        List<TG_USUARIO> ListarUsuarios(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, int intTipoFiltro, ref string strMsjUsuario);
        //3.9
        [OperationContract]
        bool EliminarUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdUsu, ref string strMsjUsuario);
        //3.10
        [OperationContract]
        bool InsertOrUpdateUsuario(long intIdSesion, int intIdMenu, int intIdSoft, TG_USUARIO objDatos, List<TSUSUAR_PERFI> listaDetallesUsuarioPerfil, List<TT_TSUSUAR_FILTRO> listaDetallesUsuarioFiltro, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario);
        //3.11
        [OperationContract]
        List<TG_USUARIO> ObtenerRegistroUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuar, ref string strMsjUsuario);
        //3.12 - A: Para Móvil
        [OperationContract]
        List<TG_USUARIO> ValidarUsuario(long intIdSesion, int intIdMenu, int intIdSoft, string strusuario, string strcontraseña, string strCoSoft, ref int Valida, ref string strMsjUsuario);
        //3.12 - B: Para website (añadido 06.05.2021)
        [OperationContract]
        List<TG_USUARIO> ValidarUsuario_(Session_ objSession_, string strusuario, string strcontraseña, string strCoSoft, ref int Valida, ref string strMsjUsuario);
        //3.13
        [OperationContract]
        List<TS_MENU_PADRE> MenuPorUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuar, int intIdPerfil, ref string strMsjUsuario);
        //3.14
        [OperationContract]
        bool ActualizarPasswrMx(long intIdSesion, int intIdMenu, int intIdSoft, string strUsUsuar, string strCoPassw, string strNwPassw, int intIdUsuario, ref string strEstado, ref string strMsjUsuario);
        //3.15
        [OperationContract]
        bool RestablecerContra(Session_Movi objSession, string strNwPassw, int intIdPersonal, ref string strEstado, ref string strMsjUsuario);

        #endregion Mant. Usuario

        //3.22 Cerrar Sesion
        [OperationContract]
        bool CerrarSession(long intIdSesion, ref string strMsjUsuario);

        //CAMBIOS AÑADIDOS JULIO - ESUYON
        #region CAMBIOSJULIO
        //AÑADIDO 30.06.2021
        [OperationContract]
        string ValidaServer(string Cadena, int Oper);

        //pruebas 30.06.2021
        [OperationContract]
        string GenerarServerEncriptado(Session_Movi objSession, ref int intRpta, string sCadena, int Oper);
        #endregion CAMBIOSJULIO
    }
}
