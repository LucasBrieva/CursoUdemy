using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasWeb.Library
{
    public class LPaginador<T>
    {
        //Cantidad de resultados por página
        private int pagi_quantity = 10;
        //Cantidad de enlaces que se mostrarán como máximo en la barra de navegación
        private int pagi_nav_num_link = 3;
        private int pagi_current;
        //Definimos que irá en el enlace a la página anterior
        private string pagi_nav_previous = " &laquo; Anterior";
        //Definimos que irá en el enlace a la página siguiente
        private string pagi_nav_next = "  Siguiente &raquo; ";
        //Definimos que irá en el enlace a la página siguiente
        private string pagi_nav_first = " &laquo; Primero ";
        private string pagi_nav_last = " Último &raquo; ";
        private string pagi_navegation = null;

        public object[] Paginador(List<T> table, int page, int records, string area, string controller, string action, string host)
        {
            if(records > 0)
            {
                pagi_quantity = records;
            }
            if (page.Equals(0))
            {
                //Si no se hizo click a ninguna página específica, si es la primera vez que se ejecuta el script 
                //pagi_current es la página actual -> Será por defecto la primera
                pagi_current = 1;
            }
            else
            {
                //Si se 'pidió' una página especifica, la página actual será la que se solicitó
                pagi_current = page;
            }
            int pagi_totalRecord = table.Count;
            int pagi_totalRecords = pagi_totalRecord;
            if((pagi_totalRecord % pagi_quantity) > 0)
            {
                pagi_totalRecords += 2;
            }
            int pagi_totalPags = pagi_totalRecords / pagi_quantity;
            if(pagi_current != 1)
            {
                //Si no estamos en la pág 1. Ponemos el enlace "PRIMERA" 
                int pagi_url = 1; // Será el nro de páginas al que enlazamos
                pagi_navegation += "<a class='btn btn-outline-primary btn-sm' style='margin: 2px!important;' href='" + host + "/" + area + "/" + controller + "/" + action + "?id=" + pagi_url + "&records=" + pagi_quantity
                    + "&area=" + area + "'>" + pagi_nav_first + "</a>";

                //Si no estamos en la página. Ponemos el enlace "ANTERIOR"
                pagi_url = pagi_current - 1;
                pagi_navegation += "<a class='btn btn-outline-primary btn-sm' style='margin: 2px!important;' href='" + host + "/" + area + "/" + controller + "/" + action + "?id=" + pagi_url + "&records=" + pagi_quantity
                    + "&area=" + area + "'>" + pagi_nav_previous + "</a>";
            }
            //Si se definió la variable pagi_nav_num_links
            //Calculamos el intervalo para restar y sumar a partir de la pág actual
            double value2 = (pagi_nav_num_link / 2);
            int pagi_nav_interval = Convert.ToInt16(Math.Round(value2));
            //Calculamos desde qué número de páginas se mostrará 
            int pagi_nav_from = pagi_current - pagi_nav_interval;
            //Calculamos hasta que nro de página se mostrará 
            int pagi_nav_to = pagi_current + pagi_nav_interval;
            //Si pagi_nav_from es un nro neg
            if(pagi_nav_from < 1)
            {
                //Le sumamos la cantidad sobrante al final para mantener el nro de enlaces que se quiere mostrar
                pagi_nav_to -= (pagi_nav_from - 1);
                //Establecemos pagi_nav_desde como 1
                pagi_nav_from = 1;
            }
            //Si pagi_nav_hasta es un nro mayor que el total de páginas
            if(pagi_nav_to > pagi_totalPags)
            {
                //Le restamos la cant excedida al comienzo para mantener el nro de enlaces que se quiere mostrar
                pagi_nav_from -= (pagi_nav_from - pagi_totalPags);
                //Establecemos pagi_nav_hasta como el total de páginas
                pagi_nav_to = pagi_totalPags;
                //Hacemos el último ajuste verificando que al cambiar pagi_nav_desde no haya quedado con un valor menor a 1 
                if(pagi_nav_from < 1)
                {
                    pagi_nav_from = 1;
                }

            }
            for(int i = pagi_nav_from; i <= pagi_nav_to; i++)
            {
                //Desde página 1 hasta última página (pagi_totalPags)
                if(i == pagi_current)
                {
                    //Si el nro de página es la actual (pagi_current). Se escribe el nro, pero sin enlace 
                    pagi_navegation += "<span class='btn btn-outline-primary btn-sm' style='margin: 2px!important;' disabled='disabled'>" + i + "</span>";
                }
                else
                {
                    //Si es cualquier otro , se escribe el enlace a dicho nro de página
                    pagi_navegation += "<a class='btn btn-outline-primary btn-sm' style='margin: 2px!important;' href='" + host + "/" + area + "/" + controller + "/" + action + "?id=" + i + "&records=" + pagi_quantity +
                        "&area=" + area + "'>" + i + "</a>";
                }
            }
            if(pagi_current < pagi_totalPags)
            {
                //Si no estamos en la última página, ponemos el enlace "siguiente"
                int pagi_url = pagi_current + 1;
                pagi_navegation += "<a class='btn btn-outline-primary btn-sm' style='margin: 2px!important;' href='" + host + "/" + area + "/" + controller + "/" + action + "?id=" + pagi_url + "&records=" + pagi_quantity +
                        "&area=" + area + "'>" + pagi_nav_next + "</a>";
                //Si no estamos en la última página, Ponemos el enlace "última"
                pagi_url = pagi_totalPags; //Será el nro de páginas al que enlazamos
                pagi_navegation += "<a class='btn btn-outline-primary btn-sm' style='margin: 2px!important;' href='" + host + "/" + area + "/" + controller + "/" + action + "?id=" + pagi_url + "&records=" + pagi_quantity +
                        "&area=" + area + "'>" + pagi_nav_last + "</a>";
            }
            /*Obtención de los registros que se mostrarán en la página actual.
                -----------------------------------------------------------------
            */
            //Calculamos desde que registro se mostrará en esta página
            //Recordemos que el conteo empieza desde CERO.
            int pagi_inital = (pagi_current - 1) * pagi_quantity;
            //Consulta SQL. Devuelve cantidad de registros empezando desde pagi_inicial
            var query = table.Skip(pagi_inital).Take(pagi_quantity).ToList();
            /*
             Generación de la información sobre los registros mostrados. 
            -------------------------------------------------------------
             */
            //Nro del primer registro de la página actual
            int pagi_from = pagi_inital + 1;
            //Nro del último registro de la página actual
            int pagi_to = pagi_inital + pagi_quantity;
            if(pagi_from > pagi_totalRecord)
            {
                //Si estamos en la última página
                //El último registro de la página actual será igual al nro de registros
                pagi_to = pagi_totalRecord;
            }
            string pagi_info = " del <b>" + pagi_from + "</b> al <b>" + pagi_to + "</b> de <b>" + pagi_current + "</b> <b>/ " + pagi_totalPags + 
                " registros por página </b>";
            //Acá primero almaceno la información que agregue al final, la navegación de las flechas y los nros para las diferentes páginas y el query que es la cantidad 
            //de registros que vamos a visualizar. 
            object[] data = { pagi_info, pagi_navegation, query };
            return data;
        }
    } 
}
