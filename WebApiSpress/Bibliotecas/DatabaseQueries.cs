using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Bibliotecas
{
    public class DatabaseQueries
    {
        public static string GetDate(DateTime data, bool withTime = false)
        {
            if (data == null) return "";
            string ano = data.Year.ToString("0000");
            string mes = data.Month.ToString("00");
            string dia = data.Day.ToString("00");

            if (!withTime)
                return ano + "-" + mes + "-" + dia;

            string hora = data.Hour.ToString("00");
            string minuto = data.Minute.ToString("00");
            // não pega os segundos

            return ano + "-" + mes + "-" + dia + " " + hora + ":" + minuto + ":00";
        }

        public static Int32 GetIntDate(DateTime data)
        {
            if (data == null) return 0;
            string ano = data.Year.ToString("0000");
            string mes = data.Month.ToString("00");
            string dia = data.Day.ToString("00");

            return Convert.ToInt32(ano + mes + dia);
        }
    }
}