using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class PermisoMasivo
    {
        [DataMember] public string EMPRESA { get; set; }
        [DataMember] public string COD_EMP { get; set; }
        [DataMember] public string NOMBRES { get; set; }
        [DataMember] public string COD_JUSTI { get; set; }
        [DataMember] public string DSCPERMISO { get; set; }
        [DataMember] public string FECHAINICIO { get; set; }
        [DataMember] public string FECHAFIN { get; set; }
        [DataMember] public string HORAINICIO { get; set; }
        [DataMember] public string HORAFIN { get; set; }
        [DataMember] public string CAMBIODIA { get; set; }//AÑADIDO 25.10.2021
        [DataMember] public string COMENTARIO { get; set; }
        [DataMember] public int INTIDPROCESO { get; set; }
        [DataMember] public string OBSERVACION { get; set; }
        [DataMember] public bool FLAGOBSERVADO { get; set; }
        [DataMember] public int ESTADO_FINAL { get; set; }
        [DataMember] public int NDIAS { get; set; }//AÑADIDO 25.10.2021
    }
}
