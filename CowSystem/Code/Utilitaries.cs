using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CowSystem.Code
{
    public static class Utilitaries
    {
        public static int IdEmpresa = 1; 
        public static string ConvertToColon(double money) {
            return money.ToString("C", CultureInfo.CreateSpecificCulture("es-CR"));
        }
        public static string GetDifferenceDate(DateTime startDate, DateTime endDate) {
            string msj = "";
            int years = startDate.Year - endDate.Year;
            int months = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            years = months / 12;
            months = months -(years * 12) ;

            if (years == 0 && months == 0) msj= "0 meses";

            if (years == 0 && months == 1) msj= "1 mes";
            
            if (years == 0 && (months != 0 && months>1)) msj = months +" meses";

            if (years == 1 && months == 0) msj = years +" 1 año";

            if ((years != 0 && years > 1) && months == 0) msj = years +" años";

            if (years == 1 && months == 1) msj = "1 año con 1 mes";
            if (years == 1 && (months != 0 && months > 1)) msj = "1 año con "+months+" meses";

            if ((years != 0 && years > 1) && months == 1) msj = years +" años con 1 mes";
            if ((years != 0 && years > 1) && (months != 0 && months > 1)) msj = years +" años con "+months+" meses";

            return msj;
            
        }
        public static string getRelativeTime(DateTime yourDate) {


            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - yourDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "Hace un segundo" : "Hace " +ts.Seconds + " segundos";

            if (delta < 2 * MINUTE)
                return "Hace un minuto";

            if (delta < 45 * MINUTE)
                return "Hace "+ts.Minutes + " minutos";

            if (delta < 90 * MINUTE)
                return "Hace una hora";

            if (delta < 24 * HOUR)
                return "Hace "+ts.Hours + " horas";

            if (delta < 48 * HOUR)
                return "Ayer";

            if (delta < 30 * DAY)
                return "Hace " + ts.Days + " días";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "Hace un mes" : "Hace " + months + " meses";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "hace un año" : "Hace " + years + " años";
            }


        }
    }
}
