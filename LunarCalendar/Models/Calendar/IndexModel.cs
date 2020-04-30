using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalendar.Models.Calendar
{
    public class IndexModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public int LunarYear { get; set; }
        public int LunarMonth { get; set; }
        public int LunarDay { get; set; }

        public bool HasLeapMonth { get; set; }
        public bool IsLeapMonth { get; set; }
        public int LeapMonth { get; set; }

        public int DaysInMonth { get; set; }

        public string LunarYearName { get; set; }
        public string LunarMonthName { get; set; }
        public string LunarDayName { get; set; }

        public string EraYearName { get; set; }
        public string EraMonthName { get; set; }
        public string EraDayName { get; set; }

        public string SolarTerm24 { get; set; }
        public SolarTermMonth[] SolarTermThisMonth { get; set; }

        public class SolarTermMonth
        {
            public int Day { get; set; }
            public string SolarTerm24 { get; set; }
        }
    }
}
