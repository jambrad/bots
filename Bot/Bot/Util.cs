using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    class Util
    {
        public static double min(double x, double y)
        {
            if (x < y) return x;
            else return y;
        }
    }
}
