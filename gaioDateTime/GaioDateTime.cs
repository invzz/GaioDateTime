using System;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;

namespace gaioDateTime
{
    // See https://aka.ms/new-console-template for more information
    public class GaioDateTime
    {
        private readonly int _daysInCycle = (365 * 4) + 1;
        private readonly DateTime _firstCycleDay = new DateTime(1999, 1, 1);

        public bool IsCapodanno { get => (DayOfCycle % 365) == 1; }

        public bool IsCapociclo { get => DayOfCycle == 0 && Year == 0; }

        public int Cycle { get => 512 + (DaysSinceReference / _daysInCycle); }

        public int Year { get => (DayOfCycle - 1) / 365 % 4; }

        public int Month
        {
            get { 
                 if (!IsCapociclo && !IsCapodanno) {
                    if (Year == 0) {
                        return 1 + (DayOfCycle - 2) % 364 / 28;
                    }
                    else
                    {
                        return 1 + (DayOfCycle-2) % 365 / 28;
                    }
                 }
                return 0;
                       
                }
        }

        public int WeekInMonth
        {
            get
            {
                if (!IsCapociclo && !IsCapodanno)
                {
                    var DayOfYear = (DayOfCycle-1) % (365);
                    if (Year == 0)
                    {
                        return 1+((DayOfYear - 2)  / 4) % 7;
                    }
                    else
                    {
                        return 1+ ((DayOfYear -1  ) / 4)  % 7;
                    }
                }
                return 0;

            }
        }

        public int DayInWeek
        {
            get
            {
                if (!IsCapociclo && !IsCapodanno)
                {
                    var DayOfYear = (DayOfCycle - 1) % (365);
                    if (Year == 0)
                    {
                        return ((DayOfYear - 1) % 4) ;
                    }
                    else
                    {
                        return ((DayOfYear - 1) % 4) ;
                    }
                }
                return 0;
            }
        }

        public int DayOfCycle { get; set; }

        public int DaysInCycleRemainder { get; set; }

        public int DaysSinceReference { get; set; }


        public GaioDateTime(DateTime _date)
        {
            // Calculate the number of days since the beginning of the cycle
            TimeSpan timeSpan = _date - _firstCycleDay;
            DaysSinceReference = timeSpan.Days;

            this.AddDays(DaysSinceReference);
        }

        public override string ToString()
        {
            if(!IsCapociclo && !IsCapodanno)
                return $"{DayInWeek.ToWeekDay(),10} {(WeekInMonth),10} " +
                    $"{(Month).ToMonth(),10} {(Year+1).ToRoman(),10} " +
                    $"{ "c#" + Cycle,5}";

            return $" {(IsCapociclo ? "Capociclo" : "")}" +
                $" {(IsCapodanno ? "Capodanno" : "")}" +
                $" {(Year + 1).ToRoman()}" +
                $" {"c#"+Cycle,5}";
        }
    }
}