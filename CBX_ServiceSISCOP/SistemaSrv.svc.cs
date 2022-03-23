using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio.Entidades.Sistema;
using Dominio.Repositorio;
using Dominio.Entidades;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SistemaSrv" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SistemaSrv.svc o SistemaSrv.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SistemaSrv : ISistemaSrv
    {
        //8.1
        public bool ImpresionTicket(Session_Movi objSession, int intId, int tipo, List<Consumo> listaConsumoSelects, ref string strMsjUsuario)
        {
            return new ImprimirBL().ImpresionTicket(objSession, intId,  tipo, listaConsumoSelects, ref strMsjUsuario);
        }
        #region Configuración (TSCONFI)
        //8.5
        public TSConfi ConsultarTSConfi_xCod(long intIdSesion, int intIdMenu, int intIdSoft, string strCoConfi, ref string strMsjUsuario)
        {
            return new TSConfiBL().ConsultarTSConfi_xCod(intIdSesion, intIdMenu, intIdSoft, strCoConfi, ref strMsjUsuario);
        }
        #endregion Configuración TSCONFI
    }
}
