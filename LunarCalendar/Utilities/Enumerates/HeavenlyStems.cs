using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalendar.Utilities.Enumerates
{
    public class HeavenlyStems
    {
        public static readonly HeavenlyStems Jia = new HeavenlyStems(1, "甲");
        public static readonly HeavenlyStems Yi = new HeavenlyStems(2, "乙");
        public static readonly HeavenlyStems Bing = new HeavenlyStems(3, "丙");
        public static readonly HeavenlyStems Ding = new HeavenlyStems(4, "丁");
        public static readonly HeavenlyStems Wu = new HeavenlyStems(5, "戊");
        public static readonly HeavenlyStems Ji = new HeavenlyStems(6, "己");
        public static readonly HeavenlyStems Geng = new HeavenlyStems(7, "庚");
        public static readonly HeavenlyStems Xin = new HeavenlyStems(8, "辛");
        public static readonly HeavenlyStems Ren = new HeavenlyStems(9, "壬");
        public static readonly HeavenlyStems Gui = new HeavenlyStems(10, "癸");

        private readonly int Id = 0;
        private readonly string HeavenlyStem = string.Empty;

        private HeavenlyStems(int id, string heavenlyStem)
        {
            Id = id;
            HeavenlyStem = heavenlyStem;
        }

        public override string ToString()
        {
            return HeavenlyStem;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return HeavenlyStem;
        }

        public HeavenlyStems FromId(int id)
        {
            switch (id)
            {
                case 1:
                    return Jia;
                case 2:
                    return Yi;
                case 3:
                    return Bing;
                case 4:
                    return Ding;
                case 5:
                    return Wu;
                case 6:
                    return Ji;
                case 7:
                    return Geng;
                case 8:
                    return Xin;
                case 9:
                    return Ren;
                case 10:
                    return Gui;
                default:
                    return null;
            }
        }
    }
}
