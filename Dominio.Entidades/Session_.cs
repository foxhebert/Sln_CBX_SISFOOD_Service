using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Session_
    {
        //Clase creada el 05.05.2021
        [DataMember] public long intIdSesion { get; set; }
        [DataMember] public int intIdSoft { get; set; }
        [DataMember] public int intIdUsuar { get; set; }
        [DataMember] public int intIdSitua { get; set; }
        [DataMember] public DateTime? dttFeSesio { get; set; }
        [DataMember] public string strNoHost { get; set; }
        [DataMember] public string strNuHost { get; set; }
        [DataMember] public string strIpHost { get; set; }
        [DataMember] public int intIDTerminal { get; set; }
    }
}
