using Dominio.Entidades.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Dominio.Entidades;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISistemaSrv" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISistemaSrv
    {
        //8.1
        [OperationContract]
        bool ImpresionTicket(Session_Movi objSession, int intId, int tipo, List<Consumo> listaConsumoSelects, ref string strMsjUsuario);
        
        /*Configuración*/
        #region Configuración (TSCONFI)
        //8.5
        [OperationContract]
        TSConfi ConsultarTSConfi_xCod(long intIdSesion, int intIdMenu, int intIdSoft, string strCoConfi, ref string strMsjUsuario);

        #endregion Configuración TSCONFI
    }
}
