﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class CorreoEmp
    {
        public int intIdPersonal { get; set; }
        public string strNomCompleto { get; set; }
        public string strCorreo { get; set; }
        public string strNumDocNue { get; set; }

        //añadidos 01.07.2021
        public string strOC { get; set; }
        public string strRUC { get; set; }
        public string strCadena { get; set; }
        public string strCadena2 { get; set; }//añadido 06.07.2021
        //public string strIP { get; set; }
        //public string strMAC { get; set; }
        public string strDestinos { get; set; }
    }
}
