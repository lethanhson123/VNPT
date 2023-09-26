using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class YearMonth
    {
        public int Display { get; set; }
        public YearMonth()
        {
        }
        public static List<YearMonth> GetYearToList()
        {
            List<YearMonth> list = new List<YearMonth>();
            for (int i = GlobalHelper.DateBegin; i <= GlobalHelper.DateEnd; i++)
            {
                YearMonth model = new YearMonth();
                model.Display = i;
                list.Add(model);
            }
            return list;
        }
        public static List<YearMonth> GetMonthToList()
        {
            List<YearMonth> list = new List<YearMonth>();
            for (int i = 1; i <= 12; i++)
            {
                YearMonth model = new YearMonth();
                model.Display = i;
                list.Add(model);
            }
            return list;
        }
    }
}
