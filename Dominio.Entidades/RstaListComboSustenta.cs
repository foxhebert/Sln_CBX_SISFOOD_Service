﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio.Entidades
{
    [DataContract]
    public class RstaListComboSustenta
    {
        [DataMember]
        public int intIdEntidad { get; set; }
        [DataMember]
        public string strDeEntidad { get; set; }
    }
}
