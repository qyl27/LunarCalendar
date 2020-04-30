using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LunarCalendar.Utilities.Enumerates
{
    public class EarthlyBranches
    {
        public static readonly EarthlyBranches Zi = new EarthlyBranches(1, "子", "鼠");
        public static readonly EarthlyBranches Chou = new EarthlyBranches(2, "丑", "牛");
        public static readonly EarthlyBranches Yin = new EarthlyBranches(3, "寅", "虎");
        public static readonly EarthlyBranches Mao = new EarthlyBranches(4, "卯", "兔");
        public static readonly EarthlyBranches Chen = new EarthlyBranches(5, "辰", "龙");
        public static readonly EarthlyBranches Si = new EarthlyBranches(6, "巳", "蛇");
        public static readonly EarthlyBranches Wu = new EarthlyBranches(7, "午", "马");
        public static readonly EarthlyBranches Wei = new EarthlyBranches(8, "未", "牛");
        public static readonly EarthlyBranches Shen = new EarthlyBranches(9, "申", "羊");
        public static readonly EarthlyBranches You = new EarthlyBranches(10, "酉", "鸡");
        public static readonly EarthlyBranches Xv = new EarthlyBranches(11, "戌", "狗");
        public static readonly EarthlyBranches Hai = new EarthlyBranches(12, "亥", "猪");

        private readonly int Id = 0;
        private readonly string EarthlyBranch = string.Empty;
        private readonly string Animal = string.Empty;

        private EarthlyBranches(int id, string earthlyBranch, string animal)
        {
            Id = id;
            EarthlyBranch = earthlyBranch;
            Animal = animal;
        }

        public override string ToString()
        {
            return EarthlyBranch;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return EarthlyBranch;
        }

        public string GetAnimal()
        {
            return Animal;
        }

        public EarthlyBranches FromId(int id)
        {
            switch (id)
            {
                case 1:
                    return Zi;
                case 2:
                    return Chou;
                case 3:
                    return Yin;
                case 4:
                    return Mao;
                case 5:
                    return Chen;
                case 6:
                    return Si;
                case 7:
                    return Wu;
                case 8:
                    return Wei;
                case 9:
                    return Shen;
                case 10:
                    return You;
                case 11:
                    return Xv;
                case 12:
                    return Hai;
                default:
                    return null;
            }
        }
    }
}
