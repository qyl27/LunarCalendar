using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using LunarCalendar.Models.Calendar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LunarCalendar.Controllers
{
    [Route("[controller]")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        public static string[] MonthName =
        {
            "正", "二", "三", "四", "五", "六", 
            "七", "八", "九", "十", "冬", "腊"
        };
        public static string[] DayName =
        {
            "一", "二", "三", "四", "五", "六", "七", "八", "九",
        };

        [HttpGet]
        public IActionResult Index()
        {
            var now = DateTime.Now;
            return Index(now.Year, now.Month, now.Day);
        }

        [HttpGet]
        [Route("{year?}/{month?}/{day?}")]
        public IActionResult Index(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var calendar = new ChineseLunisolarCalendar();

            var lunarYear = calendar.GetYear(date);
            var lunarMonth = calendar.GetMonth(date);
            var lunarDay = calendar.GetDayOfMonth(date);

            var isLeap = calendar.IsLeapMonth(lunarYear, lunarMonth);
            var leapMonth = calendar.GetLeapMonth(lunarYear);

            var lunarMonthName = string.Empty;
            if (isLeap)
            {
                if (leapMonth == lunarMonth)
                {
                    lunarMonthName += "闰";
                }
                if (leapMonth >= lunarMonth)
                {
                    lunarMonthName += MonthName[lunarMonth - 2];
                }
                else
                {
                    lunarMonthName += MonthName[lunarMonth - 1];
                }
            }
            else
            {
                lunarMonthName += MonthName[lunarMonth - 1];
            }
            lunarMonthName += "月";

            var lunarDayName = string.Empty;
            if (lunarDay <= 10)
            {
                lunarDayName += "初";
                lunarDayName += DayName[lunarDay - 1];
            }
            else if (lunarDay >= 11 && lunarDay <= 19)
            {
                lunarDayName += "十";
                lunarDayName += DayName[lunarDay - 11];
            }
            else if (lunarDay == 20)
            {
                lunarDayName += "二十";
            }
            else if (lunarDay >= 21 && lunarDay <= 29)
            {
                lunarDayName += "廿";
                lunarDayName += DayName[lunarDay - 21];
            }
            else if (lunarDay == 30)
            {
                lunarDayName += "三十";
            }

            var response = new IndexModel()
            {
                Year = date.Year,
                Month = date.Month,
                Day = date.Day,

                LunarYear = lunarYear,
                LunarMonth = lunarMonth,
                LunarDay = lunarDay,
                
                LunarYearName = lunarMonthName,
                LunarDayName = lunarDayName,
                
                HasLeapMonth = calendar.IsLeapYear(lunarYear), 
                IsLeapMonth = isLeap,

                DaysInMonth = calendar.GetDaysInMonth(lunarYear, lunarMonth)
            };

            if (isLeap)
            {
                response.LeapMonth = leapMonth;
            }

            return new JsonResult(response);
        }
    }
}