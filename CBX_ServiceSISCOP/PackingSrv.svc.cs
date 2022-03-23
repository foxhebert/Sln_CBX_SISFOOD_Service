using Dominio.Entidades;
using Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CBX_ServiceSISCOP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PackingSrv" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PackingSrv.svc o PackingSrv.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PackingSrv : IPackingSrv
    {
        public List<MaestroCaracteres> MaestroMaxCaracteres(string strTableName)
        {
            return new ClienteBL().MaestroMaxCaracteres(strTableName);
        }
    }
}
