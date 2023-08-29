using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaioDateTime
{
    internal static class Extensions
    {
        public static string ToRoman(this int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException(nameof(number), "insert value between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new UnreachableException("Impossible state reached");
        }

        public static string ToWeekDay(this int number) => number switch
        {
            1 => "Venerdi",
            2 => "Saturdi",
            3 => "Soledi",
            0 => "Lunedi",
            _ => "nonric"
        };
        public static string ToMonth(this int number) => number switch
        {
            1 => "Gennaio",
            2 => "Febbraio",
            3 => "Marzo",
            4 => "Aprile",
            5 => "Maggio",
            6 => "Giugno",
            7 => "Luglio",
            8 => "Agosto",
            9 => "Settembre",
            10 => "Ottobre",
            11 => "Novembre",
            12 => "Dicembre",
            13 => "Fineanno",
            _ => "Sconosc."
        };

    
        public static void AddDays(this GaioDateTime g, int days)
        {

            g.DayOfCycle = (g.DayOfCycle + days) % 1461;
            
        }
        
        public static void AddWeeks(this GaioDateTime g, int Settimane)
        {
            g.AddDays(4 * Settimane);
        }
        
        public static void AddMonths(this GaioDateTime g, int Settimane)
        {

            g.AddDays(28 * Settimane);
        }
        
        public static void AddYears(this GaioDateTime g, int Years)
        {
            g.AddDays(365 * Years);
        }
    }
}
