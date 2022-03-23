using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;
using Dominio.Entidades;
using Dominio.Repositorio;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SeguridadSrv" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SeguridadSrv.svc o SeguridadSrv.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SeguridadSrv : ISeguridadSrv
    {
        public string wsVersion()
        {
            //return WebConfigurationManager.AppSettings["wsVersion"].ToString();
            //modificado 06.07.2021
            var secureAppSettings = WebConfigurationManager.GetSection("secureAppSettings") as NameValueCollection;
            return secureAppSettings["wsVersion"].ToString();
        }

        #region Perfil
        //3.2
        public List<TS_PERFIL> ListarPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, ref string strMsjUsuario)
        {
            return new PerfilBL().ListarPerfil(intIdSesion, intIdMenu, intIdSoft, intActivo, strDescripcion, ref strMsjUsuario);
        }
        //3.3
        public List<TS_MENU> ListarMenuSubMenus(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, ref string strMsjUsuario)
        {
            return new PerfilBL().ListarMenuSubMenus(intIdSesion, intIdMenu, intIdSoft, intActivo, strDescripcion, ref strMsjUsuario);
        }
        //3.4
        public bool InsertarOrUpdatePerfil(long intIdSesion, int intIdMenu, int intIdSoft, TS_PERFIL objDatos, List<TT_TSPERFIL_MENU> listaDetallesPerfil, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            return new PerfilBL().IUPerfil_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaDetallesPerfil, intIdUsuario, intTipoOperacion, ref strMsjUsuario);
            //return new PerfilBL().InsertarOrUpdatePerfil(intIdSesion, intIdMenu, intIdSoft, objDatos, listaDetallesPerfil, intIdUsuario, intTipoOperacion, ref strMsjUsuario);
        }
        //3.5
        public bool EliminarPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdPerfil, ref string strMsjUsuario)
        {
            return new PerfilBL().EliminarPerfil(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdPerfil, ref strMsjUsuario);
        }
        //3.6
        public List<TS_PERFIL> ObtenerRegistroPerfil(long intIdSesion, int intIdMenu, int intIdSoft, int IntIdPerfil, ref string strMsjUsuario)
        {
            return new PerfilBL().ObtenerRegistroPerfil(intIdSesion, intIdMenu, intIdSoft, IntIdPerfil, ref strMsjUsuario);
        }

        #endregion

        #region Mant. Usuario
        //3.8
        public List<TG_USUARIO> ListarUsuarios(long intIdSesion, int intIdMenu, int intIdSoft, int intActivo, string strDescripcion, int intTipoFiltro, ref string strMsjUsuario)
        {
            return new UsuarioBL().ListarUsuarios(intIdSesion, intIdMenu, intIdSoft, intActivo, strDescripcion, intTipoFiltro, ref strMsjUsuario);
        }
        //3.9
        public bool EliminarUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuario, int intIdUsu, ref string strMsjUsuario)
        {
            return new UsuarioBL().EliminarUsuario(intIdSesion, intIdMenu, intIdSoft, intIdUsuario, intIdUsu, ref strMsjUsuario);
        }
        //3.10
        public bool InsertOrUpdateUsuario(long intIdSesion, int intIdMenu, int intIdSoft, TG_USUARIO objDatos, List<TSUSUAR_PERFI> listaDetallesUsuarioPerfil, List<TT_TSUSUAR_FILTRO> listaDetallesUsuarioFiltro, int intIdUsuario, int intTipoOperacion, ref string strMsjUsuario)
        {
            return new UsuarioBL().IUsuario_T(intIdSesion, intIdMenu, intIdSoft, objDatos, listaDetallesUsuarioPerfil, listaDetallesUsuarioFiltro, intIdUsuario, intTipoOperacion, ref strMsjUsuario);
            //return new UsuarioBL().InsertOrUpdateUsuario(intIdSesion, intIdMenu, intIdSoft, objDatos, listaDetallesUsuarioPerfil, listaDetallesUsuarioFiltro, intIdUsuario, intTipoOperacion, ref strMsjUsuario);
        }
        //3.11
        public List<TG_USUARIO> ObtenerRegistroUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuar, ref string strMsjUsuario)
        {
            return new UsuarioBL().ObtenerRegistroUsuario(intIdSesion, intIdMenu, intIdSoft, intIdUsuar, ref strMsjUsuario);
        }
        //3.12 - A: Para Móvil
        public List<TG_USUARIO> ValidarUsuario(long intIdSesion, int intIdMenu, int intIdSoft, string strusuario, string strcontraseña, string strCoSoft, ref int Valida, ref string strMsjUsuario)
        {
            return new UsuarioBL().ValidarUsuario(intIdSesion, intIdMenu, intIdSoft, strusuario, strcontraseña, "",strCoSoft, ref Valida, ref strMsjUsuario); //no envia IPPublica
        }
        //3.12 - B: Para website (añadido 06.05.2021)
        public List<TG_USUARIO> ValidarUsuario_(Session_ objSession_, string strusuario, string strcontraseña, string strCoSoft, ref int Valida, ref string strMsjUsuario)
        {
            return new UsuarioBL().ValidarUsuario(objSession_.intIdSesion, 0, objSession_.intIdSoft, strusuario, strcontraseña, objSession_.strIpHost, strCoSoft, ref Valida, ref strMsjUsuario);
        }
        //3.13
        public bool ActualizarPasswrMx(long intIdSesion, int intIdMenu, int intIdSoft, string strUsUsuar, string strCoPassw, string strNwPassw, int intIdUsuario, ref string strEstado, ref string strMsjUsuario)
        {
            return new UsuarioBL().ActualizarPasswrMx(intIdSesion, intIdMenu, intIdSoft, strUsUsuar, strCoPassw, strNwPassw, intIdUsuario, ref strEstado, ref strMsjUsuario);
        }
        //3.14
        public bool RestablecerContra(Session_Movi objSession, string strNwPassw, int intIdPersonal, ref string strEstado, ref string strMsjUsuario)
        {
            return new UsuarioBL().RestablecerContra(objSession, strNwPassw, intIdPersonal, ref strEstado, ref strMsjUsuario);
        }
        //3.19
        public List<TS_MENU_PADRE> MenuPorUsuario(long intIdSesion, int intIdMenu, int intIdSoft, int intIdUsuar, int intIdPerfil, ref string strMsjUsuario)
        {
            return new PerfilBL().MenuPorUsuario(intIdSesion, intIdMenu, intIdSoft, intIdUsuar, intIdPerfil, ref strMsjUsuario);
        }

        #endregion Mant. Usuario
        //3.22 - Cerrar Sesion
        public bool CerrarSession(long intIdSesion, ref string strMsjUsuario)
        {
            return new UsuarioBL().CerrarSession(intIdSesion,ref strMsjUsuario);
        }
        //CAMBIOS AÑADIDOS JULIO - ESUYON
        #region CAMBIOSJULIO
        public string ValidaServer(string Cadena, int Oper)
        {
            return new TSConfiBL().ValidaServer(Cadena, Oper);
        }
        public string GenerarServerEncriptado(Session_Movi objSession, ref int intRpta, string sCadena, int Oper)
        {
            return new TSConfiBL().GenerarServerEncriptado(objSession, ref intRpta, sCadena, Oper);
        }

        #endregion CAMBIOSJULIO
    }
}
