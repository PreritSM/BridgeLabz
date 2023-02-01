using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTime
{
    public class Time2Seconds
    {
        public  int ConvertTimeformat2Sec(DateTime dt)
        {
            int hour = dt.Hour;
            int minute = dt.Minute;
            int second = dt.Second;

            int sec  = hour*3600 + minute*60 + second;
            return sec;
        }

    }
}
