using Dominio.Entidades;
using Dominio.Repositorio.Util;
using Infraestructura.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using BIXOLON_SamplePg;
using System.Data;

namespace Dominio.Repositorio
{
    public class ImprimirBL
    {
        private ConsumoDAO objDao = new ConsumoDAO();
        private GlobalDAO objGlb = new GlobalDAO();//añadido 15.10.2021

        //8.1
        public bool ImpresionTicket(Session_Movi objSession, int intId, int tipo, List<Consumo> listaConsumoSelects, ref string strMsjUsuario)
        {
            bool rpta = false;
            List<Imprimir> datosPrint = new List<Imprimir>();
            try
            {
                int intResult = 0;
                string strMsjDB = "";
                if (tipo == 0) //VENTANA DE GESTION DE CONSUMOS
                {
                    //Atiende todos los consumos de diferentes idAsistencia (lista de idasistencias obtenido desde listado principal de GESTION DE CONSUMOS)

                    DataTable tbList_ = SerealizeList(listaConsumoSelects);
                    tbList_.Clear();
                    int contadorRpta = 0;
                    int totalfilas = listaConsumoSelects.Count();
                    for (int i = 0; i < listaConsumoSelects.Count(); i++)
                    {
                        intId = listaConsumoSelects[i].intIdConsumo;

                        datosPrint = objDao.DatosImpresion(objSession, intId, tipo, tbList_, ref intResult, ref strMsjDB, ref strMsjUsuario);
                        if (datosPrint.Count > 0)
                        {
                            //if (BixolonPrint(datosPrint)) //lLAMAR A BixolonPrint_2 08.11.2021
                            if (BixolonPrint_2(datosPrint)) //lLAMAR A BixolonPrint_2 08.11.2021
                            {
                                contadorRpta = contadorRpta + 1;
                            }
                        }
                        else
                        {
                            contadorRpta = 0;
                        }

                    }

                    if (contadorRpta > 0)
                    {
                        strMsjDB = "Se imprimieron " + contadorRpta.ToString() + " tickets  correctamente.";
                        Log.AlmacenarLogMensaje("[ImpresionTicket - Tipo " + tipo.ToString() + "] => " + strMsjDB);
                        rpta = true;
                    }
                    else
                    {
                        strMsjDB = "No se pudo realizar la impresión de los tickets";
                        Log.AlmacenarLogMensaje("[ImpresionTicket - Tipo " + tipo.ToString() + "] => " + strMsjDB);
                        rpta = false;
                    }

                }

                if (tipo == 1) //VENTANA DE GESTION DE CONSUMOS - MODAL DE ATENCION ESPECIFICA
                {
                    //Atiende los idconsumos de un único idAsistencia (lista de idconsumos obtenido desde GESTION DE CONSUMOS - MODAL ATENCION ESPECIFICA)
                    DataTable tbList = SerealizeList(listaConsumoSelects);

                    datosPrint = objDao.DatosImpresion(objSession, intId, tipo, tbList, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    if (datosPrint.Count > 0)
                    {
                            //if (BixolonPrint(datosPrint))
                            if (BixolonPrint_2(datosPrint))
                            {
                            strMsjDB = "Se imprimió correctamente";
                            Log.AlmacenarLogMensaje("[ImpresionTicket - Tipo " + tipo.ToString() + "] => " + strMsjDB);
                            rpta = true;
                        }
                        else
                        {
                            strMsjDB = "No se pudo realizar la impresión";
                            Log.AlmacenarLogMensaje("[ImpresionTicket - Tipo " + tipo.ToString() + "] => " + strMsjDB);
                            rpta = false;
                        }
                    }
                    else
                    {
                        strMsjDB = "No Existen Datos para Imprimir";
                        Log.AlmacenarLogMensaje("[ImpresionTicket - Tipo " + tipo.ToString() + "] => " + strMsjDB);
                        rpta = false;
                    }

                }
                if (tipo == 2) //VENTANA DE TOMA DE CONSUMO.
                {
                    //Atiende todos los idconsumos de una única idasistencia (solo recibe idAsistencia desde la ventana de TOMA DE CONSMO) Sea Marca con DNI sin seleccionar Consumos o Cualquier otra marca seleccionando consumos.
                    DataTable tbList = SerealizeList(listaConsumoSelects);
                    tbList.Clear();
                    datosPrint = objDao.DatosImpresion(objSession, intId, tipo, tbList, ref intResult, ref strMsjDB, ref strMsjUsuario);
                    if (datosPrint.Count > 0)
                    {
                       // if (BixolonPrint(datosPrint))
                            if (BixolonPrint_2(datosPrint))
                        {
                            strMsjDB = "Se imprimió correctamente";
                            Log.AlmacenarLogMensaje("[ImpresionTicket - Tipo " + tipo.ToString() + "] => " + strMsjDB);
                            rpta = true;

                            ////Añadido 15.10.2021: Si la rpta es true entonces Actualizar el estado de impresión.
                            //bool RptaUpEtiqueta = false;

                            //int intResult2 = 0;
                            //RptaUpEtiqueta = objGlb.UpEtiquetaImpresa(intId, ref intResult2, ref strMsjDB, ref strMsjUsuario);
                            //if (intResult2 == 1)
                            //{
                            //    Log.AlmacenarLogMensaje("[ImpresionTicket - Tipo " + tipo.ToString() + " - UpdateEstadoEtiqueta] => OK");
                            //}
                            ////fin
                        }
                        else
                        {
                            strMsjDB = "No se pudo realizar la impresión";
                            Log.AlmacenarLogMensaje("[ImpresionTicket - Tipo " + tipo.ToString() + "] => " + strMsjDB);
                            rpta = false;
                        }
                    }
                    else
                    {
                        strMsjDB = "No Existen Datos para Imprimir";
                        Log.AlmacenarLogMensaje("[ImpresionTicket - Tipo "+ tipo.ToString() + "] => " + strMsjDB);
                        rpta = false;
                    }


                }

                if (rpta == false)
                {
                    if (!strMsjDB.Equals(""))
                    {
                        Log.AlmacenarLogMensaje("[ImprimirTicket] => Respuesta del método : " + strMsjDB);
                        if (strMsjUsuario.Equals(""))
                            strMsjUsuario = strMsjDB;
                    }
                }
            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (ImpresionTicket)");
            }

            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: Exception");
                throw new Exception("Error General (ImpresionTicket)");
            }
            return rpta;//pendiente cambiar el tipo de dato de salida.
        }
        //8.2: Esto es lo que imprime en BIXOLON 
        private bool BixolonPrint(List<Imprimir> datos)
        {
            bool ok = false;
            try
            {
                string IP = ConfigurationManager.AppSettings["IPPrinter"];
                int PUERTO = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoPrinter"]);

                if (IP.Equals("") && PUERTO == 0)
                    throw new Exception("Falta configurar la dirección IP y puerto para la impresión de Tickets");

                //Microsoft Print to PDF

                //if (BXLAPI.PrinterOpen(BXLAPI.ILan, "Microsoft Print to PDF", PUERTO, 0, 0, 0) != BXLAPI.BXL_SUCCESS)
                if (BXLAPI.PrinterOpen(BXLAPI.ILan, IP, PUERTO, 0, 0, 0) != BXLAPI.BXL_SUCCESS)
                        throw new Exception("Conexión fallida [TCP/IP] para la impresión");

                //pruebas de impresion con datos en duro //INICIO
                string empresa = datos[0].empresa;//"Empresa Prueba";
                string comensal = datos[0].comensal;//"Empresa Prueba";
                string numdoc = datos[0].numdoc;//"Empresa Prueba";
                string tipdoc = datos[0].tipdoc;//"Empresa Prueba";
                string fecha = datos[0].fecha;//"Empresa Prueba";
                string tipServ = datos[0].tipServ;//"Empresa Prueba";
                //FIN

                BXLAPI.TransactionStart();
                BXLAPI.InitializePrinter();
                BXLAPI.SetCharacterSet(BXLAPI.BXL_CS_WPC1252);
                BXLAPI.SetInterChrSet(BXLAPI.BXL_ICS_USA);


                BXLAPI.PrintText("SISFOODWEB" + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(empresa + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //BXLAPI.PrintText(strTipoDocu, BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                //BXLAPI.PrintText(datos[0].ndocu + " ", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(tipdoc, BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(numdoc + " ", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText("    FECHA: " + datos[0].fecha + "\n", BXLAPI.BXL_ALIGNMENT_RIGHT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT);

                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(comensal + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(tipServ + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_REVERSE, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                //BXLAPI.PrintText(datos[0].nomcli + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //BXLAPI.PrintText(comentario + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_REVERSE, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(new string('=', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(" CANTIDAD |   PRECIO  \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //BXLAPI.PrintText(" CANTIDAD |   CÓDIGO  |\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(" SERVICIO \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //BXLAPI.PrintText(" D E S C R I P C I Ó N \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                BXLAPI.PrintText(new string('=', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                for (int i = 0; i < datos.Count(); i++)
                {
                    if ((datos[i].cant % 1) == 0)
                        BXLAPI.PrintText(Convert.ToInt32(datos[i].cant) + "  ", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    else
                        BXLAPI.PrintText(datos[i].cant + "  ", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);

                    //int vacias = (15 - datos[i].codf.Length);
                    int vacias = (15 - (datos[i].precio.Length+ datos[i].simbolo.Length));
                    if (vacias < 0)
                        vacias = 0;
                    BXLAPI.PrintText(" " + datos[i].simbolo + datos[i].precio + new string(' ', vacias) + " \n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_REVERSE | BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    //BXLAPI.PrintText(" " + datos[i].codf + new string(' ', vacias) + " \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_REVERSE | BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    BXLAPI.PrintText(datos[i].descr + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                    //if (!datos[i].rollos.Equals(""))
                    //    BXLAPI.PrintText(datos[i].rollos + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                    BXLAPI.PrintText(new string('_', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                    BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                }

                BXLAPI.CutPaper();

                if (BXLAPI.TransactionEnd(true, 3000 /* 3 seconds */) != BXLAPI.BXL_SUCCESS)
                {
                    // failed to read a response from the printer after sending the print-data.                    
                    throw new Exception("TransactionEnd failed, No se pudo Imprimir la etiqueta");
                }
                ok = true;


            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (BixolonPrint)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: Exception");
                throw new Exception("Error General (BixolonPrint)");
            }
            finally
            {
                BXLAPI.PrinterClose();
            }
            return ok;
        }


        //8.2: Esto es lo que imprime en BIXOLON MODELO #2 - AÑADIDO POR HGM 08.11.2021 
        private bool BixolonPrint_2(List<Imprimir> datos)
        {
            bool ok = false;
            try
            {
                string IP = ConfigurationManager.AppSettings["IPPrinter"];
                int PUERTO = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoPrinter"]);

                if (IP.Equals("") && PUERTO == 0)
                    throw new Exception("Falta configurar la dirección IP y puerto para la impresión de Tickets");

                //Microsoft Print to PDF

                //if (BXLAPI.PrinterOpen(BXLAPI.ILan, "Microsoft Print to PDF", PUERTO, 0, 0, 0) != BXLAPI.BXL_SUCCESS)
                if (BXLAPI.PrinterOpen(BXLAPI.ILan, IP, PUERTO, 0, 0, 0) != BXLAPI.BXL_SUCCESS)
                    throw new Exception("Conexión fallida [TCP/IP] para la impresión");

                //pruebas de impresion con datos en duro //INICIO
                string empresa = datos[0].empresa; //"EMPRESA DE SERVICIOS INFORMATICOS Y OTROS TIPOS DE SERVICIOS EMPRESA DE SERVICIOS INFORMATICOS Y OTROS TIPOS DE SERVICIOS";// //"Empresa Prueba";
                string comensal = datos[0].comensal;//"Empresa Prueba";
                string numdoc = datos[0].numdoc;//"Empresa Prueba";
                string tipdoc = datos[0].tipdoc;//"Empresa Prueba";
                string fecha = datos[0].fecha;//"Empresa Prueba";
                string tipServ = datos[0].tipServ;//"Empresa Prueba";
                //FIN

                BXLAPI.TransactionStart();
                BXLAPI.InitializePrinter();
                BXLAPI.SetCharacterSet(BXLAPI.BXL_CS_WPC1252);
                BXLAPI.SetInterChrSet(BXLAPI.BXL_ICS_USA);

                //Software
                BXLAPI.PrintText("SISFOODWEB" + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                ////////int empresaCount = empresa.Length;
                //////////string str = yourStringVariable.Substring(0, 5);
                ////////var primerRowEmpresa = empresa.Substring(0, 27); ;
                ////////var secondRowEmpresa = (empresa);

                ////////if (empresaCount < 28) { empresa = primerRowEmpresa;  }


                /////////////////////////////////////////AÑADIDO HGM 04.11.2021
                string s = empresa;
                var split = s.Select((c, index) => new { c, index })
                .GroupBy(x => x.index / 26)//Por cada 27 caracteres
                .Select(group => group.Select(elem => elem.c))
                .Select(chars => new string(chars.ToArray()));
                //Cada 27 carateres pasara a imprimir una linea
                foreach (var str in split)
                    //Console.WriteLine(str);
                BXLAPI.PrintText( str + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                ///////////////////////////////////////////////////////////


                //Empresa o Cliente (Razon Social)
                //BXLAPI.PrintText("EMPRESA DE SERVICIOS INFORMATICOS Y OTROS TIPOS DE SERVICIOS" + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                //COMENTADO HGM  BXLAPI.PrintText(empresa + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);

                //Líneas vacías x 1
                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
               
                //FECHA HORA
                BXLAPI.PrintText("  FECHA: " + datos[0].fecha + "    " + "\n", BXLAPI.BXL_ALIGNMENT_RIGHT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT )  ;
                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                //TIPO DE DOCUMENTO
                BXLAPI.PrintText(tipdoc, BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText(numdoc + " ", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_1WIDTH | BXLAPI.BXL_TS_1HEIGHT);
                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                //Nombres del Comensal
                BXLAPI.PrintText(comensal + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //Líneas vacías x 1
                BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                
                //Tipo de Servicio
                BXLAPI.PrintText(tipServ + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_REVERSE, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);

                //Separador dibujado con simbolo igual
                BXLAPI.PrintText(new string('=', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //ENCABEZADO
                BXLAPI.PrintText(" CANTIDAD | SERVICIO \n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //SEPARADO 
                BXLAPI.PrintText(new string('=', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                //CUERPO
                /*
                for (int i = 0; i < datos.Count(); i++)
                {
                    if ((datos[i].cant % 1) == 0)
                        BXLAPI.PrintText("   " + Convert.ToInt32(datos[i].cant) + "  | " + datos[i].descr + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    //BXLAPI.PrintText("   " + Convert.ToInt32(datos[i].cant) + "  | " + "DESAYUNO DPRUEBAMAXIMO DE CARACTERES QUESOPORTA LAAPLICACION" + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                        //BXLAPI.PrintText(Convert.ToInt32(datos[i].cant) + "  ", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    else
                        BXLAPI.PrintText("   " + datos[i].cant + " | " + datos[i].descr + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    //BXLAPI.PrintText("   " + datos[i].cant + " | " + "DESAYUNO PRUEBA MAXIMO DE CARACTERES QUE SOPORTA LA APLICACI" + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);


                    BXLAPI.PrintText(new string('_', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                    BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);



                }
                */


                for (int i = 0; i < datos.Count(); i++)
                {
                    if ((datos[i].cant % 1) == 0) { 

                        BXLAPI.PrintText("   " + Convert.ToInt32(datos[i].cant) + " | ", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);



                        /////////////////////////////////////////AÑADIDO HGM 04.11.2021
                        string m = datos[i].descr;// "DESAYUNO PRUEBA MAXIMO DE CARACTERES QUE SOPORTA LA APLICACI DESAYUNO PRUEBA MAXIMO DE CARACTERES QUE SOPORTA LA APLICACI";//datos[i].descr;
                        var split2 = m.Select((c, index) => new { c, index })
                        .GroupBy(x => x.index / 31)//Por cada 27 caracteres
                        .Select(group => group.Select(elem => elem.c))
                        .Select(chars => new string(chars.ToArray()));
                        //Cada 27 carateres pasara a imprimir una linea
                        foreach (var str in split2) {

                            if (split2.First() == str) { 
                                Console.WriteLine(str);
                                BXLAPI.PrintText( str + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                            }
                            else { 
                                BXLAPI.PrintText("       " + str + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                            }
                        }
                        ///////////////////////////////////////////////////////////



                        //BXLAPI.PrintText("   " + Convert.ToInt32(datos[i].cant) + "  | " + "DESAYUNO DPRUEBAMAXIMO DE CARACTERES QUESOPORTA LAAPLICACION" + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);
                    }
                    else
                        BXLAPI.PrintText("   " + datos[i].cant + " | " + datos[i].descr + "\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_BOLD, BXLAPI.BXL_TS_1HEIGHT);

                    BXLAPI.PrintText(new string('_', 40) + "\n", BXLAPI.BXL_ALIGNMENT_CENTER, BXLAPI.BXL_FT_DEFAULT, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);
                    BXLAPI.PrintText("\n", BXLAPI.BXL_ALIGNMENT_LEFT, BXLAPI.BXL_FT_FONTB, BXLAPI.BXL_TS_0WIDTH | BXLAPI.BXL_TS_0HEIGHT);



                }







                BXLAPI.CutPaper();

                if (BXLAPI.TransactionEnd(true, 3000 /* 3 seconds */) != BXLAPI.BXL_SUCCESS)
                {
                    // failed to read a response from the printer after sending the print-data.                    
                    throw new Exception("TransactionEnd failed, No se pudo Imprimir la etiqueta");
                }
                ok = true;


            }
            catch (SqlException ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: SqlException");
                throw new Exception("Ocurrió un error en BD (BixolonPrint)");
            }
            catch (Exception ex)
            {
                Log.AlmacenarLogError(ex, "ImprimirBL.cs: Exception");
                throw new Exception("Error General (BixolonPrint)");
            }
            finally
            {
                BXLAPI.PrinterClose();
            }
            return ok;
        }


        //-- Métodos complementarios: -----------------------------------------------------------------------------------------------------------
        //8.3
        private static string Etiquetas_FormatearTexto(string Texto, int Tamaño)
        {
            string objRetVal = string.Empty;
            try
            {
                objRetVal = Texto.ToUpper().Trim();
                objRetVal = objRetVal.Replace("Á", "A");
                objRetVal = objRetVal.Replace("É", "E");
                objRetVal = objRetVal.Replace("Í", "I");
                objRetVal = objRetVal.Replace("Ó", "O");
                objRetVal = objRetVal.Replace("Ú", "U");
                objRetVal = objRetVal.Replace("Ñ", "N");
                objRetVal = objRetVal.PadRight(Tamaño, ' ');
                objRetVal = objRetVal.Substring(0, Tamaño).Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRetVal;
        }
        //8.4
        private DataTable SerealizeList(List<Consumo> lista)
        {
            DataTable table = new DataTable();

            table.Columns.Add("intIdConsumo", typeof(int));
            table.Columns.Add("bitFlConsumido", typeof(int));
            table.Columns.Add("intCantidad", typeof(int));

            foreach (var item in lista)
            {
                DataRow rows = table.NewRow();
                rows["intIdConsumo"] = item.intIdConsumo;
                rows["bitFlConsumido"] = item.bitFlConsumido;
                rows["intCantidad"] = item.intCantidad;

                table.Rows.Add(rows);
            }

            return table;
        }
        //-------------------------------------------------------------------------------------------------------------

    }
}
