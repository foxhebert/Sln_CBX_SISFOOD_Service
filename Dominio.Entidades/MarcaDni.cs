using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Dominio.Entidades
{
    public class MarcaDni
    {

        [DataMember] public bool bitHabilitarMarcaDNI { get; set; }
        [DataMember] public string dttFechaInicioVegencia { get; set; }
        [DataMember] public string dttFechaFinVegencia { get; set; }
        [DataMember] public bool bitHabilitarSupervisorCom { get; set; }
        [DataMember] public int intIdMarca{ get; set; } //03.05.2021
        [DataMember] public int intIdConsumoAuto { get; set; } //03.05.2021


    }
}
