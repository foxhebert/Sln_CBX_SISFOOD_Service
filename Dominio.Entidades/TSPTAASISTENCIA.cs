using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TSPTAASISTENCIA
    {
        [DataMember] public int anio { get; set; }
        [DataMember] public int mes { get; set; }
        [DataMember] public int asistencia { get; set; }
        [DataMember] public int faltas { get; set; }
    }
}
