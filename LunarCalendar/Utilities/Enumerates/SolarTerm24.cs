using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalendar.Utilities.Enumerates
{
    public enum SolarTerm24
    {
        [Description("立春")]
        BeginningOfSpring = 1,
        [Description("雨水")]
        Rains = 2,
        [Description("惊蛰")]
        AwakeningOfInsects = 3,
        [Description("春分")]
        VernalEquinox = 4,
        [Description("清明")]
        TombSweepingDay = 5,
        [Description("谷雨")]
        GrainRain = 6,

        [Description("立夏")]
        BeginningOfSummer = 7,
        [Description("小满")]
        LesserFullnessOfGrain = 8,
        [Description("芒种")]
        GrainInEar = 9,
        [Description("夏至")]
        SummerSolstice = 10,
        [Description("小暑")]
        SlightHeat = 11,
        [Description("大暑")]
        GreatHeat = 12,

        [Description("立秋")]
        BeginningOfAutumn = 13,
        [Description("处暑")]
        LimitOfHeat = 14,
        [Description("白露")]
        WhiteDew = 15,
        [Description("秋分")]
        AutumnalEquinox = 16,
        [Description("寒露")]
        ColdDew = 17,
        [Description("霜降")]
        FirstFrost = 18,

        [Description("立冬")]
        BeginningOfWinter = 19,
        [Description("小雪")]
        LightSnow = 20,
        [Description("大雪")]
        GreaterSnow = 21,
        [Description("冬至")]
        WinterSolstice = 22,
        [Description("小寒")]
        LesserCold = 23,
        [Description("大寒")]
        GreatCold = 24
    }
}
