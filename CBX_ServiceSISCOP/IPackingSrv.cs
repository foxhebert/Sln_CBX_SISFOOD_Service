using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPackingSrv" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPackingSrv
    {
        #region Cliente y combo centro almacenamiento

        [OperationContract]
        List<MaestroCaracteres> MaestroMaxCaracteres(string strTableName);

        #endregion

    }
}
